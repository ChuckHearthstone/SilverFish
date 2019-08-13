namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using System.Linq;

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

        private bool printNormalstuff = false;
        private bool print = false;

        List<Playfield> posmoves = new List<Playfield>(7000);
        List<Playfield> bestoldDuplicates = new List<Playfield>(7000);
        List<Playfield> twoturnfields = new List<Playfield>(500);

        List<List<Playfield>> threadresults = new List<List<Playfield>>(64);
        private int dirtyTwoTurnSim = 256;

        public Action bestmove = null;
        public float bestmoveValue = 0;
        private float bestoldval = -20000000;
        public Playfield bestboard = new Playfield();

        public Behavior botBase = null;
        private int calculated = 0;
        private bool enoughCalculations = false;

        private bool isLethalCheck = false;
        private bool simulateSecondTurn = false;
        private bool playaround = false;
        private int playaroundprob = 50;
        private int playaroundprob2 = 80;

        private static readonly object threadnumberLocker = new object();
        private int threadnumberGlobal = 0;

        Movegenerator movegen = Movegenerator.Instance;

        PenalityManager pen = PenalityManager.Instance;

        public MiniSimulator()
        {
        }
        public MiniSimulator(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void updateParams(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void setPrintingstuff(bool sp)
        {
            this.printNormalstuff = sp;
        }

        public void setSecondTurnSimu(bool sts, int amount)
        {
            //this.simulateSecondTurn = sts;
            this.dirtyTwoTurnSim = amount;
        }

        public int getSecondTurnSimu()
        {
            return this.dirtyTwoTurnSim;
        }

        public void setPlayAround(bool spa, int pprob, int pprob2)
        {
            this.playaround = spa;
            this.playaroundprob = pprob;
            this.playaroundprob2 = pprob2;
        }

        private void addToPosmoves(Playfield pf)
        {
            if (pf.ownHero.Hp <= 0) return;
            this.posmoves.Add(pf);
            if (this.totalboards >= 1)
            {
                this.calculated++;
            }
        }
        
        public float doallmoves(Playfield playf)
        {
            print = playf.print;
            this.isLethalCheck = playf.isLethalCheck;
            enoughCalculations = false;
            botBase = Ai.Instance.botBase;
            this.posmoves.Clear();
            this.twoturnfields.Clear();
            this.addToPosmoves(playf);
            bool havedonesomething = true;
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            this.calculated = 0;
            Playfield bestold = null;
            bestoldval = -20000000;
            while (havedonesomething)
            {
                if (this.printNormalstuff) Helpfunctions.Instance.logg("ailoop");
                GC.Collect();
                temp.Clear();
                temp.AddRange(this.posmoves);
                this.posmoves.Clear();
                havedonesomething = false;
                threadnumberGlobal = 0;

                if (print) startEnemyTurnSimThread(temp, 0, temp.Count);
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
                    if (this.totalboards > 0) this.calculated += p.nextPlayfields.Count;
                    if (this.calculated <= this.totalboards)
                    {
                        this.posmoves.AddRange(p.nextPlayfields);
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
                if (isLethalCheck && bestoldval >= 10000) this.posmoves.Clear();
                if (this.posmoves.Count > 0) havedonesomething = true;
                
                if (this.printNormalstuff)
                {
                    int donec = 0;
                    foreach (Playfield p in posmoves)
                    {
                        if (p.complete) donec++;
                    }
                    Helpfunctions.Instance.logg("deep " + deep + " len " + this.posmoves.Count + " dones " + donec);
                }

                cuttingposibilities(isLethalCheck);

                if (this.printNormalstuff)
                {
                    Helpfunctions.Instance.logg("cut to len " + this.posmoves.Count);
                }
                deep++;
                temp.Clear();

                if (this.calculated > this.totalboards) enoughCalculations = true;
                if (deep >= this.maxdeep) enoughCalculations = true;
            }
            
            if (this.dirtyTwoTurnSim > 0 && !twoturnfields.Contains(bestold)) twoturnfields.Add(bestold);
            this.posmoves.Clear();
            this.posmoves.Add(bestold);
            this.posmoves.AddRange(bestoldDuplicates);

            // search the best play...........................................................
            //do dirtytwoturnsim first :D
            if (!isLethalCheck && bestoldval < 10000) doDirtyTwoTurnsim();

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
                    else if (posmoves[i].cardsPlayedThisTurn == bestplay.cardsPlayedThisTurn)
                    {
                        if (bestplay.optionsPlayedThisTurn > posmoves[i].optionsPlayedThisTurn) continue; 
                        else if (bestplay.optionsPlayedThisTurn == posmoves[i].optionsPlayedThisTurn && bestplay.enemyHero.Hp <= posmoves[i].enemyHero.Hp) continue;
                        
                    }
                    bestplay = posmoves[i];
                    bestval = val;
                }
                this.bestmove = bestplay.getNextAction();
                this.bestmoveValue = bestval;
                this.bestboard = new Playfield(bestplay);
                this.bestboard.guessingHeroHP = bestplay.guessingHeroHP;
                this.bestboard.value = bestplay.value;
                this.bestboard.hashcode = bestplay.hashcode;
                bestoldDuplicates.Clear();
                return bestval;
            }
            this.bestmove = null;
            this.bestmoveValue = -100000;
            this.bestboard = playf;

            return -10000;
        }


        private void startEnemyTurnSimThread(List<Playfield> source, int startIndex, int endIndex)
        {
            int threadnumber = 0;
            lock (threadnumberLocker)
            {
                threadnumber = threadnumberGlobal++;
                System.Threading.Monitor.Pulse(threadnumberLocker);
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
                if (p.complete || p.ownHero.Hp <= 0) { }
                else if (!enoughCalculations)
                {
                    //gernerate actions and play them!
                    List<Action> actions = movegen.getMoveList(p, usePenalityManager, useCutingTargets, true);

                    if (printRules > 0) p.endTurnState = new Playfield(p);
                    foreach (Action a in actions)
                    {
                        Playfield pf = new Playfield(p);
                        pf.doAction(a);
                        pf.evaluatePenality += - pf.ruleWeight + RulesEngine.Instance.getRuleWeight(pf);
                        if (pf.ownHero.Hp > 0 && pf.evaluatePenality < 500) p.nextPlayfields.Add(pf);
                    }
                }

                if (this.isLethalCheck)
                {
                    if (berserk > 0)
                    {
                        p.endTurn();
                        if (p.enemyHero.Hp > 0)
                        {
                            bool needETS = true;
                            if (p.anzEnemyTaunt < 1) foreach (Minion m in p.ownMinions) { if (m.Ready) { needETS = false; break; } }
                            else
                            {
                                if (p.anzOwnTaunt < 1) foreach (Minion m in p.ownMinions) { if (m.Ready) { needETS = false; break; } }
                            }
                            if (needETS) Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, this.simulateSecondTurn, playaround, false, playaroundprob, playaroundprob2);
                        }
                    }
 
                    p.complete = true;

                }
                else
                {
                    p.endTurn();

                    if (p.enemyHero.Hp > 0)
                    {
                        Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, this.simulateSecondTurn, playaround, false, playaroundprob, playaroundprob2);
                        if (p.value <= -10000)
                        {
                            bool secondChance = false;
                            foreach (Action a in p.playactions)
                            {
                                if (a.actionType == actionEnum.playcard)
                                {
                                    if (pen.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name)) secondChance = true;
                                }
                            }
                            if (secondChance) p.value += 1500;
                        }
                    }
                    p.complete = true;
                }
                botBase.getPlayfieldValue(p);
            }
        }

        public void doDirtyTwoTurnsim()
        {
            if (this.dirtyTwoTurnSim == 0) return;
            this.posmoves.Clear();

            if (print) doDirtyTwoTurnsimThread(twoturnfields, 0, twoturnfields.Count);
            else
            {
                Parallel.ForEach(Partitioner.Create(0, this.twoturnfields.Count),
                          range =>
                          {
                              doDirtyTwoTurnsimThread(twoturnfields, range.Item1, range.Item2);
                          });
            }
            this.posmoves.AddRange(this.twoturnfields);
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
                    Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, true, playaround, false, this.playaroundprob, this.playaroundprob2);
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

            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(posmoves.Count, this.maxwide);

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
            if (this.dirtyTwoTurnSim == 0 || isLethalCheck) return;
            tempDict.Clear();
            temp.Clear();
            if (bestoldval >= 10000) return;
            foreach (Playfield p in twoturnfields) tempDict.Add(p.hashcode, p);
            posmoves.Sort((a, b) => botBase.getPlayfieldValue(b).CompareTo(botBase.getPlayfieldValue(a)));

            int maxTts = Math.Min(posmoves.Count, this.dirtyTwoTurnSim);
            for (int i = 0; i < maxTts; i++)
            {
                if (!tempDict.ContainsKey(posmoves[i].hashcode)) temp.Add(posmoves[i]);
            }
            twoturnfields.Sort((a, b) => botBase.getPlayfieldValue(b).CompareTo(botBase.getPlayfieldValue(a)));
            temp.AddRange(twoturnfields.GetRange(0, Math.Min(this.dirtyTwoTurnSim, twoturnfields.Count)));
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
                        //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                        bool otherisSpecial = mnn.handcard.card.isSpecialMinion;

                        if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                        {
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal) goingtoadd = false;
                            continue;
                        }

                        if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                        {
                            if (m.name != mnn.name) // different name -> take it
                            {
                                continue;
                            }
                            // same name -> test whether they are equal
                            if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal) goingtoadd = false;
                            continue;
                        }

                    }

                    if (goingtoadd)
                    {
                        addedmins.Add(m);
                        retvalues.Add(t);
                        //help.logg(m.name + " " + m.id +" is added to targetlist");
                    }
                    else
                    {
                        //help.logg(m.name + " is not needed to attack");
                        continue;
                    }

                }
            }
            //help.logg("end targetcutting");
            if (priomins) return retvaluesPrio;

            return retvalues;
        }

        public void printPosmoves()
        {
            int i = 0;
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
                i++;
                if (i >= 200) break;
            }
        }

    }

}