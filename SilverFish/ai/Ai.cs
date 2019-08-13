namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Ai
    {

        private int maxdeep = 12;
        public int maxwide = 3000;
        //public int playaroundprob = 40;
        public int playaroundprob2 = 80;

        
        private bool dontRecalc = true;
        private bool useLethalCheck = true;

        public Playfield bestplay = new Playfield();


        public int lethalMissing = 30; //RR

        public MiniSimulator mainTurnSimulator;

        public List<EnemyTurnSimulator> enemyTurnSim = new List<EnemyTurnSimulator>();
        public List<MiniSimulatorNextTurn> nextTurnSimulator = new List<MiniSimulatorNextTurn>();
        public List<EnemyTurnSimulator> enemySecondTurnSim = new List<EnemyTurnSimulator>();

        public string currentCalculatedBoard = "1";

        PenalityManager penman = PenalityManager.Instance;

        List<Playfield> posmoves = new List<Playfield>(7000);

        Hrtprozis hp = Hrtprozis.Instance;
        Handmanager hm = Handmanager.Instance;
        Helpfunctions help = Helpfunctions.Instance;

        public Action bestmove;
        public float bestmoveValue;
        public Playfield nextMoveGuess = new Playfield();
        public Playfield oldMoveGuess = new Playfield();//used for queque actions
        public Behavior botBase;

        public List<Action> bestActions = new List<Action>();

        public bool secondturnsim;
        //public int secondTurnAmount = 256;
        public bool playaround = false;

        public int bestTracking = -1;
        public int bestTrackingStatus;//0=optimal, 1= suboptimal 2=random


        private static Ai instance;

        public static Ai Instance
        {
            get
            {
                return instance ?? (instance = new Ai());
            }
        }

        private Ai()
        {
            this.nextMoveGuess = new Playfield { mana = -100 };

            this.mainTurnSimulator = new MiniSimulator(maxdeep, maxwide, 0); // 0 for unlimited
            this.mainTurnSimulator.setPrintingstuff(true);

            /*this.nextTurnSimulator = new MiniSimulatorNextTurn();
            this.enemyTurnSim = new EnemyTurnSimulator();
            this.enemySecondTurnSim = new EnemyTurnSimulator();*/

            for (int i = 0; i < Settings.Instance.numberOfThreads; i++)
            {
                this.nextTurnSimulator.Add(new MiniSimulatorNextTurn());
                this.enemyTurnSim.Add(new EnemyTurnSimulator());
                this.enemySecondTurnSim.Add(new EnemyTurnSimulator());

                this.nextTurnSimulator[i].thread = i;
                this.enemyTurnSim[i].thread = i;
                this.enemySecondTurnSim[i].thread = i;
            }

        }

        public void setMaxWide(int mw)
        {
            this.maxwide = mw;
            if (maxwide <= 100) this.maxwide = 100;
            this.mainTurnSimulator.updateParams(maxdeep, maxwide, 0);
        }

        public void setTwoTurnSimulation(bool stts, int amount)
        {
            this.mainTurnSimulator.setSecondTurnSimu(stts, amount);
            this.secondturnsim = stts;
            Settings.Instance.secondTurnAmount = amount;
        }

        public void updateTwoTurnSim()
        {
            this.mainTurnSimulator.setSecondTurnSimu(Settings.Instance.simulateEnemysTurn, Settings.Instance.secondTurnAmount);
        }

        public void setPlayAround()
        {
            this.mainTurnSimulator.setPlayAround(Settings.Instance.playarround, Settings.Instance.playaroundprob, Settings.Instance.playaroundprob2);
        }

        private void doallmoves(bool test, bool isLethalCheck)
        {
            //set maxwide to the value for the first-turn-sim.
            foreach (EnemyTurnSimulator ets in enemyTurnSim)
            {
                ets.setMaxwideFirstStep(true);
            }

            foreach (EnemyTurnSimulator ets in enemySecondTurnSim)
            {
                ets.setMaxwideFirstStep(false);
            }

            if (isLethalCheck) this.posmoves[0].enemySecretList.Clear();
            this.mainTurnSimulator.doallmoves(this.posmoves[0], isLethalCheck);

            bestplay = this.mainTurnSimulator.bestboard;
            float bestval = this.mainTurnSimulator.bestmoveValue;

            help.loggonoff(true);
            help.logg("-------------------------------------");
            help.logg("value of best board " + bestval);

            if (isLethalCheck)
            {
                this.lethalMissing = bestplay.enemyHero.armor + bestplay.enemyHero.Hp;//RR
                help.logg("missing dmg to lethal " + this.lethalMissing);
            }
            else
            {
                this.lethalMissing = 130;
            }

            //set best tracking
            this.bestTracking = 0;
            this.bestTrackingStatus = 0;
            if(Handmanager.Instance.getNumberChoices()>=1) selectBestTracking();

            //set best actions
            this.bestActions.Clear();
            this.bestmove = null;
            foreach (Action a in bestplay.playactions)
            {
                this.bestActions.Add(new Action(a));
                a.print();
            }
            //todo sepefeets - enable after implementing anzEnemyTaunt or finding alternative            //if (isLethalCheck) reorderingActions();

            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }
            this.bestmoveValue = bestval;

            if (bestmove != null && bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
            {
                this.nextMoveGuess = new Playfield();

                //TODO: add card if bestTracking was calculated!

                this.nextMoveGuess.doAction(bestmove);
            }
            else
            {
                nextMoveGuess.mana = -100;
            }

        }

        private void reorderingActions()
        {
            if (bestplay.enemySecretCount > 0) return;
            if (bestplay.playactions.Count < 2) return;
            if (Ai.Instance.botBase.getPlayfieldValue(bestplay) < 10000) return;
            Playfield tmpPf = new Playfield();
            if (tmpPf.anzEnemyTaunt > 0) return;

            List<Action> reorderedActions = new List<Action>();
            Dictionary<Action, int> actDmgDict = new Dictionary<Action, int>();
            tmpPf.enemyHero.Hp = 30;
            try

            {
                int useability = 0;
                foreach (Action a in bestplay.playactions)
                {
                    if (a.actionType == actionEnum.useHeroPower) useability = 1;
                    if (a.actionType == actionEnum.attackWithHero) useability++;
                    int actDmd = tmpPf.enemyHero.Hp + tmpPf.enemyHero.armor;
                    tmpPf.doAction(a);
                    actDmd -= (tmpPf.enemyHero.Hp + tmpPf.enemyHero.armor);
                    actDmgDict.Add(a, actDmd);
                }
                if (useability > 1) return;
            }
            catch { return; }

            foreach (var pair in actDmgDict.OrderByDescending(pair => pair.Value))
            {
                reorderedActions.Add(pair.Key);
            }

            tmpPf = new Playfield();
            foreach (Action a in reorderedActions)
            {
                bool found = false;

                switch (a.actionType)
                {
                    case actionEnum.playcard:
                        foreach (Handmanager.Handcard hc in tmpPf.owncards)
                        {
                            if (hc.entity == a.card.entity)
                            {
                                if (tmpPf.mana >= hc.card.getManaCost(tmpPf, hc.manacost)) found = true;
                                break;
                            }
                        }
                        break;
                    case actionEnum.attackWithMinion:
                        foreach (Minion m in tmpPf.ownMinions)
                        {
                            if (m.entityID == a.own.entityID)
                            {
                                if (!a.own.Ready) return;
                                found = true;
                                break;
                            }
                        }
                        break;
                    case actionEnum.attackWithHero:
                        if (tmpPf.ownHero.Ready) found = true;
                        break;
                    case actionEnum.useHeroPower:
                        if (tmpPf.ownAbilityReady && tmpPf.mana >= tmpPf.ownHeroAblility.card.getManaCost(tmpPf, tmpPf.ownHeroAblility.manacost)) found = true;
                        break;
                }
                if (!found) return;
                tmpPf.doAction(a);
            }

            if (Ai.Instance.botBase.getPlayfieldValue(tmpPf) >= 10000)
            {
                bestplay.playactions.Clear();
                bestActions.Clear();
                bestplay.playactions.AddRange(reorderedActions);
                Helpfunctions.Instance.logg("Reordered actions:");

                foreach (Action a in bestplay.playactions)
                {
                    this.bestActions.Add(new Action(a));
                    a.print();
                }
            }
        }

        private void selectBestTracking()
        {
            int trackingchoice = 0;
            int trackingstatus = 0;
            //which choice-card to draw?
            int choice = Discovery.Instance.getChoice(mainTurnSimulator.bestboard);
            if (choice >= 1)
            {
                trackingchoice = choice;
                //Helpfunctions.Instance.ErrorLog("discovering using user choice..." + trackingchoice);
                trackingstatus = 3;
            }

            if (trackingchoice == 0 && mainTurnSimulator.bestboard.selectedChoice >= 1)
            {
                trackingchoice = mainTurnSimulator.bestboard.selectedChoice;
                //Helpfunctions.Instance.ErrorLog("discovering using optimal choice..." + trackingchoice);
                trackingstatus = 0;
            }

            //TODO: select card based on mana + usefulness?

            if (trackingchoice == 0)
            {
                //search other non-optimal boards for a choice:
                for (int i = 0; i < 100; i++)
                {
                    Playfield tc = mainTurnSimulator.getBoard(i);
                    if (trackingchoice == 0 && tc.selectedChoice >= 1) trackingchoice = tc.selectedChoice;
                }
                if (trackingchoice >= 1) trackingstatus = 1;//use tracking of other board
                //if (trackingchoice >= 1) Helpfunctions.Instance.ErrorLog("discovering using suboptimal choice..." + trackingchoice);
            }

            if (trackingchoice == 0)
            {
                //random card
                Random randovar = new Random();
                trackingchoice = randovar.Next(1, Handmanager.Instance.getNumberChoices() + 1);
                //if (trackingchoice >= 1) Helpfunctions.Instance.ErrorLog("discovering using random choice..." + trackingchoice);
                trackingstatus = 2;//use random card
            }

            this.bestTracking = trackingchoice;
            this.bestTrackingStatus = trackingstatus;
        }

        //TODO add tracking-choice to hand in nextMoveGuess!
        public void setBestMoves(List<Action> alist, float value, int tracking, int trackingstatus)
        {
            this.bestTracking = -1;
            this.bestTrackingStatus = 0;

            this.bestTracking = tracking;
            this.bestTrackingStatus = trackingstatus;

            help.logg("set best action-----------------------------------");
            this.bestActions.Clear();
            this.bestmove = null;
            this.bestmoveValue = value;
            if (bestTracking >= 1) help.logg("discover " + bestTracking + " " + bestTrackingStatus);
            foreach (Action a in alist)
            {
                help.logg("-a-");
                this.bestActions.Add(new Action(a));
                this.bestActions[this.bestActions.Count - 1].print();
            }
            //this.bestActions.Add(new Action(actionEnum.endturn, null, null, 0, null, 0, 0));

            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }

            this.nextMoveGuess = new Playfield();
            this.oldMoveGuess = new Playfield();//queque stuff
            //only debug:
            //this.nextMoveGuess.printBoardDebug();

            if (bestmove != null && bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
            {
                Helpfunctions.Instance.logg("nmgsim-");
                try
                {
                    this.nextMoveGuess.doAction(bestmove);
                    this.bestmove = this.nextMoveGuess.playactions[this.nextMoveGuess.playactions.Count - 1];
                }
                catch (Exception ex)
                {
                    Helpfunctions.Instance.logg("StackTrace ---" + ex.ToString());
                }
                Helpfunctions.Instance.logg("nmgsime-");


            }
            else
            {
                nextMoveGuess.mana = -100;
            }
        }

        public void doNextCalcedMove()
        {
            help.logg("noRecalcNeeded!!!-----------------------------------");
            //this.bestboard.printActions();

            this.bestmove = null;
            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }
            if (this.nextMoveGuess == null) this.nextMoveGuess = new Playfield();
            else Hrtprozis.Instance.updateCThunInfo(nextMoveGuess.anzOgOwnCThunAngrBonus, nextMoveGuess.anzOgOwnCThunHpBonus, nextMoveGuess.anzOgOwnCThunTaunt);
            this.oldMoveGuess = new Playfield(this.nextMoveGuess);
            //this.nextMoveGuess.printBoardDebug();

            if (bestmove != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
            {
                //this.nextMoveGuess = new Playfield();
                Helpfunctions.Instance.logg("nmgsim-");
                try
                {
                    this.nextMoveGuess.doAction(bestmove);
                    this.bestmove = this.nextMoveGuess.playactions[this.nextMoveGuess.playactions.Count - 1];
                }
                catch (Exception ex)
                {
                    Helpfunctions.Instance.logg("StackTrace do next calced move---" + ex.ToString());
                    Helpfunctions.Instance.ErrorLog("StackTrace do next calced move---" + ex.ToString());

                }
                Helpfunctions.Instance.logg("nmgsime-");

            }
            else
            {
                //Helpfunctions.Instance.logg("nd trn");
                nextMoveGuess.mana = -100;
                int twilightelderBonus = 0;
                foreach (Minion m in this.nextMoveGuess.ownMinions)
                {
                    if (m.name == CardDB.cardName.twilightelder && !m.silenced) twilightelderBonus++;
                }
                if (twilightelderBonus > 0)
                {
                    Hrtprozis.Instance.updateCThunInfo(nextMoveGuess.anzOgOwnCThunAngrBonus + twilightelderBonus, nextMoveGuess.anzOgOwnCThunHpBonus + twilightelderBonus, nextMoveGuess.anzOgOwnCThunTaunt);
                }
            }

        }

        public void dosomethingclever(Behavior bbase)
        {
            //return;
            //turncheck
            //help.moveMouse(950,750);
            //help.Screenshot();
            this.botBase = bbase;
            hp.updatePositions();

            posmoves.Clear();
            posmoves.Add(new Playfield());
            posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;
            /* foreach (var item in this.posmoves[0].owncards)
             {
                 help.logg("card " + item.handcard.card.name + " is playable :" + item.handcard.card.canplayCard(posmoves[0]) + " cost/mana: " + item.handcard.card.cost + "/" + posmoves[0].mana);
             }
             */
            //help.logg("is hero ready?" + posmoves[0].ownHeroReady);

            help.loggonoff(false);
            //do we need to recalc?
            help.logg("recalc-check###########");
            if (this.dontRecalc && posmoves[0].isEqual(this.nextMoveGuess, true))
            {
                doNextCalcedMove();
            }
            else
            {
                help.logg("Lethal-check###########");
                bestmoveValue = -1000000;
                DateTime strt = DateTime.Now;
                if (useLethalCheck)
                {
                    strt = DateTime.Now;
                    doallmoves(false, true);
                    help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
                }

                if (bestmoveValue < 10000)
                {
                    posmoves.Clear();
                    posmoves.Add(new Playfield());
                    posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;

                    List<Handmanager.Handcard> newcards = posmoves[0].getNewHandCards(Ai.Instance.nextMoveGuess);
                    foreach (var card in newcards)
                    {
                        if (!Silverfish.Instance.isCardCreated(card)) Hrtprozis.Instance.removeCardFromTurnDeck(card.card.cardIDenum);
                    }

                    help.logg("no lethal, do something random######");
                    strt = DateTime.Now;
                    doallmoves(false, false);
                    help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
                }
            }


            //help.logging(true);

        }

        public void autoTester(bool printstuff, string data = "", bool logg=true)
        {
            help.logg("simulating board ");

            BoardTester bt = new BoardTester(data);
            if (!bt.datareaded) return;
            //calculate the stuff
            posmoves.Clear();
            posmoves.Add(new Playfield());
            posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;
            if (logg)
            {
                help.logg("readed:");
                help.logg(posmoves[0].getCompleteBoardForSimulating("", "", ""));
            }
            if (logg)
            {
                foreach (Playfield p in this.posmoves)
                {
                    p.printBoard();
                }
            }
            help.logg("ownminionscount " + posmoves[0].ownMinions.Count);
            help.logg("owncardscount " + posmoves[0].owncards.Count);

            foreach (var item in this.posmoves[0].owncards)
            {
                help.logg("card " + item.card.name + " is playable :" + item.canplayCard(posmoves[0]) + " cost/mana: " + item.manacost + "/" + posmoves[0].mana);
            }
            help.logg("ability " + posmoves[0].ownHeroAblility.card.name + " is playable :" + posmoves[0].ownHeroAblility.card.canplayCard(posmoves[0], 2) + " cost/mana: " + posmoves[0].ownHeroAblility.card.getManaCost(posmoves[0], 2) + "/" + posmoves[0].mana);

            // lethalcheck + normal
            DateTime strt = DateTime.Now;
            doallmoves(false, true);
            help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
            double timeneeded = 0;
            if (bestmoveValue < 10000)
            {
                posmoves.Clear();
                posmoves.Add(new Playfield());
                posmoves[0].sEnemTurn = Settings.Instance.simulateEnemysTurn;
                strt = DateTime.Now;
                doallmoves(false, false);
                timeneeded = (DateTime.Now - strt).TotalSeconds;
                help.logg("calculated " + (DateTime.Now - strt).TotalSeconds);
            }

            if (printstuff)
            {
                this.mainTurnSimulator.printPosmoves();
                simmulateWholeTurn(this.mainTurnSimulator.bestboard);

                help.logg("Best Board Actions:");
                this.mainTurnSimulator.bestboard.printActions();
                help.logg("");

                help.logg("calculated " + timeneeded);
            }

            if (bt.boardToSimulate >= 0)
            {
                int input = 0;
                while (input >= 0)
                {
                    Console.WriteLine("write Index of board you want to simulate:");
                    String cnslrdl = Console.ReadLine();

                    try
                    {
                        input = Convert.ToInt32(cnslrdl);
                        simmulateWholeTurn(this.mainTurnSimulator.getBoard(input));
                    }
                    catch
                    {
                        Console.WriteLine("testmode ended...");
                        input = -1;
                    }
                }
            }
            else 
            {
                Console.WriteLine("notestmode");
            }
        }

        public void simmulateWholeTurn(Playfield board)
        {
            help.ErrorLog("########################################################################################################");
            help.ErrorLog("simulate board " + this.mainTurnSimulator.boardindexToSimulate);
            help.ErrorLog("########################################################################################################");
            //this.bestboard.printActions();

            Playfield tempbestboard = new Playfield();
            tempbestboard.value = botBase.getPlayfieldValue(tempbestboard);
            tempbestboard.printBoard();

            foreach (Action bestmovee in board.playactions)
            {
                help.logg("stepp");
                
                if (bestmovee != null && bestmovee.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
                {
                    bestmovee.print();

                    tempbestboard.doAction(bestmovee);

                }
                else
                {
                    tempbestboard.mana = -100;
                }
                help.logg("-------------");
                tempbestboard.value = botBase.getPlayfieldValue(tempbestboard);
                tempbestboard.printBoard();
            }

            //help.logg("AFTER ENEMY TURN:" );
            tempbestboard.sEnemTurn = true;
            tempbestboard.endTurn(false, this.playaround, false, Settings.Instance.playaroundprob, Settings.Instance.playaroundprob2);
            help.logg("ENEMY TURN:-----------------------------");
            tempbestboard.value = botBase.getPlayfieldValue(tempbestboard);
            tempbestboard.prepareNextTurn(tempbestboard.isOwnTurn);
            Ai.Instance.enemyTurnSim[0].simulateEnemysTurn(tempbestboard, true, playaround, true, Settings.Instance.playaroundprob, Settings.Instance.playaroundprob2);
        }

        public void simmulateWholeTurn()
        {
            help.ErrorLog("########################################################################################################");
            help.ErrorLog("simulate best board");
            help.ErrorLog("########################################################################################################");
            //this.bestboard.printActions();

            Playfield tempbestboard = new Playfield();
            tempbestboard.value = botBase.getPlayfieldValue(tempbestboard);
            tempbestboard.printBoard();

            if (bestmove != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
            {
                bestmove.print();

                tempbestboard.doAction(bestmove);

            }
            else
            {
                tempbestboard.mana = -100;
            }
            help.logg("-------------");
            tempbestboard.value = botBase.getPlayfieldValue(tempbestboard);
            tempbestboard.printBoard();

            foreach (Action bestmovee in this.bestActions)
            {

                help.logg("stepp");


                if (bestmovee != null && bestmovee.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
                {
                    bestmovee.print();

                    tempbestboard.doAction(bestmovee);

                }
                else
                {
                    tempbestboard.mana = -100;
                }
                help.logg("-------------");
                tempbestboard.value = botBase.getPlayfieldValue(tempbestboard);
                tempbestboard.printBoard();
            }

            //help.logg("AFTER ENEMY TURN:" );
            tempbestboard.sEnemTurn = true;
            tempbestboard.endTurn(false, this.playaround, false, Settings.Instance.playaroundprob, Settings.Instance.playaroundprob2);
            help.logg("ENEMY TURN:-----------------------------");
            tempbestboard.value = botBase.getPlayfieldValue(tempbestboard);
            tempbestboard.prepareNextTurn(tempbestboard.isOwnTurn);
            Ai.Instance.enemyTurnSim[0].simulateEnemysTurn(tempbestboard, true, playaround, true, Settings.Instance.playaroundprob, Settings.Instance.playaroundprob2);
        }

        public void simmulateWholeTurnandPrint()
        {
            help.ErrorLog("###################################");
            help.ErrorLog("what would silverfish do?---------");
            help.ErrorLog("###################################");
            if (this.bestmoveValue >= 10000) help.ErrorLog("DETECTED LETHAL ###################################");
            //this.bestboard.printActions();

            Playfield tempbestboard = new Playfield();

            if (bestmove != null && bestmove.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
            {

                tempbestboard.doAction(bestmove);
                tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);

                if (this.bestActions.Count == 0)
                {
                    help.ErrorLog("end turn");
                }
            }
            else
            {
                tempbestboard.mana = -100;
                help.ErrorLog("end turn");
            }


            foreach (Action bestmovee in this.bestActions)
            {

                if (bestmovee != null && bestmovee.actionType != actionEnum.endturn)  // save the guessed move, so we doesnt need to recalc!
                {
                    //bestmovee.print();
                    tempbestboard.doAction(bestmovee);
                    tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);

                }
                else
                {
                    tempbestboard.mana = -100;
                    help.ErrorLog("end turn");
                }
            }
        }

        public void updateEntitiy(int old, int newone)
        {
            Helpfunctions.Instance.logg("entityupdate! " + old + " to " + newone);
            if (this.nextMoveGuess != null)
            {
                foreach (Minion m in this.nextMoveGuess.ownMinions)
                {
                    if (m.entityID == old) m.entityID = newone;
                }
                foreach (Minion m in this.nextMoveGuess.enemyMinions)
                {
                    if (m.entityID == old) m.entityID = newone;
                }
            }
            foreach (Action a in this.bestActions)
            {
                if (a.own != null && a.own.entityID == old) a.own.entityID = newone;
                if (a.target != null && a.target.entityID == old) a.target.entityID = newone;
                if (a.card != null && a.card.entity == old) a.card.entity = newone;
            }

        }



        //queue stuff (done by xytrix)
        // Looks through a list of playfields from previous moves to find one that matches our current board state.
        // If any is found, we "rollback" our bestactions list to that point in time.
        public bool restoreBestMoves(Playfield currentField, List<Playfield> oldMoveGuesses)
        {
            for (int i = oldMoveGuesses.Count - 1; i >= 0; i--)  // work backwards
            {
                if (currentField.isEqualf(oldMoveGuesses[i]))
                {
                    // We need to re-queue moves from this point. So re-populate the "bestActions" list.
                    for (int j = oldMoveGuesses.Count - 1; j > i; j--)
                    {
                        this.bestActions.Insert(0, oldMoveGuesses[j].playactions.Last());
                    }

                    this.nextMoveGuess = oldMoveGuesses[i];
                    this.bestmove = nextMoveGuess.playactions.LastOrDefault();  // null if empty (i.e. no moves performed)
                    return true;
                }
            }

            return false;
        }

        // Checks if any actions (beyond our first) can be queued up for sending together. Actions cannot be queued if they have an unexpected outcome.
        public bool canQueueNextMoves()
        {
            if (this.bestmove == null || this.bestActions.Count < 1) return false;  // no moves to queue

            if (this.nextMoveGuess.owncarddraw != 0) return false;

            // Note: Generated entities (i.e. newly spawned minions) are not _always_ a problem,
            // but 90% of the time we cannot take an action involving them, so easier to just not queue.
            if (boardContainsGeneratedEntities(this.nextMoveGuess) || nextMoveContainsGeneratedEntities()) return false;

            if (this.bestmove.actionType == actionEnum.attackWithHero)
            {
                // check if using a random effect weapon
                if (this.oldMoveGuess.ownWeaponName == CardDB.cardName.ogrewarmaul) return false;
                if (this.oldMoveGuess.ownWeaponName == CardDB.cardName.powermace && this.oldMoveGuess.ownWeaponDurability == 1)
                {
                    int numMechs = 0;
                    foreach (Minion m in this.oldMoveGuess.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) numMechs++;
                        if (numMechs > 1) return false;
                    }
                }
            }
            else if (this.bestmove.actionType == actionEnum.attackWithMinion)
            {
                // check for the ogres
                foreach (Minion m in this.oldMoveGuess.ownMinions)
                {
                    if (m.name == CardDB.cardName.mogortheogre && !m.silenced)
                        return false;
                }
                foreach (Minion m in this.oldMoveGuess.enemyMinions)
                {
                    if (m.name == CardDB.cardName.mogortheogre && !m.silenced)
                        return false;
                }

                if (!this.bestmove.own.silenced && (this.bestmove.own.handcard.card.name == CardDB.cardName.ogrebrute
                    || this.bestmove.own.handcard.card.name == CardDB.cardName.dunemaulshaman
                    || this.bestmove.own.handcard.card.name == CardDB.cardName.mogorschampion
                    || this.bestmove.own.handcard.card.name == CardDB.cardName.ogreninja))
                    return false;
            }
            else if (this.bestmove.actionType == actionEnum.useHeroPower)
            {
                // Shaman/Paladin -- covered by boardContainsGeneratedEntities
                // Warlock -- covered by owncarddraw != 0
            }
            else if (this.bestmove.actionType == actionEnum.playcard)
            {
                // Check the board prior to applying the last action (this.oldMoveGuess). Was it a random action?
                return !IsPlayRandomEffect(this.bestmove.card.card, this.oldMoveGuess, this.nextMoveGuess);
            }

            return true;
        }

        public bool IsPlayRandomEffect(CardDB.Card card, Playfield oldField, Playfield newField)  // adapted from PenalityManager::getRandomPenality
        {
            bool hasgadget = false;
            bool hasstarving = false;
            bool hasknife = false;
            bool hasflamewaker = false;
            bool hasmech = false;

            foreach (Minion mnn in oldField.ownMinions)
            {
                if (mnn.handcard.card.race == TAG_RACE.MECHANICAL) hasmech = true;
                if (mnn.silenced) continue;

                switch (mnn.name)
                {
                    case CardDB.cardName.gadgetzanauctioneer: hasgadget = true; break;
                    case CardDB.cardName.starvingbuzzard: hasstarving = true; break;
                    case CardDB.cardName.knifejuggler: hasknife = true; break;
                    case CardDB.cardName.flamewaker: hasflamewaker = true; break;
                }
            }

            if ((hasknife && (oldField.enemyMinions.Count > 0) && (card.type == CardDB.cardtype.MOB || oldField.ownMinions.Count < newField.ownMinions.Count))
                || (hasgadget && card.type == CardDB.cardtype.SPELL)
                || (hasflamewaker && (oldField.enemyMinions.Count > 0) && card.type == CardDB.cardtype.SPELL)
                || (hasstarving && (TAG_RACE)card.race == TAG_RACE.PET))
            {
                return true;
            }

            if (!this.penman.randomEffects.ContainsKey(card.name)) return false;

            if (card.type == CardDB.cardtype.MOB && !card.battlecry) return false;

            if ((card.name == CardDB.cardName.bouncingblade && ((oldField.enemyMinions.Count + oldField.ownMinions.Count) == 1))
                || (card.name == CardDB.cardName.goblinblastmage && !hasmech)
                || (card.name == CardDB.cardName.coghammer && oldField.ownMinions.Count == 1))
            {
                return false;
            }

            if (oldField.enemyMinions.Count == 2 && (card.name == CardDB.cardName.cleave
                || card.name == CardDB.cardName.multishot
                || card.name == CardDB.cardName.forkedlightning
                || card.name == CardDB.cardName.darkbargain))
            {
                return false;
            }

            if (oldField.enemyMinions.Count == 1 && (card.name == CardDB.cardName.deadlyshot
                || card.name == CardDB.cardName.flamecannon
                || card.name == CardDB.cardName.bomblobber))
            {
                return false;
            }

            if (oldField.enemyMinions.Count == 0 && (card.name == CardDB.cardName.arcanemissiles
                || card.name == CardDB.cardName.avengingwrath
                || card.name == CardDB.cardName.goblinblastmage
                || card.name == CardDB.cardName.flamejuggler))
            {
                return false;
            }

            return true;
        }

        public bool nextMoveContainsGeneratedEntities()
        {
            if (this.bestActions.Count == 0) return false;

            Action potentialMove = this.bestActions[0];
            if (potentialMove.actionType == actionEnum.endturn) return false;

            if (potentialMove.card != null && potentialMove.card.entity >= 1000) return true;
            if (potentialMove.own != null && potentialMove.own.handcard.entity >= 1000) return true;
            if (potentialMove.target != null && potentialMove.target.handcard.entity >= 1000) return true;

            return false;
        }

        public bool boardContainsGeneratedEntities(Playfield p)
        {
            if (p.ownMinions.Find(m => m.handcard.entity>=1000) != null) return true;
            if (p.enemyMinions.Find(m => m.handcard.entity >= 1000) != null) return true;
            return false;
        }


    }


}