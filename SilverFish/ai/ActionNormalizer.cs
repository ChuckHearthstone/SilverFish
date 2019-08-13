using System.Collections.Generic;
using System.Linq;

namespace HREngine.Bots
{
    public class ActionNormalizer
    {
        PenalityManager penman = PenalityManager.Instance;
        Helpfunctions help = Helpfunctions.Instance;
        Settings settings = Settings.Instance;

        public struct targetNdamage
        {
            public int targetEntity;
            public int receivedDamage;

            public targetNdamage(int ent, int dmg)
            {
                this.targetEntity = ent;
                this.receivedDamage = dmg;
            }
        }


        public void adjustActions(Playfield p, bool isLethalCheck)
        {
            if (p.enemySecretCount > 0) return;
            if (p.playactions.Count < 2) return;

            List<Action> reorderedActions = new List<Action>();
            Dictionary<int, Dictionary<int, int>> rndActIdsDmg = new Dictionary<int, Dictionary<int, int>>();
            Playfield tmpPlOld = new Playfield();

            if (isLethalCheck)
            {
                if (Ai.Instance.botBase.getPlayfieldValue(p) < 10000) return;
                Playfield tmpPf = new Playfield();
                if (tmpPf.anzEnemyTaunt > 0) return;

                Dictionary<Action, int> actDmgDict = new Dictionary<Action, int>();
                tmpPf.enemyHero.Hp = 30;
                try
                {
                    int useability = 0;
                    foreach (Action a in p.playactions)
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
                    if (!isActionPossible(tmpPf, a)) return;
                    try
                    {
                        tmpPf.doAction(a);
                    }
                    catch
                    {
                        this.printError(p.playactions, reorderedActions, a);
                        return;
                    }
                }

                if (Ai.Instance.botBase.getPlayfieldValue(tmpPf) < 10000) return;
            }
            else
            {
                bool damageRandom = false;
                bool rndBeforeDamageAll = false;
                Action aa;
                for (int i = 0; i < p.playactions.Count; i++)
                {
                    aa = p.playactions[i];
                    switch (aa.actionType)
                    {
                        case actionEnum.playcard:
                            if (damageRandom && penman.DamageAllEnemysDatabase.ContainsKey(aa.card.card.name)) rndBeforeDamageAll = true;
                            else if (penman.DamageRandomDatabase.ContainsKey(aa.card.card.name)) damageRandom = true;
                            break;
                    }
                }

                int aoeEnNum = 0;
                int outOfPlace = 0;
                bool totemiccall = false;
                List<Action> rndAct = new List<Action>();
                List<Action> rndActTmp = new List<Action>();
                for (int i = 0; i < p.playactions.Count; i++)
                {
                    damageRandom = false;
                    aa = p.playactions[i];
                    reorderedActions.Add(aa);
                    switch (aa.actionType)
                    {
                        case actionEnum.useHeroPower:
                            if (aa.card.card.name == CardDB.cardName.totemiccall) totemiccall = true;
                            break;
                        case actionEnum.playcard:
                            if (penman.DamageAllEnemysDatabase.ContainsKey(aa.card.card.name))
                            {
                                if (i != aoeEnNum)
                                {
                                    if (totemiccall && aa.card.card.type == CardDB.cardtype.SPELL) return;
                                    reorderedActions.RemoveAt(i);
                                    reorderedActions.Insert(aoeEnNum, aa);
                                    outOfPlace++;
                                }
                                aoeEnNum++;
                            }
                            else if (rndBeforeDamageAll && aa.card.card.type == CardDB.cardtype.SPELL && penman.DamageRandomDatabase.ContainsKey(aa.card.card.name))
                            {
                                damageRandom = true;
                                Playfield tmp = new Playfield(tmpPlOld);
                                tmpPlOld.doAction(aa);

                                Dictionary<int, int> actIdDmg = new Dictionary<int, int>();
                                if (tmp.enemyHero.Hp != tmpPlOld.enemyHero.Hp) actIdDmg.Add(tmpPlOld.enemyHero.entitiyID, tmp.enemyHero.Hp - tmpPlOld.enemyHero.Hp);
                                if (tmp.ownHero.Hp != tmpPlOld.ownHero.Hp) actIdDmg.Add(tmpPlOld.ownHero.entitiyID, tmp.ownHero.Hp - tmpPlOld.ownHero.Hp);
                                bool found = false;
                                foreach (Minion m in tmp.enemyMinions)
                                {
                                    found = false;
                                    foreach (Minion nm in tmpPlOld.enemyMinions)
                                    {
                                        if (m.entitiyID == nm.entitiyID)
                                        {
                                            found = true;
                                            if (m.Hp != nm.Hp) actIdDmg.Add(m.entitiyID, m.Hp - nm.Hp);
                                            break;
                                        }
                                    }
                                    if (!found) actIdDmg.Add(m.entitiyID, m.Hp);
                                }
                                foreach (Minion m in tmp.ownMinions)
                                {
                                    found = false;
                                    foreach (Minion nm in tmpPlOld.ownMinions)
                                    {
                                        if (m.entitiyID == nm.entitiyID)
                                        {
                                            found = true;
                                            if (m.Hp != nm.Hp) actIdDmg.Add(m.entitiyID, m.Hp - nm.Hp);
                                            break;
                                        }
                                    }
                                    if (!found) actIdDmg.Add(m.entitiyID, m.Hp);
                                }
                                rndActIdsDmg.Add(aa.card.entity, actIdDmg);
                            }
                            break;
                    }
                    if (!damageRandom) tmpPlOld.doAction(aa);
                }

                if (outOfPlace == 0) return;

                Playfield tmpPf = new Playfield();
                foreach (Action a in reorderedActions)
                {
                    if (!isActionPossible(tmpPf, a)) return;
                    try
                    {

                        if (!(a.actionType == actionEnum.playcard && rndActIdsDmg.ContainsKey(a.card.entity))) tmpPf.doAction(a);
                        else
                        {
                            tmpPf.playactions.Add(a);
                            Dictionary<int, int> actIdDmg = rndActIdsDmg[a.card.entity];
                            if (actIdDmg.ContainsKey(tmpPf.enemyHero.entitiyID)) tmpPf.minionGetDamageOrHeal(tmpPf.enemyHero, actIdDmg[tmpPf.enemyHero.entitiyID]);
                            if (actIdDmg.ContainsKey(tmpPf.ownHero.entitiyID)) tmpPf.minionGetDamageOrHeal(tmpPf.ownHero, actIdDmg[tmpPf.ownHero.entitiyID]);
                            foreach (Minion m in tmpPf.enemyMinions)
                            {
                                if (actIdDmg.ContainsKey(m.entitiyID)) tmpPf.minionGetDamageOrHeal(m, actIdDmg[m.entitiyID]);
                            }
                            foreach (Minion m in tmpPf.ownMinions)
                            {
                                if (actIdDmg.ContainsKey(m.entitiyID)) tmpPf.minionGetDamageOrHeal(m, actIdDmg[m.entitiyID]);
                            }
                            tmpPf.doDmgTriggers();
                        }
                    }
                    catch
                    {
                        printError(p.playactions, reorderedActions, a);
                        return;
                    }
                }

                tmpPf.lostDamage = tmpPlOld.lostDamage;
                float newval = Ai.Instance.botBase.getPlayfieldValue(tmpPf);
                float oldval = Ai.Instance.botBase.getPlayfieldValue(tmpPlOld);

                if (oldval > newval) return;
            }
            help.logg("Old order of actions:");
            foreach (Action a in p.playactions) a.print();

            p.playactions.Clear();
            p.playactions.AddRange(reorderedActions);

            help.logg("New order of actions:");

        }

        private bool isActionPossible(Playfield p, Action a)
        {
            bool actionFound = false;
            switch (a.actionType)
            {
                case actionEnum.playcard:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.entity == a.card.entity)
                        {
                            if (p.mana >= hc.card.getManaCost(p, hc.manacost))
                            {
                                if (p.ownMinions.Count > 6)
                                {
                                    if (hc.card.type == CardDB.cardtype.MOB) return false;
                                }
                                actionFound = true;
                            }
                            break;
                        }
                    }
                    break;
                case actionEnum.attackWithMinion:
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.entitiyID == a.own.entitiyID)
                        {
                            if (!m.Ready) return false;
                            actionFound = true;
                            break;
                        }
                    }
                    break;
                case actionEnum.attackWithHero:
                    if (p.ownHero.Ready) actionFound = true;
                    break;
                case actionEnum.useHeroPower:
                    if (p.ownAbilityReady && p.mana >= p.ownHeroAblility.card.getManaCost(p, p.ownHeroAblility.manacost)) actionFound = true;
                    break;
            }
            if (!actionFound) return false;

            if (a.target != null)
            {
                actionFound = false;
                if (p.enemyHero.entitiyID == a.target.entitiyID) actionFound = true;
                else if (p.ownHero.entitiyID == a.target.entitiyID) actionFound = true;
                else
                {
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.entitiyID == a.target.entitiyID)
                        {
                            actionFound = true;
                            break;
                        }
                    }
                    if (!actionFound)
                    {
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.entitiyID == a.target.entitiyID)
                            {
                                actionFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            return actionFound;
        }

        private void printError(List<Action> mainActList, List<Action> newActList, Action aError)
        {
            help.ErrorLog("Reordering actions error!");
            help.logg("Reordering actions error!\r\nError in action:");
            aError.print();
            help.logg("Main order of actions:");
            foreach (Action a in mainActList) a.print();
            help.logg("New order of actions:");
            foreach (Action a in newActList) a.print();
            return;
        }

        public void checkLostActions(Playfield p)
        {
            Playfield tmpPf = new Playfield();
            foreach (Action a in p.playactions)
            {
                if (a.target != null && a.own != null) a.own.own = !a.target.own;
                tmpPf.doAction(a);
            }
            MiniSimulator mainTurnSimulator = new MiniSimulator(6, 3000, 0);
            mainTurnSimulator.setSecondTurnSimu(settings.simulateEnemysTurn, settings.secondTurnAmount);
            mainTurnSimulator.setPlayAround(settings.playaround, settings.playaroundprob, settings.playaroundprob2);

            tmpPf.checkLostAct = true;
            tmpPf.isLethalCheck = p.isLethalCheck;

            float bestval = mainTurnSimulator.doallmoves(tmpPf);
            if (bestval > p.value)
            {
                p.playactions.Clear();
                p.playactions.AddRange(mainTurnSimulator.bestboard.playactions);
                p.value = bestval;
            }
        }
    }

    
}