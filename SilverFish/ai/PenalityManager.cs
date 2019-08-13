using System.Security.Policy;

namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public sealed class PenalityManager
    {
        //todo acolyteofpain
        //todo better aoe-penality

        ComboBreaker cb;

        public Dictionary<CardDB.cardIDEnum, int> TargetAbilitysDatabase = new Dictionary<CardDB.cardIDEnum, int>();
        Dictionary<CardDB.cardName, int> HealTargetDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealHeroDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealAllDatabase = new Dictionary<CardDB.cardName, int>();


        Dictionary<CardDB.cardName, int> DamageAllDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageHeroDatabase = new Dictionary<CardDB.cardName, int>(); //not used
        Dictionary<CardDB.cardName, int> DamageRandomDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageAllEnemysDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> enrageDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> silenceDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> heroAttackBuffDatabase = new Dictionary<CardDB.cardName, int>(); //not used
        Dictionary<CardDB.cardName, int> attackBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> healthBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> tauntBuffDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> lethalHelpers = new Dictionary<CardDB.cardName, int>();


        Dictionary<CardDB.cardName, int> backToHandDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> cardDiscardDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyOwnDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> buffingMinionsDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> buffing1TurnDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> randomEffects = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> silenceTargets = new Dictionary<CardDB.cardName, int>();

        public Dictionary<CardDB.cardName, int> priorityDatabase = new Dictionary<CardDB.cardName, int>(); //minions we want to keep around

        public Dictionary<CardDB.cardName, int> DamageTargetDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> DamageTargetSpecialDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> cardDrawBattleCryDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> cardDrawDeathrattleDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> priorityTargets = new Dictionary<CardDB.cardName, int>(); //enemy minions we want to kill
        public Dictionary<CardDB.cardName, int> specialMinions = new Dictionary<CardDB.cardName, int>(); //minions with cardtext, but no battlecry

        private Dictionary<CardDB.cardName, int> discoverCards = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> strongInspireEffectMinions = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> summonMinionSpellsDatabase = new Dictionary<CardDB.cardName, int>(); // spells/hero powers that summon minions immediately
        Dictionary<CardDB.cardName, int> alsoEquipsWeaponDB = new Dictionary<CardDB.cardName, int>(); //cards that aren't weapons but equip one immediately


        private static PenalityManager instance;

        public static PenalityManager Instance
        {
            get
            {
                return instance ?? (instance = new PenalityManager());
            }
        }

        private PenalityManager()
        {
            setupHealDatabase();
            setupEnrageDatabase();
            setupDamageDatabase();
            setupPriorityList();
            setupsilenceDatabase();
            setupAttackBuff();
            setupHealthBuff();

            setupDiscover();
            setupCardDrawBattlecry();

            setupDiscardCards();
            setupDestroyOwnCards();
            setupSpecialMins();
            setupEnemyTargetPriority();
            setupBuffingMinions();
            setupRandomCards();
            setupLethalHelpMinions();
            setupSilenceTargets();
            setupTargetAbilitys();
            setupStrongInspireMinions();
            setupSummonMinionSpellsDatabase();
            setupAlsoEquipsWeaponDB();
        }

        public void setCombos()
        {
            this.cb = ComboBreaker.Instance;
        }

        public int getAttackWithMininonPenality(Minion m, Playfield p, Minion target, bool lethal)
        {
            int pen = 0;
            pen = getAttackSecretPenality(m, p, target);
            if (!lethal && target.entityID == p.enemyHero.entityID && m.destroyOnOwnTurnEnd) pen += 50;
            if (!lethal && m.name == CardDB.cardName.bloodimp) pen += 50;
            if (m.name == CardDB.cardName.leeroyjenkins)
            {
                if (!target.own)
                {
                    if (target.name == CardDB.cardName.whelp) return 500;
                }

            }

            bool rockbiterMinion = p.playactions.Find(a => a.actionType == actionEnum.playcard && a.card.card.name == CardDB.cardName.rockbiterweapon && a.target.entityID == m.entityID) != null;
            if (!lethal && target.isHero && !target.own && rockbiterMinion)
            {
                pen += 50;
            }
            if (!target.isHero && !target.own && rockbiterMinion) pen += -5; //to counter hero not waste rockbiter bonus

            if (!m.silenced && (m.name == CardDB.cardName.acolyteofpain || ((m.name == CardDB.cardName.loothoarder || m.name == CardDB.cardName.bloodmagethalnos) && !target.isHero && target.Angr >= m.Hp)))
            {
                pen += p.playactions.Count;  // penalize not utilizing the card draw as early as possible
            }

            bool freezingtrap = false;
            foreach (CardDB.cardIDEnum secretID in p.ownSecretsIDList)
            {
                if (secretID == CardDB.cardIDEnum.EX1_611) //freezing trap
                {
                    freezingtrap = true;
                }
            }

            // todo sepefeets - consider divine shield, killing off small minions, etc.
            if (freezingtrap && target.taunt) //don't kill off our own minions for no reason
            {
                int totalAngr = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    totalAngr += mnn.Angr;
                }
                if (totalAngr < target.Hp) return 500;
            }
            //Avoid wasting attacks into doomsayer
            /*// must lower HP with spells prior
            if (target.name == CardDB.cardName.doomsayer && !m.poisonous)
            {
                int totalAngr = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Ready) totalAngr += mnn.Angr;
                }
                if (p.ownWeaponAttack >= 1) totalAngr += p.ownWeaponAttack;
                if (p.ownHero.tempAttack >= 1) totalAngr += p.ownHero.tempAttack;
                if (totalAngr < target.Hp) return 500;
            }*/
            
            return pen;
        }


        int enfacehp = -142;
        
        public int getAttackWithHeroPenality(Minion target, Playfield p, bool lethal)
        {
            if (enfacehp == -142) enfacehp = Settings.Instance.enfacehp;
            int retval = 0;
            bool rockbiterHero = p.playactions.Find(a => a.actionType == actionEnum.playcard && a.card.card.name == CardDB.cardName.rockbiterweapon && a.target.entityID == p.ownHero.entityID) != null;

            if (p.ownWeaponName == CardDB.cardName.atiesh) return 500;

            if (!lethal && p.ownWeaponName == CardDB.cardName.swordofjustice)
            {
                return 28;
            }

            if (!lethal && target.entityID == p.enemyHero.entityID)
            {
                if (p.ownWeaponAttack >= 1 && p.enemyHero.Hp >= enfacehp)
                {
                    if (p.ownWeaponName == CardDB.cardName.lightsjustice && p.ownWeaponDurability >= 3) return -1;
                    if (!(p.ownHeroName == HeroEnum.thief && p.ownWeaponAttack == 1)) return 50 + p.ownWeaponAttack;
                }

                if (p.ownHero.tempAttack > 0 && !p.ownHero.windfury && rockbiterHero)
                {
                    return 50;
                }
            }

            if (p.ownWeaponDurability == 1 && p.ownWeaponName == CardDB.cardName.eaglehornbow)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.arcaneshot || hc.card.name == CardDB.cardName.killcommand) return -p.ownWeaponAttack - 1;
                }
                if (p.ownSecretsIDList.Count >= 1) return 20;

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.Secret) return 20;
                }
            }

            if (p.ownWeaponName == CardDB.cardName.doomhammer)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.rockbiterweapon && hc.canplayCard(p)) return 10;
                }
                if (!target.isHero && target.Hp <= p.ownWeaponAttack && p.ownHero.tempAttack > 0) return 20;
                if (target.isHero && !target.own && rockbiterHero) return -5; //bonus to not waste rockbiter
            }

            if (target.isHero && !target.own && p.ownWeaponName == CardDB.cardName.gorehowl && p.ownWeaponAttack >= 3)
            {
                return 10;
            }

            if (p.ownWeaponName == CardDB.cardName.spiritclaws)
            {
                if (p.ownWeaponAttack == 1)
                {
                    if (target.isHero && !target.own && !lethal) return 500;
                    if (target.Hp > p.ownHero.Angr && target.divineshild == false) return 10;
                }
            }

            //no penalty, but a bonus, if he has weapon on hand!
            if (p.ownWeaponDurability >= 1)
            {
                bool hasweapon = false;
                foreach (Handmanager.Handcard c in p.owncards)
                {
                    if (c.card.type == CardDB.cardtype.WEAPON || alsoEquipsWeaponDB.ContainsKey(c.card.name)) hasweapon = true;
                }
                if (p.ownWeaponAttack == 1 && p.ownHeroName == HeroEnum.thief) hasweapon = true;
                if (hasweapon && target.name != CardDB.cardName.doomsayer) retval = -p.ownWeaponAttack - 1; // so he doesnt "lose" the weapon in evaluation :D
            }
            if (p.ownWeaponAttack == 1 && p.ownHeroName == HeroEnum.thief) retval += -1;
            if (p.ownHero.tempAttack > 0) retval += -5; //bonus to not waste rockbiter

            //Avoid wasting durability into doomsayer
            // must lower HP with spells prior
            /*if (target.name == CardDB.cardName.doomsayer)
            {
                int totalAngr = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Ready) totalAngr += mnn.Angr;
                }
                if (p.ownWeaponAttack >= 1) totalAngr += p.ownWeaponAttack;
                if (p.ownHero.tempAttack >= 1) totalAngr += p.ownHero.tempAttack;
                if (totalAngr < target.Hp) return 500;
            }*/
            return retval;
        }

        // penalize overwriting current weapon for worse ones
        public int getEquipWeaponPenalty(CardDB.Card card, Playfield p, bool lethal)
        {
            if (p.ownWeaponDurability == 0)
            {
                if (card.name == CardDB.cardName.spiritclaws) return -3;
                return 0;
            }
            if (card.type != CardDB.cardtype.WEAPON && !alsoEquipsWeaponDB.ContainsKey(card.name)) return 0;
            /*
            if (card.type == CardDB.cardtype.WEAPON && card.Attack < p.ownWeaponAttack)
            {
                return 25 * ((p.ownWeaponAttack * p.ownWeaponDurability) - (2 * card.Attack)); //I think this case is already handled elsewhere
            }*/
            if (p.ownWeaponDurability != 0 && alsoEquipsWeaponDB.ContainsKey(card.name) && alsoEquipsWeaponDB[card.name] < p.ownWeaponAttack)
            {
                if (card.name != CardDB.cardName.upgrade) return 25 * ((p.ownWeaponAttack * p.ownWeaponDurability) - (2 * alsoEquipsWeaponDB[card.name]));
            }
            if (card.name == CardDB.cardName.spiritclaws && p.ownWeaponName == CardDB.cardName.spiritclaws) return 500;
            if (card.name == CardDB.cardName.jadeclaws) return 25; //to counter the value a jade golems a bit

            if (card.type == CardDB.cardtype.WEAPON && card.Attack <= p.ownWeaponAttack)
            {
                return Math.Max(10 + p.ownWeaponAttack * p.ownWeaponDurability - card.Attack * card.Durability, 0); //small penalty for replacing similar attack for more charges
            }
            return 0;
        }

        public int getPlayCardPenality(Handmanager.Handcard hcard, Minion target, Playfield p, int choice, bool lethal)
        {
            int retval = 0;
            CardDB.Card card = hcard.card;
            CardDB.cardName name = card.name;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(hcard, target, p, choice, lethal);
            int tbuff = getTauntBuffPenality(hcard, target, p, choice);
            if (name == CardDB.cardName.markofthewild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
            {
                retval = 0;
            }
            else
            {
                retval += abuff + tbuff;
            }
            retval += getHPBuffPenality(card, target, p, choice);
            retval += getSilencePenality(name, target, p, choice, lethal);
            retval += getDamagePenality(name, target, p, choice, lethal);
            retval += getHealPenality(name, target, p, choice, lethal);

            retval += getCardDrawPenality(name, target, p, choice, lethal);
            retval += getCardDrawofEffectMinions(card, p);
            retval += getCardDiscardPenality(name, p);
            retval += getDestroyOwnPenality(name, target, p, lethal);

            retval += getDestroyPenality(name, target, p, lethal);
            retval += getbackToHandPenality(name, target, p, lethal);
            retval += getSpecialCardComboPenalties(hcard, target, p, lethal, choice);
            //if (lethal) Console.WriteLine(retval+ " " + name);
            retval += getRandomPenalty(card, p, target);
            retval += getEquipWeaponPenalty(card, p, lethal);

            if (!lethal)
            {
                retval += cb.getPenalityForDestroyingCombo(card, p);
                retval += cb.getPlayValue(card.cardIDenum);
                retval += getPlayInspirePenalty(hcard, p);
                retval += getPlayMobPenalty(hcard, target, p, lethal);
                if (card.name == p.ownHeroAblility.card.name) retval += getHeroPowerPenality(hcard, target, p);
            }

            retval += getPlaySecretPenalty(card, p);
            retval += getPlayCardSecretPenality(card, p);

            retval += getPlayPenalty(name, p, choice);
            retval += (int)card.pen_card.getPlayPenalty(p, hcard, target, choice, lethal);
            //Helpfunctions.Instance.ErrorLog("retval " + retval);
            return retval;
        }

        private int getAttackBuffPenality(Handmanager.Handcard playhc, Minion target, Playfield p, int choice, bool lethal)
        {
            CardDB.Card card = playhc.card;
            CardDB.cardName name = card.name;
            if (name == CardDB.cardName.darkwispers && choice != 1) return 0;

            if (!lethal && (card.name == CardDB.cardName.bolster))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.taunt) targets++;
                }
                if (targets < 2)
                {
                    return 10;
                }
            }

            if (!lethal && (card.name == CardDB.cardName.savageroar || card.name == CardDB.cardName.bloodlust))
            {
                int pen = 0;
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }

                if ((p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) && card.name == CardDB.cardName.savageroar) targets++;

                if (targets <= 3)
                {
                    pen += 20;
                }
                return pen + (5 - p.enemyMinions.Count) * 10;
            }

            if (!this.attackBuffDatabase.ContainsKey(name)) return 0;
            if (target == null)
            {
                //if ((p.ownMaxMana <= 2 && (p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.hunter)))
                //    return 10;
                if (card.type == CardDB.cardtype.MOB)
                {
                    if (card.name == CardDB.cardName.metaltoothleaper && p.ownMinions.Find(mech => mech.handcard.card.race == TAG_RACE.MECHANICAL) != null) return 0;
                    return 4 * attackBuffDatabase[name];
                }

                return 60;
            }

            if (target.own && name == CardDB.cardName.rockbiterweapon)
            {
                if (p.playactions.Find(a => a.actionType == actionEnum.attackWithMinion && a.own.windfury) != null) return 500;
                if (target.isHero)
                {
                    if (p.playactions.Find(a => a.actionType == actionEnum.attackWithHero) != null) return 500;
                    if (!target.windfury && (p.ownMinions.Find(m => m.windfury) != null || p.owncards.Find(c => c.card.windfury && c.card.Charge) != null)) return 30;
                }
                else
                {
                    if (!target.Ready) return 500;
                    if (p.ownHero.windfury) return 30;
                }
                return (target.windfury) ? 10 : 15;
            }

            if (!target.isHero && !target.own)
            {
                if (card.type == CardDB.cardtype.MOB && p.ownMinions.Count == 0) return 0;
                //allow it if you have biggamehunter
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.biggamehunter && target.Angr <= 6 && p.mana >= (hc.getManaCost(p) + playhc.getManaCost(p))) return 5;
                    if (hc.card.name == CardDB.cardName.shadowworddeath && target.Angr <= 4 && p.mana >= (hc.getManaCost(p) + playhc.getManaCost(p))) return 5;
                }
                if (card.name == CardDB.cardName.crueltaskmaster || card.name == CardDB.cardName.innerrage)
                {
                    Minion m = target;

                    if (m.Hp == 1)
                    {
                        return 0;
                    }

                    if (!m.wounded && (m.Angr >= 4 || m.Hp >= 5))
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute && p.mana >= (hc.getManaCost(p) + playhc.getManaCost(p))) return 0;
                        }
                    }

                    return 30;
                }
                else
                {
                    return 500;
                }
            }

            if (!target.isHero && target.own)
            {
                Minion m = target;
                bool hasownready = false;

                //vs mage or hunter we need board presence at early game? so we skip the minion ready-check.
                // for everyone else, we penalize buffing minions when they are not ready

                if (p.ownMaxMana > 1)// || (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.hunter))
                {
                    if (card.name == CardDB.cardName.clockworkknight || card.name == CardDB.cardName.screwjankclunker)
                    {
                        // hasownready can only apply to mechs
                        hasownready = p.ownMinions.Find(mnn => mnn.handcard.card.race == TAG_RACE.MECHANICAL && mnn.Ready) != null;
                    }
                    else
                    {
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.Ready)
                            {
                                hasownready = true;
                                break;
                            }
                        }
                        if (p.playactions.Find(a => a.actionType == actionEnum.attackWithMinion) != null) hasownready = true; //we HAD something ready but already attacked with it so penalize it still
                    }
                }

                if (this.buffing1TurnDatabase.ContainsKey(name))
                {
                    if (m.Ready)
                    {
                        if (this.priorityDatabase.ContainsKey(m.name)) return 5 + priorityDatabase[m.name];
                        return m.taunt ? 5 : 0;
                    }
                    else
                    {
                        return (hasownready) ? 50 : 5;
                    }
                }
                if (!m.Ready)
                {
                    if (!m.taunt && hasownready) return 5 * attackBuffDatabase[name];
                    else return attackBuffDatabase[name];
                }
                
                if (m.Hp == 1 && !m.divineshild && !this.buffing1TurnDatabase.ContainsKey(name))
                {
                    if (this.healthBuffDatabase.ContainsKey(name)) return 0;  // m.Hp no longer == 1
                    if (card.type == CardDB.cardtype.MOB) return 2 * attackBuffDatabase[name] + 1;  // only 1pt worse than playing vanilla minion with same stats and no atk buff

                    return 10;
                }
                if (card.name == CardDB.cardName.blessingofmight) return 6;
            }

            return 0;
        }

        private int getHPBuffPenality(CardDB.Card card, Minion target, Playfield p, int choice)
        {
            CardDB.cardName name = card.name;
            if (name == CardDB.cardName.darkwispers && choice != 1) return 0;
            //buff enemy?
            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
             if (target == null)
            {
                // penalize for lost buff
                if (card.type == CardDB.cardtype.MOB) return healthBuffDatabase[name];
            }

            if (target!=null && !target.own && !this.tauntBuffDatabase.ContainsKey(name))
            {
                return 500;
            }

            return 0;
        }


        private int getTauntBuffPenality(Handmanager.Handcard hcard, Minion target, Playfield p, int choice)
        {
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(hcard.card.name)) return 0;
            if (hcard.card.name == CardDB.cardName.markofnature && choice != 2) return 0;
            if (hcard.card.name == CardDB.cardName.darkwispers && choice != 1) return 0;
            if (target == null) return 20;
            if (!target.isHero && !target.own)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.theblackknight && (p.mana >= hcard.getManaCost(p) + hc.getManaCost(p))) return 0;
                }

                // allow taunting if target is priority and others have taunt
                bool enemyhasTaunts = false;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt)
                    {
                        enemyhasTaunts = true;
                        break;
                    }
                }
                if (enemyhasTaunts && this.priorityDatabase.ContainsKey(target.name) && !target.silenced && !target.taunt)
                {
                    return 0;
                }

                pen = 500;
            }

            return pen;
        }

        private int getSilencePenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            int pen = 0;
            if (name == CardDB.cardName.keeperofthegrove && choice != 2) return 0; // look at damage penality in this case

            if (target == null)
            {
                if (name == CardDB.cardName.ironbeakowl || name == CardDB.cardName.spellbreaker)
                {

                    return 40;
                }
                return 0;
            }

            if (target.own)
            {

                

                if (this.silenceDatabase.ContainsKey(name))
                {
                    if ((!target.silenced && (target.name == CardDB.cardName.wrathguard || target.name == CardDB.cardName.darnassusaspirant || target.name == CardDB.cardName.icehowl || target.name == CardDB.cardName.venturecomercenary)))
                    {
                        return 0;
                    }

                    // no pen if own is enrage
                    if ((!target.silenced && (target.name == CardDB.cardName.darnassusaspirant || target.name == CardDB.cardName.ancientwatcher || target.name == CardDB.cardName.ragnarosthefirelord || target.name == CardDB.cardName.mogortheogre || target.name == CardDB.cardName.animagolem)) || target.Angr < target.handcard.card.Attack || target.maxHp < target.handcard.card.Health || (target.frozen && !target.playedThisTurn && target.numAttacksThisTurn == 0))
                    {
                        return 0;
                    }


                    pen += 500;
                }
                
            }



            if (!target.own)
            {
                if (this.silenceDatabase.ContainsKey(name))
                {
                    // no pen if own is enrage
                    Minion m = target;//

                    if (!m.silenced && (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord))
                    {
                        return 500;
                    }

                    if ((!target.silenced && (target.name == CardDB.cardName.wrathguard || target.name == CardDB.cardName.darnassusaspirant || target.name == CardDB.cardName.icehowl)))
                    {
                        return 100;
                    }

                    if (lethal)
                    {
                        //during lethal we only silence taunt, or if its a mob (owl/spellbreaker) + we can give him charge
                        if (m.taunt || (name == CardDB.cardName.ironbeakowl && (p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) || (name == CardDB.cardName.spellbreaker && p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) return 0; // || p.ownMinions.Find(x => x.name == CardDB.cardName.warsongcommander) != null

                        return 500;
                    }

                    if (m.handcard.card.name == CardDB.cardName.dancingswords && !m.silenced)
                    {
                        return 50;
                    }

                    if (m.handcard.card.name == CardDB.cardName.venturecomercenary && !m.silenced && (m.Angr <= m.handcard.card.Attack && m.maxHp <= m.handcard.card.Health))
                    {
                        return 30;
                    }

                    if (m.handcard.card.name == CardDB.cardName.quartermaster && (p.enemyHeroAblility.card.cardIDenum != CardDB.cardIDEnum.AT_132_PALADIN && p.enemyHeroAblility.card.cardIDenum != CardDB.cardIDEnum.CS2_101))
                    {
                        return 30;
                    }

                    if (priorityDatabase.ContainsKey(m.name) && !m.silenced)
                    {
                        return 0;
                    }

                    if (this.silenceTargets.ContainsKey(m.name) && !m.silenced)
                    {
                        return 0;
                    }

                    if (m.handcard.card.deathrattle && !m.silenced)
                    {
                        return 0;
                    }

                    //silence nothing
                    //todo add "new" enchantments (good or bad ones)
                    if (m.Angr <= m.handcard.card.Attack && m.maxHp <= m.handcard.card.Health && !m.taunt && !m.windfury && !m.divineshild && !m.poisonous && !this.specialMinions.ContainsKey(name))
                    {
                        if (name == CardDB.cardName.keeperofthegrove) return 500;
                        return 30;
                    }



                    return 5;
                }
            }

            return pen;

        }

        private int getDamagePenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            int pen = 0;

            if (name == CardDB.cardName.shieldslam && p.ownHero.armor == 0) return 500;
            if (name == CardDB.cardName.savagery && p.ownHero.Angr == 0) return 500;
            if (name == CardDB.cardName.keeperofthegrove && choice != 1) return 0; // look at silence penality
            if (name == CardDB.cardName.livingroots && choice != 1) return 0; // look at silence penality
            if (name == CardDB.cardName.swipe && !target.own) return -p.enemyMinions.Count * 7; // treat it as single target spell with bonus for aoe

            if (this.DamageAllDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealAllDatabase.ContainsKey(name))) // aoe penality
            {

                if (p.enemyMinions.Count == 0) return 300;

                foreach (Minion m in p.enemyMinions)
                {
                    if ((m.Angr >= 4 || m.Hp >= 5) && !m.wounded)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute) return 0;
                        }
                    }
                }

                if (name == CardDB.cardName.demonwrath)
                {
                    int ownmins = 0;
                    int enemymins = 0;

                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.handcard.card.race != TAG_RACE.DEMON) ownmins++;
                    }
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.handcard.card.race != TAG_RACE.DEMON) enemymins++;
                    }

                    if (enemymins <= 1 || enemymins + 1 <= ownmins || ownmins >= 3)
                    {
                        return 30;
                    }
                }

                if (p.enemyMinions.Count <= 1 || p.enemyMinions.Count + 1 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                {
                    return 30;
                }
            }

            if (this.DamageAllEnemysDatabase.ContainsKey(name)) // aoe penality
            {
                if (p.enemyMinions.Count == 0) return 300;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((m.Angr >= 4 || m.Hp >= 5) && !m.wounded)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.execute) return 0;
                        }
                    }
                }

                if (name == CardDB.cardName.holynova)
                {
                    int targets = p.enemyMinions.Count;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.wounded) targets++;
                    }
                    if (targets <= 2)
                    {
                        return 20;
                    }

                }
                if (name == CardDB.cardName.darkironskulker)
                {
                    int targets = 0;
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (!m.wounded) targets++;
                    }
                    if (targets <= 2)
                    {
                        return 20;
                    }

                }
                if (p.enemyMinions.Count <= 2)
                {
                    return 20 * (3 - p.enemyMinions.Count);
                }
            }

            if (target == null) return 0;

            if (target.own && target.isHero)
            {
                if (DamageTargetDatabase.ContainsKey(name) || DamageTargetSpecialDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealTargetDatabase.ContainsKey(name)))
                {
                    pen = 500;
                }
            }

            if (!lethal && !target.own && target.isHero)
            {
                if (name == CardDB.cardName.baneofdoom)
                {
                    pen = 500;
                }
                if (name == CardDB.cardName.lavashock && p.owedRecall == 0 && p.currentRecall == 0) //todo sepefeets - eternal sentinal penalty
                {
                    pen = 20;
                }
                if (name == CardDB.cardName.fireblast && p.enemyMinions.Count > 0)
                {
                    pen = 10;
                }

                if (name == CardDB.cardName.mortalstrike && p.ownHero.Hp > 12) pen = 20;
            }

            if (target.own && !target.isHero)
            {
                if (DamageTargetDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealTargetDatabase.ContainsKey(name)))
                {
                    // no pen if own is enrage
                    Minion m = target;

                    //standard ones :D (mostly carddraw
                    if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready)
                    {
                        return 5;
                    }

                    // no pen if we have battlerage for example
                    int dmg = this.DamageTargetDatabase.ContainsKey(name) ? this.DamageTargetDatabase[name] : this.HealTargetDatabase[name];

                    if (m.name == CardDB.cardName.madscientist && p.ownHeroName == HeroEnum.hunter) return 500;
                    if (m.name == CardDB.cardName.sylvanaswindrunner) return 5;
                    if (m.handcard.card.deathrattle) return 60;
                    if (m.Hp > dmg)
                    {
                        if (m.name == CardDB.cardName.acolyteofpain && p.owncards.Count <= 3) return pen;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.battlerage) return pen;
                            if (hc.card.name == CardDB.cardName.rampage) return pen;
                        }
                    }


                    pen = 500;
                }

                //special cards
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    int dmg = DamageTargetSpecialDatabase[name];
                    Minion m = target;
                    if ((name == CardDB.cardName.crueltaskmaster || name == CardDB.cardName.innerrage) && m.Hp >= 2) return 0;
                    if ((name == CardDB.cardName.demonfire || name == CardDB.cardName.demonheart) && (TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0;
                    if (name == CardDB.cardName.earthshock && m.Hp >= 2)
                    {
                        if ((!m.silenced && (m.name == CardDB.cardName.ancientwatcher || m.name == CardDB.cardName.ragnarosthefirelord)) || m.Angr < m.handcard.card.Attack || m.maxHp < m.handcard.card.Health || (m.frozen && !m.playedThisTurn && m.numAttacksThisTurn == 0))
                            return 0;
                        if (priorityDatabase.ContainsKey(m.name) && !m.silenced)
                        {
                            return 500;
                        }
                    }
                    if (name == CardDB.cardName.earthshock)//dont silence other own minions
                    {
                        return 500;
                    }
                    if (name == CardDB.cardName.lavashock)//dont do this on own minions (you can do it on enemy hero
                    {
                        return 500;
                    }
                    // no pen if own is enrage
                    if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready)
                    {
                        return pen;
                    }

                    // no pen if we have battlerage for example

                    if (m.Hp > dmg)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.battlerage) return pen;
                            if (hc.card.name == CardDB.cardName.rampage) return pen;
                        }
                    }

                    pen = 500;
                }
            }
            if (!target.own && !target.isHero)
            {
                if (DamageTargetSpecialDatabase.ContainsKey(name) || DamageTargetDatabase.ContainsKey(name))
                {
                    Minion m = target;
                    if (name == CardDB.cardName.soulfire && m.maxHp <= 2) pen = 10;

                    if (name == CardDB.cardName.baneofdoom && m.Hp >= 3) pen = 10;

                    if (name == CardDB.cardName.shieldslam && (m.Hp <= 4 || m.Angr <= 4)) pen = 20;

                    if (name == CardDB.cardName.lavashock && p.owedRecall == 0 && p.currentRecall == 0) pen = 15;

                    if (name == CardDB.cardName.fireblast && !lethal && m.Hp == 1) pen = -10;

                    if (name == CardDB.cardName.mortalstrike && p.ownHero.Hp > 12) pen = 20;
                }
            }

            return pen;
        }

        private int getHealPenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            if (!HealTargetDatabase.ContainsKey(name) && !HealHeroDatabase.ContainsKey(name) && !HealAllDatabase.ContainsKey(name)) return 0; 
            //Todo healpenality for aoe heal
            //todo auchenai soulpriest
            if (p.anzOwnAuchenaiSoulpriest >= 1) return 0;
            if (name == CardDB.cardName.ancientoflore && choice != 2) return 0;
            int pen = 0;
            int offset = 0;
            int heal = 0;
            /*if (HealHeroDatabase.ContainsKey(name))
            {
                heal = HealHeroDatabase[name];
                if (target == 200) pen = 500; // dont heal enemy
                if ((target == 100 || target == -1) && p.ownHeroHp + heal > 30) pen = p.ownHeroHp + heal - 30;
            }*/

            // small bonus if we have heal-trigger, big penalty if enemy does
            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.name == CardDB.cardName.northshirecleric) offset -= 20;
                if (mnn.name == CardDB.cardName.lightwarden) offset -= 20;
                if (mnn.name == CardDB.cardName.holychampion) offset -= 50;
            }
            foreach (Minion mnn in p.enemyMinions)
            {
                if (mnn.name == CardDB.cardName.northshirecleric) offset += 30;
                if (mnn.name == CardDB.cardName.lightwarden) offset += 30;
                if (mnn.name == CardDB.cardName.holychampion) offset += 75;
            }

            if (name == CardDB.cardName.treeoflife)
            {
                int mheal = 0;
                int wounded = 0;
                //int eheal = 0;
                if (p.ownHero.wounded) wounded++;
                foreach (Minion mi in p.ownMinions)
                {
                    mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                    if (mi.wounded) wounded++;
                }
                //Console.WriteLine(mheal + " circle");
                if (p.ownHero.Hp < 16)
                {
                    pen += p.ownHero.Hp;
                    if (p.guessHeroDamage(false) >= p.ownHero.Hp + p.ownHero.armor) return (pen * 2) + offset;
                    else return (pen * 10) + offset;
                }
                else
                {
                    pen = (p.ownHero.Hp * 15) + 20 - mheal;
                    return pen + offset;
                }
            }

            if (name == CardDB.cardName.renojackson)
            {
                if (p.ownHero.Hp < 16)
                {
                    pen = p.ownHero.Hp;
                    if (p.guessHeroDamage(false) >= p.ownHero.Hp + p.ownHero.armor) return (pen * 2) + offset;
                    else return (pen * 10) + offset;
                }
                else
                {
                    pen = p.ownHero.Hp * 15;
                    //extra penalty if we can draw cards
                    if (p.ownAbilityReady && cardDrawBattleCryDatabase.ContainsKey(p.ownHeroAblility.card.name)) pen += 20;
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (!cardDrawBattleCryDatabase.ContainsKey(hc.card.name)) continue;
                        pen += 20;
                        break;
                    }
                    return pen + offset;
                }
            }

            if (name == CardDB.cardName.circleofhealing)
            {
                int mheal = 0;
                int wounded = 0;
                //int eheal = 0;
                foreach (Minion mi in p.ownMinions)
                {
                    mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                    if (mi.wounded) wounded++;
                }
                //Console.WriteLine(mheal + " circle");
                if (mheal == 0) return 500 + offset;
                if (mheal <= 7 && wounded <= 2) return 20 + offset;
            }

            if (HealTargetDatabase.ContainsKey(name) || HealHeroDatabase.ContainsKey(name))
             {
                
                if (HealHeroDatabase.ContainsKey(name))
                {
                    target = p.ownHero;
                    heal = HealHeroDatabase[name];
                }
                else
                {
                    if (target == null) return 10 + offset;
                    //Helpfunctions.Instance.ErrorLog("pencheck for " + name + " " + target.entitiyID + " " + target.isHero  + " " + target.own);
                    heal = HealTargetDatabase[name];
                }
                if (target.isHero && !target.own) return 510 + offset; // dont heal enemy
                //Helpfunctions.Instance.ErrorLog("pencheck for " + name + " " + target.entitiyID + " " + target.isHero + " " + target.own);
                if ((target.isHero && target.own) && p.ownHero.Hp == 30) return 150 + offset;
                if ((target.isHero && target.own) && p.ownHero.Hp + heal > 30) pen = p.ownHero.Hp + heal - 30;
                Minion m = new Minion();

                if (!target.isHero && target.own)
                {
                    m = target;
                    int wasted = 0;
                    if (m.Hp == m.maxHp) return 500 + offset;
                    if (m.Hp + heal - 1 > m.maxHp) wasted = m.Hp + heal - m.maxHp;
                    pen = wasted;

                    if (m.taunt && wasted <= 2 && m.Hp < m.maxHp) pen -= 5; // if we heal a taunt, its good :D

                    if (m.Hp + heal <= m.maxHp) pen = -1;
                }

                if (!target.isHero && !target.own)
                {
                    m = target;
                    if (m.Hp == m.maxHp) return 500 + offset;
                    // no penality if we heal enrage enemy
                    if (enrageDatabase.ContainsKey(m.name))
                    {
                        return pen + offset;
                    }

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.cardName.slam && m.Hp < 2) return pen + offset;
                        if (hc.card.name == CardDB.cardName.backstab) return pen + offset;
                    }

                    pen = 500;
                }


            }

            return pen + offset;
        }

        private int getCardDrawPenality(CardDB.cardName name, Minion target, Playfield p, int choice, bool lethal)
        {
            // penalty if carddraw is late or you have enough cards
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.cardName.ancientoflore && choice != 1) return 0;
            if (name == CardDB.cardName.wrath && choice != 2) return 0;
            if (name == CardDB.cardName.nourish && choice != 2) return 0;
            if (name == CardDB.cardName.grovetender && choice != 2) return 0;
            if (name == CardDB.cardName.quickshot && p.owncards.Count != 1) return 0;

            int carddraw = cardDrawBattleCryDatabase[name];
            if (name == CardDB.cardName.harrisonjones)
            {
                carddraw = p.enemyWeaponDurability;
                if (carddraw == 0 && (p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.warlock && p.enemyHeroName != HeroEnum.priest)) return 5;
            }
            if (name == CardDB.cardName.divinefavor)
            {
                carddraw = p.enemyAnzCards - (p.owncards.Count);
                if (carddraw <= 0) return 500;
            }

            if (name == CardDB.cardName.battlerage)
            {
                carddraw = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.wounded) carddraw++;
                }
                if (carddraw == 0) return 500;
            }

            if (name == CardDB.cardName.slam)
            {
                Minion m = target;
                carddraw = 0;
                if (m != null && m.Hp >= 3) carddraw = 1;
                if (carddraw == 0) return 4;
            }

            if (name == CardDB.cardName.mortalcoil)
            {
                Minion m = target;
                carddraw = 0;
                if (m != null && m.Hp <= 1 + p.spellpower) carddraw = 1;
                if (carddraw == 0) return 20;
            }

            if (name == CardDB.cardName.tinkertowntechnician)
            {
                carddraw = (p.ownMinions.Find(m => m.handcard.card.race == TAG_RACE.MECHANICAL) != null ? 1 : 0);
                if (carddraw == 0) return 2;
            }

            if (name == CardDB.cardName.netherspitehistorian)
            {
                carddraw = (p.owncards.Find(x => x.card.race == TAG_RACE.DRAGON) != null ? 1 : 0);
                if (carddraw == 0) return 10;
            }

            if (name == CardDB.cardName.lifetap || name == CardDB.cardName.soultap)
            {
                if (lethal) return 500; //RR no benefit for lethal check
                int minmana = 10;
                bool cardOnLimit = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.manacost <= minmana)
                    {
                        minmana = hc.manacost;
                    }
                    //if (hc.getManaCost(p) == p.ownMaxMana)
                    int manac = hc.getManaCost(p);
                    if (manac > p.ownMaxMana - 2 && manac <= p.ownMaxMana)
                    {
                        cardOnLimit = true;
                    }

                }

                if ((Ai.Instance.botBase is BehaviorRush || Ai.Instance.botBase is BehaviorFace) && p.ownMaxMana <= 3 && cardOnLimit) return 6; //RR penalization for drawing the 3 first turns if we have a card in hand that we won't be able to play in Rush


                if (p.owncards.Count + p.cardsPlayedThisTurn <= 5 && minmana > p.ownMaxMana) return 0;
                if (p.owncards.Count + p.cardsPlayedThisTurn > 5) return 25;
                return Math.Max(-carddraw + 2 * p.optionsPlayedThisTurn + p.ownMaxMana - p.mana, 0);
            }

            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10); //big penalty if drawing raises us over 9 cards ( > 10 because 1 card is lost when played to do the drawing)
            if (p.owncards.Count + carddraw > 8) return 5 * (p.owncards.Count + carddraw - 8); ; //smaller penalty if it brings us to 8-9 cards
            
            if (name == CardDB.cardName.battlerage) return -carddraw - p.optionsPlayedThisTurn + p.ownMaxMana - p.mana;
            if (name == CardDB.cardName.quickshot) return -carddraw - p.cardsPlayedThisTurn + p.optionsPlayedThisTurn;

            return -carddraw + 2 * p.optionsPlayedThisTurn + p.ownMaxMana - p.mana;
            /*pen = -carddraw + p.ownMaxMana - p.mana;
            return pen;*/
        }

        private int getCardDrawofEffectMinions(CardDB.Card card, Playfield p)
        {
            int pen = 0;
            int carddraw = 0;
            if (card.type == CardDB.cardtype.SPELL)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.gadgetzanauctioneer) carddraw++;
                }
            }

            if (card.type == CardDB.cardtype.MOB && (TAG_RACE)card.race == TAG_RACE.PET)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.starvingbuzzard) carddraw++;
                }
            }

            if (carddraw == 0) return 0;

            if (p.owncards.Count >= 5) return 0;
            pen = -carddraw + p.ownMaxMana - p.mana + p.optionsPlayedThisTurn;

            return pen;
        }

        public int getCardDrawDeathrattlePenality(CardDB.cardName name, Playfield p)
        {
            // penality if carddraw is late or you have enough cards
            if (!cardDrawDeathrattleDatabase.ContainsKey(name)) return 0;

            int carddraw = cardDrawDeathrattleDatabase[name];
            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10);
            return 3 * p.optionsPlayedThisTurn;
        }

        private int getRandomPenalty(CardDB.Card card, Playfield p, Minion target)
        {
            int pen = 0;
            if (p.turnCounter >= 1)
            {
                return 0;
            }

            bool first = true;
            bool hasAuctioneer = false;
            bool hasBuzzard = false;
            bool hasJuggler = false;
            bool hasFlamewaker = false;
            bool hasMech = false;
            bool hasCouncilman = false;
            bool hasThunderbluffV = false;


            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.handcard.card.race == TAG_RACE.MECHANICAL) hasMech = true;

                if (mnn.silenced) continue;

                if (mnn.name == CardDB.cardName.gadgetzanauctioneer) hasAuctioneer = true;
                if (mnn.name == CardDB.cardName.starvingbuzzard) hasBuzzard = true;
                if (mnn.name == CardDB.cardName.knifejuggler) hasJuggler = true;
                if (mnn.name == CardDB.cardName.flamewaker) hasFlamewaker = true;
                if (mnn.name == CardDB.cardName.darkshirecouncilman) hasCouncilman = true; //not actually random but needs to be played early as if it were
                if (mnn.name == CardDB.cardName.thunderbluffvaliant) hasThunderbluffV = true; //not actually random but totemic call/slam are
            }

            foreach (Action a in p.playactions) // penalty for "killing" combos (like had knifejuggler, traded him in last enemy-minion and then played a minion)
            {
                if (a.actionType == actionEnum.attackWithMinion)
                {
                    if (a.own.silenced)
                        continue;
                    if (a.own.name == CardDB.cardName.gadgetzanauctioneer)
                    {
                        if (!hasAuctioneer && card.type == CardDB.cardtype.SPELL && p.owncards.Count <= 5) pen += 20;
                    }

                    if (a.own.name == CardDB.cardName.starvingbuzzard)
                    {
                        if (!hasBuzzard && card.race == TAG_RACE.PET) pen += 20; 
                    }

                    if (a.own.name == CardDB.cardName.knifejuggler)
                    {
                        if (!hasJuggler && (card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(card.name))) pen += 20; 
                    }

                    if (a.own.name == CardDB.cardName.flamewaker)
                    {
                        if (!hasFlamewaker && card.type == CardDB.cardtype.SPELL) pen += 20;
                    }

                    if (a.own.name == CardDB.cardName.darkshirecouncilman)
                    {
                        if (card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(card.name)) pen += 20;
                    }

                    if (a.own.name == CardDB.cardName.tunneltrogg)
                    {
                        if (card.overload > 0 && card.name != CardDB.cardName.elementaldestruction) pen += 20 * card.overload;
                    }
                }
                if (a.actionType == actionEnum.playcard)
                {
                    if (a.card.card.overload > 0 && a.card.card.name != CardDB.cardName.elementaldestruction && card.name == CardDB.cardName.tunneltrogg)
                    {
                        pen += 25 * a.card.card.overload;
                    }

                    if (card.name == CardDB.cardName.knifejuggler && (a.card.card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(a.card.card.name))) //prioritize jugglers 1st
                    {
                        if (a.card.card.name != CardDB.cardName.knifejuggler) pen += 20;
                    }

                    if (card.name == CardDB.cardName.darkshirecouncilman && (a.card.card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(a.card.card.name))) //and councilman 2nd
                    {
                        if (a.card.card.name != CardDB.cardName.knifejuggler && a.card.card.name != CardDB.cardName.darkshirecouncilman) pen += 20;
                    }
                }
            }

            // Don't penalize for cases that don't actually have random outcomes
            // TODO: Add Lightning Storm + Elemental Destruction if all enemies hp < the minimum damage?

            if (!this.randomEffects.ContainsKey(card.name) 
                && !this.cardDrawBattleCryDatabase.ContainsKey(card.name)
                && !(hasJuggler && (card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(card.name)) && p.enemyMinions.Count > 0)
                && !(hasCouncilman && (card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(card.name)))
                && !(hasAuctioneer && card.type == CardDB.cardtype.SPELL)
                && !(hasFlamewaker && card.type == CardDB.cardtype.SPELL && p.enemyMinions.Count > 0)
                && !(hasThunderbluffV && (TAG_RACE)card.race == TAG_RACE.TOTEM)
                && !(hasBuzzard && (TAG_RACE)card.race == TAG_RACE.PET))
             {
                 return pen;
             }


            if (card.name == CardDB.cardName.brawl || ((card.name == CardDB.cardName.bouncingblade && p.enemyMinions.Count + p.ownMinions.Count == 1)
                || ( (card.name == CardDB.cardName.goblinblastmage || card.name == CardDB.cardName.tinkertowntechnician) && !hasMech)
                || (card.name == CardDB.cardName.coghammer && p.ownMinions.Count == 1)))
             {
                 return pen;
             }

            // Don't penalize for cases that don't actually have random outcomes
            // TODO: Add Lightning Storm + Elemental Destruction if all enemies hp < the minimum damage?

            if (p.enemyMinions.Count == 2 && (card.name == CardDB.cardName.cleave
                || card.name == CardDB.cardName.multishot
                || card.name == CardDB.cardName.forkedlightning
                || card.name == CardDB.cardName.darkbargain))
             {
                 return pen;
             }

            if (card.name == CardDB.cardName.deadlyshot)
            {
                int bigminions = 0;
                foreach (Minion mm in p.enemyMinions)
                {
                    if (!(mm.Angr > 4 && mm.Hp > 4 || mm.Angr > 6)) pen += 10;
                    else bigminions += 1;
                }
                if (p.enemyMinions.Count == bigminions) pen += -100; //huge bonus if they only have big minions, may be too much
            }

            if (p.enemyMinions.Count == 1 && (card.name == CardDB.cardName.deadlyshot
                || card.name == CardDB.cardName.flamecannon
                || card.name == CardDB.cardName.bomblobber))
             {
                 return pen;
             }

            if (p.enemyMinions.Count == 0 && (card.name == CardDB.cardName.arcanemissiles 
                || card.name == CardDB.cardName.avengingwrath 
                || card.name == CardDB.cardName.goblinblastmage
                || card.name == CardDB.cardName.flamejuggler))
             {
                 return pen;
             }

            int cards = this.randomEffects.ContainsKey(card.name) ? this.randomEffects[card.name] : (this.cardDrawBattleCryDatabase.ContainsKey(card.name) ? this.cardDrawBattleCryDatabase[card.name] : 0);
            int mobsAfterKnife = 0;
            int mobsAfterCouncilman = 0;

            foreach (Action a in p.playactions) // penalize for any non-random actions taken before playing this random one
            {
                if (a.actionType == actionEnum.attackWithHero)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.useHeroPower
                    && p.ownHeroAblility.card.name != CardDB.cardName.totemiccall && p.ownHeroAblility.card.name != CardDB.cardName.totemicslam
                    && p.ownHeroAblility.card.name != CardDB.cardName.lifetap && p.ownHeroAblility.card.name != CardDB.cardName.soultap)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.attackWithMinion)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.playcard)
                {
                    if (this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name)) continue;
                    if (this.lethalHelpers.ContainsKey(a.card.card.name)) continue;
                    if (this.randomEffects.ContainsKey(a.card.card.name)) continue;
                    if (a.card.card.name == CardDB.cardName.thecoin) continue; //no penalty for using coin first
                    if (hasBuzzard && a.card.card.race == TAG_RACE.PET) continue;
                    if (hasThunderbluffV && a.card.card.race == TAG_RACE.TOTEM) continue;

                    // no penalty for spells or other cards that obtain bonuses from playing spells
                    if ((hasAuctioneer || hasFlamewaker) && (a.card.card.type == CardDB.cardtype.SPELL
                        || a.card.card.name == CardDB.cardName.gadgetzanauctioneer || a.card.card.name == CardDB.cardName.flamewaker
                        || a.card.card.name == CardDB.cardName.manawyrm || a.card.card.name == CardDB.cardName.manaaddict
                        || a.card.card.name == CardDB.cardName.questingadventurer || a.card.card.name == CardDB.cardName.wildpyromancer
                        || a.card.card.name == CardDB.cardName.violetteacher || a.card.card.name == CardDB.cardName.archmageantonidas))
                    {
                        continue;
                    }

                    //todo sepefeets - does this even do anything?
                    if (hasJuggler && (card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(card.name))) //and others
                     {
                        if (card.name == CardDB.cardName.knifejuggler && mobsAfterKnife >= 1)
                        {
                            first = false;   // penalize playing 2nd knife juggler after other mobs
                        }
                        else
                        {
                            if (a.card.card.type == CardDB.cardtype.MOB && a.card.card.name != CardDB.cardName.knifejuggler) mobsAfterKnife++;
                            continue;
                        }
                    }

                    if (hasCouncilman && (card.type == CardDB.cardtype.MOB || this.summonMinionSpellsDatabase.ContainsKey(card.name))) //and others
                    {
                        if (card.name == CardDB.cardName.darkshirecouncilman && mobsAfterCouncilman >= 1)
                        {
                            first = false;   // penalize playing 2nd darkshire councilman after other mobs
                        }
                        else
                        {
                            if (a.card.card.type == CardDB.cardtype.MOB && a.card.card.name != CardDB.cardName.darkshirecouncilman) mobsAfterCouncilman++;
                            continue;
                        }
                    }
                }
                cards+=2;
            }

            if (first == false)
            {
                pen += cards;
            }

            return pen;
        }

        private int getCardDiscardPenality(CardDB.cardName name, Playfield p)
        {
            if (p.owncards.Count <= 1) return 0;
            if (p.ownMaxMana <= 3) return 0;
            int pen = 0;
            if (this.cardDiscardDatabase.ContainsKey(name))
            {
                int newmana = p.mana - cardDiscardDatabase[name];
                bool canplayanothercard = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (this.cardDiscardDatabase.ContainsKey(hc.card.name)) continue;
                    if (hc.card.name == CardDB.cardName.silverwaregolem || hc.card.name == CardDB.cardName.fistofjaraxxus)
                    {
                        pen += -20; //bonus for discarding these
                        continue;
                    }
                    if (hc.card.getManaCost(p, hc.manacost) <= newmana)
                    {
                        canplayanothercard = true;
                    }
                }
                if (canplayanothercard) pen += 20;

            }

            return pen;
        }

        private int getDestroyOwnPenality(CardDB.cardName name, Minion target, Playfield p, bool lethal)
        {
            if (!this.destroyOwnDatabase.ContainsKey(name)) return 0;
            int pen = 0;

            if (name == CardDB.cardName.brawl || name == CardDB.cardName.deathwing || name == CardDB.cardName.twistingnether || name == CardDB.cardName.doomsayer || name == CardDB.cardName.doom)
            {
                if (p.mobsPlayedThisTurn >= 1) return 500;
                if (name == CardDB.cardName.brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
                int highminion = 0;
                int veryhighminion = 0;
                int readyAngr = 0;
                foreach (Minion m in p.enemyMinions)
                {
                    if (!m.frozen)
                    {
                        readyAngr += m.Angr;
                    }
                    if (m.Angr >= 5 || m.Hp >= 5) highminion++;
                    if (m.Angr >= 8 || m.Hp >= 8) veryhighminion++;
                }

                if (name == CardDB.cardName.doomsayer)
                {
                    if (readyAngr > 5) return 500;
                    else if (p.enemyMinions.Count <= 2 || p.enemyMinions.Count + 2 <= p.ownMinions.Count || p.ownMinions.Count >= 3) return 30;
                    else return 0;
                }
                
                if (highminion >= 2 || veryhighminion >= 1)
                {
                    return 0;
                }

                if (p.enemyMinions.Count <= 2 || p.enemyMinions.Count + 2 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                {
                    return 30;
                }

                return 0;
            }
            if (target == null) return 0;
            if (target.own && !target.isHero)
            {
                // dont destroy owns ;_; (except mins with deathrattle effects)

                Minion m = target;
                if (m.handcard.card.deathrattle) return 30;
                if (lethal && name == CardDB.cardName.sacrificialpact)
                {
                    int demons = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && mm.handcard.card.race == TAG_RACE.DEMON) demons++;
                    }
                    if (demons == 0) return 500;
                }
                else
                {

                    return 500;
                }
            }

            return pen;
        }

        private int getDestroyPenality(CardDB.cardName name, Minion target, Playfield p, bool lethal)
        {
            if (!this.destroyDatabase.ContainsKey(name) || lethal) return 0;
            int pen = 0;
            if (target == null) return 0;
            if (name == CardDB.cardName.shatter && !target.frozen) return 500; //todo sepefeets - remove after CardDB.getTargetsForCard() updated/merged?

            //if (target.own && !target.isHero){} //handled in getDestroyOwnPenality()

            if (!target.own && !target.isHero)
            {

                // destroy others
                Minion m = target;

                /*if (m.allreadyAttacked)//doesnt make sence :D
                {
                    return 50;
                }*/

                if (name == CardDB.cardName.shadowwordpain || name == CardDB.cardName.bookwyrm)
                {
                    if (this.specialMinions.ContainsKey(m.name) || m.Angr == 3 || m.Hp >= 4)
                    {
                        return 0;
                    }

                    if (m.Angr == 2) return 5;

                    return 10;
                }

                

                if (m.Angr >= 4 || m.Hp >= 5)
                {
                    pen = 0; // so we dont destroy cheap ones :D
                }
                else
                {
                    pen = 30;
                }

                if (m.name == CardDB.cardName.doomsayer)
                {
                    pen = 0;
                }

                if (name == CardDB.cardName.mindcontrol && (m.name == CardDB.cardName.direwolfalpha || m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.flametonguetotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

            }

            return pen;
        }

        private int getPlayInspirePenalty(Handmanager.Handcard playhc, Playfield p)
        {
            // Penalize for playing Inspire minions without Inspire effect

            CardDB.Card card = playhc.card;           
            CardDB.cardName name = card.name;

            if (!this.strongInspireEffectMinions.ContainsKey(name)) return 0;

            // check already used hero power
            if (p.playactions.Find(a => a.actionType == actionEnum.useHeroPower) != null)
                return 1 + (5 * strongInspireEffectMinions[name]);

            int ownplaycost = playhc.getManaCost(p);
            int heropowercost = p.ownHeroAblility.card.getManaCost(p, 2);

            // check not enough mana to gain Inspire buff
            if (p.mana < ownplaycost + heropowercost) return 2 * strongInspireEffectMinions[name];

            return 0;
        }

        private int getbackToHandPenality(CardDB.cardName name, Minion target, Playfield p, bool lethal)
        {
            if (!this.backToHandDatabase.ContainsKey(name) || lethal) return 0;
            int pen = 0;

            if (name == CardDB.cardName.vanish)
            {
                //dont vanish if we have minons on board wich are ready
                bool haveready = false;
                foreach (Minion mins in p.ownMinions)
                {
                    if (mins.Ready) haveready = true;
                }
                if (haveready) pen += 10;
            }

            if (target == null) return 0;

            if (target.own && !target.isHero)
            {
                if (p.turnCounter >= 1 && !target.handcard.card.Charge) return 500;
                // dont destroy owns ;_; (except mins with deathrattle effects, with battlecry, or to heal)
                Minion m = target;
                pen = 500;
                
                if (m.handcard.card.deathrattle || m.handcard.card.battlecry || m.handcard.card.Charge || ((m.maxHp - m.Hp) >= 4))
                {
                    pen = 0;
                }
                if (m.handcard.card.deathrattle || m.handcard.card.battlecry || m.handcard.card.Charge || ((m.maxHp - m.Hp )>=4))
                {
                    pen = 0;
                }
                if (m.shadowmadnessed)
                {
                    pen = -20;
                }

                if (m.Ready) pen += 10;
            }
            if (!target.own && !target.isHero)
            {
                
                Minion m = target;

                if (m.allreadyAttacked || m.shadowmadnessed) //dont sap shadow madness
                {
                    return 50;
                }

                if (m.name == CardDB.cardName.theblackknight)
                {
                    return 50;
                }

                if (m.Angr >= 5 || m.Hp >= 5)
                {
                    pen = 0; // so we dont destroy cheap ones :D
                }
                else
                {
                    pen = 30;
                }

                if (this.cardDrawBattleCryDatabase.ContainsKey(m.name)) pen += 10 * this.cardDrawBattleCryDatabase[m.name];

            }

            return pen;
        }

        private int getHeroPowerPenality(Handmanager.Handcard hcard, Minion target, Playfield p)
        {
            CardDB.Card card = hcard.card;
            CardDB.cardName name = card.name;
            int pen = 0;

            // penalize playing hero power after spell dmg cards
            if (name == CardDB.cardName.totemiccall || name == CardDB.cardName.totemicslam)  // shaman
            {
                pen += p.playactions.FindAll(a => a.actionType == actionEnum.playcard && a.card.card.type == CardDB.cardtype.SPELL
                    && (DamageTargetSpecialDatabase.ContainsKey(a.card.card.name) || DamageTargetDatabase.ContainsKey(a.card.card.name) 
                        || DamageAllEnemysDatabase.ContainsKey(a.card.card.name) || DamageHeroDatabase.ContainsKey(a.card.card.name)
                        || DamageRandomDatabase.ContainsKey(a.card.card.name) || a.card.card.name == CardDB.cardName.elementaldestruction)).Count * 9;
            }

            // slightly penalize playing shapeshift after other moves to recover a bit from HR data sync
            if (name == CardDB.cardName.shapeshift || name == CardDB.cardName.direshapeshift)
            {
                pen += p.playactions.Count;
            }
            /*
            //to counteract randomness penalty for playing hero power 2nd after inspire minion (maybe move to getRandomPenalty) - moved
            if ((name == CardDB.cardName.totemiccall || name == CardDB.cardName.totemicslam || name == CardDB.cardName.lifetap || name == CardDB.cardName.soultap)
                && p.playactions.Find(a => a.actionType == actionEnum.playcard && this.strongInspireEffectMinions.ContainsKey(a.card.card.name)) != null) pen += -7;
            */


            return pen;
        }

        private int getPlayMobPenalty(Handmanager.Handcard card, Minion target, Playfield p, bool lethal)
        {
            if (card.card.type != CardDB.cardtype.MOB && !this.summonMinionSpellsDatabase.ContainsKey(card.card.name)) return 0;
            int retval = 0;

            if (card.card.name == CardDB.cardName.doomcaller && p.diedMinions != null && p.diedMinions.Find(ct => ct.own && ct.cardid == CardDB.cardIDEnum.OG_279).cardid == CardDB.cardIDEnum.OG_279) retval += 5; //OG_279 = cthun; penalize playing if cthun is not dead
            if (p.ownMinions.Find(m => m.name == CardDB.cardName.doomsayer && !m.silenced) != null || p.enemyMinions.Find(m => m.name == CardDB.cardName.doomsayer && !m.silenced) != null)
            {
                // todo sepefeets - why doesn't penalizing this in behavior code work?
                if (card.card.Charge || card.card.battlecry) return 5 * card.card.cost; //should really check all the dmg databases
                else if (card.card.deathrattle) return 10 * card.card.cost; //just estimate the value by the cost
                //else if (this.buffing1TurnDatabase.ContainsKey(card.card.name) || this.attackBuffDatabase.ContainsKey(card.card.name)) return 0;
                else return 500;
            }
            if (p.ownMinions.Find(m => m.name == CardDB.cardName.muklaschampion && !m.silenced) != null && p.playactions.Find(a => a.actionType == actionEnum.useHeroPower) != null)
            {
                // penalize playing minions after mukla's +1/+1 buff
                retval += 5;
            }

            if (p.ownMinions.Find(m => m.name == CardDB.cardName.thunderbluffvaliant && !m.silenced) != null && p.playactions.Find(a => a.actionType == actionEnum.useHeroPower) != null && card.card.race == TAG_RACE.TOTEM)
            {
                // penalize playing totems after tbluff +2 ap buff
                retval += 20;
            }

            int buffs = 0;
            foreach (Action a in p.playactions)
            {
                if (a.card == null || a.actionType != actionEnum.playcard) continue;

                if (a.card.card.name == CardDB.cardName.everyfinisawesome) buffs++;
                if (a.card.card.name == CardDB.cardName.savageroar) buffs++;
                if (a.card.card.name == CardDB.cardName.bloodlust) buffs++;
                if (a.card.card.name == CardDB.cardName.souloftheforest) buffs++;
                if (a.card.card.name == CardDB.cardName.powerofthewild && a.druidchoice == 1) buffs++;
                if (a.card.card.name == CardDB.cardName.cenarius && a.druidchoice == 1) buffs++;
                if (a.card.card.name == CardDB.cardName.metaltoothleaper) buffs++;
                if (a.card.card.name == CardDB.cardName.enhanceomechano) buffs++;
                if (card.card.tank && a.card.card.name == CardDB.cardName.bolster) buffs++;

            }

            if (buffs >=1)
            {
                retval += 5*buffs;
            }

            return retval;
        }

        private int getSpecialCardComboPenalties(Handmanager.Handcard playedhcard, Minion target, Playfield p, bool lethal, int choice)
        {
            CardDB.Card card = playedhcard.card;
            CardDB.cardName name = card.name;

            if (lethal && card.type == CardDB.cardtype.MOB)
            {
                if (this.lethalHelpers.ContainsKey(name))
                {
                    return 0;
                }

                if (this.DamageTargetDatabase.ContainsKey(name) || this.DamageAllDatabase.ContainsKey(name) )
                {
                    return 0;
                }

                if (this.buffingMinionsDatabase.ContainsKey(name))
                {
                    if (name == CardDB.cardName.timberwolf || name == CardDB.cardName.houndmaster)
                    {
                        int beasts = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && (TAG_RACE)mm.handcard.card.race == TAG_RACE.PET) beasts++;
                        }
                        if (beasts == 0) return 500;
                    }

                    if (name == CardDB.cardName.warsongcommander)
                    {
                        int chargers = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.charge>=1) chargers++;
                        }
                        if (chargers == 0) return 500;
                    }

                    if (name == CardDB.cardName.southseacaptain)
                    {
                        int pirates = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && (TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE) pirates++;
                        }
                        if (pirates == 0) return 500;
                    }
                    if (name == CardDB.cardName.murlocwarleader || name == CardDB.cardName.grimscaleoracle || name == CardDB.cardName.coldlightseer)
                    {
                        int murlocs = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && (TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC) murlocs++;
                        }
                        if (murlocs == 0) return 500;
                    }

                    if (name == CardDB.cardName.warhorsetrainer)
                    {
                        int recruits = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready &&  mm.name == CardDB.cardName.silverhandrecruit) recruits++;
                        }
                        if (recruits == 0) return 500;
                    }

                    if (name == CardDB.cardName.malganis)
                    {
                        int demons = 0;
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (mm.Ready && mm.handcard.card.race == TAG_RACE.DEMON) demons++;
                        }
                        if (demons == 0) return 500;
                    }
                }
                else
                {
                    if (name == CardDB.cardName.theblackknight)
                    {
                        int taunts = 0;
                        foreach (Minion mm in p.enemyMinions)
                        {
                            if (mm.taunt) taunts++;
                        }
                        if (taunts == 0) return 500;
                    }
                    else
                    {
                        if ((this.HealTargetDatabase.ContainsKey(name) || this.HealHeroDatabase.ContainsKey(name) || this.HealAllDatabase.ContainsKey(name)))
                        {
                            int wardens = 0;
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.Ready && mm.handcard.card.name == CardDB.cardName.lightwarden) wardens++;
                                if (mm.Ready && mm.handcard.card.name == CardDB.cardName.holychampion) wardens++;
                            }
                            if (wardens == 0) return 500;
                        }
                        else
                        {
                            //ignore that minion if it does not have charge, or we can give him charge ---> warsong was deleted ;_;
                            if (!(name == CardDB.cardName.nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || ((TAG_RACE)card.race == TAG_RACE.PET && p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null) || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null))
                            {
                                return 500;
                            }
                        }
                    }
                }
            }

            //lethal end########################################################

            //bonus for early threat
            if (p.ownMaxMana == 1)
            {
                if (card.Attack >= 3 && card.Health >= 4) return -10;
                if (card.Attack >= 3 && card.Health >= 3) return -8;
                if (card.Attack >= 3 && card.Health >= 2) return -5;
                if (card.Health > 0) p.evaluatePenality += -3; //-card.Attack - card.Health; //nudge any minion playable
            }

            if (p.mana <= 2 && p.ownMaxMana <= 2)
            {
                if (card.name == CardDB.cardName.nerubianegg) return -2;
                if (card.name == CardDB.cardName.wildgrowth) return -150; //bonus for turn 1 coin+growth or turn 2 growth but not innervate+growth
                if (card.name == CardDB.cardName.sirfinleymrrgglton) return 5; //don't play early over other options
            }

            /*if (card.name == CardDB.cardName.flamewaker && p.turnCounter == 0)
            {
                int number =0;
                foreach (Action a in p.playactions)
                {
                    if (a.card!=null && a.card.card.type == CardDB.cardtype.SPELL) number++;
                }
                return number * 10;
            }*/


            switch (card.name)
            {
                case CardDB.cardName.twilightdarkmender:
                case CardDB.cardName.twinemperorveklor:
                case CardDB.cardName.klaxxiamberweaver:
                case CardDB.cardName.ancientshieldbearer:
                    if ((p.anzOgOwnCThunAngrBonus + 6) > 9) return 20;
                    break;
            }



            //if (card.name == CardDB.cardName.unstableportal && p.owncards.Count <= 9) return -15;

            if (card.name == CardDB.cardName.daggermastery)
            {
                if (p.ownWeaponAttack >= 2 || p.ownWeaponDurability >= 2) return 5;
            }

            if (card.name == CardDB.cardName.upgrade)
            {
                if (p.playactions.Find(a => a.actionType == actionEnum.attackWithHero) != null) return 20;
                if (p.ownWeaponDurability == 0) return 10;
            }

            if (card.name == CardDB.cardName.baronrivendare)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.cardName.deathlord || mnn.name == CardDB.cardName.zombiechow || mnn.name == CardDB.cardName.dancingswords) return 30;
                }
            }

            //rule for coin on early game
            if (p.ownMaxMana < 3 && card.name == CardDB.cardName.thecoin)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB && hc.canplayCard(p)) return 5;
                }

            }

            // spare parts need a base penalty so the bot does not waste them
            // TODO: move this a better location, and break reversing switch into atk buff and hp buff components
            if (name == CardDB.cardName.finickycloakfield || name == CardDB.cardName.emergencycoolant || name == CardDB.cardName.reversingswitch)
                return 20;

            if (name == CardDB.cardName.flare || name == CardDB.cardName.kezanmystic || name == CardDB.cardName.eaterofsecrets) 
            {
                if (p.enemyHeroName != HeroEnum.hunter && p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.pala) return 0;
                //it is a hunter/mage or pala:
                if (p.enemySecretCount == 0) return 50;
                if (p.enemySecretCount >= 1 && p.playactions.Count == 0)  return -10;
            }

            //some effects, which are bad :D
            int pen = 0;
            if (name == CardDB.cardName.houndmaster)
            {
                if (target == null || !target.Ready) return 50;
            }

            if ((card.name == CardDB.cardName.biggamehunter) && (target == null || target.own))
            {
                return 40;
            }
            if (name == CardDB.cardName.aldorpeacekeeper && target == null)
            {
                return  30;
            }

            if (name == CardDB.cardName.sylvanaswindrunner && p.enemyMinions.Count == 0)
            {
                return 50;
            }

            if (name == CardDB.cardName.cabalshadowpriest && target == null)
            {
                return 40;
            }

            if (name == CardDB.cardName.emergencycoolant && target != null && target.own)//dont freeze own minions
            {
                return  500;
            }

            if (name == CardDB.cardName.shatteredsuncleric && target == null) { pen = 10; }
            if (name == CardDB.cardName.argentprotector)
            {
                if (target == null) { return 20; }
                else
                {
                    if (!target.own) { return 500; }
                    if (target.divineshild) { return 15; }
                    if (!target.Ready && !target.handcard.card.isSpecialMinion) { return 10; }
                    if (!target.Ready && !target.handcard.card.isSpecialMinion && target.Angr <= 2 && target.Hp <= 2) { return 15; }
                }

            }

            if (name == CardDB.cardName.facelessmanipulator)
            {
                if (target == null)
                {
                    return 50;
                }
                if (target.Angr >= 5 || target.handcard.card.cost >= 5 || (target.handcard.card.rarity == 5 && target.handcard.card.cost >= 3))
                {
                    return 0;
                }
                return 49;
            }

            if (name == CardDB.cardName.ancientofwar)
            {
                if (p.enemyMinions.Count > 0 && choice == 1) return 200;
                if (p.enemyMinions.Count == 0 && choice == 2) return 50;
            }

            if (name == CardDB.cardName.druidoftheflame)
            {

                if (p.enemyMinions.Count > 0 && choice == 2) return 40;
                if (p.enemyMinions.Count == 0 && choice == 1) return 40;

            }

            if (name == CardDB.cardName.gangup && target!=null)
            {
                if(target.handcard.card.isToken) return 20;
                if (target.handcard.card.isSpecialMinion) return -20;
                
                
            }

            if (name == CardDB.cardName.theblackknight)
            {
                if (target == null)
                {
                    return 50;
                }

                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.taunt && (target.Angr >= 3 || target.Hp >= 3)) return 0;
                }
                return 20;
            }

            //------------------------------------------------------------------------------------------------------
            Minion m = target;

            if (card.name == CardDB.cardName.reincarnate)
            {
                if (m.own)
                {
                    if (m.handcard.card.deathrattle || m.ancestralspirit >= 1 || m.souloftheforest >= 1 || m.enemyBlessingOfWisdom >= 1 || m.explorershat >=1) return 0;
                    if (m.handcard.card.Charge && ((m.numAttacksThisTurn == 1 && !m.windfury) || (m.numAttacksThisTurn == 2 && m.windfury))) return 0;
                    if (m.wounded || m.Angr < m.handcard.card.Attack || (m.silenced && instance.specialMinions.ContainsKey(m.name))) return 0;


                    bool hasOnMinionDiesMinion = false;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.name == CardDB.cardName.scavenginghyena && m.handcard.card.race == TAG_RACE.PET) hasOnMinionDiesMinion = true;
                        if (mnn.name == CardDB.cardName.flesheatingghoul || mnn.name == CardDB.cardName.cultmaster) hasOnMinionDiesMinion = true;
                    }
                    if (hasOnMinionDiesMinion) return 0;

                    return 500;
                }
                else
                {
                    if (m.name == CardDB.cardName.nerubianegg && m.Angr <= 4 && !m.taunt) return 500;
                    if (m.taunt && !m.handcard.card.tank) return 0;
                    if (m.enemyBlessingOfWisdom >= 1) return 0;
                    if (m.Angr > m.handcard.card.Attack || m.Hp > m.handcard.card.Health) return 0;
                    if (m.name == CardDB.cardName.abomination || m.name == CardDB.cardName.zombiechow || m.name == CardDB.cardName.unstableghoul || m.name == CardDB.cardName.dancingswords) return 0;
                    return 500;

                }

            }


            if (name == CardDB.cardName.madbomber || name == CardDB.cardName.madderbomber)
            {
                //penalize for any own minions with health equal to potential attack amount
                //to lessen risk of losing your own minion
                int maxAtk = 3;
                if (name == CardDB.cardName.madderbomber) maxAtk = 6;
                if (maxAtk >= p.ownHero.Hp && maxAtk < p.enemyHero.Hp) return 500;//we could be killed, but not enemy >_< .. otherwise YOLO
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Hp <= maxAtk)
                    {
                        if (mnn.Ready) pen += 20; 
                    }
                }

                /*
                int numTargets = 2 + p.ownMinions.Count + p.enemyMinions.Count;
                int numOwnTargets = 1 + p.ownMinions.Count;
                int numEnemyTargets = numTargets-numOwnTargets;
                double dmgpertarget = ((double)maxAtk)/((double)numTargets);
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Hp <= dmgpertarget)
                    {
                        pen += 10;
                    }
                }
                */
            }



            if (name == CardDB.cardName.mechwarper)
            {
                List<Handmanager.Handcard> mechCards = p.owncards.FindAll(hc => hc != playedhcard && hc.card.race == TAG_RACE.MECHANICAL);
                mechCards.Sort((a, b) => a.getManaCost(p).CompareTo(b.getManaCost(p)));  // increasing mana cost

                int maxMechsNextTurnWithoutWarper = 0, maxMechsNextTurnWithWarper = 0;
                int manaNextTurnWithoutWarper = p.ownMaxMana + 1, manaNextTurnWithWarper = p.ownMaxMana + 1;

                for (int i = 0; i < mechCards.Count; i++)
                {
                    int cost = mechCards[i].getManaCost(p);
                    if (manaNextTurnWithoutWarper > cost)
                    {
                        maxMechsNextTurnWithoutWarper++;
                        manaNextTurnWithoutWarper -= cost;
                    }
                    if (manaNextTurnWithWarper > (cost - 1))
                    {
                        maxMechsNextTurnWithWarper++;
                        manaNextTurnWithWarper -= (cost - 1);
                    }
                }

                return -3*(maxMechsNextTurnWithWarper - maxMechsNextTurnWithoutWarper);  // +1 mana in savings per additional mech
            }

            if (name == CardDB.cardName.goblinblastmage)
            {
                bool mechOnField = false;

                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.handcard.card.race == TAG_RACE.MECHANICAL)
                    {
                        mechOnField = true;
                        break;
                    }
                }

                if (!mechOnField)  // penalize if we can play a mech this turn
                {
                    int lowestCostMechInHand = 1000;
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.race == TAG_RACE.MECHANICAL && hc.getManaCost(p) < lowestCostMechInHand) lowestCostMechInHand = hc.getManaCost(p);
                    }

                    if (p.mana >= (playedhcard.getManaCost(p) + lowestCostMechInHand)) return 50;
                    if (p.mana >= lowestCostMechInHand) return 20;

                    return 0;
                }
                else  // penalize for randomness of battlecry
                {
                    bool hasNerubianEgg = false;
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.handcard.card.name == CardDB.cardName.nerubianegg && !mnn.silenced && mnn.Hp <= 2)
                        {
                            hasNerubianEgg = true;
                            break;
                        }
                    }

                    // less minions = less randomness to penalize, but more minions = less chance to kill egg, so egg penalty is constant
                    return (hasNerubianEgg ? 10 : p.enemyMinions.Count);
                }
            }


            if (card.name == CardDB.cardName.knifejuggler && (p.mobsPlayedThisTurn > 1 || (p.ownAbilityReady == false && this.summonMinionSpellsDatabase.ContainsKey(p.ownHeroAblility.card.name))))
             {
                 return 20;
            }

            if (card.name == CardDB.cardName.darkshirecouncilman && (p.mobsPlayedThisTurn > 0 || (p.ownAbilityReady == false && this.summonMinionSpellsDatabase.ContainsKey(p.ownHeroAblility.card.name))))
            {
                return 20;
            }

            if (card.name == CardDB.cardName.flametonguetotem && p.ownMinions.Count == 0)
            {
                return 100;
            }

            if (card.name == CardDB.cardName.stampedingkodo)
            {
                bool found = false;
                foreach (Minion mi in p.enemyMinions)
                {
                    if (mi.Angr <= 2) found = true;
                }
                if (!found) return 20;
            }

            if (name == CardDB.cardName.windfury)
            {
                if (!m.own) return 500;
                if (m.own && !m.Ready) return 500;
            }

            if (name == CardDB.cardName.wildgrowth && p.ownMaxMana > 5 && p.ownMaxMana < 10)
            {
                return 500;
            }

            if (name == CardDB.cardName.nourish && choice == 1 && p.ownMaxMana > 6)
            {
                return 500;
            }

            if (name == CardDB.cardName.ancestralspirit)
            {
                if (!target.own && !target.isHero)
                {
                    if (m.name == CardDB.cardName.deathlord || m.name == CardDB.cardName.zombiechow || m.name == CardDB.cardName.dancingswords) return 0;
                    return 500;
                }
                if (target.own && !target.isHero)
                {
                    if (this.specialMinions.ContainsKey(m.name)) return -5;
                    return 0;
                }

            }

            if (name == CardDB.cardName.sylvanaswindrunner)
            {
                if (p.enemyMinions.Count == 0)
                {
                    return 10;
                }
            }

            if (name == CardDB.cardName.betrayal && !target.own && !target.isHero)
            {
                if (m.Angr == 0) return 30;
                if (p.enemyMinions.Count == 1) return 30;
            }
            

            if (heroAttackBuffDatabase.ContainsKey(name))
            {
                return ((p.ownHero.numAttacksThisTurn == 0) && !p.ownHero.frozen) ? 0 : 20;
            }

            if (name == CardDB.cardName.deadlypoison)
            {
                return -p.ownWeaponDurability * 2;
            }

            if (name == CardDB.cardName.shadydealer)
            {
                bool haspirate = false;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.handcard.card.race == TAG_RACE.PIRATE)
                    {
                        haspirate = true;
                        break;
                    }
                }
                if (haspirate) return 0;
                else return 10;

            }

            if (name == CardDB.cardName.coldblood)
            {
                if (lethal) return 0;
                return 25;
            }

            if (name == CardDB.cardName.bloodmagethalnos)
            {
                return 10;
            }

            if (name == CardDB.cardName.frostbolt)
            {
                if (!target.own && !target.isHero)
                {
                    if (m.handcard.card.cost <= 2)
                        return 15;
                }
                return 8;
            }

            if (!lethal && choice == 1 && name == CardDB.cardName.druidoftheclaw)
            {
                return 10;
            }


            if (name == CardDB.cardName.poweroverwhelming)
            {
                if (target.own && !target.isHero && !m.Ready)
                {
                    if (target.name == CardDB.cardName.voidcaller) return 50;
                    if (target.name == CardDB.cardName.sylvanaswindrunner) return 100;
                    return 500;
                }
                else
                {
                    if (this.priorityDatabase.ContainsKey(target.name)) return 10 + priorityDatabase[target.name];
                }
            }

            if (name == CardDB.cardName.frothingberserker)
            {
                if (p.cardsPlayedThisTurn >= 1 || p.playactions.Find(a => (a.actionType == actionEnum.attackWithHero || a.actionType == actionEnum.attackWithMinion) && !a.target.isHero) != null) return 15;
            }

            if (name == CardDB.cardName.handofprotection)
            {
                if (m.Hp == 1) return 15;
            }

            if (lethal)
            {
                if (name == CardDB.cardName.corruption)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && (mm.handcard.card.name == CardDB.cardName.questingadventurer || mm.handcard.card.name == CardDB.cardName.archmageantonidas || mm.handcard.card.name == CardDB.cardName.manaaddict || mm.handcard.card.name == CardDB.cardName.manawyrm || mm.handcard.card.name == CardDB.cardName.wildpyromancer)) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
            }

            if (name == CardDB.cardName.divinespirit)
            {
                if (lethal)
                {
                    if (!target.own && !target.isHero)
                    {
                        if (!m.taunt)
                        {
                            return 500;
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && (m.Hp >= 4 || (p.owncards.Find(x => x.card.name == CardDB.cardName.divinespirit) != null && m.Hp >= 2)))
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                }
                else
                {
                    if (!target.own && !target.isHero)
                    {

                        // combo for killing with innerfire and biggamehunter
                        if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && m.Hp >= 4)
                        {
                            return 0;
                        }
                        return 500;
                    }

                }

                if (target.own && !target.isHero)
                {

                    if (m.Hp >= 4)
                    {
                        return 0;
                    }
                    return 15;
                }

            }




            if ((name == CardDB.cardName.polymorph || name == CardDB.cardName.hex))
            {
                if (target.own && !target.isHero) return 500;
                foreach (Action a in p.playactions)
                {
                    if (a.target != null && a.target == target) return 500;
                    if (a.card != null && (DamageAllDatabase.ContainsKey(a.card.card.name) || DamageAllEnemysDatabase.ContainsKey(a.card.card.name)
                        || DamageRandomDatabase.ContainsKey(a.card.card.name) || randomEffects.ContainsKey(a.card.card.name))) return 500;
                }

                if (!target.own && !target.isHero)
                {
                    int hexpen = 30 - (2 * target.Angr) - target.Hp;  // base penalty so we don't waste the spell on small minions
                    if (target.allreadyAttacked) hexpen += 30;
                    if (!target.silenced)
                    {
                        if (specialMinions.ContainsKey(target.name)) hexpen -= specialMinions[target.name];
                        if (this.priorityTargets.ContainsKey(target.name) && this.priorityTargets[target.name] >= 5) return hexpen;
                        if (target.Angr >= 4 && this.silenceTargets.ContainsKey(target.name)) return hexpen;
                    }
                    return hexpen+30;
                }
            }



            if (name == CardDB.cardName.unleashthehounds)
            {
                if (p.enemyMinions.Count <= 1)
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.equality) // aoe penality
            {
                int hpdestroyed = 0;
                foreach (Minion mini in p.enemyMinions)
                {
                    hpdestroyed += (mini.Hp - 1);
                }

                if (p.enemyMinions.Count <= 2 || hpdestroyed <= 4)
                {
                    return 20;
                }
            }

            if (name == CardDB.cardName.bloodsailraider && p.ownWeaponDurability == 0)
            {
                //if you have bloodsailraider and no weapon equiped, but own a weapon:
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.WEAPON) return 10;
                }
            }



            if (name == CardDB.cardName.innerfire)
            {
                if (m.name == CardDB.cardName.lightspawn) return 500;
            }

            if (name == CardDB.cardName.huntersmark)
            {
                if (target.own && !target.isHero) return 500; // dont use on own minions
                if (!target.own && !target.isHero && (target.Hp <= 4) && target.Angr <= 4) // only use on strong minions
                {
                    return 20;
                }
            }


            if ((name == CardDB.cardName.aldorpeacekeeper || name == CardDB.cardName.humility))
            {
                if (target != null)
                {
                    if (target.own) pen = 500; // dont use on own minions
                    if (!target.own && target.Angr <= 3) // only use on strong minions
                    {
                        return 30;
                    }
                    if (m.name == CardDB.cardName.lightspawn) pen = 500;
                }
                else
                {
                    return 50;
                }
            }



            if (name == CardDB.cardName.defiasringleader && p.cardsPlayedThisTurn == 0)
            { pen = 10; }
            if (name == CardDB.cardName.bloodknight)
            {
                int shilds = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.divineshild)
                    {
                        shilds++;
                    }
                }
                foreach (Minion min in p.enemyMinions)
                {
                    if (min.divineshild)
                    {
                        shilds++;
                    }
                }
                if (shilds == 0)
                {
                    return 10;
                }
            }
            if (name == CardDB.cardName.direwolfalpha)
            {
                int ready = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.Ready) ready++;
                }
                if (ready == 0) return 10;
                if (ready == 1) return 5;
            }


/*
            if (name == CardDB.cardName.abusivesergeant)  //penalty handled by buffing1TurnDatabase
            {
                int ready = 0;
                foreach (Minion min in p.ownMinions)
                {
                    if (min.Ready)
                    { ready++; }
                }
                if (ready == 0)
                {
                    return 5;
                }
            }*/

            if (p.turnCounter >= 1 && name == CardDB.cardName.reversingswitch && target.Angr == target.Hp) return 500;

            

            return pen;
        }

        private int getPlaySecretPenalty(CardDB.Card card, Playfield p)
        {
            int pen = 0;
            if (card.Secret)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    //penalty if we play secret and have playable kirintormage
                    if (hc.card.name == CardDB.cardName.kirintormage && p.mana >= hc.getManaCost(p))
                    {
                        pen = 500;
                    }

                    if (hc.card.name == CardDB.cardName.secretkeeper && p.mana >= card.cost)
                    {
                        pen = 500;
                    }
                }

                int smallAngr = 0;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr < 4)
                    {
                        smallAngr++;
                    }
                }
                if (smallAngr > 0) pen += 50; //not 500 because we might need to protect ourself from lethal
            }

            return pen;
        }

        //not used-----------------------------------------------------------------------
        ///secret strategys pala
        /// -Attack lowest enemy. If you can’t, use noncombat means to kill it. 
        /// -attack with something able to withstand 2 damage. 
        /// -Then play something that had low health to begin with to dodge Repentance. 
        /// 
        ///secret strategys hunter
        /// - kill enemys with your minions with 2 or less heal.
        ///  - Use the smallest minion available for the first attack 
        ///  - Then smack them in the face with whatever’s left. 
        ///  - If nothing triggered until then, it’s a Snipe, so throw something in front of it that won’t die or is expendable.
        /// 
        ///secret strategys mage
        /// - Play a small minion to trigger Mirror Entity.
        /// Then attack the mage directly with the smallest minion on your side. 
        /// If nothing triggered by that point, it’s either Spellbender or Counterspell, so hold your spells until you can (and have to!) deal with either. 

        private int getPlayCardSecretPenality(CardDB.Card c, Playfield p)
        {
            int pen = 0;
            if (p.enemySecretCount == 0)
            {
                return 0;
            }


            bool hasHighHealthMinion = false;

            if (c.name == CardDB.cardName.flare || c.name == CardDB.cardName.kezanmystic || c.name == CardDB.cardName.eaterofsecrets)
            {
                if (p.playactions.Count >= 1) return 100;
                return 0;
            }
            else
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.flare && hc.canplayCard(p)) return 100 * p.enemySecretCount;
                    if (hc.card.name == CardDB.cardName.kezanmystic && hc.canplayCard(p)) return 50;
                    if (hc.card.name == CardDB.cardName.eaterofsecrets && hc.canplayCard(p)) return 100 * p.enemySecretCount;

                    if (hc.card.type == CardDB.cardtype.MOB && hc.card.Health > 4 && hc.canplayCard(p)) hasHighHealthMinion = true;
                }
            }

            int attackedbefore = 0;
            int canattack = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1)
                {
                    attackedbefore++;
                }
                if (mnn.Ready && mnn.Angr > 0 && !mnn.frozen)
                {
                    canattack++;
                }
            }

            // only penalize for playing cards if we have better options
            if (p.enemyHeroName == HeroEnum.hunter)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    if (attackedbefore == 0 && canattack > 0) pen += 10;
                    if (c.Health <= 4 && hasHighHealthMinion) pen += 10;
                    if (c.Health <= 4 && c.deathrattle && c.name != CardDB.cardName.darnassusaspirant && c.name != CardDB.cardName.dancingswords) pen -= 5;
                }
            }

            if (p.enemyHeroName == HeroEnum.mage)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.tank,
                        name = c.name
                    };

                    // play first the small minion:
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsPlayedThisTurn == 0)
                        || (p.mobsPlayedThisTurn == 0 && attackedbefore >= 1))
                    {
                        pen += 10;
                    }
                }

                // should not penalize playing spells unless 1) we know we have other options, and 2) we know it's a high value spell
                //if (c.type == CardDB.cardtype.SPELL && p.cardsPlayedThisTurn == p.mobsplayedThisTurn)
                //{
                //    pen += 10;
                //}
            }

            if (p.enemyHeroName == HeroEnum.pala)
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    Minion m = new Minion
                    {
                        Hp = c.Health,
                        maxHp = c.Health,
                        Angr = c.Attack,
                        taunt = c.tank,
                        name = c.name
                    };
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsPlayedThisTurn == 0) || (attackedbefore == 0 && canattack > 0))
                    {
                        pen += 10;
                    }
                }
            }

            return pen;
        }

        private int getAttackSecretPenality(Minion m, Playfield p, Minion target)
        {
            if (p.enemySecretCount == 0)
            {
                return 0;
            }

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.name == CardDB.cardName.flare && hc.canplayCard(p)) return 100 * p.enemySecretCount;
                if (hc.card.name == CardDB.cardName.kezanmystic && hc.canplayCard(p)) return 50;
                if (hc.card.name == CardDB.cardName.eaterofsecrets && hc.canplayCard(p)) return 100 * p.enemySecretCount;
            }

            int pen = 0;

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1) attackedbefore++;
            }

            if (p.enemyHeroName == HeroEnum.hunter)
            {
                bool islow = isOwnLowest(m, p);
                if (attackedbefore == 0 && islow) pen -= 20;
                if (attackedbefore == 0 && !islow) pen += 10;

                if (target.isHero && !target.own && p.enemyMinions.Count >= 1)
                {
                    if (hasMinionsWithLowHeal(p)) pen += 10; //penality if we didn't attack minions before
                }
            }

            if (p.enemyHeroName == HeroEnum.mage)
            {
                if (p.mobsPlayedThisTurn == 0) pen += 10;

                bool islow = isOwnLowest(m, p);

                if (target.isHero && !target.own && !islow)
                {
                    pen += 10;
                }
                if (target.isHero && !target.own && islow && p.mobsPlayedThisTurn >= 1)
                {
                    pen -= 20;
                }

            }

            if (p.enemyHeroName == HeroEnum.pala)
            {

                bool islow = isOwnLowest(m, p);

                if (!target.own && !target.isHero && attackedbefore == 0)
                {
                    bool isEnemLow = isEnemyLowest(target, p);
                    if (!isEnemLow || m.Hp <= 2) pen += 5;
                    if (isEnemLow) pen -= 5;  // encourage attacking weakest enemy
                    if (m.Hp > 2) pen -= 5;
                }

                if (target.isHero && !target.own && !islow)
                {
                    pen += 5;
                }

                if (target.isHero && !target.own && p.enemyMinions.Count >= 1 && attackedbefore == 0)
                {
                    pen += 5;
                }

            }


            return pen;
        }

        private int getPlayPenalty(CardDB.cardName name, Playfield p, int choice)
        {
            switch (name)
            {
                case CardDB.cardName.brannbronzebeard: //play brann before good battlecries
                    return p.playactions.Find(a => a.actionType == actionEnum.playcard && a.card.card.battlecry && a.card.card.name != CardDB.cardName.flameimp) != null ? 20 : 0;
                case CardDB.cardName.dream:
                    return 6;
                case CardDB.cardName.reliquaryseeker:
                    return (p.ownMinions.Count == 6) ? 0 : 5;
                case CardDB.cardName.silverwaregolem:
                    return 10 + p.owncards.Count;
                case CardDB.cardName.malchezaarsimp:
                    return 5;
                case CardDB.cardName.scavenginghyena: //play hyena before attacking with beasts
                    return p.playactions.Find(a => a.actionType == actionEnum.attackWithMinion && a.own.handcard.card.race == TAG_RACE.PET) != null ? 20 : 0;
                case CardDB.cardName.maelstromportal:
                    return -5;
                case CardDB.cardName.netherspitehistorian:
                    return -8;
                case CardDB.cardName.lunarvisions:
                    return (p.owncards.Count > 7) ? 5 : 0;
                case CardDB.cardName.grimestreetprotector:
                case CardDB.cardName.defenderofargus:
                case CardDB.cardName.sunfuryprotector:
                    if (p.ownMinions.Count == 0) return 50;
                    if (p.ownMinions.Count == 1) return 40;
                    return 0;
                case CardDB.cardName.jadeidol:
                    if (choice == 1 && !Hrtprozis.Instance.turnDeck.ContainsKey(CardDB.cardIDEnum.CFM_602)) return 50; //don't waste our last copy
                    if (choice == 2 && Hrtprozis.Instance.turnDeck.ContainsKey(CardDB.cardIDEnum.CFM_602)) return 50; //don't shuffle more in if some still in deck
                    return 0;
                case CardDB.cardName.twilightguardian: //penalty if no dragon in hand
                    return p.owncards.Find(c => c.card.race == TAG_RACE.DRAGON) != null ? 10 : 0;
                case CardDB.cardName.bloodsailcultist:
                    if (p.playactions.Find(a => a.actionType == actionEnum.attackWithHero) != null && p.ownWeaponDurability > 0) return 20;
                    if (p.ownWeaponDurability == 0 || p.ownMinions.Find(m => m.handcard.card.race == TAG_RACE.PIRATE) == null) return 20;
                    return 0;
                default:
                    return 0;
            }
        }





        private int getValueOfMinion(Minion m)
        {
            int ret = 0;
            ret += 2 * m.Angr + m.Hp;
            if (m.taunt) ret += 2;
            if (this.priorityDatabase.ContainsKey(m.name)) ret += 20 + priorityDatabase[m.name];
            return ret;
        }

        private bool isOwnLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            int val = getValueOfMinion(mnn);
            foreach (Minion m in p.ownMinions)
            {
                if (!m.Ready) continue;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool isOwnLowestInHand(Minion mnn, Playfield p)
        {
            bool ret = true;
            Minion m = new Minion();
            int val = getValueOfMinion(mnn);
            foreach (Handmanager.Handcard card in p.owncards)
            {
                if (card.card.type != CardDB.cardtype.MOB) continue;
                CardDB.Card c = card.card;
                m.Hp = c.Health;
                m.maxHp = c.Health;
                m.Angr = c.Attack;
                m.taunt = c.tank;
                m.name = c.name;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private int getValueOfEnemyMinion(Minion m)
        {
            int ret = 0;
            ret += m.Hp;
            if (m.taunt) ret -= 2;
            return ret;
        }

        private bool isEnemyLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            List<Minion> litt = p.getAttackTargets(true);
            int val = getValueOfEnemyMinion(mnn);
            foreach (Minion m in p.enemyMinions)
            {
                if (litt.Find(x => x.entityID == m.entityID) == null) continue;
                if (getValueOfEnemyMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool hasMinionsWithLowHeal(Playfield p)
        {
            bool ret = false;
            foreach (Minion m in p.ownMinions)
            {
                if (m.Hp <= 2 && ((m.Ready && m.Angr > 0 && !m.frozen) || this.priorityDatabase.ContainsKey(m.name))) ret = true;
            }
            return ret;
        }

        private void setupEnrageDatabase()
        {
            enrageDatabase.Add(CardDB.cardName.amaniberserker, 0);
            enrageDatabase.Add(CardDB.cardName.angrychicken, 0);
            enrageDatabase.Add(CardDB.cardName.grommashhellscream, 0);
            enrageDatabase.Add(CardDB.cardName.ragingworgen, 0);
            enrageDatabase.Add(CardDB.cardName.spitefulsmith, 0);
            enrageDatabase.Add(CardDB.cardName.taurenwarrior, 0);
            enrageDatabase.Add(CardDB.cardName.warbot, 0);
            enrageDatabase.Add(CardDB.cardName.aberrantberserker, 2);
            enrageDatabase.Add(CardDB.cardName.bloodhoofbrave, 3);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(CardDB.cardName.holynova, 2);//to all friends
            HealAllDatabase.Add(CardDB.cardName.circleofhealing, 4);//all minions
            HealAllDatabase.Add(CardDB.cardName.darkscalehealer, 2);//all friends
            HealAllDatabase.Add(CardDB.cardName.treeoflife, 100);//all chars to max

            HealHeroDatabase.Add(CardDB.cardName.drainlife, 2);//tohero
            HealHeroDatabase.Add(CardDB.cardName.guardianofkings, 6);//tohero
            HealHeroDatabase.Add(CardDB.cardName.holyfire, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.priestessofelune, 4);//tohero
            HealHeroDatabase.Add(CardDB.cardName.sacrificialpact, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.siphonsoul, 3); //tohero
            HealHeroDatabase.Add(CardDB.cardName.sealoflight, 4); //tohero
            HealHeroDatabase.Add(CardDB.cardName.antiquehealbot, 8); //tohero
            HealHeroDatabase.Add(CardDB.cardName.renojackson, 30); //tohero
            HealHeroDatabase.Add(CardDB.cardName.tuskarrjouster, 7);
            HealHeroDatabase.Add(CardDB.cardName.tournamentmedic, 2);
            HealHeroDatabase.Add(CardDB.cardName.refreshmentvendor, 4);
            HealHeroDatabase.Add(CardDB.cardName.cultapothecary, 2);
            HealHeroDatabase.Add(CardDB.cardName.twilightdarkmender, 10);
            HealHeroDatabase.Add(CardDB.cardName.ivoryknight, 5); //heal = mana cost of discovered spell

            HealTargetDatabase.Add(CardDB.cardName.lightofthenaaru, 3);
            HealTargetDatabase.Add(CardDB.cardName.ancestralhealing, 3);
            HealTargetDatabase.Add(CardDB.cardName.ancientsecrets, 5);
            HealTargetDatabase.Add(CardDB.cardName.holylight, 6);
            HealTargetDatabase.Add(CardDB.cardName.earthenringfarseer, 3);
            HealTargetDatabase.Add(CardDB.cardName.healingtouch, 8);
            HealTargetDatabase.Add(CardDB.cardName.layonhands, 8);
            HealTargetDatabase.Add(CardDB.cardName.lesserheal, 2);
            HealTargetDatabase.Add(CardDB.cardName.voodoodoctor, 2);
            HealTargetDatabase.Add(CardDB.cardName.willofmukla, 8);
            HealTargetDatabase.Add(CardDB.cardName.ancientoflore, 5);
            HealTargetDatabase.Add(CardDB.cardName.healingwave, 14);
            HealTargetDatabase.Add(CardDB.cardName.heal, 4);
            HealTargetDatabase.Add(CardDB.cardName.flashheal, 5);
            HealTargetDatabase.Add(CardDB.cardName.darkshirealchemist, 5);
            HealTargetDatabase.Add(CardDB.cardName.forbiddenhealing, 2);//heal = 2x mana spent
            HealTargetDatabase.Add(CardDB.cardName.moongladeportal, 5);
            HealTargetDatabase.Add(CardDB.cardName.greaterhealingpotion, 12); //to friendly char
            HealTargetDatabase.Add(CardDB.cardName.jinyuwaterspeaker, 6);
            HealTargetDatabase.Add(CardDB.cardName.gadgetzansocialite, 2);
            HealTargetDatabase.Add(CardDB.cardName.hozenhealer, 30); //minion to full hp

            //HealTargetDatabase.Add(CardDB.cardName.divinespirit, 2);
        }

        private void setupDamageDatabase()
        {
            //DamageAllDatabase.Add(CardDB.cardName.flameleviathan, 2);
            DamageAllDatabase.Add(CardDB.cardName.abomination, 2);
            DamageAllDatabase.Add(CardDB.cardName.barongeddon, 2);
            DamageAllDatabase.Add(CardDB.cardName.demonwrath, 2);
            DamageAllDatabase.Add(CardDB.cardName.dreadinfernal, 1);
            DamageAllDatabase.Add(CardDB.cardName.dreadscale, 1);
            DamageAllDatabase.Add(CardDB.cardName.elementaldestruction, 4);
            DamageAllDatabase.Add(CardDB.cardName.excavatedevil, 3);
            DamageAllDatabase.Add(CardDB.cardName.explosivesheep, 2);
            DamageAllDatabase.Add(CardDB.cardName.hellfire, 3);
            DamageAllDatabase.Add(CardDB.cardName.lava, 2);
            DamageAllDatabase.Add(CardDB.cardName.lightbomb, 5);
            DamageAllDatabase.Add(CardDB.cardName.magmapulse, 1);
            DamageAllDatabase.Add(CardDB.cardName.revenge, 1);
            DamageAllDatabase.Add(CardDB.cardName.scarletpurifier, 2);
            DamageAllDatabase.Add(CardDB.cardName.unstableghoul, 1);
            DamageAllDatabase.Add(CardDB.cardName.whirlwind, 1);
            DamageAllDatabase.Add(CardDB.cardName.yseraawakens, 5);
            DamageAllDatabase.Add(CardDB.cardName.anomalus, 8);
            DamageAllDatabase.Add(CardDB.cardName.ravagingghoul, 1);
            DamageAllDatabase.Add(CardDB.cardName.tentacleofnzoth, 1);
            DamageAllDatabase.Add(CardDB.cardName.volcanicpotion, 2);
            DamageAllDatabase.Add(CardDB.cardName.dragonfirepotion, 5);
            DamageAllDatabase.Add(CardDB.cardName.felfirepotion, 5);
            DamageAllDatabase.Add(CardDB.cardName.abyssalenforcer, 3);
            DamageAllDatabase.Add(CardDB.cardName.sleepwiththefishes, 3);


            DamageAllEnemysDatabase.Add(CardDB.cardName.arcaneexplosion, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.bladeflurry, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.blizzard, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.consecration, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.fanofknives, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.flamestrike, 4);
            DamageAllEnemysDatabase.Add(CardDB.cardName.holynova, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.lightningstorm, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.locustswarm, 3);
            DamageAllEnemysDatabase.Add(CardDB.cardName.shadowflame, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.sporeburst, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.starfall, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.stomp, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.swipe, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.darkironskulker, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.livingbomb, 5);
            DamageAllEnemysDatabase.Add(CardDB.cardName.poisoncloud, 1);//todo 1 or 2
            DamageAllEnemysDatabase.Add(CardDB.cardName.cthun, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.twilightflamecaller, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.maelstromportal, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.sergeantsally, 1);// dmg = ap


            DamageHeroDatabase.Add(CardDB.cardName.curseofrafaam, 2);
            DamageHeroDatabase.Add(CardDB.cardName.headcrack, 2);
            DamageHeroDatabase.Add(CardDB.cardName.lepergnome, 2);
            DamageHeroDatabase.Add(CardDB.cardName.mindblast, 5);
            DamageHeroDatabase.Add(CardDB.cardName.nightblade, 3);
            DamageHeroDatabase.Add(CardDB.cardName.purecold, 8);
            DamageHeroDatabase.Add(CardDB.cardName.shadowbomber, 3);
            DamageHeroDatabase.Add(CardDB.cardName.sinisterstrike, 3);
            DamageHeroDatabase.Add(CardDB.cardName.frostblast, 3);
            DamageHeroDatabase.Add(CardDB.cardName.necroticaura, 3);
            DamageHeroDatabase.Add(CardDB.cardName.backstreetleper, 2);


            DamageRandomDatabase.Add(CardDB.cardName.arcanemissiles, 1);
            DamageRandomDatabase.Add(CardDB.cardName.avengingwrath, 1);
            DamageRandomDatabase.Add(CardDB.cardName.bomblobber, 4);
            DamageRandomDatabase.Add(CardDB.cardName.boombot, 1);
            DamageRandomDatabase.Add(CardDB.cardName.bouncingblade, 1);
            DamageRandomDatabase.Add(CardDB.cardName.cleave, 2);
            DamageRandomDatabase.Add(CardDB.cardName.demolisher, 2);
            DamageRandomDatabase.Add(CardDB.cardName.flamecannon, 4);
            DamageRandomDatabase.Add(CardDB.cardName.flamejuggler, 1);
            DamageRandomDatabase.Add(CardDB.cardName.flamewaker, 2);
            DamageRandomDatabase.Add(CardDB.cardName.forkedlightning, 2);
            DamageRandomDatabase.Add(CardDB.cardName.goblinblastmage, 1);
            DamageRandomDatabase.Add(CardDB.cardName.hugetoad, 1);
            DamageRandomDatabase.Add(CardDB.cardName.knifejuggler, 1);
            DamageRandomDatabase.Add(CardDB.cardName.madbomber, 1);
            DamageRandomDatabase.Add(CardDB.cardName.madderbomber, 1);
            DamageRandomDatabase.Add(CardDB.cardName.multishot, 3);
            DamageRandomDatabase.Add(CardDB.cardName.ragnarosthefirelord, 8);
            DamageRandomDatabase.Add(CardDB.cardName.rumblingelemental, 1);
            DamageRandomDatabase.Add(CardDB.cardName.shadowboxer, 1);
            DamageRandomDatabase.Add(CardDB.cardName.shipscannon, 2);
            DamageRandomDatabase.Add(CardDB.cardName.boombotjr, 1);
            DamageRandomDatabase.Add(CardDB.cardName.dieinsect, 8);
            DamageRandomDatabase.Add(CardDB.cardName.dieinsects, 8);
            DamageRandomDatabase.Add(CardDB.cardName.throwrocks, 3);
            DamageRandomDatabase.Add(CardDB.cardName.fierybat, 1);
            DamageRandomDatabase.Add(CardDB.cardName.spreadingmadness, 1);
            DamageRandomDatabase.Add(CardDB.cardName.greaterarcanemissiles, 9);


            DamageTargetDatabase.Add(CardDB.cardName.keeperofthegrove, 2); // or silence
            DamageTargetDatabase.Add(CardDB.cardName.arcaneblast, 2);
            DamageTargetDatabase.Add(CardDB.cardName.arcaneshot, 2);
            DamageTargetDatabase.Add(CardDB.cardName.backstab, 2);
            DamageTargetDatabase.Add(CardDB.cardName.barreltoss, 2);
            DamageTargetDatabase.Add(CardDB.cardName.betrayal, 2);
            DamageTargetDatabase.Add(CardDB.cardName.blackwingcorruptor, 3);//if dragon in hand
            DamageTargetDatabase.Add(CardDB.cardName.blizzard, 2);
            DamageTargetDatabase.Add(CardDB.cardName.cobrashot, 3);
            DamageTargetDatabase.Add(CardDB.cardName.coneofcold, 1);
            DamageTargetDatabase.Add(CardDB.cardName.crackle, 3);
            DamageTargetDatabase.Add(CardDB.cardName.damage1, 1);
            DamageTargetDatabase.Add(CardDB.cardName.damage5, 5);
            DamageTargetDatabase.Add(CardDB.cardName.darkbomb, 3);
            DamageTargetDatabase.Add(CardDB.cardName.dragonsbreath, 4);
            DamageTargetDatabase.Add(CardDB.cardName.drainlife, 2);
            DamageTargetDatabase.Add(CardDB.cardName.elvenarcher, 1);
            DamageTargetDatabase.Add(CardDB.cardName.eviscerate, 2);
            DamageTargetDatabase.Add(CardDB.cardName.explosiveshot, 5);
            DamageTargetDatabase.Add(CardDB.cardName.felcannon, 2);
            DamageTargetDatabase.Add(CardDB.cardName.fireball, 6);
            DamageTargetDatabase.Add(CardDB.cardName.fireblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.fireblastrank2, 2);
            DamageTargetDatabase.Add(CardDB.cardName.fireelemental, 3);
            DamageTargetDatabase.Add(CardDB.cardName.flamelance, 5);// i know its 8 :D
            DamageTargetDatabase.Add(CardDB.cardName.forgottentorch, 3);
            DamageTargetDatabase.Add(CardDB.cardName.frostbolt, 3);
            DamageTargetDatabase.Add(CardDB.cardName.frostshock, 1);
            DamageTargetDatabase.Add(CardDB.cardName.gormoktheimpaler, 4);
            DamageTargetDatabase.Add(CardDB.cardName.hoggersmash, 4);
            DamageTargetDatabase.Add(CardDB.cardName.holyfire, 5);
            DamageTargetDatabase.Add(CardDB.cardName.holysmite, 2);
            DamageTargetDatabase.Add(CardDB.cardName.icelance, 4);//only if iced
            DamageTargetDatabase.Add(CardDB.cardName.implosion, 2);
            DamageTargetDatabase.Add(CardDB.cardName.ironforgerifleman, 1);
            DamageTargetDatabase.Add(CardDB.cardName.killcommand, 3);//or 5
            DamageTargetDatabase.Add(CardDB.cardName.lavaburst, 5);
            DamageTargetDatabase.Add(CardDB.cardName.lightningbolt, 3);
            DamageTargetDatabase.Add(CardDB.cardName.lightningjolt, 2);
            DamageTargetDatabase.Add(CardDB.cardName.livingroots, 2);//choice 1
            DamageTargetDatabase.Add(CardDB.cardName.mindshatter, 3);
            DamageTargetDatabase.Add(CardDB.cardName.mindspike, 2);
            DamageTargetDatabase.Add(CardDB.cardName.moonfire, 1);
            DamageTargetDatabase.Add(CardDB.cardName.mortalcoil, 1);
            DamageTargetDatabase.Add(CardDB.cardName.mortalstrike, 4);
            DamageTargetDatabase.Add(CardDB.cardName.northseakraken, 4);
            DamageTargetDatabase.Add(CardDB.cardName.perditionsblade, 1);
            DamageTargetDatabase.Add(CardDB.cardName.powershot, 2);
            DamageTargetDatabase.Add(CardDB.cardName.pyroblast, 10);
            DamageTargetDatabase.Add(CardDB.cardName.quickshot, 3);//brmcard
            DamageTargetDatabase.Add(CardDB.cardName.roaringtorch, 6);
            DamageTargetDatabase.Add(CardDB.cardName.shadowbolt, 4);
            DamageTargetDatabase.Add(CardDB.cardName.shadowform, 2);
            DamageTargetDatabase.Add(CardDB.cardName.shotgunblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.si7agent, 2);
            DamageTargetDatabase.Add(CardDB.cardName.starfall, 5);//2 to all enemy
            DamageTargetDatabase.Add(CardDB.cardName.starfire, 5);//draw a card
            DamageTargetDatabase.Add(CardDB.cardName.steadyshot, 2);//or 1 + card
            DamageTargetDatabase.Add(CardDB.cardName.stormpikecommando, 2);
            DamageTargetDatabase.Add(CardDB.cardName.swipe, 4);//1 to others
            DamageTargetDatabase.Add(CardDB.cardName.undercityvaliant, 1);
            DamageTargetDatabase.Add(CardDB.cardName.wrath, 1);//todo 3 or 1+card
            DamageTargetDatabase.Add(CardDB.cardName.sonicbreath, 3);
            DamageTargetDatabase.Add(CardDB.cardName.ballistashot, 3);
            DamageTargetDatabase.Add(CardDB.cardName.unbalancingstrike, 3);
            DamageTargetDatabase.Add(CardDB.cardName.discipleofcthun, 2);
            DamageTargetDatabase.Add(CardDB.cardName.firebloomtoxin, 2);
            DamageTargetDatabase.Add(CardDB.cardName.forbiddenflame, 1); //dmg = mana spent
            DamageTargetDatabase.Add(CardDB.cardName.onthehunt, 1);
            DamageTargetDatabase.Add(CardDB.cardName.shadowstrike, 5);
            DamageTargetDatabase.Add(CardDB.cardName.stormcrack, 4);
            DamageTargetDatabase.Add(CardDB.cardName.firelandsportal, 5);
            DamageTargetDatabase.Add(CardDB.cardName.dispatchkodo, 2); //dmg = ap
            DamageTargetDatabase.Add(CardDB.cardName.jadeshuriken, 2);
            DamageTargetDatabase.Add(CardDB.cardName.jadelightning, 4);
            DamageTargetDatabase.Add(CardDB.cardName.blowgillsniper, 1);
            DamageTargetDatabase.Add(CardDB.cardName.bombsquad, 5);


            DamageTargetSpecialDatabase.Add(CardDB.cardName.bash, 3); //+3 armor
            DamageTargetSpecialDatabase.Add(CardDB.cardName.crueltaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.cardName.deathbloom, 5);
            DamageTargetSpecialDatabase.Add(CardDB.cardName.demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(CardDB.cardName.demonheart, 5);
            DamageTargetSpecialDatabase.Add(CardDB.cardName.earthshock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(CardDB.cardName.hammerofwrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.holywrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.innerrage, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.cardName.lavashock, 2); //erases overload
            DamageTargetSpecialDatabase.Add(CardDB.cardName.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shieldslam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(CardDB.cardName.soulfire, 4);//delete a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.quickshot, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.bloodtoichor, 1); 
            DamageTargetSpecialDatabase.Add(CardDB.cardName.baneofdoom, 2); 
        }

        private void setupsilenceDatabase()
        {
            silenceDatabase.Add(CardDB.cardName.dispel, 1);
            silenceDatabase.Add(CardDB.cardName.earthshock, 1);
            silenceDatabase.Add(CardDB.cardName.massdispel, 1); //enemy minions
            silenceDatabase.Add(CardDB.cardName.silence, 1);
            silenceDatabase.Add(CardDB.cardName.keeperofthegrove, 1);
            silenceDatabase.Add(CardDB.cardName.ironbeakowl, 1);
            silenceDatabase.Add(CardDB.cardName.spellbreaker, 1);
            silenceDatabase.Add(CardDB.cardName.lightschampion, 1); //a demon
            silenceDatabase.Add(CardDB.cardName.purify, 1); //a friendly minion
            silenceDatabase.Add(CardDB.cardName.kabalsongstealer, 1);
            silenceDatabase.Add(CardDB.cardName.defiascleaner, 1); //a deathrattle minion
            silenceDatabase.Add(CardDB.cardName.wailingsoul, 1); //your minions
        }

        private void setupPriorityList()
        {
            priorityDatabase.Add(CardDB.cardName.acidmaw, 3);
            priorityDatabase.Add(CardDB.cardName.alakirthewindlord, 4);
            priorityDatabase.Add(CardDB.cardName.animatedarmor, 2);
            priorityDatabase.Add(CardDB.cardName.archmageantonidas, 10);
            priorityDatabase.Add(CardDB.cardName.armorsmith, 1);
            priorityDatabase.Add(CardDB.cardName.auchenaisoulpriest, 2);
            priorityDatabase.Add(CardDB.cardName.aviana, 5);
            priorityDatabase.Add(CardDB.cardName.brannbronzebeard, 4);
            priorityDatabase.Add(CardDB.cardName.bloodmagethalnos, 2);
            priorityDatabase.Add(CardDB.cardName.buccaneer, 2);
            priorityDatabase.Add(CardDB.cardName.cloakedhuntress, 5);
            priorityDatabase.Add(CardDB.cardName.coldarradrake, 2);
            priorityDatabase.Add(CardDB.cardName.confessorpaletress, 7);
            priorityDatabase.Add(CardDB.cardName.crowdfavorite, 6);
            priorityDatabase.Add(CardDB.cardName.cultmaster, 3);
            priorityDatabase.Add(CardDB.cardName.cutpurse, 2);
            priorityDatabase.Add(CardDB.cardName.dalaranaspirant, 4);
            priorityDatabase.Add(CardDB.cardName.darkshirecouncilman, 4);
            priorityDatabase.Add(CardDB.cardName.dementedfrostcaller, 2);
            priorityDatabase.Add(CardDB.cardName.demolisher, 1);
            priorityDatabase.Add(CardDB.cardName.djinniofzephyrs, 4);
            priorityDatabase.Add(CardDB.cardName.direwolfalpha, 5);
            priorityDatabase.Add(CardDB.cardName.dragonhawkrider, 2);
            priorityDatabase.Add(CardDB.cardName.dustdevil, 1);
            priorityDatabase.Add(CardDB.cardName.emperorthaurissan, 5);
            priorityDatabase.Add(CardDB.cardName.etherealarcanist, 3);
            priorityDatabase.Add(CardDB.cardName.fandralstaghelm, 6);
            priorityDatabase.Add(CardDB.cardName.flametonguetotem, 6);
            priorityDatabase.Add(CardDB.cardName.flesheatingghoul, 1);
            priorityDatabase.Add(CardDB.cardName.flamewaker, 5);
            priorityDatabase.Add(CardDB.cardName.frothingberserker, 3);
            priorityDatabase.Add(CardDB.cardName.gadgetzanauctioneer, 5);
            priorityDatabase.Add(CardDB.cardName.garrisoncommander, 1);
            priorityDatabase.Add(CardDB.cardName.grimpatron, 5);
            priorityDatabase.Add(CardDB.cardName.grimscaleoracle, 5);
            priorityDatabase.Add(CardDB.cardName.grommashhellscream, 4);
            priorityDatabase.Add(CardDB.cardName.hallazealtheascended, 4);
            priorityDatabase.Add(CardDB.cardName.hogger, 4);
            priorityDatabase.Add(CardDB.cardName.holychampion, 5);
            priorityDatabase.Add(CardDB.cardName.hoodedacolyte, 2);
            priorityDatabase.Add(CardDB.cardName.illidanstormrage, 4);
            priorityDatabase.Add(CardDB.cardName.knifejuggler, 4);
            priorityDatabase.Add(CardDB.cardName.kodorider, 6);
            priorityDatabase.Add(CardDB.cardName.kvaldirraider, 1);
            priorityDatabase.Add(CardDB.cardName.leokk, 5);
            priorityDatabase.Add(CardDB.cardName.lightspawn, 4);
            priorityDatabase.Add(CardDB.cardName.maidenofthelake, 2);
            priorityDatabase.Add(CardDB.cardName.malchezaarsimp, 1);
            priorityDatabase.Add(CardDB.cardName.malganis, 10);
            priorityDatabase.Add(CardDB.cardName.malygos, 10);
            priorityDatabase.Add(CardDB.cardName.manaaddict, 1);
            priorityDatabase.Add(CardDB.cardName.manatidetotem, 5);
            priorityDatabase.Add(CardDB.cardName.manawyrm, 1);
            priorityDatabase.Add(CardDB.cardName.masterswordsmith, 1);
            priorityDatabase.Add(CardDB.cardName.mechwarper, 1);
            priorityDatabase.Add(CardDB.cardName.moroes, 10);
            priorityDatabase.Add(CardDB.cardName.muklaschampion, 5);
            priorityDatabase.Add(CardDB.cardName.murlocknight, 5);
            priorityDatabase.Add(CardDB.cardName.murloctidecaller, 2);
            priorityDatabase.Add(CardDB.cardName.murlocwarleader, 5);
            priorityDatabase.Add(CardDB.cardName.natpagle, 2);
            priorityDatabase.Add(CardDB.cardName.nexuschampionsaraad, 6);
            priorityDatabase.Add(CardDB.cardName.northshirecleric, 5);
            priorityDatabase.Add(CardDB.cardName.obsidiandestroyer, 4);
            priorityDatabase.Add(CardDB.cardName.orgrimmaraspirant, 2);
            priorityDatabase.Add(CardDB.cardName.pintsizedsummoner, 3);
            priorityDatabase.Add(CardDB.cardName.priestofthefeast, 3);
            priorityDatabase.Add(CardDB.cardName.prophetvelen, 5);
            priorityDatabase.Add(CardDB.cardName.questingadventurer, 4);
            priorityDatabase.Add(CardDB.cardName.ragnaroslightlord, 5);
            priorityDatabase.Add(CardDB.cardName.raidleader, 5);
            priorityDatabase.Add(CardDB.cardName.recruiter, 1);
            priorityDatabase.Add(CardDB.cardName.rumblingelemental, 2);
            priorityDatabase.Add(CardDB.cardName.savagecombatant, 5);
            priorityDatabase.Add(CardDB.cardName.scalednightmare, 4);
            priorityDatabase.Add(CardDB.cardName.scavenginghyena, 5);
            priorityDatabase.Add(CardDB.cardName.secretkeeper, 1);
            priorityDatabase.Add(CardDB.cardName.shadowfiend, 3);
            priorityDatabase.Add(CardDB.cardName.sorcerersapprentice, 3);
            priorityDatabase.Add(CardDB.cardName.southseacaptain, 5);
            priorityDatabase.Add(CardDB.cardName.stormwindchampion, 5);
            priorityDatabase.Add(CardDB.cardName.summoningportal, 5);
            priorityDatabase.Add(CardDB.cardName.summoningstone, 5);
            priorityDatabase.Add(CardDB.cardName.tournamentmedic, 2);
            priorityDatabase.Add(CardDB.cardName.thunderbluffvaliant, 3);
            priorityDatabase.Add(CardDB.cardName.timberwolf, 3);
            priorityDatabase.Add(CardDB.cardName.tinyknightofevil, 1);
            priorityDatabase.Add(CardDB.cardName.tunneltrogg, 4);
            priorityDatabase.Add(CardDB.cardName.unboundelemental, 2);
            priorityDatabase.Add(CardDB.cardName.usherofsouls, 2);
            priorityDatabase.Add(CardDB.cardName.voidcrusher, 1);
            priorityDatabase.Add(CardDB.cardName.violetillusionist, 10);
            priorityDatabase.Add(CardDB.cardName.violetteacher, 1);
            priorityDatabase.Add(CardDB.cardName.warhorsetrainer, 5);
            priorityDatabase.Add(CardDB.cardName.warsongcommander, 2);
            priorityDatabase.Add(CardDB.cardName.wickedwitchdoctor, 3);
            priorityDatabase.Add(CardDB.cardName.wilfredfizzlebang, 5);
            priorityDatabase.Add(CardDB.cardName.ysera, 10);
            
            priorityDatabase.Add(CardDB.cardName.grimestreetenforcer, 10);
            priorityDatabase.Add(CardDB.cardName.shakuthecollector, 5);
            priorityDatabase.Add(CardDB.cardName.kabaltrafficker, 5);
            priorityDatabase.Add(CardDB.cardName.grimygadgeteer, 5);
            priorityDatabase.Add(CardDB.cardName.friendlybartender, 1);
            priorityDatabase.Add(CardDB.cardName.auctionmasterbeardo, 5);
            priorityDatabase.Add(CardDB.cardName.backroombouncer, 5);
            priorityDatabase.Add(CardDB.cardName.daringreporter, 1);
            priorityDatabase.Add(CardDB.cardName.burglybully, 3);
            priorityDatabase.Add(CardDB.cardName.redmanawyrm, 5);
        }

        private void setupAttackBuff()
        {
            heroAttackBuffDatabase.Add(CardDB.cardName.bite, 4);
            heroAttackBuffDatabase.Add(CardDB.cardName.claw, 2);
            heroAttackBuffDatabase.Add(CardDB.cardName.heroicstrike, 4);
            heroAttackBuffDatabase.Add(CardDB.cardName.evolvespines, 4);
            heroAttackBuffDatabase.Add(CardDB.cardName.feralrage, 4);

            attackBuffDatabase.Add(CardDB.cardName.abusivesergeant, 2);
            attackBuffDatabase.Add(CardDB.cardName.bananas, 1);
            attackBuffDatabase.Add(CardDB.cardName.bestialwrath, 2); // NEVER ON enemy MINION
            attackBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            attackBuffDatabase.Add(CardDB.cardName.blessingofmight, 3);
            attackBuffDatabase.Add(CardDB.cardName.bolster, 2);
            attackBuffDatabase.Add(CardDB.cardName.clockworkknight, 1);
            attackBuffDatabase.Add(CardDB.cardName.coldblood, 2);
            attackBuffDatabase.Add(CardDB.cardName.crueltaskmaster, 2);
            attackBuffDatabase.Add(CardDB.cardName.darkirondwarf, 2);
            attackBuffDatabase.Add(CardDB.cardName.darkwispers, 5); //choice 2
            attackBuffDatabase.Add(CardDB.cardName.demonfuse, 3);
            attackBuffDatabase.Add(CardDB.cardName.explorershat, 1);
            attackBuffDatabase.Add(CardDB.cardName.innerrage, 2);
            attackBuffDatabase.Add(CardDB.cardName.lancecarrier, 2);
            attackBuffDatabase.Add(CardDB.cardName.markofnature, 4); //choice 1 
            attackBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            attackBuffDatabase.Add(CardDB.cardName.metaltoothleaper, 2);
            attackBuffDatabase.Add(CardDB.cardName.nightmare, 5); //destroy minion on next turn
            attackBuffDatabase.Add(CardDB.cardName.rampage, 3); //only damaged minion 
            attackBuffDatabase.Add(CardDB.cardName.rockbiterweapon, 3);
            attackBuffDatabase.Add(CardDB.cardName.screwjankclunker, 2);
            attackBuffDatabase.Add(CardDB.cardName.sealofchampions, 3);
            attackBuffDatabase.Add(CardDB.cardName.uproot, 5);
            attackBuffDatabase.Add(CardDB.cardName.velenschosen, 2);
            attackBuffDatabase.Add(CardDB.cardName.whirlingblades, 1);
            attackBuffDatabase.Add(CardDB.cardName.briarthorntoxin, 3);
            attackBuffDatabase.Add(CardDB.cardName.divinestrength, 1);
            attackBuffDatabase.Add(CardDB.cardName.lanternofpower, 10);
            attackBuffDatabase.Add(CardDB.cardName.markofyshaarj, 2);
            attackBuffDatabase.Add(CardDB.cardName.mutatinginjection, 4);
            attackBuffDatabase.Add(CardDB.cardName.powerwordtentacles, 2);
            attackBuffDatabase.Add(CardDB.cardName.primalfusion, 1);
            attackBuffDatabase.Add(CardDB.cardName.silvermoonportal, 2);
            attackBuffDatabase.Add(CardDB.cardName.zoobot, 1);
            attackBuffDatabase.Add(CardDB.cardName.menageriemagician, 2);
            attackBuffDatabase.Add(CardDB.cardName.powerofthewild, 1); //choice 1
            attackBuffDatabase.Add(CardDB.cardName.markofthelotus, 1);
            attackBuffDatabase.Add(CardDB.cardName.virmensensei, 2); //to a beast
            attackBuffDatabase.Add(CardDB.cardName.shadowsensei, 2); //to a stealth
            attackBuffDatabase.Add(CardDB.cardName.bloodfurypotion, 3);
            attackBuffDatabase.Add(CardDB.cardName.crystalweaver, 1); //to demons
        }

        private void setupHealthBuff()
        {
            //healthBuffDatabase.Add(CardDB.cardName.ancientofwar, 5);//choice2 is only buffing himself!
            //healthBuffDatabase.Add(CardDB.cardName.rooted, 5);
            healthBuffDatabase.Add(CardDB.cardName.armorplating, 1);
            healthBuffDatabase.Add(CardDB.cardName.bananas, 1);
            healthBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            healthBuffDatabase.Add(CardDB.cardName.bolster, 2);
            healthBuffDatabase.Add(CardDB.cardName.clockworkknight, 1);
            healthBuffDatabase.Add(CardDB.cardName.competitivespirit, 1);
            healthBuffDatabase.Add(CardDB.cardName.darkwispers, 5);//choice2
            healthBuffDatabase.Add(CardDB.cardName.demonfuse, 3);
            healthBuffDatabase.Add(CardDB.cardName.explorershat, 1);
            healthBuffDatabase.Add(CardDB.cardName.markofnature, 4);//choice2
            healthBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            healthBuffDatabase.Add(CardDB.cardName.nightmare, 5);
            healthBuffDatabase.Add(CardDB.cardName.powerwordshield, 2);
            healthBuffDatabase.Add(CardDB.cardName.rampage, 3);
            healthBuffDatabase.Add(CardDB.cardName.screwjankclunker, 2);
            healthBuffDatabase.Add(CardDB.cardName.upgradedrepairbot, 4);
            healthBuffDatabase.Add(CardDB.cardName.velenschosen, 4);
            healthBuffDatabase.Add(CardDB.cardName.wildwalker, 3);
            healthBuffDatabase.Add(CardDB.cardName.divinestrength, 2);
            healthBuffDatabase.Add(CardDB.cardName.lanternofpower, 10);
            healthBuffDatabase.Add(CardDB.cardName.markofyshaarj, 2);
            healthBuffDatabase.Add(CardDB.cardName.mutatinginjection, 4);
            healthBuffDatabase.Add(CardDB.cardName.powerwordtentacles, 6);
            healthBuffDatabase.Add(CardDB.cardName.primalfusion, 1);
            healthBuffDatabase.Add(CardDB.cardName.silvermoonportal, 2);
            healthBuffDatabase.Add(CardDB.cardName.zoobot, 1);
            healthBuffDatabase.Add(CardDB.cardName.menageriemagician, 2);
            healthBuffDatabase.Add(CardDB.cardName.powerofthewild, 1); //choice 1
            healthBuffDatabase.Add(CardDB.cardName.markofthelotus, 1);
            healthBuffDatabase.Add(CardDB.cardName.virmensensei, 2); //to a beast
            healthBuffDatabase.Add(CardDB.cardName.shadowsensei, 2); //to a stealth
            healthBuffDatabase.Add(CardDB.cardName.bloodfurypotion, 3); //if demon
            healthBuffDatabase.Add(CardDB.cardName.crystalweaver, 1); //to demons
            healthBuffDatabase.Add(CardDB.cardName.kabaltalonpriest, 3);

            tauntBuffDatabase.Add(CardDB.cardName.markofnature, 1);
            tauntBuffDatabase.Add(CardDB.cardName.markofthewild, 1);
            tauntBuffDatabase.Add(CardDB.cardName.darkwispers, 1);
            tauntBuffDatabase.Add(CardDB.cardName.rustyhorn, 1);
            tauntBuffDatabase.Add(CardDB.cardName.mutatinginjection, 1);
            tauntBuffDatabase.Add(CardDB.cardName.ancestralhealing, 1);
            tauntBuffDatabase.Add(CardDB.cardName.sparringpartner, 1);
        }

        private void setupCardDrawBattlecry()
        {

            cardDrawBattleCryDatabase.Add(CardDB.cardName.solemnvigil, 2);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientoflore, 2);// choice =1
            cardDrawBattleCryDatabase.Add(CardDB.cardName.nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.grovetender, 1); //choice = 2

            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientteachings, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.flare, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.excessmana, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.starfire, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.azuredrake, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.coldlightoracle, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gnomishinventor, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.harrisonjones, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.noviceengineer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.arcaneintellect, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.hammerofwrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.holywrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.layonhands, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.massdispel, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.powerwordshield, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.fanofknives, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shiv, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.sprint, 4);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.farsight, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lifetap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.commandingshout, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shieldblock, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.slam, 1); //if survives
            cardDrawBattleCryDatabase.Add(CardDB.cardName.mortalcoil, 1);//only if kills
            cardDrawBattleCryDatabase.Add(CardDB.cardName.battlerage, 1);//only if wounded own minions
            cardDrawBattleCryDatabase.Add(CardDB.cardName.divinefavor, 1);//only if enemy has more cards than you

            cardDrawBattleCryDatabase.Add(CardDB.cardName.neptulon, 4);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gnomishexperimenter, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.unstableportal, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.callpet, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.grandcrusader, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.nexuschampionsaraad, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.spellslinger, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.burgle, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancestralknowledge, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.varianwrynn, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ambush, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.soultap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lockandload, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kingselekk, 1);  // only if we win joust

            cardDrawBattleCryDatabase.Add(CardDB.cardName.tinkertowntechnician, 1); // if we have a mech
            cardDrawBattleCryDatabase.Add(CardDB.cardName.toshley, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.maptothegoldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.goldenmonkey, 1); //no carddraw, but new cards

            cardDrawBattleCryDatabase.Add(CardDB.cardName.bloodwarriors, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.cabaliststome, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.darkshirelibrarian, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.flameheart, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kingsbloodtoxin, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.markofyshaarj, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.muklatyrantofthevale, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shadowcaster, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.thistletea, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.xarilpoisonedmind, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.babblingbook, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.thecurator, 1);
            
            cardDrawBattleCryDatabase.Add(CardDB.cardName.quickshot, 1);

            cardDrawBattleCryDatabase.Add(CardDB.cardName.fightpromoter, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.wrathion, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lunarvisions, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.smalltimerecruits, 3);


            
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.bloodmagethalnos, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.clockworkgnome, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.dancingswords, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.loothoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.mechanicalyeti, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.mechbearcat, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.tombpillager, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.toshley, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.webspinner, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.acolyteofpain, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.pollutedhoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.shiftingshade, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.undercityhuckster, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.xarilpoisonedmind, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.deadlyfork, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.runicegg, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.meanstreetmarshal, 1);



            //add discover minions
            foreach (CardDB.cardName discoverCard in this.discoverCards.Keys)
            {
                cardDrawBattleCryDatabase.Add(discoverCard, 1);
            }
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(CardDB.cardName.doomguard, 5);
            cardDiscardDatabase.Add(CardDB.cardName.soulfire, 0);
            cardDiscardDatabase.Add(CardDB.cardName.succubus, 2);
            cardDiscardDatabase.Add(CardDB.cardName.darkbargain, 2);
            cardDiscardDatabase.Add(CardDB.cardName.darkshirelibrarian, 1);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(CardDB.cardName.brawl, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.deathwing, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.twistingnether, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.doom, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.doomsayer, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.poisonseeds, 0); //replace all minions with 2/2 treants
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowwordhorror, 0); //all minions with 2 or less ap
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowflame, 0); //destroy own minion, deal its ap to all enemies
            this.destroyOwnDatabase.Add(CardDB.cardName.enterthecoliseum, 0);//all but each player's highest ap

            this.destroyOwnDatabase.Add(CardDB.cardName.naturalize, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowworddeath, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowwordpain, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.siphonsoul, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.biggamehunter, 0); //a minion ap>=7
            this.destroyOwnDatabase.Add(CardDB.cardName.hungrycrab, 0); //a murloc
            this.destroyOwnDatabase.Add(CardDB.cardName.sacrificialpact, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.mulch, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.bladeofcthun, 0); //add stats to c'thun
            this.destroyOwnDatabase.Add(CardDB.cardName.reincarnate, 0); //and resummon
            this.destroyOwnDatabase.Add(CardDB.cardName.voidterror, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.blastcrystalpotion, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.crush, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.hemetnesingwary, 0); //a beast
            this.destroyOwnDatabase.Add(CardDB.cardName.moatlurker, 0); //resummon deathrattle
            this.destroyOwnDatabase.Add(CardDB.cardName.rendblackhand, 0); //a legendary if holding dragon
            this.destroyOwnDatabase.Add(CardDB.cardName.shatter, 0); //frozen
            this.destroyOwnDatabase.Add(CardDB.cardName.execute, 0); //hurt


            this.destroyDatabase.Add(CardDB.cardName.brawl, 0);
            this.destroyDatabase.Add(CardDB.cardName.deathwing, 0);
            this.destroyDatabase.Add(CardDB.cardName.twistingnether, 0);
            this.destroyDatabase.Add(CardDB.cardName.doom, 0);
            this.destroyDatabase.Add(CardDB.cardName.doomsayer, 0);
            this.destroyDatabase.Add(CardDB.cardName.poisonseeds, 0); //replace all minions with 2/2 treants
            this.destroyDatabase.Add(CardDB.cardName.shadowwordhorror, 0); //all minions with 2 or less ap
            this.destroyDatabase.Add(CardDB.cardName.shadowflame, 0); //destroy own minion, deal its ap to all enemies
            this.destroyDatabase.Add(CardDB.cardName.enterthecoliseum, 0);//all but each player's highest ap

            this.destroyDatabase.Add(CardDB.cardName.assassinate, 0); //not own mins
            this.destroyDatabase.Add(CardDB.cardName.corruption, 0); //not own mins
            this.destroyDatabase.Add(CardDB.cardName.execute, 0); //hurt
            this.destroyDatabase.Add(CardDB.cardName.naturalize, 0);
            this.destroyDatabase.Add(CardDB.cardName.siphonsoul, 0);
            this.destroyDatabase.Add(CardDB.cardName.mindcontrol, 0); //not own mins
            this.destroyDatabase.Add(CardDB.cardName.theblackknight, 0); //not own mins
            this.destroyDatabase.Add(CardDB.cardName.sabotage, 0); //not own mins
            this.destroyDatabase.Add(CardDB.cardName.crush, 0);
            this.destroyDatabase.Add(CardDB.cardName.hemetnesingwary, 0); //a beast
            this.destroyDatabase.Add(CardDB.cardName.mulch, 0);
            this.destroyDatabase.Add(CardDB.cardName.bladeofcthun, 0); //add stats to c'thun
            this.destroyDatabase.Add(CardDB.cardName.shatter, 0); //frozen
            this.destroyDatabase.Add(CardDB.cardName.moatlurker, 0); //resummon deathrattle
            this.destroyDatabase.Add(CardDB.cardName.bookwyrm, 0); //enemy ap<=3
            this.destroyDatabase.Add(CardDB.cardName.deadlyshot, 0); //random enemy
            this.destroyDatabase.Add(CardDB.cardName.darkbargain, 0);
            this.destroyDatabase.Add(CardDB.cardName.rendblackhand, 0); //a legendary if holding dragon
            this.destroyDatabase.Add(CardDB.cardName.blastcrystalpotion, 0);


            this.backToHandDatabase.Add(CardDB.cardName.sap, 0);
            this.backToHandDatabase.Add(CardDB.cardName.timerewinder, 0);
            this.backToHandDatabase.Add(CardDB.cardName.ancientbrewmaster, 0);
            this.backToHandDatabase.Add(CardDB.cardName.dream, 0);
            this.backToHandDatabase.Add(CardDB.cardName.shadowstep, 0);
            this.backToHandDatabase.Add(CardDB.cardName.youthfulbrewmaster, 0);
            this.backToHandDatabase.Add(CardDB.cardName.kidnapper, 0);
            this.backToHandDatabase.Add(CardDB.cardName.recycle, 0);
            this.backToHandDatabase.Add(CardDB.cardName.vanish, 0);
            this.backToHandDatabase.Add(CardDB.cardName.bloodthistletoxin, 0);
            this.backToHandDatabase.Add(CardDB.cardName.gadgetzanferryman, 0); //combo

        }

        private void setupSpecialMins()
        {

            //== everything with an effect (other than battlecry and normal stuff like taunt, charge, divshield)
            //also deathrattles?
            // value used for hex/poly priority
            this.specialMinions.Add(CardDB.cardName.amaniberserker, 0);
            this.specialMinions.Add(CardDB.cardName.angrychicken, 0);
            this.specialMinions.Add(CardDB.cardName.abomination, 0);
            this.specialMinions.Add(CardDB.cardName.acolyteofpain, 0);
            this.specialMinions.Add(CardDB.cardName.alarmobot, 0);
            this.specialMinions.Add(CardDB.cardName.archmage, 0);
            this.specialMinions.Add(CardDB.cardName.archmageantonidas, 0);
            this.specialMinions.Add(CardDB.cardName.armorsmith, 0);
            this.specialMinions.Add(CardDB.cardName.auchenaisoulpriest, 0);
            this.specialMinions.Add(CardDB.cardName.azuredrake, 0);
            this.specialMinions.Add(CardDB.cardName.barongeddon, 0);
            this.specialMinions.Add(CardDB.cardName.bloodimp, 0);
            this.specialMinions.Add(CardDB.cardName.bloodmagethalnos, 0);
            this.specialMinions.Add(CardDB.cardName.cairnebloodhoof, 0);
            this.specialMinions.Add(CardDB.cardName.cultmaster, 0);
            this.specialMinions.Add(CardDB.cardName.dalaranmage, 0);
            this.specialMinions.Add(CardDB.cardName.demolisher, 0);
            this.specialMinions.Add(CardDB.cardName.direwolfalpha, 0);
            this.specialMinions.Add(CardDB.cardName.doomsayer, 0);
            this.specialMinions.Add(CardDB.cardName.emperorcobra, 0);
            this.specialMinions.Add(CardDB.cardName.etherealarcanist, 0);
            this.specialMinions.Add(CardDB.cardName.flametonguetotem, 0);
            this.specialMinions.Add(CardDB.cardName.flesheatingghoul, 0);
            this.specialMinions.Add(CardDB.cardName.gadgetzanauctioneer, 0);
            this.specialMinions.Add(CardDB.cardName.grimscaleoracle, 0);
            this.specialMinions.Add(CardDB.cardName.grommashhellscream, 0);
            this.specialMinions.Add(CardDB.cardName.gruul, 0);
            this.specialMinions.Add(CardDB.cardName.gurubashiberserker, 0);
            this.specialMinions.Add(CardDB.cardName.harvestgolem, 0);
            this.specialMinions.Add(CardDB.cardName.hogger, 0);
            this.specialMinions.Add(CardDB.cardName.illidanstormrage, 0);
            this.specialMinions.Add(CardDB.cardName.impmaster, 0);
            this.specialMinions.Add(CardDB.cardName.knifejuggler, 0);
            this.specialMinions.Add(CardDB.cardName.koboldgeomancer, 0);
            this.specialMinions.Add(CardDB.cardName.lepergnome, 0);
            this.specialMinions.Add(CardDB.cardName.lightspawn, 0);
            this.specialMinions.Add(CardDB.cardName.lightwarden, 0);
            this.specialMinions.Add(CardDB.cardName.lightwell, 0);
            this.specialMinions.Add(CardDB.cardName.loothoarder, 0);
            this.specialMinions.Add(CardDB.cardName.lorewalkercho, 0);
            this.specialMinions.Add(CardDB.cardName.malygos, 0);
            this.specialMinions.Add(CardDB.cardName.manaaddict, 0);
            this.specialMinions.Add(CardDB.cardName.manatidetotem, 0);
            this.specialMinions.Add(CardDB.cardName.manawraith, 0);
            this.specialMinions.Add(CardDB.cardName.manawyrm, 0);
            this.specialMinions.Add(CardDB.cardName.masterswordsmith, 0);
            this.specialMinions.Add(CardDB.cardName.murloctidecaller, 0);
            this.specialMinions.Add(CardDB.cardName.murlocwarleader, 0);
            this.specialMinions.Add(CardDB.cardName.natpagle, 0);
            this.specialMinions.Add(CardDB.cardName.northshirecleric, 0);
            this.specialMinions.Add(CardDB.cardName.ogremagi, 0);
            this.specialMinions.Add(CardDB.cardName.oldmurkeye, 0);
            this.specialMinions.Add(CardDB.cardName.patientassassin, 0);
            this.specialMinions.Add(CardDB.cardName.pintsizedsummoner, 0);
            this.specialMinions.Add(CardDB.cardName.prophetvelen, 0);
            this.specialMinions.Add(CardDB.cardName.questingadventurer, 0);
            this.specialMinions.Add(CardDB.cardName.ragingworgen, 0);
            this.specialMinions.Add(CardDB.cardName.ragnarosthefirelord, 10);
            this.specialMinions.Add(CardDB.cardName.raidleader, 0);
            this.specialMinions.Add(CardDB.cardName.savannahhighmane, 20);
            this.specialMinions.Add(CardDB.cardName.scavenginghyena, 0);
            this.specialMinions.Add(CardDB.cardName.secretkeeper, 0);
            this.specialMinions.Add(CardDB.cardName.sorcerersapprentice, 0);
            this.specialMinions.Add(CardDB.cardName.southseacaptain, 0);
            this.specialMinions.Add(CardDB.cardName.spitefulsmith, 0);
            this.specialMinions.Add(CardDB.cardName.starvingbuzzard, 0);
            this.specialMinions.Add(CardDB.cardName.stormwindchampion, 0);
            this.specialMinions.Add(CardDB.cardName.summoningportal, 0);
            this.specialMinions.Add(CardDB.cardName.sylvanaswindrunner, 0);
            this.specialMinions.Add(CardDB.cardName.taurenwarrior, 0);
            this.specialMinions.Add(CardDB.cardName.thebeast, 0);
            this.specialMinions.Add(CardDB.cardName.timberwolf, 0);
            this.specialMinions.Add(CardDB.cardName.tirionfordring, 0);
            this.specialMinions.Add(CardDB.cardName.tundrarhino, 0);
            this.specialMinions.Add(CardDB.cardName.unboundelemental, 0);
            //this.specialMinions.Add(CardDB.cardName.venturecomercenary, 0);
            this.specialMinions.Add(CardDB.cardName.violetteacher, 0);
            this.specialMinions.Add(CardDB.cardName.warsongcommander, 0);
            this.specialMinions.Add(CardDB.cardName.waterelemental, 0);

            // naxx cards
            this.specialMinions.Add(CardDB.cardName.baronrivendare, 0);
            this.specialMinions.Add(CardDB.cardName.undertaker, 0);
            this.specialMinions.Add(CardDB.cardName.dancingswords, 0);
            this.specialMinions.Add(CardDB.cardName.darkcultist, 0);
            this.specialMinions.Add(CardDB.cardName.deathlord, 0);
            this.specialMinions.Add(CardDB.cardName.feugen, 0);
            this.specialMinions.Add(CardDB.cardName.stalagg, 0);
            this.specialMinions.Add(CardDB.cardName.hauntedcreeper, 0);
            this.specialMinions.Add(CardDB.cardName.kelthuzad, 0);
            this.specialMinions.Add(CardDB.cardName.madscientist, 0);
            this.specialMinions.Add(CardDB.cardName.maexxna, 0);
            this.specialMinions.Add(CardDB.cardName.nerubarweblord, 0);
            this.specialMinions.Add(CardDB.cardName.shadeofnaxxramas, 0);
            this.specialMinions.Add(CardDB.cardName.unstableghoul, 0);
            this.specialMinions.Add(CardDB.cardName.voidcaller, 0);
            this.specialMinions.Add(CardDB.cardName.anubarambusher, 0);
            this.specialMinions.Add(CardDB.cardName.webspinner, 0);

            this.specialMinions.Add(CardDB.cardName.emperorthaurissan, 0);
            this.specialMinions.Add(CardDB.cardName.majordomoexecutus, 0);
            this.specialMinions.Add(CardDB.cardName.chromaggus, 0);
            this.specialMinions.Add(CardDB.cardName.flamewaker, 0);
            this.specialMinions.Add(CardDB.cardName.impgangboss, 0);
            this.specialMinions.Add(CardDB.cardName.axeflinger, 0);
            this.specialMinions.Add(CardDB.cardName.grimpatron, 0);
            this.specialMinions.Add(CardDB.cardName.dragonkinsorcerer, 0);
            this.specialMinions.Add(CardDB.cardName.dragonegg, 0);

            //GVG
            this.specialMinions.Add(CardDB.cardName.snowchugger, 0);
            this.specialMinions.Add(CardDB.cardName.mechwarper, 0);
            this.specialMinions.Add(CardDB.cardName.cogmaster, 0);
            this.specialMinions.Add(CardDB.cardName.mistressofpain, 0);
            this.specialMinions.Add(CardDB.cardName.felcannon, 0);
            this.specialMinions.Add(CardDB.cardName.malganis, 0);
            this.specialMinions.Add(CardDB.cardName.ironsensei, 0);
            this.specialMinions.Add(CardDB.cardName.tradeprincegallywix, 0);
            this.specialMinions.Add(CardDB.cardName.mechbearcat, 0);
            this.specialMinions.Add(CardDB.cardName.vitalitytotem, 0);
            this.specialMinions.Add(CardDB.cardName.siltfinspiritwalker, 0);
            this.specialMinions.Add(CardDB.cardName.gahzrilla, 0);
            this.specialMinions.Add(CardDB.cardName.warbot, 0);
            this.specialMinions.Add(CardDB.cardName.cobaltguardian, 0);
            this.specialMinions.Add(CardDB.cardName.stonesplintertrogg, 0);
            this.specialMinions.Add(CardDB.cardName.burlyrockjawtrogg, 0);
            this.specialMinions.Add(CardDB.cardName.shadowboxer, 0);
            this.specialMinions.Add(CardDB.cardName.shipscannon, 0);
            this.specialMinions.Add(CardDB.cardName.steamwheedlesniper, 0);
            this.specialMinions.Add(CardDB.cardName.jeeves, 0);
            this.specialMinions.Add(CardDB.cardName.goblinsapper, 0);
            this.specialMinions.Add(CardDB.cardName.floatingwatcher, 0);
            this.specialMinions.Add(CardDB.cardName.micromachine, 0);
            this.specialMinions.Add(CardDB.cardName.hobgoblin, 0);
            this.specialMinions.Add(CardDB.cardName.junkbot, 0);
            this.specialMinions.Add(CardDB.cardName.mimironshead, 0);
            this.specialMinions.Add(CardDB.cardName.mogortheogre, 0);
            this.specialMinions.Add(CardDB.cardName.foereaper4000, 0);
            this.specialMinions.Add(CardDB.cardName.mekgineerthermaplugg, 0);
            this.specialMinions.Add(CardDB.cardName.gazlowe, 0);
            this.specialMinions.Add(CardDB.cardName.troggzortheearthinator, 0);
            this.specialMinions.Add(CardDB.cardName.clockworkgnome, 0);
            this.specialMinions.Add(CardDB.cardName.explosivesheep, 0);
            this.specialMinions.Add(CardDB.cardName.mechanicalyeti, 0);
            this.specialMinions.Add(CardDB.cardName.pilotedshredder, 0);
            this.specialMinions.Add(CardDB.cardName.pilotedskygolem, 0);
            this.specialMinions.Add(CardDB.cardName.malorne, 0);
            this.specialMinions.Add(CardDB.cardName.sneedsoldshredder, 0);
            this.specialMinions.Add(CardDB.cardName.toshley, 0);

            //TGT
            this.specialMinions.Add(CardDB.cardName.lowlysquire, 0);
            this.specialMinions.Add(CardDB.cardName.boneguardlieutenant, 0);
            this.specialMinions.Add(CardDB.cardName.dragonhawkrider, 0);
            this.specialMinions.Add(CardDB.cardName.silverhandregent, 0);
            this.specialMinions.Add(CardDB.cardName.maidenofthelake, 0);
            this.specialMinions.Add(CardDB.cardName.tournamentmedic, 0);
            this.specialMinions.Add(CardDB.cardName.kvaldirraider, 0);
            this.specialMinions.Add(CardDB.cardName.muklaschampion, 0);
            this.specialMinions.Add(CardDB.cardName.garrisoncommander, 0);
            this.specialMinions.Add(CardDB.cardName.crowdfavorite, 0);
            this.specialMinions.Add(CardDB.cardName.recruiter, 0);
            this.specialMinions.Add(CardDB.cardName.kodorider, 0);
            this.specialMinions.Add(CardDB.cardName.eydisdarkbane, 0);
            this.specialMinions.Add(CardDB.cardName.fjolalightbane, 0);
            this.specialMinions.Add(CardDB.cardName.nexuschampionsaraad, 0);
            this.specialMinions.Add(CardDB.cardName.bolframshield, 0);

            this.specialMinions.Add(CardDB.cardName.savagecombatant, 0);
            this.specialMinions.Add(CardDB.cardName.knightofthewild, 0);
            this.specialMinions.Add(CardDB.cardName.aviana, 0);
            this.specialMinions.Add(CardDB.cardName.bravearcher, 0);
            this.specialMinions.Add(CardDB.cardName.dreadscale, 0);
            this.specialMinions.Add(CardDB.cardName.acidmaw, 0);
            this.specialMinions.Add(CardDB.cardName.dalaranaspirant, 0);
            this.specialMinions.Add(CardDB.cardName.fallenhero, 0);
            this.specialMinions.Add(CardDB.cardName.coldarradrake, 0);
            this.specialMinions.Add(CardDB.cardName.warhorsetrainer, 0);
            this.specialMinions.Add(CardDB.cardName.murlocknight, 0);
            this.specialMinions.Add(CardDB.cardName.holychampion, 0);
            this.specialMinions.Add(CardDB.cardName.spawnofshadows, 0);
            this.specialMinions.Add(CardDB.cardName.shadowfiend, 0);
            this.specialMinions.Add(CardDB.cardName.confessorpaletress, 0);
            this.specialMinions.Add(CardDB.cardName.buccaneer, 0);
            this.specialMinions.Add(CardDB.cardName.cutpurse, 0);
            this.specialMinions.Add(CardDB.cardName.thunderbluffvaliant, 0);
            this.specialMinions.Add(CardDB.cardName.wrathguard, 0);
            this.specialMinions.Add(CardDB.cardName.tinyknightofevil, 0);
            this.specialMinions.Add(CardDB.cardName.voidcrusher, 0);
            this.specialMinions.Add(CardDB.cardName.wilfredfizzlebang, 0);
            this.specialMinions.Add(CardDB.cardName.orgrimmaraspirant, 0);
            this.specialMinions.Add(CardDB.cardName.magnatauralpha, 0);
            this.specialMinions.Add(CardDB.cardName.chillmaw, 20);

            //LOE (week 1 and 2 :D)
            this.specialMinions.Add(CardDB.cardName.obsidiandestroyer, 0);
            this.specialMinions.Add(CardDB.cardName.djinniofzephyrs, 0);
            this.specialMinions.Add(CardDB.cardName.summoningstone, 0);
            this.specialMinions.Add(CardDB.cardName.rumblingelemental, 0);
            this.specialMinions.Add(CardDB.cardName.tunneltrogg, 0);
            this.specialMinions.Add(CardDB.cardName.brannbronzebeard, 0);

            //OG
            specialMinions.Add(CardDB.cardName.aberrantberserker, 0);
            specialMinions.Add(CardDB.cardName.addledgrizzly, 0);
            specialMinions.Add(CardDB.cardName.ancientharbinger, 0);
            specialMinions.Add(CardDB.cardName.blackwaterpirate, 0);
            specialMinions.Add(CardDB.cardName.bloodhoofbrave, 0);
            specialMinions.Add(CardDB.cardName.crazedworshipper, 0);
            specialMinions.Add(CardDB.cardName.cthun, 0);
            specialMinions.Add(CardDB.cardName.cultsorcerer, 0);
            specialMinions.Add(CardDB.cardName.darkshirecouncilman, 0);
            specialMinions.Add(CardDB.cardName.dementedfrostcaller, 0);
            specialMinions.Add(CardDB.cardName.evolvedkobold, 0);
            specialMinions.Add(CardDB.cardName.fandralstaghelm, 0);
            specialMinions.Add(CardDB.cardName.giantsandworm, 0);
            specialMinions.Add(CardDB.cardName.hallazealtheascended, 0);
            specialMinions.Add(CardDB.cardName.hoggerdoomofelwynn, 0);
            specialMinions.Add(CardDB.cardName.hoodedacolyte, 0);
            specialMinions.Add(CardDB.cardName.infestedtauren, 0);
            specialMinions.Add(CardDB.cardName.infestedwolf, 0);
            specialMinions.Add(CardDB.cardName.ragnaroslightlord, 10);
            specialMinions.Add(CardDB.cardName.scalednightmare, 0);
            specialMinions.Add(CardDB.cardName.shiftingshade, 0);
            specialMinions.Add(CardDB.cardName.southseasquidface, 0);
            specialMinions.Add(CardDB.cardName.spawnofnzoth, 0);
            specialMinions.Add(CardDB.cardName.stewardofdarkshire, 0);
            specialMinions.Add(CardDB.cardName.theboogeymonster, 0);
            specialMinions.Add(CardDB.cardName.twilightelder, 0);
            specialMinions.Add(CardDB.cardName.undercityhuckster, 0);
            specialMinions.Add(CardDB.cardName.usherofsouls, 0);
            specialMinions.Add(CardDB.cardName.wobblingrunts, 0);
            specialMinions.Add(CardDB.cardName.xarilpoisonedmind, 0);
            specialMinions.Add(CardDB.cardName.ysera, 0);
            specialMinions.Add(CardDB.cardName.yshaarjrageunbound, 0);
            
            //Kara
            specialMinions.Add(CardDB.cardName.arcaneanomaly, 0);
            specialMinions.Add(CardDB.cardName.cloakedhuntress, 0);
            specialMinions.Add(CardDB.cardName.deadlyfork, 0);
            specialMinions.Add(CardDB.cardName.moroes, 0);
            specialMinions.Add(CardDB.cardName.priestofthefeast, 0);
            specialMinions.Add(CardDB.cardName.kindlygrandmother, 0);
            specialMinions.Add(CardDB.cardName.wickedwitchdoctor, 0);
            specialMinions.Add(CardDB.cardName.moatlurker, 0);

            //MSG
            specialMinions.Add(CardDB.cardName.ratpack, 0);
            specialMinions.Add(CardDB.cardName.shakyzipgunner, 0);
            specialMinions.Add(CardDB.cardName.knuckles, 0);
            specialMinions.Add(CardDB.cardName.meanstreetmarshal, 0);
            specialMinions.Add(CardDB.cardName.wickerflameburnbristle, 0);
            specialMinions.Add(CardDB.cardName.grimestreetenforcer, 0);
            specialMinions.Add(CardDB.cardName.manageode, 0);
            specialMinions.Add(CardDB.cardName.jadeswarmer, 0);
            specialMinions.Add(CardDB.cardName.shakuthecollector, 0);
            specialMinions.Add(CardDB.cardName.lotusassassin, 0);
            specialMinions.Add(CardDB.cardName.lotusillusionist, 0);
            specialMinions.Add(CardDB.cardName.whiteeyes, 0);
            specialMinions.Add(CardDB.cardName.unlicensedapothecary, 0);
            specialMinions.Add(CardDB.cardName.kabaltrafficker, 0);
            specialMinions.Add(CardDB.cardName.grimygadgeteer, 0);
            specialMinions.Add(CardDB.cardName.alleyarmorsmith, 0);
            specialMinions.Add(CardDB.cardName.mistressofmixtures, 0);
            specialMinions.Add(CardDB.cardName.smalltimebuccaneer, 0);
            specialMinions.Add(CardDB.cardName.weaseltunneler, 0);
            specialMinions.Add(CardDB.cardName.friendlybartender, 0);
            specialMinions.Add(CardDB.cardName.auctionmasterbeardo, 0);
            specialMinions.Add(CardDB.cardName.backstreetleper, 0);
            specialMinions.Add(CardDB.cardName.felorcsoulfiend, 0);
            specialMinions.Add(CardDB.cardName.sergeantsally, 0);
            specialMinions.Add(CardDB.cardName.backroombouncer, 0);
            specialMinions.Add(CardDB.cardName.daringreporter, 0);
            specialMinions.Add(CardDB.cardName.genzotheshark, 0);
            specialMinions.Add(CardDB.cardName.bombsquad, 0);
            specialMinions.Add(CardDB.cardName.burglybully, 0);
            specialMinions.Add(CardDB.cardName.finjatheflyingstar, 0);
            specialMinions.Add(CardDB.cardName.redmanawyrm, 0);
            specialMinions.Add(CardDB.cardName.windupburglebot, 0);
            specialMinions.Add(CardDB.cardName.mayornoggenfogger, 0);
            specialMinions.Add(CardDB.cardName.ayablackpaw, 10);

        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.captaingreenskin, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.cenarius, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.coldlightseer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.crueltaskmaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.darkirondwarf, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.defenderofargus, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.direwolfalpha, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.flametonguetotem, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.grimscaleoracle, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.houndmaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.leokk, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.murlocwarleader, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.raidleader, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.shatteredsuncleric, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.southseacaptain, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.spitefulsmith, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.stormwindchampion, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.templeenforcer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.timberwolf, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.malganis, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.warsongcommander, 0);

            buffingMinionsDatabase.Add(CardDB.cardName.metaltoothleaper, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.quartermaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.screwjankclunker, 0);

            buffingMinionsDatabase.Add(CardDB.cardName.lancecarrier, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.clockworkknight, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.wildwalker, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.warhorsetrainer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.thunderbluffvaliant, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.bloodsailcultist, 5);

            buffingMinionsDatabase.Add(CardDB.cardName.virmensensei, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.grimestreetprotector, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.kabaltalonpriest, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.shadowsensei, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.crystalweaver, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.hobartgrapplehammer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.grimestreetpawnbroker, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.nagacorsair, 0);



            buffing1TurnDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.darkirondwarf, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.rockbiterweapon, 0);
        }

        private void setupEnemyTargetPriority()
        {
            priorityTargets.Add(CardDB.cardName.lightwarden, 4);
            priorityTargets.Add(CardDB.cardName.secretkeeper, 3);
            priorityTargets.Add(CardDB.cardName.youngdragonhawk, 4);
            priorityTargets.Add(CardDB.cardName.bloodmagethalnos, 10);
            priorityTargets.Add(CardDB.cardName.direwolfalpha, 4);
            priorityTargets.Add(CardDB.cardName.doomsayer, 10);
            priorityTargets.Add(CardDB.cardName.knifejuggler, 10);
            priorityTargets.Add(CardDB.cardName.koboldgeomancer, 3);
            priorityTargets.Add(CardDB.cardName.manaaddict, 4);
            priorityTargets.Add(CardDB.cardName.masterswordsmith, 2);
            priorityTargets.Add(CardDB.cardName.natpagle, 10);
            priorityTargets.Add(CardDB.cardName.murloctidehunter, 4);
            priorityTargets.Add(CardDB.cardName.pintsizedsummoner, 10);
            priorityTargets.Add(CardDB.cardName.wildpyromancer, 4);
            priorityTargets.Add(CardDB.cardName.alarmobot, 10);
            priorityTargets.Add(CardDB.cardName.acolyteofpain, 10);
            priorityTargets.Add(CardDB.cardName.demolisher, 4);
            priorityTargets.Add(CardDB.cardName.flesheatingghoul, 5);
            priorityTargets.Add(CardDB.cardName.impmaster, 3);
            priorityTargets.Add(CardDB.cardName.questingadventurer, 6);
            priorityTargets.Add(CardDB.cardName.raidleader, 6);
            priorityTargets.Add(CardDB.cardName.thrallmarfarseer, 10);
            priorityTargets.Add(CardDB.cardName.cultmaster, 10);
            priorityTargets.Add(CardDB.cardName.violetteacher, 6);
            priorityTargets.Add(CardDB.cardName.gadgetzanauctioneer, 10);
            priorityTargets.Add(CardDB.cardName.hogger, 10);
            priorityTargets.Add(CardDB.cardName.illidanstormrage, 10);
            priorityTargets.Add(CardDB.cardName.barongeddon, 10);
            priorityTargets.Add(CardDB.cardName.stormwindchampion, 10);
            priorityTargets.Add(CardDB.cardName.gurubashiberserker, 10);
            priorityTargets.Add(CardDB.cardName.ragnarosthefirelord, 20);

            //warrior cards
            priorityTargets.Add(CardDB.cardName.frothingberserker, 10);
            priorityTargets.Add(CardDB.cardName.warsongcommander, 10);

            //warlock cards
            priorityTargets.Add(CardDB.cardName.summoningportal, 10);

            //shaman cards
            priorityTargets.Add(CardDB.cardName.dustdevil, 10);
            priorityTargets.Add(CardDB.cardName.wrathofairtotem, 2);
            priorityTargets.Add(CardDB.cardName.flametonguetotem, 10);
            priorityTargets.Add(CardDB.cardName.manatidetotem, 7);
            priorityTargets.Add(CardDB.cardName.unboundelemental, 5);
            priorityTargets.Add(CardDB.cardName.thunderbluffvaliant, 10);

            //rogue cards

            //priest cards
            priorityTargets.Add(CardDB.cardName.northshirecleric, 10);
            priorityTargets.Add(CardDB.cardName.lightwell, 10);
            priorityTargets.Add(CardDB.cardName.auchenaisoulpriest, 5);
            priorityTargets.Add(CardDB.cardName.prophetvelen, 10);

            //paladin cards

            //mage cards
            priorityTargets.Add(CardDB.cardName.manawyrm, 4);
            priorityTargets.Add(CardDB.cardName.sorcerersapprentice, 10);
            priorityTargets.Add(CardDB.cardName.etherealarcanist, 6);
            priorityTargets.Add(CardDB.cardName.archmageantonidas, 10);

            //hunter cards
            priorityTargets.Add(CardDB.cardName.timberwolf, 4);
            priorityTargets.Add(CardDB.cardName.scavenginghyena, 10);
            priorityTargets.Add(CardDB.cardName.starvingbuzzard, 10);
            priorityTargets.Add(CardDB.cardName.leokk, 10);
            priorityTargets.Add(CardDB.cardName.tundrarhino, 10);

            //naxx cards
            priorityTargets.Add(CardDB.cardName.baronrivendare, 5);
            priorityTargets.Add(CardDB.cardName.kelthuzad, 10);
            priorityTargets.Add(CardDB.cardName.nerubarweblord, 10);
            priorityTargets.Add(CardDB.cardName.shadeofnaxxramas, 10);
            priorityTargets.Add(CardDB.cardName.undertaker, 4);



            //GVG
            this.priorityTargets.Add(CardDB.cardName.ironsensei, 6);
            this.priorityTargets.Add(CardDB.cardName.mechwarper, 4);
            this.priorityTargets.Add(CardDB.cardName.malganis, 10);
            this.priorityTargets.Add(CardDB.cardName.vitalitytotem, 4);
            this.priorityTargets.Add(CardDB.cardName.gahzrilla, 10);
            this.priorityTargets.Add(CardDB.cardName.steamwheedlesniper, 5);
            this.priorityTargets.Add(CardDB.cardName.floatingwatcher, 6);
            this.priorityTargets.Add(CardDB.cardName.micromachine, 4);
            this.priorityTargets.Add(CardDB.cardName.hobgoblin, 5);
            this.priorityTargets.Add(CardDB.cardName.mogortheogre, 10);
            this.priorityTargets.Add(CardDB.cardName.foereaper4000, 10);
            this.priorityTargets.Add(CardDB.cardName.troggzortheearthinator, 10);
            
            //BRM
            this.priorityTargets.Add(CardDB.cardName.flamewaker, 10);
            this.priorityTargets.Add(CardDB.cardName.impgangboss, 5);
            this.priorityTargets.Add(CardDB.cardName.grimpatron, 10);
            this.priorityTargets.Add(CardDB.cardName.dragonkinsorcerer, 4);
            this.priorityTargets.Add(CardDB.cardName.emperorthaurissan, 10);
            this.priorityTargets.Add(CardDB.cardName.chromaggus, 10);

            //TGT
            this.priorityTargets.Add(CardDB.cardName.muklaschampion, 10);
            this.priorityTargets.Add(CardDB.cardName.kodorider, 5);
            this.priorityTargets.Add(CardDB.cardName.eydisdarkbane, 5);
            this.priorityTargets.Add(CardDB.cardName.nexuschampionsaraad, 5);
            this.priorityTargets.Add(CardDB.cardName.savagecombatant, 5);
            this.priorityTargets.Add(CardDB.cardName.aviana, 10);
            this.priorityTargets.Add(CardDB.cardName.acidmaw, 5);

            this.priorityTargets.Add(CardDB.cardName.coldarradrake, 5);
            this.priorityTargets.Add(CardDB.cardName.warhorsetrainer, 5);
            this.priorityTargets.Add(CardDB.cardName.murlocknight, 10);
            this.priorityTargets.Add(CardDB.cardName.holychampion, 5);
            this.priorityTargets.Add(CardDB.cardName.wilfredfizzlebang, 10);

            //LOE
            this.priorityTargets.Add(CardDB.cardName.brannbronzebeard, 20);
            this.priorityTargets.Add(CardDB.cardName.obsidiandestroyer, 10);
            this.priorityTargets.Add(CardDB.cardName.summoningstone, 10);
            this.priorityTargets.Add(CardDB.cardName.djinniofzephyrs, 5);
            this.priorityTargets.Add(CardDB.cardName.rumblingelemental, 5);
            this.priorityTargets.Add(CardDB.cardName.animatedarmor, 5);
            priorityTargets.Add(CardDB.cardName.tunneltrogg, 5);

            //OG
            priorityTargets.Add(CardDB.cardName.addledgrizzly, 10);
            priorityTargets.Add(CardDB.cardName.cthun, 10);
            priorityTargets.Add(CardDB.cardName.cultsorcerer, 10);
            priorityTargets.Add(CardDB.cardName.darkshirecouncilman, 10);
            priorityTargets.Add(CardDB.cardName.dementedfrostcaller, 10);
            priorityTargets.Add(CardDB.cardName.fandralstaghelm, 10);
            priorityTargets.Add(CardDB.cardName.giantsandworm, 10);
            priorityTargets.Add(CardDB.cardName.hoggerdoomofelwynn, 10);
            priorityTargets.Add(CardDB.cardName.hoodedacolyte, 10);
            priorityTargets.Add(CardDB.cardName.ragnaroslightlord, 10);
            priorityTargets.Add(CardDB.cardName.scalednightmare, 10);
            priorityTargets.Add(CardDB.cardName.theboogeymonster, 10);
            priorityTargets.Add(CardDB.cardName.twilightsummoner, 10);
            priorityTargets.Add(CardDB.cardName.yshaarjrageunbound, 10);

            //Kara
            priorityTargets.Add(CardDB.cardName.cloakedhuntress, 10);
            priorityTargets.Add(CardDB.cardName.moroes, 5);
            priorityTargets.Add(CardDB.cardName.priestofthefeast, 10);
            priorityTargets.Add(CardDB.cardName.wickedwitchdoctor, 5);

            //MSG
            priorityTargets.Add(CardDB.cardName.grimestreetenforcer, 10);
            priorityTargets.Add(CardDB.cardName.shakuthecollector, 5);
            priorityTargets.Add(CardDB.cardName.kabaltrafficker, 5);
            priorityTargets.Add(CardDB.cardName.grimygadgeteer, 5);
            priorityTargets.Add(CardDB.cardName.friendlybartender, 1);
            priorityTargets.Add(CardDB.cardName.auctionmasterbeardo, 5);
            priorityTargets.Add(CardDB.cardName.backroombouncer, 5);
            priorityTargets.Add(CardDB.cardName.daringreporter, 1);
            priorityTargets.Add(CardDB.cardName.burglybully, 3);
            priorityTargets.Add(CardDB.cardName.redmanawyrm, 5);
        }

        private void setupLethalHelpMinions()
        {
            lethalHelpers.Add(CardDB.cardName.auchenaisoulpriest, 0);
            //spellpower minions
            lethalHelpers.Add(CardDB.cardName.archmage, 0);
            lethalHelpers.Add(CardDB.cardName.dalaranmage, 0);
            lethalHelpers.Add(CardDB.cardName.koboldgeomancer, 0);
            lethalHelpers.Add(CardDB.cardName.ogremagi, 0);
            lethalHelpers.Add(CardDB.cardName.ancientmage, 0);
            lethalHelpers.Add(CardDB.cardName.azuredrake, 0);
            lethalHelpers.Add(CardDB.cardName.bloodmagethalnos, 0);
            lethalHelpers.Add(CardDB.cardName.malygos, 0);
            lethalHelpers.Add(CardDB.cardName.sootspewer, 0);
            lethalHelpers.Add(CardDB.cardName.minimage, 0);

            lethalHelpers.Add(CardDB.cardName.varianwrynn, 0);
            lethalHelpers.Add(CardDB.cardName.bravearcher, 0);
            lethalHelpers.Add(CardDB.cardName.acidmaw, 0);
            lethalHelpers.Add(CardDB.cardName.coldarradrake, 0);
            lethalHelpers.Add(CardDB.cardName.polymorphboar, 0);
            //
            lethalHelpers.Add(CardDB.cardName.cultsorcerer, 0);
            lethalHelpers.Add(CardDB.cardName.evolvedkobold, 0);

        }

        private void setupSilenceTargets()
        {
            this.silenceTargets.Add(CardDB.cardName.abomination, 0);
            this.silenceTargets.Add(CardDB.cardName.acolyteofpain, 0);
            this.silenceTargets.Add(CardDB.cardName.archmageantonidas, 0);
            this.silenceTargets.Add(CardDB.cardName.armorsmith, 0);
            this.silenceTargets.Add(CardDB.cardName.auchenaisoulpriest, 0);
            this.silenceTargets.Add(CardDB.cardName.barongeddon, 0);
            //this.silenceTargets.Add(CardDB.cardName.bloodimp, 0);
            this.silenceTargets.Add(CardDB.cardName.cairnebloodhoof, 0);
            this.silenceTargets.Add(CardDB.cardName.cultmaster, 0);
            this.silenceTargets.Add(CardDB.cardName.direwolfalpha, 0);
            this.silenceTargets.Add(CardDB.cardName.doomsayer, 0);
            this.silenceTargets.Add(CardDB.cardName.emperorcobra, 0);
            this.silenceTargets.Add(CardDB.cardName.etherealarcanist, 0);
            this.silenceTargets.Add(CardDB.cardName.flametonguetotem, 0);
            this.silenceTargets.Add(CardDB.cardName.gadgetzanauctioneer, 10);
            this.silenceTargets.Add(CardDB.cardName.grommashhellscream, 0);

            this.silenceTargets.Add(CardDB.cardName.gruul, 0);
            this.silenceTargets.Add(CardDB.cardName.gurubashiberserker, 0);
            this.silenceTargets.Add(CardDB.cardName.hogger, 0);

            this.silenceTargets.Add(CardDB.cardName.illidanstormrage, 0);
            this.silenceTargets.Add(CardDB.cardName.impmaster, 0);

            this.silenceTargets.Add(CardDB.cardName.knifejuggler, 0);
            this.silenceTargets.Add(CardDB.cardName.lightspawn, 0);
            this.silenceTargets.Add(CardDB.cardName.lightwarden, 0);
            this.silenceTargets.Add(CardDB.cardName.lightwell, 0);
            this.silenceTargets.Add(CardDB.cardName.lorewalkercho, 0);

            this.silenceTargets.Add(CardDB.cardName.malygos, 0);

            this.silenceTargets.Add(CardDB.cardName.manatidetotem, 0);
            this.silenceTargets.Add(CardDB.cardName.manawraith, 0);
            this.silenceTargets.Add(CardDB.cardName.manawyrm, 0);
            this.silenceTargets.Add(CardDB.cardName.masterswordsmith, 0);

            this.silenceTargets.Add(CardDB.cardName.murloctidecaller, 0);
            this.silenceTargets.Add(CardDB.cardName.murlocwarleader, 0);
            this.silenceTargets.Add(CardDB.cardName.natpagle, 0);
            this.silenceTargets.Add(CardDB.cardName.northshirecleric, 0);

            this.silenceTargets.Add(CardDB.cardName.oldmurkeye, 0);
            this.silenceTargets.Add(CardDB.cardName.prophetvelen, 0);
            this.silenceTargets.Add(CardDB.cardName.questingadventurer, 0);
            this.silenceTargets.Add(CardDB.cardName.raidleader, 0);

            this.silenceTargets.Add(CardDB.cardName.savannahhighmane, 0);
            this.silenceTargets.Add(CardDB.cardName.scavenginghyena, 0);
            this.silenceTargets.Add(CardDB.cardName.sorcerersapprentice, 0);
            this.silenceTargets.Add(CardDB.cardName.southseacaptain, 0);
            this.silenceTargets.Add(CardDB.cardName.spitefulsmith, 0);
            this.silenceTargets.Add(CardDB.cardName.starvingbuzzard, 0);
            this.silenceTargets.Add(CardDB.cardName.stormwindchampion, 0);
            this.silenceTargets.Add(CardDB.cardName.summoningportal, 0);
            this.silenceTargets.Add(CardDB.cardName.sylvanaswindrunner, 0);
            this.silenceTargets.Add(CardDB.cardName.timberwolf, 0);
            this.silenceTargets.Add(CardDB.cardName.tirionfordring, 0);
            this.silenceTargets.Add(CardDB.cardName.tundrarhino, 0);
            //this.specialMinions.Add(CardDB.cardName.unboundelemental, 0);
            //this.specialMinions.Add(CardDB.cardName.venturecomercenary, 0);
            this.silenceTargets.Add(CardDB.cardName.violetteacher, 0);
            this.silenceTargets.Add(CardDB.cardName.warsongcommander, 0);
            //this.specialMinions.Add(CardDB.cardName.waterelemental, 0);

            // naxx cards
            this.silenceTargets.Add(CardDB.cardName.baronrivendare, 0);
            this.silenceTargets.Add(CardDB.cardName.undertaker, 0);
            this.silenceTargets.Add(CardDB.cardName.darkcultist, 0);
            this.silenceTargets.Add(CardDB.cardName.feugen, 0);
            this.silenceTargets.Add(CardDB.cardName.stalagg, 0);
            this.silenceTargets.Add(CardDB.cardName.hauntedcreeper, 0);
            this.silenceTargets.Add(CardDB.cardName.kelthuzad, 10);
            this.silenceTargets.Add(CardDB.cardName.madscientist, 0);
            this.silenceTargets.Add(CardDB.cardName.maexxna, 0);
            this.silenceTargets.Add(CardDB.cardName.nerubarweblord, 0);
            this.silenceTargets.Add(CardDB.cardName.shadeofnaxxramas, 0);

            this.silenceTargets.Add(CardDB.cardName.webspinner, 0);
            this.silenceTargets.Add(CardDB.cardName.ironsensei, 0);
            this.silenceTargets.Add(CardDB.cardName.vitalitytotem, 0);


            this.silenceTargets.Add(CardDB.cardName.malganis, 0);
            this.silenceTargets.Add(CardDB.cardName.malorne, 0);
            this.silenceTargets.Add(CardDB.cardName.gahzrilla, 0);
            this.silenceTargets.Add(CardDB.cardName.bolvarfordragon, 0);
            this.silenceTargets.Add(CardDB.cardName.mogortheogre, 0);
            this.silenceTargets.Add(CardDB.cardName.stonesplintertrogg, 0);
            this.silenceTargets.Add(CardDB.cardName.burlyrockjawtrogg, 0);
            this.silenceTargets.Add(CardDB.cardName.shadowboxer, 0);
            this.silenceTargets.Add(CardDB.cardName.explosivesheep, 0);
            this.silenceTargets.Add(CardDB.cardName.animagolem, 0);
            this.silenceTargets.Add(CardDB.cardName.siegeengine, 0);
            this.silenceTargets.Add(CardDB.cardName.steamwheedlesniper, 0);
            this.silenceTargets.Add(CardDB.cardName.floatingwatcher, 0);
            this.silenceTargets.Add(CardDB.cardName.micromachine, 0);
            this.silenceTargets.Add(CardDB.cardName.hobgoblin, 0);
            this.silenceTargets.Add(CardDB.cardName.pilotedskygolem, 0);
            this.silenceTargets.Add(CardDB.cardName.junkbot, 0);
            this.silenceTargets.Add(CardDB.cardName.v07tr0n, 0);
            this.silenceTargets.Add(CardDB.cardName.foereaper4000, 0);
            this.silenceTargets.Add(CardDB.cardName.sneedsoldshredder, 0);
            this.silenceTargets.Add(CardDB.cardName.mekgineerthermaplugg, 0);
            this.silenceTargets.Add(CardDB.cardName.troggzortheearthinator, 0);

            this.silenceTargets.Add(CardDB.cardName.flamewaker, 0);
            this.silenceTargets.Add(CardDB.cardName.impgangboss, 0);
            this.silenceTargets.Add(CardDB.cardName.grimpatron, 0);
            this.silenceTargets.Add(CardDB.cardName.dragonkinsorcerer, 0);
            this.silenceTargets.Add(CardDB.cardName.majordomoexecutus, 0);
            this.silenceTargets.Add(CardDB.cardName.emperorthaurissan, 0);
            this.silenceTargets.Add(CardDB.cardName.chromaggus, 0);

            this.silenceTargets.Add(CardDB.cardName.quartermaster, 0);

            //TGT
            this.silenceTargets.Add(CardDB.cardName.silverhandregent, 0);
            this.silenceTargets.Add(CardDB.cardName.muklaschampion, 0);
            this.silenceTargets.Add(CardDB.cardName.maidenofthelake, 0);
            this.silenceTargets.Add(CardDB.cardName.crowdfavorite, 0);
            this.silenceTargets.Add(CardDB.cardName.kodorider, 0);
            this.silenceTargets.Add(CardDB.cardName.eydisdarkbane, 0);
            this.silenceTargets.Add(CardDB.cardName.fjolalightbane, 0);
            this.silenceTargets.Add(CardDB.cardName.nexuschampionsaraad, 0);
            this.silenceTargets.Add(CardDB.cardName.theskeletonknight, 0);
            this.silenceTargets.Add(CardDB.cardName.chillmaw, 0);
            this.silenceTargets.Add(CardDB.cardName.savagecombatant, 0);
            this.silenceTargets.Add(CardDB.cardName.aviana, 0);
            this.silenceTargets.Add(CardDB.cardName.dreadscale, 0);
            this.silenceTargets.Add(CardDB.cardName.acidmaw, 0);
            this.silenceTargets.Add(CardDB.cardName.coldarradrake, 0);
            this.silenceTargets.Add(CardDB.cardName.rhonin, 0);
            this.silenceTargets.Add(CardDB.cardName.warhorsetrainer, 0);
            this.silenceTargets.Add(CardDB.cardName.murlocknight, 0);
            this.silenceTargets.Add(CardDB.cardName.holychampion, 0);
            this.silenceTargets.Add(CardDB.cardName.confessorpaletress, 0);
            this.silenceTargets.Add(CardDB.cardName.thunderbluffvaliant, 0);
            this.silenceTargets.Add(CardDB.cardName.voidcrusher, 0);
            this.silenceTargets.Add(CardDB.cardName.wilfredfizzlebang, 0);
            this.silenceTargets.Add(CardDB.cardName.magnatauralpha, 0);
            this.silenceTargets.Add(CardDB.cardName.anubarak, 0);

            //LOE
            silenceTargets.Add(CardDB.cardName.addledgrizzly, 0);
            silenceTargets.Add(CardDB.cardName.ancientharbinger, 0);
            silenceTargets.Add(CardDB.cardName.anomalus, 0);
            silenceTargets.Add(CardDB.cardName.anubisathsentinel, 0);
            silenceTargets.Add(CardDB.cardName.blackwaterpirate, 0);
            silenceTargets.Add(CardDB.cardName.crazedworshipper, 0);
            silenceTargets.Add(CardDB.cardName.cthun, 0);
            silenceTargets.Add(CardDB.cardName.cultsorcerer, 0);
            silenceTargets.Add(CardDB.cardName.darkshirecouncilman, 0);
            silenceTargets.Add(CardDB.cardName.dementedfrostcaller, 0);
            silenceTargets.Add(CardDB.cardName.evolvedkobold, 0);
            silenceTargets.Add(CardDB.cardName.fandralstaghelm, 0);
            silenceTargets.Add(CardDB.cardName.giantsandworm, 0);
            silenceTargets.Add(CardDB.cardName.hallazealtheascended, 0);
            silenceTargets.Add(CardDB.cardName.hoggerdoomofelwynn, 0);
            silenceTargets.Add(CardDB.cardName.hoodedacolyte, 0);
            silenceTargets.Add(CardDB.cardName.scalednightmare, 0);
            silenceTargets.Add(CardDB.cardName.shiftingshade, 0);
            silenceTargets.Add(CardDB.cardName.southseasquidface, 0);
            silenceTargets.Add(CardDB.cardName.spawnofnzoth, 0);
            silenceTargets.Add(CardDB.cardName.stewardofdarkshire, 0);
            silenceTargets.Add(CardDB.cardName.theboogeymonster, 0);
            silenceTargets.Add(CardDB.cardName.twilightelder, 0);
            silenceTargets.Add(CardDB.cardName.undercityhuckster, 0);
            silenceTargets.Add(CardDB.cardName.usherofsouls, 0);
            silenceTargets.Add(CardDB.cardName.wobblingrunts, 0);
            silenceTargets.Add(CardDB.cardName.yshaarjrageunbound, 0);


            silenceTargets.Add(CardDB.cardName.ayablackpaw, 0);

        }

        private void setupRandomCards()
        {
            this.randomEffects.Add(CardDB.cardName.deadlyshot, 1); //destroy random enemy minion
            this.randomEffects.Add(CardDB.cardName.multishot, 1);

            this.randomEffects.Add(CardDB.cardName.animalcompanion, 1); //random "companion" beast
            this.randomEffects.Add(CardDB.cardName.arcanemissiles, 3); //random 3 dmg split enemies
            this.randomEffects.Add(CardDB.cardName.goblinblastmage, 1); //random 4 dmg split enemies if have mech
            this.randomEffects.Add(CardDB.cardName.avengingwrath, 8); //random 8 dmg split enemies

            this.randomEffects.Add(CardDB.cardName.flamecannon, 4); //random 4 dmg enemy minion

            //this.randomEffects.Add(CardDB.cardName.baneofdoom, 1);
            this.randomEffects.Add(CardDB.cardName.brawl, 1); //random 1 minion lives
            this.randomEffects.Add(CardDB.cardName.captainsparrot, 1);
            this.randomEffects.Add(CardDB.cardName.cleave, 1);
            this.randomEffects.Add(CardDB.cardName.forkedlightning, 1);
            this.randomEffects.Add(CardDB.cardName.gelbinmekkatorque, 1);
            this.randomEffects.Add(CardDB.cardName.iammurloc, 3);
            this.randomEffects.Add(CardDB.cardName.lightningstorm, 1); //deal 2-3 dmg all enemy minions
            this.randomEffects.Add(CardDB.cardName.madbomber, 3); //random 3 dmg split all
            this.randomEffects.Add(CardDB.cardName.mindgames, 1);
            this.randomEffects.Add(CardDB.cardName.mindcontroltech, 1); //steal random minion if they have >3
            this.randomEffects.Add(CardDB.cardName.mindvision, 1);
            this.randomEffects.Add(CardDB.cardName.powerofthehorde, 1);
            this.randomEffects.Add(CardDB.cardName.sensedemons, 2);
            this.randomEffects.Add(CardDB.cardName.tinkmasteroverspark, 1);
            this.randomEffects.Add(CardDB.cardName.totemiccall, 1); //random totem
            this.randomEffects.Add(CardDB.cardName.elitetaurenchieftain, 1); //random "power cord" card both hands
            this.randomEffects.Add(CardDB.cardName.lifetap, 1); //draw card
            this.randomEffects.Add(CardDB.cardName.soultap, 1); //draw card

            this.randomEffects.Add(CardDB.cardName.unstableportal, 1); //random minion to hand
            this.randomEffects.Add(CardDB.cardName.crackle, 1); //deal 3-6 dmg
            this.randomEffects.Add(CardDB.cardName.bouncingblade, 3); //random 1 dmg until minion dies
            this.randomEffects.Add(CardDB.cardName.coghammer, 1); //random taunt/divine shield
            this.randomEffects.Add(CardDB.cardName.madderbomber, 6); //random 6 dmg split all
            this.randomEffects.Add(CardDB.cardName.bomblobber, 1); //random 4 dmg enemy
            this.randomEffects.Add(CardDB.cardName.enhanceomechano, 1); //random taunt/windfury/divine shield own minions

            this.randomEffects.Add(CardDB.cardName.nefarian, 2);
            this.randomEffects.Add(CardDB.cardName.dieinsect, 2);
            this.randomEffects.Add(CardDB.cardName.resurrect, 2);
            this.randomEffects.Add(CardDB.cardName.fireguarddestroyer, 2);

            //TGT
            //50% minions
            this.randomEffects.Add(CardDB.cardName.mogorschampion, 1);

            this.randomEffects.Add(CardDB.cardName.gadgetzanjouster, 1);
            this.randomEffects.Add(CardDB.cardName.armoredwarhorse, 1);
            this.randomEffects.Add(CardDB.cardName.masterjouster, 1);
            this.randomEffects.Add(CardDB.cardName.tuskarrjouster, 1);
            this.randomEffects.Add(CardDB.cardName.tuskarrtotemic, 1); //random totem
            this.randomEffects.Add(CardDB.cardName.healingwave, 1); //heal 7/14 joust
            this.randomEffects.Add(CardDB.cardName.elementaldestruction, 1); //deal 4-5 dmg to all minions
            this.randomEffects.Add(CardDB.cardName.darkbargain, 2);
            this.randomEffects.Add(CardDB.cardName.varianwrynn, 3); //draw 3 cards, minions get summoned

            this.randomEffects.Add(CardDB.cardName.lockandload, 10); //random hunter card for each spell cast
            this.randomEffects.Add(CardDB.cardName.flamejuggler, 1); //random 1 dmg
            this.randomEffects.Add(CardDB.cardName.grandcrusader, 1);
            this.randomEffects.Add(CardDB.cardName.spellslinger, 1); //random spell to both hands
            randomEffects.Add(CardDB.cardName.cthun, 10); //random X dmg split enemies, X=attack
            randomEffects.Add(CardDB.cardName.fierybat, 1); //random 1 dmg
            randomEffects.Add(CardDB.cardName.spreadingmadness, 9); //random 9 dmg split all

            //todo these need more thought in getRandomPenalty
            this.randomEffects.Add(CardDB.cardName.servantofyoggsaron, 1); //random 1 spell
            this.randomEffects.Add(CardDB.cardName.cabaliststome, 1); //random 3 mage spells
            this.randomEffects.Add(CardDB.cardName.nexuschampionsaraad, 1); //random spell inspire
            this.randomEffects.Add(CardDB.cardName.xarilpoisonedmind, 1); //random toxin, random toxin deathrattle
            this.randomEffects.Add(CardDB.cardName.yoggsaronhopesend, 1); //cast X random spells equal to # previous casts
            this.randomEffects.Add(CardDB.cardName.infest, 1); //add random beast deathrattle

            this.randomEffects.Add(CardDB.cardName.goldenmonkey, 1); //replace your cards with legendaries
            this.randomEffects.Add(CardDB.cardName.timepieceofhorror, 1); //random 10 dmg split enemies
            this.randomEffects.Add(CardDB.cardName.succubus, 1); //discard card
            this.randomEffects.Add(CardDB.cardName.desertcamel, 1); //summon 1 cost from both decks
            this.randomEffects.Add(CardDB.cardName.facelesssummoner, 1); //summon random 3 cost
            this.randomEffects.Add(CardDB.cardName.hugetoad, 1); //random 1 dmg deathrattle
            this.randomEffects.Add(CardDB.cardName.hungrydragon, 1); //summon random 1 cost for enemy
            this.randomEffects.Add(CardDB.cardName.mountedraptor, 1); //summon random 1 cost deathrattle
            this.randomEffects.Add(CardDB.cardName.murlocknight, 1); //summon random murloc inspire
            this.randomEffects.Add(CardDB.cardName.rumblingelemental, 2); //random 2 dmg after each battlecry
            this.randomEffects.Add(CardDB.cardName.soulfire, 1); //discard card
            this.randomEffects.Add(CardDB.cardName.thoughtsteal, 1); //copy 2 cards from enemy deck
            this.randomEffects.Add(CardDB.cardName.zealousinitiate, 1); //give random +1/1 deathrattle
            this.randomEffects.Add(CardDB.cardName.burgle, 1); //add 2 random enemy class cards
            this.randomEffects.Add(CardDB.cardName.darkshirelibrarian, 1); //discard card, draw card deathrattle
            this.randomEffects.Add(CardDB.cardName.dementedfrostcaller, 1); //freeze random enemy every spell
            this.randomEffects.Add(CardDB.cardName.doomguard, 1); //discard 2
            this.randomEffects.Add(CardDB.cardName.evolve, 1); //replace all your minions with ones that cost 1 more
            this.randomEffects.Add(CardDB.cardName.fistofjaraxxus, 1); //random 4 dmg
            this.randomEffects.Add(CardDB.cardName.flamewaker, 1); //random 2 dmg split after spell
            this.randomEffects.Add(CardDB.cardName.knifejuggler, 1); //random 1 dmg every summon
            this.randomEffects.Add(CardDB.cardName.masterofevolution, 1); //replace minion with one that costs 1 more
            this.randomEffects.Add(CardDB.cardName.ramwrangler, 1); //summon random beast if you have a beast
            this.randomEffects.Add(CardDB.cardName.selflesshero, 1); //random divine shield deathrattle
            this.randomEffects.Add(CardDB.cardName.shifterzerus, 1); //his morphing doesn't matter but w/e he becomes could have random effects //todo sepefeets - remove him once we properly detect what he becomes
            this.randomEffects.Add(CardDB.cardName.shiftingshade, 1); //copy card from enemy deck deathrattle
            this.randomEffects.Add(CardDB.cardName.stampedingkodo, 1); // destroy random <3 attack minion
            this.randomEffects.Add(CardDB.cardName.summoningstone, 1); // summon minion with equal cost to any spell cast
            this.randomEffects.Add(CardDB.cardName.undercityhuckster, 1); //add random enemy class card deathrattle
            this.randomEffects.Add(CardDB.cardName.voidcrusher, 1); //destroy random minion for both players inspire
            this.randomEffects.Add(CardDB.cardName.renouncedarkness, 1); //replace cards/power with a new class
            this.randomEffects.Add(CardDB.cardName.confessorpaletress, 1); //random legendary inspire
            this.randomEffects.Add(CardDB.cardName.eydisdarkbane, 1); //random 3 dmg when you target her with spell
            this.randomEffects.Add(CardDB.cardName.malkorok, 1); //equip random weapon
            this.randomEffects.Add(CardDB.cardName.sylvanaswindrunner, 1); //steal random enemy deathrattle

            randomEffects.Add(CardDB.cardName.firelandsportal, 1);
            randomEffects.Add(CardDB.cardName.maelstromportal, 1);
            randomEffects.Add(CardDB.cardName.ivoryknight, 1);
            randomEffects.Add(CardDB.cardName.silvermoonportal, 1);
            randomEffects.Add(CardDB.cardName.onyxbishop, 1);
            randomEffects.Add(CardDB.cardName.swashburglar, 1);
            randomEffects.Add(CardDB.cardName.wickedwitchdoctor, 1);
            randomEffects.Add(CardDB.cardName.barnes, 1);
            randomEffects.Add(CardDB.cardName.babblingbook, 1);
            randomEffects.Add(CardDB.cardName.zoobot, 1);
            randomEffects.Add(CardDB.cardName.menageriemagician, 1);
            randomEffects.Add(CardDB.cardName.thecurator, 1);
            randomEffects.Add(CardDB.cardName.malchezaarsimp, 1);
            randomEffects.Add(CardDB.cardName.ironforgeportal, 1);
            randomEffects.Add(CardDB.cardName.netherspitehistorian, 1);
            randomEffects.Add(CardDB.cardName.atiesh, 1);
            randomEffects.Add(CardDB.cardName.moongladeportal, 1);
        }

        private void setupTargetAbilitys()
        {
            //todo sepefeets - can these be converted to card names easily so that we don't need to update for every new skin?
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS1h_001, 1);  //Lesser Heal
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS1h_001_H1, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_132_PRIEST, 1); //Heal
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS1h_001_H1_AT_132, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034, 1);  //Fireblast
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034_H1, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034_H2, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_132_MAGE, 1);  //Fireblast Rank 2
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034_H1_AT_132, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.CS2_034_H2_AT_132, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.DS1h_292, 1);  //Steady Shot
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.DS1h_292_H1, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_132_HUNTER, 1);  //Ballista Shot
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.DS1h_292_H1_AT_132, 1);
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.EX1_625t, 1);  //Mind Spike r1
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.EX1_625t2, 1);  //Mind Spike r2
            this.TargetAbilitysDatabase.Add(CardDB.cardIDEnum.AT_050t, 1);  //Lightning Jolt
        }

        private void setupDiscover()
        {
            discoverCards.Add(CardDB.cardName.tracking, 1);
            discoverCards.Add(CardDB.cardName.jeweledscarab, 1);
            discoverCards.Add(CardDB.cardName.ancientshade, 1);
            discoverCards.Add(CardDB.cardName.darkpeddler, 1);
            discoverCards.Add(CardDB.cardName.tombspider, 1);
            discoverCards.Add(CardDB.cardName.gorillabota3, 1);  // only if you have a mech
            discoverCards.Add(CardDB.cardName.etherealconjurer, 1);
            discoverCards.Add(CardDB.cardName.museumcurator, 1);
            discoverCards.Add(CardDB.cardName.ravenidol, 1);
            discoverCards.Add(CardDB.cardName.archthiefrafaam, 1);
            discoverCards.Add(CardDB.cardName.alightinthedarkness, 1);
            discoverCards.Add(CardDB.cardName.journeybelow, 1);
            discoverCards.Add(CardDB.cardName.ivoryknight, 1);
            discoverCards.Add(CardDB.cardName.netherspitehistorian, 1);
            discoverCards.Add(CardDB.cardName.drakonidoperative, 1);
            discoverCards.Add(CardDB.cardName.finderskeepers, 1);
            discoverCards.Add(CardDB.cardName.iknowaguy, 1);
            discoverCards.Add(CardDB.cardName.grimestreetinformant, 1);
            discoverCards.Add(CardDB.cardName.kabalcourier, 1);
            discoverCards.Add(CardDB.cardName.lotusagents, 1);
        }


        private void setupStrongInspireMinions()
        {
            strongInspireEffectMinions.Add(CardDB.cardName.boneguardlieutenant, 0);
            strongInspireEffectMinions.Add(CardDB.cardName.confessorpaletress, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.dalaranaspirant, 1);
            strongInspireEffectMinions.Add(CardDB.cardName.kodorider, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.kvaldirraider, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.lowlysquire, 0);
            strongInspireEffectMinions.Add(CardDB.cardName.muklaschampion, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.murlocknight, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.nexuschampionsaraad, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.recruiter, 3);
            strongInspireEffectMinions.Add(CardDB.cardName.thunderbluffvaliant, 10);
            strongInspireEffectMinions.Add(CardDB.cardName.tournamentmedic, 1);
            strongInspireEffectMinions.Add(CardDB.cardName.savagecombatant, 4);
            strongInspireEffectMinions.Add(CardDB.cardName.silverhandregent, 3);
        }

        private void setupSummonMinionSpellsDatabase()
        {
            summonMinionSpellsDatabase.Add(CardDB.cardName.mirrorimage, 2);
            summonMinionSpellsDatabase.Add(CardDB.cardName.totemiccall, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.reinforce, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.animalcompanion, 3);
            summonMinionSpellsDatabase.Add(CardDB.cardName.powerofthewild, 1); //choice
            summonMinionSpellsDatabase.Add(CardDB.cardName.feralspirit, 2);
            summonMinionSpellsDatabase.Add(CardDB.cardName.baneofdoom, 1); //only if it kills
            summonMinionSpellsDatabase.Add(CardDB.cardName.unleashthehounds, 1); //count=enemy minions
            summonMinionSpellsDatabase.Add(CardDB.cardName.forceofnature, 3);
            summonMinionSpellsDatabase.Add(CardDB.cardName.thesilverhand, 2);
            summonMinionSpellsDatabase.Add(CardDB.cardName.anyfincanhappen, 1); //count=dead murlocs
            summonMinionSpellsDatabase.Add(CardDB.cardName.thetidalhand, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.onthehunt, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.forbiddenshaping, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.forbiddenritual, 1); //count=mana spent
            summonMinionSpellsDatabase.Add(CardDB.cardName.wispsoftheoldgods, 7); //choice
            summonMinionSpellsDatabase.Add(CardDB.cardName.callofthewild, 3);
            summonMinionSpellsDatabase.Add(CardDB.cardName.standagainstdarkness, 5);
            summonMinionSpellsDatabase.Add(CardDB.cardName.bloodtoichor, 1); //if it doesn't kill
            summonMinionSpellsDatabase.Add(CardDB.cardName.iammurloc, 3); //3-5
            summonMinionSpellsDatabase.Add(CardDB.cardName.powerofthehorde, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.lightofthenaaru, 1); //if it doesn't heal to full
            summonMinionSpellsDatabase.Add(CardDB.cardName.darkwispers, 5); //choice
            summonMinionSpellsDatabase.Add(CardDB.cardName.musterforbattle, 3);
            summonMinionSpellsDatabase.Add(CardDB.cardName.livingroots, 2); //choice
            summonMinionSpellsDatabase.Add(CardDB.cardName.ballofspiders, 3);
            summonMinionSpellsDatabase.Add(CardDB.cardName.totemicslam, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.firelandsportal, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.maelstromportal, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.protecttheking, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.silvermoonportal, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.karakazham, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.moongladeportal, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.ironforgeportal, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.jadeidol, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.jadeblossom, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.jadeshuriken, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.callinthefinishers, 1);
            summonMinionSpellsDatabase.Add(CardDB.cardName.jadelightning, 1);
        }

        private void setupAlsoEquipsWeaponDB()
        {
            alsoEquipsWeaponDB.Add(CardDB.cardName.arathiweaponsmith, 2);
            alsoEquipsWeaponDB.Add(CardDB.cardName.blingtron3000, 3); //random weapon so be conservative
            alsoEquipsWeaponDB.Add(CardDB.cardName.malkorok, 3); //random weapon so be conservative
            alsoEquipsWeaponDB.Add(CardDB.cardName.musterforbattle, 1);
            alsoEquipsWeaponDB.Add(CardDB.cardName.nzothsfirstmate, 1);
            alsoEquipsWeaponDB.Add(CardDB.cardName.upgrade, 1); //if we don't have a weapon
            alsoEquipsWeaponDB.Add(CardDB.cardName.medivhtheguardian, 1);
        }
    }
}