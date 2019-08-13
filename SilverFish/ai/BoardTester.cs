namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BoardTester
    {

        public string botBehavior = "None";
        int maxwide = 3000;
        int twoturnsim = 256;
        int pprob1 = 50;
        int pprob2 = 80;
        bool playaround = false;

        int ownPlayer = 1;
        int enemmaxman = 0;

        Minion ownHero;
        Minion enemyHero;

        Weapon ownWeapon;
        Weapon enemyWeapon;

        int ownHEntity = 0;
        int enemyHEntity = 1;
        bool enemyHeroStealth = false;


        int gTurn = 0;
        int gTurnStep = 0;
        int mana = 0;
        int maxmana = 0;
        string ownheroname = "";
        int ownherohp = 0;
        int ownheromaxhp = 30;
        int enemyheromaxhp = 30;
        int ownherodefence = 0;
        bool ownheroready = false;
        bool ownHeroimmunewhileattacking = false;
        int ownheroattacksThisRound = 0;
        int ownHeroAttack = 0;
        int ownHeroTempAttack = 0;
        bool ownHeroStealth = false;
        int numOptionPlayedThisTurn = 0;
        int numMinionsPlayedThisTurn = 0;
        int cardsPlayedThisTurn = 0;
        int overload = 0;
        int lockedMana = 0;

        int anzOgOwnCThunHpBonus = 0;
        int anzOgOwnCThunAngrBonus = 0;
        int anzOgOwnCThunTaunt = 0;
        int anzOwnJadeGolem = 0;
        int anzEnemyJadeGolem = 0;
        int anzOwnElementalsThisTurn = 0;
        int anzOwnElementalsLastTurn = 0;
        int ownElementalsHaveLifesteal = 0;
        int ownCrystalCore = 0;
        bool ownMinionsInDeckCost0 = false;

        int ownDecksize = 30;
        int enemyDecksize = 30;
        int ownFatigue = 0;
        int enemyFatigue = 0;

        bool heroImmune = false;
        bool enemyHeroImmune = false;

        int ownHeroPowerCost = 2;
        int enemyHeroPowerCost = 2;

        int enemySecretAmount = 0;
        List<SecretItem> enemySecrets = new List<SecretItem>();

        bool ownHeroFrozen = false;

        List<string> ownsecretlist = new List<string>();
        string enemyheroname = "";
        int enemyherohp = 0;
        int enemyherodefence = 0;
        bool enemyFrozen = false;
        bool fistRun = true;
        int enemyNumberHand = 5;

        List<Minion> ownminions = new List<Minion>();
        List<Minion> enemyminions = new List<Minion>();
        List<Handmanager.Handcard> handcards = new List<Handmanager.Handcard>();
        List<CardDB.cardIDEnum> enemycards = new List<CardDB.cardIDEnum>();
        List<GraveYardItem> turnGraveYard = new List<GraveYardItem>();
        List<GraveYardItem> turnGraveYardAll = new List<GraveYardItem>();
        List<string> discover = new List<string>();
        Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();
        Dictionary<CardDB.cardIDEnum, int> og = new Dictionary<CardDB.cardIDEnum, int>();
        Dictionary<CardDB.cardIDEnum, int> eg = new Dictionary<CardDB.cardIDEnum, int>();

        bool feugendead = false;
        bool stalaggdead = false;
        public bool datareaded = false;

        public BoardTester(string data = "")
        {
            og.Clear();
            eg.Clear();

            string omd = "";
            string emd = "";

            int weaponOnlyAttackMobsUntilEnfacehp = 0;
            int berserkIfCanFinishNextTour = 0;
            int facehp = 15;
            int placement = 0;

            int ets = 20;
            int ets2 = 200;

            int ntssw = 10;
            int ntssd = 6;
            int ntssm = 50;

            int iC = 0;
            int speedup = 0;
            int adjustActions = 0;
            int concedeMode = 0;

            int alpha = 50;

            bool dosecrets = false;

            Settings.Instance.placement = 0;
            Hrtprozis.Instance.clearAllNewGame();
            Handmanager.Instance.clearAllRecalc();
            string[] lines = new string[0] { };
            if (data == "")
            {
                this.datareaded = false;
                try
                {
                    string path = Settings.Instance.path;
                    lines = System.IO.File.ReadAllLines(path + "test.txt");
                    this.datareaded = true;
                }
                catch
                {
                    this.datareaded = false;
                    Helpfunctions.Instance.logg("cant find test.txt");
                    Helpfunctions.Instance.ErrorLog("cant find test.txt");
                    return;
                }
            }
            else
            {
                this.datareaded = true;
                lines = data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            CardDB.Card heroability = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_034);
            CardDB.Card enemyability = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_034);
            bool abilityReady = false;

            int readstate = 0;
            int counter = 0;

            Minion tempminion = new Minion();
            int j = 0;
            foreach (string sss in lines)
            {
                string s = sss + " ";
                Helpfunctions.Instance.logg(s);
                
                if (s.StartsWith("ailoop") || s.StartsWith("deep ") || s.StartsWith("cut to len"))
                {
                    continue;
                }

                if (s.StartsWith("####"))
                {
                    continue;
                }

                if (s.StartsWith("mana changed"))
                {
                    continue;
                }

                if (s.StartsWith("start calculations, current time: "))
                {
                    if (!fistRun) break;
                    fistRun = false;

                    Ai.Instance.currentCalculatedBoard = s.Split(' ')[4].Split(' ')[0];

                    this.botBehavior = s.Split(' ')[6].Split(' ')[0];

                    this.maxwide = Convert.ToInt32(s.Split(' ')[7].Split(' ')[0]);

                    //following params are optional
                    this.twoturnsim = 0;
                    if (s.Contains("twoturnsim ")) this.twoturnsim = Convert.ToInt32(s.Split(new string[] { "twoturnsim " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                    if (s.Contains(" face "))
                    {
                        string tmp = s.Split(new string[] { "face " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        facehp = Convert.ToInt32(tmp);
                    }
                        
                    if (s.Contains(" womob:"))
                    {
                        string tmp = s.Split(new string[] { " womob:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        weaponOnlyAttackMobsUntilEnfacehp = Convert.ToInt32(tmp);
                    }

                    if (s.Contains(" berserk:"))
                    {
                        string tmp = s.Split(new string[] { " berserk:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        berserkIfCanFinishNextTour = Convert.ToInt32(tmp);
                    }

                    if (s.Contains(" cede:"))
                    {
                        string tmp = s.Split(new string[] { " cede:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        concedeMode = Convert.ToInt32(tmp);
                    }

                    this.playaround = false;
                    if (s.Contains("playaround "))
                    {
                        string probs = s.Split(new string[] { "playaround " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        this.playaround = true;
                        this.pprob1 = Convert.ToInt32(probs.Split(' ')[0]);
                        this.pprob2 = Convert.ToInt32(probs.Split(' ')[1]);
                    }

                    if (s.Contains(" ets "))
                    {
                        string eturnsim = s.Split(new string[] { " ets " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ets = Convert.ToInt32(eturnsim.Split(' ')[0]);
                    }

                    if (s.Contains(" ets2 "))
                    {
                        string eturnsim2 = s.Split(new string[] { " ets2 " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ets2 = Convert.ToInt32(eturnsim2.Split(' ')[0]);
                    }
                    
                    if (s.Contains(" ntss "))
                    {
                        string ss = s.Split(new string[] { " ntss " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        ntssd = Convert.ToInt32(ss.Split(' ')[0]);
                        ntssw = Convert.ToInt32(ss.Split(' ')[1]);
                        ntssm = Convert.ToInt32(ss.Split(' ')[2]);
                    }
                    
                    if (s.Contains(" iC "))
                    {
                        string ss = s.Split(new string[] { " iC " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        iC = Convert.ToInt32(ss.Split(' ')[0]);
                    }

                    if (s.Contains(" speedup "))
                    {
                        string ss = s.Split(new string[] { " speedup " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        speedup = Convert.ToInt32(ss.Split(' ')[0]);
                    }

                    if (s.Contains(" aA "))
                    {
                        string ss = s.Split(new string[] { " aA " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        adjustActions = Convert.ToInt32(ss.Split(' ')[0]);
                    }

                    if (s.Contains(" secret")) dosecrets = true;

                    if (s.Contains(" weight "))
                    {
                        string alphaval = s.Split(new string[] { " weight " }, StringSplitOptions.RemoveEmptyEntries)[1];
                        alpha = Convert.ToInt32(alphaval.Split(' ')[0]);
                    }
                    
                    if (s.Contains(" plcmnt:"))
                    {
                        string tmp = s.Split(new string[] { " plcmnt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0];
                        placement = Convert.ToInt32(tmp);
                    }
                    continue;
                }
                
                if (s.StartsWith("enemy secretsCount:"))
                {
                    this.enemySecretAmount = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemySecrets.Clear();
                    if (this.enemySecretAmount >= 1 && s.Contains(";"))
                    {
                        string secretstuff = s.Split(';')[1];
                        foreach (string sec in secretstuff.Split(','))
                        {
                            if (sec == "" || sec == String.Empty || sec == " ") continue;
                            this.enemySecrets.Add(new SecretItem(sec));
                        }

                    }
                    continue;
                }

                if (s.StartsWith("turn "))
                {
                    string ss = s.Replace("turn ", "");
                    gTurn = Convert.ToInt32(ss.Split('/')[0]);
                    gTurnStep = Convert.ToInt32(ss.Split('/')[1]);
                }

                if (s.StartsWith("mana "))
                {
                    string ss = s.Replace("mana ", "");
                    mana = Convert.ToInt32(ss.Split('/')[0]);
                    maxmana = Convert.ToInt32(ss.Split('/')[1]);
                }

                if (s.StartsWith("emana "))
                {
                    string ss = s.Replace("emana ", "");
                    enemmaxman = Convert.ToInt32(ss);
                }

                if (s.StartsWith("Enemy cards: "))
                {
                    enemyNumberHand = Convert.ToInt32(s.Split(' ')[2]);
                    readstate = 0;
                    continue;
                }

                if (s.StartsWith("GraveYard:"))
                {
                    if (s.Contains("fgn")) this.feugendead = true;
                    if (s.Contains("stlgg")) this.stalaggdead = true;
                    continue;
                }

                if (s.StartsWith("osecrets: "))
                {
                    string secs = s.Replace("osecrets: ", "");
                    foreach (string sec in secs.Split(' '))
                    {
                        if (sec == "" || sec == string.Empty) continue;
                        this.ownsecretlist.Add(sec);
                    }
                    continue;
                }

                if (s.StartsWith("cthunbonus: "))
                {
                    String[] ss = s.Split(' ');
                    anzOgOwnCThunAngrBonus = Convert.ToInt32(ss[1]);
                    anzOgOwnCThunHpBonus = Convert.ToInt32(ss[2]);
                    anzOgOwnCThunTaunt = Convert.ToInt32(ss[3]);
                }

                if (s.StartsWith("jadegolems: "))
                {
                    String[] ss = s.Split(' ');
                    anzOwnJadeGolem = Convert.ToInt32(ss[1]);
                    anzEnemyJadeGolem = Convert.ToInt32(ss[2]);
                }

                if (s.StartsWith("elementals: "))
                {
                    String[] ss = s.Split(' ');
                    anzOwnElementalsThisTurn = Convert.ToInt32(ss[1]);
                    anzOwnElementalsLastTurn = Convert.ToInt32(ss[2]);
                    if (ss.Length > 3) ownElementalsHaveLifesteal = (ss[3] == "1") ? 1 : 0;
                }

                if (s.StartsWith("quests: "))
                {
                    String[] ss = s.Split(' ');
                    Questmanager.Instance.updateQuestStuff(ss[1], Convert.ToInt32(ss[2]), Convert.ToInt32(ss[3]), true);
                    Questmanager.Instance.updateQuestStuff(ss[4], Convert.ToInt32(ss[5]), Convert.ToInt32(ss[6]), false);
                }

                if (s.StartsWith("advanced: "))
                {
                    String[] ss = s.Split(' ');
                    this.ownCrystalCore = Convert.ToInt32(ss[1]);
                    this.ownMinionsInDeckCost0 = Convert.ToInt32(ss[2]) == 1 ? true : false;
                }

                if (s.StartsWith("ownDiedMinions: "))
                {
                    string temp = "";
                    temp = s.Replace("ownDiedMinions: ", "");

                    foreach (string str in temp.Split(';'))
                    {
                        if (str == "" || str == " ") continue;
                        string id = str.Split(',')[0];
                        string ent = str.Split(',')[1];
                        GraveYardItem gyi = new GraveYardItem(CardDB.Instance.cardIdstringToEnum(id), Convert.ToInt32(ent), true);
                        this.turnGraveYard.Add(gyi);
                    }
                    continue;
                }

                if (s.StartsWith("enemyDiedMinions: "))
                {
                    string temp = "";
                    temp = s.Replace("enemyDiedMinions: ", "");

                    foreach (string str in temp.Split(';'))
                    {
                        if (str == "" || str == " ") continue;
                        string id = str.Split(',')[0];
                        string ent = str.Split(',')[1];
                        GraveYardItem gyi = new GraveYardItem(CardDB.Instance.cardIdstringToEnum(id), Convert.ToInt32(ent), false);
                        this.turnGraveYard.Add(gyi);
                    }
                    continue;
                }

                if (s.StartsWith("otg: "))
                {
                    string temp = "";
                    temp = s.Replace("otg: ", "");

                    foreach (string str in temp.Split(';'))
                    {
                        if (str == "" || str == " ") continue;
                        string id = str.Split(',')[0];
                        string ent = str.Split(',')[1];
                        GraveYardItem gyi = new GraveYardItem(CardDB.Instance.cardIdstringToEnum(id), Convert.ToInt32(ent), true);
                        this.turnGraveYardAll.Add(gyi);
                    }
                    continue;
                }

                if (s.StartsWith("etg: "))
                {
                    string temp = "";
                    temp = s.Replace("etg: ", "");

                    foreach (string str in temp.Split(';'))
                    {
                        if (str == "" || str == " ") continue;
                        string id = str.Split(',')[0];
                        string ent = str.Split(',')[1];
                        GraveYardItem gyi = new GraveYardItem(CardDB.Instance.cardIdstringToEnum(id), Convert.ToInt32(ent), false);
                        this.turnGraveYardAll.Add(gyi);
                    }
                    continue;
                }
                
                if (s.StartsWith("og:"))
                {
                    string temp = s.Replace("og: ", "");
                    foreach (string tmp in temp.Split(';'))
                    {
                        if (tmp == "" || tmp == " ") continue;
                        string id = tmp.Split(',')[0];
                        int anz = Convert.ToInt32(tmp.Split(',')[1]);
                        CardDB.cardIDEnum cide = CardDB.Instance.cardIdstringToEnum(id);
                        this.og.Add(cide, anz);
                    }
                    continue;
                }
                if (s.StartsWith("eg:"))
                {
                    string temp = s.Replace("eg: ", "");
                    foreach (string tmp in temp.Split(';'))
                    {
                        if (tmp == "" || tmp == " ") continue;
                        string id = tmp.Split(',')[0];
                        int anz = Convert.ToInt32(tmp.Split(',')[1]);
                        CardDB.cardIDEnum cide = CardDB.Instance.cardIdstringToEnum(id);
                        this.eg.Add(cide, anz);
                    }
                    continue;
                }
                
                if (s.StartsWith("discover card:"))
                {
                    this.discover.Add(s.Split(' ')[2]);
                    this.discover.Add(s.Split(' ')[3]);
                    this.discover.Add(s.Split(' ')[4]);
                    this.discover.Add(s.Split(' ')[5]);
                    continue;
                }

                if (readstate == 42 && counter == 1) // player
                {
                    String[] ss = s.Split(' ');
                    this.numMinionsPlayedThisTurn = Convert.ToInt32(ss[0]);
                    this.cardsPlayedThisTurn = Convert.ToInt32(ss[1]);
                    this.overload = Convert.ToInt32(ss[2]);
                    if (ss.Length == 5) this.ownPlayer = Convert.ToInt32(ss[3]); 
                    else
                    {
                        this.lockedMana = Convert.ToInt32(ss[3]);
                        this.ownPlayer = Convert.ToInt32(ss[4]);
                    }
                }

                if (readstate == 1 && counter == 1) // class + hp + defence + immunewhile attacking + immune
                {
                    String[] h = s.Split(' ');
                    ownheroname = h[0];
                    ownherohp = Convert.ToInt32(h[1]);
                    ownheromaxhp = Convert.ToInt32(h[2]);
                    ownherodefence = Convert.ToInt32(h[3]);
                    this.ownHeroimmunewhileattacking = (h[4] == "True") ? true : false;
                    this.heroImmune = (h[5] == "True") ? true : false;
                    ownHEntity = Convert.ToInt32(h[6]);
                    ownheroready = (h[7] == "True") ? true : false;
                    ownheroattacksThisRound = Convert.ToInt32(h[8]);
                    ownHeroFrozen = (h[9] == "True") ? true : false;
                    ownHeroAttack = Convert.ToInt32(h[10]);
                    ownHeroTempAttack = Convert.ToInt32(h[11]);
                    if (h.Length > 12) ownHeroStealth = (h[12] == "True") ? true : false;

                }

                if (readstate == 1 && counter == 2) // own hero weapon
                {
                    String[] w = s.Split(' ');

                    ownWeapon = new Weapon();
                    int d = Convert.ToInt32(w[2]);
                    if (d > 0)
                    {
                        if (w.Length > 5)
                        {
                            ownWeapon.equip(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(w[4])));
                            if (w.Length > 6) ownWeapon.poisonous = (w[5] == "1") ? true : false;
                            if (w.Length > 7) ownWeapon.lifesteal = (w[6] == "1") ? true : false;
                        }
                        else ownWeapon.equip(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(w[3])));
                    }
                    ownWeapon.Angr = Convert.ToInt32(w[1]);
                    ownWeapon.Durability = Convert.ToInt32(w[2]);
                }

                if (readstate == 1 && counter == 3) // ability + abilityready
                {
                    abilityReady = (s.Split(' ')[1] == "True");
                    heroability = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                }

                if (readstate == 1 && counter >= 5) // secrets
                {
                    if (!(s.StartsWith("enemyhero:") || s.StartsWith("cthunbonus:") || s.StartsWith("jadegolems:") || s.StartsWith("elementals:") || s.StartsWith("quests:") || s.StartsWith("advanced:")))
                    {
                        ownsecretlist.Add(s.Replace(" ", ""));
                    }
                }

                if (readstate == 2 && counter == 1) // class + hp + defence + frozen + immune
                {
                    String[] h = s.Split(' ');
                    enemyheroname = h[0];
                    enemyherohp = Convert.ToInt32(h[1]);
                    enemyheromaxhp = Convert.ToInt32(h[2]);
                    enemyherodefence = Convert.ToInt32(h[3]);
                    enemyFrozen = (h[4] == "True") ? true : false;
                    enemyHeroImmune = (h[5] == "True") ? true : false;
                    enemyHEntity = Convert.ToInt32(h[6]);
                    if (h.Length > 7) enemyHeroStealth = (h[7] == "True") ? true : false;
                }

                if (readstate == 2 && counter == 2) // weapon + stuff
                {
                    String[] w = s.Split(' ');

                    enemyWeapon = new Weapon();
                    int d = Convert.ToInt32(w[2]);
                    if (d > 0)
                    {
                        if (w.Length > 5)
                        {
                            enemyWeapon.equip(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(w[4])));
                            if (w.Length > 6) enemyWeapon.poisonous = (w[5] == "1") ? true : false;
                            if (w.Length > 7) enemyWeapon.lifesteal = (w[6] == "1") ? true : false;
                        }
                        else enemyWeapon.equip(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(w[3])));
                    }
                    enemyWeapon.Angr = Convert.ToInt32(w[1]);
                    enemyWeapon.Durability = Convert.ToInt32(w[2]);
                }
                if (readstate == 2 && counter == 3) // ability
                {
                    enemyability = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(' ')[2]));
                }
                if (readstate == 2 && counter == 4) // fatigue
                {
                    this.ownDecksize = Convert.ToInt32(s.Split(' ')[1]);
                    this.enemyDecksize = Convert.ToInt32(s.Split(' ')[3]);
                    this.ownFatigue = Convert.ToInt32(s.Split(' ')[2]);
                    this.enemyFatigue = Convert.ToInt32(s.Split(' ')[4]);
                }

                if (readstate == 3) // minion + enchantment
                {
                    if (s.Contains(" zp:"))
                    {

                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int zp = Convert.ToInt32(s.Split(new string[] { " zp:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int ent = 1000 + j;
                        if (s.Contains(" e:")) ent = Convert.ToInt32(s.Split(new string[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int attack = Convert.ToInt32(s.Split(new string[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp = Convert.ToInt32(s.Split(new string[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp = Convert.ToInt32(s.Split(new string[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new string[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True";
                        if (s.Contains(" respawn:"))
                        {
                            string[] tmp = s.Split(new string[] { " respawn:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0].Split(':');
                            LurkersDB.Add(ent, new IDEnumOwner() { IDEnum = CardDB.Instance.cardIdstringToEnum(tmp[0]), own = (tmp[1] == "True" ? true : false) });
                        }
                        int natt = 0;
                        if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hChoice = 0;//hidden choice
                        if (s.Contains(" hChoice:")) hChoice = Convert.ToInt32(s.Split(new string[] { " hChoice:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        // optional params (bools)
                        bool ex = s.Contains(" ex");
                        bool taunt = s.Contains(" tnt");
                        bool frzn = s.Contains(" frz");
                        bool silenced = s.Contains(" silenced");
                        bool divshield = s.Contains(" divshield");
                        bool ptt = s.Contains(" ptt");
                        bool wndfry = s.Contains(" wndfr");
                        bool stl = s.Contains(" stlth");
                        bool pois = s.Contains(" poi");
                        bool lfst = s.Contains(" lfst");
                        bool immn = s.Contains(" imm");
                        bool untch = s.Contains(" untch");
                        bool cncdl = s.Contains(" cncdl");
                        bool destroyOnOwnTurnStart = s.Contains(" dstrOwnTrnStrt");
                        bool destroyOnOwnTurnEnd = s.Contains(" dstrOwnTrnnd");
                        bool destroyOnEnemyTurnStart = s.Contains(" dstrEnmTrnStrt");
                        bool destroyOnEnemyTurnEnd = s.Contains(" dstrEnmTrnnd");
                        bool shadowmadnessed = s.Contains(" shdwmdnssd");
                        bool cntlower = s.Contains(" cantLowerHpBelowOne");
                        bool cbtBySpells = s.Contains(" cbtBySpells");
                        //optional params (ints)


                        int chrg = 0;//charge
                        if (s.Contains(" chrg(")) chrg = Convert.ToInt32(s.Split(new string[] { " chrg(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int adjadmg = 0;//adjadmg
                        if (s.Contains(" adjaattk(")) adjadmg = Convert.ToInt32(s.Split(new string[] { " adjaattk(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int tmpdmg = 0;//adjadmg
                        if (s.Contains(" tmpattck(")) tmpdmg = Convert.ToInt32(s.Split(new string[] { " tmpattck(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int spllpwr = 0;//adjadmg
                        if (s.Contains(" spllpwr(")) spllpwr = Convert.ToInt32(s.Split(new string[] { " spllpwr(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ancestralspirit = 0;//adjadmg
                        if (s.Contains(" ancstrl(")) ancestralspirit = Convert.ToInt32(s.Split(new string[] { " ancstrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int desperatestand = 0;//adjadmg
                        if (s.Contains(" despStand(")) desperatestand = Convert.ToInt32(s.Split(new string[] { " despStand(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" ownBlssng(")) ownBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " ownBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" enemyBlssng(")) enemyBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " enemyBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownPowerWordGlory = 0;//adjadmg
                        if (s.Contains(" ownGlory(")) ownPowerWordGlory = Convert.ToInt32(s.Split(new string[] { " ownGlory(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyPowerWordGlory = 0;//adjadmg
                        if (s.Contains(" enemyGlory(")) enemyPowerWordGlory = Convert.ToInt32(s.Split(new string[] { " enemyGlory(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int souloftheforest = 0;//adjadmg
                        if (s.Contains(" souloffrst(")) souloftheforest = Convert.ToInt32(s.Split(new string[] { " souloffrst(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                                                    
                        int stegodon = 0;//adjadmg
                        if (s.Contains(" stegodon(")) stegodon = Convert.ToInt32(s.Split(new string[] { " stegodon(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int livingspores = 0;//adjadmg
                        if (s.Contains(" lspores(")) livingspores = Convert.ToInt32(s.Split(new string[] { " lspores(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int explorershat = 0;//adjadmg
                        if (s.Contains(" explHat(")) explorershat = Convert.ToInt32(s.Split(new string[] { " explHat(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        
                        int returnToHand = 0;//adjadmg
                        if (s.Contains(" retHand(")) returnToHand = Convert.ToInt32(s.Split(new string[] { " retHand(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        
                        int infest = 0;//adjadmg
                        if (s.Contains(" infest(")) infest = Convert.ToInt32(s.Split(new string[] { " infest(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        CardDB.Card deathrattle2 = null;
                        if (s.Contains(" dethrl(")) deathrattle2 = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(new string[] { " dethrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]));


                        tempminion = createNewMinion(new Handmanager.Handcard(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), zp, true);
                        tempminion.own = true;
                        tempminion.entitiyID = ent;
                        tempminion.handcard.entity = ent;
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.exhausted = ex;
                        tempminion.taunt = taunt;
                        tempminion.frozen = frzn;
                        tempminion.silenced = silenced;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.stealth = stl;
                        tempminion.poisonous = pois;
                        tempminion.lifesteal = lfst;
                        tempminion.immune = immn;
                        tempminion.untouchable = untch;
                        tempminion.conceal = cncdl;
                        tempminion.destroyOnOwnTurnStart = destroyOnOwnTurnStart;
                        tempminion.destroyOnOwnTurnEnd = destroyOnOwnTurnEnd;
                        tempminion.destroyOnEnemyTurnStart = destroyOnEnemyTurnStart;
                        tempminion.destroyOnEnemyTurnEnd = destroyOnEnemyTurnEnd;
                        tempminion.shadowmadnessed = shadowmadnessed;
                        tempminion.cantLowerHPbelowONE = cntlower;
                        tempminion.cantBeTargetedBySpellsOrHeroPowers = cbtBySpells;

                        tempminion.charge = chrg;
                        tempminion.hChoice = hChoice;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.desperatestand = desperatestand;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.ownPowerWordGlory = ownPowerWordGlory;
                        tempminion.enemyPowerWordGlory = enemyPowerWordGlory;
                        tempminion.souloftheforest = souloftheforest;
                        tempminion.stegodon = stegodon;
                        tempminion.livingspores = livingspores;
                        tempminion.explorershat = explorershat;
                        tempminion.returnToHand = returnToHand;
                        tempminion.infest = infest;
                        tempminion.deathrattle2 = deathrattle2;

                        if (maxhp > hp) tempminion.wounded = true;
                        tempminion.updateReadyness();
                        this.ownminions.Add(tempminion);



                    }

                }

                if (readstate == 4) // minion or enchantment
                {
                    if (s.Contains(" zp:"))
                    {

                        string minionname = s.Split(' ')[0];
                        string minionid = s.Split(' ')[1];
                        int zp = Convert.ToInt32(s.Split(new string[] { " zp:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int ent = 1000 + j;
                        if (s.Contains(" e:")) ent = Convert.ToInt32(s.Split(new string[] { " e:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int attack = Convert.ToInt32(s.Split(new string[] { " A:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hp = Convert.ToInt32(s.Split(new string[] { " H:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int maxhp = Convert.ToInt32(s.Split(new string[] { " mH:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        bool ready = s.Split(new string[] { " rdy:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0] == "True" ? true : false;
                        int natt = 0;
                        //if (s.Contains(" natt:")) natt = Convert.ToInt32(s.Split(new string[] { " natt:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);
                        int hChoice = 0;//hidden choice
                        if (s.Contains(" hChoice:")) hChoice = Convert.ToInt32(s.Split(new string[] { " hChoice:" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ')[0]);

                        // optional params (bools)
                        bool ex = s.Contains(" ex");
                        bool taunt = s.Contains(" tnt");
                        bool frzn = s.Contains(" frz");
                        bool silenced = s.Contains(" silenced");
                        bool divshield = s.Contains(" divshield");
                        bool ptt = s.Contains(" ptt");
                        bool wndfry = s.Contains(" wndfr");
                        bool stl = s.Contains(" stlth");
                        bool pois = s.Contains(" poi");
                        bool lfst = s.Contains(" lfst");
                        bool immn = s.Contains(" imm");
                        bool untch = s.Contains(" untch");
                        bool cncdl = s.Contains(" cncdl");
                        bool destroyOnOwnTurnStart = s.Contains(" dstrOwnTrnStrt");
                        bool destroyOnOwnTurnEnd = s.Contains(" dstrOwnTrnnd");
                        bool destroyOnEnemyTurnStart = s.Contains(" dstrEnmTrnStrt");
                        bool destroyOnEnemyTurnEnd = s.Contains(" dstrEnmTrnnd");
                        bool shadowmadnessed = s.Contains(" shdwmdnssd");
                        bool cntlower = s.Contains(" cantLowerHpBelowOne");
                        bool cbtBySpells = s.Contains(" cbtBySpells");
                        //optional params (ints)


                        int chrg = 0;//charge
                        if (s.Contains(" chrg(")) chrg = Convert.ToInt32(s.Split(new string[] { " chrg(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int adjadmg = 0;//adjadmg
                        if (s.Contains(" adjaattk(")) adjadmg = Convert.ToInt32(s.Split(new string[] { " adjaattk(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int tmpdmg = 0;//adjadmg
                        if (s.Contains(" tmpattck(")) tmpdmg = Convert.ToInt32(s.Split(new string[] { " tmpattck(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int spllpwr = 0;//adjadmg
                        if (s.Contains(" spllpwr(")) spllpwr = Convert.ToInt32(s.Split(new string[] { " spllpwr(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ancestralspirit = 0;//adjadmg
                        if (s.Contains(" ancstrl(")) ancestralspirit = Convert.ToInt32(s.Split(new string[] { " ancstrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int desperatestand = 0;//adjadmg
                        if (s.Contains(" despStand(")) desperatestand = Convert.ToInt32(s.Split(new string[] { " despStand(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" ownBlssng(")) ownBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " ownBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyBlessingOfWisdom = 0;//adjadmg
                        if (s.Contains(" enemyBlssng(")) enemyBlessingOfWisdom = Convert.ToInt32(s.Split(new string[] { " enemyBlssng(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int ownPowerWordGlory = 0;//adjadmg
                        if (s.Contains(" ownGlory(")) ownPowerWordGlory = Convert.ToInt32(s.Split(new string[] { " ownGlory(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int enemyPowerWordGlory = 0;//adjadmg
                        if (s.Contains(" enemyGlory(")) enemyPowerWordGlory = Convert.ToInt32(s.Split(new string[] { " enemyGlory(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int souloftheforest = 0;//adjadmg
                        if (s.Contains(" souloffrst(")) souloftheforest = Convert.ToInt32(s.Split(new string[] { " souloffrst(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        
                        int stegodon = 0;//adjadmg
                        if (s.Contains(" stegodon(")) stegodon = Convert.ToInt32(s.Split(new string[] { " stegodon(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int livingspores = 0;//adjadmg
                        if (s.Contains(" lspores(")) livingspores = Convert.ToInt32(s.Split(new string[] { " lspores(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int explorershat = 0;//adjadmg
                        if (s.Contains(" explHat(")) explorershat = Convert.ToInt32(s.Split(new string[] { " explHat(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        int returnToHand = 0;//adjadmg
                        if (s.Contains(" retHand(")) returnToHand = Convert.ToInt32(s.Split(new string[] { " retHand(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);
                        
                        int infest = 0;//adjadmg
                        if (s.Contains(" infest(")) infest = Convert.ToInt32(s.Split(new string[] { " infest(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]);

                        CardDB.Card deathrattle2 = null;
                        if (s.Contains(" dethrl(")) deathrattle2 = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s.Split(new string[] { " dethrl(" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(')')[0]));


                        tempminion = createNewMinion(new Handmanager.Handcard(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(minionid))), zp, false);
                        tempminion.own = false;
                        tempminion.entitiyID = ent;
                        tempminion.handcard.entity = ent;
                        tempminion.Angr = attack;
                        tempminion.Hp = hp;
                        tempminion.maxHp = maxhp;
                        tempminion.Ready = ready;
                        tempminion.numAttacksThisTurn = natt;
                        tempminion.exhausted = ex;
                        tempminion.taunt = taunt;
                        tempminion.frozen = frzn;
                        tempminion.silenced = silenced;
                        tempminion.divineshild = divshield;
                        tempminion.playedThisTurn = ptt;
                        tempminion.windfury = wndfry;
                        tempminion.stealth = stl;
                        tempminion.poisonous = pois;
                        tempminion.lifesteal = lfst;
                        tempminion.immune = immn;
                        tempminion.untouchable = untch;
                        tempminion.conceal = cncdl;
                        tempminion.destroyOnOwnTurnStart = destroyOnOwnTurnStart;
                        tempminion.destroyOnOwnTurnEnd = destroyOnOwnTurnEnd;
                        tempminion.destroyOnEnemyTurnStart = destroyOnEnemyTurnStart;
                        tempminion.destroyOnEnemyTurnEnd = destroyOnEnemyTurnEnd;
                        tempminion.shadowmadnessed = shadowmadnessed;
                        tempminion.cantLowerHPbelowONE = cntlower;
                        tempminion.cantBeTargetedBySpellsOrHeroPowers = cbtBySpells;

                        tempminion.charge = chrg;
                        tempminion.hChoice = hChoice;
                        tempminion.AdjacentAngr = adjadmg;
                        tempminion.tempAttack = tmpdmg;
                        tempminion.spellpower = spllpwr;

                        tempminion.ancestralspirit = ancestralspirit;
                        tempminion.desperatestand = desperatestand;
                        tempminion.ownBlessingOfWisdom = ownBlessingOfWisdom;
                        tempminion.enemyBlessingOfWisdom = enemyBlessingOfWisdom;
                        tempminion.ownPowerWordGlory = ownPowerWordGlory;
                        tempminion.enemyPowerWordGlory = enemyPowerWordGlory;
                        tempminion.souloftheforest = souloftheforest;
                        tempminion.stegodon = stegodon;
                        tempminion.livingspores = livingspores;
                        tempminion.explorershat = explorershat;
                        tempminion.returnToHand = returnToHand;
                        tempminion.infest = infest;
                        tempminion.deathrattle2 = deathrattle2;

                        if (maxhp > hp) tempminion.wounded = true;
                        tempminion.updateReadyness();
                        this.enemyminions.Add(tempminion);


                    }


                }

                if (readstate == 5) // minion or enchantment
                {

                    Handmanager.Handcard card = new Handmanager.Handcard();

                    String[] hc = s.Split(' ');
                    card.position = Convert.ToInt32(hc[1]);
                    string minionname = hc[2];
                    card.manacost = Convert.ToInt32(hc[3]);
                    card.entity = Convert.ToInt32(hc[5]);
                    card.card = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(hc[6]));
                    if (hc.Length > 8) card.addattack = Convert.ToInt32(hc[7]);
                    if (hc.Length > 9) card.addHp = Convert.ToInt32(hc[8]);
                    if (hc.Length > 10) card.elemPoweredUp = Convert.ToInt32(hc[9]);
                    handcards.Add(card);
                }


                if (s.StartsWith("ownhero:"))
                {
                    readstate = 1;
                    counter = 0;
                }

                if (s.StartsWith("enemyhero:"))
                {
                    readstate = 2;
                    counter = 0;
                }

                if (s.StartsWith("OwnMinions:"))
                {
                    readstate = 3;
                    counter = 0;
                }

                if (s.StartsWith("EnemyMinions:"))
                {
                    readstate = 4;
                    counter = 0;
                }

                if (s.StartsWith("Own Handcards:"))
                {
                    readstate = 5;
                    counter = 0;
                }

                if (s.StartsWith("player:"))
                {
                    readstate = 42;
                    counter = 0;
                }



                counter++;
                j++;
            }
            Helpfunctions.Instance.logg("rdy");

            //Set default settings for behaviour
            Settings.Instance.setSettings(this.botBehavior);
            Settings.Instance.test = true;

            //Apply settings from this UILogg
            Hrtprozis.Instance.setAttackFaceHP(facehp);
            ComboBreaker.Instance.attackFaceHP = facehp;
            Settings.Instance.enfacehp = facehp;
            Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp = weaponOnlyAttackMobsUntilEnfacehp;
            Settings.Instance.berserkIfCanFinishNextTour = berserkIfCanFinishNextTour;
            Settings.Instance.concedeMode = concedeMode;            
            Settings.Instance.enemyTurnMaxWide = ets;
            Settings.Instance.enemyTurnMaxWideSecondStep = ets2;
            Settings.Instance.placement = placement;
            Settings.Instance.nextTurnDeep = ntssd;
            Settings.Instance.nextTurnMaxWide = ntssw;
            Settings.Instance.nextTurnTotalBoards = ntssm;
            Settings.Instance.ImprovedCalculations = iC;
            Settings.Instance.speedupLevel = speedup;
            Settings.Instance.adjustActions = adjustActions;
            Settings.Instance.useSecretsPlayAround = dosecrets;
            Settings.Instance.setWeights(alpha);
            Settings.Instance.playaround = this.playaround;
            Settings.Instance.playaroundprob = this.pprob1;
            Settings.Instance.playaroundprob2 = this.pprob2;


            //set Simulation stuff
            Ai.Instance.botBase = Silverfish.Instance.getBehaviorByName(this.botBehavior);
            RulesEngine.Instance.setCardIdRulesGame(heroNametoClass(this.ownheroname), heroNametoClass(this.enemyheroname));
            RulesEngine.Instance.setRulesTurn((gTurn + 1) / 2);
            Ai.Instance.setMaxWide(this.maxwide);
            Ai.Instance.setTwoTurnSimulation(false, this.twoturnsim);
            Ai.Instance.setPlayAround();
            

            Hrtprozis.Instance.setOwnPlayer(ownPlayer);
            Handmanager.Instance.setOwnPlayer(ownPlayer);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + ownheroattacksThisRound;
            foreach (Minion m in this.ownminions)
            {
                this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
            }

            Hrtprozis.Instance.updateTurnInfo(this.gTurn, this.gTurnStep);
            Hrtprozis.Instance.updatePlayer(this.maxmana, this.mana, this.cardsPlayedThisTurn, this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.overload, this.lockedMana, ownHEntity, enemyHEntity);
            Hrtprozis.Instance.updateSecretStuff(this.ownsecretlist, enemySecretAmount);
            Hrtprozis.Instance.updateCThunInfo(this.anzOgOwnCThunAngrBonus, this.anzOgOwnCThunHpBonus, this.anzOgOwnCThunTaunt);
            Hrtprozis.Instance.updateJadeGolemsInfo(this.anzOwnJadeGolem, this.anzEnemyJadeGolem);
            Hrtprozis.Instance.updateElementals(this.anzOwnElementalsThisTurn, this.anzOwnElementalsLastTurn, this.ownElementalsHaveLifesteal);
            Hrtprozis.Instance.updateCrystalCore(this.ownCrystalCore);
            Hrtprozis.Instance.updateOwnMinionsInDeckCost0(this.ownMinionsInDeckCost0);
            Hrtprozis.Instance.updateDiscoverCards(this.discover);

            bool herowindfury = false;
            if (this.ownWeapon.windfury) herowindfury = true;

            //create heros:

            this.ownHero = new Minion();
            this.enemyHero = new Minion();
            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = this.ownheromaxhp;
            this.enemyHero.maxHp = this.enemyheromaxhp;
            this.ownHero.entitiyID = ownHEntity;
            this.enemyHero.entitiyID = enemyHEntity;
            this.ownHero.cardClass = heroNametoClass(this.ownheroname);
            this.enemyHero.cardClass = heroNametoClass(this.enemyheroname);
            
            this.ownHero.Angr = ownHeroAttack;
            this.ownHero.Hp = ownherohp;
            this.ownHero.armor = ownherodefence;
            this.ownHero.frozen = ownHeroFrozen;
            this.ownHero.immuneWhileAttacking = ownHeroimmunewhileattacking;
            this.ownHero.immune = heroImmune;
            this.ownHero.numAttacksThisTurn = ownheroattacksThisRound;
            this.ownHero.windfury = herowindfury;
            this.ownHero.stealth = ownHeroStealth;

            this.enemyHero.Angr = enemyWeapon.Angr;
            this.enemyHero.Hp = enemyherohp;
            this.enemyHero.frozen = enemyFrozen;
            this.enemyHero.armor = enemyherodefence;
            this.enemyHero.immune = enemyHeroImmune;
            this.enemyHero.stealth = enemyHeroStealth;
            this.enemyHero.Ready = false;

            this.ownHero.updateReadyness();


            //save data
            Hrtprozis.Instance.updateHero(this.ownWeapon, this.ownheroname, heroability, abilityReady, this.ownHeroPowerCost, this.ownHero);
            Hrtprozis.Instance.updateHero(this.enemyWeapon, this.enemyheroname, enemyability, false, this.enemyHeroPowerCost, this.enemyHero, enemmaxman);
            Hrtprozis.Instance.updateHeroStartClass(heroNametoClass(this.ownheroname), heroNametoClass(this.enemyheroname));

            Hrtprozis.Instance.updateMinions(this.ownminions, this.enemyminions);
            Hrtprozis.Instance.updateLurkersDB(this.LurkersDB);

            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownFatigue, this.enemyDecksize, this.enemyFatigue);

            Handmanager.Instance.setHandcards(this.handcards, this.handcards.Count, enemyNumberHand);

            Probabilitymaker.Instance.setEnemySecretData(enemySecrets);

            Probabilitymaker.Instance.setTurnGraveYard(this.turnGraveYard, this.turnGraveYardAll);
            Probabilitymaker.Instance.stalaggDead = this.stalaggdead;
            Probabilitymaker.Instance.feugenDead = this.feugendead;

            Probabilitymaker.Instance.setOwnCardsOut(og);
            Probabilitymaker.Instance.setEnemyCardsOut(eg);
        }



        public Minion createNewMinion(Handmanager.Handcard hc, int zonepos, bool own)
        {
            Minion m = new Minion
            {
                handcard = new Handmanager.Handcard(hc),
                zonepos = zonepos,
                entitiyID = hc.entity,
                Angr = hc.card.Attack,
                Hp = hc.card.Health,
                maxHp = hc.card.Health,
                name = hc.card.name,
                playedThisTurn = true,
                numAttacksThisTurn = 0
            };

            m.own = own;
            m.isHero = false;
            m.entitiyID = hc.entity;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.windfury = hc.card.windfury;
            m.taunt = hc.card.tank;
            m.charge = (hc.card.Charge) ? 1 : 0;
            m.divineshild = hc.card.Shield;
            m.poisonous = hc.card.poisonous;
            m.lifesteal = hc.card.lifesteal;
            m.stealth = hc.card.Stealth;

            if (own) m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(heroNametoClass(this.ownheroname), (TAG_RACE)hc.card.race);
            else m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(heroNametoClass(this.enemyheroname), (TAG_RACE)hc.card.race);
            if (m.synergy > 0 && hc.card.Stealth) m.synergy++;

            m.updateReadyness();

            if (m.name == CardDB.cardName.lightspawn)
            {
                m.Angr = m.Hp;
            }
            return m;
        }


        public TAG_CLASS heroNametoClass(string s)
        {
            switch (s)
            {
                case "hunter": return TAG_CLASS.HUNTER;
                case "priest": return TAG_CLASS.PRIEST;
                case "druid": return TAG_CLASS.DRUID;
                case "warlock": return TAG_CLASS.WARLOCK;
                case "thief": return TAG_CLASS.ROGUE;
                case "pala": return TAG_CLASS.PALADIN;
                case "warrior": return TAG_CLASS.WARRIOR;
                case "shaman": return TAG_CLASS.SHAMAN;
                case "mage": return TAG_CLASS.MAGE;
                default: return TAG_CLASS.INVALID;
            }
        }


        public void printSettings()
        {
            Helpfunctions.Instance.logg("#################### Settings #########################################");
            Helpfunctions.Instance.logg("path = " + Settings.Instance.path);
            Helpfunctions.Instance.logg("logpath = " + Settings.Instance.logpath);
            Helpfunctions.Instance.logg("logfile = " + Settings.Instance.logfile);
            Helpfunctions.Instance.logg("twotsamount = " + Settings.Instance.twotsamount);
            Helpfunctions.Instance.logg("secondTurnAmount = " + Settings.Instance.secondTurnAmount);
            Helpfunctions.Instance.logg("playaroundprob2 = " + Settings.Instance.playaroundprob2);
            Helpfunctions.Instance.logg("playaroundprob = " + Settings.Instance.playaroundprob);
            Helpfunctions.Instance.logg("nextTurnTotalBoards = " + Settings.Instance.nextTurnTotalBoards);
            Helpfunctions.Instance.logg("nextTurnMaxWide = " + Settings.Instance.nextTurnMaxWide);
            Helpfunctions.Instance.logg("nextTurnDeep = " + Settings.Instance.nextTurnDeep);
            Helpfunctions.Instance.logg("maxwide = " + Settings.Instance.maxwide);
            Helpfunctions.Instance.logg("enfacehp = " + Settings.Instance.enfacehp);
            Helpfunctions.Instance.logg("weaponOnlyAttackMobsUntilEnfacehp = " + Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp);
            Helpfunctions.Instance.logg("enemyTurnMaxWideSecondStep = " + Settings.Instance.enemyTurnMaxWideSecondStep);
            Helpfunctions.Instance.logg("enemyTurnMaxWide = " + Settings.Instance.enemyTurnMaxWide);
            Helpfunctions.Instance.logg("alpha = " + Settings.Instance.alpha);
            Helpfunctions.Instance.logg("secondweight = " + Settings.Instance.secondweight);
            Helpfunctions.Instance.logg("firstweight = " + Settings.Instance.firstweight);
            Helpfunctions.Instance.logg("writeToSingleFile = " + Settings.Instance.writeToSingleFile);
            Helpfunctions.Instance.logg("useSecretsPlayAround = " + Settings.Instance.useSecretsPlayAround);
            Helpfunctions.Instance.logg("useExternalProcess = " + Settings.Instance.useExternalProcess);
            Helpfunctions.Instance.logg("placement = " + Settings.Instance.placement);
            Helpfunctions.Instance.logg("simulateEnemysTurn = " + Settings.Instance.simulateEnemysTurn);
            Helpfunctions.Instance.logg("printlearnmode = " + Settings.Instance.printlearnmode);
            Helpfunctions.Instance.logg("playaround = " + Settings.Instance.playaround);
            Helpfunctions.Instance.logg("passiveWaiting = " + Settings.Instance.passiveWaiting);
            Helpfunctions.Instance.logg("learnmode = " + Settings.Instance.learnmode);
            Helpfunctions.Instance.logg("enemyConcede = " + Settings.Instance.enemyConcede);
            Helpfunctions.Instance.logg("concede = " + Settings.Instance.concede);
            Helpfunctions.Instance.logg("ImprovedCalculations = " + Settings.Instance.ImprovedCalculations);
            Helpfunctions.Instance.logg("speedupLevel = " + Settings.Instance.speedupLevel);
            Helpfunctions.Instance.logg("adjustActions = " + Settings.Instance.adjustActions);
            Helpfunctions.Instance.logg("#################### Settings End #####################################");
        }

    }

}