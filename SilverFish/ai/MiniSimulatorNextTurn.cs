namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public class MiniSimulatorNextTurn
    {
        //#####################################################################################################################
        //public int maxdeep = 6;
        //public int maxwide = 10;
        //public int totalboards = 50;

        public int thread = 0;

        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;
        
        List<Playfield> posmoves = new List<Playfield>(7000);

        public Action bestmove = null;
        public float bestmoveValue = 0;
        public Playfield bestboard = new Playfield();

        public Behavior botBase = null;
        private int calculated = 0;

        private bool simulateSecondTurn = false;

        Movegenerator movegen = Movegenerator.Instance;
        

        public MiniSimulatorNextTurn()
        {
        }




        private void startEnemyTurnSim(Playfield p, bool simulateTwoTurns, bool print, bool playaround, int playaroundprob, int playaroundprob2)
        {
            if (p.guessingHeroHP >= 1)
            {

                Ai.Instance.enemySecondTurnSim[this.thread].simulateEnemysTurn(p, simulateTwoTurns, playaround, print, playaroundprob, playaroundprob2);
            }
            p.complete = true;
        }

        public float doallmoves(Playfield playf, bool print = false)
        {
            //todo only one time!
            bool isLethalCheck = playf.isLethalCheck;
            int totalboards = Settings.Instance.nextTurnTotalBoards;
            int maxwide = Settings.Instance.nextTurnMaxWide;
            int maxdeep = Settings.Instance.nextTurnDeep;
            bool playaround = Settings.Instance.playaround;
            int playaroundprob = Settings.Instance.playaroundprob;
            int playaroundprob2 = Settings.Instance.playaroundprob2;
            
            botBase = Ai.Instance.botBase;
            this.posmoves.Clear();
            this.posmoves.Add(new Playfield(playf));
            bool havedonesomething = true;
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            this.calculated = 0;
            Playfield bestold = null;
            float bestoldval = -20000000;
            while (havedonesomething)
            {
                //GC.Collect();
                temp.Clear();
                temp.AddRange(this.posmoves);
                havedonesomething = false;
                foreach (Playfield p in temp)
                {
                    if (p.complete || p.ownHero.Hp <= 0)
                    {
                        continue;
                    }

                    List<Action> actions = movegen.getMoveList(p, usePenalityManager, useCutingTargets, true);
                    foreach (Action a in actions)
                    {
                        havedonesomething = true;
                        Playfield pf = new Playfield(p);
                        pf.doAction(a);
                        if (pf.ownHero.Hp > 0) this.posmoves.Add(pf);
                        if (totalboards > 0) this.calculated++;
                    }


                    p.endTurn();

                    if (!isLethalCheck) this.startEnemyTurnSim(p, this.simulateSecondTurn, false, playaround, playaroundprob, playaroundprob2);

                    //sort stupid stuff ouf

                    if (botBase.getPlayfieldValue(p) > bestoldval)
                    {
                        bestoldval = botBase.getPlayfieldValue(p);
                        bestold = p;
                    }
                    posmoves.Remove(p);

                    if (this.calculated > totalboards) break;
                }
                cuttingposibilities(maxwide);
                
                deep++;

                if (this.calculated > totalboards) break;
                if (deep >= maxdeep) break;
            }

            posmoves.Add(bestold);
            foreach (Playfield p in posmoves)
            {
                if (!p.complete)
                {

                    p.endTurn();
                    if (!isLethalCheck) this.startEnemyTurnSim(p, this.simulateSecondTurn, false, playaround, playaroundprob, playaroundprob2);
                }
            }
            // find best

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
                    if (bestplay.playactions.Count <= posmoves[i].playactions.Count) continue; //priority to the minimum acts
                    bestplay = posmoves[i];
                    bestval = val;
                }
                this.bestmove = bestplay.getNextAction();
                this.bestmoveValue = bestval;
                this.bestboard = new Playfield(bestplay);
                return bestval;
            }
            this.bestmove = null;
            this.bestmoveValue = -100000;
            this.bestboard = playf;
            return -10000;
        }

        public void cuttingposibilities(int maxwide)
        {
            // take the x best values
            List<Playfield> temp = new List<Playfield>();
            Dictionary<Int64, Playfield> tempDict = new Dictionary<Int64, Playfield>();
            posmoves.Sort((a, b) => -(botBase.getPlayfieldValue(a)).CompareTo(botBase.getPlayfieldValue(b)));//want to keep the best

            if (this.useComparison)
            {
                int i = 0;
                int max = Math.Min(posmoves.Count, maxwide);

                Playfield p = null;
                //foreach (Playfield p in posmoves)
                for (i = 0; i < max; i++)
                {
                    p = posmoves[i];
                    Int64 hash = p.GetPHash();
                    p.hashcode = hash;
                    if (!tempDict.ContainsKey(hash)) tempDict.Add(hash, p);

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
            posmoves.AddRange(temp.GetRange(0, Math.Min(maxwide, temp.Count)));

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
                    /*if (penman.priorityDatabase.ContainsKey(m.name))
                    {
                        //retvalues.Add(t);
                        retvaluesPrio.Add(t);
                        priomins = true;
                        //help.logg(m.name + " is added to targetlist");
                        continue;
                    }*/


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
            foreach (Playfield p in this.posmoves)
            {
                p.printBoard();
            }
        }

    }


}