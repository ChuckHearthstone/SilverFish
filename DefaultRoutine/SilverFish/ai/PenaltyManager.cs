using System;
using System.Collections.Generic;
using SilverFish.Enums;

namespace HREngine.Bots
{
    public class PenaltyManager
    {
        //todo acolyteofpain
        //todo better aoe-penality

        public Dictionary<CardName, int> HealTargetDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> HealHeroDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> HealAllDatabase = new Dictionary<CardName, int>();


        Dictionary<CardName, int> DamageAllDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> DamageHeroDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> DamageRandomDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> DamageAllEnemysDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> HeroPowerEquipWeapon = new Dictionary<CardName, int>();

        Dictionary<CardName, int> enrageDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> silenceDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> OwnNeedSilenceDatabase = new Dictionary<CardName, int>();

        Dictionary<CardName, int> heroAttackBuffDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> attackBuffDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> healthBuffDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> tauntBuffDatabase = new Dictionary<CardName, int>();

        Dictionary<CardName, int> lethalHelpers = new Dictionary<CardName, int>();
        
        Dictionary<CardName, int> spellDependentDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> dragonDependentDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> elementalLTDependentDatabase = new Dictionary<CardName, int>();

        public Dictionary<CardName, int> cardDiscardDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> destroyOwnDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> destroyDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> buffingMinionsDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> buffing1TurnDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> heroDamagingAoeDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> randomEffects = new Dictionary<CardName, int>();

        Dictionary<CardName, int> silenceTargets = new Dictionary<CardName, int>();

        Dictionary<CardName, int> returnHandDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> GangUpDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> buffHandDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> equipWeaponPlayDatabase = new Dictionary<CardName, int>(); 

        Dictionary<CardName, int> priorityDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, int> UsefulNeedKeepDatabase = new Dictionary<CardName, int>();
        Dictionary<CardName, CardIdEnum> choose1database = new Dictionary<CardName, CardIdEnum>();
        Dictionary<CardName, CardIdEnum> choose2database = new Dictionary<CardName, CardIdEnum>();

        public Dictionary<CardName, int> DamageTargetDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> DamageTargetSpecialDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> maycauseharmDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> cardDrawBattleCryDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> cardDrawDeathrattleDatabase = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> priorityTargets = new Dictionary<CardName, int>();
        public Dictionary<CardName, int> specialMinions = new Dictionary<CardName, int>(); //minions with cardtext, but no battlecry
        public Dictionary<CardName, int> ownSummonFromDeathrattle = new Dictionary<CardName, int>();

        Dictionary<TAG_RACE, int> ClassRacePriorityWarloc = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityHunter = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityMage = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityShaman = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityDruid = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityPaladin = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityPriest = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityRouge = new Dictionary<TAG_RACE, int>();
        Dictionary<TAG_RACE, int> ClassRacePriorityWarrior = new Dictionary<TAG_RACE, int>();
        
        ComboBreaker cb;
        Hrtprozis prozis;
        Settings settings;
        CardDB cdb;
        Ai ai;

        private static PenaltyManager instance;

        public static PenaltyManager Instance
        {
            get
            {
                return instance ?? (instance = new PenaltyManager());
            }
        }

        public void setInstances()
        {
            ai = Ai.Instance;
            cb = ComboBreaker.Instance;
            prozis = Hrtprozis.Instance;
            settings = Settings.Instance;
            cdb = CardDB.Instance;
        }

        private PenaltyManager()
        {
            setupHealDatabase();
            setupEnrageDatabase();
            setupDamageDatabase();
            setupPriorityList();
            setupsilenceDatabase();
            setupAttackBuff();
            setupHealthBuff();
            setupCardDrawBattlecry();
            setupDiscardCards();
            setupDestroyOwnCards();
            setupSpecialMins();
            setupEnemyTargetPriority();
            setupHeroDamagingAOE();
            setupBuffingMinions();
            setupRandomCards();
            setupLethalHelpMinions();
            setupSilenceTargets();
            setupUsefulNeedKeepDatabase();
            setupRelations();
            setupChooseDatabase();
            setupClassRacePriorityDatabase();
            setupGangUpDatabase();
            setupOwnSummonFromDeathrattle();
			setupbuffHandDatabase();
            setupequipWeaponPlayDatabase();
            setupReturnBackToHandCards();
        }


        public int getAttackWithMininonPenality(Minion m, Playfield p, Minion target)
        {
            int retval = ai.botBase.getAttackWithMininonPenality(m, p, target);
            if (retval < 0 || retval > 499) return retval;

            retval += getAttackSecretPenality(m, p, target);
            if (!p.isLethalCheck && m.name == CardName.bloodimp) retval += 50;
            switch (m.name)
            {
                case CardName.leeroyjenkins:
                    if (!target.own && target.name == CardName.whelp) return 500;
                    break;
                case CardName.bloodmagethalnos:
                    if (!target.isHero && Ai.Instance.lethalMissing <= 5)
                    {
                        if (!target.taunt)
                        {
                            if (m.HealthPoints <= target.Attack && m.own && !m.divineshild && !m.immune) return 65;
                        }
                    }
                    goto case CardName.aiextra1;
                
                
                case CardName.acolyteofpain: goto case CardName.aiextra1;
                case CardName.clockworkgnome: goto case CardName.aiextra1;
                case CardName.loothoarder: goto case CardName.aiextra1;
                case CardName.mechanicalyeti: goto case CardName.aiextra1;
                case CardName.mechbearcat: goto case CardName.aiextra1;
                case CardName.tombpillager: goto case CardName.aiextra1;
                case CardName.toshley: goto case CardName.aiextra1;
                case CardName.webspinner: goto case CardName.aiextra1;
                case CardName.aiextra1:
                    
                    if (m.HealthPoints <= target.Attack && m.own && !m.divineshild && !m.immune)
                    {
                        int carddraw = 1; 
                        if (p.owncards.Count + carddraw > 10) retval += 15 * (p.owncards.Count + carddraw - 10);
                        else retval += 3 * p.optionsPlayedThisTurn;
                    }
                    return retval;
                    break;
            }
            if (this.specialMinions.ContainsKey(m.name) && target.HealthPoints > m.Attack && !target.isHero) retval++;
            if (this.UsefulNeedKeepDatabase.ContainsKey(m.name) && !target.isHero && !(m.divineshild || target.Attack == 0)) retval++;
            if (m.justBuffed > 0)
            {
                if (m.divineshild || m.immune) {}
                else if (target.poisonous || target.Attack >= m.HealthPoints) retval += m.justBuffed;
            }
            return retval;
        }

        public int getAttackWithHeroPenality(Minion target, Playfield p)
        {
            bool isLethalCheck = p.isLethalCheck;
            int retval = ai.botBase.getAttackWithHeroPenality(target, p);
            if (retval < 0 || retval > 499) return retval;

            if (!isLethalCheck && target.isHero && target.HealthPoints > settings.enfacehp)
            {
                switch (settings.weaponOnlyAttackMobsUntilEnfacehp)
                {
                    case 1:
                        if (p.ownWeapon.Durability == 1 && p.ownWeapon.Angr > 1) return 500;
                        break;
                    case 2:
                        return 500;
                    case 3:
                        if (p.ownWeapon.Durability == 1) return 500;
                        break;
                    case 4:
                        if (weaponInHandAttackNextTurn(p) == 0) return 500;
                        break;
                    case 5:
                        int wAttack = weaponInHandAttackNextTurn(p);
                        if (wAttack > 1 || (wAttack == 1 && p.ownWeapon.Angr == 1)) { }
                        else return 500;
                        break;
                    default:
                        if (p.ownWeapon.Angr > 1) return 500;
                        break;
                }
            }

            if (!isLethalCheck && p.enemyWeapon.name == CardName.swordofjustice)
            {
                return 28;
            }

            switch (p.ownWeapon.name)
            {
                case CardName.atiesh:
                    if (!isLethalCheck)
                    {
                        if (target.isHero) return 500;
                        else return 15;
                    }
                    break;
                case CardName.doomhammer:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardName.rockbiterweapon && hc.canplayCard(p, true)) return 10;
                    }
                    break;
                case CardName.eaglehornbow:
                    if (p.ownWeapon.Durability == 1)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardName.arcaneshot || hc.card.name == CardName.killcommand) return -p.ownWeapon.Angr - 1;
                        }
                        if (p.ownSecretsIDList.Count >= 1) return 20;

                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Secret) return 20;
                        }
                    }
                    break;
                case CardName.spiritclaws:
                    if (!isLethalCheck && p.ownWeapon.Angr == 1)
                    {
                        if (target.isHero) return 500;
                        else if (target.HealthPoints == 1 && this.specialMinions.ContainsKey(target.name)) return 0;
                        else return 7;
                    }
                    break;
                case CardName.gorehowl:
                    if (target.isHero && p.ownWeapon.Angr >= 3) return 10;
                    break;
                case CardName.brassknuckles:
                    if (target.own)
                    {
                        if (p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob) != null)
                        {
                            return -5;
                        }
                    }
                    else
                    {
                        if (p.enemyAnzCards > 3) return -5;
                    }
                    break;
            }

            if (p.ownWeapon.Durability >= 1)
            {
                int wAttack = weaponInHandAttackNextTurn(p);
                if (p.ownWeapon.Angr == 1 && wAttack == 0 && (p.ownHeroAblility.card.name == CardName.poisoneddaggers || p.ownHeroAblility.card.name == CardName.daggermastery)) wAttack = 1;
                if (wAttack > 0) retval = -p.ownWeapon.Angr - 1; // so he doesnt "lose" the weapon in evaluation :D
            }
            if (p.ownWeapon.Angr == 1 && p.ownHeroName == HeroEnum.thief)
            {
                if (target.HealthPoints < 11) retval += 1;
                else retval += -1;
            }
            return retval;
        }

        public int weaponInHandAttackNextTurn(Playfield p)
        {
            foreach (Handmanager.Handcard c in p.owncards)
            {
                if (c.card.type == CardDB.CardType.WEAPON && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
                {
                    return c.card.Attack;
                }
                if (this.equipWeaponPlayDatabase.ContainsKey(c.card.name) && c.card.name != CardName.upgrade && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
                {
                    return this.equipWeaponPlayDatabase[c.card.name];
                }
            }
            return 0;
        }

        public int getPlayCardPenality(CardDB.Card card, Minion target, Playfield p)
        {
            int retval = ai.botBase.getPlayCardPenality(card, target, p);
            if (retval < 0 || retval > 499) return retval;

            CardName name = card.name;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(card, target, p);
            int tbuff = getTauntBuffPenality(card, target, p);
            if (name == CardName.markofthewild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
            {
                retval = 0;
            }
            else
            {
                retval += abuff + tbuff;
            }
            retval += getHPBuffPenality(card, target, p);
            retval += getSilencePenality(name, target, p);
            retval += getDamagePenality(card, target, p);
            retval += getHealPenality(name, target, p);
            retval += getCardDrawPenality(card, target, p);
            retval += getCardDrawofEffectMinions(card, p);
            retval += getCardDiscardPenality(name, p);
            retval += getDestroyOwnPenality(name, target, p);

            retval += getDestroyPenality(name, target, p);
            retval += getSpecialCardComboPenalitys(card, target, p);
            retval += getRandomPenaltiy(card, p, target);
            retval += getBuffHandPenalityPlay(name, p);
            if (!p.isLethalCheck)
            {
                retval += cb.getPenalityForDestroyingCombo(card, p);
                retval += cb.getPlayValue(card.cardIDenum);
            }

            retval += playSecretPenality(card, p);
            retval += getPlayCardSecretPenality(card, p);

            return retval;
        }


        private int getAttackBuffPenality(CardDB.Card card, Minion target, Playfield p)
        {
            CardName name = card.name;
            if (name == CardName.darkwispers && card.cardIDenum != CardIdEnum.GVG_041a) return 0;
            int pen = 0;
            //buff enemy?

            if (!p.isLethalCheck && (card.name == CardName.savageroar || card.name == CardName.bloodlust))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }
                if ((p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) && card.name == CardName.savageroar) targets++;

                if (targets <= 2)
                {
                    return 20;
                }
            }

            if (!this.attackBuffDatabase.ContainsKey(name)) return 0;
            if (target == null) return 60;
            if (!target.isHero && !target.own)
            {
                if (card.type == CardDB.CardType.MOB && p.ownMinions.Count == 0) return 2;
                
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    switch (hc.card.name)
                    {
                        case CardName.biggamehunter:
                            if (target.Attack + this.attackBuffDatabase[name] > 6) return 5;
                            break;
                        case CardName.shadowworddeath:
                            if (target.Attack + this.attackBuffDatabase[name] > 4) return 5;
                            break;
                        default:
                            break;
                    }
                }
                if (card.name == CardName.crueltaskmaster || card.name == CardName.innerrage)
                {
                    Minion m = target;

                    if (m.HealthPoints == 1)
                    {
                        return 0;
                    }

                    if (!m.wounded && (m.Attack >= 4 || m.HealthPoints >= 5))
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardName.execute) return 0;
                        }
                    }
                    pen = 30;
                }
                else
                {
                    pen = 500;
                }
            }
            if (!target.isHero && target.own)
            {
                Minion m = target;
                if (!m.Ready)
                {
                    switch (card.name)
                    {
                        case CardName.markofyshaarj:
                            if (target.stealth)
                            {
                                if ((TAG_RACE)target.handcard.card.race == TAG_RACE.PET) return 3;
                                else return 7;
                            }
                            if ((TAG_RACE)target.handcard.card.race == TAG_RACE.PET && p.owncards.Count < 2) return 3;
                            return 50;

                        default:
                            break;
                    }
                    return 50;
                }
                if (m.HealthPoints == 1 && !m.divineshild && !this.buffing1TurnDatabase.ContainsKey(name))
                {
                    return 10;
                }
                if (m.Attack == 0)
                {
                    if (!m.silenced && m.handcard.card.deathrattle) return -8;
                    return -5;
                }
            }

            return pen;
        }

        private int getHPBuffPenality(CardDB.Card card, Minion target, Playfield p)
        {
            CardName name = card.name;
            int pen = 0;

            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardName.darkwispers && card.cardIDenum != CardIdEnum.GVG_041a) return 0;

            if (target != null && !target.own && !this.tauntBuffDatabase.ContainsKey(name))
            {
                pen = 500 + p.ownMinions.Count;
            }

            return pen;
        }


        private int getTauntBuffPenality(CardDB.Card card, Minion target, Playfield p)
        {
            CardName name = card.name;
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardName.markofnature && card.cardIDenum != CardIdEnum.EX1_155b) return 0;
            if (name == CardName.darkwispers && card.cardIDenum != CardIdEnum.GVG_041a) return 0;
            
            if (target == null) return 3;
            if (!target.isHero && !target.own)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardName.theblackknight) return 0;
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

        private int getSilencePenality(CardName name, Minion target, Playfield p)
        {
            int pen = 0;

            if (target == null)
            {
                if (name == CardName.ironbeakowl || name == CardName.spellbreaker || name == CardName.keeperofthegrove)
                {
                    return 20;
                }
                return 0;
            }

            if (target.own)
            {
                if (this.silenceDatabase.ContainsKey(name))
                {
                    if (!target.silenced && this.OwnNeedSilenceDatabase.ContainsKey(target.name)) return -5;
                    if (target.Attack < target.handcard.card.Attack || target.maxHp < target.handcard.card.Health
                        || target.enemyPowerWordGlory > 0 || target.enemyBlessingOfWisdom > 0
                        || (target.frozen && !target.playedThisTurn && target.numAttacksThisTurn == 0))
                    {
                        return 0;
                    }
                    pen += 500;
                }
            }
            else
            {
                switch (target.name)
                {
                    case CardName.masterchest: return 500;
                }
                if (this.silenceDatabase.ContainsKey(name))
                {
                    pen = 5;
                    if (p.isLethalCheck)
                    {
                        //during lethal we only silence taunt, or if its a mob (owl/spellbreaker) + we can give him charge
                        if (target.taunt || (name == CardName.ironbeakowl && (p.ownMinions.Find(x => x.name == CardName.tundrarhino) != null || p.owncards.Find(x => x.card.name == CardName.charge) != null)) || (name == CardName.spellbreaker && p.owncards.Find(x => x.card.name == CardName.charge) != null)) return 0;

                        return 500;
                    }

                    if (!target.silenced && this.OwnNeedSilenceDatabase.ContainsKey(target.name))
                    {
                        if (target.taunt) pen += 15;
                        return 500;
                    }

                    if (!target.silenced)
                    {
                        if (this.priorityDatabase.ContainsKey(target.name)) return 0;
                        if (this.silenceTargets.ContainsKey(target.name)) return 0;
                        if (target.handcard.card.deathrattle) return 0;
                    }

                    if (target.Attack <= target.handcard.card.Attack && target.maxHp <= target.handcard.card.Health && !target.taunt && !target.windfury && !target.divineshild && !target.poisonous && !target.lifesteal && !this.specialMinions.ContainsKey(name))
                    {
                        if (name == CardName.keeperofthegrove) return 500;
                        return 30;
                    }

                    if (target.Attack > target.handcard.card.Attack || target.maxHp > target.handcard.card.Health)
                    {
                        return 0;
                    }

                    return pen;
                }
            }

            return pen;

        }

        private int getDamagePenality(CardDB.Card card, Minion target, Playfield p)
        {
            CardName name = card.name;
            int pen = 0;

            if (name == CardName.shieldslam && p.ownHero.armor == 0) return 500;
            if (name == CardName.savagery && p.ownHero.Attack == 0) return 500;
            
            //aoe damage *************************************************************************************
            int aoeDamageType = 0;
            if (this.DamageAllEnemysDatabase.ContainsKey(name)) aoeDamageType = 1;
            else if (p.anzOwnAuchenaiSoulpriest >= 1 && HealAllDatabase.ContainsKey(name)) aoeDamageType = 2;
            else if (this.DamageAllDatabase.ContainsKey(name)) aoeDamageType = 3;
            if (aoeDamageType > 0)
            {
                if (p.enemyMinions.Count == 0)
                {
                    if (name == CardName.cthun) return 0;
                    return 300;
                }

                int aoeDamage = 0;
                if (aoeDamageType == 1) aoeDamage = (card.type == CardDB.CardType.SPELL) ? p.getSpellDamageDamage(this.DamageAllEnemysDatabase[name]) : this.DamageAllEnemysDatabase[name];
                else if (aoeDamageType == 2) aoeDamage = (card.type == CardDB.CardType.SPELL) ? p.getSpellDamageDamage(this.HealAllDatabase[name]) : this.HealAllDatabase[name];
                else if (aoeDamageType == 3)
                {
                    if (name == CardName.revenge && p.ownHero.HealthPoints <= 12) aoeDamage = p.getSpellDamageDamage(3);
                    else aoeDamage = (card.type == CardDB.CardType.SPELL) ? p.getSpellDamageDamage(this.DamageAllDatabase[name]) : this.DamageAllDatabase[name];
                }
                
                int preventDamage = 0;
                int lostOwnDamage = 0;
                int lostOwnHp = 0;
                int lostOwnMinions = 0;
                int survivedEnemyMinions = 0;
                int survivedEnemyMinionsAngr = 0;
                bool frothingberserkerEnemy = false;
                bool frothingberserkerOwn = false;
                bool grimpatronEnemy = false;
                bool grimpatronOwn = false;
                int numSpecialMinionsEnemy = 0;


                int preventDamageAdd = 0;
                int anz = p.enemyMinions.Count;
                for (int i = 0; i < anz; i++)
                {
                    Minion m = p.enemyMinions[i];
                    if (aoeDamage >= m.HealthPoints && !m.divineshild)
                    {
                        switch (name)
                        {
                            case CardName.sleepwiththefishes: 
                                if (!m.wounded) continue;
                                break;
                            case CardName.dragonfirepotion: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) continue;
                                break;
                            case CardName.corruptedseer: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) continue;
                                break;
                            case CardName.shadowvolley: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                break;
                            case CardName.demonwrath: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                break;
                            case CardName.scarletpurifier: 
                                if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                break;
                            case CardName.yseraawakens: 
                                if (m.name == CardName.ysera) continue;
                                break;
                            case CardName.lightbomb: 
                                if (m.HealthPoints > m.Attack) continue;
                                break;
                        }
                        
                        if (this.specialMinions.ContainsKey(m.name)) numSpecialMinionsEnemy++;
                        switch (m.name)
                        {
                            case CardName.direwolfalpha: 
                                if (m.silenced) break;
                                
                                if (i > 0)
                                {
                                    if (p.enemyMinions[i - 1].divineshild)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].HealthPoints <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i - 1].HealthPoints > aoeDamage)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].HealthPoints - aoeDamage <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                }
                                if (i < anz - 1)
                                {
                                    if (p.enemyMinions[i + 1].divineshild)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].HealthPoints <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i + 1].HealthPoints > aoeDamage)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].HealthPoints - aoeDamage <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                }
                                break;
                            case CardName.flametonguetotem: 
                                if (m.silenced) break;
                                if (i > 0)
                                {
                                    if (p.enemyMinions[i - 1].divineshild)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].HealthPoints <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i - 1].HealthPoints > aoeDamage)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].HealthPoints - aoeDamage <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                }
                                if (i < anz - 1)
                                {
                                    if (p.enemyMinions[i + 1].divineshild)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].HealthPoints <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i + 1].HealthPoints > aoeDamage)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].HealthPoints - aoeDamage <= p.ownHero.Attack) preventDamageAdd = 1;
                                    }
                                }
                                break;
                            case CardName.leokk: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardName.raidleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardName.stormwindchampion: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardName.grimscaleoracle: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                                 
                            case CardName.murlocwarleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardName.malganis: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.DEMON && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardName.southseacaptain: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardName.timberwolf: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardName.warhorsetrainer: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.name == CardName.silverhandrecruit && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardName.warsongcommander: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.charge > 0 && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardName.tunneltrogg:
                                preventDamage++;
                                break;
                            case CardName.secretkeeper:
                                preventDamage++;
                                break;
                        }
                        preventDamage += m.Attack;
                    }
                    else
                    {
                        survivedEnemyMinions++;
                        if (survivedEnemyMinionsAngr < m.Attack) survivedEnemyMinionsAngr = m.Attack;
                        if (!m.wounded && this.enrageDatabase.ContainsKey(name)) preventDamage -= this.enrageDatabase[name];
                        else if (m.name == CardName.gurubashiberserker) preventDamage -= 3;
                        else if (m.name == CardName.frothingberserker) frothingberserkerEnemy = true;
                        else if (m.name == CardName.grimpatron) { preventDamage -= 3; grimpatronEnemy = true; }
                    }
                }
                preventDamage += preventDamageAdd;

                if (aoeDamageType > 1)
                {
                    anz = p.ownMinions.Count;
                    for (int i = 0; i < anz; i++)
                    {
                        Minion m = p.ownMinions[i];
                        if (aoeDamage >= m.HealthPoints && !m.divineshild)
                        {
                            switch (name)
                            {
                                case CardName.sleepwiththefishes: 
                                    if (!m.wounded) continue;
                                    break;
                                case CardName.dragonfirepotion: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) continue;
                                    break;
                                case CardName.corruptedseer: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) continue;
                                    break;
                                case CardName.shadowvolley: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                    break;
                                case CardName.demonwrath: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                    break;
                                case CardName.scarletpurifier: 
                                    if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                    break;
                                case CardName.yseraawakens: 
                                    if (m.name == CardName.ysera) continue;
                                    break;
                                case CardName.lightbomb: 
                                    if (m.HealthPoints > m.Attack) continue;
                                    break;
                            }

                            switch (m.name)
                            {
                                case CardName.direwolfalpha: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].HealthPoints > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 1;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].HealthPoints > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 1;
                                    break;
                                case CardName.flametonguetotem: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].HealthPoints > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 2;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].HealthPoints > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 2;
                                    break;
                                case CardName.leokk: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardName.raidleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardName.stormwindchampion: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardName.grimscaleoracle: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                
                                case CardName.murlocwarleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardName.malganis: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.DEMON && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardName.southseacaptain: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardName.timberwolf: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardName.warhorsetrainer: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.name == CardName.silverhandrecruit && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardName.warsongcommander: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.charge > 0 && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                            }
                            lostOwnHp += m.HealthPoints; 
                            lostOwnDamage += m.Attack;

                            lostOwnMinions++;
                            if (!m.wounded && this.enrageDatabase.ContainsKey(name)) lostOwnDamage += this.enrageDatabase[name];
                            else if (m.name == CardName.gurubashiberserker && m.HealthPoints > 1) lostOwnDamage += 3;
                            else if (m.name == CardName.frothingberserker) frothingberserkerOwn = true;
                            else if (m.name == CardName.grimpatron) { lostOwnDamage += 3; grimpatronOwn = true; }
                        }
                    }
                    
                    if (p.ownMinions.Count - lostOwnMinions - survivedEnemyMinions > 0)
                    {
                        if (preventDamage >= lostOwnDamage) return 0;
                        return (lostOwnDamage - preventDamage) * 2;
                    }
                    else
                    {
                        if (preventDamage >= lostOwnDamage * 2 + 1) return 0;
                        int MinionBalance = lostOwnMinions - (p.enemyMinions.Count - survivedEnemyMinions);
                        if (MinionBalance > 0 && preventDamage <= lostOwnDamage) return 80;
                        if (survivedEnemyMinions > 0)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == CardName.execute) return 0;
                        }
                        if (lostOwnHp <= preventDamage)
                        {
                            if (MinionBalance <= 0) return 1;
                            return 10;
                        }
                        else return 30;
                    }
                }
                else 
                {

                    if (preventDamage > 5 || (p.enemyMinions.Count - survivedEnemyMinions) >= 4) return 0;
                    else if (name == CardName.holynova && preventDamage >= 0)
                    {
                        int ownWoundedMinions = 0;
                        foreach (Minion m in p.ownMinions) if (m.wounded) ownWoundedMinions++;
                        if (ownWoundedMinions > 2) return 20;
                    }

                    if (survivedEnemyMinions > 0)
                    {
                        int hasExecute = 0;
                        foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == CardName.execute) hasExecute++;
                        if (hasExecute > 0)
                        {
                            if (survivedEnemyMinions <= hasExecute) return 0;
                            preventDamage += survivedEnemyMinionsAngr;
                            if (preventDamage > 6) preventDamage = 6;
                        }
                    }

                    int tmp = 0;
                    Minion bogMob = null;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.Attack > tmp)
                        {
                            tmp = m.Attack;
                            bogMob = m;
                        }
                    }
                    if (bogMob != null && bogMob.Attack >= 4 && bogMob.HealthPoints > preventDamage)
                    {
                        preventDamage = 6;
                    }

                    return (6 - preventDamage) * 20 - numSpecialMinionsEnemy * 8 - p.spellpower;
                }
            }
            //END aoe damage **********************************************************************************

            if (target == null) return 0;

            if (target.own && target.isHero)
            {
                if (DamageTargetDatabase.ContainsKey(name) || DamageTargetSpecialDatabase.ContainsKey(name) || (p.anzOwnAuchenaiSoulpriest >= 1 && HealTargetDatabase.ContainsKey(name)))
                {
                    pen = 500;
                }
            }

            if (!p.isLethalCheck && !target.own && target.isHero)
            {
                if (name == CardName.baneofdoom)
                {
                    pen = 500;
                }
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
                        return pen;
                    }
                    
                    if (m.name == CardName.madscientist && p.ownHeroStartClass == TAG_CLASS.HUNTER) return 500;

                    // no pen if we have battlerage for example
                    int dmg = this.DamageTargetDatabase.ContainsKey(name) ? this.DamageTargetDatabase[name] : this.HealTargetDatabase[name];
                    switch (card.cardIDenum)
                    {
                        case CardIdEnum.EX1_166a: dmg = 2 - p.spellpower; break; 
                        case CardIdEnum.CS2_031: if (!target.frozen) return 0; break; 
                        case CardIdEnum.EX1_408: if (p.ownHero.HealthPoints <= 12) dmg = 6; break; 
                        case CardIdEnum.EX1_539: 
                            foreach (Minion mn in p.ownMinions)
                            {
                                if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.PET) { dmg = 5; break; }
                            }
                            break;
                    }
                    if (card.type == CardDB.CardType.SPELL) dmg = p.getSpellDamageDamage(dmg);
                
                    if (m.HealthPoints > dmg)
                    {
                        switch (m.name)
                        {
                            case CardName.gurubashiberserker: return 0; break;
                            case CardName.axeflinger: return 0; break;
                            case CardName.gahzrilla: return 0; break;
                            case CardName.garr: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardName.hoggerdoomofelwynn: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardName.acolyteofpain: if (p.owncards.Count <= 3) return 0; break;
                            case CardName.dragonegg: if (p.ownMinions.Count <= 6) return 5; break;
                            case CardName.impgangboss: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardName.grimpatron: if (p.ownMinions.Count <= 6) return 0; break;
                        }
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardName.battlerage) return pen;
                            if (hc.card.name == CardName.rampage) return pen;
                        }
                    }
                    else
                    {
                        if (p.isLethalCheck && dmg == 1 && p.enemyHero.HealthPoints < 3)
                        {
                            switch (m.name)
                            {
                                case CardName.lepergnome: return 0; break;
                                case CardName.axeflinger: return 0; break;
                            }
                        }
                        if (cardDrawDeathrattleDatabase.ContainsKey(m.name))
                        {
                            if (ai.lethalMissing <= 5 && p.lethalMissing() <= 5) pen += 115 + (dmg - m.HealthPoints) * 10; //behav compensation
                            if (p.enemyAnzCards == 9) pen += 60; //drawACard compensation
                            return 10;
                        }
                    }
                    if (m.handcard.card.deathrattle) return 10;

                    pen = 500;
                }

                //special cards
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    int dmg = DamageTargetSpecialDatabase[name];
                    Minion m = target; 
                    switch (name)
                    {
                        case CardName.crueltaskmaster: if (m.HealthPoints >= 2) return 0; break;
                        case CardName.innerrage: if (m.HealthPoints >= 2) return 0; break;
                        case CardName.demonfire: if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0; break;
                        case CardName.demonheart: if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0; break;
                        case CardName.earthshock:
                            if (m.HealthPoints >= 2)
                            {
                                if ((!m.silenced && this.OwnNeedSilenceDatabase.ContainsKey(m.name)) 
                                    || m.Attack < m.handcard.card.Attack || m.maxHp < m.handcard.card.Health 
                                    || m.enemyPowerWordGlory > 0 || m.enemyBlessingOfWisdom > 0
                                    || (m.frozen && !m.playedThisTurn && m.numAttacksThisTurn == 0))
                                    return 0;
                                if ((enrageDatabase.ContainsKey(m.name) || priorityDatabase.ContainsKey(m.name)) && !m.silenced) return 500;
                            }
                            else return 500; //dont silence other own minions
                            break;
                    }
                    if (m.HealthPoints > dmg)
                    {
                        if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready) // no pen if own is enrage
                        {
                            return pen;
                        }

                        foreach (Handmanager.Handcard hc in p.owncards) // no pen if we have battlerage for example
                        {
                            switch (hc.card.name)
                            {
                                case CardName.battlerage: return pen; break;
                                case CardName.rampage: return pen; break;
                                case CardName.bloodwarriors: return pen; break;
                            }
                        }
                    }
                    pen = 500;
                }
            }
            if (!target.own && !target.isHero)
            {
                int realDamage = 0;
                if (DamageTargetSpecialDatabase.ContainsKey(name))
                {
                    realDamage = (card.type == CardDB.CardType.SPELL) ? p.getSpellDamageDamage(this.DamageTargetSpecialDatabase[name]) : this.DamageTargetSpecialDatabase[name];
                    switch (name)
                    {
                        case CardName.soulfire: if (target.HealthPoints <= realDamage - 2) pen = 10; break; 
                        case CardName.baneofdoom: if (target.HealthPoints > realDamage) pen = 10; break; 
                        case CardName.shieldslam: if (target.HealthPoints <= 4 || target.Attack <= 4) pen = 20; break; 
                        case CardName.bloodtoichor: if (target.HealthPoints <= realDamage) pen = 2; break; 
                    }
                }
                else
                {
                    if (DamageTargetDatabase.ContainsKey(name))
                    {
                        realDamage = this.DamageTargetDatabase[name];
                        switch (card.cardIDenum)
                        {
                            case CardIdEnum.EX1_166a: realDamage = 2 - p.spellpower; break; 
                            case CardIdEnum.CS2_031: if (!target.frozen) return 0; break; 
                            case CardIdEnum.EX1_408: if (p.ownHero.HealthPoints <= 12) realDamage = 6; break; 
                            case CardIdEnum.EX1_539: 
                                foreach (Minion mn in p.ownMinions)
                                {
                                    if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.PET) { realDamage = 5; break; }
                                }
                                break;
                        }
                        if (card.type == CardDB.CardType.SPELL) realDamage = p.getSpellDamageDamage(realDamage);
                    }
                }
                if (realDamage == 0) realDamage = card.Attack;
                if (target.name == CardName.grimpatron && realDamage < target.HealthPoints) return 500;
            }

            return pen;
        }

        private int getHealPenality(CardName name, Minion target, Playfield p)
        {
            ///Todo healpenality for aoe heal
            ///todo auchenai soulpriest
            if (p.anzOwnAuchenaiSoulpriest >= 1) return 0;
            int pen = 0;
            int heal = 0;


            switch (name)
            {
                case CardName.treeoflife:
                    {
                        int mheal = 0;
                        int wounded = 0;
                        if (p.ownHero.wounded) wounded++;
                        foreach (Minion mi in p.ownMinions)
                        {
                            mheal += Math.Min((mi.maxHp - mi.HealthPoints), 4);
                            if (mi.wounded) wounded++;
                        }
                        if (mheal == 0) return 500;
                        if (mheal <= 7 && wounded <= 2) return 20;
                    }
                    break;

                case CardName.renojackson:
                    if (p.ownHero.HealthPoints < 16)
                    {
                        int retval = p.ownHero.HealthPoints - 16;
                        if (p.ownHeroHasDirectLethal()) return retval * 10;
                        else return retval * 2;
                    }
                    else
                    {
                        pen = (p.ownHero.HealthPoints - 15) / 2;
                        if (p.ownAbilityReady && cardDrawBattleCryDatabase.ContainsKey(p.ownHeroAblility.card.name)) pen += 20;
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (!cardDrawBattleCryDatabase.ContainsKey(hc.card.name)) continue;
                            pen += 20;
                            break;
                        }
                        return pen;
                    }
                    break;

                case CardName.circleofhealing:
                    {
                        int mheal = 0;
                        int wounded = 0;
                        //int eheal = 0;
                        foreach (Minion mi in p.ownMinions)
                        {
                            mheal += Math.Min((mi.maxHp - mi.HealthPoints), 4);
                            if (mi.wounded) wounded++;
                        }
                        //Console.WriteLine(mheal + " circle");
                        if (mheal == 0) return 500;
                        if (mheal <= 7 && wounded <= 2) return 20;
                    }
                    break;
            }

            if (HealTargetDatabase.ContainsKey(name))
            {
                if (target == null) return 10;
                heal = HealTargetDatabase[name];
                if (target.isHero && !target.own) return 510; // dont heal enemy
                if ((target.isHero && target.own) && p.ownHero.HealthPoints == 30) return 150;
                if ((target.isHero && target.own) && p.ownHero.HealthPoints + heal - 1 > 30) pen = p.ownHero.HealthPoints + heal - 30;
                Minion m = new Minion();

                if (!target.isHero && target.own)
                {
                    m = target;
                    int wasted = 0;
                    if (m.HealthPoints == m.maxHp) return 500;
                    if (m.HealthPoints + heal - 1 > m.maxHp) wasted = m.HealthPoints + heal - m.maxHp;
                    pen = wasted;

                    if ((m.taunt || this.UsefulNeedKeepDatabase.ContainsKey(m.name)) && wasted <= 2 && m.HealthPoints < m.maxHp) pen -= 5; // bonus for healing a taunt/useful minion

                    if (m.HealthPoints + heal <= m.maxHp) pen = -1;
                }

                if (!target.isHero && !target.own)
                {
                    m = target;
                    if (m.HealthPoints == m.maxHp) return 500;
                    // no penality if we heal enrage enemy
                    if (enrageDatabase.ContainsKey(m.name))
                    {
                        return pen;
                    }
                    // no penality if we have heal-trigger :D
                    int i = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.name == CardName.northshirecleric) i++;
                        if (mnn.name == CardName.lightwarden) i++;
                    }
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.name == CardName.northshirecleric) i--;
                        if (mnn.name == CardName.lightwarden) i--;
                    }
                    if (i >= 1) return pen;

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardName.slam && m.HealthPoints < 2) return pen;
                        if (hc.card.name == CardName.backstab) return pen;
                    }

                    pen = 500;
                }


            }

            return pen;
        }

        private int getCardDrawPenality(CardDB.Card card, Minion target, Playfield p)
        {
            // penality if carddraw is late or you have enough cards
            int pen = 0;
            CardName name = card.name;
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == CardName.wrath && card.cardIDenum != CardIdEnum.EX1_154b) return 0;
            if (name == CardName.nourish && card.cardIDenum != CardIdEnum.EX1_164b) return 0;
            if (name == CardName.tracking) return -1;            

            int carddraw = cardDrawBattleCryDatabase[name];
            if (carddraw == 0)
            {
                switch(name)
                {
                    case CardName.harrisonjones:
                        carddraw = p.enemyWeapon.Durability;
                        if (carddraw == 0 && (p.enemyHeroStartClass != TAG_CLASS.DRUID && p.enemyHeroStartClass != TAG_CLASS.MAGE && p.enemyHeroStartClass != TAG_CLASS.WARLOCK && p.enemyHeroStartClass != TAG_CLASS.PRIEST)) return 5;
                        break;

                    case CardName.divinefavor:
                        carddraw = p.enemyAnzCards - (p.owncards.Count);
                        if (carddraw <= 0) return 500;
                        break;

                    case CardName.battlerage:
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.wounded) carddraw++;
                        }
                        if (carddraw == 0)
                        {
                            if(p.ownMinions.Count == 0 && p.mana > 6)
                            {
                                foreach (Handmanager.Handcard hc in p.owncards)
                                {
                                    if (hc.card.type == CardDB.CardType.MOB) return 500;
                                }
                                if (p.owncards.Count < 2) return -10;
                                else if (p.owncards.Count < 4) return -2;
                                else if (p.owncards.Count < 6) return 0;
                                else if (p.owncards.Count < 9) return 3;
                            }
                            return 500;
                        }
                        break;

                    case CardName.slam:
                        if (target != null && target.HealthPoints >= 3) carddraw = 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardName.mortalcoil:
                        if (target != null && target.HealthPoints == 1) carddraw = 1;
                        if (carddraw == 0) return 15;
                        break;

                    case CardName.quickshot:
                        carddraw = (p.owncards.Count > 0) ? 0 : 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardName.thoughtsteal:
                        carddraw = Math.Min(2, p.enemyDeckSize);
                        if (carddraw == 2) break;
                        if (carddraw == 1) pen +=4;
                        else
                        {
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (spellDependentDatabase.ContainsKey(mnn.name)) return 0;
                            }
                            return 500;
                        }
                        break;
                    
                    case CardName.mindvision:
                        carddraw = Math.Min(1, p.enemyAnzCards);
                        if (carddraw != 1)
                        {
                            int scales = 0;
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (this.spellDependentDatabase.ContainsKey(mnn.name))
                                    if(mnn.name == CardName.lorewalkercho) pen += 20; //if(spellDependentDatabase[mnn.name] == 0);
                                    else scales--;
                            }
                            if (scales == 0) return 500;
                            foreach (Minion mnn in p.enemyMinions)
                            {
                                if (this.spellDependentDatabase.ContainsKey(mnn.name) && this.spellDependentDatabase[name] <= 0) scales++;
                            }
                            return (12 + scales * 4 + pen);
                        }
                        break;
                        
                    case CardName.echoofmedivh:
                        if (p.ownMinions.Count == 0) return 500;
                        return 0;
                        break;
                        
                    case CardName.tinkertowntechnician:
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if ((TAG_RACE)mnn.handcard.card.race != TAG_RACE.MECHANICAL) pen += 4;
                        }
                        break;

                    case CardName.markofyshaarj:
                        if ((TAG_RACE)target.handcard.card.race == TAG_RACE.PET) carddraw = 1;
                        break;

                    case CardName.servantofkalimos:
                        if (p.anzOwnElementalsLastTurn > 0) carddraw = 1;
                        break;                        

                    default:
                        break;
                }
            }
            
            if (name == CardName.farsight || name == CardName.callpet) pen -= 10;
            
            if (name == CardName.lifetap)
            {
                if (p.isLethalCheck) return 500; //RR no benefit for lethal check
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

                if (ai.botBase is BehaviorRush && p.ownMaxMana <= 3 && cardOnLimit) return 6; //RR penalization for drawing the 3 first turns if we have a card in hand that we won't be able to play in Rush

                if (p.owncards.Count + p.cardsPlayedThisTurn <= 5 && minmana > p.ownMaxMana) return 0;
                if (p.owncards.Count + p.cardsPlayedThisTurn > 5)
                {
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.name == CardName.doomsayer) return 2;
                    }
                    return 25;
                }

                int prevCardDraw = 0;
                if (p.optionsPlayedThisTurn > 0)
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.playedThisTurn && cardDrawBattleCryDatabase.ContainsKey(m.name)) prevCardDraw++;
                    }
                    CardDB.Card c;
                    foreach (GraveYardItem ge in Probabilitymaker.Instance.turngraveyardAll)
                    {
                        c = cdb.getCardDataFromID(ge.cardid);
                        if (cardDrawDeathrattleDatabase.ContainsKey(c.name)) prevCardDraw++;
                        else if (c.type == CardDB.CardType.SPELL && cardDrawBattleCryDatabase.ContainsKey(c.name)) prevCardDraw++;
                    }
                }
                return Math.Max(-carddraw + 2 * (p.optionsPlayedThisTurn - prevCardDraw) + p.ownMaxMana - p.mana, 0);
            }

            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10);
            if (p.ownMaxMana > 3 && p.owncards.Count + p.cardsPlayedThisTurn > 7) return (5 * carddraw) + 1;

            int tmp = 2 * p.optionsPlayedThisTurn + p.ownMaxMana - p.mana;
            int diff = 0;
            switch (card.name)
            {
                case CardName.solemnvigil:
                    tmp -= 2 * p.diedMinions.Count;
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name)) tmp -= 2;
                    }
                    break;
                case CardName.echoofmedivh:
                    diff = p.ownMinions.Count - prozis.ownMinions.Count;
                    if (diff > 0) tmp -= 2 * diff;
                    break;
                case CardName.bloodwarriors:
                    foreach (Minion m in p.ownMinions) if (m.wounded) diff++;
                    foreach (Minion m in prozis.ownMinions) if (m.wounded) diff--;
                    if (diff > 0) tmp -= 2 * diff;
                    break;
            }
            if (tmp < 0) tmp = 0;
            pen += -carddraw + tmp;
            if (p.ownMinions.Count < 3) pen += carddraw;
            if (p.playactions.Count > 0) pen += p.playactions.Count; // draw first!
            else if (p.owncards.Count < 4) pen -= (4 - p.owncards.Count) * 4;
            if (p.ownMinionsInDeckCost0) pen -= carddraw * 5;
            return pen;
        }

        private int getCardDrawofEffectMinions(CardDB.Card card, Playfield p)
        {
            int pen = 0;
            int carddraw = 0;
            if (card.type == CardDB.CardType.SPELL)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardName.gadgetzanauctioneer) carddraw++;
                }
            }

            if (card.type == CardDB.CardType.MOB && (TAG_RACE)card.race == TAG_RACE.PET)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardName.starvingbuzzard) carddraw++;
                }
            }

            if (carddraw == 0) return 0;
            if (p.owncards.Count >= 5) return 0;

            
            if (card.cost > 0) pen = -carddraw + p.ownMaxMana - p.mana + p.optionsPlayedThisTurn;

            return pen;
        }
        
        public int getCardDrawDeathrattlePenality(CardName name, Playfield p)
        {
            // penality if carddraw is late or you have enough cards
            if (!cardDrawDeathrattleDatabase.ContainsKey(name)) return 0;
            
            int carddraw = cardDrawDeathrattleDatabase[name];
            if (p.owncards.Count + carddraw > 10) return 15 * (p.owncards.Count + carddraw - 10);
            return 3 * p.optionsPlayedThisTurn;
        }

        private int getRandomPenaltiy(CardDB.Card card, Playfield p, Minion target)
        {
            if (p.turnCounter >= 1)
            {
                return 0;
            }

            if (!this.randomEffects.ContainsKey(card.name) && !(this.cardDrawBattleCryDatabase.ContainsKey(card.name) && card.type != CardDB.CardType.SPELL))
            {
                return 0;
            }

            if (card.name == CardName.brawl)
            {
                return 0;
            }

            if ((card.name == CardName.cleave || card.name == CardName.multishot) && p.enemyMinions.Count == 2)
            {
                return 0;
            }

            if ((card.name == CardName.deadlyshot) && p.enemyMinions.Count == 1)
            {
                return 0;
            }

            if ((card.name == CardName.arcanemissiles || card.name == CardName.avengingwrath)
                && p.enemyMinions.Count == 0)
            {
                return 0;
            }

            int cards = 0;
            cards = this.randomEffects.ContainsKey(card.name) ? this.randomEffects[card.name] : this.cardDrawBattleCryDatabase[card.name];

            bool first = true;
            bool hasgadget = false;
            bool hasstarving = false;
            bool hasknife = false;
            bool hasFlamewaker = false;
            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.name == CardName.gadgetzanauctioneer)
                {
                    hasgadget = true;
                }

                if (mnn.name == CardName.starvingbuzzard)
                {
                    hasstarving = true;
                }

                if (mnn.name == CardName.knifejuggler)
                {
                    hasknife = true;
                }

                if (mnn.name == CardName.flamewaker)
                {
                    hasFlamewaker = true;
                }
            }

            foreach (Action a in p.playactions)
            {
                if (a.actionType == actionEnum.attackWithHero)
                {
                    first = false;
                    continue;
                }

                if (a.actionType == actionEnum.useHeroPower
                    && (p.ownHeroAblility.card.name == CardName.totemiccall || p.ownHeroAblility.card.name == CardName.lifetap || p.ownHeroAblility.card.name == CardName.soultap))
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
                    if (card.name == CardName.knifejuggler && card.type == CardDB.CardType.MOB)
                    {
                        continue;
                    }

                    if (this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name))
                    {
                        continue;
                    }

                    if (this.lethalHelpers.ContainsKey(a.card.card.name))
                    {
                        continue;
                    }

                    if (hasgadget && card.type == CardDB.CardType.SPELL)
                    {
                        continue;
                    }

                    if (hasFlamewaker && card.type == CardDB.CardType.SPELL)
                    {
                        continue;
                    }

                    if (hasstarving && (TAG_RACE)card.race == TAG_RACE.PET)
                    {
                        continue;
                    }

                    if (hasknife && card.type == CardDB.CardType.MOB)
                    {
                        continue;
                    }

                    first = false;
                }
            }

            if (first == false)
            {
                return cards + p.playactions.Count + 1;
            }

            return 0;
        }


        private int getBuffHandPenalityPlay(CardName name, Playfield p)
        {
            if (!buffHandDatabase.ContainsKey(name)) return 0;

            Handmanager.Handcard hc;
            int anz = 0;
            switch (name)
            {
                case CardName.troggbeastrager: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -5;
                    break;
                case CardName.grimestreetsmuggler: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -5;
                    break;
                case CardName.donhancho: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -20;
                    break;
                case CardName.deathaxepunisher: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.LIFESTEAL);
                    if (hc != null) return -10;
                    break;
                case CardName.grimscalechum: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.MURLOC);
                    if (hc == null) return -5;
                    break;
                case CardName.grimestreetpawnbroker: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Weapon);
                    if (hc == null) return -5;
                    break;
                case CardName.grimestreetoutfitter: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == CardDB.CardType.MOB) anz++;
                    }
                    anz--; 
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
                case CardName.themistcaller: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == CardDB.CardType.MOB) anz++;
                    }
                    anz--; 
                    anz += p.ownDeckSize / 4;
                    return -1 * anz * 4;
                    break;
                case CardName.hobartgrapplehammer: 
                    foreach (Handmanager.Handcard hc2 in p.owncards)
                    {
                        if (hc2.card.type == CardDB.CardType.WEAPON) anz++;
                    }
                    if (anz == 0) return 2;
                    else return -1 * anz * 2;
                    break;
                case CardName.smugglerscrate: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -10;
                    else return 10;
                    break;
                case CardName.stolengoods: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.TAUNT);
                    if (hc != null) return -15;
                    else return 10;
                    break;
                case CardName.smugglersrun: 
                    foreach (Handmanager.Handcard hc3 in p.owncards)
                    {
                        if (hc3.card.type == CardDB.CardType.MOB) anz++;
                    }
                    anz--; 
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
            }
            return 0;
        }

        private int getCardDiscardPenality(CardName name, Playfield p)
        {
            if (p.owncards.Count <= 1) return 0;
            if (p.ownMaxMana <= 3) return 0;
            int pen = 0;
            if (this.cardDiscardDatabase.ContainsKey(name))
            {
                int newmana = p.mana - cardDiscardDatabase[name];
                bool canplaythisturn = false;
                bool haveChargeInHand = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (this.cardDiscardDatabase.ContainsKey(hc.card.name)) continue;
                    switch (hc.card.name)
                    {
                        case CardName.silverwaregolem: pen -= 12; continue;
                        case CardName.fistofjaraxxus: pen -= 6; continue;
                    }
                    if (hc.card.getManaCost(p, hc.manacost) <= newmana)
                    {
                        canplaythisturn = true;
                    }
                    if (hc.card.Charge && hc.card.getManaCost(p, hc.manacost) < p.ownMaxMana + 1) haveChargeInHand = true;
                }
                if (canplaythisturn) pen += 18;
                if (haveChargeInHand) pen += 10;
            }

            return pen;
        }

        private int getDestroyOwnPenality(CardName name, Minion target, Playfield p)
        {
            if (!this.destroyOwnDatabase.ContainsKey(name)) return 0;
            
            switch (name)
            {
                case CardName.sanguinereveler: goto case CardName.shadowflame;
                case CardName.ravenouspterrordax: goto case CardName.shadowflame;
                case CardName.shadowflame:
                    if (target == null || !target.Ready) return 0;
                    else return 1;
                case CardName.deathwing:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    break;
                case CardName.twistingnether: goto case CardName.brawl;
                case CardName.doompact: goto case CardName.brawl;
                case CardName.brawl:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    
                    if (name == CardName.brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
                    int highminion = 0;
                    int veryhighminion = 0;
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.Attack >= 5 || m.HealthPoints >= 5) highminion++;
                        if (m.Attack >= 8 || m.HealthPoints >= 8) veryhighminion++;
                    }

                    if (highminion >= 2 || veryhighminion >= 1)
                    {
                        return 0;
                    }

                    if (p.enemyMinions.Count <= 2 || p.enemyMinions.Count + 2 <= p.ownMinions.Count || p.ownMinions.Count >= 3)
                    {
                        return 30;
                    }
                    break;
            }

            if (target == null) return 0;
            if (target.own && !target.isHero)
            {
                // dont destroy owns (except mins with deathrattle effects or + effects)
                if (p.isLethalCheck)
                {
                    if (target.Ready) return 500;
                    switch (target.handcard.card.name)
                    {
                        case CardName.lepergnome: return -2;
                        case CardName.backstreetleper: return -2;
                        case CardName.firesworn: return -2;
                        case CardName.zombiechow:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -5;
                            else return 500;
                        case CardName.corruptedhealbot:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -8;
                            else return 500;
                        default:
                            int up = 0;
                            foreach (Minion m in p.ownMinions)
                            {
                                switch (m.handcard.card.name)
                                {
                                    case CardName.manawyrm: goto case CardName.lightwarden;
                                    case CardName.flamewaker: goto case CardName.lightwarden;
                                    case CardName.archmageantonidas: goto case CardName.lightwarden;
                                    case CardName.gadgetzanauctioneer: goto case CardName.lightwarden;
                                    case CardName.manaaddict: goto case CardName.lightwarden;
                                    case CardName.redmanawyrm: goto case CardName.lightwarden;
                                    case CardName.summoningstone: goto case CardName.lightwarden;
                                    case CardName.wickedwitchdoctor: goto case CardName.lightwarden;
                                    case CardName.holychampion: goto case CardName.lightwarden;
                                    case CardName.lightwarden:
                                        if (m.Ready)
                                        {
                                            up++;
                                            if (target.entitiyID == m.entitiyID) up--;
                                        }
                                        continue;
                                }
                            }
                            if (up > 0) return 0;
                            if (target.handcard.card.deathrattle) return 10;
                            else return 500;
                    }
                }
                else
                {
                    switch (name)
                    {
                        case CardName.unwillingsacrifice:
                            if (p.enemyMinions.Count > 0)
                            {
                                if (target.handcard.card.deathrattle) return 1;
                                else return 3;
                            }
                            break;
                    }

                    
                }
                return 500;
            }

            return 0;
        }

        private int getDestroyPenality(CardName name, Minion target, Playfield p)
        {
            if (!this.destroyDatabase.ContainsKey(name) || p.isLethalCheck) return 0;
            int pen = 0;
            if (target == null) return 0;
            if (target.own && !target.isHero)
            {
                Minion m = target;
                if (!m.handcard.card.deathrattle)
                {
                    pen = 500;
                }
            }
            if (!target.own && !target.isHero)
            {
                // dont destroy owns ;_; (except mins with deathrattle effects)

                Minion m = target;

                if (m.allreadyAttacked && name != CardName.execute)
                {
                    return 50;
                }

                if (name == CardName.shadowwordpain)
                {
                    if (this.specialMinions.ContainsKey(m.name) || m.Attack == 3 || m.HealthPoints >= 4)
                    {
                        return 0;
                    }

                    if (m.Attack == 2) return 5;

                    return 10;
                }

                if (m.Attack >= 4 || m.HealthPoints >= 5)
                {
                    pen = 0; // so we dont destroy cheap ones :D
                }
                else
                {
                    pen = 30;
                }

                if (name == CardName.mindcontrol && (m.name == CardName.direwolfalpha || m.name == CardName.raidleader || m.name == CardName.flametonguetotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

                if (m.name == CardName.doomsayer)
                {
                    pen = 5;
                }

            }

            return pen;
        }

        private int getSpecialCardComboPenalitys(CardDB.Card card, Minion target, Playfield p)
        {
            bool lethal = p.isLethalCheck;
            CardName name = card.name;

            if (lethal && card.type == CardDB.CardType.MOB)
            {
                if (this.lethalHelpers.ContainsKey(name))
                {
                    return 0;
                }

                if (this.buffingMinionsDatabase.ContainsKey(name))
                {
                    switch (this.buffingMinionsDatabase[name])
                    {
                        case 0:
                            if (p.ownMinions.Count > 0) return 0;
                                break;
                        case 1:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET && mm.Ready) return 0;
                            }
                            break;
                        case 2:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MECHANICAL && mm.Ready) return 0;
                            }
                            break;
                        case 3:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && mm.Ready) return 0;
                            }
                            break;
                        case 4:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE && mm.Ready) return 0;
                            }
                            break;
                        case 5:
                            if (p.ownHero.Ready && p.ownHero.Attack >= 1) return 0;
                            break;
                        case 6:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.name == CardName.silverhandrecruit && mm.Ready) return 0;
                            }
                            break;
                        case 7:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.charge > 0) return 0;
                            }
                            break;
                        case 8:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.DEMON && mm.Ready) return 0;
                            }
                            break;
                        case 9:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.TOTEM && mm.Ready) return 0;
                            }
                            break;
                        case 10:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.name == CardName.cthun && mm.Ready) return 0;
                            }
                            break;
                    }
                    return 500;
                }
                else
                {
                    if ((name == CardName.rendblackhand && target != null) && !target.own)
                    {
                        if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == CardName.malganis)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) return 0;
                            }
                        }
                        return 500;
                    }

                    if (name == CardName.theblackknight)
                    {
                        foreach (Minion mm in p.enemyMinions)
                        {
                            if (mm.taunt) return 0;
                        }
                        return 500;
                    }
                    else
                    {
                        if ((this.HealTargetDatabase.ContainsKey(name) || this.HealHeroDatabase.ContainsKey(name) || this.HealAllDatabase.ContainsKey(name)))
                        {
                            int beasts = 0;
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.Ready && (mm.handcard.card.name == CardName.lightwarden || mm.handcard.card.name == CardName.holychampion)) beasts++;
                            }
                            if (beasts == 0) return 500;
                        }
                        else
                        {
                            if (!(name == CardName.nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || this.DamageTargetDatabase.ContainsKey(name) || ((TAG_RACE)card.race == TAG_RACE.PET && p.ownMinions.Find(x => x.name == CardName.tundrarhino) != null) || p.owncards.Find(x => x.card.name == CardName.charge) != null))
                            {
                                return 500;
                            }
                        }
                        return 0;
                    }
                }
            }

            //lethal end########################################################
                        
            int pen = 0;
            if (dragonDependentDatabase.ContainsKey(name))
            {
                pen += 10;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.race == 24)
                    {
                        pen -= 10;
                        break;
                    }
                }
            }
            
            if (elementalLTDependentDatabase.ContainsKey(name) && p.anzOwnElementalsLastTurn == 0) pen += 10;

            int targets = 0;
            switch(name)
            {
                case CardName.hobartgrapplehammer: return -5; 
                case CardName.bloodsailraider: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardName.captaingreenskin: if (p.ownWeapon.Durability == 0) return 10; return 0; 
                case CardName.luckydobuccaneer: if (!(p.ownWeapon.Durability > 0 && p.ownWeapon.Angr > 2)) return 10; return 0; 
                case CardName.nagacorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardName.goblinautobarber: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardName.dreadcorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardName.grimestreetpawnbroker: 
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.CardType.WEAPON) return 0;
                    return 5;
                case CardName.bloodsailcultist: ; 
                    if (p.ownWeapon.Durability > 0) foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) return 0;
                    return 8;
                case CardName.ravasaurrunt: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardName.nestingroc: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardName.gentlemegasaur: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardName.primalfinlookout: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardName.spiritecho: 
                    if (p.ownQuest.Id == CardIdEnum.UNG_942)
                    {
                        targets = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) targets++;
                        }
                        if (targets > 1) return -7;
                        return 10;
                    }
                    else if (p.ownMinions.Count < 2) return 7;
                    return 0;
                case CardName.evolvingspores: 
                    if (p.ownMinions.Count < 3) return 15 - p.ownMinions.Count * 5;
                    return 0;
                case CardName.livingmana: 
                    int free = 7 - p.ownMinions.Count;
                    switch (free)
                    {
                        case 7: return -22 * free;
                        case 6: return -21 * free;
                        case 5: return -20 * free;
                        case 4: if (p.ownMinions.Count < p.enemyMinions.Count) return -20 * free; else return -19 * free;
                        case 3: if (p.ownMinions.Count + 2 < p.enemyMinions.Count) return -20 * free; else return 0;
                        case 2: return 0;
                        case 1: return 5;
                        default:
                            return 500;
                    }
                    break;
                case CardName.elisethetrailblazer: return -7; 
                case CardName.cracklingrazormaw:   
                    if (target != null) return 0;
                    return 5;
                case CardName.dinomancy: return -7; 
                case CardName.moltenblade: return -10; 
                case CardName.gluttonousooze: goto case CardName.acidicswampooze;
                case CardName.acidicswampooze:
                    if (p.enemyWeapon.Angr > 0) return 0;
                    if (p.enemyHeroName == HeroEnum.shaman || p.enemyHeroName == HeroEnum.warrior || p.enemyHeroName == HeroEnum.thief || p.enemyHeroName == HeroEnum.pala) return 10;
                    if (p.enemyHeroName == HeroEnum.hunter) return 6;
                    return 0;
                case CardName.darkshirecouncilman:
                    if (p.enemyMinions.Count == 0)
                    {
                        List<Handmanager.Handcard> temp = new List<Handmanager.Handcard>(p.owncards);
                        temp.Sort((a, b) => a.card.cost.CompareTo(b.card.cost)); 
                        int cnum = 0;
                        int pcards = 0;
                        int nextTurnMana = p.ownMaxMana + 1;
                        foreach (Handmanager.Handcard hc in temp)
                        {
                            if (hc.card.name == name && cnum == 0)
                            {
                                cnum++;
                                continue;
                            }
                            nextTurnMana -= hc.card.cost;
                            if (nextTurnMana < 0) break;
                            else pcards++;
                        }
                        return -3 * pcards;
                    }
                    break;
                case CardName.deadmanshand: 
                    if (p.owncards.Count > 2) return -5 * p.owncards.Count;
                    break;
                case CardName.bringiton: 
                    return 3 * p.enemyAnzCards * (11 - p.enemyMaxMana);
                case CardName.strongshellscavenger:
                    int tmp = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp++;
                    return 12 - tmp * 2;

            }

            if (name == CardName.unstableportal && p.owncards.Count <= 9) return -15;
            if (name == CardName.lunarvisions && p.owncards.Count <= 8) return -5;

            if (name == CardName.azuredrake)
            {
                pen = 0;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.Attack > 3 && p.anzOwnTaunt == 0)
                    {
                        pen = 5;
                        break;
                    }
                }
                if (p.ownHeroStartClass == TAG_CLASS.DRUID)
                {
                    if (p.owncards.Count > 3)
                    {
                        p.owncarddraw--;
                        pen += 5;
                    }
                    bool menageriewarden = false;
                    bool pet = false;
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardName.menageriewarden) { menageriewarden = true; continue; }
                        if ((TAG_RACE)hc.card.race == TAG_RACE.PET && hc.card.cost <= p.ownMaxMana) pet = true;
                    }
                    if (menageriewarden && pet) pen += 23;
                }
                return pen;
            }

            if (name == CardName.manatidetotem)
            {
                if (p.owncards.Count > 2)
                {
                    int eAngr = p.enemyWeapon.Angr;
                    foreach (Minion em in p.enemyMinions)
                    {
                        if (!em.frozen) eAngr += em.Attack;
                    }
                    if (p.anzOwnTaunt > 0)
                    {
                        foreach (Minion om in p.ownMinions)
                        {
                            if (om.taunt) eAngr -= om.HealthPoints;
                        }
                    }
                    if (eAngr >= 3) return 5;
                }
                return 0;
            }

            if (name == CardName.menageriewarden)
            {
                if (target != null && (TAG_RACE)target.handcard.card.race == TAG_RACE.PET) return 0;
                else return 10;
            }

            if (name == CardName.duplicate)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardName.mirrorentity)
                    {
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.handcard.card.Attack >= 3 && this.UsefulNeedKeepDatabase.ContainsKey(mnn.name)) return 0;
                        }
                        return 16;
                    }
                }
            }

            if ((name == CardName.lifetap || name == CardName.soultap) && p.owncards.Count <= 9)
            {
                 foreach (Minion mnn in p.ownMinions)
                 {
                     if (mnn.name == CardName.wilfredfizzlebang && !mnn.silenced) return -20;
                 }
            }

            if (name == CardName.forbiddenritual)
            {
                if (p.ownMinions.Count == 7 || p.mana == 0) return 500;
                return 7;
            }
            
            if (name == CardName.competitivespirit)
            {
                if (p.ownMinions.Count < 1) return 500;
                if (p.ownMinions.Count > 2) return 0;
                return (15 - 5 * p.ownMinions.Count);
            }

            if (name == CardName.shifterzerus) return 500;

            if (card.name == CardName.daggermastery)
            {
                if (p.ownWeapon.Angr >= 2 || p.ownWeapon.Durability >= 2) return 5;
            }

            if (card.name == CardName.upgrade)
            {
                if (p.ownWeapon.Durability == 0)
                {
                    if (weaponInHandAttackNextTurn(p) > 0) return 10;
                    return 0;
                }
            }

            if (card.name == CardName.malchezaarsimp && p.owncards.Count > 2) return 5;

            if (card.name == CardName.baronrivendare)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardName.deathlord || mnn.name == CardName.zombiechow || mnn.name == CardName.dancingswords) return 30;
                }
            }

            //rule for coin on early game
            if (p.ownMaxMana < 3 && card.name == CardName.thecoin)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.manacost <= p.ownMaxMana && hc.card.type == CardDB.CardType.MOB) return 5;
                }

            }
            
            //destroySecretPenality
            pen = 0;
            switch (card.name)
            {
                case CardName.flare: 
                    foreach (Minion mn in p.ownMinions) if (mn.stealth) pen++;
                    foreach (Minion mn in p.enemyMinions) if (mn.stealth) pen--;
                    if (p.enemySecretCount > 0)
                    {
                        bool canPlayMinion = false;
                        bool canPlaySpell = false;
                        foreach(Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardName.flare) continue;
                            if (hc.card.cost <= p.mana - 2) 
                            {
                                if (!canPlayMinion && hc.card.type == CardDB.CardType.MOB)
                                {
                                    
                                    int tmp = p.getSecretTriggersByType(0, true, false, target);
                                    if (tmp > 0) pen -= tmp * 50;
                                    canPlayMinion = true;
                                    continue;
                                }
                                if (!canPlaySpell && hc.card.type == CardDB.CardType.SPELL)
                                {
                                    int tmp = p.getSecretTriggersByType(1, true, false, target);
                                    if (tmp > 0) pen -= tmp * 50;
                                    canPlaySpell = true;
                                    continue;
                                }
                            }
                        }
                        pen -= p.enemySecretCount * 5;
                        if (p.playactions.Count == 0) pen -= 5;
                    }
                    else
                    {
                        switch (p.enemyHeroStartClass)
                        {
                            case TAG_CLASS.MAGE: pen += 5; break;
                            case TAG_CLASS.PALADIN: pen += 5; break;
                            case TAG_CLASS.HUNTER: pen += 5; break;
                        }
                    }
                    break;
                case CardName.eaterofsecrets: 
                    if (p.enemySecretCount > 0)
                    {
                        pen -= p.enemySecretCount * 50;
                        if (p.playactions.Count == 0) pen -= 5;
                    }
                    else
                    {
                        switch (p.enemyHeroStartClass)
                        {
                            case TAG_CLASS.MAGE: pen += 5; break;
                            case TAG_CLASS.PALADIN: pen += 5; break;
                            case TAG_CLASS.HUNTER: pen += 5; break;
                        }
                    }
                    break;
                case CardName.kezanmystic: 
                    if (p.enemySecretCount == 1 && p.playactions.Count == 0) pen -= 50;
                    break;

                case CardName.totemiccall:
                    if (lethal) return 20;
                    break;

                case CardName.frostwolfwarlord:
                    if (p.ownMinions.Count == 0) pen += 5;
                    break;

                case CardName.flametonguetotem:
                    if (p.ownMinions.Count == 0) return 100;
                    break;
                
                case CardName.stampedingkodo:
                    bool found = false;
                    foreach (Minion mi in p.enemyMinions)
                    {
                        if (mi.Attack <= 2) found = true;
                    }
                    if (!found) return 20;
                    break;

                case CardName.windfury:
                    if (!target.own) return 500;
                    else if (!target.Ready) return 500;
                    break;

                case CardName.desperatestand: goto case CardName.ancestralspirit;
                case CardName.ancestralspirit:
                    if (!target.isHero)
                    {
                        if (!target.own)
                        {
                            if (target.name == CardName.deathlord || target.name == CardName.zombiechow || target.name == CardName.dancingswords) return 0;
                            return 500;
                        }
                        else
                        {
                            if (this.specialMinions.ContainsKey(target.name)) return -5;
                            return 0;
                        }
                    }
                    break;

                case CardName.houndmaster:
                    if (target == null) return 50;
                    break;

                case CardName.beneaththegrounds: return -10;

                case CardName.curseofrafaam: return -7;

                case CardName.flameimp:
                    if (p.ownHero.HealthPoints + p.ownHero.armor > 20) pen -= 3;
                    break;
             

                case CardName.quartermaster:
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.name == CardName.silverhandrecruit) return 0;
                    }
                    return 5;

                case CardName.mysteriouschallenger: return -14;

                case CardName.biggamehunter:
                    if (target == null || target.own) return 40;
                    break;
                    
                case CardName.emergencycoolant:
                    if (target != null && target.own) pen = 500;
                    break;

                case CardName.shatteredsuncleric:
                    if (target == null) return 10;
                    break;

                case CardName.argentprotector:
                    if (target == null) pen = 20;
                    else
                    {
                        if (!target.own) return 500;
                        if (!target.Ready && !target.handcard.card.isSpecialMinion)
                        {
                            if (target.Attack <= 2 && target.HealthPoints <= 2) pen = 15;
                            else pen = 10;
                        }
                    }
                    break;

                case CardName.facelessmanipulator:
                    if (target == null) return 50;
                    if (target.Attack >= 5 || target.handcard.card.cost >= 5 || (target.handcard.card.rarity == 5 || target.handcard.card.cost >= 3))
                    {
                        return 0;
                    }
                    return 49;

                case CardName.rendblackhand:
                    if (target == null) return 15;
                    if (target.own) return 100;
                    if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == CardName.malganis)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) return 0;
                        }
                    }
                    return 500;

                case CardName.theblackknight:
                    if (target == null) return 50;
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.taunt && (target.Attack >= 3 || target.HealthPoints >= 3)) return 0;
                    }
                    return 20;

                case CardName.madderbomber: goto case CardName.madbomber;
                case CardName.madbomber:
                    pen = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.Ready & mnn.HealthPoints < 3) pen += 5;
                    }
                    return pen;

                case CardName.sylvanaswindrunner:
                    if (p.enemyMinions.Count == 0) return 10;
                    break;

                case CardName.betrayal:
                    if (!target.own && !target.isHero)
                    {
                        if (target.Attack == 0) return 30;
                        if (p.enemyMinions.Count == 1) return 30;
                    }
                    break;

                case CardName.nerubianegg:
                    if (p.owncards.Find(x => this.attackBuffDatabase.ContainsKey(x.card.name)) != null || p.owncards.Find(x => this.tauntBuffDatabase.ContainsKey(x.card.name)) != null)
                    {
                        return -6;
                    }
                    break;

                case CardName.bite:
                    if ((p.ownHero.numAttacksThisTurn == 0 || (p.ownHero.windfury && p.ownHero.numAttacksThisTurn == 1)) && !p.ownHero.frozen)
                    {

                    }
                    else return 20;
                    break;

                case CardName.deadlypoison:
                    return -(p.ownWeapon.Durability - 1) * 2;

                case CardName.coldblood:
                    if (lethal) return 0;
                    return 25;

                case CardName.bloodmagethalnos: return 10;

                case CardName.frostbolt:
                    if (!target.own && !target.isHero)
                    {
                        if (target.handcard.card.cost < 3 && !this.priorityDatabase.ContainsKey(target.handcard.card.name)) return 15;
                    }
                    return 0;

                case CardName.poweroverwhelming:
                    if (target.own && !target.isHero && !target.Ready) return 500;
                    break;

                case CardName.frothingberserker:
                    if (p.cardsPlayedThisTurn >= 1) pen = 5;
                    break;

                case CardName.handofprotection:
                    if (!target.own)
                    {
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (!mm.divineshild) return 500;
                        }
                    }
                    if (target.HealthPoints == 1) pen = 15;
                    break;

                case CardName.wildgrowth: goto case CardName.nourish;
                case CardName.nourish:
                    if (p.ownMaxMana == 9 && !(p.ownHeroName == HeroEnum.thief && p.cardsPlayedThisTurn == 0)) return 500;
                    break;

                case CardName.resurrect:
                    if (p.ownMaxMana < 6) return 50;
                    if (p.ownMinions.Count == 7) return 500;
                    if (p.ownMaxMana > 8) return 0;
                    if (p.OwnLastDiedMinion == CardIdEnum.None) return 6;
                    return 0;

                case CardName.lavashock:
                    if (p.ueberladung + p.lockedMana < 1) return 15;
                    return (3 - 3 * (p.ueberladung + p.lockedMana));

                case CardName.edwinvancleef:
                    if (p.cardsPlayedThisTurn < 1) return 30;
                    else if (p.cardsPlayedThisTurn < 2) return 10;
                    else return 0;

                case CardName.enhanceomechano:
                    if (p.ownMinions.Count == 0 && p.ownMaxMana < 5) return 500;
                    pen = 2 * (p.mana - 4 - p.mobsplayedThisTurn);
                    if (p.mobsplayedThisTurn < 1) pen += 30;
                    return pen;

                case CardName.knifejuggler:
                    if (p.mobsplayedThisTurn >= 1) return 20;
                    break;

                case CardName.flamewaker:
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && a.card.card.type == CardDB.CardType.SPELL) return 30;
                    }
                    break;

                case CardName.polymorph: goto case CardName.hex;
                case CardName.hex:
                    if (!target.isHero)
                    {
                        if (target.own)
                        {
                            if (target.name == CardName.masterchest) return -5;
                            else return 500;
                        }
                        else
                        {
                            if (target.allreadyAttacked) return 30;
                            Minion frog = target;
                            if (this.priorityTargets.ContainsKey(frog.name)) return 0;
                            if (frog.Attack >= 4 && frog.HealthPoints >= 4) return 0;
                            if (frog.Attack >= 2 && frog.HealthPoints >= 6) return 5;
                            return 30;
                        }
                    }
                    break;

                case CardName.ravagingghoul:
                    if (p.enemyMinions.Count == 0) return 7;
                    break;

                case CardName.bookwyrm:
                    if (target == null) return 20;
                    else
                    {
                        if (this.priorityTargets.ContainsKey(target.name) || this.priorityDatabase.ContainsKey(target.name))
                        {
                            if (target.HealthPoints > 3) return -6;
                            return -3;
                        }
                        else if (target.maxHp > 3) return 0;
                        else return 5;
                    }
                    break;

                case CardName.grimestreetprotector:
                    if (p.ownMinions.Count == 1) return 10;
                    else if (p.ownMinions.Count == 0) return 20;
                    break;

                case CardName.sunfuryprotector:
                    if (p.ownMinions.Count == 1) return 15;
                    else if (p.ownMinions.Count == 0) return 30;
                    break;

                case CardName.defenderofargus:
                    if (p.ownMinions.Count == 1) return 30;
                    else if (p.ownMinions.Count == 0) return 50;
                    break;

                case CardName.unearthedraptor:
                    if (target == null) return 10;
                    break;

                case CardName.unleashthehounds:
                    if (p.enemyMinions.Count <= 1) return 20;
                    break;

                case CardName.equality:
                    if (p.enemyMinions.Count <= 2 || (p.ownMinions.Count - p.enemyMinions.Count >= 1)) return 20;
                    break;

                case CardName.bloodsailraider:
                    if (p.ownWeapon.Durability == 0)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.type == CardDB.CardType.WEAPON) return 10;
                        }
                    }
                    break;

                case CardName.innerfire:
                    if (target.name == CardName.lightspawn) return 500;
                    if (!target.Ready) return 20;
                    break;

                case CardName.huntersmark:
                    if (!target.isHero)
                    {
                        if (target.own) return 500;
                        else if (target.HealthPoints <= 4 && target.Attack <= 4 && !(target.poisonous && !target.silenced))
                        {
                            pen = 20;
                        }
                    }
                    break;

                case CardName.crazedalchemist:
                    if (target != null) pen -= 1;
                    break;

                case CardName.deathwing:
                    int prevDmg = 0;
                    foreach (Minion m1 in p.enemyMinions)
                    {
                        prevDmg += m1.Attack;
                    }
                    if (p.ownHero.HealthPoints + p.ownHero.armor > prevDmg * 2) pen += p.ownMinions.Count * 10 + p.owncards.Count * 25;
                    break;

                case CardName.deathwingdragonlord:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) pen -= 3;
                    }
                    pen += 3;
                    break;

                case CardName.humility: goto case CardName.aldorpeacekeeper;
                case CardName.aldorpeacekeeper:
                    if (target != null)
                    {
                        if (target.own) pen = 500;
                        else if (target.Attack <= 3) pen = 30;
                        if (target.name == CardName.lightspawn) pen = 500;
                    }
                    else pen = 40;
                    break;
            
                case CardName.direwolfalpha: goto case CardName.abusivesergeant;
                case CardName.abusivesergeant:
                    int ready = 0;
                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.Ready) ready++;
                    }
                    if (ready == 0) pen = 5;
                    break;
                    
                case CardName.gangup:
                    if (this.GangUpDatabase.ContainsKey(target.handcard.card.name))
                    {
                        return (-5 - 1 * GangUpDatabase[target.handcard.card.name]);
                    }
                    else return 40;
                    
                case CardName.defiasringleader:
                    if (p.cardsPlayedThisTurn == 0) pen = 10;
                    break;

                case CardName.bloodknight:
                    int shilds = 0;
                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.divineshild) shilds++;
                    }
                    foreach (Minion min in p.enemyMinions)
                    {
                        if (min.divineshild) shilds++;
                    }
                    if (shilds == 0) pen = 10;
                    break;

                case CardName.reincarnate:
                    if (target.own)
                    {
                        if (target.handcard.card.deathrattle || target.ancestralspirit >= 1 || target.desperatestand >= 1 || target.souloftheforest >= 1 || target.stegodon >= 1 || target.livingspores >= 1 || target.infest >= 1 || target.explorershat >= 1 || target.returnToHand >= 1 || target.deathrattle2 != null || target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.handcard.card.Charge && ((target.numAttacksThisTurn == 1 && !target.windfury) || (target.numAttacksThisTurn == 2 && target.windfury))) return 0;
                        if (target.wounded || target.Attack < target.handcard.card.Attack || (target.silenced && this.specialMinions.ContainsKey(target.name))) return 0;
                        
                        bool hasOnMinionDiesMinion = false;
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.name == CardName.scavenginghyena && target.handcard.card.race == 20) hasOnMinionDiesMinion = true;
                            if (mnn.name == CardName.flesheatingghoul || mnn.name == CardName.cultmaster) hasOnMinionDiesMinion = true;
                        }
                        if (hasOnMinionDiesMinion) return 0;
                        return 500;
                    }
                    else
                    {
                        if (target.name == CardName.nerubianegg && target.Attack <= 4 && !target.taunt) return 500;
                        if (target.taunt && !target.handcard.card.tank) return 0;
                        if (target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.Attack > target.handcard.card.Attack || target.HealthPoints > target.handcard.card.Health) return 0;
                        if (target.name == CardName.abomination || target.name == CardName.zombiechow || target.name == CardName.unstableghoul || target.name == CardName.dancingswords) return 0;
                        return 500;
                    }
                    break;

                case CardName.divinespirit:
                    if (!target.isHero)
                    {
                        if (target.own)
                        {
                            if (target.HealthPoints >= 4) return 0;
                            return 15;
                        }
                        else if (lethal)
                        {
                            if (!target.taunt) return 500;
                            else
                            {
                                // combo for killing with innerfire and biggamehunter
                                if (p.owncards.Find(x => x.card.name == CardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardName.innerfire) != null && (target.HealthPoints >= 4 || (p.owncards.Find(x => x.card.name == CardName.divinespirit) != null && target.HealthPoints >= 2)))
                                {
                                    return 0;
                                }
                                return 500;
                            }
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.name == CardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardName.innerfire) != null && target.HealthPoints >= 4)
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                    break;
            }


            //------------------------------------------------------------------------------------------------------


            if ((p.ownHeroAblility.card.name == CardName.totemiccall || p.ownHeroAblility.card.name == CardName.totemicslam) && p.ownAbilityReady == false)
            {
                foreach (Action a in p.playactions)
                {
                    if (a.actionType == actionEnum.playcard && a.card.card.name == CardName.draeneitotemcarver) return -1;
                }
                if (p.owncards.Count > 1)
                {
                    if (card.type == CardDB.CardType.SPELL)
                    {
                        if (!(DamageTargetDatabase.ContainsKey(card.name) || DamageAllEnemysDatabase.ContainsKey(card.name) 
                            || DamageAllDatabase.ContainsKey(card.name) || DamageRandomDatabase.ContainsKey(card.name) 
                            || DamageTargetSpecialDatabase.ContainsKey(card.name) || DamageHeroDatabase.ContainsKey(card.name))) pen += 10;
                    }
                    else if (card.name == CardName.frostwolfwarlord || card.name == CardName.thingfrombelow || card.name == CardName.draeneitotemcarver) return -1;
                    else pen += 10;
                }
            }

            if (target != null && (name == CardName.sap || name == CardName.dream || name == CardName.kidnapper))
            {
                if (!target.own && (target.name == CardName.theblackknight || name == CardName.rendblackhand))
                {
                    return 50;
                }
            }

            if (!lethal && card.cardIDenum == CardIdEnum.EX1_165t1) //druidoftheclaw	Charge
            {
                return 20;
            }


            if (lethal)
            {
                if (name == CardName.corruption)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && (mm.handcard.card.name == CardName.questingadventurer || mm.handcard.card.name == CardName.archmageantonidas || mm.handcard.card.name == CardName.manaaddict || mm.handcard.card.name == CardName.manawyrm || mm.handcard.card.name == CardName.wildpyromancer)) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
            }


            if (returnHandDatabase.ContainsKey(name))
            {
                if (target != null && target.own && !target.isHero && target.Ready) pen += 10;

                switch (target.name)
                {
                    case CardName.masterchest: return target.own ? -21 : 5;
                }

                if (card.type == CardDB.CardType.SPELL)
                {
                    if (name == CardName.vanish)
                    {
                        //dont vanish if we have minons on board wich are ready
                        bool haveready = false;
                        foreach (Minion mins in p.ownMinions)
                        {
                            if (mins.Ready) haveready = true;
                        }
                        if (haveready) pen += 10;
                    }
                    else
                    {
                        if (target.wounded) return 0;
                        if (target.silenced)
                        {
                            if (this.UsefulNeedKeepDatabase.ContainsKey(target.name)) return -1;
                        }
                        if (target.charge > 0 && !target.Ready) return 0;

                        if (p.enemySecretCount > 0 && p.enemyHeroStartClass == TAG_CLASS.MAGE) return 0;

                        bool BeastReq = false;
                        bool MechReq = false;
                        bool PirateReq = false;
                        bool DragonReq = false;
                        if (target.handcard.card.battlecry)
                        {
                            if (this.dragonDependentDatabase.ContainsKey(target.name)) DragonReq = true;
                            switch (target.name)
                            {
                                //case CardName.masterofceremonies:
                                case CardName.ramwrangler: BeastReq = true; break;
                                case CardName.druidofthefang: BeastReq = true; break;
                                case CardName.goblinblastmage: MechReq = true; break;
                                case CardName.tinkertowntechnician: MechReq = true; break;
                                case CardName.shadydealer: if (!target.Ready && target.maxHp == 3) PirateReq = true; break;
                                case CardName.gormoktheimpaler: if (p.ownMinions.Count > 4) return 0; break;
                                case CardName.corerager: if (p.owncards.Count < 1) return 0; break;
                                case CardName.drakonidcrusher: if (p.enemyHero.HealthPoints < 16) return 0; break;
                                case CardName.mindcontroltech: if (p.enemyMinions.Count > 3) return 0; break;
                                case CardName.alexstraszaschampion: if (target.Ready) DragonReq = false; break;
                                case CardName.twilightguardian: if (target.taunt) DragonReq = false; break;
                                case CardName.wyrmrestagent: if (target.taunt) DragonReq = false; break;
                                case CardName.blackwingtechnician: if (target.maxHp > 4) DragonReq = false; break;
                                case CardName.twilightwhelp: if (target.maxHp > 1) DragonReq = false; break;
                                case CardName.kingselekk: return 0; break;
                                case CardName.gadgetzanjouster: if (target.maxHp == 2) return 0; break;
                                case CardName.armoredwarhorse: if (!target.Ready) return 0; break;
                                case CardName.masterjouster: if (!target.taunt) return 0; break;
                                case CardName.tuskarrjouster: if (!target.Ready && p.ownHero.HealthPoints < 26) return 0; break;
                            }
                        }

                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (this.spellDependentDatabase.ContainsKey(mnn.name) && mnn.entitiyID != target.entitiyID) return 0;
                            if (mnn.name == CardName.starvingbuzzard && mnn.entitiyID != target.entitiyID && target.handcard.card.race == 20) return 0;

                            if (BeastReq && mnn.handcard.card.race == 20) return 0;
                            if (MechReq && mnn.handcard.card.race == 17) return 0;
                            if (PirateReq && mnn.handcard.card.race == 23) return 0;
                        }

                        if (DragonReq)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if (hc.card.race == 24) return 0;
                            }
                        }
                        return 500;
                    }
                }
            }

            return pen;
        }

        private int playSecretPenality(CardDB.Card card, Playfield p)
        {
            //penality if we play secret and have playable kirintormage
            int pen = 0;
            if (card.Secret)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardName.kirintormage && p.mana >= hc.getManaCost(p))
                    {
                        pen = 500;
                    }
                }
            }

            return pen;
        }
        

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

            switch (c.name)
            {
                case CardName.flare: return 0; break; 
                case CardName.eaterofsecrets: return 0; break; 
                case CardName.kezanmystic: 
                    if (p.enemySecretCount == 1)  return 0;
                    break;
            }

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1)
                {
                    attackedbefore++;
                }
            }

            if ((c.name == CardName.acidicswampooze || c.name == CardName.gluttonousooze)
                && (p.enemyHeroStartClass == TAG_CLASS.WARRIOR || p.enemyHeroStartClass == TAG_CLASS.ROGUE || p.enemyHeroStartClass == TAG_CLASS.PALADIN))
            {
                if (p.enemyHeroStartClass == TAG_CLASS.ROGUE && p.enemyWeapon.Angr <= 2)
                {
                    pen += 100;
                }
                else
                {
                    if (p.enemyWeapon.Angr <= 1)
                    {
                        pen += 100;
                    }
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.HUNTER)
            {
                if (c.type == CardDB.CardType.MOB
                    && (attackedbefore == 0 || c.Health <= 4
                        || (p.enemyHero.HealthPoints >= p.enemyHeroHpStarted && attackedbefore >= 1)))
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.MAGE)
            {
                if (c.type == CardDB.CardType.MOB)
                {
                    Minion m = new Minion
                    {
                        HealthPoints = c.Health,
                        maxHp = c.Health,
                        Attack = c.Attack,
                        taunt = c.tank,
                        name = c.name
                    };

                    // play first the small minion:
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0)
                        || (p.mobsplayedThisTurn == 0 && attackedbefore >= 1))
                    {
                        pen += 10;
                    }
                }

                if (c.type == CardDB.CardType.SPELL && p.cardsPlayedThisTurn == p.mobsplayedThisTurn)
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.PALADIN)
            {
                if (c.type == CardDB.CardType.MOB)
                {
                    Minion m = new Minion
                    {
                        HealthPoints = c.Health,
                        maxHp = c.Health,
                        Attack = c.Attack,
                        taunt = c.tank,
                        name = c.name
                    };
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0) || attackedbefore == 0)
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

            int pen = 0;

            int attackedbefore = 0;

            foreach (Minion mnn in p.ownMinions)
            {
                if (mnn.numAttacksThisTurn >= 1) attackedbefore++;
            }

            if (p.enemyHeroStartClass == TAG_CLASS.HUNTER)
            {
                if (target.isHero)
                {
                    bool canBe_explosive = false;
                    foreach (SecretItem si in p.enemySecretList)
                    {
                        if (si.canBe_explosive) { canBe_explosive = true; break; }
                    }
                    if (canBe_explosive)
                    {
                        foreach(Action a in p.playactions)
                        {
                            switch (a.actionType)
                            {
                                case actionEnum.useHeroPower:
                                    if (a.card.card.playrequires.Contains(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS)) pen += 22;
                                    break;
                                case actionEnum.playcard:
                                    if (a.card.card.type == CardDB.CardType.MOB || a.card.card.playrequires.Contains(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
                                    {
                                        pen += 20;
                                    }
                                    break;
                            }
                        }
                    }
                }

                bool islow = isOwnLowest(m, p);
                if (attackedbefore == 0 && islow) pen -= 20;
                if (attackedbefore == 0 && !islow) pen += 10;

                if (target.isHero && !target.own && p.enemyMinions.Count >= 1)
                {
                    if (hasMinionsWithLowHeal(p)) pen += 10; //penality if we doesn't attacked minions before
                }
            }


            if (p.enemyHeroStartClass == TAG_CLASS.MAGE)
            {
                if (target.isHero)
                {
                    bool canBe_vaporize = false;
                    foreach (SecretItem si in p.enemySecretList)
                    {
                        if (si.canBe_vaporize) { canBe_vaporize = true; break; }
                    }
                    if (canBe_vaporize)
                    {
                        if (!target.own)
                        {
                            bool islow = isOwnLowest(m, p);
                            if (!islow) pen += 10;
                            else
                            {
                                if (getValueOfMinion(m) > 14) pen += 5;
                            }
                            if (p.enemyMinions.Count > 0) pen += 12;
                        }
                        return pen;
                    }
                    else
                    {
                        //TODO other secrets

                        if (p.mobsplayedThisTurn == 0)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if (hc.card.type == CardDB.CardType.MOB && hc.canplayCard(p, true)) { pen += 10; break; }
                            }
                        }
                    }

                }
                else
                {
                    bool canBe_duplicate = false;
                    foreach (SecretItem si in p.enemySecretList)
                    {
                        if (si.canBe_duplicate) { canBe_duplicate = true; break; }
                    }
                    if (canBe_duplicate)
                    {
                        pen = 1;
                        if (target.HealthPoints > m.Attack || target.divineshild) return 0;
                        else
                        {
                            pen += target.handcard.card.cost;
                            if (target.handcard.card.battlecry && target.name != CardName.kingmukla) pen += 1;
                            return pen;
                        }
                    }
                    else return 0;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.PALADIN)
            {

                bool islow = isOwnLowest(m, p);

                if (!target.own && !target.isHero && attackedbefore == 0)
                {
                    if (!isEnemyLowest(target, p) || m.HealthPoints <= 2) pen += 5;
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


        public CardDB.Card getChooseCard(CardDB.Card c, int choice)
        {
            if (choice == 1 && this.choose1database.ContainsKey(c.name))
            {
                c = cdb.getCardDataFromID(this.choose1database[c.name]);
            }
            else if (choice == 2 && this.choose2database.ContainsKey(c.name))
            {
                c = cdb.getCardDataFromID(this.choose2database[c.name]);
            }
            return c;
        }

        public int getValueOfUsefulNeedKeepPriority(CardName name)
        {
            return UsefulNeedKeepDatabase.ContainsKey(name) ? UsefulNeedKeepDatabase[name] : 0;
        }


        private int getValueOfMinion(Minion m)
        {
            int ret = 0;
            ret += 2 * m.Attack + m.HealthPoints;
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
                if (card.card.type != CardDB.CardType.MOB) continue;
                CardDB.Card c = card.card;
                m.HealthPoints = c.Health;
                m.maxHp = c.Health;
                m.Attack = c.Attack;
                m.taunt = c.tank;
                m.name = c.name;
                if (getValueOfMinion(m) < val) ret = false;
            }
            return ret;
        }

        private int getValueOfEnemyMinion(Minion m)
        {
            int ret = 0;
            ret += m.HealthPoints;
            if (m.taunt) ret -= 2;
            return ret;
        }

        private bool isEnemyLowest(Minion mnn, Playfield p)
        {
            bool ret = true;
            List<Minion> litt = p.getAttackTargets(true, false);
            int val = getValueOfEnemyMinion(mnn);
            foreach (Minion m in p.enemyMinions)
            {
                if (litt.Find(x => x.entitiyID == m.entitiyID) == null) continue;
                if (getValueOfEnemyMinion(m) < val) ret = false;
            }
            return ret;
        }

        private bool hasMinionsWithLowHeal(Playfield p)
        {
            bool ret = false;
            foreach (Minion m in p.ownMinions)
            {
                if (m.HealthPoints <= 2 && (m.Ready || this.priorityDatabase.ContainsKey(m.name))) ret = true;
            }
            return ret;
        }

        public int guessTotalSpellDamage(Playfield p, CardName name, bool ownplay)
        {
            int dmg = 0;
            if (this.DamageTargetDatabase.ContainsKey(name)) dmg = this.DamageTargetDatabase[name];
            else if (this.DamageTargetSpecialDatabase.ContainsKey(name)) dmg = this.DamageTargetSpecialDatabase[name];
            else if (this.DamageRandomDatabase.ContainsKey(name)) dmg = this.DamageRandomDatabase[name];
            else if (this.DamageHeroDatabase.ContainsKey(name)) dmg = this.DamageHeroDatabase[name];
            else if (this.DamageAllDatabase.ContainsKey(name)) dmg = (p.ownMinions.Count * this.DamageAllDatabase[name] + p.enemyMinions.Count * this.DamageAllDatabase[name]) * 7 / 10;
            else if (this.DamageAllEnemysDatabase.ContainsKey(name)) dmg = p.enemyMinions.Count * this.DamageAllEnemysDatabase[name] * 7 / 10;
            else if (p.anzOwnAuchenaiSoulpriest >= 1)
            {
                if (this.HealAllDatabase.ContainsKey(name)) dmg = (p.ownMinions.Count * this.HealAllDatabase[name] + p.enemyMinions.Count * this.HealAllDatabase[name]) * 7 / 10;
                else if (this.HealTargetDatabase.ContainsKey(name)) dmg = Math.Min(this.HealTargetDatabase[name], 29);
            }

            if (dmg != 0) dmg = (ownplay) ? p.getSpellDamageDamage(dmg) : p.getEnemySpellDamageDamage(dmg);
            return dmg;
        }


        private void setupEnrageDatabase()
        {
            enrageDatabase.Add(CardName.aberrantberserker, 2);
            enrageDatabase.Add(CardName.amaniberserker, 3);
            enrageDatabase.Add(CardName.angrychicken, 5);
            enrageDatabase.Add(CardName.bloodhoofbrave, 3);
            enrageDatabase.Add(CardName.grommashhellscream, 6);
            enrageDatabase.Add(CardName.ragingworgen, 2);
            enrageDatabase.Add(CardName.spitefulsmith, 2);
            enrageDatabase.Add(CardName.taurenwarrior, 3);
            enrageDatabase.Add(CardName.warbot, 1);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(CardName.circleofhealing, 4);//allminions
            HealAllDatabase.Add(CardName.darkscalehealer, 2);//all friends
            HealAllDatabase.Add(CardName.holynova, 2);//to all own minions
            HealAllDatabase.Add(CardName.treeoflife, 1000);//all friends

            HealHeroDatabase.Add(CardName.amarawardenofhope, 40);
            HealHeroDatabase.Add(CardName.antiquehealbot, 8); //tohero
            HealHeroDatabase.Add(CardName.bindingheal, 5);
            HealHeroDatabase.Add(CardName.cultapothecary, 2);
            HealHeroDatabase.Add(CardName.drainlife, 2);//tohero
            HealHeroDatabase.Add(CardName.guardianofkings, 6);//tohero
            HealHeroDatabase.Add(CardName.holyfire, 5);//tohero
            HealHeroDatabase.Add(CardName.invocationofwater, 12);
            HealHeroDatabase.Add(CardName.jinyuwaterspeaker, 6);
            HealHeroDatabase.Add(CardName.priestessofelune, 4);//tohero
            HealHeroDatabase.Add(CardName.refreshmentvendor, 4);
            HealHeroDatabase.Add(CardName.renojackson, 25); //tohero
            HealHeroDatabase.Add(CardName.sacrificialpact, 5);//tohero
            HealHeroDatabase.Add(CardName.sealoflight, 4); //tohero
            HealHeroDatabase.Add(CardName.siphonsoul, 3); //tohero
            HealHeroDatabase.Add(CardName.tidalsurge, 4);
            HealHeroDatabase.Add(CardName.tournamentmedic, 2);
            HealHeroDatabase.Add(CardName.tuskarrjouster, 7);
            HealHeroDatabase.Add(CardName.twilightdarkmender, 10);

            HealTargetDatabase.Add(CardName.ancestralhealing, 1000);
            HealTargetDatabase.Add(CardName.ancientoflore, 5);
            HealTargetDatabase.Add(CardName.ancientsecrets, 5);
            HealTargetDatabase.Add(CardName.bindingheal, 5);
            HealTargetDatabase.Add(CardName.darkshirealchemist, 5);
            HealTargetDatabase.Add(CardName.earthenringfarseer, 3);
            HealTargetDatabase.Add(CardName.flashheal, 5);
            HealTargetDatabase.Add(CardName.forbiddenhealing, 2);
            HealTargetDatabase.Add(CardName.gadgetzansocialite, 2);
            HealTargetDatabase.Add(CardName.heal, 4);
            HealTargetDatabase.Add(CardName.healingtouch, 8);
            HealTargetDatabase.Add(CardName.healingwave, 14);
            HealTargetDatabase.Add(CardName.holylight, 6);
            HealTargetDatabase.Add(CardName.hotspringguardian, 3);
            HealTargetDatabase.Add(CardName.hozenhealer, 30);
            HealTargetDatabase.Add(CardName.layonhands, 8);
            HealTargetDatabase.Add(CardName.lesserheal, 2);
            HealTargetDatabase.Add(CardName.lightofthenaaru, 3);
            HealTargetDatabase.Add(CardName.moongladeportal, 6);
            HealTargetDatabase.Add(CardName.voodoodoctor, 2);
            HealTargetDatabase.Add(CardName.willofmukla, 8);
            //HealTargetDatabase.Add(CardName.divinespirit, 2);
        }

        private void setupDamageDatabase()
        {
            //DamageAllDatabase.Add(CardName.flameleviathan, 2);
            DamageAllDatabase.Add(CardName.abomination, 2);
            DamageAllDatabase.Add(CardName.abyssalenforcer, 3);
            DamageAllDatabase.Add(CardName.anomalus, 8);
            DamageAllDatabase.Add(CardName.barongeddon, 2);
            DamageAllDatabase.Add(CardName.corruptedseer, 2);
            DamageAllDatabase.Add(CardName.demonwrath, 1);
            DamageAllDatabase.Add(CardName.dragonfirepotion, 5);
            DamageAllDatabase.Add(CardName.dreadinfernal, 1);
            DamageAllDatabase.Add(CardName.dreadscale, 1);
            DamageAllDatabase.Add(CardName.elementaldestruction, 4);
            DamageAllDatabase.Add(CardName.excavatedevil, 3);
            DamageAllDatabase.Add(CardName.explosivesheep, 2);
            DamageAllDatabase.Add(CardName.felbloom, 4);
            DamageAllDatabase.Add(CardName.felfirepotion, 5);
            DamageAllDatabase.Add(CardName.hellfire, 3);
            DamageAllDatabase.Add(CardName.lava, 2);
            DamageAllDatabase.Add(CardName.lightbomb, 5);
            DamageAllDatabase.Add(CardName.magmapulse, 1);
            DamageAllDatabase.Add(CardName.primordialdrake, 2);
            DamageAllDatabase.Add(CardName.ravagingghoul, 1);
            DamageAllDatabase.Add(CardName.revenge, 1);
            DamageAllDatabase.Add(CardName.scarletpurifier, 2);
            DamageAllDatabase.Add(CardName.sleepwiththefishes, 3);
            DamageAllDatabase.Add(CardName.tentacleofnzoth, 1);
            DamageAllDatabase.Add(CardName.unstableghoul, 1);
            DamageAllDatabase.Add(CardName.volcanicpotion, 2);
            DamageAllDatabase.Add(CardName.whirlwind, 1);
            DamageAllDatabase.Add(CardName.yseraawakens, 5);
            DamageAllDatabase.Add(CardName.spiritlash, 1);
            DamageAllDatabase.Add(CardName.defile, 1);
            DamageAllDatabase.Add(CardName.bloodrazor, 1);
            DamageAllDatabase.Add(CardName.bladestorm, 1);

            DamageAllEnemysDatabase.Add(CardName.arcaneexplosion, 1);
            DamageAllEnemysDatabase.Add(CardName.bladeflurry, 1);
            DamageAllEnemysDatabase.Add(CardName.blizzard, 2);
            DamageAllEnemysDatabase.Add(CardName.consecration, 2);
            DamageAllEnemysDatabase.Add(CardName.cthun, 1);
            DamageAllEnemysDatabase.Add(CardName.darkironskulker, 2);
            DamageAllEnemysDatabase.Add(CardName.fanofknives, 1);
            DamageAllEnemysDatabase.Add(CardName.flamestrike, 4);
            DamageAllEnemysDatabase.Add(CardName.holynova, 2);
            DamageAllEnemysDatabase.Add(CardName.invocationofair, 3);
            DamageAllEnemysDatabase.Add(CardName.lightningstorm, 3);
            DamageAllEnemysDatabase.Add(CardName.livingbomb, 5);
            DamageAllEnemysDatabase.Add(CardName.locustswarm, 3);
            DamageAllEnemysDatabase.Add(CardName.maelstromportal, 1);
            DamageAllEnemysDatabase.Add(CardName.poisoncloud, 1);//todo 1 or 2
            DamageAllEnemysDatabase.Add(CardName.sergeantsally, 1);
            DamageAllEnemysDatabase.Add(CardName.shadowflame, 2);
            DamageAllEnemysDatabase.Add(CardName.sporeburst, 1);
            DamageAllEnemysDatabase.Add(CardName.starfall, 2);
            DamageAllEnemysDatabase.Add(CardName.stomp, 2);
            DamageAllEnemysDatabase.Add(CardName.swipe, 1);
            DamageAllEnemysDatabase.Add(CardName.twilightflamecaller, 1);
            DamageAllEnemysDatabase.Add(CardName.explodingbloatbat, 2);
            DamageAllEnemysDatabase.Add(CardName.deathstalkerrexxar, 2);
            DamageAllEnemysDatabase.Add(CardName.deathanddecay, 3);
            DamageAllEnemysDatabase.Add(CardName.bonestorm, 1);

            DamageHeroDatabase.Add(CardName.backstreetleper, 2);
            DamageHeroDatabase.Add(CardName.burningadrenaline, 2);
            DamageHeroDatabase.Add(CardName.curseofrafaam, 2);
            DamageHeroDatabase.Add(CardName.emeraldreaver, 1);
            DamageHeroDatabase.Add(CardName.frostblast, 3);
            DamageHeroDatabase.Add(CardName.headcrack, 2);
            DamageHeroDatabase.Add(CardName.invocationoffire, 6);
            DamageHeroDatabase.Add(CardName.lepergnome, 2);
            DamageHeroDatabase.Add(CardName.mindblast, 5);
            DamageHeroDatabase.Add(CardName.necroticaura, 3);
            DamageHeroDatabase.Add(CardName.nightblade, 3);
            DamageHeroDatabase.Add(CardName.purecold, 8);
            DamageHeroDatabase.Add(CardName.shadowbomber, 3);
            DamageHeroDatabase.Add(CardName.sinisterstrike, 3);

            DamageRandomDatabase.Add(CardName.arcanemissiles, 1);
            DamageRandomDatabase.Add(CardName.avengingwrath, 1);
            DamageRandomDatabase.Add(CardName.bomblobber, 4);
            DamageRandomDatabase.Add(CardName.boombot, 1);
            DamageRandomDatabase.Add(CardName.boombotjr, 1);
            DamageRandomDatabase.Add(CardName.bouncingblade, 1);
            DamageRandomDatabase.Add(CardName.cleave, 2);
            DamageRandomDatabase.Add(CardName.demolisher, 2);
            DamageRandomDatabase.Add(CardName.dieinsect, 8);
            DamageRandomDatabase.Add(CardName.dieinsects, 8);
            DamageRandomDatabase.Add(CardName.fierybat, 1);
            DamageRandomDatabase.Add(CardName.flamecannon, 4);
            DamageRandomDatabase.Add(CardName.flamejuggler, 1);
            DamageRandomDatabase.Add(CardName.flamewaker, 2);
            DamageRandomDatabase.Add(CardName.forkedlightning, 2);
            DamageRandomDatabase.Add(CardName.goblinblastmage, 1);
            DamageRandomDatabase.Add(CardName.greaterarcanemissiles, 3);
            DamageRandomDatabase.Add(CardName.hugetoad, 1);
            DamageRandomDatabase.Add(CardName.knifejuggler, 1);
            DamageRandomDatabase.Add(CardName.madbomber, 1);
            DamageRandomDatabase.Add(CardName.madderbomber, 1);
            DamageRandomDatabase.Add(CardName.multishot, 3);
            DamageRandomDatabase.Add(CardName.ragnarosthefirelord, 8);
            DamageRandomDatabase.Add(CardName.rumblingelemental, 1);
            DamageRandomDatabase.Add(CardName.shadowboxer, 1);
            DamageRandomDatabase.Add(CardName.shipscannon, 2);
            DamageRandomDatabase.Add(CardName.spreadingmadness, 1);
            DamageRandomDatabase.Add(CardName.throwrocks, 3);
            DamageRandomDatabase.Add(CardName.timepieceofhorror, 1);
            DamageRandomDatabase.Add(CardName.volatileelemental, 3);
            DamageRandomDatabase.Add(CardName.volcano, 1);
            DamageRandomDatabase.Add(CardName.breathofsindragosa, 2);
            DamageRandomDatabase.Add(CardName.blackguard, 3);

            DamageTargetDatabase.Add(CardName.arcaneblast, 2);
            DamageTargetDatabase.Add(CardName.arcaneshot, 2);
            DamageTargetDatabase.Add(CardName.backstab, 2);
            DamageTargetDatabase.Add(CardName.ballistashot, 3);
            DamageTargetDatabase.Add(CardName.barreltoss, 2);
            DamageTargetDatabase.Add(CardName.betrayal, 2);
            DamageTargetDatabase.Add(CardName.blackwingcorruptor, 3);//if dragon in hand
            DamageTargetDatabase.Add(CardName.blazecaller, 5);
            DamageTargetDatabase.Add(CardName.blowgillsniper, 1);
            DamageTargetDatabase.Add(CardName.bombsquad, 5);
            DamageTargetDatabase.Add(CardName.cobrashot, 3);
            DamageTargetDatabase.Add(CardName.coneofcold, 1);
            DamageTargetDatabase.Add(CardName.crackle, 3);
            DamageTargetDatabase.Add(CardName.darkbomb, 3);
            DamageTargetDatabase.Add(CardName.discipleofcthun, 2);
            DamageTargetDatabase.Add(CardName.dispatchkodo, 2);
            DamageTargetDatabase.Add(CardName.dragonsbreath, 4);
            DamageTargetDatabase.Add(CardName.drainlife, 2);
            DamageTargetDatabase.Add(CardName.elvenarcher, 1);
            DamageTargetDatabase.Add(CardName.eviscerate, 2);
            DamageTargetDatabase.Add(CardName.explosiveshot, 5);
            DamageTargetDatabase.Add(CardName.felcannon, 2);
            DamageTargetDatabase.Add(CardName.fireball, 6);
            DamageTargetDatabase.Add(CardName.fireblast, 1);
            DamageTargetDatabase.Add(CardName.fireblastrank2, 2);
            DamageTargetDatabase.Add(CardName.firebloomtoxin, 2);
            DamageTargetDatabase.Add(CardName.fireelemental, 3);
            DamageTargetDatabase.Add(CardName.firelandsportal, 5);
            DamageTargetDatabase.Add(CardName.fireplumephoenix, 2);
            DamageTargetDatabase.Add(CardName.flamelance, 8);
            DamageTargetDatabase.Add(CardName.forbiddenflame, 1);
            DamageTargetDatabase.Add(CardName.forgottentorch, 3);
            DamageTargetDatabase.Add(CardName.frostbolt, 3);
            DamageTargetDatabase.Add(CardName.frostshock, 1);
            DamageTargetDatabase.Add(CardName.gormoktheimpaler, 4);
            DamageTargetDatabase.Add(CardName.greaterhealingpotion, 12);
            DamageTargetDatabase.Add(CardName.grievousbite, 2);
            DamageTargetDatabase.Add(CardName.heartoffire, 5);
            DamageTargetDatabase.Add(CardName.hoggersmash, 4);
            DamageTargetDatabase.Add(CardName.holyfire, 5);
            DamageTargetDatabase.Add(CardName.holysmite, 2);
            DamageTargetDatabase.Add(CardName.icelance, 4);//only if iced
            DamageTargetDatabase.Add(CardName.implosion, 2);
            DamageTargetDatabase.Add(CardName.ironforgerifleman, 1);
            DamageTargetDatabase.Add(CardName.jadelightning, 4);
            DamageTargetDatabase.Add(CardName.jadeshuriken, 2);
            DamageTargetDatabase.Add(CardName.keeperofthegrove, 2);
            DamageTargetDatabase.Add(CardName.killcommand, 3);//or 5
            DamageTargetDatabase.Add(CardName.lavaburst, 5);
            DamageTargetDatabase.Add(CardName.lavashock, 2);
            DamageTargetDatabase.Add(CardName.lightningbolt, 3);
            DamageTargetDatabase.Add(CardName.lightningjolt, 2);
            DamageTargetDatabase.Add(CardName.livingroots, 2);//choice 1
            DamageTargetDatabase.Add(CardName.medivhsvalet, 3);
            DamageTargetDatabase.Add(CardName.cloudprince, 6);
            DamageTargetDatabase.Add(CardName.meteor, 15);
            DamageTargetDatabase.Add(CardName.mindshatter, 3);
            DamageTargetDatabase.Add(CardName.mindspike, 2);
            DamageTargetDatabase.Add(CardName.moonfire, 1); 
            DamageTargetDatabase.Add(CardName.mortalcoil, 1);
            DamageTargetDatabase.Add(CardName.mortalstrike, 4);
            DamageTargetDatabase.Add(CardName.northseakraken, 4);
            DamageTargetDatabase.Add(CardName.onthehunt, 1);
            DamageTargetDatabase.Add(CardName.perditionsblade, 1);
            DamageTargetDatabase.Add(CardName.powershot, 2);
            DamageTargetDatabase.Add(CardName.pyroblast, 10);
            DamageTargetDatabase.Add(CardName.razorpetal, 1);
            DamageTargetDatabase.Add(CardName.roaringtorch, 6);
            DamageTargetDatabase.Add(CardName.shadowbolt, 4);
            DamageTargetDatabase.Add(CardName.shadowform, 2);
            DamageTargetDatabase.Add(CardName.shadowstrike, 5);
            DamageTargetDatabase.Add(CardName.shotgunblast, 1);
            DamageTargetDatabase.Add(CardName.si7agent, 2);
            DamageTargetDatabase.Add(CardName.sonicbreath, 3);
            DamageTargetDatabase.Add(CardName.sonoftheflame, 6);
            DamageTargetDatabase.Add(CardName.starfall, 5);//2 to all enemy
            DamageTargetDatabase.Add(CardName.starfire, 5);//draw a card
            DamageTargetDatabase.Add(CardName.steadyshot, 2);//or 1 + card
            DamageTargetDatabase.Add(CardName.stormcrack, 4);
            DamageTargetDatabase.Add(CardName.stormpikecommando, 2);
            DamageTargetDatabase.Add(CardName.swipe, 4);//1 to others
            DamageTargetDatabase.Add(CardName.tidalsurge, 4);
            DamageTargetDatabase.Add(CardName.unbalancingstrike, 3);
            DamageTargetDatabase.Add(CardName.undercityvaliant, 1);
            DamageTargetDatabase.Add(CardName.wrath, 1);//todo 3 or 1+card
            DamageTargetDatabase.Add(CardName.voidform, 2);
            DamageTargetDatabase.Add(CardName.vampiricleech, 3);
            DamageTargetDatabase.Add(CardName.ultimateinfestation, 5);
            DamageTargetDatabase.Add(CardName.toxicarrow, 2);
            DamageTargetDatabase.Add(CardName.siphonlife, 3);
            DamageTargetDatabase.Add(CardName.icytouch, 1);
            DamageTargetDatabase.Add(CardName.iceclaw, 2);
            DamageTargetDatabase.Add(CardName.drainsoul, 2);
            DamageTargetDatabase.Add(CardName.doomerang, 2);
            DamageTargetDatabase.Add(CardName.avalanche, 0);

            DamageTargetSpecialDatabase.Add(CardName.baneofdoom, 2); 
            DamageTargetSpecialDatabase.Add(CardName.bash, 3); //+3 armor
            DamageTargetSpecialDatabase.Add(CardName.bloodtoichor, 1); 
            DamageTargetSpecialDatabase.Add(CardName.crueltaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardName.deathbloom, 5);
            DamageTargetSpecialDatabase.Add(CardName.demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(CardName.demonheart, 5);
            DamageTargetSpecialDatabase.Add(CardName.earthshock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(CardName.feedingtime, 3); 
            DamageTargetSpecialDatabase.Add(CardName.flamegeyser, 2); 
            DamageTargetSpecialDatabase.Add(CardName.hammerofwrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardName.holywrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(CardName.innerrage, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardName.quickshot, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardName.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(CardName.savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(CardName.shieldslam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(CardName.shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(CardName.slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(CardName.soulfire, 4);//delete a card

            HeroPowerEquipWeapon.Add(CardName.daggermastery, 1);
            HeroPowerEquipWeapon.Add(CardName.direshapeshift, 2);
            HeroPowerEquipWeapon.Add(CardName.echolocate, 0);
            HeroPowerEquipWeapon.Add(CardName.enraged, 2);
            HeroPowerEquipWeapon.Add(CardName.poisoneddaggers, 2);
            HeroPowerEquipWeapon.Add(CardName.shapeshift, 1);
            HeroPowerEquipWeapon.Add(CardName.plaguelord, 3);

            
            this.maycauseharmDatabase.Add(CardName.arcaneblast, 1);
            this.maycauseharmDatabase.Add(CardName.arcaneshot, 1);
            this.maycauseharmDatabase.Add(CardName.backstab, 1);
            this.maycauseharmDatabase.Add(CardName.baneofdoom, 1);
            this.maycauseharmDatabase.Add(CardName.barreltoss, 1);
            this.maycauseharmDatabase.Add(CardName.bash, 1);
            this.maycauseharmDatabase.Add(CardName.blastcrystalpotion, 2);
            this.maycauseharmDatabase.Add(CardName.bloodthistletoxin, 3);
            this.maycauseharmDatabase.Add(CardName.bloodtoichor, 1);
            this.maycauseharmDatabase.Add(CardName.chromaticmutation, 5);
            this.maycauseharmDatabase.Add(CardName.cobrashot, 1);
            this.maycauseharmDatabase.Add(CardName.coneofcold, 6);
            this.maycauseharmDatabase.Add(CardName.crackle, 1);
            this.maycauseharmDatabase.Add(CardName.crush, 2);
            this.maycauseharmDatabase.Add(CardName.darkbomb, 1);
            this.maycauseharmDatabase.Add(CardName.deathbloom, 1);
            this.maycauseharmDatabase.Add(CardName.demonfire, 1);
            this.maycauseharmDatabase.Add(CardName.demonheart, 1);
            this.maycauseharmDatabase.Add(CardName.dispel, 4);
            this.maycauseharmDatabase.Add(CardName.dragonsbreath, 1);
            this.maycauseharmDatabase.Add(CardName.drainlife, 1);
            this.maycauseharmDatabase.Add(CardName.drakkisathscommand, 2);
            this.maycauseharmDatabase.Add(CardName.dream, 3);
            this.maycauseharmDatabase.Add(CardName.dynamite, 1);
            this.maycauseharmDatabase.Add(CardName.earthshock, 4);
            this.maycauseharmDatabase.Add(CardName.emergencycoolant, 6);
            this.maycauseharmDatabase.Add(CardName.eviscerate, 1);
            this.maycauseharmDatabase.Add(CardName.explosiveshot, 1);
            this.maycauseharmDatabase.Add(CardName.feedingtime, 1);
            this.maycauseharmDatabase.Add(CardName.fireball, 1);
            this.maycauseharmDatabase.Add(CardName.firebloomtoxin, 1);
            this.maycauseharmDatabase.Add(CardName.firelandsportal, 1);
            this.maycauseharmDatabase.Add(CardName.flamegeyser, 1);
            this.maycauseharmDatabase.Add(CardName.flamelance, 1);
            this.maycauseharmDatabase.Add(CardName.forbiddenflame, 1);
            this.maycauseharmDatabase.Add(CardName.forgottentorch, 1);
            this.maycauseharmDatabase.Add(CardName.frostbolt, 1);
            this.maycauseharmDatabase.Add(CardName.grievousbite, 1);
            this.maycauseharmDatabase.Add(CardName.hakkaribloodgoblet, 5);
            this.maycauseharmDatabase.Add(CardName.hammerofwrath, 1);
            this.maycauseharmDatabase.Add(CardName.hex, 5);
            this.maycauseharmDatabase.Add(CardName.hoggersmash, 1);
            this.maycauseharmDatabase.Add(CardName.holyfire, 1);
            this.maycauseharmDatabase.Add(CardName.holysmite, 1);
            this.maycauseharmDatabase.Add(CardName.holywrath, 1);
            this.maycauseharmDatabase.Add(CardName.humility, 7);
            this.maycauseharmDatabase.Add(CardName.huntersmark, 7);
            this.maycauseharmDatabase.Add(CardName.icelance, 6);
            this.maycauseharmDatabase.Add(CardName.implosion, 1);
            this.maycauseharmDatabase.Add(CardName.innerrage, 1);
            this.maycauseharmDatabase.Add(CardName.jadelightning, 1);
            this.maycauseharmDatabase.Add(CardName.jadeshuriken, 1);
            this.maycauseharmDatabase.Add(CardName.keeperofthegrove, 1);
            this.maycauseharmDatabase.Add(CardName.killcommand, 1);
            this.maycauseharmDatabase.Add(CardName.lavaburst, 1);
            this.maycauseharmDatabase.Add(CardName.lavashock, 1);
            this.maycauseharmDatabase.Add(CardName.lightningbolt, 1);
            this.maycauseharmDatabase.Add(CardName.livingroots, 1);
            this.maycauseharmDatabase.Add(CardName.madbomber, 1);
            this.maycauseharmDatabase.Add(CardName.madderbomber, 1);
            this.maycauseharmDatabase.Add(CardName.meteor, 1);
            this.maycauseharmDatabase.Add(CardName.moonfire, 1);
            this.maycauseharmDatabase.Add(CardName.mortalcoil, 1);
            this.maycauseharmDatabase.Add(CardName.mortalstrike, 1);
            this.maycauseharmDatabase.Add(CardName.mulch, 2);
            this.maycauseharmDatabase.Add(CardName.naturalize, 2);
            this.maycauseharmDatabase.Add(CardName.necroticpoison, 2);
            this.maycauseharmDatabase.Add(CardName.onthehunt, 1);
            this.maycauseharmDatabase.Add(CardName.polymorph, 5);
            this.maycauseharmDatabase.Add(CardName.powershot, 1);
            this.maycauseharmDatabase.Add(CardName.pyroblast, 1);
            this.maycauseharmDatabase.Add(CardName.quickshot, 1);
            this.maycauseharmDatabase.Add(CardName.razorpetal, 1);
            this.maycauseharmDatabase.Add(CardName.roaringtorch, 1);
            this.maycauseharmDatabase.Add(CardName.roguesdoit, 1);
            this.maycauseharmDatabase.Add(CardName.rottenbanana, 1);
            this.maycauseharmDatabase.Add(CardName.savagery, 1);
            this.maycauseharmDatabase.Add(CardName.shadowbolt, 1);
            this.maycauseharmDatabase.Add(CardName.shadowstep, 3);
            this.maycauseharmDatabase.Add(CardName.shadowstrike, 1);
            this.maycauseharmDatabase.Add(CardName.shadowworddeath, 2);
            this.maycauseharmDatabase.Add(CardName.shadowwordpain, 2);
            this.maycauseharmDatabase.Add(CardName.shatter, 2);
            this.maycauseharmDatabase.Add(CardName.shieldslam, 1);
            this.maycauseharmDatabase.Add(CardName.shiv, 1);
            this.maycauseharmDatabase.Add(CardName.silence, 4);
            this.maycauseharmDatabase.Add(CardName.siphonsoul, 2);
            this.maycauseharmDatabase.Add(CardName.slam, 1);
            this.maycauseharmDatabase.Add(CardName.sonicbreath, 1);
            this.maycauseharmDatabase.Add(CardName.soulfire, 1);
            this.maycauseharmDatabase.Add(CardName.spreadingmadness, 1);
            this.maycauseharmDatabase.Add(CardName.starfall, 1);
            this.maycauseharmDatabase.Add(CardName.starfire, 1);
            this.maycauseharmDatabase.Add(CardName.stormcrack, 1);
            this.maycauseharmDatabase.Add(CardName.swipe, 1);
            this.maycauseharmDatabase.Add(CardName.tailswipe, 1);
            this.maycauseharmDatabase.Add(CardName.thetruewarchief, 2);
            this.maycauseharmDatabase.Add(CardName.tidalsurge, 1);
            this.maycauseharmDatabase.Add(CardName.timerewinder, 3);
            this.maycauseharmDatabase.Add(CardName.volcano, 1);
            this.maycauseharmDatabase.Add(CardName.wrath, 1);
            this.maycauseharmDatabase.Add(CardName.drainsoul, 1);
            this.maycauseharmDatabase.Add(CardName.obliterate, 2);
        }

        private void setupsilenceDatabase()
        {
            
            this.silenceDatabase.Add(CardName.defiascleaner, 1);
            this.silenceDatabase.Add(CardName.dispel, 1);
            this.silenceDatabase.Add(CardName.earthshock, 1);
            this.silenceDatabase.Add(CardName.ironbeakowl, 1);
            this.silenceDatabase.Add(CardName.kabalsongstealer, 1);
            this.silenceDatabase.Add(CardName.lightschampion, 1);
            this.silenceDatabase.Add(CardName.massdispel, 1);
            this.silenceDatabase.Add(CardName.purify, -1);
            this.silenceDatabase.Add(CardName.silence, 1);
            this.silenceDatabase.Add(CardName.spellbreaker, 1);
            this.silenceDatabase.Add(CardName.wailingsoul, -2);

            OwnNeedSilenceDatabase.Add(CardName.ancientwatcher, 2);
            OwnNeedSilenceDatabase.Add(CardName.animagolem, 1);
            OwnNeedSilenceDatabase.Add(CardName.bittertidehydra, 1);
            OwnNeedSilenceDatabase.Add(CardName.blackknight, 2);
            OwnNeedSilenceDatabase.Add(CardName.bombsquad, 1);
            OwnNeedSilenceDatabase.Add(CardName.corruptedhealbot, 2);
            OwnNeedSilenceDatabase.Add(CardName.dancingswords, 1);
            OwnNeedSilenceDatabase.Add(CardName.deathcharger, 1);
            OwnNeedSilenceDatabase.Add(CardName.eeriestatue, 0);
            OwnNeedSilenceDatabase.Add(CardName.emeraldhivequeen, 1);
            OwnNeedSilenceDatabase.Add(CardName.felorcsoulfiend, 1);
            OwnNeedSilenceDatabase.Add(CardName.felreaver, 3);
            OwnNeedSilenceDatabase.Add(CardName.frozencrusher, 2);
            OwnNeedSilenceDatabase.Add(CardName.humongousrazorleaf, 2);
            OwnNeedSilenceDatabase.Add(CardName.icehowl, 2);
            OwnNeedSilenceDatabase.Add(CardName.mogortheogre, 1);
            OwnNeedSilenceDatabase.Add(CardName.natthedarkfisher, 0);
            OwnNeedSilenceDatabase.Add(CardName.spectralrider, 1);
            OwnNeedSilenceDatabase.Add(CardName.spectraltrainee, 1);
            OwnNeedSilenceDatabase.Add(CardName.spectralwarrior, 1);
            OwnNeedSilenceDatabase.Add(CardName.spore, 3);
            OwnNeedSilenceDatabase.Add(CardName.thebeast, 1);
            OwnNeedSilenceDatabase.Add(CardName.unlicensedapothecary, 1);
            OwnNeedSilenceDatabase.Add(CardName.unrelentingrider, 1);
            OwnNeedSilenceDatabase.Add(CardName.unrelentingtrainee, 1);
            OwnNeedSilenceDatabase.Add(CardName.unrelentingwarrior, 1);
            OwnNeedSilenceDatabase.Add(CardName.venturecomercenary, 1);
            OwnNeedSilenceDatabase.Add(CardName.whiteknight, 2);
            OwnNeedSilenceDatabase.Add(CardName.wrathguard, 1);
            OwnNeedSilenceDatabase.Add(CardName.zombiechow, 2);
            OwnNeedSilenceDatabase.Add(CardName.tickingabomination, 0);
            OwnNeedSilenceDatabase.Add(CardName.rattlingrascal, 1);
            OwnNeedSilenceDatabase.Add(CardName.masterchest, 1);
        }


        private void setupPriorityList()
        {
            priorityDatabase.Add(CardName.acidmaw, 3);
            priorityDatabase.Add(CardName.animatedarmor, 2);
            priorityDatabase.Add(CardName.archmageantonidas, 6);
            priorityDatabase.Add(CardName.aviana, 5);
            priorityDatabase.Add(CardName.brannbronzebeard, 4);
            priorityDatabase.Add(CardName.cloakedhuntress, 2);
            priorityDatabase.Add(CardName.confessorpaletress, 7);
            priorityDatabase.Add(CardName.crowdfavorite, 6);
            priorityDatabase.Add(CardName.darkshirecouncilman, 2);
            priorityDatabase.Add(CardName.direwolfalpha, 6);
            priorityDatabase.Add(CardName.emperorthaurissan, 5);
            priorityDatabase.Add(CardName.fandralstaghelm, 6);
            priorityDatabase.Add(CardName.flametonguetotem, 6);
            priorityDatabase.Add(CardName.flamewaker, 5);
            priorityDatabase.Add(CardName.frothingberserker, 1);
            priorityDatabase.Add(CardName.gadgetzanauctioneer, 1);
            priorityDatabase.Add(CardName.grimestreetenforcer, 1);
            priorityDatabase.Add(CardName.grimpatron, 5);
            priorityDatabase.Add(CardName.grimscaleoracle, 5);
            priorityDatabase.Add(CardName.grimygadgeteer, 1);
            priorityDatabase.Add(CardName.holychampion, 5);
            priorityDatabase.Add(CardName.knifejuggler, 2);
            priorityDatabase.Add(CardName.kodorider, 6);
            priorityDatabase.Add(CardName.kvaldirraider, 1);
            priorityDatabase.Add(CardName.leokk, 5);
            priorityDatabase.Add(CardName.lyrathesunshard, 1);
            priorityDatabase.Add(CardName.malchezaarsimp, 1);
            priorityDatabase.Add(CardName.malganis, 10);
            priorityDatabase.Add(CardName.manatidetotem, 5);
            priorityDatabase.Add(CardName.mechwarper, 1);
            priorityDatabase.Add(CardName.muklaschampion, 5);
            priorityDatabase.Add(CardName.murlocknight, 5);
            priorityDatabase.Add(CardName.underbellyangler, 5);
            priorityDatabase.Add(CardName.murlocwarleader, 5);
            priorityDatabase.Add(CardName.nexuschampionsaraad, 6);
            priorityDatabase.Add(CardName.northshirecleric, 4);
            priorityDatabase.Add(CardName.pintsizedsummoner, 3);
            priorityDatabase.Add(CardName.primalfintotem, 5);
            priorityDatabase.Add(CardName.prophetvelen, 5);
            priorityDatabase.Add(CardName.questingadventurer, 1);
            priorityDatabase.Add(CardName.radiantelemental, 3);
            priorityDatabase.Add(CardName.ragnaroslightlord, 5);
            priorityDatabase.Add(CardName.raidleader, 5);
            priorityDatabase.Add(CardName.recruiter, 1);
            priorityDatabase.Add(CardName.scavenginghyena, 5);
            priorityDatabase.Add(CardName.secretkeeper, 5);
            priorityDatabase.Add(CardName.sorcerersapprentice, 3);
            priorityDatabase.Add(CardName.southseacaptain, 5);
            priorityDatabase.Add(CardName.spiritsingerumbra, 5);
            priorityDatabase.Add(CardName.stormwindchampion, 5);
            priorityDatabase.Add(CardName.summoningportal, 5);
            priorityDatabase.Add(CardName.summoningstone, 5);
            priorityDatabase.Add(CardName.thevoraxx, 2);
            priorityDatabase.Add(CardName.thunderbluffvaliant, 2);
            priorityDatabase.Add(CardName.timberwolf, 5);
            priorityDatabase.Add(CardName.tunneltrogg, 1);
            priorityDatabase.Add(CardName.viciousfledgling, 4);
            priorityDatabase.Add(CardName.violetillusionist, 10);
            priorityDatabase.Add(CardName.violetteacher, 1);
            priorityDatabase.Add(CardName.warhorsetrainer, 5);
            priorityDatabase.Add(CardName.warsongcommander, 5);
            priorityDatabase.Add(CardName.wickedwitchdoctor, 5);
            priorityDatabase.Add(CardName.wilfredfizzlebang, 1);
            priorityDatabase.Add(CardName.rotface, 1);
            priorityDatabase.Add(CardName.professorputricide, 1);
            priorityDatabase.Add(CardName.moorabi, 1);
        }

        private void setupAttackBuff()
        {
            this.heroAttackBuffDatabase.Add(CardName.bite, 4);
            this.heroAttackBuffDatabase.Add(CardName.claw, 2);
            this.heroAttackBuffDatabase.Add(CardName.evolvespines, 4);
            this.heroAttackBuffDatabase.Add(CardName.feralrage, 4);
            this.heroAttackBuffDatabase.Add(CardName.heroicstrike, 4);
            this.heroAttackBuffDatabase.Add(CardName.gnash, 3);

            this.attackBuffDatabase.Add(CardName.abusivesergeant, 2);
            this.attackBuffDatabase.Add(CardName.adaptation, 1);
            this.attackBuffDatabase.Add(CardName.bananas, 1);
            this.attackBuffDatabase.Add(CardName.bestialwrath, 2); // NEVER ON enemy MINION
            this.attackBuffDatabase.Add(CardName.blessingofkings, 4);
            this.attackBuffDatabase.Add(CardName.blessingofmight, 3);
            this.attackBuffDatabase.Add(CardName.bloodfurypotion, 3);
            this.attackBuffDatabase.Add(CardName.briarthorntoxin, 3);
            this.attackBuffDatabase.Add(CardName.clockworkknight, 1);
            this.attackBuffDatabase.Add(CardName.coldblood, 2);
            this.attackBuffDatabase.Add(CardName.crueltaskmaster, 2);
            this.attackBuffDatabase.Add(CardName.darkirondwarf, 2);
            this.attackBuffDatabase.Add(CardName.darkwispers, 5);//choice 2
            this.attackBuffDatabase.Add(CardName.demonfuse, 3);
            this.attackBuffDatabase.Add(CardName.dinomancy, 2);
            this.attackBuffDatabase.Add(CardName.dinosize, 10);
            this.attackBuffDatabase.Add(CardName.divinestrength, 1);
            this.attackBuffDatabase.Add(CardName.earthenscales, 1);
            this.attackBuffDatabase.Add(CardName.explorershat, 1);
            this.attackBuffDatabase.Add(CardName.innerrage, 2);
            this.attackBuffDatabase.Add(CardName.lancecarrier, 2);
            this.attackBuffDatabase.Add(CardName.lanternofpower, 10);
            this.attackBuffDatabase.Add(CardName.lightfusedstegodon, 1);
            this.attackBuffDatabase.Add(CardName.markofnature, 4);//choice1 
            this.attackBuffDatabase.Add(CardName.markofthewild, 2);
            this.attackBuffDatabase.Add(CardName.markofyshaarj, 2);
            this.attackBuffDatabase.Add(CardName.mutatinginjection, 4);
            this.attackBuffDatabase.Add(CardName.nightmare, 5); //destroy minion on next turn
            this.attackBuffDatabase.Add(CardName.powerwordtentacles, 2);
            this.attackBuffDatabase.Add(CardName.primalfusion, 1);
            this.attackBuffDatabase.Add(CardName.rampage, 3);//only damaged minion 
            this.attackBuffDatabase.Add(CardName.rockbiterweapon, 3);
            this.attackBuffDatabase.Add(CardName.rockpoolhunter, 1);
            this.attackBuffDatabase.Add(CardName.screwjankclunker, 2);
            this.attackBuffDatabase.Add(CardName.sealofchampions, 3);
            this.attackBuffDatabase.Add(CardName.silvermoonportal, 2);
            this.attackBuffDatabase.Add(CardName.spikeridgedsteed, 2);
            this.attackBuffDatabase.Add(CardName.velenschosen, 2);
            this.attackBuffDatabase.Add(CardName.whirlingblades, 1);
            this.attackBuffDatabase.Add(CardName.antimagicshell, 2);
            this.attackBuffDatabase.Add(CardName.fallensuncleric, 1);
            this.attackBuffDatabase.Add(CardName.cryostasis, 3);
            this.attackBuffDatabase.Add(CardName.bonemare, 4);
            this.attackBuffDatabase.Add(CardName.acherusveteran, 1);
        }

        private void setupHealthBuff()
        {
            //healthBuffDatabase.Add(CardName.ancientofwar, 5);//choice2 is only buffing himself!
            //healthBuffDatabase.Add(CardName.rooted, 5);
            healthBuffDatabase.Add(CardName.adaptation, 1);
            healthBuffDatabase.Add(CardName.armorplating, 1);
            healthBuffDatabase.Add(CardName.bananas, 1);
            healthBuffDatabase.Add(CardName.blessingofkings, 4);
            healthBuffDatabase.Add(CardName.clockworkknight, 1);
            healthBuffDatabase.Add(CardName.darkwispers, 5);//choice2
            healthBuffDatabase.Add(CardName.demonfuse, 3);
            healthBuffDatabase.Add(CardName.dinomancy, 2);
            healthBuffDatabase.Add(CardName.dinosize, 10);
            healthBuffDatabase.Add(CardName.divinestrength, 2);
            healthBuffDatabase.Add(CardName.earthenscales, 1);
            healthBuffDatabase.Add(CardName.explorershat, 1);
            healthBuffDatabase.Add(CardName.lanternofpower, 10);
            healthBuffDatabase.Add(CardName.lightfusedstegodon, 1);
            healthBuffDatabase.Add(CardName.markofnature, 4);//choice2
            healthBuffDatabase.Add(CardName.markofthewild, 2);
            healthBuffDatabase.Add(CardName.markofyshaarj, 2);
            healthBuffDatabase.Add(CardName.mutatinginjection, 4);
            healthBuffDatabase.Add(CardName.nightmare, 5);
            healthBuffDatabase.Add(CardName.powerwordshield, 2);
            healthBuffDatabase.Add(CardName.powerwordtentacles, 6);
            healthBuffDatabase.Add(CardName.primalfusion, 1);
            healthBuffDatabase.Add(CardName.rampage, 3);
            healthBuffDatabase.Add(CardName.rockpoolhunter, 1);
            healthBuffDatabase.Add(CardName.screwjankclunker, 2);
            healthBuffDatabase.Add(CardName.silvermoonportal, 2);
            healthBuffDatabase.Add(CardName.spikeridgedsteed, 6);
            healthBuffDatabase.Add(CardName.upgradedrepairbot, 4);
            healthBuffDatabase.Add(CardName.velenschosen, 4);
            healthBuffDatabase.Add(CardName.wildwalker, 3);
            healthBuffDatabase.Add(CardName.antimagicshell, 2);
            healthBuffDatabase.Add(CardName.sunbornevalkyr, 2);
            healthBuffDatabase.Add(CardName.fallensuncleric, 1);
            healthBuffDatabase.Add(CardName.cryostasis, 3);
            healthBuffDatabase.Add(CardName.bonemare, 4);

            tauntBuffDatabase.Add(CardName.ancestralhealing, 1);
            tauntBuffDatabase.Add(CardName.darkwispers, 1);
            tauntBuffDatabase.Add(CardName.markofnature, 1);
            tauntBuffDatabase.Add(CardName.markofthewild, 1);
            tauntBuffDatabase.Add(CardName.mutatinginjection, 1);
            tauntBuffDatabase.Add(CardName.rustyhorn, 1);
            tauntBuffDatabase.Add(CardName.sparringpartner, 1);
            tauntBuffDatabase.Add(CardName.spikeridgedsteed, 1);
        }

        private void setupCardDrawBattlecry()
        {
            cardDrawBattleCryDatabase.Add(CardName.alightinthedarkness, 1);
            cardDrawBattleCryDatabase.Add(CardName.ancestralknowledge, 2);
            cardDrawBattleCryDatabase.Add(CardName.ancientoflore, 1);
            cardDrawBattleCryDatabase.Add(CardName.ancientteachings, 1);
            cardDrawBattleCryDatabase.Add(CardName.arcaneintellect, 2);
            cardDrawBattleCryDatabase.Add(CardName.archthiefrafaam, 1);
            cardDrawBattleCryDatabase.Add(CardName.azuredrake, 1);
            cardDrawBattleCryDatabase.Add(CardName.babblingbook, 1);
            cardDrawBattleCryDatabase.Add(CardName.battlerage, 0);//only if wounded own minions or hero
            cardDrawBattleCryDatabase.Add(CardName.bloodwarriors, 1);
            cardDrawBattleCryDatabase.Add(CardName.burgle, 2);
            cardDrawBattleCryDatabase.Add(CardName.cabaliststome, 3);
            cardDrawBattleCryDatabase.Add(CardName.callpet, 1);
            cardDrawBattleCryDatabase.Add(CardName.carnassasbrood, 1);
            cardDrawBattleCryDatabase.Add(CardName.chitteringtunneler, 1);
            cardDrawBattleCryDatabase.Add(CardName.chooseyourpath, 1);
            cardDrawBattleCryDatabase.Add(CardName.coldlightoracle, 2);
            cardDrawBattleCryDatabase.Add(CardName.commandingshout, 1);
            cardDrawBattleCryDatabase.Add(CardName.convert, 1);
            cardDrawBattleCryDatabase.Add(CardName.darkpeddler, 1);
            cardDrawBattleCryDatabase.Add(CardName.darkshirelibrarian, 1);
            cardDrawBattleCryDatabase.Add(CardName.desertcamel, 1);
            cardDrawBattleCryDatabase.Add(CardName.divinefavor, 0);//only if enemy has more cards than you
            cardDrawBattleCryDatabase.Add(CardName.drakonidoperative, 1);
            cardDrawBattleCryDatabase.Add(CardName.echoofmedivh, 0);
            cardDrawBattleCryDatabase.Add(CardName.elisestarseeker, 1);
            cardDrawBattleCryDatabase.Add(CardName.elitetaurenchieftain, 1);
            cardDrawBattleCryDatabase.Add(CardName.etherealconjurer, 1);
            cardDrawBattleCryDatabase.Add(CardName.excessmana, 0);
            cardDrawBattleCryDatabase.Add(CardName.fanofknives, 1);
            cardDrawBattleCryDatabase.Add(CardName.farsight, 1);
            cardDrawBattleCryDatabase.Add(CardName.fightpromoter, 2);
            cardDrawBattleCryDatabase.Add(CardName.finderskeepers, 1);
            cardDrawBattleCryDatabase.Add(CardName.firefly, 1);
            cardDrawBattleCryDatabase.Add(CardName.flamegeyser, 1);
            cardDrawBattleCryDatabase.Add(CardName.flameheart, 2);
            cardDrawBattleCryDatabase.Add(CardName.flare, 1);
            cardDrawBattleCryDatabase.Add(CardName.freefromamber, 1);
            cardDrawBattleCryDatabase.Add(CardName.giftofcards, 1); //choice = 2
            cardDrawBattleCryDatabase.Add(CardName.gnomishexperimenter, 1);
            cardDrawBattleCryDatabase.Add(CardName.gnomishinventor, 1);
            cardDrawBattleCryDatabase.Add(CardName.goldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardName.gorillabota3, 1);
            cardDrawBattleCryDatabase.Add(CardName.grandcrusader, 1);
            cardDrawBattleCryDatabase.Add(CardName.grimestreetinformant, 1);
            cardDrawBattleCryDatabase.Add(CardName.hallucination, 1);
            cardDrawBattleCryDatabase.Add(CardName.hammerofwrath, 1);
            cardDrawBattleCryDatabase.Add(CardName.harrisonjones, 0);
            cardDrawBattleCryDatabase.Add(CardName.harvest, 1);
            cardDrawBattleCryDatabase.Add(CardName.holywrath, 1);
            cardDrawBattleCryDatabase.Add(CardName.hydrologist, 1);
            cardDrawBattleCryDatabase.Add(CardName.iknowaguy, 1);
            cardDrawBattleCryDatabase.Add(CardName.ivoryknight, 1);
            cardDrawBattleCryDatabase.Add(CardName.jeweledmacaw, 1);
            cardDrawBattleCryDatabase.Add(CardName.jeweledscarab, 1);
            cardDrawBattleCryDatabase.Add(CardName.journeybelow, 1);
            cardDrawBattleCryDatabase.Add(CardName.kabalchemist, 1);
            cardDrawBattleCryDatabase.Add(CardName.kabalcourier, 1);
            cardDrawBattleCryDatabase.Add(CardName.kazakus, 1);
            cardDrawBattleCryDatabase.Add(CardName.kingmukla, 2);
            cardDrawBattleCryDatabase.Add(CardName.kingsblood, 2);
            cardDrawBattleCryDatabase.Add(CardName.kingsbloodtoxin, 1);
            cardDrawBattleCryDatabase.Add(CardName.kingselekk, 1);
            cardDrawBattleCryDatabase.Add(CardName.layonhands, 3);
            cardDrawBattleCryDatabase.Add(CardName.lifetap, 1);
            cardDrawBattleCryDatabase.Add(CardName.lockandload, 0);
            cardDrawBattleCryDatabase.Add(CardName.lotusagents, 1);
            cardDrawBattleCryDatabase.Add(CardName.lunarvisions, 2);
            cardDrawBattleCryDatabase.Add(CardName.maptothegoldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardName.markofyshaarj, 0);
            cardDrawBattleCryDatabase.Add(CardName.massdispel, 1);
            cardDrawBattleCryDatabase.Add(CardName.megafin, 9);
            cardDrawBattleCryDatabase.Add(CardName.mimicpod, 2);
            cardDrawBattleCryDatabase.Add(CardName.mindpocalypse, 2);
            cardDrawBattleCryDatabase.Add(CardName.mindvision, 1);
            cardDrawBattleCryDatabase.Add(CardName.mortalcoil, 0);//only if kills
            cardDrawBattleCryDatabase.Add(CardName.muklatyrantofthevale, 2);
            cardDrawBattleCryDatabase.Add(CardName.museumcurator, 1);
            cardDrawBattleCryDatabase.Add(CardName.nefarian, 2);
            cardDrawBattleCryDatabase.Add(CardName.neptulon, 4);
            cardDrawBattleCryDatabase.Add(CardName.netherspitehistorian, 1);
            cardDrawBattleCryDatabase.Add(CardName.nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(CardName.noviceengineer, 1);
            cardDrawBattleCryDatabase.Add(CardName.powerwordshield, 1);
            cardDrawBattleCryDatabase.Add(CardName.primalfinlookout, 1);
            cardDrawBattleCryDatabase.Add(CardName.primordialglyph, 1);
            cardDrawBattleCryDatabase.Add(CardName.purify, 1);
            cardDrawBattleCryDatabase.Add(CardName.quickshot, 0);//only if your hand is empty
            cardDrawBattleCryDatabase.Add(CardName.ravenidol, 1);
            cardDrawBattleCryDatabase.Add(CardName.razorpetallasher, 1);
            cardDrawBattleCryDatabase.Add(CardName.razorpetalvolley, 2);
            cardDrawBattleCryDatabase.Add(CardName.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(CardName.servantofkalimos, 0);
            cardDrawBattleCryDatabase.Add(CardName.shadowcaster, 1);
            cardDrawBattleCryDatabase.Add(CardName.shadowoil, 2);
            cardDrawBattleCryDatabase.Add(CardName.shadowvisions, 1);
            cardDrawBattleCryDatabase.Add(CardName.shieldblock, 1);
            cardDrawBattleCryDatabase.Add(CardName.shiv, 1);
            cardDrawBattleCryDatabase.Add(CardName.slam, 0); //if survives
            cardDrawBattleCryDatabase.Add(CardName.smalltimerecruits, 3);
            cardDrawBattleCryDatabase.Add(CardName.solemnvigil, 2);
            cardDrawBattleCryDatabase.Add(CardName.soultap, 1);
            cardDrawBattleCryDatabase.Add(CardName.spellslinger, 1);
            cardDrawBattleCryDatabase.Add(CardName.sprint, 4);
            cardDrawBattleCryDatabase.Add(CardName.stampede, 0);
            cardDrawBattleCryDatabase.Add(CardName.starfire, 1);
            cardDrawBattleCryDatabase.Add(CardName.stonehilldefender, 1);
            cardDrawBattleCryDatabase.Add(CardName.swashburglar, 1);
            cardDrawBattleCryDatabase.Add(CardName.thecurator, 2);
            cardDrawBattleCryDatabase.Add(CardName.thistletea, 3);
            cardDrawBattleCryDatabase.Add(CardName.thoughtsteal, 0);
            cardDrawBattleCryDatabase.Add(CardName.tinkertowntechnician, 0); // If you have a Mech
            cardDrawBattleCryDatabase.Add(CardName.tolvirwarden, 2);
            cardDrawBattleCryDatabase.Add(CardName.tombspider, 1);
            cardDrawBattleCryDatabase.Add(CardName.tortollanforager, 1);
            cardDrawBattleCryDatabase.Add(CardName.tortollanprimalist, 1);
            cardDrawBattleCryDatabase.Add(CardName.toshley, 1);
            cardDrawBattleCryDatabase.Add(CardName.tracking, 1); //NOT SUPPORTED YET
            cardDrawBattleCryDatabase.Add(CardName.ungoropack, 5);
            cardDrawBattleCryDatabase.Add(CardName.unholyshadow, 2);
            cardDrawBattleCryDatabase.Add(CardName.unstableportal, 1);
            cardDrawBattleCryDatabase.Add(CardName.varianwrynn, 3);
            cardDrawBattleCryDatabase.Add(CardName.wildmagic, 1);
            cardDrawBattleCryDatabase.Add(CardName.wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(CardName.wrathion, 1);
            cardDrawBattleCryDatabase.Add(CardName.xarilpoisonedmind, 1);
            cardDrawBattleCryDatabase.Add(CardName.ultimateinfestation, 5);
            cardDrawBattleCryDatabase.Add(CardName.tomblurker, 1);
            cardDrawBattleCryDatabase.Add(CardName.ghastlyconjurer, 1);
            cardDrawBattleCryDatabase.Add(CardName.deathgrip, 1);
            cardDrawBattleCryDatabase.Add(CardName.stitchedtracker, 1);
            cardDrawBattleCryDatabase.Add(CardName.rollthebones, 1);
            cardDrawBattleCryDatabase.Add(CardName.icefishing, 2);
            cardDrawBattleCryDatabase.Add(CardName.howlingcommander, 0);
            cardDrawBattleCryDatabase.Add(CardName.frozenclone, 1);
            cardDrawBattleCryDatabase.Add(CardName.forgeofsouls, 2);
            cardDrawBattleCryDatabase.Add(CardName.devourmind, 3);

            cardDrawDeathrattleDatabase.Add(CardName.acolyteofpain, 1);
            cardDrawDeathrattleDatabase.Add(CardName.anubarak, 1);
            cardDrawDeathrattleDatabase.Add(CardName.bloodmagethalnos, 1);
            cardDrawDeathrattleDatabase.Add(CardName.clockworkgnome, 1);
            cardDrawDeathrattleDatabase.Add(CardName.crystallineoracle, 1);
            cardDrawDeathrattleDatabase.Add(CardName.dancingswords, 1);
            cardDrawDeathrattleDatabase.Add(CardName.deadlyfork, 1);
            cardDrawDeathrattleDatabase.Add(CardName.hook, 1);
            cardDrawDeathrattleDatabase.Add(CardName.igneouselemental, 2);
            cardDrawDeathrattleDatabase.Add(CardName.loothoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardName.meanstreetmarshal, 1);
            cardDrawDeathrattleDatabase.Add(CardName.mechanicalyeti, 1);
            cardDrawDeathrattleDatabase.Add(CardName.mechbearcat, 1);
            cardDrawDeathrattleDatabase.Add(CardName.pollutedhoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardName.pyros, 1);
            cardDrawDeathrattleDatabase.Add(CardName.rhonin, 3);
            cardDrawDeathrattleDatabase.Add(CardName.runicegg, 1);
            cardDrawDeathrattleDatabase.Add(CardName.shiftingshade, 1);
            cardDrawDeathrattleDatabase.Add(CardName.shimmeringtempest, 1);
            cardDrawDeathrattleDatabase.Add(CardName.tentaclesforarms, 1);
            cardDrawDeathrattleDatabase.Add(CardName.tombpillager, 1);
            cardDrawDeathrattleDatabase.Add(CardName.toshley, 1);
            cardDrawDeathrattleDatabase.Add(CardName.undercityhuckster, 1);
            cardDrawDeathrattleDatabase.Add(CardName.webspinner, 1);
            cardDrawDeathrattleDatabase.Add(CardName.xarilpoisonedmind, 1);
            cardDrawDeathrattleDatabase.Add(CardName.shallowgravedigger, 1);
            cardDrawDeathrattleDatabase.Add(CardName.frozenchampion, 1);
            cardDrawDeathrattleDatabase.Add(CardName.bonedrake, 1);
            cardDrawDeathrattleDatabase.Add(CardName.bonebaron, 2);
            cardDrawDeathrattleDatabase.Add(CardName.arfus, 1);
            cardDrawDeathrattleDatabase.Add(CardName.glacialmysteries, 1);
        }


        private void setupUsefulNeedKeepDatabase()
        {
            UsefulNeedKeepDatabase.Add(CardName.acidmaw, 4);
            UsefulNeedKeepDatabase.Add(CardName.addledgrizzly, 9);
            UsefulNeedKeepDatabase.Add(CardName.airelemental, 6);
            UsefulNeedKeepDatabase.Add(CardName.alarmobot, 4);
            UsefulNeedKeepDatabase.Add(CardName.ancientharbinger, 2);
            UsefulNeedKeepDatabase.Add(CardName.animatedarmor, 12);
            UsefulNeedKeepDatabase.Add(CardName.archmageantonidas, 7);
            UsefulNeedKeepDatabase.Add(CardName.armorsmith, 10);
            UsefulNeedKeepDatabase.Add(CardName.aviana, 7);
            UsefulNeedKeepDatabase.Add(CardName.backroombouncer, 1);
            UsefulNeedKeepDatabase.Add(CardName.bloodimp, 10);
            UsefulNeedKeepDatabase.Add(CardName.brannbronzebeard, 9);
            UsefulNeedKeepDatabase.Add(CardName.burlyrockjawtrogg, 5);
            UsefulNeedKeepDatabase.Add(CardName.cloakedhuntress, 12);
            UsefulNeedKeepDatabase.Add(CardName.cobaltguardian, 8);
            UsefulNeedKeepDatabase.Add(CardName.coldarradrake, 15);
            UsefulNeedKeepDatabase.Add(CardName.confessorpaletress, 32);
            UsefulNeedKeepDatabase.Add(CardName.cultmaster, 10);
            UsefulNeedKeepDatabase.Add(CardName.cultsorcerer, 13);
            UsefulNeedKeepDatabase.Add(CardName.darkshirecouncilman, 0);
            UsefulNeedKeepDatabase.Add(CardName.dementedfrostcaller, 15);
            UsefulNeedKeepDatabase.Add(CardName.demolisher, 11);
            UsefulNeedKeepDatabase.Add(CardName.direwolfalpha, 30);
            UsefulNeedKeepDatabase.Add(CardName.dragonkinsorcerer, 9);
            UsefulNeedKeepDatabase.Add(CardName.emboldener3000, 10);
            UsefulNeedKeepDatabase.Add(CardName.emperorthaurissan, 11);
            UsefulNeedKeepDatabase.Add(CardName.faeriedragon, 7);
            UsefulNeedKeepDatabase.Add(CardName.fallenhero, 15);
            UsefulNeedKeepDatabase.Add(CardName.masterchest, 48);
            UsefulNeedKeepDatabase.Add(CardName.fandralstaghelm, 15);
            UsefulNeedKeepDatabase.Add(CardName.felcannon, 10);
            UsefulNeedKeepDatabase.Add(CardName.flametonguetotem, 30);
            UsefulNeedKeepDatabase.Add(CardName.flamewaker, 12);
            UsefulNeedKeepDatabase.Add(CardName.flesheatingghoul, 9);
            UsefulNeedKeepDatabase.Add(CardName.floatingwatcher, 10);
            UsefulNeedKeepDatabase.Add(CardName.frothingberserker, 9);
            UsefulNeedKeepDatabase.Add(CardName.gadgetzanauctioneer, 9);
            UsefulNeedKeepDatabase.Add(CardName.garrisoncommander, 7);
            UsefulNeedKeepDatabase.Add(CardName.gazlowe, 6);
            UsefulNeedKeepDatabase.Add(CardName.grimestreetenforcer, 12);
            UsefulNeedKeepDatabase.Add(CardName.grimscaleoracle, 10);
            UsefulNeedKeepDatabase.Add(CardName.grimygadgeteer, 11);
            UsefulNeedKeepDatabase.Add(CardName.gruul, 4);
            UsefulNeedKeepDatabase.Add(CardName.hallazealtheascended, 16);
            UsefulNeedKeepDatabase.Add(CardName.healingtotem, 9);
            UsefulNeedKeepDatabase.Add(CardName.hobgoblin, 10);
            UsefulNeedKeepDatabase.Add(CardName.hogger, 13);
            UsefulNeedKeepDatabase.Add(CardName.homingchicken, 12);
            UsefulNeedKeepDatabase.Add(CardName.illidanstormrage, 10);
            UsefulNeedKeepDatabase.Add(CardName.illuminator, 2);
            UsefulNeedKeepDatabase.Add(CardName.impmaster, 5);
            UsefulNeedKeepDatabase.Add(CardName.ironsensei, 10);
            UsefulNeedKeepDatabase.Add(CardName.jeeves, 0);
            UsefulNeedKeepDatabase.Add(CardName.junkbot, 10);
            UsefulNeedKeepDatabase.Add(CardName.kabaltrafficker, 1);
            UsefulNeedKeepDatabase.Add(CardName.kelthuzad, 18);
            UsefulNeedKeepDatabase.Add(CardName.knifejuggler, 10);
            UsefulNeedKeepDatabase.Add(CardName.kodorider, 20);
            UsefulNeedKeepDatabase.Add(CardName.kvaldirraider, 12);
            UsefulNeedKeepDatabase.Add(CardName.leokk, 10);
            UsefulNeedKeepDatabase.Add(CardName.lightwarden, 10);
            UsefulNeedKeepDatabase.Add(CardName.lightwell, 13);
            UsefulNeedKeepDatabase.Add(CardName.lyrathesunshard, 9);
            UsefulNeedKeepDatabase.Add(CardName.maidenofthelake, 18);
            UsefulNeedKeepDatabase.Add(CardName.malchezaarsimp, 0);
            UsefulNeedKeepDatabase.Add(CardName.malganis, 13);
            UsefulNeedKeepDatabase.Add(CardName.manatidetotem, 10);
            UsefulNeedKeepDatabase.Add(CardName.manawyrm, 9);
            UsefulNeedKeepDatabase.Add(CardName.masterswordsmith, 10);
            UsefulNeedKeepDatabase.Add(CardName.mechwarper, 11);
            UsefulNeedKeepDatabase.Add(CardName.mekgineerthermaplugg, 5);
            UsefulNeedKeepDatabase.Add(CardName.micromachine, 12);
            UsefulNeedKeepDatabase.Add(CardName.moroes, 13);
            UsefulNeedKeepDatabase.Add(CardName.muklaschampion, 14);
            UsefulNeedKeepDatabase.Add(CardName.murlocknight, 16);
            UsefulNeedKeepDatabase.Add(CardName.underbellyangler, 17);
            UsefulNeedKeepDatabase.Add(CardName.murloctidecaller, 10);
            UsefulNeedKeepDatabase.Add(CardName.murlocwarleader, 11);
            UsefulNeedKeepDatabase.Add(CardName.natpagle, 2);
            UsefulNeedKeepDatabase.Add(CardName.nexuschampionsaraad, 30);
            UsefulNeedKeepDatabase.Add(CardName.northshirecleric, 11);
            UsefulNeedKeepDatabase.Add(CardName.obsidiandestroyer, 10);
            UsefulNeedKeepDatabase.Add(CardName.pintsizedsummoner, 10);
            UsefulNeedKeepDatabase.Add(CardName.priestofthefeast, 3);
            UsefulNeedKeepDatabase.Add(CardName.primalfintotem, 9);
            UsefulNeedKeepDatabase.Add(CardName.prophetvelen, 5);
            UsefulNeedKeepDatabase.Add(CardName.questingadventurer, 9);
            UsefulNeedKeepDatabase.Add(CardName.radiantelemental, 10);
            UsefulNeedKeepDatabase.Add(CardName.ragnaroslightlord, 19);
            UsefulNeedKeepDatabase.Add(CardName.ragnarosthefirelord, 5);
            UsefulNeedKeepDatabase.Add(CardName.raidleader, 11);
            UsefulNeedKeepDatabase.Add(CardName.recruiter, 15);
            UsefulNeedKeepDatabase.Add(CardName.redmanawyrm, 8);
            UsefulNeedKeepDatabase.Add(CardName.repairbot, 10);
            UsefulNeedKeepDatabase.Add(CardName.rumblingelemental, 7);
            UsefulNeedKeepDatabase.Add(CardName.scavenginghyena, 10);
            UsefulNeedKeepDatabase.Add(CardName.secretkeeper, 10);
            UsefulNeedKeepDatabase.Add(CardName.shadeofnaxxramas, 10);
            UsefulNeedKeepDatabase.Add(CardName.shadowboxer, 11);
            UsefulNeedKeepDatabase.Add(CardName.shakuthecollector, 25);
            UsefulNeedKeepDatabase.Add(CardName.shipscannon, 10);
            UsefulNeedKeepDatabase.Add(CardName.siegeengine, 8);
            UsefulNeedKeepDatabase.Add(CardName.siltfinspiritwalker, 5);
            UsefulNeedKeepDatabase.Add(CardName.silverhandregent, 14);
            UsefulNeedKeepDatabase.Add(CardName.sorcerersapprentice, 10);
            UsefulNeedKeepDatabase.Add(CardName.southseacaptain, 11);
            UsefulNeedKeepDatabase.Add(CardName.spiritsingerumbra, 13);
            UsefulNeedKeepDatabase.Add(CardName.starvingbuzzard, 8);
            UsefulNeedKeepDatabase.Add(CardName.stonesplintertrogg, 8);
            UsefulNeedKeepDatabase.Add(CardName.stormwindchampion, 10);
            UsefulNeedKeepDatabase.Add(CardName.summoningportal, 10);
            UsefulNeedKeepDatabase.Add(CardName.summoningstone, 13);
            UsefulNeedKeepDatabase.Add(CardName.thunderbluffvaliant, 16);
            UsefulNeedKeepDatabase.Add(CardName.timberwolf, 10);
            UsefulNeedKeepDatabase.Add(CardName.tradeprincegallywix, 5);
            UsefulNeedKeepDatabase.Add(CardName.troggzortheearthinator, 4);
            UsefulNeedKeepDatabase.Add(CardName.twilightelder, 9);
            UsefulNeedKeepDatabase.Add(CardName.undertaker, 8);
            UsefulNeedKeepDatabase.Add(CardName.usherofsouls, 2);
            UsefulNeedKeepDatabase.Add(CardName.viciousfledgling, 13);
            UsefulNeedKeepDatabase.Add(CardName.violetillusionist, 14);
            UsefulNeedKeepDatabase.Add(CardName.violetteacher, 10);
            UsefulNeedKeepDatabase.Add(CardName.vitalitytotem, 8);
            UsefulNeedKeepDatabase.Add(CardName.warhorsetrainer, 13);
            UsefulNeedKeepDatabase.Add(CardName.warsongcommander, 10);
            UsefulNeedKeepDatabase.Add(CardName.weespellstopper, 11);
            UsefulNeedKeepDatabase.Add(CardName.wickedwitchdoctor, 13);
            UsefulNeedKeepDatabase.Add(CardName.wilfredfizzlebang, 16);
            UsefulNeedKeepDatabase.Add(CardName.windupburglebot, 5);
            UsefulNeedKeepDatabase.Add(CardName.youngpriestess, 10);
            UsefulNeedKeepDatabase.Add(CardName.shadowascendant, 10);
            UsefulNeedKeepDatabase.Add(CardName.festergut, 25);
            UsefulNeedKeepDatabase.Add(CardName.drakkarienchanter, 17);
            UsefulNeedKeepDatabase.Add(CardName.despicabledreadlord, 14);
            UsefulNeedKeepDatabase.Add(CardName.cobaltscalebane, 10);
            UsefulNeedKeepDatabase.Add(CardName.valkyrsoulclaimer, 10);
            UsefulNeedKeepDatabase.Add(CardName.runeforgehaunter, 1);
            UsefulNeedKeepDatabase.Add(CardName.rotface, 26);
            UsefulNeedKeepDatabase.Add(CardName.necroticgeist, 12);
            UsefulNeedKeepDatabase.Add(CardName.moorabi, 16);
            UsefulNeedKeepDatabase.Add(CardName.icewalker, 15);
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(CardName.darkbargain, 6);
            cardDiscardDatabase.Add(CardName.darkshirelibrarian, 2);
            cardDiscardDatabase.Add(CardName.doomguard, 5);
            cardDiscardDatabase.Add(CardName.lakkarifelhound, 4);
            cardDiscardDatabase.Add(CardName.soulfire, 1);
            cardDiscardDatabase.Add(CardName.succubus, 2);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(CardName.brawl, 0);
            this.destroyOwnDatabase.Add(CardName.deathwing, 0);
            this.destroyOwnDatabase.Add(CardName.golakkacrawler, 0);
            this.destroyOwnDatabase.Add(CardName.hungrycrab, 0);//not own mins
            this.destroyOwnDatabase.Add(CardName.kingmosh, 0);
            this.destroyOwnDatabase.Add(CardName.naturalize, 0);//not own mins
            this.destroyOwnDatabase.Add(CardName.ravenouspterrordax, 0);
            this.destroyOwnDatabase.Add(CardName.sacrificialpact, 0);//not own mins
            this.destroyOwnDatabase.Add(CardName.siphonsoul, 0);//not own mins
            this.destroyOwnDatabase.Add(CardName.shadowflame, 0);
            this.destroyOwnDatabase.Add(CardName.twistingnether, 0);
            this.destroyOwnDatabase.Add(CardName.unwillingsacrifice, 0);
            this.destroyOwnDatabase.Add(CardName.sanguinereveler, 0);

            this.destroyDatabase.Add(CardName.assassinate, 0);//not own mins
            this.destroyDatabase.Add(CardName.biggamehunter, 0);
            this.destroyDatabase.Add(CardName.bladeofcthun, 0);
            this.destroyDatabase.Add(CardName.blastcrystalpotion, 0);
            this.destroyDatabase.Add(CardName.bookwyrm, 0);
            this.destroyDatabase.Add(CardName.corruption, 0);//not own mins
            this.destroyDatabase.Add(CardName.crush, 0);//not own mins
            this.destroyDatabase.Add(CardName.darkbargain, 0);
            this.destroyDatabase.Add(CardName.deadlyshot, 0);
            this.destroyDatabase.Add(CardName.doom, 0);
            this.destroyDatabase.Add(CardName.drakkisathscommand, 0);
            this.destroyDatabase.Add(CardName.enterthecoliseum, 0);
            this.destroyDatabase.Add(CardName.execute, 0);//not own mins
            this.destroyDatabase.Add(CardName.hemetnesingwary, 0);//not own mins
            this.destroyDatabase.Add(CardName.mindcontrol, 0);//not own mins
            this.destroyDatabase.Add(CardName.moatlurker, 1);
            this.destroyDatabase.Add(CardName.mulch, 0);
            this.destroyDatabase.Add(CardName.necroticpoison, 0);
            this.destroyDatabase.Add(CardName.rendblackhand, 0);
            this.destroyDatabase.Add(CardName.sabotage, 0);//not own mins
            this.destroyDatabase.Add(CardName.shadowworddeath, 0);
            this.destroyDatabase.Add(CardName.shadowwordhorror, 0);
            this.destroyDatabase.Add(CardName.shadowwordpain, 0);
            this.destroyDatabase.Add(CardName.shatter, 0);
            this.destroyDatabase.Add(CardName.theblackknight, 0);//not own mins
            this.destroyDatabase.Add(CardName.thetruewarchief, 0);
            this.destroyDatabase.Add(CardName.vilespineslayer, 0);
            this.destroyDatabase.Add(CardName.voidcrusher, 0);
            this.destroyDatabase.Add(CardName.obsidianstatue, 0);
            this.destroyDatabase.Add(CardName.obliterate, 0);
            this.destroyDatabase.Add(CardName.doompact, 0);
        }

        private void setupReturnBackToHandCards()
        {
            returnHandDatabase.Add(CardName.ancientbrewmaster, 0);
            returnHandDatabase.Add(CardName.bloodthistletoxin, 0);
            returnHandDatabase.Add(CardName.dream, 0);
            returnHandDatabase.Add(CardName.gadgetzanferryman, 0);
            returnHandDatabase.Add(CardName.kidnapper, 0);//if combo
            returnHandDatabase.Add(CardName.recycle, 0);
            returnHandDatabase.Add(CardName.shadowstep, 0);
            returnHandDatabase.Add(CardName.timerewinder, 0);
            returnHandDatabase.Add(CardName.vanish, 0);
            returnHandDatabase.Add(CardName.youthfulbrewmaster, 0);
        }

        private void setupHeroDamagingAOE()
        {
            this.heroDamagingAoeDatabase.Add(CardName.unknown, 0);
        }

        private void setupSpecialMins()
        {
            specialMinions.Add(CardName.aberrantberserker, 0);
            specialMinions.Add(CardName.abomination, 0);
            specialMinions.Add(CardName.acidmaw, 0);
            specialMinions.Add(CardName.acolyteofpain, 0);
            specialMinions.Add(CardName.addledgrizzly, 0);
            specialMinions.Add(CardName.alarmobot, 0);
            specialMinions.Add(CardName.amaniberserker, 0);
            specialMinions.Add(CardName.ancientharbinger, 0);
            specialMinions.Add(CardName.angrychicken, 0);
            specialMinions.Add(CardName.animatedarmor, 0);
            specialMinions.Add(CardName.anubarak, 0);
            specialMinions.Add(CardName.anubarambusher, 0);
            specialMinions.Add(CardName.anubisathsentinel, 0);
            specialMinions.Add(CardName.arcaneanomaly, 0);
            specialMinions.Add(CardName.archmage, 0);
            specialMinions.Add(CardName.archmageantonidas, 0);
            specialMinions.Add(CardName.armorsmith, 0);
            specialMinions.Add(CardName.auchenaisoulpriest, 0);
            specialMinions.Add(CardName.aviana, 0);
            specialMinions.Add(CardName.axeflinger, 0);
            specialMinions.Add(CardName.ayablackpaw, 0);
            specialMinions.Add(CardName.azuredrake, 0);
            specialMinions.Add(CardName.backroombouncer, 0);
            specialMinions.Add(CardName.backstreetleper, 0);
            specialMinions.Add(CardName.barongeddon, 0);
            specialMinions.Add(CardName.baronrivendare, 0);
            specialMinions.Add(CardName.blackwaterpirate, 0);
            specialMinions.Add(CardName.bloodhoofbrave, 0);
            specialMinions.Add(CardName.bloodimp, 0);
            specialMinions.Add(CardName.bloodmagethalnos, 0);
            specialMinions.Add(CardName.bolframshield, 0);
            specialMinions.Add(CardName.boneguardlieutenant, 0);
            specialMinions.Add(CardName.brannbronzebeard, 0);
            specialMinions.Add(CardName.bravearcher, 0);
            specialMinions.Add(CardName.buccaneer, 0);
            specialMinions.Add(CardName.burglybully, 0);
            specialMinions.Add(CardName.burlyrockjawtrogg, 0);
            specialMinions.Add(CardName.cairnebloodhoof, 0);
            specialMinions.Add(CardName.chromaggus, 0);
            specialMinions.Add(CardName.chromaticdragonkin, 0);
            specialMinions.Add(CardName.cloakedhuntress, 0);
            specialMinions.Add(CardName.clockworkgnome, 0);
            specialMinions.Add(CardName.cobaltguardian, 0);
            specialMinions.Add(CardName.cogmaster, 0);
            specialMinions.Add(CardName.coldarradrake, 0);
            specialMinions.Add(CardName.coliseummanager, 0);
            specialMinions.Add(CardName.confessorpaletress, 0);
            specialMinions.Add(CardName.crazedworshipper, 0);
            specialMinions.Add(CardName.crowdfavorite, 0);
            specialMinions.Add(CardName.crueldinomancer, 0);
            specialMinions.Add(CardName.crystallineoracle, 0);
            specialMinions.Add(CardName.cthun, 0);
            specialMinions.Add(CardName.cultmaster, 0);
            specialMinions.Add(CardName.cultsorcerer, 0);
            specialMinions.Add(CardName.cutpurse, 0);
            specialMinions.Add(CardName.dalaranaspirant, 0);
            specialMinions.Add(CardName.dalaranmage, 0);
            specialMinions.Add(CardName.dancingswords, 0);
            specialMinions.Add(CardName.darkcultist, 0);
            specialMinions.Add(CardName.darkshirecouncilman, 0);
            specialMinions.Add(CardName.deadlyfork, 0);
            specialMinions.Add(CardName.deathlord, 0);
            specialMinions.Add(CardName.dementedfrostcaller, 0);
            specialMinions.Add(CardName.demolisher, 0);
            specialMinions.Add(CardName.direhornhatchling, 0);
            specialMinions.Add(CardName.direwolfalpha, 0);
            specialMinions.Add(CardName.djinniofzephyrs, 0);
            specialMinions.Add(CardName.doomsayer, 0);
            specialMinions.Add(CardName.dragonegg, 0);
            specialMinions.Add(CardName.dragonhawkrider, 0);
            specialMinions.Add(CardName.dragonkinsorcerer, 0);
            specialMinions.Add(CardName.dreadscale, 0);
            specialMinions.Add(CardName.dreadsteed, 0);
            specialMinions.Add(CardName.eggnapper, 0);
            specialMinions.Add(CardName.emperorcobra, 0);
            specialMinions.Add(CardName.emperorthaurissan, 0);
            specialMinions.Add(CardName.etherealarcanist, 0);
            specialMinions.Add(CardName.evolvedkobold, 0);
            specialMinions.Add(CardName.explosivesheep, 0);
            specialMinions.Add(CardName.eydisdarkbane, 0);
            specialMinions.Add(CardName.fallenhero, 0);
            specialMinions.Add(CardName.fandralstaghelm, 0);
            specialMinions.Add(CardName.felcannon, 0);
            specialMinions.Add(CardName.feugen, 0);
            specialMinions.Add(CardName.finjatheflyingstar, 0);
            specialMinions.Add(CardName.fjolalightbane, 0);
            specialMinions.Add(CardName.flametonguetotem, 0);
            specialMinions.Add(CardName.flamewaker, 0);
            specialMinions.Add(CardName.flesheatingghoul, 0);
            specialMinions.Add(CardName.floatingwatcher, 0);
            specialMinions.Add(CardName.foereaper4000, 0);
            specialMinions.Add(CardName.gadgetzanauctioneer, 0);
            specialMinions.Add(CardName.gahzrilla, 0);
            specialMinions.Add(CardName.garr, 0);
            specialMinions.Add(CardName.garrisoncommander, 0);
            specialMinions.Add(CardName.gazlowe, 0);
            specialMinions.Add(CardName.genzotheshark, 0);
            specialMinions.Add(CardName.giantanaconda, 0);
            specialMinions.Add(CardName.giantsandworm, 0);
            specialMinions.Add(CardName.giantwasp, 0);
            specialMinions.Add(CardName.goblinsapper, 0);
            specialMinions.Add(CardName.grimestreetenforcer, 0);
            specialMinions.Add(CardName.grimpatron, 0);
            specialMinions.Add(CardName.grimscaleoracle, 0);
            specialMinions.Add(CardName.grimygadgeteer, 0);
            specialMinions.Add(CardName.grommashhellscream, 0);
            specialMinions.Add(CardName.gruul, 0);
            specialMinions.Add(CardName.gurubashiberserker, 0);
            specialMinions.Add(CardName.hallazealtheascended, 0);
            specialMinions.Add(CardName.harvestgolem, 0);
            specialMinions.Add(CardName.hauntedcreeper, 0);
            specialMinions.Add(CardName.hobgoblin, 0);
            specialMinions.Add(CardName.hogger, 0);
            specialMinions.Add(CardName.hoggerdoomofelwynn, 0);
            specialMinions.Add(CardName.holychampion, 0);
            specialMinions.Add(CardName.hoodedacolyte, 0);
            specialMinions.Add(CardName.hugetoad, 0);
            specialMinions.Add(CardName.igneouselemental, 0);
            specialMinions.Add(CardName.illidanstormrage, 0);
            specialMinions.Add(CardName.impgangboss, 0);
            specialMinions.Add(CardName.impmaster, 0);
            specialMinions.Add(CardName.infestedtauren, 0);
            specialMinions.Add(CardName.infestedwolf, 0);
            specialMinions.Add(CardName.ironsensei, 0);
            specialMinions.Add(CardName.jadeswarmer, 0);
            specialMinions.Add(CardName.jeeves, 0);
            specialMinions.Add(CardName.junglemoonkin, 0);
            specialMinions.Add(CardName.junkbot, 0);
            specialMinions.Add(CardName.kabaltrafficker, 0);
            specialMinions.Add(CardName.kelthuzad, 0);
            specialMinions.Add(CardName.kindlygrandmother, 0);
            specialMinions.Add(CardName.knifejuggler, 0);
            specialMinions.Add(CardName.knuckles, 0);
            specialMinions.Add(CardName.koboldgeomancer, 0);
            specialMinions.Add(CardName.kodorider, 0);
            specialMinions.Add(CardName.kvaldirraider, 0);
            specialMinions.Add(CardName.lepergnome, 0);
            specialMinions.Add(CardName.lightspawn, 0);
            specialMinions.Add(CardName.lightwarden, 0);
            specialMinions.Add(CardName.lightwell, 0);
            specialMinions.Add(CardName.loothoarder, 0);
            specialMinions.Add(CardName.lorewalkercho, 0);
            specialMinions.Add(CardName.lotusassassin, 0);
            specialMinions.Add(CardName.lowlysquire, 0);
            specialMinions.Add(CardName.lyrathesunshard, 0);
            specialMinions.Add(CardName.madscientist, 0);
            specialMinions.Add(CardName.maexxna, 0);
            specialMinions.Add(CardName.magnatauralpha, 0);
            specialMinions.Add(CardName.maidenofthelake, 0);
            specialMinions.Add(CardName.majordomoexecutus, 0);
            specialMinions.Add(CardName.malchezaarsimp, 0);
            specialMinions.Add(CardName.malganis, 0);
            specialMinions.Add(CardName.malorne, 0);
            specialMinions.Add(CardName.malygos, 0);
            specialMinions.Add(CardName.manaaddict, 0);
            specialMinions.Add(CardName.manageode, 0);
            specialMinions.Add(CardName.manatidetotem, 0);
            specialMinions.Add(CardName.manatreant, 0);
            specialMinions.Add(CardName.manawraith, 0);
            specialMinions.Add(CardName.manawyrm, 0);
            specialMinions.Add(CardName.masterswordsmith, 0);
            specialMinions.Add(CardName.mechanicalyeti, 0);
            specialMinions.Add(CardName.mechbearcat, 0);
            specialMinions.Add(CardName.mechwarper, 0);
            specialMinions.Add(CardName.mekgineerthermaplugg, 0);
            specialMinions.Add(CardName.micromachine, 0);
            specialMinions.Add(CardName.mimironshead, 0);
            specialMinions.Add(CardName.mistressofpain, 0);
            specialMinions.Add(CardName.moroes, 0);
            specialMinions.Add(CardName.muklaschampion, 0);
            specialMinions.Add(CardName.murlocknight, 0);
            specialMinions.Add(CardName.underbellyangler, 0);
            specialMinions.Add(CardName.murloctidecaller, 0);
            specialMinions.Add(CardName.murlocwarleader, 0);
            specialMinions.Add(CardName.natpagle, 0);
            specialMinions.Add(CardName.nerubarweblord, 0);
            specialMinions.Add(CardName.nexuschampionsaraad, 0);
            specialMinions.Add(CardName.northshirecleric, 0);
            specialMinions.Add(CardName.obsidiandestroyer, 0);
            specialMinions.Add(CardName.ogremagi, 0);
            specialMinions.Add(CardName.oldmurkeye, 0);
            specialMinions.Add(CardName.orgrimmaraspirant, 0);
            specialMinions.Add(CardName.patientassassin, 0);
            specialMinions.Add(CardName.pilotedshredder, 0);
            specialMinions.Add(CardName.pilotedskygolem, 0);
            specialMinions.Add(CardName.pintsizedsummoner, 0);
            specialMinions.Add(CardName.pitsnake, 0);
            specialMinions.Add(CardName.possessedvillager, 0);
            specialMinions.Add(CardName.priestofthefeast, 0);
            specialMinions.Add(CardName.primalfinchampion, 0);
            specialMinions.Add(CardName.primalfintotem, 0);
            specialMinions.Add(CardName.prophetvelen, 0);
            specialMinions.Add(CardName.pyros, 0);
            specialMinions.Add(CardName.questingadventurer, 0);
            specialMinions.Add(CardName.radiantelemental, 0);
            specialMinions.Add(CardName.ragingworgen, 0);
            specialMinions.Add(CardName.ragnaroslightlord, 0);
            specialMinions.Add(CardName.raidleader, 0);
            specialMinions.Add(CardName.raptorhatchling, 0);
            specialMinions.Add(CardName.ratpack, 0);
            specialMinions.Add(CardName.recruiter, 0);
            specialMinions.Add(CardName.redmanawyrm, 0);
            specialMinions.Add(CardName.rumblingelemental, 0);
            specialMinions.Add(CardName.satedthreshadon, 0);
            specialMinions.Add(CardName.savagecombatant, 0);
            specialMinions.Add(CardName.savannahhighmane, 0);
            specialMinions.Add(CardName.scalednightmare, 0);
            specialMinions.Add(CardName.scavenginghyena, 0);
            specialMinions.Add(CardName.secretkeeper, 0);
            specialMinions.Add(CardName.selflesshero, 0);
            specialMinions.Add(CardName.sergeantsally, 0);
            specialMinions.Add(CardName.shadeofnaxxramas, 0);
            specialMinions.Add(CardName.shadowboxer, 0);
            specialMinions.Add(CardName.shadowfiend, 0);
            specialMinions.Add(CardName.shakuthecollector, 0);
            specialMinions.Add(CardName.sherazincorpseflower, 0);
            specialMinions.Add(CardName.shiftingshade, 0);
            specialMinions.Add(CardName.shimmeringtempest, 0);
            specialMinions.Add(CardName.shipscannon, 0);
            specialMinions.Add(CardName.siltfinspiritwalker, 0);
            specialMinions.Add(CardName.silverhandregent, 0);
            specialMinions.Add(CardName.smalltimebuccaneer, 0);
            specialMinions.Add(CardName.sneedsoldshredder, 0);
            specialMinions.Add(CardName.snowchugger, 0);
            specialMinions.Add(CardName.sorcerersapprentice, 0);
            specialMinions.Add(CardName.southseacaptain, 0);
            specialMinions.Add(CardName.southseasquidface, 0);
            specialMinions.Add(CardName.spawnofnzoth, 0);
            specialMinions.Add(CardName.spawnofshadows, 0);
            specialMinions.Add(CardName.spiritsingerumbra, 0);
            specialMinions.Add(CardName.spitefulsmith, 0);
            specialMinions.Add(CardName.stalagg, 0);
            specialMinions.Add(CardName.starvingbuzzard, 0);
            specialMinions.Add(CardName.steamwheedlesniper, 0);
            specialMinions.Add(CardName.stewardofdarkshire, 0);
            specialMinions.Add(CardName.stonesplintertrogg, 0);
            specialMinions.Add(CardName.stormwindchampion, 0);
            specialMinions.Add(CardName.summoningportal, 0);
            specialMinions.Add(CardName.summoningstone, 0);
            specialMinions.Add(CardName.sylvanaswindrunner, 0);
            specialMinions.Add(CardName.tarcreeper, 0);
            specialMinions.Add(CardName.tarlord, 0);
            specialMinions.Add(CardName.tarlurker, 0);
            specialMinions.Add(CardName.taurenwarrior, 0);
            specialMinions.Add(CardName.tentacleofnzoth, 0);
            specialMinions.Add(CardName.thebeast, 0);
            specialMinions.Add(CardName.theboogeymonster, 0);
            specialMinions.Add(CardName.thevoraxx, 0);
            specialMinions.Add(CardName.thunderbluffvaliant, 0);
            specialMinions.Add(CardName.timberwolf, 0);
            specialMinions.Add(CardName.tinyknightofevil, 0);
            specialMinions.Add(CardName.tirionfordring, 0);
            specialMinions.Add(CardName.tortollanshellraiser, 0);
            specialMinions.Add(CardName.toshley, 0);
            specialMinions.Add(CardName.tournamentmedic, 0);
            specialMinions.Add(CardName.tradeprincegallywix, 0);
            specialMinions.Add(CardName.troggzortheearthinator, 0);
            specialMinions.Add(CardName.tundrarhino, 0);
            specialMinions.Add(CardName.tunneltrogg, 0);
            specialMinions.Add(CardName.twilightelder, 0);
            specialMinions.Add(CardName.twilightsummoner, 0);
            specialMinions.Add(CardName.unboundelemental, 0);
            specialMinions.Add(CardName.undercityhuckster, 0);
            specialMinions.Add(CardName.undertaker, 0);
            specialMinions.Add(CardName.unstableghoul, 0);
            specialMinions.Add(CardName.usherofsouls, 0);
            specialMinions.Add(CardName.viciousfledgling, 0);
            specialMinions.Add(CardName.violetillusionist, 0);
            specialMinions.Add(CardName.violetteacher, 0);
            specialMinions.Add(CardName.vitalitytotem, 0);
            specialMinions.Add(CardName.voidcaller, 0);
            specialMinions.Add(CardName.voidcrusher, 0);
            specialMinions.Add(CardName.volatileelemental, 0);
            specialMinions.Add(CardName.warbot, 0);
            specialMinions.Add(CardName.warhorsetrainer, 0);
            specialMinions.Add(CardName.warsongcommander, 0);
            specialMinions.Add(CardName.waterelemental, 0);
            specialMinions.Add(CardName.voodoohexxer, 0);
            specialMinions.Add(CardName.webspinner, 0);
            specialMinions.Add(CardName.whiteeyes, 0);
            specialMinions.Add(CardName.wickedwitchdoctor, 0);
            specialMinions.Add(CardName.wickerflameburnbristle, 0);
            specialMinions.Add(CardName.wilfredfizzlebang, 0);
            specialMinions.Add(CardName.windupburglebot, 0);
            specialMinions.Add(CardName.wobblingrunts, 0);
            specialMinions.Add(CardName.xarilpoisonedmind, 0);
            specialMinions.Add(CardName.ysera, 0);
            specialMinions.Add(CardName.yshaarjrageunbound, 0);
            specialMinions.Add(CardName.zealousinitiate, 0);
            specialMinions.Add(CardName.vryghoul, 0);
            specialMinions.Add(CardName.thelichking, 0);
            specialMinions.Add(CardName.skelemancer, 0);
            specialMinions.Add(CardName.shallowgravedigger, 0);
            specialMinions.Add(CardName.shadowascendant, 0);
            specialMinions.Add(CardName.obsidianstatue, 0);
            specialMinions.Add(CardName.mountainfirearmor, 0);
            specialMinions.Add(CardName.meatwagon, 0);
            specialMinions.Add(CardName.hadronox, 0);
            specialMinions.Add(CardName.festergut, 0);
            specialMinions.Add(CardName.fatespinner, 0);
            specialMinions.Add(CardName.explodingbloatbat, 0);
            specialMinions.Add(CardName.drakkarienchanter, 0);
            specialMinions.Add(CardName.despicabledreadlord, 0);
            specialMinions.Add(CardName.deadscaleknight, 0);
            specialMinions.Add(CardName.cobaltscalebane, 0);
            specialMinions.Add(CardName.chillbladechampion, 0);
            specialMinions.Add(CardName.bonedrake, 0);
            specialMinions.Add(CardName.bonebaron, 0);
            specialMinions.Add(CardName.bloodworm, 0);
            specialMinions.Add(CardName.bloodqueenlanathel, 0);
            specialMinions.Add(CardName.blackguard, 0);
            specialMinions.Add(CardName.arrogantcrusader, 0);
            specialMinions.Add(CardName.arfus, 0);
            specialMinions.Add(CardName.acolyteofagony, 0);
            specialMinions.Add(CardName.abominablebowman, 0);
            specialMinions.Add(CardName.venomancer, 0);
            specialMinions.Add(CardName.valkyrsoulclaimer, 0);
            specialMinions.Add(CardName.stubborngastropod, 0);
            specialMinions.Add(CardName.runeforgehaunter, 0);
            specialMinions.Add(CardName.rotface, 0);
            specialMinions.Add(CardName.professorputricide, 0);
            specialMinions.Add(CardName.nighthowler, 0);
            specialMinions.Add(CardName.nerubianunraveler, 0);
            specialMinions.Add(CardName.necroticgeist, 0);
            specialMinions.Add(CardName.moorabi, 0);
            specialMinions.Add(CardName.mindbreaker, 0);
            specialMinions.Add(CardName.icewalker, 0);
            specialMinions.Add(CardName.graveshambler, 0);
            specialMinions.Add(CardName.doomedapprentice, 0);
            specialMinions.Add(CardName.cryptlord, 0);
            specialMinions.Add(CardName.corpsewidow, 0);
        }

        private void setupOwnSummonFromDeathrattle()
        {
            ownSummonFromDeathrattle.Add(CardName.anubarak, -10);
            ownSummonFromDeathrattle.Add(CardName.ayablackpaw, 1);
            ownSummonFromDeathrattle.Add(CardName.cairnebloodhoof, 5);
            ownSummonFromDeathrattle.Add(CardName.crueldinomancer, 1);
            ownSummonFromDeathrattle.Add(CardName.devilsauregg, -20);
            ownSummonFromDeathrattle.Add(CardName.dreadsteed, -1);
            ownSummonFromDeathrattle.Add(CardName.eggnapper, 1);
            ownSummonFromDeathrattle.Add(CardName.giantanaconda, 1);
            ownSummonFromDeathrattle.Add(CardName.harvestgolem, 1);
            ownSummonFromDeathrattle.Add(CardName.hauntedcreeper, 1);
            ownSummonFromDeathrattle.Add(CardName.infestedtauren, 1);
            ownSummonFromDeathrattle.Add(CardName.infestedwolf, 1);
            ownSummonFromDeathrattle.Add(CardName.jadeswarmer, -1);
            ownSummonFromDeathrattle.Add(CardName.kindlygrandmother, -10);
            ownSummonFromDeathrattle.Add(CardName.moirabronzebeard, 3);
            ownSummonFromDeathrattle.Add(CardName.mountedraptor, 3);
            ownSummonFromDeathrattle.Add(CardName.nerubianegg, -16);
            ownSummonFromDeathrattle.Add(CardName.pilotedshredder, 4);
            ownSummonFromDeathrattle.Add(CardName.pilotedskygolem, 4);
            ownSummonFromDeathrattle.Add(CardName.possessedvillager, 1);
            ownSummonFromDeathrattle.Add(CardName.ratpack, 1);
            ownSummonFromDeathrattle.Add(CardName.satedthreshadon, 1);
            ownSummonFromDeathrattle.Add(CardName.savannahhighmane, 8);
            ownSummonFromDeathrattle.Add(CardName.sludgebelcher, 10);
            ownSummonFromDeathrattle.Add(CardName.sneedsoldshredder, 5);
            ownSummonFromDeathrattle.Add(CardName.twilightsummoner, -14);
            ownSummonFromDeathrattle.Add(CardName.whiteeyes, -10);
            ownSummonFromDeathrattle.Add(CardName.wobblingrunts, 1);
            ownSummonFromDeathrattle.Add(CardName.frozenchampion, -12);
        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(CardName.abusivesergeant, 0);
            buffingMinionsDatabase.Add(CardName.beckonerofevil, 10);
            buffingMinionsDatabase.Add(CardName.bladeofcthun, 10);
            buffingMinionsDatabase.Add(CardName.bloodsailcultist, 5);
            buffingMinionsDatabase.Add(CardName.captaingreenskin, 5);
            buffingMinionsDatabase.Add(CardName.cenarius, 0);
            buffingMinionsDatabase.Add(CardName.clockworkknight, 2);
            buffingMinionsDatabase.Add(CardName.coldlightseer, 3);
            buffingMinionsDatabase.Add(CardName.crueltaskmaster, 0);
            buffingMinionsDatabase.Add(CardName.cthunschosen, 10);
            buffingMinionsDatabase.Add(CardName.cultsorcerer, 10);
            buffingMinionsDatabase.Add(CardName.darkarakkoa, 10);
            buffingMinionsDatabase.Add(CardName.darkirondwarf, 0);
            buffingMinionsDatabase.Add(CardName.defenderofargus, 0);
            buffingMinionsDatabase.Add(CardName.direwolfalpha, 0);
            buffingMinionsDatabase.Add(CardName.discipleofcthun, 10);
            buffingMinionsDatabase.Add(CardName.doomcaller, 10);
            buffingMinionsDatabase.Add(CardName.flametonguetotem, 0);
            buffingMinionsDatabase.Add(CardName.goblinautobarber, 5);
            buffingMinionsDatabase.Add(CardName.grimscaleoracle, 3);
            buffingMinionsDatabase.Add(CardName.hoodedacolyte, 10);
            buffingMinionsDatabase.Add(CardName.houndmaster, 1);
            buffingMinionsDatabase.Add(CardName.lancecarrier, 0);
            buffingMinionsDatabase.Add(CardName.leokk, 0);
            buffingMinionsDatabase.Add(CardName.malganis, 8);
            buffingMinionsDatabase.Add(CardName.metaltoothleaper, 2);
            buffingMinionsDatabase.Add(CardName.murlocwarleader, 3);
            buffingMinionsDatabase.Add(CardName.quartermaster, 6);
            buffingMinionsDatabase.Add(CardName.raidleader, 0);
            buffingMinionsDatabase.Add(CardName.screwjankclunker, 2);
            buffingMinionsDatabase.Add(CardName.shatteredsuncleric, 0);
            buffingMinionsDatabase.Add(CardName.skeramcultist, 10);
            buffingMinionsDatabase.Add(CardName.southseacaptain, 4);
            buffingMinionsDatabase.Add(CardName.spitefulsmith, 5);
            buffingMinionsDatabase.Add(CardName.stormwindchampion, 0);
            buffingMinionsDatabase.Add(CardName.templeenforcer, 0);
            buffingMinionsDatabase.Add(CardName.thunderbluffvaliant, 9);
            buffingMinionsDatabase.Add(CardName.timberwolf, 1);
            buffingMinionsDatabase.Add(CardName.upgradedrepairbot, 2);
            buffingMinionsDatabase.Add(CardName.usherofsouls, 10);
            buffingMinionsDatabase.Add(CardName.warhorsetrainer, 6);
            buffingMinionsDatabase.Add(CardName.warsongcommander, 7);
            buffingMinionsDatabase.Add(CardName.worshipper, 0);

            buffing1TurnDatabase.Add(CardName.abusivesergeant, 0);
            buffing1TurnDatabase.Add(CardName.bloodlust, 3);
            buffing1TurnDatabase.Add(CardName.darkirondwarf, 0);
            buffing1TurnDatabase.Add(CardName.rockbiterweapon, 0);
            buffing1TurnDatabase.Add(CardName.worshipper, 0);
        }

        private void setupEnemyTargetPriority()
        {
            priorityTargets.Add(CardName.acidmaw, 10);
            priorityTargets.Add(CardName.acolyteofpain, 10);
            priorityTargets.Add(CardName.addledgrizzly, 10);
            priorityTargets.Add(CardName.alarmobot, 10);
            priorityTargets.Add(CardName.angrychicken, 10);
            priorityTargets.Add(CardName.animatedarmor, 10);
            priorityTargets.Add(CardName.anubarak, 10);
            priorityTargets.Add(CardName.anubisathsentinel, 10);
            priorityTargets.Add(CardName.archmageantonidas, 10);
            priorityTargets.Add(CardName.auchenaisoulpriest, 10);
            priorityTargets.Add(CardName.auctionmasterbeardo, 10);
            priorityTargets.Add(CardName.aviana, 10);
            priorityTargets.Add(CardName.ayablackpaw, 10);
            priorityTargets.Add(CardName.backroombouncer, 10);
            priorityTargets.Add(CardName.barongeddon, 10);
            priorityTargets.Add(CardName.baronrivendare, 10);
            priorityTargets.Add(CardName.bloodmagethalnos, 10);
            priorityTargets.Add(CardName.boneguardlieutenant, 10);
            priorityTargets.Add(CardName.brannbronzebeard, 10);
            priorityTargets.Add(CardName.burglybully, 10);
            priorityTargets.Add(CardName.chromaggus, 10);
            priorityTargets.Add(CardName.cloakedhuntress, 10);
            priorityTargets.Add(CardName.coldarradrake, 10);
            priorityTargets.Add(CardName.confessorpaletress, 10);
            priorityTargets.Add(CardName.crowdfavorite, 10);
            priorityTargets.Add(CardName.crueldinomancer, 10);
            priorityTargets.Add(CardName.crystallineoracle, 10);
            priorityTargets.Add(CardName.cthun, 10);
            priorityTargets.Add(CardName.cultmaster, 10);
            priorityTargets.Add(CardName.cultsorcerer, 10);
            priorityTargets.Add(CardName.dalaranaspirant, 10);
            priorityTargets.Add(CardName.daringreporter, 10);
            priorityTargets.Add(CardName.darkshirecouncilman, 10);
            priorityTargets.Add(CardName.dementedfrostcaller, 10);
            priorityTargets.Add(CardName.demolisher, 10);
            priorityTargets.Add(CardName.devilsauregg, 10);
            priorityTargets.Add(CardName.nerubianegg, 10);
            priorityTargets.Add(CardName.direhornhatchling, 10);
            priorityTargets.Add(CardName.direwolfalpha, 10);
            priorityTargets.Add(CardName.djinniofzephyrs, 10);
            priorityTargets.Add(CardName.doomsayer, 10);
            priorityTargets.Add(CardName.dragonegg, 0);
            priorityTargets.Add(CardName.dragonhawkrider, 10);
            priorityTargets.Add(CardName.dragonkinsorcerer, 4);
            priorityTargets.Add(CardName.dreadscale, 10);
            priorityTargets.Add(CardName.dustdevil, 10);
            priorityTargets.Add(CardName.eggnapper, 10);
            priorityTargets.Add(CardName.emperorthaurissan, 10);
            priorityTargets.Add(CardName.etherealarcanist, 10);
            priorityTargets.Add(CardName.eydisdarkbane, 10);
            priorityTargets.Add(CardName.fallenhero, 10);
            priorityTargets.Add(CardName.masterchest, 10);
            priorityTargets.Add(CardName.fandralstaghelm, 10);
            priorityTargets.Add(CardName.finjatheflyingstar, 10);
            priorityTargets.Add(CardName.flametonguetotem, 10);
            priorityTargets.Add(CardName.flamewaker, 10);
            priorityTargets.Add(CardName.flesheatingghoul, 10);
            priorityTargets.Add(CardName.floatingwatcher, 10);
            priorityTargets.Add(CardName.foereaper4000, 10);
            priorityTargets.Add(CardName.friendlybartender, 10);
            priorityTargets.Add(CardName.frothingberserker, 10);
            priorityTargets.Add(CardName.gadgetzanauctioneer, 10);
            priorityTargets.Add(CardName.gahzrilla, 10);
            priorityTargets.Add(CardName.garr, 10);
            priorityTargets.Add(CardName.garrisoncommander, 10);
            priorityTargets.Add(CardName.genzotheshark, 10);
            priorityTargets.Add(CardName.giantanaconda, 10);
            priorityTargets.Add(CardName.giantsandworm, 10);
            priorityTargets.Add(CardName.grimestreetenforcer, 10);
            priorityTargets.Add(CardName.grimpatron, 10);
            priorityTargets.Add(CardName.grimygadgeteer, 10);
            priorityTargets.Add(CardName.gurubashiberserker, 10);
            priorityTargets.Add(CardName.hobgoblin, 10);
            priorityTargets.Add(CardName.hogger, 10);
            priorityTargets.Add(CardName.hoggerdoomofelwynn, 10);
            priorityTargets.Add(CardName.holychampion, 10);
            priorityTargets.Add(CardName.hoodedacolyte, 10);
            priorityTargets.Add(CardName.igneouselemental, 10);
            priorityTargets.Add(CardName.illidanstormrage, 10);
            priorityTargets.Add(CardName.impgangboss, 10);
            priorityTargets.Add(CardName.impmaster, 10);
            priorityTargets.Add(CardName.ironsensei, 10);
            priorityTargets.Add(CardName.junglemoonkin, 10);
            priorityTargets.Add(CardName.kabaltrafficker, 10);
            priorityTargets.Add(CardName.kelthuzad, 10);
            priorityTargets.Add(CardName.knifejuggler, 10);
            priorityTargets.Add(CardName.knuckles, 10);
            priorityTargets.Add(CardName.koboldgeomancer, 10);
            priorityTargets.Add(CardName.kodorider, 10);
            priorityTargets.Add(CardName.kvaldirraider, 10);
            priorityTargets.Add(CardName.leeroyjenkins, 10);
            priorityTargets.Add(CardName.leokk, 10);
            priorityTargets.Add(CardName.lightwarden, 10);
            priorityTargets.Add(CardName.lightwell, 10);
            priorityTargets.Add(CardName.lowlysquire, 10);
            priorityTargets.Add(CardName.lyrathesunshard, 10);
            priorityTargets.Add(CardName.maexxna, 10);
            priorityTargets.Add(CardName.maidenofthelake, 10);
            priorityTargets.Add(CardName.malchezaarsimp, 10);
            priorityTargets.Add(CardName.malganis, 10);
            priorityTargets.Add(CardName.malygos, 10);
            priorityTargets.Add(CardName.manaaddict, 10);
            priorityTargets.Add(CardName.manatidetotem, 10);
            priorityTargets.Add(CardName.manatreant, 10);
            priorityTargets.Add(CardName.manawyrm, 10);
            priorityTargets.Add(CardName.masterswordsmith, 10);
            priorityTargets.Add(CardName.mechwarper, 10);
            priorityTargets.Add(CardName.micromachine, 10);
            priorityTargets.Add(CardName.mogortheogre, 10);
            priorityTargets.Add(CardName.moroes, 10);
            priorityTargets.Add(CardName.muklaschampion, 10);
            priorityTargets.Add(CardName.underbellyangler, 10);
            priorityTargets.Add(CardName.murlocknight, 10);
            priorityTargets.Add(CardName.natpagle, 10);
            priorityTargets.Add(CardName.nerubarweblord, 10);
            priorityTargets.Add(CardName.nexuschampionsaraad, 10);
            priorityTargets.Add(CardName.northshirecleric, 10);
            priorityTargets.Add(CardName.obsidiandestroyer, 10);
            priorityTargets.Add(CardName.orgrimmaraspirant, 10);
            priorityTargets.Add(CardName.pintsizedsummoner, 10);
            priorityTargets.Add(CardName.priestofthefeast, 10);
            priorityTargets.Add(CardName.primalfintotem, 10);
            priorityTargets.Add(CardName.prophetvelen, 10);
            priorityTargets.Add(CardName.pyros, 10);
            priorityTargets.Add(CardName.questingadventurer, 10);
            priorityTargets.Add(CardName.radiantelemental, 10);
            priorityTargets.Add(CardName.ragnaroslightlord, 10);
            priorityTargets.Add(CardName.raidleader, 10);
            priorityTargets.Add(CardName.raptorhatchling, 10);
            priorityTargets.Add(CardName.recruiter, 10);
            priorityTargets.Add(CardName.redmanawyrm, 10);
            priorityTargets.Add(CardName.rhonin, 10);
            priorityTargets.Add(CardName.rumblingelemental, 10);
            priorityTargets.Add(CardName.satedthreshadon, 10);
            priorityTargets.Add(CardName.savagecombatant, 10);
            priorityTargets.Add(CardName.scalednightmare, 10);
            priorityTargets.Add(CardName.scavenginghyena, 10);
            priorityTargets.Add(CardName.secretkeeper, 10);
            priorityTargets.Add(CardName.shadeofnaxxramas, 10);
            priorityTargets.Add(CardName.shakuthecollector, 10);
            priorityTargets.Add(CardName.sherazincorpseflower, 10);
            priorityTargets.Add(CardName.shimmeringtempest, 10);
            priorityTargets.Add(CardName.silverhandregent, 10);
            priorityTargets.Add(CardName.sorcerersapprentice, 10);
            priorityTargets.Add(CardName.spiritsingerumbra, 10);
            priorityTargets.Add(CardName.starvingbuzzard, 10);
            priorityTargets.Add(CardName.steamwheedlesniper, 10);
            priorityTargets.Add(CardName.stormwindchampion, 10);
            priorityTargets.Add(CardName.summoningportal, 10);
            priorityTargets.Add(CardName.summoningstone, 10);
            priorityTargets.Add(CardName.theboogeymonster, 10);
            priorityTargets.Add(CardName.thevoraxx, 10);
            priorityTargets.Add(CardName.thrallmarfarseer, 10);
            priorityTargets.Add(CardName.thunderbluffvaliant, 10);
            priorityTargets.Add(CardName.timberwolf, 10);
            priorityTargets.Add(CardName.troggzortheearthinator, 10);
            priorityTargets.Add(CardName.tundrarhino, 10);
            priorityTargets.Add(CardName.tunneltrogg, 10);
            priorityTargets.Add(CardName.twilightsummoner, 10);
            priorityTargets.Add(CardName.unboundelemental, 10);
            priorityTargets.Add(CardName.undertaker, 10);
            priorityTargets.Add(CardName.viciousfledgling, 10);
            priorityTargets.Add(CardName.violetillusionist, 10);
            priorityTargets.Add(CardName.violetteacher, 10);
            priorityTargets.Add(CardName.vitalitytotem, 10);
            priorityTargets.Add(CardName.warhorsetrainer, 10);
            priorityTargets.Add(CardName.warsongcommander, 10);
            priorityTargets.Add(CardName.whiteeyes, 10);
            priorityTargets.Add(CardName.wickedwitchdoctor, 10);
            priorityTargets.Add(CardName.wildpyromancer, 10);
            priorityTargets.Add(CardName.wilfredfizzlebang, 10);
            priorityTargets.Add(CardName.windupburglebot, 10);
            priorityTargets.Add(CardName.youngdragonhawk, 10);
            priorityTargets.Add(CardName.yshaarjrageunbound, 10);
            priorityTargets.Add(CardName.thelichking, 10);
            priorityTargets.Add(CardName.obsidianstatue, 10);
            priorityTargets.Add(CardName.moirabronzebeard, 10);
            priorityTargets.Add(CardName.highjusticegrimstone, 10);
            priorityTargets.Add(CardName.hadronox, 10);
            priorityTargets.Add(CardName.festergut, 10);
            priorityTargets.Add(CardName.despicabledreadlord, 10);
            priorityTargets.Add(CardName.rotface, 10);
            priorityTargets.Add(CardName.professorputricide, 10);
            priorityTargets.Add(CardName.nighthowler, 10);
            priorityTargets.Add(CardName.necroticgeist, 10);
            priorityTargets.Add(CardName.moorabi, 10);
            priorityTargets.Add(CardName.icewalker, 10);
            priorityTargets.Add(CardName.cryptlord, 10);
            priorityTargets.Add(CardName.corpsewidow, 10);
        }

        private void setupLethalHelpMinions()
        {
            //spellpower minions
            lethalHelpers.Add(CardName.ancientmage, 0);
            lethalHelpers.Add(CardName.arcanotron, 0);
            lethalHelpers.Add(CardName.archmage, 0);
            lethalHelpers.Add(CardName.auchenaisoulpriest, 0);
            lethalHelpers.Add(CardName.azuredrake, 0);
            lethalHelpers.Add(CardName.bloodmagethalnos, 0);
            lethalHelpers.Add(CardName.cultsorcerer, 0);
            lethalHelpers.Add(CardName.dalaranaspirant, 0);
            lethalHelpers.Add(CardName.dalaranmage, 0);
            lethalHelpers.Add(CardName.evolvedkobold, 0);
            lethalHelpers.Add(CardName.frigidsnobold, 0);
            lethalHelpers.Add(CardName.junglemoonkin, 0);
            lethalHelpers.Add(CardName.koboldgeomancer, 0);
            lethalHelpers.Add(CardName.malygos, 0);
            lethalHelpers.Add(CardName.minimage, 0);
            lethalHelpers.Add(CardName.ogremagi, 0);
            lethalHelpers.Add(CardName.prophetvelen, 0);
            lethalHelpers.Add(CardName.sootspewer, 0);
            lethalHelpers.Add(CardName.streettrickster, 0);
            lethalHelpers.Add(CardName.wrathofairtotem, 0);
            lethalHelpers.Add(CardName.tuskarrfisherman, 0);
            lethalHelpers.Add(CardName.taintedzealot, 1);
            lethalHelpers.Add(CardName.spellweaver, 2);
        }

        private void setupRelations()
        {
            spellDependentDatabase.Add(CardName.arcaneanomaly, 1);
            spellDependentDatabase.Add(CardName.archmageantonidas, 2);
            spellDependentDatabase.Add(CardName.burglybully, -1);
            spellDependentDatabase.Add(CardName.burlyrockjawtrogg, -1);
            spellDependentDatabase.Add(CardName.chromaticdragonkin, -1);
            spellDependentDatabase.Add(CardName.cultsorcerer, 1);
            spellDependentDatabase.Add(CardName.dementedfrostcaller, 1);
            spellDependentDatabase.Add(CardName.djinniofzephyrs, 1);
            spellDependentDatabase.Add(CardName.flamewaker, 1);
            spellDependentDatabase.Add(CardName.gadgetzanauctioneer, 2);
            spellDependentDatabase.Add(CardName.gazlowe, 2);
            spellDependentDatabase.Add(CardName.hallazealtheascended, 1);
            spellDependentDatabase.Add(CardName.lorewalkercho, 0);
            spellDependentDatabase.Add(CardName.lyrathesunshard, 2);
            spellDependentDatabase.Add(CardName.manaaddict, 1);
            spellDependentDatabase.Add(CardName.manawyrm, 1);
            spellDependentDatabase.Add(CardName.priestofthefeast, 1);
            spellDependentDatabase.Add(CardName.redmanawyrm, 1);
            spellDependentDatabase.Add(CardName.stonesplintertrogg, -1);
            spellDependentDatabase.Add(CardName.summoningstone, 3);
            spellDependentDatabase.Add(CardName.tradeprincegallywix, -1);
            spellDependentDatabase.Add(CardName.troggzortheearthinator, -2);
            spellDependentDatabase.Add(CardName.violetteacher, 3);
            spellDependentDatabase.Add(CardName.wickedwitchdoctor, 3);
            spellDependentDatabase.Add(CardName.wildpyromancer, 1);

            dragonDependentDatabase.Add(CardName.alexstraszaschampion, 1);
            dragonDependentDatabase.Add(CardName.blackwingcorruptor, 1);
            dragonDependentDatabase.Add(CardName.blackwingtechnician, 1);
            dragonDependentDatabase.Add(CardName.bookwyrm, 1);
            dragonDependentDatabase.Add(CardName.drakonidoperative, 1);
            dragonDependentDatabase.Add(CardName.netherspitehistorian, 1);
            dragonDependentDatabase.Add(CardName.nightbanetemplar, 1);
            dragonDependentDatabase.Add(CardName.rendblackhand, 1);
            dragonDependentDatabase.Add(CardName.twilightguardian, 1);
            dragonDependentDatabase.Add(CardName.twilightwhelp, 1);
            dragonDependentDatabase.Add(CardName.wyrmrestagent, 1);

            elementalLTDependentDatabase.Add(CardName.blazecaller, 1);
            elementalLTDependentDatabase.Add(CardName.kalimosprimallord, 1);
            elementalLTDependentDatabase.Add(CardName.ozruk, 1);
            elementalLTDependentDatabase.Add(CardName.servantofkalimos, 1);
            elementalLTDependentDatabase.Add(CardName.steamsurger, 1);
            elementalLTDependentDatabase.Add(CardName.stonesentinel, 1);
            elementalLTDependentDatabase.Add(CardName.thunderlizard, 1);
            elementalLTDependentDatabase.Add(CardName.tolvirstoneshaper, 1);
        }

        private void setupSilenceTargets()
        {
            silenceTargets.Add(CardName.abomination, 0);
            silenceTargets.Add(CardName.acidmaw, 0);
            silenceTargets.Add(CardName.acolyteofpain, 0);
            silenceTargets.Add(CardName.addledgrizzly, 0);
            silenceTargets.Add(CardName.ancientharbinger, 0);
            silenceTargets.Add(CardName.animatedarmor, 0);
            silenceTargets.Add(CardName.anomalus, 0);
            silenceTargets.Add(CardName.anubarak, 0);
            silenceTargets.Add(CardName.anubisathsentinel, 0);
            silenceTargets.Add(CardName.archmageantonidas, 0);
            silenceTargets.Add(CardName.armorsmith, 0);
            silenceTargets.Add(CardName.auchenaisoulpriest, 0);
            silenceTargets.Add(CardName.aviana, 0);
            silenceTargets.Add(CardName.axeflinger, 0);
            silenceTargets.Add(CardName.ayablackpaw, 0);
            silenceTargets.Add(CardName.backroombouncer, 0);
            silenceTargets.Add(CardName.barongeddon, 0);
            silenceTargets.Add(CardName.baronrivendare, 0);
            silenceTargets.Add(CardName.blackwaterpirate, 0);
            silenceTargets.Add(CardName.bloodimp, 0);
            silenceTargets.Add(CardName.blubberbaron, 0);
            silenceTargets.Add(CardName.bolvarfordragon, 0);
            silenceTargets.Add(CardName.boneguardlieutenant, 0);
            silenceTargets.Add(CardName.brannbronzebeard, 0);
            silenceTargets.Add(CardName.bravearcher, 0);
            silenceTargets.Add(CardName.burlyrockjawtrogg, 0);
            silenceTargets.Add(CardName.cairnebloodhoof, 0);
            silenceTargets.Add(CardName.chillmaw, 0);
            silenceTargets.Add(CardName.chromaggus, 0);
            silenceTargets.Add(CardName.cobaltguardian, 0);
            silenceTargets.Add(CardName.coldarradrake, 0);
            silenceTargets.Add(CardName.coliseummanager, 0);
            silenceTargets.Add(CardName.confessorpaletress, 0);
            silenceTargets.Add(CardName.crazedworshipper, 0);
            silenceTargets.Add(CardName.crowdfavorite, 0);
            silenceTargets.Add(CardName.crueldinomancer, 0);
            silenceTargets.Add(CardName.crystallineoracle, 0);
            silenceTargets.Add(CardName.cthun, 0);
            silenceTargets.Add(CardName.cultmaster, 0);
            silenceTargets.Add(CardName.cultsorcerer, 0);
            silenceTargets.Add(CardName.dalaranaspirant, 0);
            silenceTargets.Add(CardName.darkcultist, 0);
            silenceTargets.Add(CardName.darkshirecouncilman, 0);
            silenceTargets.Add(CardName.dementedfrostcaller, 0);
            silenceTargets.Add(CardName.devilsauregg, 0);
            silenceTargets.Add(CardName.nerubianegg, 0);
            silenceTargets.Add(CardName.direhornhatchling, 0);
            silenceTargets.Add(CardName.direwolfalpha, 0);
            silenceTargets.Add(CardName.djinniofzephyrs, 0);
            silenceTargets.Add(CardName.doomsayer, 0);
            silenceTargets.Add(CardName.dragonegg, 0);
            silenceTargets.Add(CardName.dragonhawkrider, 0);
            silenceTargets.Add(CardName.dragonkinsorcerer, 0);
            silenceTargets.Add(CardName.dreadscale, 0);
            silenceTargets.Add(CardName.eggnapper, 0);
            silenceTargets.Add(CardName.emboldener3000, 0);
            silenceTargets.Add(CardName.emperorcobra, 0);
            silenceTargets.Add(CardName.emperorthaurissan, 0);
            silenceTargets.Add(CardName.etherealarcanist, 0);
            silenceTargets.Add(CardName.evolvedkobold, 0);
            silenceTargets.Add(CardName.explosivesheep, 0);
            silenceTargets.Add(CardName.eydisdarkbane, 0);
            silenceTargets.Add(CardName.fallenhero, 0);
            silenceTargets.Add(CardName.masterchest, 0);            
            silenceTargets.Add(CardName.fandralstaghelm, 0);
            silenceTargets.Add(CardName.feugen, 0);
            silenceTargets.Add(CardName.finjatheflyingstar, 0);
            silenceTargets.Add(CardName.fjolalightbane, 0);
            silenceTargets.Add(CardName.flametonguetotem, 0);
            silenceTargets.Add(CardName.flamewaker, 0);
            silenceTargets.Add(CardName.flesheatingghoul, 0);
            silenceTargets.Add(CardName.floatingwatcher, 0);
            silenceTargets.Add(CardName.foereaper4000, 0);
            silenceTargets.Add(CardName.frothingberserker, 0);
            silenceTargets.Add(CardName.gadgetzanauctioneer, 10);
            silenceTargets.Add(CardName.gahzrilla, 0);
            silenceTargets.Add(CardName.garr, 0);
            silenceTargets.Add(CardName.garrisoncommander, 0);
            silenceTargets.Add(CardName.giantanaconda, 0);
            silenceTargets.Add(CardName.giantsandworm, 0);
            silenceTargets.Add(CardName.giantwasp, 0);
            silenceTargets.Add(CardName.grimestreetenforcer, 0);
            silenceTargets.Add(CardName.grimpatron, 0);
            silenceTargets.Add(CardName.grimscaleoracle, 0);
            silenceTargets.Add(CardName.grimygadgeteer, 0);
            silenceTargets.Add(CardName.grommashhellscream, 0);
            silenceTargets.Add(CardName.gruul, 0);
            silenceTargets.Add(CardName.gurubashiberserker, 0);
            silenceTargets.Add(CardName.hallazealtheascended, 0);
            silenceTargets.Add(CardName.hauntedcreeper, 0);
            silenceTargets.Add(CardName.hobgoblin, 0);
            silenceTargets.Add(CardName.hogger, 0);
            silenceTargets.Add(CardName.hoggerdoomofelwynn, 0);
            silenceTargets.Add(CardName.holychampion, 0);
            silenceTargets.Add(CardName.homingchicken, 0);
            silenceTargets.Add(CardName.hoodedacolyte, 0);
            silenceTargets.Add(CardName.igneouselemental, 0);
            silenceTargets.Add(CardName.illidanstormrage, 0);
            silenceTargets.Add(CardName.impgangboss, 0);
            silenceTargets.Add(CardName.impmaster, 0);
            silenceTargets.Add(CardName.ironsensei, 0);
            silenceTargets.Add(CardName.jadeswarmer, 0);
            silenceTargets.Add(CardName.jeeves, 0);
            silenceTargets.Add(CardName.junkbot, 0);
            silenceTargets.Add(CardName.kabaltrafficker, 0);
            silenceTargets.Add(CardName.kelthuzad, 10);
            silenceTargets.Add(CardName.kindlygrandmother, 0);
            silenceTargets.Add(CardName.knifejuggler, 0);
            silenceTargets.Add(CardName.knuckles, 0);
            silenceTargets.Add(CardName.kodorider, 0);
            silenceTargets.Add(CardName.kvaldirraider, 0);
            silenceTargets.Add(CardName.leokk, 0);
            silenceTargets.Add(CardName.lightspawn, 0);
            silenceTargets.Add(CardName.lightwarden, 0);
            silenceTargets.Add(CardName.lightwell, 0);
            silenceTargets.Add(CardName.lorewalkercho, 0);
            silenceTargets.Add(CardName.lowlysquire, 0);
            silenceTargets.Add(CardName.lyrathesunshard, 0);
            silenceTargets.Add(CardName.madscientist, 0);
            silenceTargets.Add(CardName.maexxna, 0);
            silenceTargets.Add(CardName.magnatauralpha, 0);
            silenceTargets.Add(CardName.maidenofthelake, 0);
            silenceTargets.Add(CardName.majordomoexecutus, 0);
            silenceTargets.Add(CardName.malganis, 0);
            silenceTargets.Add(CardName.malorne, 0);
            silenceTargets.Add(CardName.malygos, 0);
            silenceTargets.Add(CardName.manaaddict, 0);
            silenceTargets.Add(CardName.manageode, 0);
            silenceTargets.Add(CardName.manatidetotem, 0);
            silenceTargets.Add(CardName.manatreant, 0);
            silenceTargets.Add(CardName.manawraith, 0);
            silenceTargets.Add(CardName.manawyrm, 0);
            silenceTargets.Add(CardName.masterswordsmith, 0);
            silenceTargets.Add(CardName.mekgineerthermaplugg, 0);
            silenceTargets.Add(CardName.micromachine, 0);
            silenceTargets.Add(CardName.mogortheogre, 0);
            silenceTargets.Add(CardName.muklaschampion, 0);
            silenceTargets.Add(CardName.murlocknight, 0);
            silenceTargets.Add(CardName.underbellyangler, 0);
            silenceTargets.Add(CardName.murloctidecaller, 0);
            silenceTargets.Add(CardName.murlocwarleader, 0);
            silenceTargets.Add(CardName.natpagle, 0);
            silenceTargets.Add(CardName.nerubarweblord, 0);
            silenceTargets.Add(CardName.nexuschampionsaraad, 0);
            silenceTargets.Add(CardName.northshirecleric, 0);
            silenceTargets.Add(CardName.obsidiandestroyer, 0);
            silenceTargets.Add(CardName.oldmurkeye, 0);
            silenceTargets.Add(CardName.oneeyedcheat, 0);
            silenceTargets.Add(CardName.orgrimmaraspirant, 0);
            silenceTargets.Add(CardName.pilotedskygolem, 0);
            silenceTargets.Add(CardName.pitsnake, 0);
            silenceTargets.Add(CardName.primalfinchampion, 0);
            silenceTargets.Add(CardName.primalfintotem, 0);
            silenceTargets.Add(CardName.prophetvelen, 0);
            silenceTargets.Add(CardName.pyros, 0);
            silenceTargets.Add(CardName.questingadventurer, 0);
            silenceTargets.Add(CardName.radiantelemental, 0);
            silenceTargets.Add(CardName.ragingworgen, 0);
            silenceTargets.Add(CardName.raidleader, 0);
            silenceTargets.Add(CardName.raptorhatchling, 0);
            silenceTargets.Add(CardName.ratpack, 0);
            silenceTargets.Add(CardName.recruiter, 0);
            silenceTargets.Add(CardName.redmanawyrm, 0);
            silenceTargets.Add(CardName.rhonin, 0);
            silenceTargets.Add(CardName.rumblingelemental, 0);
            silenceTargets.Add(CardName.satedthreshadon, 0);
            silenceTargets.Add(CardName.savagecombatant, 0);
            silenceTargets.Add(CardName.savannahhighmane, 0);
            silenceTargets.Add(CardName.scalednightmare, 0);
            silenceTargets.Add(CardName.scavenginghyena, 0);
            silenceTargets.Add(CardName.secretkeeper, 0);
            silenceTargets.Add(CardName.selflesshero, 0);
            silenceTargets.Add(CardName.sergeantsally, 0);
            silenceTargets.Add(CardName.shadeofnaxxramas, 0);
            silenceTargets.Add(CardName.shadowboxer, 0);
            silenceTargets.Add(CardName.shakuthecollector, 0);
            silenceTargets.Add(CardName.sherazincorpseflower, 0);
            silenceTargets.Add(CardName.shiftingshade, 0);
            silenceTargets.Add(CardName.shimmeringtempest, 0);
            silenceTargets.Add(CardName.shipscannon, 0);
            silenceTargets.Add(CardName.siegeengine, 0);
            silenceTargets.Add(CardName.siltfinspiritwalker, 0);
            silenceTargets.Add(CardName.silverhandregent, 0);
            silenceTargets.Add(CardName.sneedsoldshredder, 0);
            silenceTargets.Add(CardName.sorcerersapprentice, 0);
            silenceTargets.Add(CardName.southseacaptain, 0);
            silenceTargets.Add(CardName.southseasquidface, 0);
            silenceTargets.Add(CardName.spawnofnzoth, 0);
            silenceTargets.Add(CardName.spawnofshadows, 0);
            silenceTargets.Add(CardName.spiritsingerumbra, 0);
            silenceTargets.Add(CardName.spitefulsmith, 0);
            silenceTargets.Add(CardName.stalagg, 0);
            silenceTargets.Add(CardName.starvingbuzzard, 0);
            silenceTargets.Add(CardName.steamwheedlesniper, 0);
            silenceTargets.Add(CardName.stewardofdarkshire, 0);
            silenceTargets.Add(CardName.stonesplintertrogg, 0);
            silenceTargets.Add(CardName.stormwindchampion, 0);
            silenceTargets.Add(CardName.summoningportal, 0);
            silenceTargets.Add(CardName.summoningstone, 0);
            silenceTargets.Add(CardName.sylvanaswindrunner, 0);
            silenceTargets.Add(CardName.tarcreeper, 0);
            silenceTargets.Add(CardName.tarlord, 0);
            silenceTargets.Add(CardName.tarlurker, 0);
            silenceTargets.Add(CardName.theboogeymonster, 0);
            silenceTargets.Add(CardName.theskeletonknight, 0);
            silenceTargets.Add(CardName.thevoraxx, 0);
            silenceTargets.Add(CardName.thunderbluffvaliant, 0);
            silenceTargets.Add(CardName.timberwolf, 0);
            silenceTargets.Add(CardName.tirionfordring, 0);
            silenceTargets.Add(CardName.tortollanshellraiser, 0);
            silenceTargets.Add(CardName.tournamentmedic, 0);
            silenceTargets.Add(CardName.tradeprincegallywix, 0);
            silenceTargets.Add(CardName.troggzortheearthinator, 0);
            silenceTargets.Add(CardName.tundrarhino, 0);
            silenceTargets.Add(CardName.twilightelder, 0);
            silenceTargets.Add(CardName.twilightsummoner, 0);
            silenceTargets.Add(CardName.unboundelemental, 0);
            silenceTargets.Add(CardName.undercityhuckster, 0);
            silenceTargets.Add(CardName.undertaker, 0);
            silenceTargets.Add(CardName.usherofsouls, 0);
            silenceTargets.Add(CardName.v07tr0n, 0);
            silenceTargets.Add(CardName.viciousfledgling, 0);
            silenceTargets.Add(CardName.violetillusionist, 0);
            silenceTargets.Add(CardName.violetteacher, 0);
            silenceTargets.Add(CardName.vitalitytotem, 0);
            silenceTargets.Add(CardName.voidcrusher, 0);
            silenceTargets.Add(CardName.volatileelemental, 0);
            silenceTargets.Add(CardName.warhorsetrainer, 0);
            silenceTargets.Add(CardName.warsongcommander, 0);
            silenceTargets.Add(CardName.webspinner, 0);
            silenceTargets.Add(CardName.whiteeyes, 0);
            silenceTargets.Add(CardName.wickedwitchdoctor, 0);
            silenceTargets.Add(CardName.wilfredfizzlebang, 0);
            silenceTargets.Add(CardName.windupburglebot, 0);
            silenceTargets.Add(CardName.wobblingrunts, 0);
            silenceTargets.Add(CardName.youngpriestess, 0);
            silenceTargets.Add(CardName.ysera, 0);
            silenceTargets.Add(CardName.yshaarjrageunbound, 0);
            silenceTargets.Add(CardName.zealousinitiate, 0);
            silenceTargets.Add(CardName.vryghoul, 0);
            silenceTargets.Add(CardName.thelichking, 0);
            silenceTargets.Add(CardName.skelemancer, 0);
            silenceTargets.Add(CardName.shallowgravedigger, 0);
            silenceTargets.Add(CardName.shadowascendant, 0);
            silenceTargets.Add(CardName.moirabronzebeard, 0);
            silenceTargets.Add(CardName.meatwagon, 0);
            silenceTargets.Add(CardName.highjusticegrimstone, 0);
            silenceTargets.Add(CardName.hadronox, 0);
            silenceTargets.Add(CardName.frozenchampion, 0);
            silenceTargets.Add(CardName.festergut, 0);
            silenceTargets.Add(CardName.fatespinner, 0);
            silenceTargets.Add(CardName.explodingbloatbat, 0);
            silenceTargets.Add(CardName.drakkarienchanter, 0);
            silenceTargets.Add(CardName.despicabledreadlord, 0);
            silenceTargets.Add(CardName.cobaltscalebane, 0);
            silenceTargets.Add(CardName.bonedrake, 0);
            silenceTargets.Add(CardName.bonebaron, 0);
            silenceTargets.Add(CardName.blackguard, 0);
            silenceTargets.Add(CardName.arrogantcrusader, 0);
            silenceTargets.Add(CardName.arfus, 0);
            silenceTargets.Add(CardName.abominablebowman, 0);
            silenceTargets.Add(CardName.voodoohexxer, 0);
            silenceTargets.Add(CardName.venomancer, 0);
            silenceTargets.Add(CardName.valkyrsoulclaimer, 0);
            silenceTargets.Add(CardName.stubborngastropod, 0);
            silenceTargets.Add(CardName.runeforgehaunter, 0);
            silenceTargets.Add(CardName.rotface, 0);
            silenceTargets.Add(CardName.professorputricide, 0);
            silenceTargets.Add(CardName.nighthowler, 0);
            silenceTargets.Add(CardName.nerubianunraveler, 0);
            silenceTargets.Add(CardName.necroticgeist, 0);
            silenceTargets.Add(CardName.moorabi, 0);
            silenceTargets.Add(CardName.icewalker, 0);
            silenceTargets.Add(CardName.doomedapprentice, 0);
            silenceTargets.Add(CardName.cryptlord, 0);
            silenceTargets.Add(CardName.corpsewidow, 0);
            silenceTargets.Add(CardName.bolvarfireblood, 0);
            silenceTargets.Add(CardName.bloodqueenlanathel, 0);
        }

        private void setupRandomCards()
        {
            randomEffects.Add(CardName.alightinthedarkness, 1);
            randomEffects.Add(CardName.ancestorscall, 1);
            randomEffects.Add(CardName.animalcompanion, 1);
            randomEffects.Add(CardName.arcanemissiles, 3);
            randomEffects.Add(CardName.archthiefrafaam, 1);
            randomEffects.Add(CardName.armoredwarhorse, 1);
            randomEffects.Add(CardName.avengingwrath, 8);
            randomEffects.Add(CardName.babblingbook, 1);
            randomEffects.Add(CardName.barnes, 1);
            randomEffects.Add(CardName.bomblobber, 1);
            randomEffects.Add(CardName.bouncingblade, 3);
            randomEffects.Add(CardName.brawl, 1);
            randomEffects.Add(CardName.captainsparrot, 1);
            randomEffects.Add(CardName.chitteringtunneler, 1);
            randomEffects.Add(CardName.chooseyourpath, 1);
            randomEffects.Add(CardName.cleave, 2);
            randomEffects.Add(CardName.coghammer, 1);
            randomEffects.Add(CardName.crackle, 1);
            randomEffects.Add(CardName.cthun, 10);
            randomEffects.Add(CardName.darkbargain, 2);
            randomEffects.Add(CardName.darkpeddler, 1);
            randomEffects.Add(CardName.deadlyshot, 1);
            randomEffects.Add(CardName.desertcamel, 1);
            randomEffects.Add(CardName.elementaldestruction, 1);
            randomEffects.Add(CardName.elitetaurenchieftain, 1);
            randomEffects.Add(CardName.enhanceomechano, 1);
            randomEffects.Add(CardName.etherealconjurer, 1);
            randomEffects.Add(CardName.fierybat, 1);
            randomEffects.Add(CardName.finderskeepers, 1);
            randomEffects.Add(CardName.firelandsportal, 1);
            randomEffects.Add(CardName.flamecannon, 1);
            randomEffects.Add(CardName.flamejuggler, 1);
            randomEffects.Add(CardName.flamewaker, 2);
            randomEffects.Add(CardName.forkedlightning, 1);
            randomEffects.Add(CardName.freefromamber, 1);
            randomEffects.Add(CardName.zarogscrown, 1);
            randomEffects.Add(CardName.gelbinmekkatorque, 1);
            randomEffects.Add(CardName.glaivezooka, 1);
            randomEffects.Add(CardName.grandcrusader, 1);
            randomEffects.Add(CardName.greaterarcanemissiles, 3);
            randomEffects.Add(CardName.grimestreetinformant, 1);
            randomEffects.Add(CardName.hallucination, 1);
            randomEffects.Add(CardName.harvest, 1);
            randomEffects.Add(CardName.hungrydragon, 1);
            randomEffects.Add(CardName.hydrologist, 1);
            randomEffects.Add(CardName.iammurloc, 3);
            randomEffects.Add(CardName.iknowaguy, 1);
            randomEffects.Add(CardName.ironforgeportal, 1);
            randomEffects.Add(CardName.ivoryknight, 1);
            randomEffects.Add(CardName.jeweledscarab, 1);
            randomEffects.Add(CardName.journeybelow, 1);
            randomEffects.Add(CardName.kabalchemist, 1);
            randomEffects.Add(CardName.kabalcourier, 1);
            randomEffects.Add(CardName.kazakus, 1);
            randomEffects.Add(CardName.kingsblood, 1);
            randomEffects.Add(CardName.lifetap, 1);
            randomEffects.Add(CardName.lightningstorm, 1);
            randomEffects.Add(CardName.lockandload, 10);
            randomEffects.Add(CardName.lotusagents, 1);
            randomEffects.Add(CardName.madbomber, 3);
            randomEffects.Add(CardName.madderbomber, 1);
            randomEffects.Add(CardName.maelstromportal, 1);
            randomEffects.Add(CardName.masterjouster, 1);
            randomEffects.Add(CardName.menageriemagician, 0);
            randomEffects.Add(CardName.mindcontroltech, 1);
            randomEffects.Add(CardName.mindgames, 1);
            randomEffects.Add(CardName.mindvision, 1);
            randomEffects.Add(CardName.mogorschampion, 1);
            randomEffects.Add(CardName.mogortheogre, 1);
            randomEffects.Add(CardName.moongladeportal, 1);
            randomEffects.Add(CardName.multishot, 2);
            randomEffects.Add(CardName.museumcurator, 1);
            randomEffects.Add(CardName.mysteriouschallenger, 2);
            randomEffects.Add(CardName.pileon, 1);
            randomEffects.Add(CardName.powerofthehorde, 1);
            randomEffects.Add(CardName.primordialglyph, 1);
            randomEffects.Add(CardName.ramwrangler, 1);
            randomEffects.Add(CardName.ravenidol, 1);
            randomEffects.Add(CardName.resurrect, 1);
            randomEffects.Add(CardName.sabotage, 0);
            randomEffects.Add(CardName.sensedemons, 2);
            randomEffects.Add(CardName.servantofkalimos, 1);
            randomEffects.Add(CardName.shadowoil, 1);
            randomEffects.Add(CardName.shadowvisions, 1);
            randomEffects.Add(CardName.silvermoonportal, 1);
            randomEffects.Add(CardName.sirfinleymrrgglton, 1);
            randomEffects.Add(CardName.soultap, 1);
            randomEffects.Add(CardName.spellslinger, 1);
            randomEffects.Add(CardName.spreadingmadness, 9);
            randomEffects.Add(CardName.stampede, 10);
            randomEffects.Add(CardName.stonehilldefender, 1);
            randomEffects.Add(CardName.swashburglar, 1);
            randomEffects.Add(CardName.timepieceofhorror, 10);
            randomEffects.Add(CardName.tinkmasteroverspark, 1);
            randomEffects.Add(CardName.tombspider, 1);
            randomEffects.Add(CardName.tortollanprimalist, 1);
            randomEffects.Add(CardName.totemiccall, 1);
            randomEffects.Add(CardName.tuskarrtotemic, 1);
            randomEffects.Add(CardName.unholyshadow, 2);
            randomEffects.Add(CardName.unstableportal, 1);
            randomEffects.Add(CardName.varianwrynn, 2);
            randomEffects.Add(CardName.volcano, 15);
            randomEffects.Add(CardName.xarilpoisonedmind, 1);
            randomEffects.Add(CardName.zoobot, 0);
            randomEffects.Add(CardName.tomblurker, 1);
            randomEffects.Add(CardName.ghastlyconjurer, 1);
            randomEffects.Add(CardName.shadowessence, 1);

        }


        private void setupChooseDatabase()
        {
            this.choose1database.Add(CardName.ancientoflore, CardIdEnum.NEW1_008a);
            this.choose1database.Add(CardName.ancientofwar, CardIdEnum.EX1_178b);
            this.choose1database.Add(CardName.anodizedrobocub, CardIdEnum.GVG_030a);
            this.choose1database.Add(CardName.cenarius, CardIdEnum.EX1_573a);
            this.choose1database.Add(CardName.darkwispers, CardIdEnum.GVG_041b);
            this.choose1database.Add(CardName.druidoftheclaw, CardIdEnum.EX1_165t1);
            this.choose1database.Add(CardName.druidoftheflame, CardIdEnum.BRM_010t);
            this.choose1database.Add(CardName.druidofthesaber, CardIdEnum.AT_042t);
            this.choose1database.Add(CardName.feralrage, CardIdEnum.OG_047a);
            this.choose1database.Add(CardName.grovetender, CardIdEnum.GVG_032a);
            this.choose1database.Add(CardName.jadeidol, CardIdEnum.CFM_602a);
            this.choose1database.Add(CardName.keeperofthegrove, CardIdEnum.EX1_166a);
            this.choose1database.Add(CardName.kuntheforgottenking, CardIdEnum.CFM_308a);
            this.choose1database.Add(CardName.livingroots, CardIdEnum.AT_037a);
            this.choose1database.Add(CardName.markofnature, CardIdEnum.EX1_155a);
            this.choose1database.Add(CardName.mirekeeper, CardIdEnum.OG_202a);
            this.choose1database.Add(CardName.nourish, CardIdEnum.EX1_164a);
            this.choose1database.Add(CardName.powerofthewild, CardIdEnum.EX1_160b);
            this.choose1database.Add(CardName.ravenidol, CardIdEnum.LOE_115a);
            this.choose1database.Add(CardName.shellshifter, CardIdEnum.UNG_101t);
            this.choose1database.Add(CardName.starfall, CardIdEnum.NEW1_007b);
            this.choose1database.Add(CardName.wispsoftheoldgods, CardIdEnum.OG_195a);
            this.choose1database.Add(CardName.wrath, CardIdEnum.EX1_154a);
            this.choose1database.Add(CardName.malfurionthepestilent, CardIdEnum.ICC_832b);
            this.choose1database.Add(CardName.plaguelord, CardIdEnum.ICC_832pb);
            this.choose1database.Add(CardName.druidoftheswarm, CardIdEnum.ICC_051t);

            this.choose2database.Add(CardName.ancientoflore, CardIdEnum.NEW1_008b);
            this.choose2database.Add(CardName.ancientofwar, CardIdEnum.EX1_178a);
            this.choose2database.Add(CardName.anodizedrobocub, CardIdEnum.GVG_030b);
            this.choose2database.Add(CardName.cenarius, CardIdEnum.EX1_573b);
            this.choose2database.Add(CardName.darkwispers, CardIdEnum.GVG_041a);
            this.choose2database.Add(CardName.druidoftheclaw, CardIdEnum.EX1_165t2);
            this.choose2database.Add(CardName.druidoftheflame, CardIdEnum.BRM_010t2);
            this.choose2database.Add(CardName.druidofthesaber, CardIdEnum.AT_042t2);
            this.choose2database.Add(CardName.feralrage, CardIdEnum.OG_047b);
            this.choose2database.Add(CardName.grovetender, CardIdEnum.GVG_032b);
            this.choose2database.Add(CardName.jadeidol, CardIdEnum.CFM_602b);
            this.choose2database.Add(CardName.keeperofthegrove, CardIdEnum.EX1_166b);
            this.choose2database.Add(CardName.kuntheforgottenking, CardIdEnum.CFM_308b);
            this.choose2database.Add(CardName.livingroots, CardIdEnum.AT_037b);
            this.choose2database.Add(CardName.markofnature, CardIdEnum.EX1_155b);
            this.choose2database.Add(CardName.mirekeeper, CardIdEnum.OG_202ae);
            this.choose2database.Add(CardName.nourish, CardIdEnum.EX1_164b);
            this.choose2database.Add(CardName.powerofthewild, CardIdEnum.EX1_160t);
            this.choose2database.Add(CardName.ravenidol, CardIdEnum.LOE_115b);
            this.choose2database.Add(CardName.shellshifter, CardIdEnum.UNG_101t2);
            this.choose2database.Add(CardName.starfall, CardIdEnum.NEW1_007a);
            this.choose2database.Add(CardName.wispsoftheoldgods, CardIdEnum.OG_195b);
            this.choose2database.Add(CardName.wrath, CardIdEnum.EX1_154b);
            this.choose2database.Add(CardName.malfurionthepestilent, CardIdEnum.ICC_832a);
            this.choose2database.Add(CardName.plaguelord, CardIdEnum.ICC_832pa);
            this.choose2database.Add(CardName.druidoftheswarm, CardIdEnum.ICC_051t2);
        }


        public int getClassRacePriorityPenality(TAG_CLASS opponentHeroClass, TAG_RACE minionRace)
        {
            int retval = 0;
            switch (opponentHeroClass)
            {
                case TAG_CLASS.WARLOCK:
                    if (this.ClassRacePriorityWarloc.ContainsKey(minionRace)) retval += this.ClassRacePriorityWarloc[minionRace];
                    break;
                case TAG_CLASS.WARRIOR:
                    if (this.ClassRacePriorityWarrior.ContainsKey(minionRace)) retval += this.ClassRacePriorityWarrior[minionRace];
					break;
                case TAG_CLASS.ROGUE:
                    if (this.ClassRacePriorityRouge.ContainsKey(minionRace)) retval += this.ClassRacePriorityRouge[minionRace];
					break;
                case TAG_CLASS.SHAMAN:
                    if (this.ClassRacePriorityShaman.ContainsKey(minionRace)) retval += this.ClassRacePriorityShaman[minionRace];
					break;
                case TAG_CLASS.PRIEST:
                    if (this.ClassRacePriorityPriest.ContainsKey(minionRace)) retval += this.ClassRacePriorityPriest[minionRace];
					break;
                case TAG_CLASS.PALADIN:
                    if (this.ClassRacePriorityPaladin.ContainsKey(minionRace)) retval += this.ClassRacePriorityPaladin[minionRace];
					break;
                case TAG_CLASS.MAGE:
                    if (this.ClassRacePriorityMage.ContainsKey(minionRace)) retval += this.ClassRacePriorityMage[minionRace];
					break;
                case TAG_CLASS.HUNTER:
                    if (this.ClassRacePriorityHunter.ContainsKey(minionRace)) retval += this.ClassRacePriorityHunter[minionRace];
					break;
                case TAG_CLASS.DRUID:
                    if (this.ClassRacePriorityDruid.ContainsKey(minionRace)) retval += this.ClassRacePriorityDruid[minionRace];
                    break;
                default:
                    break;
			}
            return retval;
        }

        private void setupClassRacePriorityDatabase()
        {
            this.ClassRacePriorityWarloc.Add(TAG_RACE.MURLOC, 2);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.DEMON, 2);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityWarloc.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityHunter.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityHunter.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityHunter.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityHunter.Add(TAG_RACE.PET, 2);
            this.ClassRacePriorityHunter.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityMage.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityMage.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityMage.Add(TAG_RACE.MECHANICAL, 2);
            this.ClassRacePriorityMage.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityMage.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityShaman.Add(TAG_RACE.MURLOC, 2);
            this.ClassRacePriorityShaman.Add(TAG_RACE.PIRATE, 1);
            this.ClassRacePriorityShaman.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityShaman.Add(TAG_RACE.MECHANICAL, 2);
            this.ClassRacePriorityShaman.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityShaman.Add(TAG_RACE.TOTEM, 2);

            this.ClassRacePriorityDruid.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityDruid.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityDruid.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityDruid.Add(TAG_RACE.PET, 1);
            this.ClassRacePriorityDruid.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityPaladin.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.PIRATE, 1);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityPaladin.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityPriest.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityPriest.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityPriest.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityPriest.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityPriest.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityRouge.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityRouge.Add(TAG_RACE.PIRATE, 2);
            this.ClassRacePriorityRouge.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityRouge.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityRouge.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityRouge.Add(TAG_RACE.TOTEM, 0);

            this.ClassRacePriorityWarrior.Add(TAG_RACE.MURLOC, 1);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.DEMON, 0);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.MECHANICAL, 1);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.PET, 0);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.TOTEM, 0);
            this.ClassRacePriorityWarrior.Add(TAG_RACE.PIRATE, 2);
        }

        private void setupGangUpDatabase()
        {
            GangUpDatabase.Add(CardName.addledgrizzly, 1);
            GangUpDatabase.Add(CardName.alakirthewindlord, 5);
            GangUpDatabase.Add(CardName.aldorpeacekeeper, 5);
            GangUpDatabase.Add(CardName.ancientoflore, 5);
            GangUpDatabase.Add(CardName.ancientofwar, 5);
            GangUpDatabase.Add(CardName.antiquehealbot, 5);
            GangUpDatabase.Add(CardName.anubarak, 5);
            GangUpDatabase.Add(CardName.archmageantonidas, 3);
            GangUpDatabase.Add(CardName.armorsmith, 0);
            GangUpDatabase.Add(CardName.ayablackpaw, 5);
            GangUpDatabase.Add(CardName.azuredrake, 5);
            GangUpDatabase.Add(CardName.baronrivendare, 1);
            GangUpDatabase.Add(CardName.biggamehunter, 5);
            GangUpDatabase.Add(CardName.biteweed, 5);
            GangUpDatabase.Add(CardName.bladeofcthun, 5);
            GangUpDatabase.Add(CardName.bloodimp, 1);
            GangUpDatabase.Add(CardName.bomblobber, 4);
            GangUpDatabase.Add(CardName.boneguardlieutenant, 3);
            GangUpDatabase.Add(CardName.burglybully, 0);
            GangUpDatabase.Add(CardName.burlyrockjawtrogg, 1);
            GangUpDatabase.Add(CardName.cabalshadowpriest, 5);
            GangUpDatabase.Add(CardName.cairnebloodhoof, 5);
            GangUpDatabase.Add(CardName.cenarius, 5);
            GangUpDatabase.Add(CardName.chromaggus, 4);
            GangUpDatabase.Add(CardName.cobaltguardian, 1);
            GangUpDatabase.Add(CardName.coldarradrake, 1);
            GangUpDatabase.Add(CardName.coldlightoracle, 5);
            GangUpDatabase.Add(CardName.confessorpaletress, 5);
            GangUpDatabase.Add(CardName.corendirebrew, 5);
            GangUpDatabase.Add(CardName.cthun, 5);
            GangUpDatabase.Add(CardName.cultapothecary, 1);
            GangUpDatabase.Add(CardName.cultmaster, 1);
            GangUpDatabase.Add(CardName.cultsorcerer, 5);
            GangUpDatabase.Add(CardName.dementedfrostcaller, 5);
            GangUpDatabase.Add(CardName.demolisher, 1);
            GangUpDatabase.Add(CardName.direwolfalpha, 1);
            GangUpDatabase.Add(CardName.doppelgangster, 1);
            GangUpDatabase.Add(CardName.dragonkinsorcerer, 0);
            GangUpDatabase.Add(CardName.drboom, 5);
            GangUpDatabase.Add(CardName.earthenringfarseer, 3);
            GangUpDatabase.Add(CardName.edwinvancleef, 5);
            GangUpDatabase.Add(CardName.emboldener3000, 1);
            GangUpDatabase.Add(CardName.emperorthaurissan, 5);
            GangUpDatabase.Add(CardName.etherealpeddler, 3);
            GangUpDatabase.Add(CardName.felcannon, 0);
            GangUpDatabase.Add(CardName.fireelemental, 5);
            GangUpDatabase.Add(CardName.fireguarddestroyer, 4);
            GangUpDatabase.Add(CardName.flametonguetotem, 4);
            GangUpDatabase.Add(CardName.flamewaker, 4);
            GangUpDatabase.Add(CardName.flesheatingghoul, 0);
            GangUpDatabase.Add(CardName.floatingwatcher, 0);
            GangUpDatabase.Add(CardName.foereaper4000, 1);
            GangUpDatabase.Add(CardName.friendlybartender, 3);
            GangUpDatabase.Add(CardName.frothingberserker, 1);
            GangUpDatabase.Add(CardName.gadgetzanauctioneer, 1);
            GangUpDatabase.Add(CardName.gahzrilla, 5);
            GangUpDatabase.Add(CardName.garr, 5);
            GangUpDatabase.Add(CardName.gazlowe, 1);
            GangUpDatabase.Add(CardName.gelbinmekkatorque, 3);
            GangUpDatabase.Add(CardName.genzotheshark, 5);
            GangUpDatabase.Add(CardName.grimestreetenforcer, 3);
            GangUpDatabase.Add(CardName.grimscaleoracle, 1);
            GangUpDatabase.Add(CardName.grimygadgeteer, 3);
            GangUpDatabase.Add(CardName.gruul, 4);
            GangUpDatabase.Add(CardName.harrisonjones, 1);
            GangUpDatabase.Add(CardName.hemetnesingwary, 1);
            GangUpDatabase.Add(CardName.highjusticegrimstone, 5);
            GangUpDatabase.Add(CardName.hobgoblin, 1);
            GangUpDatabase.Add(CardName.hogger, 5);
            GangUpDatabase.Add(CardName.hoggerdoomofelwynn, 1);
            GangUpDatabase.Add(CardName.igneouselemental, 1);
            GangUpDatabase.Add(CardName.illidanstormrage, 5);
            GangUpDatabase.Add(CardName.impmaster, 0);
            GangUpDatabase.Add(CardName.infestedtauren, 1);
            GangUpDatabase.Add(CardName.ironbeakowl, 4);
            GangUpDatabase.Add(CardName.ironjuggernaut, 2);
            GangUpDatabase.Add(CardName.ironsensei, 1);
            GangUpDatabase.Add(CardName.jadeswarmer, 5);
            GangUpDatabase.Add(CardName.jeeves, 0);
            GangUpDatabase.Add(CardName.junkbot, 1);
            GangUpDatabase.Add(CardName.kelthuzad, 5);
            GangUpDatabase.Add(CardName.kingkrush, 5);
            GangUpDatabase.Add(CardName.knifejuggler, 3);
            GangUpDatabase.Add(CardName.kodorider, 5);
            GangUpDatabase.Add(CardName.leeroyjenkins, 3);
            GangUpDatabase.Add(CardName.leokk, 3);
            GangUpDatabase.Add(CardName.lightwarden, 0);
            GangUpDatabase.Add(CardName.lightwell, 1);
            GangUpDatabase.Add(CardName.loatheb, 5);
            GangUpDatabase.Add(CardName.lucifron, 5);
            GangUpDatabase.Add(CardName.lyrathesunshard, 1);
            GangUpDatabase.Add(CardName.maexxna, 3);
            GangUpDatabase.Add(CardName.malganis, 4);
            GangUpDatabase.Add(CardName.malkorok, 2);
            GangUpDatabase.Add(CardName.malorne, 1);
            GangUpDatabase.Add(CardName.malygos, 1);
            GangUpDatabase.Add(CardName.manatidetotem, 0);
            GangUpDatabase.Add(CardName.manawyrm, 0);
            GangUpDatabase.Add(CardName.masterswordsmith, 1);
            GangUpDatabase.Add(CardName.mechwarper, 1);
            GangUpDatabase.Add(CardName.medivhtheguardian, 2);
            GangUpDatabase.Add(CardName.mekgineerthermaplugg, 4);
            GangUpDatabase.Add(CardName.micromachine, 1);
            GangUpDatabase.Add(CardName.misha, 5);
            GangUpDatabase.Add(CardName.moatlurker, 4);
            GangUpDatabase.Add(CardName.moirabronzebeard, 5);
            GangUpDatabase.Add(CardName.murlocknight, 5);
            GangUpDatabase.Add(CardName.underbellyangler, 5);
            GangUpDatabase.Add(CardName.murloctidecaller, 1);
            GangUpDatabase.Add(CardName.murlocwarleader, 1);
            GangUpDatabase.Add(CardName.nefarian, 5);
            GangUpDatabase.Add(CardName.nexuschampionsaraad, 5);
            GangUpDatabase.Add(CardName.northshirecleric, 0);
            GangUpDatabase.Add(CardName.obsidiandestroyer, 5);
            GangUpDatabase.Add(CardName.oldmurkeye, 5);
            GangUpDatabase.Add(CardName.onyxia, 4);
            GangUpDatabase.Add(CardName.pilotedshredder, 3);
            GangUpDatabase.Add(CardName.pintsizedsummoner, 1);
            GangUpDatabase.Add(CardName.prophetvelen, 1);
            GangUpDatabase.Add(CardName.pyros, 1);
            GangUpDatabase.Add(CardName.questingadventurer, 1);
            GangUpDatabase.Add(CardName.radiantelemental, 1);
            GangUpDatabase.Add(CardName.ragnaroslightlord, 3);
            GangUpDatabase.Add(CardName.ragnarosthefirelord, 5);
            GangUpDatabase.Add(CardName.raidleader, 2);
            GangUpDatabase.Add(CardName.ratpack, 2);
            GangUpDatabase.Add(CardName.razorgore, 5);
            GangUpDatabase.Add(CardName.recruiter, 5);
            GangUpDatabase.Add(CardName.repairbot, 1);
            GangUpDatabase.Add(CardName.satedthreshadon, 1);
            GangUpDatabase.Add(CardName.savagecombatant, 5);
            GangUpDatabase.Add(CardName.savannahhighmane, 5);
            GangUpDatabase.Add(CardName.scalednightmare, 3);
            GangUpDatabase.Add(CardName.scavenginghyena, 0);
            GangUpDatabase.Add(CardName.shadeofnaxxramas, 3);
            GangUpDatabase.Add(CardName.shadopanrider, 5);
            GangUpDatabase.Add(CardName.shadowboxer, 0);
            GangUpDatabase.Add(CardName.shadowfiend, 1);
            GangUpDatabase.Add(CardName.shakuthecollector, 5);
            GangUpDatabase.Add(CardName.shipscannon, 0);
            GangUpDatabase.Add(CardName.siltfinspiritwalker, 0);
            GangUpDatabase.Add(CardName.sludgebelcher, 5);
            GangUpDatabase.Add(CardName.sneedsoldshredder, 5);
            GangUpDatabase.Add(CardName.sorcerersapprentice, 1);
            GangUpDatabase.Add(CardName.southseacaptain, 0);
            GangUpDatabase.Add(CardName.starvingbuzzard, 0);
            GangUpDatabase.Add(CardName.stonesplintertrogg, 0);
            GangUpDatabase.Add(CardName.stormwindchampion, 4);
            GangUpDatabase.Add(CardName.summoningportal, 5);
            GangUpDatabase.Add(CardName.summoningstone, 5);
            GangUpDatabase.Add(CardName.swashburglar, 2);
            GangUpDatabase.Add(CardName.sylvanaswindrunner, 5);
            GangUpDatabase.Add(CardName.theblackknight, 5);
            GangUpDatabase.Add(CardName.theboogeymonster, 3);
            GangUpDatabase.Add(CardName.timberwolf, 0);
            GangUpDatabase.Add(CardName.tirionfordring, 5);
            GangUpDatabase.Add(CardName.toshley, 4);
            GangUpDatabase.Add(CardName.tradeprincegallywix, 3);
            GangUpDatabase.Add(CardName.troggzortheearthinator, 1);
            GangUpDatabase.Add(CardName.undercityhuckster, 2);
            GangUpDatabase.Add(CardName.undertaker, 0);
            GangUpDatabase.Add(CardName.unearthedraptor, 5);
            GangUpDatabase.Add(CardName.usherofsouls, 1);
            GangUpDatabase.Add(CardName.v07tr0n, 5);
            GangUpDatabase.Add(CardName.vaelastrasz, 5);
            GangUpDatabase.Add(CardName.viciousfledgling, 2);
            GangUpDatabase.Add(CardName.violetillusionist, 5);
            GangUpDatabase.Add(CardName.violetteacher, 0);
            GangUpDatabase.Add(CardName.vitalitytotem, 1);
            GangUpDatabase.Add(CardName.voljin, 5);
            GangUpDatabase.Add(CardName.warsongcommander, 3);
            GangUpDatabase.Add(CardName.weespellstopper, 0);
            GangUpDatabase.Add(CardName.wickedwitchdoctor, 5);
            GangUpDatabase.Add(CardName.wobblingrunts, 3);
            GangUpDatabase.Add(CardName.xarilpoisonedmind, 3);
            GangUpDatabase.Add(CardName.youngpriestess, 1);
            GangUpDatabase.Add(CardName.ysera, 5);
            GangUpDatabase.Add(CardName.yshaarjrageunbound, 5);
            GangUpDatabase.Add(CardName.valkyrsoulclaimer, 0);
            GangUpDatabase.Add(CardName.cryptlord, 4);
        }

        private void setupbuffHandDatabase()
        {
            buffHandDatabase.Add(CardName.brassknuckles, 1);
            buffHandDatabase.Add(CardName.donhancho, 5);
            buffHandDatabase.Add(CardName.grimestreetenforcer, 1);
            buffHandDatabase.Add(CardName.grimestreetoutfitter, 1);
            buffHandDatabase.Add(CardName.grimestreetpawnbroker, 1);
            buffHandDatabase.Add(CardName.grimestreetsmuggler, 1);
            buffHandDatabase.Add(CardName.grimscalechum, 1);
            buffHandDatabase.Add(CardName.grimygadgeteer, 2);
            buffHandDatabase.Add(CardName.hiddencache, 2);
            buffHandDatabase.Add(CardName.hobartgrapplehammer, 1);
            buffHandDatabase.Add(CardName.shakyzipgunner, 2);
            buffHandDatabase.Add(CardName.smugglerscrate, 2);
            buffHandDatabase.Add(CardName.smugglersrun, 1);
            buffHandDatabase.Add(CardName.stolengoods, 3);
            buffHandDatabase.Add(CardName.themistcaller, 1);
            buffHandDatabase.Add(CardName.troggbeastrager, 1);
        }

        private void setupequipWeaponPlayDatabase()
        {
            equipWeaponPlayDatabase.Add(CardName.arathiweaponsmith, 2);
            equipWeaponPlayDatabase.Add(CardName.blingtron3000, 3);
            equipWeaponPlayDatabase.Add(CardName.daggermastery, 1);
            equipWeaponPlayDatabase.Add(CardName.echolocate, 2);
            equipWeaponPlayDatabase.Add(CardName.instructorrazuvious, 5);
            equipWeaponPlayDatabase.Add(CardName.malkorok, 3);
            equipWeaponPlayDatabase.Add(CardName.medivhtheguardian, 1);
            equipWeaponPlayDatabase.Add(CardName.musterforbattle, 1);
            equipWeaponPlayDatabase.Add(CardName.nzothsfirstmate, 1);
            equipWeaponPlayDatabase.Add(CardName.poisoneddaggers, 2);
            equipWeaponPlayDatabase.Add(CardName.upgrade, 1);
            equipWeaponPlayDatabase.Add(CardName.visionsoftheassassin, 1);
            equipWeaponPlayDatabase.Add(CardName.utheroftheebonblade, 5);
            equipWeaponPlayDatabase.Add(CardName.scourgelordgarrosh, 4);
        }


    }

}