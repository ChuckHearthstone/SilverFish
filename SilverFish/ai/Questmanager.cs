namespace HREngine.Bots
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Questmanager
    {
        public class QuestItem
        {
            public Dictionary<CardDB.cardName, int> mobsTurn = new Dictionary<CardDB.cardName, int>();
            public CardDB.cardIDEnum Id = CardDB.cardIDEnum.None;
            public int questProgress = 0;
            public int maxProgress = 1000;

            public QuestItem()
            {
            }

            public void Copy(QuestItem q)
            {
                this.Id = q.Id;
                this.questProgress = q.questProgress;
                this.maxProgress = q.maxProgress;
                if (Id == CardDB.cardIDEnum.UNG_067)
                {
                    this.mobsTurn.Clear();
                    foreach (var n in q.mobsTurn) this.mobsTurn.Add(n.Key, n.Value);
                }
            }

            public void Reset()
            {
                this.Id = CardDB.cardIDEnum.None;
                this.questProgress = 0;
                this.maxProgress = 1000;
                this.mobsTurn.Clear();
            }

            public QuestItem(string s)
            {
                String[] q = s.Split(' ');
                this.Id = CardDB.Instance.cardIdstringToEnum(q[0]);
                this.questProgress = Convert.ToInt32(q[1]);
                this.maxProgress = Convert.ToInt32(q[2]);
            }

            //-!!!!set in code check if (this.enemyQuest.Id != CardDB.cardIDEnum.None)
            public void trigger_MinionWasPlayed(Minion m)
            {
                switch (Id)
                {
                    case CardDB.cardIDEnum.UNG_934: if (m.taunt) questProgress++; break;
                    case CardDB.cardIDEnum.UNG_920: if (m.handcard.card.cost == 1) questProgress++; break;
                    case CardDB.cardIDEnum.UNG_067:                        
                        if (mobsTurn.ContainsKey(m.name)) mobsTurn[m.name]++;
                        else mobsTurn.Add(m.name, 1);
                        int total = mobsTurn[m.name] + Questmanager.Instance.getPlayedCardFromHand(m.name);
                        if (total > questProgress) questProgress++;
                        break;
                }
            }

            public void trigger_MinionWasSummoned(Minion m)
            {
                switch (Id)
                {
                    case CardDB.cardIDEnum.UNG_116: if (m.Angr >= 5) questProgress++; break;
                    case CardDB.cardIDEnum.UNG_940: if (m.handcard.card.deathrattle) questProgress++; break;
                    case CardDB.cardIDEnum.UNG_942: if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) questProgress++; break;
                }
            }

            public void trigger_SpellWasPlayed(Minion target, int qId)
            {
                switch (Id)
                {
                    case CardDB.cardIDEnum.UNG_954: if (target != null && target.own && !target.isHero) questProgress++; break;
                    case CardDB.cardIDEnum.UNG_028: if (qId > 67) questProgress++; break;
                }
            }
            
            public void trigger_WasDiscard(int num)
            {
                switch (Id)
                {
                    case CardDB.cardIDEnum.UNG_829: questProgress += num; break;
                }
            }

            public CardDB.cardIDEnum Reward()
            {
                switch (Id)
                {
                    case CardDB.cardIDEnum.UNG_028: return CardDB.cardIDEnum.UNG_028t; //-Quest: Cast 6 spells that didn't start in your deck. Reward: Time Warp.
                    case CardDB.cardIDEnum.UNG_067: return CardDB.cardIDEnum.UNG_067t1; //-Quest: Play four minions with the same name. Reward: Crystal Core.
                    case CardDB.cardIDEnum.UNG_116: return CardDB.cardIDEnum.UNG_116; //-Quest: Summon 5 minions with 5 or more Attack. Reward: Barnabus.
                    case CardDB.cardIDEnum.UNG_829: return CardDB.cardIDEnum.UNG_829t1; //-Quest: Discard 6 cards. Reward: Nether Portal.
                    case CardDB.cardIDEnum.UNG_920: return CardDB.cardIDEnum.UNG_920t1; //-Quest: Play seven 1-Cost minions. Reward: Queen Carnassa.
                    case CardDB.cardIDEnum.UNG_934: return CardDB.cardIDEnum.UNG_934t1; //-Quest: Play 7 Taunt minions. Reward: Sulfuras.
                    case CardDB.cardIDEnum.UNG_940: return CardDB.cardIDEnum.UNG_940t8; //-Quest: Summon 7 Deathrattle minions. Reward: Amara, Warden of Hope.
                    case CardDB.cardIDEnum.UNG_942: return CardDB.cardIDEnum.UNG_942t; //-Quest: Summon 10 Murlocs. Reward: Megafin.
                    case CardDB.cardIDEnum.UNG_954: return CardDB.cardIDEnum.UNG_954t1; //-Quest: Cast 6 spells on your minions. Reward: Galvadon.
                }
                return CardDB.cardIDEnum.None;
            }
        }
        
        StringBuilder sb = new StringBuilder("", 500);
        public QuestItem ownQuest = new QuestItem();
        public QuestItem enemyQuest = new QuestItem();
        public Dictionary<CardDB.cardName, int> mobsGame = new Dictionary<CardDB.cardName, int>();
        private CardDB.cardName nextMobName = CardDB.cardName.unknown;
        private int nextMobId = 0;
        private int prevMobId = 0;
        Helpfunctions help;

        private static Questmanager instance;

        public static Questmanager Instance
        {
            get
            {
                return instance ?? (instance = new Questmanager());
            }
        }
        
        private Questmanager()
        {
            this.help = Helpfunctions.Instance;
        }

        public void updateQuestStuff(string questID, int curProgr, int maxProgr, bool ownplay)
        {
            QuestItem tmp = new QuestItem() { Id = CardDB.Instance.cardIdstringToEnum(questID), questProgress = curProgr, maxProgress = maxProgr };
            if (ownplay) this.ownQuest = tmp;
            else this.enemyQuest = tmp;
        }
        
        public void updatePlayedMobs(int step)
        {
            if (step != 0)
            {
                if (nextMobName != CardDB.cardName.unknown && nextMobId != prevMobId)
                {
                    prevMobId = nextMobId;
                    nextMobId = 0;
                    if (mobsGame.ContainsKey(nextMobName))
                    {
                        if (ownQuest.questProgress > mobsGame[nextMobName]) mobsGame[nextMobName]++;
                        else mobsGame[nextMobName] = ownQuest.questProgress;
                    }
                    else mobsGame.Add(nextMobName, 1);
                }
            }
        }

        public void updatePlayedCardFromHand(Handmanager.Handcard hc)
        {
            nextMobName = CardDB.cardName.unknown;
            nextMobId = 0;
            if (hc != null && hc.card.type == CardDB.cardtype.MOB)
            {
                nextMobName = hc.card.name;
                nextMobId = hc.entity;
            }
        }

        public int getPlayedCardFromHand(CardDB.cardName name)
        {
            if (mobsGame.ContainsKey(name)) return mobsGame[name];
            else return 0;
        }

        public void Reset()
        {            
            sb.Clear();
            mobsGame.Clear();
            ownQuest = new QuestItem();
            enemyQuest = new QuestItem();
            nextMobName = CardDB.cardName.unknown;
            nextMobId = 0;
            prevMobId = 0;
        }

        public string getQuestsString()
        {   
            sb.Clear();
            sb.Append("quests: ");
            sb.Append(ownQuest.Id).Append(" ").Append(ownQuest.questProgress).Append(" ").Append(ownQuest.maxProgress).Append(" ");
            sb.Append(enemyQuest.Id).Append(" ").Append(enemyQuest.questProgress).Append(" ").Append(enemyQuest.maxProgress);
            return sb.ToString();
        }


    }

}