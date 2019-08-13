using System;
using System.Collections.Generic;

namespace HREngine.Bots
{

    public sealed class Discovery
    {
        class discoveryitem
        {
            public CardDB.cardIDEnum cardid = CardDB.cardIDEnum.None;
            public int bonus;
            public string ownclass = "";
            public string enemyclass = "";

            public discoveryitem(string line)
            {
                this.cardid = CardDB.Instance.cardIdstringToEnum(line.Split(',')[0]);
                this.bonus = Convert.ToInt32(line.Split(';')[0].Split(',')[1]);
                this.ownclass = line.Split(';')[1];
                this.enemyclass = line.Split(';')[2];
            }

        }

        private string ownClass = Hrtprozis.Instance.heroEnumtoCommonName(Hrtprozis.Instance.heroname);
        private string deckName = Hrtprozis.Instance.deckName;
        private string cleanPath = "";

        private List<discoveryitem> discoverylist = new List<discoveryitem>();

        private static Discovery instance;

        public static Discovery Instance
        {
            get
            {
                return instance ?? (instance = new Discovery());
            }
        }

        public void updateInstance()
        {
            ownClass = Hrtprozis.Instance.heroEnumtoCommonName(Hrtprozis.Instance.heroname);
            deckName = Hrtprozis.Instance.deckName;
            lock (instance)
            {
                readCombos();
            }
        }

        public void loggCleanPath()
        {
            Helpfunctions.Instance.logg(cleanPath);
        }

        private void readCombos()
        {
            string[] lines = new string[] { };
            this.discoverylist.Clear();

            string path = Settings.Instance.path;
            string cleanpath = "Silverfish" + System.IO.Path.DirectorySeparatorChar;
            string datapath = path + "Data" + System.IO.Path.DirectorySeparatorChar;
            string cleandatapath = cleanpath + "Data" + System.IO.Path.DirectorySeparatorChar;
            string classpath = datapath + ownClass + System.IO.Path.DirectorySeparatorChar;
            string cleanclasspath = cleandatapath + ownClass + System.IO.Path.DirectorySeparatorChar;
            string deckpath = classpath + deckName + System.IO.Path.DirectorySeparatorChar;
            string cleandeckpath = cleanclasspath + deckName + System.IO.Path.DirectorySeparatorChar;
            const string filestring = "_discovery.txt";


            if (deckName != "" && System.IO.File.Exists(deckpath + filestring))
            {
                path = deckpath;
                cleanPath = cleandeckpath + filestring;
            }
            else if (deckName != "" && System.IO.File.Exists(classpath + filestring))
            {
                path = classpath;
                cleanPath = cleanclasspath + filestring;
            }
            else if (deckName != "" && System.IO.File.Exists(datapath + filestring))
            {
                path = datapath;
                cleanPath = cleandatapath + filestring;
            }
            else if (System.IO.File.Exists(path + filestring))
            {
                cleanPath = cleanpath + filestring;
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("[Discovery] cant find base _discovery.txt, consider creating one");
                return;
            }
            Helpfunctions.Instance.ErrorLog("[Discovery] read " + cleanPath);

            
            try
            {
                lines = System.IO.File.ReadAllLines(path + "_discovery.txt");
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("_discovery.txt read error. Continuing without user-defined rules.");
                return;
            }
            
            foreach (string line in lines)
            {
                string shortline = line.Replace(" ", "");
                if (shortline.StartsWith("//")) continue;
                if (shortline.Length == 0) continue;

                try
                {
                    discoveryitem d = new discoveryitem(line);
                    this.discoverylist.Add(d);
                }
                catch
                {
                    Helpfunctions.Instance.ErrorLog("[Discovery] cant read line: " + line);
                }
            }
            Helpfunctions.Instance.ErrorLog("[Discovery] " + discoverylist.Count + " rules found");
        }

        public int getBonusValue(CardDB.cardIDEnum cardid, string ownclass, string enemyclass)
        {
            int bonus = 0;
            foreach (discoveryitem di in this.discoverylist)
            {
                if (di.cardid == cardid && (di.ownclass == "all" || di.ownclass == ownclass) && (di.enemyclass == "all" || di.enemyclass == enemyclass))
                {
                    if (di.bonus > bonus) bonus = di.bonus;
                }
            }

            return bonus;
        }

        public int getChoice(Playfield p)
        {
            int i = 0;
            int choice = 0;
            int prevbonus = 0;
            foreach (Handmanager.Handcard hc in Handmanager.Instance.handcardchoices)
            {
                CardDB.Card c = hc.card;
                i++;

                int bonus = getBonusValue(c.cardIDenum, Hrtprozis.heroEnumtoName(p.ownHeroName), Hrtprozis.heroEnumtoName(p.enemyHeroName));
                if (bonus > prevbonus)
                {
                    choice = i;
                    prevbonus = bonus;
                }
            }

            return choice;
        }
    }
}