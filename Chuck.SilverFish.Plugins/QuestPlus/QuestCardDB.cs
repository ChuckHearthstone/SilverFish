using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Logger = Triton.Common.LogUtilities.Logger;

namespace QuestPlus
{    
    public class QuestCardDB
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        public enum cardtype
        {
            NONE,
            MOB,
            SPELL,
            WEAPON,
            HEROPWR,
            HERO
        }

        public class QuestCard
        {
            public string Id = "";
            public int race = 0;
            public int cost = 0;
            public int Class = 0;
            public cardtype type = QuestCardDB.cardtype.NONE;
            public bool tank = false;
            public bool deathrattle = false;
            public bool battlecry = false;
            public bool Enrage = false;
            public bool Combo = false;
            public int overload = 0;
            public bool Shield = false;
            public bool Secret = false;
            
            public QuestCard()
            {

            }
        }

        Dictionary<string, QuestCard> cardidToCard = new Dictionary<string, QuestCard>();
        private static QuestCardDB instance;

        public static QuestCardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestCardDB();
                }
                return instance;
            }
        }

        private QuestCardDB()
        {
            string[] lines = new string[0] { };
            string path = Path.Combine(".", "Routines", "DefaultRoutine", "Silverfish");
            path = Path.Combine(path, "data", "_carddb.txt");

            try
            {
                lines = System.IO.File.ReadAllLines(path);
            }
            catch
            {
                Log.InfoFormat("cant find _carddb.txt in {0}.", path);
            }
            this.cardidToCard.Clear();
            QuestCard c = new QuestCard();
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (!this.cardidToCard.ContainsKey(c.Id))
                    {
                        this.cardidToCard.Add(c.Id, c);
                    }
                }
                if (s.Contains("<Entity version=\"") && s.Contains(" CardID=\""))
                {
                    c = new QuestCard();
                    string temp = s.Split(new string[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", "");
                    c.Id = temp;
                    continue;
                }
                
                if (s.Contains("Tag enumID=\"199\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Class = Convert.ToInt32(temp);
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"200\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = Convert.ToInt32(temp);
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"48\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"202\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];

                    int crdtype = Convert.ToInt32(temp);
                    if (crdtype == 10)
                    {
                        c.type = QuestCardDB.cardtype.HEROPWR;
                    }
                    if (crdtype == 3)
                    {
                        c.type = QuestCardDB.cardtype.HERO;
                    }
                    if (crdtype == 4)
                    {
                        c.type = QuestCardDB.cardtype.MOB;
                    }
                    if (crdtype == 5)
                    {
                        c.type = QuestCardDB.cardtype.SPELL;
                    }
                    if (crdtype == 7)
                    {
                        c.type = QuestCardDB.cardtype.WEAPON;
                    }
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"212\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Enrage = true;
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"190\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.tank = true;
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"218\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.battlecry = true;
                    continue;
                }

                
                if (s.Contains("<Tag enumID=\"217\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.deathrattle = true;
                    continue;
                }

                
                if (s.Contains("<Tag enumID=\"220\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Combo = true;
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"296\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.overload = Convert.ToInt32(temp);
                    continue;
                }

                
                if (s.Contains("<Tag enumID=\"219\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Secret = true;
                    continue;
                }
                
                if (s.Contains("<Tag enumID=\"194\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Shield = true;
                    continue;
                }
            }
        }
        
        public QuestCard getCardDataFromStringID(string id)
        {
            return this.cardidToCard.ContainsKey(id) ? this.cardidToCard[id] : null;
        }


    }

}