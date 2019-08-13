namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public struct GraveYardItem
    {
        public bool own;
        public int entity;
        public CardDB.cardIDEnum cardid;

        public GraveYardItem(CardDB.cardIDEnum id, int entity, bool own)
        {
            this.own = own;
            this.cardid = id;
            this.entity = entity;
        }
    }

    public class SecretItem
    {
        public bool triggered = false;

        /*not in use temporarily 1
        public bool canbeTriggeredWithAttackingHero = true;
        public bool canbeTriggeredWithAttackingMinion = true;
        public bool canbeTriggeredWithPlayingMinion = true;
        public bool canbeTriggeredWithPlayingHeroPower = true;*/

        public bool canBe_snaketrap = true;
        public bool canBe_snipe = true;
        public bool canBe_explosive = true;
        public bool canBe_beartrap = true;
        public bool canBe_freezing = true;
        public bool canBe_missdirection = true;
        public bool canBe_darttrap = true;
        public bool canBe_cattrick = true;

        public bool canBe_counterspell = true;
        public bool canBe_icebarrier = true;
        public bool canBe_iceblock = true;
        public bool canBe_mirrorentity = true;
        public bool canBe_spellbender = true;
        public bool canBe_vaporize = true;
        public bool canBe_duplicate = true;
        public bool canBe_effigy = true;

        public bool canBe_eyeforaneye = true;
        public bool canBe_noblesacrifice = true;
        public bool canBe_redemption = true;
        public bool canBe_repentance = true;
        public bool canBe_avenge = true;
        public bool canBe_sacredtrial = true;

        public int entityId = 0;

        public SecretItem()
        {
        }

        public SecretItem(SecretItem sec)
        {
            this.triggered = sec.triggered;
            /*not in use temporarily 1
            this.canbeTriggeredWithAttackingHero = sec.canbeTriggeredWithAttackingHero;
            this.canbeTriggeredWithAttackingMinion = sec.canbeTriggeredWithAttackingMinion;
            this.canbeTriggeredWithPlayingMinion = sec.canbeTriggeredWithPlayingMinion;
            this.canbeTriggeredWithPlayingHeroPower = sec.canbeTriggeredWithPlayingHeroPower;*/

            this.canBe_avenge = sec.canBe_avenge;
            this.canBe_counterspell = sec.canBe_counterspell;
            this.canBe_duplicate = sec.canBe_duplicate;
            this.canBe_effigy = sec.canBe_effigy;
            this.canBe_explosive = sec.canBe_explosive;
            this.canBe_beartrap = sec.canBe_beartrap;
            this.canBe_eyeforaneye = sec.canBe_eyeforaneye;
            this.canBe_freezing = sec.canBe_freezing;
            this.canBe_icebarrier = sec.canBe_icebarrier;
            this.canBe_iceblock = sec.canBe_iceblock;
            this.canBe_cattrick = sec.canBe_cattrick;
            this.canBe_mirrorentity = sec.canBe_mirrorentity;
            this.canBe_missdirection = sec.canBe_missdirection;
            this.canBe_darttrap = sec.canBe_darttrap;
            this.canBe_noblesacrifice = sec.canBe_noblesacrifice;
            this.canBe_redemption = sec.canBe_redemption;
            this.canBe_repentance = sec.canBe_repentance;
            this.canBe_snaketrap = sec.canBe_snaketrap;
            this.canBe_snipe = sec.canBe_snipe;
            this.canBe_spellbender = sec.canBe_spellbender;
            this.canBe_vaporize = sec.canBe_vaporize;
            this.canBe_sacredtrial = sec.canBe_sacredtrial;

            this.entityId = sec.entityId;

        }

        public SecretItem(string secdata)
        {
            this.entityId = Convert.ToInt32(secdata.Split('.')[0]);

            string canbe = secdata.Split('.')[1];
            if (canbe.Length < 17)
            {
                Helpfunctions.Instance.ErrorLog("cant read secret " + secdata + " " + canbe.Length);
            }

            this.canBe_snaketrap = false;
            this.canBe_snipe = false;
            this.canBe_explosive = false;
            this.canBe_beartrap = false;
            this.canBe_freezing = false;
            this.canBe_missdirection = false;
            this.canBe_darttrap = false;
            this.canBe_cattrick = false;

            this.canBe_counterspell = false;
            this.canBe_icebarrier = false;
            this.canBe_iceblock = false;
            this.canBe_mirrorentity = false;
            this.canBe_spellbender = false;
            this.canBe_vaporize = false;
            this.canBe_duplicate = false;
            this.canBe_effigy = false;

            this.canBe_eyeforaneye = false;
            this.canBe_noblesacrifice = false;
            this.canBe_redemption = false;
            this.canBe_repentance = false;
            this.canBe_avenge = false;
            this.canBe_sacredtrial = false;

            if (canbe.Length == 22) //new
            {
                this.canBe_snaketrap = (canbe[0] == '1');
                this.canBe_snipe = (canbe[1] == '1');
                this.canBe_explosive = (canbe[2] == '1');
                this.canBe_beartrap = (canbe[3] == '1');
                this.canBe_freezing = (canbe[4] == '1');
                this.canBe_missdirection = (canbe[5] == '1');
                this.canBe_darttrap = (canbe[6] == '1');
                this.canBe_cattrick = (canbe[7] == '1');

                this.canBe_counterspell = (canbe[8] == '1');
                this.canBe_icebarrier = (canbe[9] == '1');
                this.canBe_iceblock = (canbe[10] == '1');
                this.canBe_mirrorentity = (canbe[11] == '1');
                this.canBe_spellbender = (canbe[12] == '1');
                this.canBe_vaporize = (canbe[13] == '1');
                this.canBe_duplicate = (canbe[14] == '1');
                this.canBe_effigy = (canbe[15] == '1');

                this.canBe_eyeforaneye = (canbe[16] == '1');
                this.canBe_noblesacrifice = (canbe[17] == '1');
                this.canBe_redemption = (canbe[18] == '1');
                this.canBe_repentance = (canbe[19] == '1');
                this.canBe_avenge = (canbe[20] == '1');
                this.canBe_sacredtrial = (canbe[21] == '1');
            }
            else if (canbe.Length == 21)
            {
                this.canBe_snaketrap = (canbe[0] == '1');
                this.canBe_snipe = (canbe[1] == '1');
                this.canBe_explosive = (canbe[2] == '1');
                this.canBe_beartrap = (canbe[3] == '1');
                this.canBe_freezing = (canbe[4] == '1');
                this.canBe_missdirection = (canbe[5] == '1');
                this.canBe_darttrap = (canbe[6] == '1');

                this.canBe_counterspell = (canbe[7] == '1');
                this.canBe_icebarrier = (canbe[8] == '1');
                this.canBe_iceblock = (canbe[9] == '1');
                this.canBe_mirrorentity = (canbe[10] == '1');
                this.canBe_spellbender = (canbe[11] == '1');
                this.canBe_vaporize = (canbe[12] == '1');
                this.canBe_duplicate = (canbe[13] == '1');
                this.canBe_effigy = (canbe[14] == '1');

                this.canBe_eyeforaneye = (canbe[15] == '1');
                this.canBe_noblesacrifice = (canbe[16] == '1');
                this.canBe_redemption = (canbe[17] == '1');
                this.canBe_repentance = (canbe[18] == '1');
                this.canBe_avenge = (canbe[19] == '1');
                this.canBe_sacredtrial = (canbe[20] == '1');
            }
            else if (canbe.Length == 20) //old
            {
                this.canBe_snaketrap = (canbe[0] == '1');
                this.canBe_snipe = (canbe[1] == '1');
                this.canBe_explosive = (canbe[2] == '1');
                this.canBe_beartrap = (canbe[3] == '1');
                this.canBe_freezing = (canbe[4] == '1');
                this.canBe_missdirection = (canbe[5] == '1');
                this.canBe_darttrap = (canbe[6] == '1');

                this.canBe_counterspell = (canbe[7] == '1');
                this.canBe_icebarrier = (canbe[8] == '1');
                this.canBe_iceblock = (canbe[9] == '1');
                this.canBe_mirrorentity = (canbe[10] == '1');
                this.canBe_spellbender = (canbe[11] == '1');
                this.canBe_vaporize = (canbe[12] == '1');
                this.canBe_duplicate = (canbe[13] == '1');

                this.canBe_eyeforaneye = (canbe[14] == '1');
                this.canBe_noblesacrifice = (canbe[15] == '1');
                this.canBe_redemption = (canbe[16] == '1');
                this.canBe_repentance = (canbe[17] == '1');
                this.canBe_avenge = (canbe[18] == '1');
                this.canBe_sacredtrial = (canbe[19] == '1');
            }

            this.updateCanBeTriggered();
        }

        public void updateCanBeTriggered()
        {
            /*not in use temporarily 1
            this.canbeTriggeredWithAttackingHero = false;
            this.canbeTriggeredWithAttackingMinion = false;
            this.canbeTriggeredWithPlayingMinion = false;
            this.canbeTriggeredWithPlayingHeroPower = false;

            if (this.canBe_snipe || this.canBe_mirrorentity || this.canBe_repentance || this.canBe_sacredtrial) this.canbeTriggeredWithPlayingMinion = true;

            if (this.canBe_explosive || this.canBe_beartrap || this.canBe_missdirection || this.canBe_freezing || this.canBe_icebarrier || this.canBe_vaporize || this.canBe_noblesacrifice) this.canbeTriggeredWithAttackingHero = true;

            if (this.canBe_snaketrap || this.canBe_freezing || this.canBe_noblesacrifice) this.canbeTriggeredWithAttackingMinion = true;

            if (this.canBe_darttrap) this.canbeTriggeredWithPlayingHeroPower = true;
            */
        }

        public void usedTrigger_CharIsAttacked(bool DefenderIsHero, bool AttackerIsHero)
        {
            if (DefenderIsHero)
            {
                this.canBe_explosive = false;
                this.canBe_beartrap = false;
                this.canBe_missdirection = false;

                this.canBe_icebarrier = false;
                this.canBe_vaporize = false;

            }
            else
            {
                this.canBe_snaketrap = false;
            }
            if (!AttackerIsHero)
            {
                this.canBe_freezing = false;
            }
            this.canBe_noblesacrifice = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_MinionIsPlayed(int i)
        {
            this.canBe_snipe = false;
            this.canBe_mirrorentity = false;
            this.canBe_repentance = false;
            if (i == 1) this.canBe_sacredtrial = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_SpellIsPlayed(bool minionIsTarget)
        {
            this.canBe_counterspell = false;
            this.canBe_cattrick = false;
            if (minionIsTarget) this.canBe_spellbender = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_MinionDied()
        {
            this.canBe_avenge = false;
            this.canBe_redemption = false;
            this.canBe_duplicate = false;
            this.canBe_effigy = false;
            updateCanBeTriggered();
        }

        public void usedTrigger_HeroGotDmg(bool deadly = false)
        {
            this.canBe_eyeforaneye = false;
            if (deadly) this.canBe_iceblock = false;
            updateCanBeTriggered();
        }
        public void usedTrigger_HeroPowerUsed()
        {
            this.canBe_darttrap = false;
            updateCanBeTriggered();
        }


        public string returnAString()
        {
            string retval = "" + this.entityId + ".";
            retval += "" + ((canBe_snaketrap) ? "1" : "0");
            retval += "" + ((canBe_snipe) ? "1" : "0");
            retval += "" + ((canBe_explosive) ? "1" : "0");
            retval += "" + ((canBe_beartrap) ? "1" : "0");
            retval += "" + ((canBe_freezing) ? "1" : "0");
            retval += "" + ((canBe_missdirection) ? "1" : "0");
            retval += "" + ((canBe_darttrap) ? "1" : "0");
            retval += "" + ((canBe_cattrick) ? "1" : "0");

            retval += "" + ((canBe_counterspell) ? "1" : "0");
            retval += "" + ((canBe_icebarrier) ? "1" : "0");
            retval += "" + ((canBe_iceblock) ? "1" : "0");
            retval += "" + ((canBe_mirrorentity) ? "1" : "0");
            retval += "" + ((canBe_spellbender) ? "1" : "0");
            retval += "" + ((canBe_vaporize) ? "1" : "0");
            retval += "" + ((canBe_duplicate) ? "1" : "0");
            retval += "" + ((canBe_effigy) ? "1" : "0");

            retval += "" + ((canBe_eyeforaneye) ? "1" : "0");
            retval += "" + ((canBe_noblesacrifice) ? "1" : "0");
            retval += "" + ((canBe_redemption) ? "1" : "0");
            retval += "" + ((canBe_repentance) ? "1" : "0");
            retval += "" + ((canBe_avenge) ? "1" : "0");
            retval += "" + ((canBe_sacredtrial) ? "1" : "0");
            return retval + ",";
        }

        public bool isEqual(SecretItem s)
        {
            bool result = this.entityId == s.entityId;
            if (!result)
            {
                result = result && this.canBe_avenge == s.canBe_avenge && this.canBe_counterspell == s.canBe_counterspell && this.canBe_duplicate == s.canBe_duplicate && this.canBe_effigy == s.canBe_effigy && this.canBe_explosive == s.canBe_explosive;
                result = result && this.canBe_eyeforaneye == s.canBe_eyeforaneye && this.canBe_freezing == s.canBe_freezing && this.canBe_icebarrier == s.canBe_icebarrier && this.canBe_iceblock == s.canBe_iceblock;
                result = result && this.canBe_mirrorentity == s.canBe_mirrorentity && this.canBe_missdirection == s.canBe_missdirection && this.canBe_noblesacrifice == s.canBe_noblesacrifice && this.canBe_redemption == s.canBe_redemption;
                result = result && this.canBe_repentance == s.canBe_repentance && this.canBe_snaketrap == s.canBe_snaketrap && this.canBe_snipe == s.canBe_snipe && this.canBe_spellbender == s.canBe_spellbender && this.canBe_vaporize == s.canBe_vaporize;
                result = result && this.canBe_sacredtrial == s.canBe_sacredtrial && this.canBe_darttrap == s.canBe_darttrap && this.canBe_beartrap == s.canBe_beartrap && this.canBe_cattrick == s.canBe_cattrick;
            }
            return result;
        }

    }

    public class Probabilitymaker
    {
        public Dictionary<CardDB.cardIDEnum, int> ownCardsOut = new Dictionary<CardDB.cardIDEnum, int>();
        public Dictionary<CardDB.cardIDEnum, int> enemyCardsOut = new Dictionary<CardDB.cardIDEnum, int>();
        List<GraveYardItem> graveyard = new List<GraveYardItem>();
        public List<GraveYardItem> turngraveyard = new List<GraveYardItem>();//MOBS only
        public List<GraveYardItem> turngraveyardAll = new List<GraveYardItem>();//All
        List<GraveYardItem> graveyartTillTurnStart = new List<GraveYardItem>();

        public List<SecretItem> enemySecrets = new List<SecretItem>();

        public bool feugenDead = false;
        public bool stalaggDead = false;

        private static Probabilitymaker instance;
        public static Probabilitymaker Instance
        {
            get
            {
                return instance ?? (instance = new Probabilitymaker());
            }
        }

        private Probabilitymaker()
        {

        }

        public void setOwnCardsOut(Dictionary<CardDB.cardIDEnum, int> og)
        {
            ownCardsOut.Clear();
            this.stalaggDead = false;
            this.feugenDead = false;
            foreach (var tmp in og)
            {
                ownCardsOut.Add(tmp.Key, tmp.Value);
                if (tmp.Key == CardDB.cardIDEnum.FP1_015) this.feugenDead = true;
                if (tmp.Key == CardDB.cardIDEnum.FP1_014) this.stalaggDead = true;
            }
        }
        public void setEnemyCardsOut(Dictionary<CardDB.cardIDEnum, int> eg)
        {
            enemyCardsOut.Clear();
            foreach (var tmp in eg)
            {
                enemyCardsOut.Add(tmp.Key, tmp.Value);
                if (tmp.Key == CardDB.cardIDEnum.FP1_015) this.feugenDead = true;
                if (tmp.Key == CardDB.cardIDEnum.FP1_014) this.stalaggDead = true;
            }
        }
        
        public void printTurnGraveYard()
        {
            /*string g = "";
            if (Probabilitymaker.Instance.feugenDead) g += " fgn";
            if (Probabilitymaker.Instance.stalaggDead) g += " stlgg";
            Helpfunctions.Instance.logg("GraveYard:" + g);
            if (writetobuffer) Helpfunctions.Instance.writeToBuffer("GraveYard:" + g);*/

            string s = "ownDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }
            Helpfunctions.Instance.logg(s);

            s = "enemyDiedMinions: ";
            foreach (GraveYardItem gyi in this.turngraveyard)
            {
                if (!gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }
            Helpfunctions.Instance.logg(s);


            s = "otg: ";
            foreach (GraveYardItem gyi in this.turngraveyardAll)
            {
                if (gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }
            Helpfunctions.Instance.logg(s);

            s = "etg: ";
            foreach (GraveYardItem gyi in this.turngraveyardAll)
            {
                if (!gyi.own) s += gyi.cardid + "," + gyi.entity + ";";
            }
            Helpfunctions.Instance.logg(s);
        }

        public void setGraveYard(List<GraveYardItem> list, bool turnStart)
        {
            graveyard.Clear();
            graveyard.AddRange(list);
            if (turnStart)
            {
                this.graveyartTillTurnStart.Clear();
                this.graveyartTillTurnStart.AddRange(list);
            }

            this.stalaggDead = false;
            this.feugenDead = false;
            this.turngraveyard.Clear();
            this.turngraveyardAll.Clear();

            GraveYardItem OwnLastDiedMinion = new GraveYardItem(CardDB.cardIDEnum.None, -1, true);
            foreach (GraveYardItem ent in list)
            {
                if (ent.cardid == CardDB.cardIDEnum.FP1_015)
                {
                    this.feugenDead = true;
                }

                if (ent.cardid == CardDB.cardIDEnum.FP1_014)
                {
                    this.stalaggDead = true;
                }

                bool found = false;

                foreach (GraveYardItem gyi in this.graveyartTillTurnStart)
                {
                    if (ent.entity == gyi.entity)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (CardDB.Instance.getCardDataFromID(ent.cardid).type == CardDB.cardtype.MOB)
                    {
                        this.turngraveyard.Add(ent);
                    }
                    this.turngraveyardAll.Add(ent);
                }
                if (ent.own && CardDB.Instance.getCardDataFromID(ent.cardid).type == CardDB.cardtype.MOB)
                {
                    OwnLastDiedMinion = ent;
                }
            }
            Hrtprozis.Instance.updateOwnLastDiedMinion(OwnLastDiedMinion.cardid);
        }

        public void setTurnGraveYard(List<GraveYardItem> listMobs, List<GraveYardItem> listAll)
        {
            this.turngraveyard.Clear();
            this.turngraveyardAll.Clear();
            this.turngraveyard.AddRange(listMobs);
            this.turngraveyardAll.AddRange(listAll);
        }

        public bool hasEnemyThisCardInDeck(CardDB.cardIDEnum cardid)
        {
            if (this.enemyCardsOut.ContainsKey(cardid))
            {
                if (this.enemyCardsOut[cardid] == 1)
                {

                    return true;
                }
                return false;
            }
            return true;
        }

        public int anzCardsInDeck(CardDB.cardIDEnum cardid)
        {
            int ret = 2;
            CardDB.Card c = CardDB.Instance.getCardDataFromID(cardid);
            if (c.rarity == 5) ret = 1;//you can have only one rare;

            if (this.enemyCardsOut.ContainsKey(cardid))
            {
                if (this.enemyCardsOut[cardid] == 1)
                {

                    return 1;
                }
                return 0;
            }
            return ret;

        }

        public void printGraveyards()
        {
            string og = "og: ";
            foreach (KeyValuePair<CardDB.cardIDEnum, int> e in this.ownCardsOut)
            {
                og += e.Key + "," + e.Value + ";";
            }
            string eg = "eg: ";
            foreach (KeyValuePair<CardDB.cardIDEnum, int> e in this.enemyCardsOut)
            {
                eg += e.Key + "," + e.Value + ";";
            }
            Helpfunctions.Instance.logg(og);
            Helpfunctions.Instance.logg(eg);
        }

        public int getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum cardid, int handsize, int decksize)
        {
            //calculates probability \in [0,...,100]


            int cardsremaining = this.anzCardsInDeck(cardid);
            if (cardsremaining == 0) return 0;
            double retval = 0.0;
            //http://de.wikipedia.org/wiki/Hypergeometrische_Verteilung (we calculte 1-p(x=0))

            if (cardsremaining == 1)
            {
                retval = 1.0 - ((double)(decksize)) / ((double)(decksize + handsize));
            }
            else
            {
                retval = 1.0 - ((double)(decksize * (decksize - 1))) / ((double)((decksize + handsize) * (decksize + handsize - 1)));
            }

            retval = Math.Min(retval, 1.0);

            return (int)(100.0 * retval);
        }

        public bool hasCardinGraveyard(CardDB.cardIDEnum cardid)
        {
            foreach (GraveYardItem gyi in this.graveyard)
            {
                if (gyi.cardid == cardid) return true;
            }
            return false;
        }

        public void setEnemySecretGuesses(Dictionary<int, TAG_CLASS> enemySecretList)
        {
            List<SecretItem> newlist = new List<SecretItem>();

            foreach (KeyValuePair<int, TAG_CLASS> eSec in enemySecretList)
            {
                if (eSec.Key >= 1000) continue;
                Helpfunctions.Instance.logg("detect secret with id" + eSec.Key);
                SecretItem sec = getNewSecretGuessedItem(eSec.Key, eSec.Value);

                newlist.Add(new SecretItem(sec));
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(newlist);
        }

        public SecretItem getNewSecretGuessedItem(int entityid, TAG_CLASS SecClass)
        {
            foreach (SecretItem si in this.enemySecrets)
            {
                if (si.entityId == entityid && entityid < 1000) return si;
            }

            switch (SecClass)
            {
                case TAG_CLASS.WARRIOR: break;
                case TAG_CLASS.WARLOCK: break;
                case TAG_CLASS.ROGUE: break;
                case TAG_CLASS.SHAMAN: break;
                case TAG_CLASS.PRIEST: break;
                case TAG_CLASS.PALADIN: break;
                case TAG_CLASS.MAGE: break;
                case TAG_CLASS.HUNTER: break;
                case TAG_CLASS.DRUID: break;
                default:
                    Helpfunctions.Instance.ErrorLog("Problem is detected: undefined Secret class " + SecClass);
                    SecClass = Hrtprozis.Instance.heroEnumtoTagClass(Hrtprozis.Instance.enemyHeroname);
                    Helpfunctions.Instance.ErrorLog("attempt to restore... " + SecClass);
                    break;
            }


            SecretItem sec = new SecretItem { entityId = entityid };
            if (SecClass == TAG_CLASS.HUNTER)
            {

                sec.canBe_counterspell = false;
                sec.canBe_icebarrier = false;
                sec.canBe_iceblock = false;
                sec.canBe_mirrorentity = false;
                sec.canBe_spellbender = false;
                sec.canBe_vaporize = false;
                sec.canBe_duplicate = false;
                sec.canBe_effigy = false;

                sec.canBe_eyeforaneye = false;
                sec.canBe_noblesacrifice = false;
                sec.canBe_redemption = false;
                sec.canBe_repentance = false;
                sec.canBe_avenge = false;
                sec.canBe_sacredtrial = false;

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_554) && enemyCardsOut[CardDB.cardIDEnum.EX1_554] >= 2)
                {
                    sec.canBe_snaketrap = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_609) && enemyCardsOut[CardDB.cardIDEnum.EX1_609] >= 2)
                {
                    sec.canBe_snipe = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_610) && enemyCardsOut[CardDB.cardIDEnum.EX1_610] >= 2)
                {
                    sec.canBe_explosive = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.AT_060) && enemyCardsOut[CardDB.cardIDEnum.AT_060] >= 2)
                {
                    sec.canBe_beartrap = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_611) && enemyCardsOut[CardDB.cardIDEnum.EX1_611] >= 2)
                {
                    sec.canBe_freezing = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_533) && enemyCardsOut[CardDB.cardIDEnum.EX1_533] >= 2)
                {
                    sec.canBe_missdirection = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.LOE_021) && enemyCardsOut[CardDB.cardIDEnum.LOE_021] >= 2)
                {
                    sec.canBe_darttrap = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.KAR_004) && enemyCardsOut[CardDB.cardIDEnum.KAR_004] >= 2)
                {
                    sec.canBe_cattrick = false;
                }

            }

            if (SecClass == TAG_CLASS.MAGE)
            {
                sec.canBe_snaketrap = false;
                sec.canBe_snipe = false;
                sec.canBe_explosive = false;
                sec.canBe_beartrap = false;
                sec.canBe_freezing = false;
                sec.canBe_missdirection = false;
                sec.canBe_darttrap = false;
                sec.canBe_cattrick = false;

                sec.canBe_eyeforaneye = false;
                sec.canBe_noblesacrifice = false;
                sec.canBe_redemption = false;
                sec.canBe_repentance = false;
                sec.canBe_avenge = false;
                sec.canBe_sacredtrial = false;

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_287) && enemyCardsOut[CardDB.cardIDEnum.EX1_287] >= 2)
                {
                    sec.canBe_counterspell = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_289) && enemyCardsOut[CardDB.cardIDEnum.EX1_289] >= 2)
                {
                    sec.canBe_icebarrier = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_295) && enemyCardsOut[CardDB.cardIDEnum.EX1_295] >= 2)
                {
                    sec.canBe_iceblock = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_294) && enemyCardsOut[CardDB.cardIDEnum.EX1_294] >= 2)
                {
                    sec.canBe_mirrorentity = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.tt_010) && enemyCardsOut[CardDB.cardIDEnum.tt_010] >= 2)
                {
                    sec.canBe_spellbender = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_594) && enemyCardsOut[CardDB.cardIDEnum.EX1_594] >= 2)
                {
                    sec.canBe_vaporize = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.FP1_018) && enemyCardsOut[CardDB.cardIDEnum.FP1_018] >= 2)
                {
                    sec.canBe_duplicate = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.AT_002) && enemyCardsOut[CardDB.cardIDEnum.AT_002] >= 2)
                {
                    sec.canBe_effigy = false;
                }
            }

            if (SecClass == TAG_CLASS.PALADIN)
            {
                sec.canBe_snaketrap = false;
                sec.canBe_snipe = false;
                sec.canBe_explosive = false;
                sec.canBe_beartrap = false;
                sec.canBe_freezing = false;
                sec.canBe_missdirection = false;
                sec.canBe_darttrap = false;
                sec.canBe_cattrick = false;

                sec.canBe_counterspell = false;
                sec.canBe_icebarrier = false;
                sec.canBe_iceblock = false;
                sec.canBe_mirrorentity = false;
                sec.canBe_spellbender = false;
                sec.canBe_vaporize = false;
                sec.canBe_duplicate = false;
                sec.canBe_effigy = false;

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_132) && enemyCardsOut[CardDB.cardIDEnum.EX1_132] >= 2)
                {
                    sec.canBe_eyeforaneye = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_130) && enemyCardsOut[CardDB.cardIDEnum.EX1_130] >= 2)
                {
                    sec.canBe_noblesacrifice = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_136) && enemyCardsOut[CardDB.cardIDEnum.EX1_136] >= 2)
                {
                    sec.canBe_redemption = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.EX1_379) && enemyCardsOut[CardDB.cardIDEnum.EX1_379] >= 2)
                {
                    sec.canBe_repentance = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.FP1_020) && enemyCardsOut[CardDB.cardIDEnum.FP1_020] >= 2)
                {
                    sec.canBe_avenge = false;
                }

                if (enemyCardsOut.ContainsKey(CardDB.cardIDEnum.LOE_027) && enemyCardsOut[CardDB.cardIDEnum.LOE_027] >= 2)
                {
                    sec.canBe_sacredtrial = false;
                }
            }

            return sec;
        }


        public bool isAllowedSecret(CardDB.cardIDEnum cardID)
        {
            if (ownCardsOut.ContainsKey(cardID) && ownCardsOut[cardID] >= 2) return false;
            return true;
        }


        public string getEnemySecretData()
        {
            string retval = "";
            foreach (SecretItem si in this.enemySecrets)
            {

                retval += si.returnAString();
            }

            return retval;
        }

        public string getEnemySecretData(List<SecretItem> list)
        {
            string retval = "";
            foreach (SecretItem si in list)
            {

                retval += si.returnAString();
            }

            return retval;
        }


        public void setEnemySecretData(List<SecretItem> enemySecretl)
        {
            this.enemySecrets.Clear();
            foreach (SecretItem si in enemySecretl)
            {
                this.enemySecrets.Add(new SecretItem(si));
            }
        }

        public void updateSecretList(List<SecretItem> enemySecretl)
        {
            List<SecretItem> temp = new List<SecretItem>();
            foreach (SecretItem si in this.enemySecrets)
            {
                bool add = false;
                SecretItem seit = null;
                foreach (SecretItem sit in enemySecretl) // enemySecrets have to be updated to latest entitys
                {
                    if (si.entityId == sit.entityId)
                    {
                        seit = sit;
                        add = true;
                    }
                }

                temp.Add(add ? new SecretItem(seit) : new SecretItem(si));
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(temp);

        }


        public void updateSecretList(Playfield p, Playfield old)
        {
            if (p.enemySecretCount == 0 || p.optionsPlayedThisTurn == 0) return;
            Action doneMove = Ai.Instance.bestmove;
            if (doneMove == null) return;

            List<CardDB.cardIDEnum> enemySecretsOpenedStep = new List<CardDB.cardIDEnum>();
            List<CardDB.Card> enemyMinionsDiedStep = new List<CardDB.Card>();
            foreach (KeyValuePair<CardDB.cardIDEnum, int> tmp in p.enemyCardsOut)
            {
                if (!old.enemyCardsOut.ContainsKey(tmp.Key) || old.enemyCardsOut[tmp.Key] != tmp.Value)
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(tmp.Key);
                    if (c.Secret) enemySecretsOpenedStep.Add(tmp.Key);
                    else if (c.type == CardDB.cardtype.MOB) enemyMinionsDiedStep.Add(c);
                }
            }

            bool beartrap = false;
            bool explosive = false;
            bool snaketrap = false;
            bool missdirection = false;
            bool freezing = false;
            bool snipe = false;
            bool darttrap = false;
            bool cattrick = false;

            bool mirrorentity = false;
            bool counterspell = false;
            bool spellbender = false;
            bool iceblock = false;
            bool icebarrier = false;
            bool vaporize = false;
            bool duplicate = false;
            bool effigy = false;

            bool eyeforaneye = false;
            bool noblesacrifice = false;
            bool redemption = false;
            bool repentance = false;
            bool avenge = false;
            bool sacredtrial = false;

            if (enemyMinionsDiedStep.Count > 0)
            {
                duplicate = true;
                
                if (old.enemyMinions.Count > 1) avenge = true;
                if (old.enemyMinions.Count < 7)
                {
                    effigy = true;
                    redemption = true;
                }
                else if (!enemyMinionsDiedStep[0].deathrattle) { redemption = true; effigy = true; }
                else
                {
                    switch (enemyMinionsDiedStep[0].cardIDenum)
                    {
                        case CardDB.cardIDEnum.AT_019: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.AT_036: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.BRMC_87: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.EX1_110: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.EX1_534: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.EX1_556: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.FP1_002: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.FP1_007: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.FP1_012: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.GVG_096: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.GVG_105: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.GVG_114: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.LOE_050: redemption = false; effigy = false; break;
                        case CardDB.cardIDEnum.LOE_089: redemption = false; effigy = false; break;
                        default: redemption = true; effigy = true; break;
                    }
                }
            }


            bool targetWasHero = (doneMove.target != null && doneMove.target.entitiyID == p.enemyHero.entitiyID);

            if (doneMove.actionType == actionEnum.attackWithHero || doneMove.actionType == actionEnum.attackWithMinion)
            {
                bool attackerIsHero = doneMove.own.isHero;

                if (enemySecretsOpenedStep.Count == 0)
                {
                    if (old.enemyMinions.Count < 7) noblesacrifice = true;
                    if (doneMove.actionType == actionEnum.attackWithMinion) freezing = true;
                    if (targetWasHero)
                    {
                        explosive = true;
                        if (old.enemyMinions.Count < 7) beartrap = true;
                        missdirection = true;
                        if (attackerIsHero && old.ownMinions.Count == 0 && old.enemyMinions.Count == 0) missdirection = false;
                        icebarrier = true;
                        if (!attackerIsHero) vaporize = true;
                    }
                    else
                    {
                        snaketrap = true;
                    }
                }
                else
                {
                    if (targetWasHero)
                    {
                        explosive = true;
                        icebarrier = true;
                        if (!attackerIsHero) vaporize = true; //?
                    }
                    else snaketrap = true;
                    if (!attackerIsHero) freezing = true;
                    if (old.enemyMinions.Count < 7) noblesacrifice = true;

                    foreach (CardDB.cardIDEnum id in enemySecretsOpenedStep)
                    {
                        switch (id)
                        {
                            case CardDB.cardIDEnum.AT_060:  //beartrap
                                beartrap = true;
                                missdirection = true;
                                continue;
                            case CardDB.cardIDEnum.EX1_610:  //explosivetrap
                                if (enemySecretsOpenedStep.Count == 1)
                                {
                                    missdirection = true;
                                    if (!attackerIsHero && p.ownMinions.Find(x => x.entitiyID == doneMove.own.entitiyID) == null)
                                    {
                                        missdirection = false;
                                        freezing = false;
                                    }
                                }
                                continue;
                            case CardDB.cardIDEnum.EX1_533:  //misdirection
                                missdirection = true;
                                vaporize = false;
                                if (enemySecretsOpenedStep.Contains(CardDB.cardIDEnum.EX1_554)) continue;
                                int hpBalance = 0; //we need to know who has become the new target
                                foreach (Minion m in p.enemyMinions) hpBalance += m.Hp;
                                foreach (Minion m in old.enemyMinions) hpBalance -= m.Hp;
                                if (hpBalance < 0) snaketrap = true;
                                continue;
                            case CardDB.cardIDEnum.EX1_611:  //freezingtrap
                                freezing = true;
                                vaporize = false;
                                continue;
                            case CardDB.cardIDEnum.EX1_594:   //vaporize
                                vaporize = true;
                                freezing = false;
                                continue;
                            case CardDB.cardIDEnum.EX1_130:   //noblesacrifice
                                noblesacrifice = true;
                                snaketrap = true;
                                vaporize = false;
                                icebarrier = false;
                                continue;
                        }
                    }
                }
            }
            else if (doneMove.actionType == actionEnum.playcard)
            {
                if (doneMove.card.card.type == CardDB.cardtype.SPELL)
                {
                    cattrick = true;
                    counterspell = true;
                    if (!targetWasHero) spellbender = true;
                }
                /* else if (doneMove.card.card.type == CardDB.cardtype.MOB) //we need the response from the core
                 {
                     mirrorentity = true;
                     snipe = true;
                     repentance = true;
                     if (p.ownMinions.Count > 3) sacredtrial = true;
                 }*/
            }
            if (p.mobsplayedThisTurn > old.mobsplayedThisTurn) //if we have a response from the core - remove
            {
                mirrorentity = true;
                snipe = true;
                repentance = true;
                if (p.ownMinions.Count > 3) sacredtrial = true;
            }

            if (p.enemyHero.Hp + p.enemyHero.armor < old.enemyHero.Hp + old.enemyHero.armor) eyeforaneye = true;
            if (doneMove.actionType == actionEnum.useHeroPower) darttrap = true;

            foreach (CardDB.cardIDEnum id in enemySecretsOpenedStep)
            {
                switch (id)
                {
                    case CardDB.cardIDEnum.AT_002: effigy = true; continue;
                    case CardDB.cardIDEnum.AT_060: beartrap = true; continue;
                    case CardDB.cardIDEnum.EX1_130: noblesacrifice = true; continue;
                    case CardDB.cardIDEnum.EX1_132: eyeforaneye = true; continue;
                    case CardDB.cardIDEnum.EX1_136: redemption = true; continue;
                    case CardDB.cardIDEnum.EX1_287: counterspell = true; continue;
                    case CardDB.cardIDEnum.EX1_289: icebarrier = true; continue;
                    case CardDB.cardIDEnum.EX1_294: mirrorentity = true; continue;
                    case CardDB.cardIDEnum.EX1_295: iceblock = true; continue;
                    case CardDB.cardIDEnum.EX1_379: repentance = true; continue;
                    case CardDB.cardIDEnum.EX1_533: missdirection = true; continue;
                    case CardDB.cardIDEnum.EX1_554: snaketrap = true; continue;
                    case CardDB.cardIDEnum.EX1_594: vaporize = true; continue;
                    case CardDB.cardIDEnum.EX1_609: snipe = true; continue;
                    case CardDB.cardIDEnum.EX1_610: explosive = true; continue;
                    case CardDB.cardIDEnum.EX1_611: freezing = true; continue;
                    case CardDB.cardIDEnum.FP1_018: duplicate = true; continue;
                    case CardDB.cardIDEnum.FP1_020: avenge = true; continue;
                    case CardDB.cardIDEnum.LOE_021: darttrap = true; continue;
                    case CardDB.cardIDEnum.LOE_027: sacredtrial = true; continue;
                    case CardDB.cardIDEnum.tt_010: spellbender = true; continue;
                    case CardDB.cardIDEnum.KAR_004: cattrick = true; continue;
                }
            }

            foreach (SecretItem si in this.enemySecrets)
            {
                if (beartrap) si.canBe_beartrap = false;
                if (explosive) si.canBe_explosive = false;
                if (snaketrap) si.canBe_snaketrap = false;
                if (missdirection) si.canBe_missdirection = false;
                if (freezing) si.canBe_freezing = false;
                if (snipe) si.canBe_snipe = false;
                if (darttrap) si.canBe_darttrap = false;
                if (cattrick) si.canBe_cattrick = false;

                if (counterspell) si.canBe_counterspell = false;
                if (icebarrier) si.canBe_icebarrier = false;
                if (iceblock) si.canBe_iceblock = false;
                if (mirrorentity) si.canBe_mirrorentity = false;
                if (spellbender) si.canBe_spellbender = false;
                if (vaporize) si.canBe_vaporize = false;
                if (duplicate) si.canBe_duplicate = false;
                if (effigy) si.canBe_effigy = false;

                if (eyeforaneye) si.canBe_eyeforaneye = false;
                if (noblesacrifice) si.canBe_noblesacrifice = false;
                if (redemption) si.canBe_redemption = false;
                if (repentance) si.canBe_repentance = false;
                if (avenge) si.canBe_avenge = false;
                if (sacredtrial) si.canBe_sacredtrial = false;
            }
        }


    }

}