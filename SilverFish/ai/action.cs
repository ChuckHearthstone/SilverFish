
 //TODO:

//cardids of duplicate + avenge
//nozdormu (for computing time :D)
//faehrtenlesen (tracking)
// lehrensucher cho
//scharmuetzel kills all :D
//todo deathlord-guessing
//todo kelthuzad dont know which minion died this turn in rl

 using SilverFish.Helpers;

 namespace HREngine.Bots
{
    using System;

    public enum actionEnum
    {
        endturn = 0,
        playcard,
        attackWithHero,
        useHeroPower,
        attackWithMinion
    }
    //todo make to struct

    public class Action
    {

        public actionEnum actionType;
        public Handmanager.Handcard card;
        //public int cardEntitiy;
        public int place; //= target where card/minion is placed
        public Minion own;
        public Minion target;
        public int druidchoice; // 1 left card, 2 right card
        public int penalty;
        public int turn = -1;
        public int prevHpOwn = -1;
        public int prevHpTarget = -1;

        public Action(actionEnum type, Handmanager.Handcard hc, Minion ownM, int place, Minion targetM, int pen, int choice)
        {
            this.actionType = type;
            this.card = hc;
            this.own = ownM;
            this.place = place;
            this.target = targetM;
            this.penalty = pen;
            this.druidchoice = choice;
            if (ownM != null) prevHpOwn = ownM.HealthPoints;
            if (targetM != null) prevHpTarget = targetM.HealthPoints;
        }
        
        public Action(Action a)
        {
            this.actionType = a.actionType;
            this.card = a.card;
            this.place = a.place;
            this.own = a.own;
            this.target = a.target;
            this.druidchoice = a.druidchoice;
            this.penalty = a.penalty;
            this.prevHpOwn = a.prevHpOwn;
            this.prevHpTarget = a.prevHpTarget;
        }

        public void print(bool tobuffer = false)
        {
            Helpfunctions help = Helpfunctions.Instance;
            if (tobuffer)
            {
                if (this.actionType == actionEnum.playcard)
                {
                    string playaction = "play ";

                    playaction += "id " + this.card.entity;
                    if (this.target != null)
                    {
                        playaction += " target " + this.target.entitiyID;
                    }

                    if (this.place >= 0)
                    {
                        playaction += " pos " + this.place;
                    }

                    if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                    LogHelper.WriteCombatLog(playaction);
                }
                if (this.actionType == actionEnum.attackWithMinion)
                {
                    LogHelper.WriteCombatLog("attack " + this.own.entitiyID + " enemy " + this.target.entitiyID);
                }
                if (this.actionType == actionEnum.attackWithHero)
                {
                    LogHelper.WriteCombatLog("heroattack " + this.target.entitiyID);
                }
                if (this.actionType == actionEnum.useHeroPower)
                {

                    if (this.target != null)
                    {
                        LogHelper.WriteCombatLog("useability on target " + this.target.entitiyID);
                    }
                    else
                    {
                        LogHelper.WriteCombatLog("useability");
                    }
                }
                return;
            }
            if (this.actionType == actionEnum.playcard)
            {
                string playaction = "play ";

                playaction += "id " + this.card.entity;
                if (this.target != null)
                {
                    playaction += " target " + this.target.entitiyID;
                }

                if (this.place >= 0)
                {
                    playaction += " pos " + this.place;
                }

                if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                LogHelper.WriteCombatLog(playaction);
            }
            if (this.actionType == actionEnum.attackWithMinion)
            {
                LogHelper.WriteCombatLog("attacker: " + this.own.entitiyID + " enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.attackWithHero)
            {
                LogHelper.WriteCombatLog("attack with hero, enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.useHeroPower)
            {
                LogHelper.WriteCombatLog("useability ");
                if (this.target != null)
                {
                    LogHelper.WriteCombatLog("on enemy: " + this.target.entitiyID);
                }
            }
            LogHelper.WriteCombatLog("");
        }
        
        public string printString()
        {
            string retval = "";

            if (this.actionType == actionEnum.playcard)
            {
                retval += "play ";

                retval += "id " + this.card.entity;
                if (this.target != null)
                {
                    retval += " target " + this.target.entitiyID;
                }

                if (this.place >= 0)
                {
                    retval += " pos " + this.place;
                }
                if (this.druidchoice >= 1) retval += " choice " + this.druidchoice;
            }
            if (this.actionType == actionEnum.attackWithMinion)
            {
                retval += ("attacker: " + this.own.entitiyID + " enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.attackWithHero)
            {
                retval += ("attack with hero, enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.useHeroPower)
            {
                retval += ("useability ");
                if (this.target != null)
                {
                    retval += ("on target: " + this.target.entitiyID);
                }
            }

            return retval;
        }

    }

    
}