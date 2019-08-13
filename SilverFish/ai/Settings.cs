using System;


namespace HREngine.Bots
{
    internal sealed class Settings
    {

        public Behavior setSettings()
        {
            return readSettings();
        }

        public Behavior setDefaultSettings() //settings not to high to run without external process
        {
            // play with these settings###################################
            this.enfacehp = 15;  // hp of enemy when your hero is allowed to attack the enemy face with his weapon

            this.maxwide = 3000;   // numer of boards which are taken to the next deep-lvl
            this.twotsamount = 0;          // number of boards where the next turn is simulated

            this.simEnemySecondTurn = true; // if he simulates the next players-turn, he also simulates the enemys respons

            this.playarround = false;  //play around some enemys aoe-spells?
            //these two probs are >= 0 and <= 100
            this.playaroundprob = 50;    //probability where the enemy plays the aoe-spell, but your minions will not die through it
            this.playaroundprob2 = 80;   // probability where the enemy plays the aoe-spell, and your minions can die!

            this.enemyTurnMaxWide = 40; // bords calculated in enemys-first-turn in first AI step (lower than enemySecondTurnMaxWide)
            this.enemyTurnMaxWideSecondTime = 200; // bords calculated in enemys-first-turn BUT in the second AI step (higher than enemyTurnMaxWide)
            this.enemySecondTurnMaxWide = 20; // number of enemy-board calculated in enemys second TURN

            this.nextTurnDeep = 6; //maximum combo-deep in your second turn (dont change this!)
            this.nextTurnMaxWide = 20; //maximum boards calculated in one second-turn-"combo-step"
            this.nextTurnTotalBoards = 200;//maximum boards calculated in second turn simulation

            this.useSecretsPlayArround = false; // playing arround enemys secrets

            this.alpha = 50; // weight of the second turn in calculation (0<= alpha <= 100)

            this.simulatePlacement = false;  // set this true, and ai will simulate all placements, whether you have a alpha/flametongue/argus
            this.behave = new BehaviorControl(); //select the behavior of the ai: control, rush, face (new) or mana (very experimental, dont use that :D)

            this.useExternalProcess = false; // use silver.exe for calculations a lot faster than turning it off (true = recomended)
            this.passiveWaiting = false; // process will wait passive for silver.exe to finish

            this.speedy = false; // send multiple actions together to HR

            this.useNetwork = false; // use networking to communicate with silver.exe instead of a file
            this.netAddress = "127.0.0.1"; // address where the bot is running
            this.tcpPort = 14804; // TCP port to connect on

            this.logBuffer = 100; // max log messages to buffer before writing to disk

            //###########################################################

            applySettings();

            return behave;
        }

        public void applySettings()
        {
            this.setWeights(alpha);

            Mulligan.Instance.setAutoConcede(Settings.Instance.concede);
            Helpfunctions.Instance.ErrorLog("[Settings] set enemy-face-hp to: " + this.enfacehp);
            ComboBreaker.Instance.attackFaceHP = this.enfacehp;
            Ai.Instance.setMaxWide(this.maxwide);
            Helpfunctions.Instance.ErrorLog("[Settings] set maxwide to: " + this.maxwide);

            Ai.Instance.setTwoTurnSimulation(false, this.twotsamount);
            Helpfunctions.Instance.ErrorLog("[Settings] calculate the second turn of the " + this.twotsamount + " best boards");
            if (this.twotsamount >= 1)
            {
                if (this.simEnemySecondTurn) Helpfunctions.Instance.ErrorLog("[Settings] simulates the enemy turn on your second turn");
            }

            if (this.useSecretsPlayArround)
            {
                Helpfunctions.Instance.ErrorLog("[Settings] playing arround secrets is " + this.useSecretsPlayArround);
            }
            Ai.Instance.setPlayAround();

            if (this.writeToSingleFile) Helpfunctions.Instance.ErrorLog("[Settings] write log to single file");
        }


        public int enfacehp = 15;

        public int maxwide = 3000;
        public int twotsamount;
        public int secondTurnAmount = 256;
        
        public bool simulateEnemysTurn = true;
        public bool simEnemySecondTurn = true; //todo sepefeets - wasn't this dead code too?

        public bool playarround;
        public int playaroundprob = 50;
        public int playaroundprob2 = 80; //todo - and this

        public int enemyTurnMaxWide = 20;
        public int enemyTurnMaxWideSecondTime = 200;
        public int enemySecondTurnMaxWide = 20;

        public int nextTurnDeep = 6;
        public int nextTurnMaxWide = 20;
        public int nextTurnTotalBoards = 50;

        public bool useSecretsPlayArround;

        public int alpha = 50;
        public float firstweight = 0.5f;
        public float secondweight = 0.5f;

        public bool simulatePlacement = true;

        public bool useExternalProcess;
        public bool passiveWaiting; //todo sepefeets - dead code
        public bool speedy;

        public bool concede = false;
        public bool enemyConcede;
        public int enemyConcedeValue = -900;

        public bool useNetwork = false;
        public string netAddress = "127.0.0.1";
        public int tcpPort = 14804;

        public int logBuffer = 100;

        public string path = "";
        public string logpath = "";
        public string logfile = "Logg.txt";

        public bool writeToSingleFile = false;

        public bool learnmode = false;
        public bool printlearnmode = true;

        public int numberOfThreads = Environment.ProcessorCount;//32;//

        private string ownClass = "";
        private string enemyClass = "";
        private string deckName = "";
        private string cleanPath = "";

        public Behavior behave = new BehaviorControl();


        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                return instance ?? (instance = new Settings());
            }
        }

        private Settings() { }

        
        public Behavior updateInstance()
        {
            ownClass = Hrtprozis.Instance.heroEnumtoCommonName(Hrtprozis.Instance.heroname);
            enemyClass = Hrtprozis.Instance.heroEnumtoCommonName(Hrtprozis.Instance.enemyHeroname);
            deckName = Hrtprozis.Instance.deckName;
            lock(instance)
            {
                return readSettings();
            }
        }

        public void loggCleanPath()
        {
            Helpfunctions.Instance.logg(cleanPath);
        }

        public void setWeights(int alpha)
        {
            float a = ((float)alpha) / 100f;
            this.firstweight = 1f - a;
            this.secondweight = a;
            Helpfunctions.Instance.ErrorLog("[Settings] current alpha is " + this.secondweight);
        }

        public void setFilePath(string path)
        {
            this.path = path;
        }
        public void setLoggPath(string path)
        {
            this.logpath = path;
        }

        public void setLoggFile(string path)
        {
            this.logfile = path;
        }

        public Behavior readSettings() //takes same path as carddb
        {
            string[] lines = new string[] { };

            string path = this.path;
            string cleanpath = "Silverfish" + System.IO.Path.DirectorySeparatorChar;
            string datapath = path + "Data" + System.IO.Path.DirectorySeparatorChar;
            string cleandatapath = cleanpath + "Data" + System.IO.Path.DirectorySeparatorChar;
            string classpath = datapath + ownClass + System.IO.Path.DirectorySeparatorChar;
            string cleanclasspath = cleandatapath + ownClass + System.IO.Path.DirectorySeparatorChar;
            string deckpath = classpath + deckName + System.IO.Path.DirectorySeparatorChar;
            string cleandeckpath = cleanclasspath + deckName + System.IO.Path.DirectorySeparatorChar;
            string enemyfilestring = "settings-" + enemyClass + ".txt";
            const string filestring = "settings.txt";
            bool enemysettings = false;

            // if we have a deckName then we have a real ownClass too, not the default "druid"
            if (deckName != "" && System.IO.File.Exists(deckpath + enemyfilestring))
            {
                enemysettings = true;
                path = deckpath;
                cleanPath = cleandeckpath + enemyfilestring;
            }
            else if (deckName != "" && System.IO.File.Exists(deckpath + filestring))
            {
                path = deckpath;
                cleanPath = cleandeckpath + filestring;
            }
            else if (deckName != "" && System.IO.File.Exists(classpath + enemyfilestring))
            {
                enemysettings = true;
                path = classpath;
                cleanPath = cleanclasspath + enemyfilestring;
            }
            else if (deckName != "" && System.IO.File.Exists(classpath + filestring))
            {
                path = classpath;
                cleanPath = cleanclasspath + filestring;
            }
            else if (deckName != "" && System.IO.File.Exists(datapath + enemyfilestring))
            {
                enemysettings = true;
                path = datapath;
                cleanPath = cleandatapath + enemyfilestring;
            }
            else if (deckName != "" && System.IO.File.Exists(datapath + filestring))
            {
                path = datapath;
                cleanPath = cleandatapath + filestring;
            }
            else if (System.IO.File.Exists(path + enemyfilestring))
            {
                enemysettings = true;
                cleanPath = cleanpath + enemyfilestring;
            }
            else if (System.IO.File.Exists(path + filestring))
            {
                cleanPath = cleanpath + filestring;
            }
            else
            {
                Helpfunctions.Instance.logg("[Settings] cant find base settings.txt, using default settings");
                return setDefaultSettings();
            }
            Helpfunctions.Instance.ErrorLog("[Settings] read " + cleanPath);


            const string readerror = " read error. Continuing without user-defined rules.";
            if (enemysettings)
            {
                try
                {
                    lines = System.IO.File.ReadAllLines(path + enemyfilestring);
                }
                catch
                {
                    Helpfunctions.Instance.ErrorLog(enemyfilestring + readerror);
                    return setDefaultSettings();
                }
            }
            else
            {
                try
                {
                    lines = System.IO.File.ReadAllLines(path + filestring);
                }
                catch
                {
                    Helpfunctions.Instance.logg(filestring + readerror);
                    return setDefaultSettings();
                }
            }

            foreach (string ss in lines)
            {
                string s = ss.Replace(" ", "");
                if (s.Contains(";")) s = s.Split(';')[0];
                if (s.Contains("#")) s = s.Split('#')[0];
                if (s.Contains("//")) s = s.Split(new string[]{"//"}, StringSplitOptions.RemoveEmptyEntries)[0];
                if (s.Contains(",")) s = s.Split(',')[0];
                if (s == "" || s == " ") continue;
                s = s.ToLower();
                const string ignoring = "[Settings] ignoring the setting ";

                string searchword = "maxwide=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword,"");
                    try
                    {
                        this.maxwide = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "twotsamount=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.twotsamount = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "simenemysecondturn=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.simEnemySecondTurn = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "enfacehp=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.enfacehp = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "playarround=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.playarround = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "playaroundprob=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.playaroundprob = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "playaroundprob2=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.playaroundprob2 = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "enemyturnmaxwide=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.enemyTurnMaxWide = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "enemyturnmaxwidesecondtime=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.enemyTurnMaxWideSecondTime = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "enemysecondturnmaxwide=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.enemySecondTurnMaxWide = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }
               
                searchword = "nextturndeep=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.nextTurnDeep = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "nextturnmaxwide=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.nextTurnMaxWide = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "nextturntotalboards=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.nextTurnTotalBoards = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "usesecretsplayarround=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.useSecretsPlayArround = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "alpha=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.alpha = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "simulateplacement=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.simulatePlacement = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "useexternalprocess=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.useExternalProcess = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "passivewaiting=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.passiveWaiting = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "behave=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    if (a.StartsWith("control")) behave = new BehaviorControl();
                    if (a.StartsWith("rush")) behave = new BehaviorRush();
                    if (a.StartsWith("mana")) behave = new BehaviorMana();
                    if (a.StartsWith("face")) behave = new BehaviorFace();
                }

                searchword = "concedeonbadboard=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.enemyConcede = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "concedeonboardvalue=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.enemyConcedeValue = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "speed=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.speedy = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "usenetwork=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.useNetwork = Convert.ToBoolean(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "netaddress=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.netAddress = a;
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }

                searchword = "tcpport=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.tcpPort = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }
                //always enabled now so ignore user setting
                /*
                searchword = "logbuffer=";
                if (s.StartsWith(searchword))
                {
                    string a = s.Replace(searchword, "");
                    try
                    {
                        this.logBuffer = Convert.ToInt32(a);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog(ignoring + searchword);
                    }
                }
                */


            }
            //foreach ended----------

            applySettings();


            return behave;
        }

    }

}