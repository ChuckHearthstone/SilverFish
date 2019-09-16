using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SilverFish.Helpers;

namespace Chuck.SilverFish
{
    public class MiniSimulator
    {
        //#####################################################################################################################
        private int maxdeep = 6;
        private int maxwide = 10;
        private int totalboards = 50;
        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;

        private bool printNormalstuff;
        private bool print;

        List<Playfield> posmoves = new List<Playfield>(7000);
        List<Playfield> bestoldDuplicates = new List<Playfield>(7000);
        List<Playfield> twoturnfields = new List<Playfield>(500);

        List<List<Playfield>> threadresults = new List<List<Playfield>>(64);
        private int dirtyTwoTurnSim = 256;

        public Action bestmove;
        public float bestmoveValue;
        private float bestoldval = -20000000;
        public Playfield bestboard = new Playfield();

        public Behavior botBase;
        private int calculated;
        private bool enoughCalculations;

        private bool isLethalCheck;
        private bool simulateSecondTurn = false;
        private bool playaround;
        private int playaroundprob = 50;
        private int playaroundprob2 = 80;

        private static readonly object threadnumberLocker = new object();
        private int threadnumberGlobal;

        Movegenerator movegen = Movegenerator.Instance;

        PenaltyManager pen = PenaltyManager.Instance;

        public MiniSimulator()
        {
        }
        public MiniSimulator(int deep, int wide, int ttlboards)
        {
            maxdeep = deep;
            maxwide = wide;
            totalboards = ttlboards;
        }

        public void updateParams(int deep, int wide, int ttlboards)
        {
            maxdeep = deep;
            maxwide = wide;
            totalboards = ttlboards;
        }

        public void setPrintingstuff(bool sp)
        {
            printNormalstuff = sp;
        }

        public void setSecondTurnSimu(bool sts, int amount)
        {
            //this.simulateSecondTurn = sts;
            dirtyTwoTurnSim = amount;
        }

        public int getSecondTurnSimu()
        {
            return dirtyTwoTurnSim;
        }

        public void setPlayAround(bool spa, int pprob, int pprob2)
        {
            playaround = spa;
            playaroundprob = pprob;
            playaroundprob2 = pprob2;
        }

        private void addToPosmoves(Playfield pf)
        {
            if (pf.ownHero.HealthPoints <= 0) return;
            posmoves.Add(pf);
            if (totalboards >= 1)
            {
                calculated++;
            }
        }
        
        public float DoAllMoves(Playfield playf)
        {
            print = playf.print;
            isLethalCheck = playf.isLethalCheck;
            enoughCalculations = false;
            botBase = Ai.Instance.botBase;
            posmoves.Clear();
            twoturnfields.Clear();
            addToPosmoves(playf);
            bool havedonesomething = true;
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            calculated = 0;
            Playfield bestold = null;
            bestoldval = -20000000;
            int loopCount = -1;
            while (havedonesomething)
            {
                loopCount++;
                if (printNormalstuff)
                {
                    LogHelper.WriteCombatLog($"ailoop{loopCount}");
                }
                GC.Collect();
                temp.Clear();
                temp.AddRange(posmoves);
                posmoves.Clear();
                havedonesomething = false;
                threadnumberGlobal = 0;

                if (print)
                {
                    startEnemyTurnSimThread(temp, 0, temp.Count);
                }
                else
                {
                    Parallel.ForEach(Partitioner.Create(0, temp.Count),
                         range =>
                         {
                             startEnemyTurnSimThread(temp, range.Item1, range.Item2);
                         });
                }

                foreach (Playfield p in temp)
                {
                    if (totalboards > 0) calculated += p.nextPlayfields.Count;
                    if (calculated <= totalboards)
                    {
                        posmoves.AddRange(p.nextPlayfields);
                        p.nextPlayfields.Clear();
                    }
                    
                    //get the best Playfield
                    float pVal = botBase.getPlayfieldValue(p);
                    if (pVal > bestoldval)
                    {
                        bestoldval = pVal;
                        bestold = p;
                        bestoldDuplicates.Clear();
                    }
                    else if (pVal == bestoldval) bestoldDuplicates.Add(p);
                }

                if (isLethalCheck && bestoldval >= 10000)
                {
                    posmoves.Clear();
                }

                if (posmoves.Count > 0)
                {
                    havedonesomething = true;
                }
                
                if (printNormalstuff)
                {
                    int donec = 0;
                    foreach (Playfield p in posmoves)
                    {
                        if (p.complete)
                        {
                            donec++;
                        }
                    }
                    LogHelper.WriteCombatLog("deep " + deep + " len " + posmoves.Count + " dones " + donec);
                }

                cuttingposibilities(isLethalCheck);

                if (printNormalstuff)
                {
                    LogHelper.WriteCombatLog("cut to len " + posmoves.Count);
                }
                deep++;
                temp.Clear();

                if (calculated > totalboards)
                {
                    enoughCalculations = true;
                }

                if (deep >= maxdeep)
                {
                    enoughCalculations = true;
                }
            }

            if (dirtyTwoTurnSim > 0 && !twoturnfields.Contains(bestold))
            {
                twoturnfields.Add(bestold);
            }
            posmoves.Clear();
            posmoves.Add(bestold);
            posmoves.AddRange(bestoldDuplicates);

            // search the best play...........................................................
            //do dirtytwoturnsim first :D
            if (!isLethalCheck && bestoldval < 10000)
            {
                doDirtyTwoTurnsim();
            }

            if (posmoves.Count >= 1)
            {
                posmoves.Sort((a, b) => botBase.getPlayfieldValue(b).CompareTo(botBase.getPlayfieldValue(a)));
                Playfield bestplay = posmoves[0];
                float bestval = botBase.getPlayfieldValue(bestplay);
                int pcount = posmoves.Count;
                for (int i = 1; i < pcount; i++)
                {
                    float val = botBase.getPlayfieldValue(posmoves[i]);
                    if (bestval > val) break;
                    if (posmoves[i].cardsPlayedThisTurn > bestplay.cardsPlayedThisTurn) continue;
                    if (posmoves[i].cardsPlayedThisTurn == bestplay.cardsPlayedThisTurn)
                    {
                        if (bestplay.optionsPlayedThisTurn > posmoves[i].optionsPlayedThisTurn) continue;
                        if (bestplay.optionsPlayedThisTurn == posmoves[i].optionsPlayedThisTurn && bestplay.enemyHero.HealthPoints <= posmoves[i].enemyHero.HealthPoints) continue;

                    }
                    bestplay = posmoves[i];
                    bestval = val;
                }
                bestmove = bestplay.getNextAction();
                bestmoveValue = bestval;
                bestboard = new Playfield(bestplay);
                bestboard.guessingHeroHP = bestplay.guessingHeroHP;
                bestboard.value = bestplay.value;
                bestboard.hashcode = bestplay.hashcode;
                bestoldDuplicates.Clear();
                return bestval;
            }
            bestmove = null;
            bestmoveValue = -100000;
            bestboard = playf;

            return -10000;
        }


        private void startEnemyTurnSimThread(List<Playfield> source, int startIndex, int endIndex)
        {
            int threadnumber = 0;
            lock (threadnumberLocker)
            {
                threadnumber = threadnumberGlobal++;
                Monitor.Pulse(threadnumberLocker);
            }
            if (threadnumber > Ai.Instance.maxNumberOfThreads - 2)
            {
                threadnumber = Ai.Instance.maxNumberOfThreads - 2;
                Helpfunctions.Instance.ErrorLog("You need more threads!");
                return;
            }


            int berserk = Settings.Instance.berserkIfCanFinishNextTour;
            int printRules = Settings.Instance.printRules;

            for (int i = startIndex; i < endIndex; i++)
            {
                Playfield p = source[i];
                if (p.complete || p.ownHero.HealthPoints <= 0) { }
                else if (!enoughCalculations)
                {
                    //gernerate actions and play them!
                    List<Action> actions = movegen.GetMoveList(p, usePenalityManager, useCutingTargets, true);

                    if (printRules > 0)
                    {
                        p.endTurnState = new Playfield(p);
                    }
                    foreach (Action a in actions)
                    {
                        Playfield pf = new Playfield(p);
                        pf.doAction(a);
                        pf.evaluatePenality += - pf.ruleWeight + RulesEngine.Instance.getRuleWeight(pf);
                        if (pf.ownHero.HealthPoints > 0 && pf.evaluatePenality < 500) p.nextPlayfields.Add(pf);
                    }
                }

                if (isLethalCheck)
                {
                    if (berserk > 0)
                    {
                        p.endTurn();
                        if (p.enemyHero.HealthPoints > 0)
                        {
                            bool needETS = true;
                            if (p.anzEnemyTaunt < 1) foreach (Minion m in p.ownMinions) { if (m.Ready) { needETS = false; break; } }
                            else
                            {
                                if (p.anzOwnTaunt < 1) foreach (Minion m in p.ownMinions) { if (m.Ready) { needETS = false; break; } }
                            }
                            if (needETS) Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, simulateSecondTurn, playaround, false, playaroundprob, playaroundprob2);
                        }
                    }
 
                    p.complete = true;

                }
                else
                {
                    p.endTurn();

                    if (p.enemyHero.HealthPoints > 0)
                    {
                        Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, simulateSecondTurn, playaround, false, playaroundprob, playaroundprob2);
                        if (p.value <= -10000)
                        {
                            bool secondChance = false;
                            foreach (Action a in p.playactions)
                            {
                                if (a.actionType == actionEnum.playcard)
                                {
                                    if (pen.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name))
                                    {
                                        secondChance = true;
                                    }
                                }
                            }

                            if (secondChance)
                            {
                                p.value += 1500;
                            }
                        }
                    }
                    p.complete = true;
                }
                botBase.getPlayfieldValue(p);
            }
        }

        public void doDirtyTwoTurnsim()
        {
            if (dirtyTwoTurnSim == 0) return;
            posmoves.Clear();

            if (print) doDirtyTwoTurnsimThread(twoturnfields, 0, twoturnfields.Count);
            else
            {
                Parallel.ForEach(Partitioner.Create(0, twoturnfields.Count),
                          range =>
                          {
                              doDirtyTwoTurnsimThread(twoturnfields, range.Item1, range.Item2);
                          });
            }
            posmoves.AddRange(twoturnfields);
        }

        public void doDirtyTwoTurnsimThread(List<Playfield> source, int startIndex, int endIndex)
        {
            int threadnumber = Ai.Instance.maxNumberOfThreads - 2;
            if (endIndex < source.Count) threadnumber = startIndex / (endIndex - startIndex);
            //set maxwide of enemyturnsimulator's to second step (this value is higher than the maxwide in first step) 
            Ai.Instance.enemyTurnSim[threadnumber].setMaxwide(false);

            for (int i = startIndex; i < endIndex; i++)
            {
                Playfield p = source[i];
                if (p.guessingHeroHP >= 1)
                {
                    p.doDirtyTts = p.value;
                    p.complete = false;
                    p.value = int.MinValue;
                    p.bestEnemyPlay = null;
                    Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, true, playaround, false, playaroundprob, playaroundprob2);
                }
                else
                {
                    //p.value = -10000;
                }
                botBase.getPlayfieldValue(p);
            }
        }


        public void cuttingposibilities(bool isLethalCheck)
        {
            // take the x best values
            List<Playfield> temp = new List<Playfield>();
            Dictionary<Int64, Playfield> tempDict = new Dictionary<Int64, Playfield>();
            posmoves.Sort((a, b) => botBase.getPlayfieldValue(b).CompareTo(botBase.getPlayfieldValue(a)));//want to keep the best

            if (useComparison)
            {
                int i = 0;
                int max = Math.Min(posmoves.Count, maxwide);

                Playfield p = null;
                for (i = 0; i < max; i++)
                {
                    p = posmoves[i];
                    Int64 hash = p.GetPHash();
                    p.hashcode = hash;
                    if (!tempDict.ContainsKey(hash)) tempDict.Add(hash, p);
                    else if (p.evaluatePenality < tempDict[hash].evaluatePenality)
                    {
                        tempDict[hash] = p;
                    }
                }
                foreach (KeyValuePair<Int64, Playfield> d in tempDict)
                {
                    temp.Add(d.Value);
                }
            }
            else
            {
                temp.AddRange(posmoves);
            }
            posmoves.Clear();
            posmoves.AddRange(temp);




            //twoturnfields!
            if (dirtyTwoTurnSim == 0 || isLethalCheck) return;
            tempDict.Clear();
            temp.Clear();
            if (bestoldval >= 10000) return;
            foreach (Playfield p in twoturnfields) tempDict.Add(p.hashcode, p);
            posmoves.Sort((a, b) => botBase.getPlayfieldValue(b).CompareTo(botBase.getPlayfieldValue(a)));

            int maxTts = Math.Min(posmoves.Count, dirtyTwoTurnSim);
            for (int i = 0; i < maxTts; i++)
            {
                if (!tempDict.ContainsKey(posmoves[i].hashcode)) temp.Add(posmoves[i]);
            }
            twoturnfields.Sort((a, b) => botBase.getPlayfieldValue(b).CompareTo(botBase.getPlayfieldValue(a)));
            temp.AddRange(twoturnfields.GetRange(0, Math.Min(dirtyTwoTurnSim, twoturnfields.Count)));
            twoturnfields.Clear();
            twoturnfields.AddRange(temp);



        }

        public List<targett> cutAttackTargets(List<targett> oldlist, Playfield p, bool own)
        {
            List<targett> retvalues = new List<targett>();
            List<Minion> addedmins = new List<Minion>(8);

            bool priomins = false;
            List<targett> retvaluesPrio = new List<targett>();
            foreach (targett t in oldlist)
            {
                if ((own && t.target == 200) || (!own && t.target == 100))
                {
                    retvalues.Add(t);
                    continue;
                }
                if ((own && t.target >= 10 && t.target <= 19) || (!own && t.target >= 0 && t.target <= 9))
                {
                    Minion m = null;
                    if (own) m = p.enemyMinions[t.target - 10];
                    if (!own) m = p.ownMinions[t.target];


                    bool goingtoadd = true;
                    List<Minion> temp = new List<Minion>(addedmins);
                    bool isSpecial = m.handcard.card.isSpecialMinion;
                    foreach (Minion mnn in temp)
                    {
                        // special minions are allowed to attack in silended and unsilenced state!
                        //LogHelper.WriteCombatLog(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = mnn.handcard.card.isSpecialMinion;

                        if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                        {
                            if (mnn.Attack == m.Attack && mnn.HealthPoints == m.HealthPoints && mnn.DivineShield == m.DivineShield && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal) goingtoadd = false;
                            continue;
                        }

                        if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                        {
                            if (m.name != mnn.name) // different name -> take it
                            {
                                continue;
                            }
                            // same name -> test whether they are equal
                            if (mnn.Attack == m.Attack && mnn.HealthPoints == m.HealthPoints && mnn.DivineShield == m.DivineShield && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal) goingtoadd = false;
                            continue;
                        }

                    }

                    if (goingtoadd)
                    {
                        addedmins.Add(m);
                        retvalues.Add(t);
                        //LogHelper.WriteCombatLog(m.name + " " + m.id +" is added to targetlist");
                    }
                    else
                    {
                        //LogHelper.WriteCombatLog(m.name + " is not needed to attack");
                        continue;
                    }
                }
            }
            //LogHelper.WriteCombatLog("end targetcutting");
            if (priomins) return retvaluesPrio;

            return retvalues;
        }

        public void printPosmoves()
        {
            int i = 0;
            foreach (Playfield p in posmoves)
            {
                p.printBoard();
                i++;
                if (i >= 200) break;
            }
        }

    }

}