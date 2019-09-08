namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public class PenaltyManager
    {
        //todo acolyteofpain
        //todo better aoe-penality

        public Dictionary<CardDB.CardName, int> HealTargetDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> HealHeroDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> HealAllDatabase = new Dictionary<CardDB.CardName, int>();


        Dictionary<CardDB.CardName, int> DamageAllDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> DamageHeroDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> DamageRandomDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> DamageAllEnemysDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> HeroPowerEquipWeapon = new Dictionary<CardDB.CardName, int>();

        Dictionary<CardDB.CardName, int> enrageDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> silenceDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> OwnNeedSilenceDatabase = new Dictionary<CardDB.CardName, int>();

        Dictionary<CardDB.CardName, int> heroAttackBuffDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> attackBuffDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> healthBuffDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> tauntBuffDatabase = new Dictionary<CardDB.CardName, int>();

        Dictionary<CardDB.CardName, int> lethalHelpers = new Dictionary<CardDB.CardName, int>();
        
        Dictionary<CardDB.CardName, int> spellDependentDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> dragonDependentDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> elementalLTDependentDatabase = new Dictionary<CardDB.CardName, int>();

        public Dictionary<CardDB.CardName, int> cardDiscardDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> destroyOwnDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> destroyDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> buffingMinionsDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> buffing1TurnDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> heroDamagingAoeDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> randomEffects = new Dictionary<CardDB.CardName, int>();

        Dictionary<CardDB.CardName, int> silenceTargets = new Dictionary<CardDB.CardName, int>();

        Dictionary<CardDB.CardName, int> returnHandDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> GangUpDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> buffHandDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> equipWeaponPlayDatabase = new Dictionary<CardDB.CardName, int>(); 

        Dictionary<CardDB.CardName, int> priorityDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, int> UsefulNeedKeepDatabase = new Dictionary<CardDB.CardName, int>();
        Dictionary<CardDB.CardName, CardDB.CardIdEnum> choose1database = new Dictionary<CardDB.CardName, CardDB.CardIdEnum>();
        Dictionary<CardDB.CardName, CardDB.CardIdEnum> choose2database = new Dictionary<CardDB.CardName, CardDB.CardIdEnum>();

        public Dictionary<CardDB.CardName, int> DamageTargetDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> DamageTargetSpecialDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> maycauseharmDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> cardDrawBattleCryDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> cardDrawDeathrattleDatabase = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> priorityTargets = new Dictionary<CardDB.CardName, int>();
        public Dictionary<CardDB.CardName, int> specialMinions = new Dictionary<CardDB.CardName, int>(); //minions with cardtext, but no battlecry
        public Dictionary<CardDB.CardName, int> ownSummonFromDeathrattle = new Dictionary<CardDB.CardName, int>();

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
            if (!p.isLethalCheck && m.name == CardDB.CardName.bloodimp) retval += 50;
            switch (m.name)
            {
                case CardDB.CardName.leeroyjenkins:
                    if (!target.own && target.name == CardDB.CardName.whelp) return 500;
                    break;
                case CardDB.CardName.bloodmagethalnos:
                    if (!target.isHero && Ai.Instance.lethalMissing <= 5)
                    {
                        if (!target.taunt)
                        {
                            if (m.HealthPoints <= target.Attack && m.own && !m.divineshild && !m.immune) return 65;
                        }
                    }
                    goto case CardDB.CardName.aiextra1;
                
                
                case CardDB.CardName.acolyteofpain: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.clockworkgnome: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.loothoarder: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.mechanicalyeti: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.mechbearcat: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.tombpillager: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.toshley: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.webspinner: goto case CardDB.CardName.aiextra1;
                case CardDB.CardName.aiextra1:
                    
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

            if (!isLethalCheck && p.enemyWeapon.name == CardDB.CardName.swordofjustice)
            {
                return 28;
            }

            switch (p.ownWeapon.name)
            {
                case CardDB.CardName.atiesh:
                    if (!isLethalCheck)
                    {
                        if (target.isHero) return 500;
                        else return 15;
                    }
                    break;
                case CardDB.CardName.doomhammer:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.CardName.rockbiterweapon && hc.canplayCard(p, true)) return 10;
                    }
                    break;
                case CardDB.CardName.eaglehornbow:
                    if (p.ownWeapon.Durability == 1)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.CardName.arcaneshot || hc.card.name == CardDB.CardName.killcommand) return -p.ownWeapon.Angr - 1;
                        }
                        if (p.ownSecretsIDList.Count >= 1) return 20;

                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Secret) return 20;
                        }
                    }
                    break;
                case CardDB.CardName.spiritclaws:
                    if (!isLethalCheck && p.ownWeapon.Angr == 1)
                    {
                        if (target.isHero) return 500;
                        else if (target.HealthPoints == 1 && this.specialMinions.ContainsKey(target.name)) return 0;
                        else return 7;
                    }
                    break;
                case CardDB.CardName.gorehowl:
                    if (target.isHero && p.ownWeapon.Angr >= 3) return 10;
                    break;
                case CardDB.CardName.brassknuckles:
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
                if (p.ownWeapon.Angr == 1 && wAttack == 0 && (p.ownHeroAblility.card.name == CardDB.CardName.poisoneddaggers || p.ownHeroAblility.card.name == CardDB.CardName.daggermastery)) wAttack = 1;
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
                if (this.equipWeaponPlayDatabase.ContainsKey(c.card.name) && c.card.name != CardDB.CardName.upgrade && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
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

            CardDB.CardName name = card.name;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(card, target, p);
            int tbuff = getTauntBuffPenality(card, target, p);
            if (name == CardDB.CardName.markofthewild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
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
            CardDB.CardName name = card.name;
            if (name == CardDB.CardName.darkwispers && card.cardIDenum != CardDB.CardIdEnum.GVG_041a) return 0;
            int pen = 0;
            //buff enemy?

            if (!p.isLethalCheck && (card.name == CardDB.CardName.savageroar || card.name == CardDB.CardName.bloodlust))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }
                if ((p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) && card.name == CardDB.CardName.savageroar) targets++;

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
                        case CardDB.CardName.biggamehunter:
                            if (target.Attack + this.attackBuffDatabase[name] > 6) return 5;
                            break;
                        case CardDB.CardName.shadowworddeath:
                            if (target.Attack + this.attackBuffDatabase[name] > 4) return 5;
                            break;
                        default:
                            break;
                    }
                }
                if (card.name == CardDB.CardName.crueltaskmaster || card.name == CardDB.CardName.innerrage)
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
                            if (hc.card.name == CardDB.CardName.execute) return 0;
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
                        case CardDB.CardName.markofyshaarj:
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
            CardDB.CardName name = card.name;
            int pen = 0;

            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.CardName.darkwispers && card.cardIDenum != CardDB.CardIdEnum.GVG_041a) return 0;

            if (target != null && !target.own && !this.tauntBuffDatabase.ContainsKey(name))
            {
                pen = 500 + p.ownMinions.Count;
            }

            return pen;
        }


        private int getTauntBuffPenality(CardDB.Card card, Minion target, Playfield p)
        {
            CardDB.CardName name = card.name;
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.CardName.markofnature && card.cardIDenum != CardDB.CardIdEnum.EX1_155b) return 0;
            if (name == CardDB.CardName.darkwispers && card.cardIDenum != CardDB.CardIdEnum.GVG_041a) return 0;
            
            if (target == null) return 3;
            if (!target.isHero && !target.own)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.CardName.theblackknight) return 0;
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

        private int getSilencePenality(CardDB.CardName name, Minion target, Playfield p)
        {
            int pen = 0;

            if (target == null)
            {
                if (name == CardDB.CardName.ironbeakowl || name == CardDB.CardName.spellbreaker || name == CardDB.CardName.keeperofthegrove)
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
                    case CardDB.CardName.masterchest: return 500;
                }
                if (this.silenceDatabase.ContainsKey(name))
                {
                    pen = 5;
                    if (p.isLethalCheck)
                    {
                        //during lethal we only silence taunt, or if its a mob (owl/spellbreaker) + we can give him charge
                        if (target.taunt || (name == CardDB.CardName.ironbeakowl && (p.ownMinions.Find(x => x.name == CardDB.CardName.tundrarhino) != null || p.owncards.Find(x => x.card.name == CardDB.CardName.charge) != null)) || (name == CardDB.CardName.spellbreaker && p.owncards.Find(x => x.card.name == CardDB.CardName.charge) != null)) return 0;

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
                        if (name == CardDB.CardName.keeperofthegrove) return 500;
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
            CardDB.CardName name = card.name;
            int pen = 0;

            if (name == CardDB.CardName.shieldslam && p.ownHero.armor == 0) return 500;
            if (name == CardDB.CardName.savagery && p.ownHero.Attack == 0) return 500;
            
            //aoe damage *************************************************************************************
            int aoeDamageType = 0;
            if (this.DamageAllEnemysDatabase.ContainsKey(name)) aoeDamageType = 1;
            else if (p.anzOwnAuchenaiSoulpriest >= 1 && HealAllDatabase.ContainsKey(name)) aoeDamageType = 2;
            else if (this.DamageAllDatabase.ContainsKey(name)) aoeDamageType = 3;
            if (aoeDamageType > 0)
            {
                if (p.enemyMinions.Count == 0)
                {
                    if (name == CardDB.CardName.cthun) return 0;
                    return 300;
                }

                int aoeDamage = 0;
                if (aoeDamageType == 1) aoeDamage = (card.type == CardDB.CardType.SPELL) ? p.getSpellDamageDamage(this.DamageAllEnemysDatabase[name]) : this.DamageAllEnemysDatabase[name];
                else if (aoeDamageType == 2) aoeDamage = (card.type == CardDB.CardType.SPELL) ? p.getSpellDamageDamage(this.HealAllDatabase[name]) : this.HealAllDatabase[name];
                else if (aoeDamageType == 3)
                {
                    if (name == CardDB.CardName.revenge && p.ownHero.HealthPoints <= 12) aoeDamage = p.getSpellDamageDamage(3);
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
                            case CardDB.CardName.sleepwiththefishes: 
                                if (!m.wounded) continue;
                                break;
                            case CardDB.CardName.dragonfirepotion: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) continue;
                                break;
                            case CardDB.CardName.corruptedseer: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) continue;
                                break;
                            case CardDB.CardName.shadowvolley: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                break;
                            case CardDB.CardName.demonwrath: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                break;
                            case CardDB.CardName.scarletpurifier: 
                                if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                break;
                            case CardDB.CardName.yseraawakens: 
                                if (m.name == CardDB.CardName.ysera) continue;
                                break;
                            case CardDB.CardName.lightbomb: 
                                if (m.HealthPoints > m.Attack) continue;
                                break;
                        }
                        
                        if (this.specialMinions.ContainsKey(m.name)) numSpecialMinionsEnemy++;
                        switch (m.name)
                        {
                            case CardDB.CardName.direwolfalpha: 
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
                            case CardDB.CardName.flametonguetotem: 
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
                            case CardDB.CardName.leokk: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardDB.CardName.raidleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardDB.CardName.stormwindchampion: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardDB.CardName.grimscaleoracle: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                                 
                            case CardDB.CardName.murlocwarleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardDB.CardName.malganis: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.DEMON && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardDB.CardName.southseacaptain: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.CardName.timberwolf: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.CardName.warhorsetrainer: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.name == CardDB.CardName.silverhandrecruit && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.CardName.warsongcommander: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.charge > 0 && (mm.HealthPoints > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.CardName.tunneltrogg:
                                preventDamage++;
                                break;
                            case CardDB.CardName.secretkeeper:
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
                        else if (m.name == CardDB.CardName.gurubashiberserker) preventDamage -= 3;
                        else if (m.name == CardDB.CardName.frothingberserker) frothingberserkerEnemy = true;
                        else if (m.name == CardDB.CardName.grimpatron) { preventDamage -= 3; grimpatronEnemy = true; }
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
                                case CardDB.CardName.sleepwiththefishes: 
                                    if (!m.wounded) continue;
                                    break;
                                case CardDB.CardName.dragonfirepotion: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) continue;
                                    break;
                                case CardDB.CardName.corruptedseer: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) continue;
                                    break;
                                case CardDB.CardName.shadowvolley: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                    break;
                                case CardDB.CardName.demonwrath: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                    break;
                                case CardDB.CardName.scarletpurifier: 
                                    if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                    break;
                                case CardDB.CardName.yseraawakens: 
                                    if (m.name == CardDB.CardName.ysera) continue;
                                    break;
                                case CardDB.CardName.lightbomb: 
                                    if (m.HealthPoints > m.Attack) continue;
                                    break;
                            }

                            switch (m.name)
                            {
                                case CardDB.CardName.direwolfalpha: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].HealthPoints > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 1;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].HealthPoints > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 1;
                                    break;
                                case CardDB.CardName.flametonguetotem: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].HealthPoints > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 2;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].HealthPoints > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 2;
                                    break;
                                case CardDB.CardName.leokk: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardDB.CardName.raidleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardDB.CardName.stormwindchampion: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.HealthPoints > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardDB.CardName.grimscaleoracle: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                
                                case CardDB.CardName.murlocwarleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardDB.CardName.malganis: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.DEMON && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardDB.CardName.southseacaptain: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardDB.CardName.timberwolf: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardDB.CardName.warhorsetrainer: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.name == CardDB.CardName.silverhandrecruit && (mm.HealthPoints > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardDB.CardName.warsongcommander: 
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
                            else if (m.name == CardDB.CardName.gurubashiberserker && m.HealthPoints > 1) lostOwnDamage += 3;
                            else if (m.name == CardDB.CardName.frothingberserker) frothingberserkerOwn = true;
                            else if (m.name == CardDB.CardName.grimpatron) { lostOwnDamage += 3; grimpatronOwn = true; }
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
                            foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == CardDB.CardName.execute) return 0;
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
                    else if (name == CardDB.CardName.holynova && preventDamage >= 0)
                    {
                        int ownWoundedMinions = 0;
                        foreach (Minion m in p.ownMinions) if (m.wounded) ownWoundedMinions++;
                        if (ownWoundedMinions > 2) return 20;
                    }

                    if (survivedEnemyMinions > 0)
                    {
                        int hasExecute = 0;
                        foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == CardDB.CardName.execute) hasExecute++;
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
                if (name == CardDB.CardName.baneofdoom)
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
                    
                    if (m.name == CardDB.CardName.madscientist && p.ownHeroStartClass == TAG_CLASS.HUNTER) return 500;

                    // no pen if we have battlerage for example
                    int dmg = this.DamageTargetDatabase.ContainsKey(name) ? this.DamageTargetDatabase[name] : this.HealTargetDatabase[name];
                    switch (card.cardIDenum)
                    {
                        case CardDB.CardIdEnum.EX1_166a: dmg = 2 - p.spellpower; break; 
                        case CardDB.CardIdEnum.CS2_031: if (!target.frozen) return 0; break; 
                        case CardDB.CardIdEnum.EX1_408: if (p.ownHero.HealthPoints <= 12) dmg = 6; break; 
                        case CardDB.CardIdEnum.EX1_539: 
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
                            case CardDB.CardName.gurubashiberserker: return 0; break;
                            case CardDB.CardName.axeflinger: return 0; break;
                            case CardDB.CardName.gahzrilla: return 0; break;
                            case CardDB.CardName.garr: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardDB.CardName.hoggerdoomofelwynn: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardDB.CardName.acolyteofpain: if (p.owncards.Count <= 3) return 0; break;
                            case CardDB.CardName.dragonegg: if (p.ownMinions.Count <= 6) return 5; break;
                            case CardDB.CardName.impgangboss: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardDB.CardName.grimpatron: if (p.ownMinions.Count <= 6) return 0; break;
                        }
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.CardName.battlerage) return pen;
                            if (hc.card.name == CardDB.CardName.rampage) return pen;
                        }
                    }
                    else
                    {
                        if (p.isLethalCheck && dmg == 1 && p.enemyHero.HealthPoints < 3)
                        {
                            switch (m.name)
                            {
                                case CardDB.CardName.lepergnome: return 0; break;
                                case CardDB.CardName.axeflinger: return 0; break;
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
                        case CardDB.CardName.crueltaskmaster: if (m.HealthPoints >= 2) return 0; break;
                        case CardDB.CardName.innerrage: if (m.HealthPoints >= 2) return 0; break;
                        case CardDB.CardName.demonfire: if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0; break;
                        case CardDB.CardName.demonheart: if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0; break;
                        case CardDB.CardName.earthshock:
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
                                case CardDB.CardName.battlerage: return pen; break;
                                case CardDB.CardName.rampage: return pen; break;
                                case CardDB.CardName.bloodwarriors: return pen; break;
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
                        case CardDB.CardName.soulfire: if (target.HealthPoints <= realDamage - 2) pen = 10; break; 
                        case CardDB.CardName.baneofdoom: if (target.HealthPoints > realDamage) pen = 10; break; 
                        case CardDB.CardName.shieldslam: if (target.HealthPoints <= 4 || target.Attack <= 4) pen = 20; break; 
                        case CardDB.CardName.bloodtoichor: if (target.HealthPoints <= realDamage) pen = 2; break; 
                    }
                }
                else
                {
                    if (DamageTargetDatabase.ContainsKey(name))
                    {
                        realDamage = this.DamageTargetDatabase[name];
                        switch (card.cardIDenum)
                        {
                            case CardDB.CardIdEnum.EX1_166a: realDamage = 2 - p.spellpower; break; 
                            case CardDB.CardIdEnum.CS2_031: if (!target.frozen) return 0; break; 
                            case CardDB.CardIdEnum.EX1_408: if (p.ownHero.HealthPoints <= 12) realDamage = 6; break; 
                            case CardDB.CardIdEnum.EX1_539: 
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
                if (target.name == CardDB.CardName.grimpatron && realDamage < target.HealthPoints) return 500;
            }

            return pen;
        }

        private int getHealPenality(CardDB.CardName name, Minion target, Playfield p)
        {
            ///Todo healpenality for aoe heal
            ///todo auchenai soulpriest
            if (p.anzOwnAuchenaiSoulpriest >= 1) return 0;
            int pen = 0;
            int heal = 0;


            switch (name)
            {
                case CardDB.CardName.treeoflife:
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

                case CardDB.CardName.renojackson:
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

                case CardDB.CardName.circleofhealing:
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
                        if (mnn.name == CardDB.CardName.northshirecleric) i++;
                        if (mnn.name == CardDB.CardName.lightwarden) i++;
                    }
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.name == CardDB.CardName.northshirecleric) i--;
                        if (mnn.name == CardDB.CardName.lightwarden) i--;
                    }
                    if (i >= 1) return pen;

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.CardName.slam && m.HealthPoints < 2) return pen;
                        if (hc.card.name == CardDB.CardName.backstab) return pen;
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
            CardDB.CardName name = card.name;
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.CardName.wrath && card.cardIDenum != CardDB.CardIdEnum.EX1_154b) return 0;
            if (name == CardDB.CardName.nourish && card.cardIDenum != CardDB.CardIdEnum.EX1_164b) return 0;
            if (name == CardDB.CardName.tracking) return -1;            

            int carddraw = cardDrawBattleCryDatabase[name];
            if (carddraw == 0)
            {
                switch(name)
                {
                    case CardDB.CardName.harrisonjones:
                        carddraw = p.enemyWeapon.Durability;
                        if (carddraw == 0 && (p.enemyHeroStartClass != TAG_CLASS.DRUID && p.enemyHeroStartClass != TAG_CLASS.MAGE && p.enemyHeroStartClass != TAG_CLASS.WARLOCK && p.enemyHeroStartClass != TAG_CLASS.PRIEST)) return 5;
                        break;

                    case CardDB.CardName.divinefavor:
                        carddraw = p.enemyAnzCards - (p.owncards.Count);
                        if (carddraw <= 0) return 500;
                        break;

                    case CardDB.CardName.battlerage:
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

                    case CardDB.CardName.slam:
                        if (target != null && target.HealthPoints >= 3) carddraw = 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardDB.CardName.mortalcoil:
                        if (target != null && target.HealthPoints == 1) carddraw = 1;
                        if (carddraw == 0) return 15;
                        break;

                    case CardDB.CardName.quickshot:
                        carddraw = (p.owncards.Count > 0) ? 0 : 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardDB.CardName.thoughtsteal:
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
                    
                    case CardDB.CardName.mindvision:
                        carddraw = Math.Min(1, p.enemyAnzCards);
                        if (carddraw != 1)
                        {
                            int scales = 0;
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (this.spellDependentDatabase.ContainsKey(mnn.name))
                                    if(mnn.name == CardDB.CardName.lorewalkercho) pen += 20; //if(spellDependentDatabase[mnn.name] == 0);
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
                        
                    case CardDB.CardName.echoofmedivh:
                        if (p.ownMinions.Count == 0) return 500;
                        return 0;
                        break;
                        
                    case CardDB.CardName.tinkertowntechnician:
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if ((TAG_RACE)mnn.handcard.card.race != TAG_RACE.MECHANICAL) pen += 4;
                        }
                        break;

                    case CardDB.CardName.markofyshaarj:
                        if ((TAG_RACE)target.handcard.card.race == TAG_RACE.PET) carddraw = 1;
                        break;

                    case CardDB.CardName.servantofkalimos:
                        if (p.anzOwnElementalsLastTurn > 0) carddraw = 1;
                        break;                        

                    default:
                        break;
                }
            }
            
            if (name == CardDB.CardName.farsight || name == CardDB.CardName.callpet) pen -= 10;
            
            if (name == CardDB.CardName.lifetap)
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
                        if (m.name == CardDB.CardName.doomsayer) return 2;
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
                case CardDB.CardName.solemnvigil:
                    tmp -= 2 * p.diedMinions.Count;
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name)) tmp -= 2;
                    }
                    break;
                case CardDB.CardName.echoofmedivh:
                    diff = p.ownMinions.Count - prozis.ownMinions.Count;
                    if (diff > 0) tmp -= 2 * diff;
                    break;
                case CardDB.CardName.bloodwarriors:
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
                    if (mnn.name == CardDB.CardName.gadgetzanauctioneer) carddraw++;
                }
            }

            if (card.type == CardDB.CardType.MOB && (TAG_RACE)card.race == TAG_RACE.PET)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.CardName.starvingbuzzard) carddraw++;
                }
            }

            if (carddraw == 0) return 0;
            if (p.owncards.Count >= 5) return 0;

            
            if (card.cost > 0) pen = -carddraw + p.ownMaxMana - p.mana + p.optionsPlayedThisTurn;

            return pen;
        }
        
        public int getCardDrawDeathrattlePenality(CardDB.CardName name, Playfield p)
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

            if (card.name == CardDB.CardName.brawl)
            {
                return 0;
            }

            if ((card.name == CardDB.CardName.cleave || card.name == CardDB.CardName.multishot) && p.enemyMinions.Count == 2)
            {
                return 0;
            }

            if ((card.name == CardDB.CardName.deadlyshot) && p.enemyMinions.Count == 1)
            {
                return 0;
            }

            if ((card.name == CardDB.CardName.arcanemissiles || card.name == CardDB.CardName.avengingwrath)
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
                if (mnn.name == CardDB.CardName.gadgetzanauctioneer)
                {
                    hasgadget = true;
                }

                if (mnn.name == CardDB.CardName.starvingbuzzard)
                {
                    hasstarving = true;
                }

                if (mnn.name == CardDB.CardName.knifejuggler)
                {
                    hasknife = true;
                }

                if (mnn.name == CardDB.CardName.flamewaker)
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
                    && (p.ownHeroAblility.card.name == CardDB.CardName.totemiccall || p.ownHeroAblility.card.name == CardDB.CardName.lifetap || p.ownHeroAblility.card.name == CardDB.CardName.soultap))
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
                    if (card.name == CardDB.CardName.knifejuggler && card.type == CardDB.CardType.MOB)
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


        private int getBuffHandPenalityPlay(CardDB.CardName name, Playfield p)
        {
            if (!buffHandDatabase.ContainsKey(name)) return 0;

            Handmanager.Handcard hc;
            int anz = 0;
            switch (name)
            {
                case CardDB.CardName.troggbeastrager: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -5;
                    break;
                case CardDB.CardName.grimestreetsmuggler: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -5;
                    break;
                case CardDB.CardName.donhancho: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -20;
                    break;
                case CardDB.CardName.deathaxepunisher: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.LIFESTEAL);
                    if (hc != null) return -10;
                    break;
                case CardDB.CardName.grimscalechum: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.MURLOC);
                    if (hc == null) return -5;
                    break;
                case CardDB.CardName.grimestreetpawnbroker: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Weapon);
                    if (hc == null) return -5;
                    break;
                case CardDB.CardName.grimestreetoutfitter: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == CardDB.CardType.MOB) anz++;
                    }
                    anz--; 
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
                case CardDB.CardName.themistcaller: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == CardDB.CardType.MOB) anz++;
                    }
                    anz--; 
                    anz += p.ownDeckSize / 4;
                    return -1 * anz * 4;
                    break;
                case CardDB.CardName.hobartgrapplehammer: 
                    foreach (Handmanager.Handcard hc2 in p.owncards)
                    {
                        if (hc2.card.type == CardDB.CardType.WEAPON) anz++;
                    }
                    if (anz == 0) return 2;
                    else return -1 * anz * 2;
                    break;
                case CardDB.CardName.smugglerscrate: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -10;
                    else return 10;
                    break;
                case CardDB.CardName.stolengoods: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.TAUNT);
                    if (hc != null) return -15;
                    else return 10;
                    break;
                case CardDB.CardName.smugglersrun: 
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

        private int getCardDiscardPenality(CardDB.CardName name, Playfield p)
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
                        case CardDB.CardName.silverwaregolem: pen -= 12; continue;
                        case CardDB.CardName.fistofjaraxxus: pen -= 6; continue;
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

        private int getDestroyOwnPenality(CardDB.CardName name, Minion target, Playfield p)
        {
            if (!this.destroyOwnDatabase.ContainsKey(name)) return 0;
            
            switch (name)
            {
                case CardDB.CardName.sanguinereveler: goto case CardDB.CardName.shadowflame;
                case CardDB.CardName.ravenouspterrordax: goto case CardDB.CardName.shadowflame;
                case CardDB.CardName.shadowflame:
                    if (target == null || !target.Ready) return 0;
                    else return 1;
                case CardDB.CardName.deathwing:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    break;
                case CardDB.CardName.twistingnether: goto case CardDB.CardName.brawl;
                case CardDB.CardName.doompact: goto case CardDB.CardName.brawl;
                case CardDB.CardName.brawl:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    
                    if (name == CardDB.CardName.brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
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
                        case CardDB.CardName.lepergnome: return -2;
                        case CardDB.CardName.backstreetleper: return -2;
                        case CardDB.CardName.firesworn: return -2;
                        case CardDB.CardName.zombiechow:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -5;
                            else return 500;
                        case CardDB.CardName.corruptedhealbot:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -8;
                            else return 500;
                        default:
                            int up = 0;
                            foreach (Minion m in p.ownMinions)
                            {
                                switch (m.handcard.card.name)
                                {
                                    case CardDB.CardName.manawyrm: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.flamewaker: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.archmageantonidas: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.gadgetzanauctioneer: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.manaaddict: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.redmanawyrm: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.summoningstone: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.wickedwitchdoctor: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.holychampion: goto case CardDB.CardName.lightwarden;
                                    case CardDB.CardName.lightwarden:
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
                        case CardDB.CardName.unwillingsacrifice:
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

        private int getDestroyPenality(CardDB.CardName name, Minion target, Playfield p)
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

                if (m.allreadyAttacked && name != CardDB.CardName.execute)
                {
                    return 50;
                }

                if (name == CardDB.CardName.shadowwordpain)
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

                if (name == CardDB.CardName.mindcontrol && (m.name == CardDB.CardName.direwolfalpha || m.name == CardDB.CardName.raidleader || m.name == CardDB.CardName.flametonguetotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

                if (m.name == CardDB.CardName.doomsayer)
                {
                    pen = 5;
                }

            }

            return pen;
        }

        private int getSpecialCardComboPenalitys(CardDB.Card card, Minion target, Playfield p)
        {
            bool lethal = p.isLethalCheck;
            CardDB.CardName name = card.name;

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
                                if (mm.name == CardDB.CardName.silverhandrecruit && mm.Ready) return 0;
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
                                if (mm.name == CardDB.CardName.cthun && mm.Ready) return 0;
                            }
                            break;
                    }
                    return 500;
                }
                else
                {
                    if ((name == CardDB.CardName.rendblackhand && target != null) && !target.own)
                    {
                        if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == CardDB.CardName.malganis)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) return 0;
                            }
                        }
                        return 500;
                    }

                    if (name == CardDB.CardName.theblackknight)
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
                                if (mm.Ready && (mm.handcard.card.name == CardDB.CardName.lightwarden || mm.handcard.card.name == CardDB.CardName.holychampion)) beasts++;
                            }
                            if (beasts == 0) return 500;
                        }
                        else
                        {
                            if (!(name == CardDB.CardName.nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || this.DamageTargetDatabase.ContainsKey(name) || ((TAG_RACE)card.race == TAG_RACE.PET && p.ownMinions.Find(x => x.name == CardDB.CardName.tundrarhino) != null) || p.owncards.Find(x => x.card.name == CardDB.CardName.charge) != null))
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
                case CardDB.CardName.hobartgrapplehammer: return -5; 
                case CardDB.CardName.bloodsailraider: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.CardName.captaingreenskin: if (p.ownWeapon.Durability == 0) return 10; return 0; 
                case CardDB.CardName.luckydobuccaneer: if (!(p.ownWeapon.Durability > 0 && p.ownWeapon.Angr > 2)) return 10; return 0; 
                case CardDB.CardName.nagacorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.CardName.goblinautobarber: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.CardName.dreadcorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.CardName.grimestreetpawnbroker: 
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.CardType.WEAPON) return 0;
                    return 5;
                case CardDB.CardName.bloodsailcultist: ; 
                    if (p.ownWeapon.Durability > 0) foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) return 0;
                    return 8;
                case CardDB.CardName.ravasaurrunt: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardDB.CardName.nestingroc: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardDB.CardName.gentlemegasaur: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardDB.CardName.primalfinlookout: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardDB.CardName.spiritecho: 
                    if (p.ownQuest.Id == CardDB.CardIdEnum.UNG_942)
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
                case CardDB.CardName.evolvingspores: 
                    if (p.ownMinions.Count < 3) return 15 - p.ownMinions.Count * 5;
                    return 0;
                case CardDB.CardName.livingmana: 
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
                case CardDB.CardName.elisethetrailblazer: return -7; 
                case CardDB.CardName.cracklingrazormaw:   
                    if (target != null) return 0;
                    return 5;
                case CardDB.CardName.dinomancy: return -7; 
                case CardDB.CardName.moltenblade: return -10; 
                case CardDB.CardName.gluttonousooze: goto case CardDB.CardName.acidicswampooze;
                case CardDB.CardName.acidicswampooze:
                    if (p.enemyWeapon.Angr > 0) return 0;
                    if (p.enemyHeroName == HeroEnum.shaman || p.enemyHeroName == HeroEnum.warrior || p.enemyHeroName == HeroEnum.thief || p.enemyHeroName == HeroEnum.pala) return 10;
                    if (p.enemyHeroName == HeroEnum.hunter) return 6;
                    return 0;
                case CardDB.CardName.darkshirecouncilman:
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
                case CardDB.CardName.deadmanshand: 
                    if (p.owncards.Count > 2) return -5 * p.owncards.Count;
                    break;
                case CardDB.CardName.bringiton: 
                    return 3 * p.enemyAnzCards * (11 - p.enemyMaxMana);
                case CardDB.CardName.strongshellscavenger:
                    int tmp = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp++;
                    return 12 - tmp * 2;

            }

            if (name == CardDB.CardName.unstableportal && p.owncards.Count <= 9) return -15;
            if (name == CardDB.CardName.lunarvisions && p.owncards.Count <= 8) return -5;

            if (name == CardDB.CardName.azuredrake)
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
                        if (hc.card.name == CardDB.CardName.menageriewarden) { menageriewarden = true; continue; }
                        if ((TAG_RACE)hc.card.race == TAG_RACE.PET && hc.card.cost <= p.ownMaxMana) pet = true;
                    }
                    if (menageriewarden && pet) pen += 23;
                }
                return pen;
            }

            if (name == CardDB.CardName.manatidetotem)
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

            if (name == CardDB.CardName.menageriewarden)
            {
                if (target != null && (TAG_RACE)target.handcard.card.race == TAG_RACE.PET) return 0;
                else return 10;
            }

            if (name == CardDB.CardName.duplicate)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.CardName.mirrorentity)
                    {
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.handcard.card.Attack >= 3 && this.UsefulNeedKeepDatabase.ContainsKey(mnn.name)) return 0;
                        }
                        return 16;
                    }
                }
            }

            if ((name == CardDB.CardName.lifetap || name == CardDB.CardName.soultap) && p.owncards.Count <= 9)
            {
                 foreach (Minion mnn in p.ownMinions)
                 {
                     if (mnn.name == CardDB.CardName.wilfredfizzlebang && !mnn.silenced) return -20;
                 }
            }

            if (name == CardDB.CardName.forbiddenritual)
            {
                if (p.ownMinions.Count == 7 || p.mana == 0) return 500;
                return 7;
            }
            
            if (name == CardDB.CardName.competitivespirit)
            {
                if (p.ownMinions.Count < 1) return 500;
                if (p.ownMinions.Count > 2) return 0;
                return (15 - 5 * p.ownMinions.Count);
            }

            if (name == CardDB.CardName.shifterzerus) return 500;

            if (card.name == CardDB.CardName.daggermastery)
            {
                if (p.ownWeapon.Angr >= 2 || p.ownWeapon.Durability >= 2) return 5;
            }

            if (card.name == CardDB.CardName.upgrade)
            {
                if (p.ownWeapon.Durability == 0)
                {
                    if (weaponInHandAttackNextTurn(p) > 0) return 10;
                    return 0;
                }
            }

            if (card.name == CardDB.CardName.malchezaarsimp && p.owncards.Count > 2) return 5;

            if (card.name == CardDB.CardName.baronrivendare)
            {
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.name == CardDB.CardName.deathlord || mnn.name == CardDB.CardName.zombiechow || mnn.name == CardDB.CardName.dancingswords) return 30;
                }
            }

            //rule for coin on early game
            if (p.ownMaxMana < 3 && card.name == CardDB.CardName.thecoin)
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
                case CardDB.CardName.flare: 
                    foreach (Minion mn in p.ownMinions) if (mn.stealth) pen++;
                    foreach (Minion mn in p.enemyMinions) if (mn.stealth) pen--;
                    if (p.enemySecretCount > 0)
                    {
                        bool canPlayMinion = false;
                        bool canPlaySpell = false;
                        foreach(Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.CardName.flare) continue;
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
                case CardDB.CardName.eaterofsecrets: 
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
                case CardDB.CardName.kezanmystic: 
                    if (p.enemySecretCount == 1 && p.playactions.Count == 0) pen -= 50;
                    break;

                case CardDB.CardName.totemiccall:
                    if (lethal) return 20;
                    break;

                case CardDB.CardName.frostwolfwarlord:
                    if (p.ownMinions.Count == 0) pen += 5;
                    break;

                case CardDB.CardName.flametonguetotem:
                    if (p.ownMinions.Count == 0) return 100;
                    break;
                
                case CardDB.CardName.stampedingkodo:
                    bool found = false;
                    foreach (Minion mi in p.enemyMinions)
                    {
                        if (mi.Attack <= 2) found = true;
                    }
                    if (!found) return 20;
                    break;

                case CardDB.CardName.windfury:
                    if (!target.own) return 500;
                    else if (!target.Ready) return 500;
                    break;

                case CardDB.CardName.desperatestand: goto case CardDB.CardName.ancestralspirit;
                case CardDB.CardName.ancestralspirit:
                    if (!target.isHero)
                    {
                        if (!target.own)
                        {
                            if (target.name == CardDB.CardName.deathlord || target.name == CardDB.CardName.zombiechow || target.name == CardDB.CardName.dancingswords) return 0;
                            return 500;
                        }
                        else
                        {
                            if (this.specialMinions.ContainsKey(target.name)) return -5;
                            return 0;
                        }
                    }
                    break;

                case CardDB.CardName.houndmaster:
                    if (target == null) return 50;
                    break;

                case CardDB.CardName.beneaththegrounds: return -10;

                case CardDB.CardName.curseofrafaam: return -7;

                case CardDB.CardName.flameimp:
                    if (p.ownHero.HealthPoints + p.ownHero.armor > 20) pen -= 3;
                    break;
             

                case CardDB.CardName.quartermaster:
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.name == CardDB.CardName.silverhandrecruit) return 0;
                    }
                    return 5;

                case CardDB.CardName.mysteriouschallenger: return -14;

                case CardDB.CardName.biggamehunter:
                    if (target == null || target.own) return 40;
                    break;
                    
                case CardDB.CardName.emergencycoolant:
                    if (target != null && target.own) pen = 500;
                    break;

                case CardDB.CardName.shatteredsuncleric:
                    if (target == null) return 10;
                    break;

                case CardDB.CardName.argentprotector:
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

                case CardDB.CardName.facelessmanipulator:
                    if (target == null) return 50;
                    if (target.Attack >= 5 || target.handcard.card.cost >= 5 || (target.handcard.card.rarity == 5 || target.handcard.card.cost >= 3))
                    {
                        return 0;
                    }
                    return 49;

                case CardDB.CardName.rendblackhand:
                    if (target == null) return 15;
                    if (target.own) return 100;
                    if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == CardDB.CardName.malganis)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) return 0;
                        }
                    }
                    return 500;

                case CardDB.CardName.theblackknight:
                    if (target == null) return 50;
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.taunt && (target.Attack >= 3 || target.HealthPoints >= 3)) return 0;
                    }
                    return 20;

                case CardDB.CardName.madderbomber: goto case CardDB.CardName.madbomber;
                case CardDB.CardName.madbomber:
                    pen = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.Ready & mnn.HealthPoints < 3) pen += 5;
                    }
                    return pen;

                case CardDB.CardName.sylvanaswindrunner:
                    if (p.enemyMinions.Count == 0) return 10;
                    break;

                case CardDB.CardName.betrayal:
                    if (!target.own && !target.isHero)
                    {
                        if (target.Attack == 0) return 30;
                        if (p.enemyMinions.Count == 1) return 30;
                    }
                    break;

                case CardDB.CardName.nerubianegg:
                    if (p.owncards.Find(x => this.attackBuffDatabase.ContainsKey(x.card.name)) != null || p.owncards.Find(x => this.tauntBuffDatabase.ContainsKey(x.card.name)) != null)
                    {
                        return -6;
                    }
                    break;

                case CardDB.CardName.bite:
                    if ((p.ownHero.numAttacksThisTurn == 0 || (p.ownHero.windfury && p.ownHero.numAttacksThisTurn == 1)) && !p.ownHero.frozen)
                    {

                    }
                    else return 20;
                    break;

                case CardDB.CardName.deadlypoison:
                    return -(p.ownWeapon.Durability - 1) * 2;

                case CardDB.CardName.coldblood:
                    if (lethal) return 0;
                    return 25;

                case CardDB.CardName.bloodmagethalnos: return 10;

                case CardDB.CardName.frostbolt:
                    if (!target.own && !target.isHero)
                    {
                        if (target.handcard.card.cost < 3 && !this.priorityDatabase.ContainsKey(target.handcard.card.name)) return 15;
                    }
                    return 0;

                case CardDB.CardName.poweroverwhelming:
                    if (target.own && !target.isHero && !target.Ready) return 500;
                    break;

                case CardDB.CardName.frothingberserker:
                    if (p.cardsPlayedThisTurn >= 1) pen = 5;
                    break;

                case CardDB.CardName.handofprotection:
                    if (!target.own)
                    {
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (!mm.divineshild) return 500;
                        }
                    }
                    if (target.HealthPoints == 1) pen = 15;
                    break;

                case CardDB.CardName.wildgrowth: goto case CardDB.CardName.nourish;
                case CardDB.CardName.nourish:
                    if (p.ownMaxMana == 9 && !(p.ownHeroName == HeroEnum.thief && p.cardsPlayedThisTurn == 0)) return 500;
                    break;

                case CardDB.CardName.resurrect:
                    if (p.ownMaxMana < 6) return 50;
                    if (p.ownMinions.Count == 7) return 500;
                    if (p.ownMaxMana > 8) return 0;
                    if (p.OwnLastDiedMinion == CardDB.CardIdEnum.None) return 6;
                    return 0;

                case CardDB.CardName.lavashock:
                    if (p.ueberladung + p.lockedMana < 1) return 15;
                    return (3 - 3 * (p.ueberladung + p.lockedMana));

                case CardDB.CardName.edwinvancleef:
                    if (p.cardsPlayedThisTurn < 1) return 30;
                    else if (p.cardsPlayedThisTurn < 2) return 10;
                    else return 0;

                case CardDB.CardName.enhanceomechano:
                    if (p.ownMinions.Count == 0 && p.ownMaxMana < 5) return 500;
                    pen = 2 * (p.mana - 4 - p.mobsplayedThisTurn);
                    if (p.mobsplayedThisTurn < 1) pen += 30;
                    return pen;

                case CardDB.CardName.knifejuggler:
                    if (p.mobsplayedThisTurn >= 1) return 20;
                    break;

                case CardDB.CardName.flamewaker:
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && a.card.card.type == CardDB.CardType.SPELL) return 30;
                    }
                    break;

                case CardDB.CardName.polymorph: goto case CardDB.CardName.hex;
                case CardDB.CardName.hex:
                    if (!target.isHero)
                    {
                        if (target.own)
                        {
                            if (target.name == CardDB.CardName.masterchest) return -5;
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

                case CardDB.CardName.ravagingghoul:
                    if (p.enemyMinions.Count == 0) return 7;
                    break;

                case CardDB.CardName.bookwyrm:
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

                case CardDB.CardName.grimestreetprotector:
                    if (p.ownMinions.Count == 1) return 10;
                    else if (p.ownMinions.Count == 0) return 20;
                    break;

                case CardDB.CardName.sunfuryprotector:
                    if (p.ownMinions.Count == 1) return 15;
                    else if (p.ownMinions.Count == 0) return 30;
                    break;

                case CardDB.CardName.defenderofargus:
                    if (p.ownMinions.Count == 1) return 30;
                    else if (p.ownMinions.Count == 0) return 50;
                    break;

                case CardDB.CardName.unearthedraptor:
                    if (target == null) return 10;
                    break;

                case CardDB.CardName.unleashthehounds:
                    if (p.enemyMinions.Count <= 1) return 20;
                    break;

                case CardDB.CardName.equality:
                    if (p.enemyMinions.Count <= 2 || (p.ownMinions.Count - p.enemyMinions.Count >= 1)) return 20;
                    break;

                case CardDB.CardName.bloodsailraider:
                    if (p.ownWeapon.Durability == 0)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.type == CardDB.CardType.WEAPON) return 10;
                        }
                    }
                    break;

                case CardDB.CardName.innerfire:
                    if (target.name == CardDB.CardName.lightspawn) return 500;
                    if (!target.Ready) return 20;
                    break;

                case CardDB.CardName.huntersmark:
                    if (!target.isHero)
                    {
                        if (target.own) return 500;
                        else if (target.HealthPoints <= 4 && target.Attack <= 4 && !(target.poisonous && !target.silenced))
                        {
                            pen = 20;
                        }
                    }
                    break;

                case CardDB.CardName.crazedalchemist:
                    if (target != null) pen -= 1;
                    break;

                case CardDB.CardName.deathwing:
                    int prevDmg = 0;
                    foreach (Minion m1 in p.enemyMinions)
                    {
                        prevDmg += m1.Attack;
                    }
                    if (p.ownHero.HealthPoints + p.ownHero.armor > prevDmg * 2) pen += p.ownMinions.Count * 10 + p.owncards.Count * 25;
                    break;

                case CardDB.CardName.deathwingdragonlord:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) pen -= 3;
                    }
                    pen += 3;
                    break;

                case CardDB.CardName.humility: goto case CardDB.CardName.aldorpeacekeeper;
                case CardDB.CardName.aldorpeacekeeper:
                    if (target != null)
                    {
                        if (target.own) pen = 500;
                        else if (target.Attack <= 3) pen = 30;
                        if (target.name == CardDB.CardName.lightspawn) pen = 500;
                    }
                    else pen = 40;
                    break;
            
                case CardDB.CardName.direwolfalpha: goto case CardDB.CardName.abusivesergeant;
                case CardDB.CardName.abusivesergeant:
                    int ready = 0;
                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.Ready) ready++;
                    }
                    if (ready == 0) pen = 5;
                    break;
                    
                case CardDB.CardName.gangup:
                    if (this.GangUpDatabase.ContainsKey(target.handcard.card.name))
                    {
                        return (-5 - 1 * GangUpDatabase[target.handcard.card.name]);
                    }
                    else return 40;
                    
                case CardDB.CardName.defiasringleader:
                    if (p.cardsPlayedThisTurn == 0) pen = 10;
                    break;

                case CardDB.CardName.bloodknight:
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

                case CardDB.CardName.reincarnate:
                    if (target.own)
                    {
                        if (target.handcard.card.deathrattle || target.ancestralspirit >= 1 || target.desperatestand >= 1 || target.souloftheforest >= 1 || target.stegodon >= 1 || target.livingspores >= 1 || target.infest >= 1 || target.explorershat >= 1 || target.returnToHand >= 1 || target.deathrattle2 != null || target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.handcard.card.Charge && ((target.numAttacksThisTurn == 1 && !target.windfury) || (target.numAttacksThisTurn == 2 && target.windfury))) return 0;
                        if (target.wounded || target.Attack < target.handcard.card.Attack || (target.silenced && this.specialMinions.ContainsKey(target.name))) return 0;
                        
                        bool hasOnMinionDiesMinion = false;
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.name == CardDB.CardName.scavenginghyena && target.handcard.card.race == 20) hasOnMinionDiesMinion = true;
                            if (mnn.name == CardDB.CardName.flesheatingghoul || mnn.name == CardDB.CardName.cultmaster) hasOnMinionDiesMinion = true;
                        }
                        if (hasOnMinionDiesMinion) return 0;
                        return 500;
                    }
                    else
                    {
                        if (target.name == CardDB.CardName.nerubianegg && target.Attack <= 4 && !target.taunt) return 500;
                        if (target.taunt && !target.handcard.card.tank) return 0;
                        if (target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.Attack > target.handcard.card.Attack || target.HealthPoints > target.handcard.card.Health) return 0;
                        if (target.name == CardDB.CardName.abomination || target.name == CardDB.CardName.zombiechow || target.name == CardDB.CardName.unstableghoul || target.name == CardDB.CardName.dancingswords) return 0;
                        return 500;
                    }
                    break;

                case CardDB.CardName.divinespirit:
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
                                if (p.owncards.Find(x => x.card.name == CardDB.CardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.CardName.innerfire) != null && (target.HealthPoints >= 4 || (p.owncards.Find(x => x.card.name == CardDB.CardName.divinespirit) != null && target.HealthPoints >= 2)))
                                {
                                    return 0;
                                }
                                return 500;
                            }
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.name == CardDB.CardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.CardName.innerfire) != null && target.HealthPoints >= 4)
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                    break;
            }


            //------------------------------------------------------------------------------------------------------


            if ((p.ownHeroAblility.card.name == CardDB.CardName.totemiccall || p.ownHeroAblility.card.name == CardDB.CardName.totemicslam) && p.ownAbilityReady == false)
            {
                foreach (Action a in p.playactions)
                {
                    if (a.actionType == actionEnum.playcard && a.card.card.name == CardDB.CardName.draeneitotemcarver) return -1;
                }
                if (p.owncards.Count > 1)
                {
                    if (card.type == CardDB.CardType.SPELL)
                    {
                        if (!(DamageTargetDatabase.ContainsKey(card.name) || DamageAllEnemysDatabase.ContainsKey(card.name) 
                            || DamageAllDatabase.ContainsKey(card.name) || DamageRandomDatabase.ContainsKey(card.name) 
                            || DamageTargetSpecialDatabase.ContainsKey(card.name) || DamageHeroDatabase.ContainsKey(card.name))) pen += 10;
                    }
                    else if (card.name == CardDB.CardName.frostwolfwarlord || card.name == CardDB.CardName.thingfrombelow || card.name == CardDB.CardName.draeneitotemcarver) return -1;
                    else pen += 10;
                }
            }

            if (target != null && (name == CardDB.CardName.sap || name == CardDB.CardName.dream || name == CardDB.CardName.kidnapper))
            {
                if (!target.own && (target.name == CardDB.CardName.theblackknight || name == CardDB.CardName.rendblackhand))
                {
                    return 50;
                }
            }

            if (!lethal && card.cardIDenum == CardDB.CardIdEnum.EX1_165t1) //druidoftheclaw	Charge
            {
                return 20;
            }


            if (lethal)
            {
                if (name == CardDB.CardName.corruption)
                {
                    int beasts = 0;
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.Ready && (mm.handcard.card.name == CardDB.CardName.questingadventurer || mm.handcard.card.name == CardDB.CardName.archmageantonidas || mm.handcard.card.name == CardDB.CardName.manaaddict || mm.handcard.card.name == CardDB.CardName.manawyrm || mm.handcard.card.name == CardDB.CardName.wildpyromancer)) beasts++;
                    }
                    if (beasts == 0) return 500;
                }
            }


            if (returnHandDatabase.ContainsKey(name))
            {
                if (target != null && target.own && !target.isHero && target.Ready) pen += 10;

                switch (target.name)
                {
                    case CardDB.CardName.masterchest: return target.own ? -21 : 5;
                }

                if (card.type == CardDB.CardType.SPELL)
                {
                    if (name == CardDB.CardName.vanish)
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
                                //case CardDB.cardName.masterofceremonies:
                                case CardDB.CardName.ramwrangler: BeastReq = true; break;
                                case CardDB.CardName.druidofthefang: BeastReq = true; break;
                                case CardDB.CardName.goblinblastmage: MechReq = true; break;
                                case CardDB.CardName.tinkertowntechnician: MechReq = true; break;
                                case CardDB.CardName.shadydealer: if (!target.Ready && target.maxHp == 3) PirateReq = true; break;
                                case CardDB.CardName.gormoktheimpaler: if (p.ownMinions.Count > 4) return 0; break;
                                case CardDB.CardName.corerager: if (p.owncards.Count < 1) return 0; break;
                                case CardDB.CardName.drakonidcrusher: if (p.enemyHero.HealthPoints < 16) return 0; break;
                                case CardDB.CardName.mindcontroltech: if (p.enemyMinions.Count > 3) return 0; break;
                                case CardDB.CardName.alexstraszaschampion: if (target.Ready) DragonReq = false; break;
                                case CardDB.CardName.twilightguardian: if (target.taunt) DragonReq = false; break;
                                case CardDB.CardName.wyrmrestagent: if (target.taunt) DragonReq = false; break;
                                case CardDB.CardName.blackwingtechnician: if (target.maxHp > 4) DragonReq = false; break;
                                case CardDB.CardName.twilightwhelp: if (target.maxHp > 1) DragonReq = false; break;
                                case CardDB.CardName.kingselekk: return 0; break;
                                case CardDB.CardName.gadgetzanjouster: if (target.maxHp == 2) return 0; break;
                                case CardDB.CardName.armoredwarhorse: if (!target.Ready) return 0; break;
                                case CardDB.CardName.masterjouster: if (!target.taunt) return 0; break;
                                case CardDB.CardName.tuskarrjouster: if (!target.Ready && p.ownHero.HealthPoints < 26) return 0; break;
                            }
                        }

                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (this.spellDependentDatabase.ContainsKey(mnn.name) && mnn.entitiyID != target.entitiyID) return 0;
                            if (mnn.name == CardDB.CardName.starvingbuzzard && mnn.entitiyID != target.entitiyID && target.handcard.card.race == 20) return 0;

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
                    if (hc.card.name == CardDB.CardName.kirintormage && p.mana >= hc.getManaCost(p))
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
                case CardDB.CardName.flare: return 0; break; 
                case CardDB.CardName.eaterofsecrets: return 0; break; 
                case CardDB.CardName.kezanmystic: 
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

            if ((c.name == CardDB.CardName.acidicswampooze || c.name == CardDB.CardName.gluttonousooze)
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
                            if (target.handcard.card.battlecry && target.name != CardDB.CardName.kingmukla) pen += 1;
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

        public int getValueOfUsefulNeedKeepPriority(CardDB.CardName name)
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

        public int guessTotalSpellDamage(Playfield p, CardDB.CardName name, bool ownplay)
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
            enrageDatabase.Add(CardDB.CardName.aberrantberserker, 2);
            enrageDatabase.Add(CardDB.CardName.amaniberserker, 3);
            enrageDatabase.Add(CardDB.CardName.angrychicken, 5);
            enrageDatabase.Add(CardDB.CardName.bloodhoofbrave, 3);
            enrageDatabase.Add(CardDB.CardName.grommashhellscream, 6);
            enrageDatabase.Add(CardDB.CardName.ragingworgen, 2);
            enrageDatabase.Add(CardDB.CardName.spitefulsmith, 2);
            enrageDatabase.Add(CardDB.CardName.taurenwarrior, 3);
            enrageDatabase.Add(CardDB.CardName.warbot, 1);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(CardDB.CardName.circleofhealing, 4);//allminions
            HealAllDatabase.Add(CardDB.CardName.darkscalehealer, 2);//all friends
            HealAllDatabase.Add(CardDB.CardName.holynova, 2);//to all own minions
            HealAllDatabase.Add(CardDB.CardName.treeoflife, 1000);//all friends

            HealHeroDatabase.Add(CardDB.CardName.amarawardenofhope, 40);
            HealHeroDatabase.Add(CardDB.CardName.antiquehealbot, 8); //tohero
            HealHeroDatabase.Add(CardDB.CardName.bindingheal, 5);
            HealHeroDatabase.Add(CardDB.CardName.cultapothecary, 2);
            HealHeroDatabase.Add(CardDB.CardName.drainlife, 2);//tohero
            HealHeroDatabase.Add(CardDB.CardName.guardianofkings, 6);//tohero
            HealHeroDatabase.Add(CardDB.CardName.holyfire, 5);//tohero
            HealHeroDatabase.Add(CardDB.CardName.invocationofwater, 12);
            HealHeroDatabase.Add(CardDB.CardName.jinyuwaterspeaker, 6);
            HealHeroDatabase.Add(CardDB.CardName.priestessofelune, 4);//tohero
            HealHeroDatabase.Add(CardDB.CardName.refreshmentvendor, 4);
            HealHeroDatabase.Add(CardDB.CardName.renojackson, 25); //tohero
            HealHeroDatabase.Add(CardDB.CardName.sacrificialpact, 5);//tohero
            HealHeroDatabase.Add(CardDB.CardName.sealoflight, 4); //tohero
            HealHeroDatabase.Add(CardDB.CardName.siphonsoul, 3); //tohero
            HealHeroDatabase.Add(CardDB.CardName.tidalsurge, 4);
            HealHeroDatabase.Add(CardDB.CardName.tournamentmedic, 2);
            HealHeroDatabase.Add(CardDB.CardName.tuskarrjouster, 7);
            HealHeroDatabase.Add(CardDB.CardName.twilightdarkmender, 10);

            HealTargetDatabase.Add(CardDB.CardName.ancestralhealing, 1000);
            HealTargetDatabase.Add(CardDB.CardName.ancientoflore, 5);
            HealTargetDatabase.Add(CardDB.CardName.ancientsecrets, 5);
            HealTargetDatabase.Add(CardDB.CardName.bindingheal, 5);
            HealTargetDatabase.Add(CardDB.CardName.darkshirealchemist, 5);
            HealTargetDatabase.Add(CardDB.CardName.earthenringfarseer, 3);
            HealTargetDatabase.Add(CardDB.CardName.flashheal, 5);
            HealTargetDatabase.Add(CardDB.CardName.forbiddenhealing, 2);
            HealTargetDatabase.Add(CardDB.CardName.gadgetzansocialite, 2);
            HealTargetDatabase.Add(CardDB.CardName.heal, 4);
            HealTargetDatabase.Add(CardDB.CardName.healingtouch, 8);
            HealTargetDatabase.Add(CardDB.CardName.healingwave, 14);
            HealTargetDatabase.Add(CardDB.CardName.holylight, 6);
            HealTargetDatabase.Add(CardDB.CardName.hotspringguardian, 3);
            HealTargetDatabase.Add(CardDB.CardName.hozenhealer, 30);
            HealTargetDatabase.Add(CardDB.CardName.layonhands, 8);
            HealTargetDatabase.Add(CardDB.CardName.lesserheal, 2);
            HealTargetDatabase.Add(CardDB.CardName.lightofthenaaru, 3);
            HealTargetDatabase.Add(CardDB.CardName.moongladeportal, 6);
            HealTargetDatabase.Add(CardDB.CardName.voodoodoctor, 2);
            HealTargetDatabase.Add(CardDB.CardName.willofmukla, 8);
            //HealTargetDatabase.Add(CardDB.cardName.divinespirit, 2);
        }

        private void setupDamageDatabase()
        {
            //DamageAllDatabase.Add(CardDB.cardName.flameleviathan, 2);
            DamageAllDatabase.Add(CardDB.CardName.abomination, 2);
            DamageAllDatabase.Add(CardDB.CardName.abyssalenforcer, 3);
            DamageAllDatabase.Add(CardDB.CardName.anomalus, 8);
            DamageAllDatabase.Add(CardDB.CardName.barongeddon, 2);
            DamageAllDatabase.Add(CardDB.CardName.corruptedseer, 2);
            DamageAllDatabase.Add(CardDB.CardName.demonwrath, 1);
            DamageAllDatabase.Add(CardDB.CardName.dragonfirepotion, 5);
            DamageAllDatabase.Add(CardDB.CardName.dreadinfernal, 1);
            DamageAllDatabase.Add(CardDB.CardName.dreadscale, 1);
            DamageAllDatabase.Add(CardDB.CardName.elementaldestruction, 4);
            DamageAllDatabase.Add(CardDB.CardName.excavatedevil, 3);
            DamageAllDatabase.Add(CardDB.CardName.explosivesheep, 2);
            DamageAllDatabase.Add(CardDB.CardName.felbloom, 4);
            DamageAllDatabase.Add(CardDB.CardName.felfirepotion, 5);
            DamageAllDatabase.Add(CardDB.CardName.hellfire, 3);
            DamageAllDatabase.Add(CardDB.CardName.lava, 2);
            DamageAllDatabase.Add(CardDB.CardName.lightbomb, 5);
            DamageAllDatabase.Add(CardDB.CardName.magmapulse, 1);
            DamageAllDatabase.Add(CardDB.CardName.primordialdrake, 2);
            DamageAllDatabase.Add(CardDB.CardName.ravagingghoul, 1);
            DamageAllDatabase.Add(CardDB.CardName.revenge, 1);
            DamageAllDatabase.Add(CardDB.CardName.scarletpurifier, 2);
            DamageAllDatabase.Add(CardDB.CardName.sleepwiththefishes, 3);
            DamageAllDatabase.Add(CardDB.CardName.tentacleofnzoth, 1);
            DamageAllDatabase.Add(CardDB.CardName.unstableghoul, 1);
            DamageAllDatabase.Add(CardDB.CardName.volcanicpotion, 2);
            DamageAllDatabase.Add(CardDB.CardName.whirlwind, 1);
            DamageAllDatabase.Add(CardDB.CardName.yseraawakens, 5);
            DamageAllDatabase.Add(CardDB.CardName.spiritlash, 1);
            DamageAllDatabase.Add(CardDB.CardName.defile, 1);
            DamageAllDatabase.Add(CardDB.CardName.bloodrazor, 1);
            DamageAllDatabase.Add(CardDB.CardName.bladestorm, 1);

            DamageAllEnemysDatabase.Add(CardDB.CardName.arcaneexplosion, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.bladeflurry, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.blizzard, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.consecration, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.cthun, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.darkironskulker, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.fanofknives, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.flamestrike, 4);
            DamageAllEnemysDatabase.Add(CardDB.CardName.holynova, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.invocationofair, 3);
            DamageAllEnemysDatabase.Add(CardDB.CardName.lightningstorm, 3);
            DamageAllEnemysDatabase.Add(CardDB.CardName.livingbomb, 5);
            DamageAllEnemysDatabase.Add(CardDB.CardName.locustswarm, 3);
            DamageAllEnemysDatabase.Add(CardDB.CardName.maelstromportal, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.poisoncloud, 1);//todo 1 or 2
            DamageAllEnemysDatabase.Add(CardDB.CardName.sergeantsally, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.shadowflame, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.sporeburst, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.starfall, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.stomp, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.swipe, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.twilightflamecaller, 1);
            DamageAllEnemysDatabase.Add(CardDB.CardName.explodingbloatbat, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.deathstalkerrexxar, 2);
            DamageAllEnemysDatabase.Add(CardDB.CardName.deathanddecay, 3);
            DamageAllEnemysDatabase.Add(CardDB.CardName.bonestorm, 1);

            DamageHeroDatabase.Add(CardDB.CardName.backstreetleper, 2);
            DamageHeroDatabase.Add(CardDB.CardName.burningadrenaline, 2);
            DamageHeroDatabase.Add(CardDB.CardName.curseofrafaam, 2);
            DamageHeroDatabase.Add(CardDB.CardName.emeraldreaver, 1);
            DamageHeroDatabase.Add(CardDB.CardName.frostblast, 3);
            DamageHeroDatabase.Add(CardDB.CardName.headcrack, 2);
            DamageHeroDatabase.Add(CardDB.CardName.invocationoffire, 6);
            DamageHeroDatabase.Add(CardDB.CardName.lepergnome, 2);
            DamageHeroDatabase.Add(CardDB.CardName.mindblast, 5);
            DamageHeroDatabase.Add(CardDB.CardName.necroticaura, 3);
            DamageHeroDatabase.Add(CardDB.CardName.nightblade, 3);
            DamageHeroDatabase.Add(CardDB.CardName.purecold, 8);
            DamageHeroDatabase.Add(CardDB.CardName.shadowbomber, 3);
            DamageHeroDatabase.Add(CardDB.CardName.sinisterstrike, 3);

            DamageRandomDatabase.Add(CardDB.CardName.arcanemissiles, 1);
            DamageRandomDatabase.Add(CardDB.CardName.avengingwrath, 1);
            DamageRandomDatabase.Add(CardDB.CardName.bomblobber, 4);
            DamageRandomDatabase.Add(CardDB.CardName.boombot, 1);
            DamageRandomDatabase.Add(CardDB.CardName.boombotjr, 1);
            DamageRandomDatabase.Add(CardDB.CardName.bouncingblade, 1);
            DamageRandomDatabase.Add(CardDB.CardName.cleave, 2);
            DamageRandomDatabase.Add(CardDB.CardName.demolisher, 2);
            DamageRandomDatabase.Add(CardDB.CardName.dieinsect, 8);
            DamageRandomDatabase.Add(CardDB.CardName.dieinsects, 8);
            DamageRandomDatabase.Add(CardDB.CardName.fierybat, 1);
            DamageRandomDatabase.Add(CardDB.CardName.flamecannon, 4);
            DamageRandomDatabase.Add(CardDB.CardName.flamejuggler, 1);
            DamageRandomDatabase.Add(CardDB.CardName.flamewaker, 2);
            DamageRandomDatabase.Add(CardDB.CardName.forkedlightning, 2);
            DamageRandomDatabase.Add(CardDB.CardName.goblinblastmage, 1);
            DamageRandomDatabase.Add(CardDB.CardName.greaterarcanemissiles, 3);
            DamageRandomDatabase.Add(CardDB.CardName.hugetoad, 1);
            DamageRandomDatabase.Add(CardDB.CardName.knifejuggler, 1);
            DamageRandomDatabase.Add(CardDB.CardName.madbomber, 1);
            DamageRandomDatabase.Add(CardDB.CardName.madderbomber, 1);
            DamageRandomDatabase.Add(CardDB.CardName.multishot, 3);
            DamageRandomDatabase.Add(CardDB.CardName.ragnarosthefirelord, 8);
            DamageRandomDatabase.Add(CardDB.CardName.rumblingelemental, 1);
            DamageRandomDatabase.Add(CardDB.CardName.shadowboxer, 1);
            DamageRandomDatabase.Add(CardDB.CardName.shipscannon, 2);
            DamageRandomDatabase.Add(CardDB.CardName.spreadingmadness, 1);
            DamageRandomDatabase.Add(CardDB.CardName.throwrocks, 3);
            DamageRandomDatabase.Add(CardDB.CardName.timepieceofhorror, 1);
            DamageRandomDatabase.Add(CardDB.CardName.volatileelemental, 3);
            DamageRandomDatabase.Add(CardDB.CardName.volcano, 1);
            DamageRandomDatabase.Add(CardDB.CardName.breathofsindragosa, 2);
            DamageRandomDatabase.Add(CardDB.CardName.blackguard, 3);

            DamageTargetDatabase.Add(CardDB.CardName.arcaneblast, 2);
            DamageTargetDatabase.Add(CardDB.CardName.arcaneshot, 2);
            DamageTargetDatabase.Add(CardDB.CardName.backstab, 2);
            DamageTargetDatabase.Add(CardDB.CardName.ballistashot, 3);
            DamageTargetDatabase.Add(CardDB.CardName.barreltoss, 2);
            DamageTargetDatabase.Add(CardDB.CardName.betrayal, 2);
            DamageTargetDatabase.Add(CardDB.CardName.blackwingcorruptor, 3);//if dragon in hand
            DamageTargetDatabase.Add(CardDB.CardName.blazecaller, 5);
            DamageTargetDatabase.Add(CardDB.CardName.blowgillsniper, 1);
            DamageTargetDatabase.Add(CardDB.CardName.bombsquad, 5);
            DamageTargetDatabase.Add(CardDB.CardName.cobrashot, 3);
            DamageTargetDatabase.Add(CardDB.CardName.coneofcold, 1);
            DamageTargetDatabase.Add(CardDB.CardName.crackle, 3);
            DamageTargetDatabase.Add(CardDB.CardName.darkbomb, 3);
            DamageTargetDatabase.Add(CardDB.CardName.discipleofcthun, 2);
            DamageTargetDatabase.Add(CardDB.CardName.dispatchkodo, 2);
            DamageTargetDatabase.Add(CardDB.CardName.dragonsbreath, 4);
            DamageTargetDatabase.Add(CardDB.CardName.drainlife, 2);
            DamageTargetDatabase.Add(CardDB.CardName.elvenarcher, 1);
            DamageTargetDatabase.Add(CardDB.CardName.eviscerate, 2);
            DamageTargetDatabase.Add(CardDB.CardName.explosiveshot, 5);
            DamageTargetDatabase.Add(CardDB.CardName.felcannon, 2);
            DamageTargetDatabase.Add(CardDB.CardName.fireball, 6);
            DamageTargetDatabase.Add(CardDB.CardName.fireblast, 1);
            DamageTargetDatabase.Add(CardDB.CardName.fireblastrank2, 2);
            DamageTargetDatabase.Add(CardDB.CardName.firebloomtoxin, 2);
            DamageTargetDatabase.Add(CardDB.CardName.fireelemental, 3);
            DamageTargetDatabase.Add(CardDB.CardName.firelandsportal, 5);
            DamageTargetDatabase.Add(CardDB.CardName.fireplumephoenix, 2);
            DamageTargetDatabase.Add(CardDB.CardName.flamelance, 8);
            DamageTargetDatabase.Add(CardDB.CardName.forbiddenflame, 1);
            DamageTargetDatabase.Add(CardDB.CardName.forgottentorch, 3);
            DamageTargetDatabase.Add(CardDB.CardName.frostbolt, 3);
            DamageTargetDatabase.Add(CardDB.CardName.frostshock, 1);
            DamageTargetDatabase.Add(CardDB.CardName.gormoktheimpaler, 4);
            DamageTargetDatabase.Add(CardDB.CardName.greaterhealingpotion, 12);
            DamageTargetDatabase.Add(CardDB.CardName.grievousbite, 2);
            DamageTargetDatabase.Add(CardDB.CardName.heartoffire, 5);
            DamageTargetDatabase.Add(CardDB.CardName.hoggersmash, 4);
            DamageTargetDatabase.Add(CardDB.CardName.holyfire, 5);
            DamageTargetDatabase.Add(CardDB.CardName.holysmite, 2);
            DamageTargetDatabase.Add(CardDB.CardName.icelance, 4);//only if iced
            DamageTargetDatabase.Add(CardDB.CardName.implosion, 2);
            DamageTargetDatabase.Add(CardDB.CardName.ironforgerifleman, 1);
            DamageTargetDatabase.Add(CardDB.CardName.jadelightning, 4);
            DamageTargetDatabase.Add(CardDB.CardName.jadeshuriken, 2);
            DamageTargetDatabase.Add(CardDB.CardName.keeperofthegrove, 2);
            DamageTargetDatabase.Add(CardDB.CardName.killcommand, 3);//or 5
            DamageTargetDatabase.Add(CardDB.CardName.lavaburst, 5);
            DamageTargetDatabase.Add(CardDB.CardName.lavashock, 2);
            DamageTargetDatabase.Add(CardDB.CardName.lightningbolt, 3);
            DamageTargetDatabase.Add(CardDB.CardName.lightningjolt, 2);
            DamageTargetDatabase.Add(CardDB.CardName.livingroots, 2);//choice 1
            DamageTargetDatabase.Add(CardDB.CardName.medivhsvalet, 3);
            DamageTargetDatabase.Add(CardDB.CardName.cloudprince, 6);
            DamageTargetDatabase.Add(CardDB.CardName.meteor, 15);
            DamageTargetDatabase.Add(CardDB.CardName.mindshatter, 3);
            DamageTargetDatabase.Add(CardDB.CardName.mindspike, 2);
            DamageTargetDatabase.Add(CardDB.CardName.moonfire, 1); 
            DamageTargetDatabase.Add(CardDB.CardName.mortalcoil, 1);
            DamageTargetDatabase.Add(CardDB.CardName.mortalstrike, 4);
            DamageTargetDatabase.Add(CardDB.CardName.northseakraken, 4);
            DamageTargetDatabase.Add(CardDB.CardName.onthehunt, 1);
            DamageTargetDatabase.Add(CardDB.CardName.perditionsblade, 1);
            DamageTargetDatabase.Add(CardDB.CardName.powershot, 2);
            DamageTargetDatabase.Add(CardDB.CardName.pyroblast, 10);
            DamageTargetDatabase.Add(CardDB.CardName.razorpetal, 1);
            DamageTargetDatabase.Add(CardDB.CardName.roaringtorch, 6);
            DamageTargetDatabase.Add(CardDB.CardName.shadowbolt, 4);
            DamageTargetDatabase.Add(CardDB.CardName.shadowform, 2);
            DamageTargetDatabase.Add(CardDB.CardName.shadowstrike, 5);
            DamageTargetDatabase.Add(CardDB.CardName.shotgunblast, 1);
            DamageTargetDatabase.Add(CardDB.CardName.si7agent, 2);
            DamageTargetDatabase.Add(CardDB.CardName.sonicbreath, 3);
            DamageTargetDatabase.Add(CardDB.CardName.sonoftheflame, 6);
            DamageTargetDatabase.Add(CardDB.CardName.starfall, 5);//2 to all enemy
            DamageTargetDatabase.Add(CardDB.CardName.starfire, 5);//draw a card
            DamageTargetDatabase.Add(CardDB.CardName.steadyshot, 2);//or 1 + card
            DamageTargetDatabase.Add(CardDB.CardName.stormcrack, 4);
            DamageTargetDatabase.Add(CardDB.CardName.stormpikecommando, 2);
            DamageTargetDatabase.Add(CardDB.CardName.swipe, 4);//1 to others
            DamageTargetDatabase.Add(CardDB.CardName.tidalsurge, 4);
            DamageTargetDatabase.Add(CardDB.CardName.unbalancingstrike, 3);
            DamageTargetDatabase.Add(CardDB.CardName.undercityvaliant, 1);
            DamageTargetDatabase.Add(CardDB.CardName.wrath, 1);//todo 3 or 1+card
            DamageTargetDatabase.Add(CardDB.CardName.voidform, 2);
            DamageTargetDatabase.Add(CardDB.CardName.vampiricleech, 3);
            DamageTargetDatabase.Add(CardDB.CardName.ultimateinfestation, 5);
            DamageTargetDatabase.Add(CardDB.CardName.toxicarrow, 2);
            DamageTargetDatabase.Add(CardDB.CardName.siphonlife, 3);
            DamageTargetDatabase.Add(CardDB.CardName.icytouch, 1);
            DamageTargetDatabase.Add(CardDB.CardName.iceclaw, 2);
            DamageTargetDatabase.Add(CardDB.CardName.drainsoul, 2);
            DamageTargetDatabase.Add(CardDB.CardName.doomerang, 2);
            DamageTargetDatabase.Add(CardDB.CardName.avalanche, 0);

            DamageTargetSpecialDatabase.Add(CardDB.CardName.baneofdoom, 2); 
            DamageTargetSpecialDatabase.Add(CardDB.CardName.bash, 3); //+3 armor
            DamageTargetSpecialDatabase.Add(CardDB.CardName.bloodtoichor, 1); 
            DamageTargetSpecialDatabase.Add(CardDB.CardName.crueltaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.CardName.deathbloom, 5);
            DamageTargetSpecialDatabase.Add(CardDB.CardName.demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(CardDB.CardName.demonheart, 5);
            DamageTargetSpecialDatabase.Add(CardDB.CardName.earthshock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(CardDB.CardName.feedingtime, 3); 
            DamageTargetSpecialDatabase.Add(CardDB.CardName.flamegeyser, 2); 
            DamageTargetSpecialDatabase.Add(CardDB.CardName.hammerofwrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.CardName.holywrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.CardName.innerrage, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.CardName.quickshot, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.CardName.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.CardName.savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(CardDB.CardName.shieldslam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(CardDB.CardName.shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.CardName.slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(CardDB.CardName.soulfire, 4);//delete a card

            HeroPowerEquipWeapon.Add(CardDB.CardName.daggermastery, 1);
            HeroPowerEquipWeapon.Add(CardDB.CardName.direshapeshift, 2);
            HeroPowerEquipWeapon.Add(CardDB.CardName.echolocate, 0);
            HeroPowerEquipWeapon.Add(CardDB.CardName.enraged, 2);
            HeroPowerEquipWeapon.Add(CardDB.CardName.poisoneddaggers, 2);
            HeroPowerEquipWeapon.Add(CardDB.CardName.shapeshift, 1);
            HeroPowerEquipWeapon.Add(CardDB.CardName.plaguelord, 3);

            
            this.maycauseharmDatabase.Add(CardDB.CardName.arcaneblast, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.arcaneshot, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.backstab, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.baneofdoom, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.barreltoss, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.bash, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.blastcrystalpotion, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.bloodthistletoxin, 3);
            this.maycauseharmDatabase.Add(CardDB.CardName.bloodtoichor, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.chromaticmutation, 5);
            this.maycauseharmDatabase.Add(CardDB.CardName.cobrashot, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.coneofcold, 6);
            this.maycauseharmDatabase.Add(CardDB.CardName.crackle, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.crush, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.darkbomb, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.deathbloom, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.demonfire, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.demonheart, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.dispel, 4);
            this.maycauseharmDatabase.Add(CardDB.CardName.dragonsbreath, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.drainlife, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.drakkisathscommand, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.dream, 3);
            this.maycauseharmDatabase.Add(CardDB.CardName.dynamite, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.earthshock, 4);
            this.maycauseharmDatabase.Add(CardDB.CardName.emergencycoolant, 6);
            this.maycauseharmDatabase.Add(CardDB.CardName.eviscerate, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.explosiveshot, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.feedingtime, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.fireball, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.firebloomtoxin, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.firelandsportal, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.flamegeyser, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.flamelance, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.forbiddenflame, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.forgottentorch, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.frostbolt, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.grievousbite, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.hakkaribloodgoblet, 5);
            this.maycauseharmDatabase.Add(CardDB.CardName.hammerofwrath, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.hex, 5);
            this.maycauseharmDatabase.Add(CardDB.CardName.hoggersmash, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.holyfire, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.holysmite, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.holywrath, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.humility, 7);
            this.maycauseharmDatabase.Add(CardDB.CardName.huntersmark, 7);
            this.maycauseharmDatabase.Add(CardDB.CardName.icelance, 6);
            this.maycauseharmDatabase.Add(CardDB.CardName.implosion, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.innerrage, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.jadelightning, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.jadeshuriken, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.keeperofthegrove, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.killcommand, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.lavaburst, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.lavashock, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.lightningbolt, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.livingroots, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.madbomber, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.madderbomber, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.meteor, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.moonfire, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.mortalcoil, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.mortalstrike, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.mulch, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.naturalize, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.necroticpoison, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.onthehunt, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.polymorph, 5);
            this.maycauseharmDatabase.Add(CardDB.CardName.powershot, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.pyroblast, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.quickshot, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.razorpetal, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.roaringtorch, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.roguesdoit, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.rottenbanana, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.savagery, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.shadowbolt, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.shadowstep, 3);
            this.maycauseharmDatabase.Add(CardDB.CardName.shadowstrike, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.shadowworddeath, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.shadowwordpain, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.shatter, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.shieldslam, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.shiv, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.silence, 4);
            this.maycauseharmDatabase.Add(CardDB.CardName.siphonsoul, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.slam, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.sonicbreath, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.soulfire, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.spreadingmadness, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.starfall, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.starfire, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.stormcrack, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.swipe, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.tailswipe, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.thetruewarchief, 2);
            this.maycauseharmDatabase.Add(CardDB.CardName.tidalsurge, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.timerewinder, 3);
            this.maycauseharmDatabase.Add(CardDB.CardName.volcano, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.wrath, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.drainsoul, 1);
            this.maycauseharmDatabase.Add(CardDB.CardName.obliterate, 2);
        }

        private void setupsilenceDatabase()
        {
            
            this.silenceDatabase.Add(CardDB.CardName.defiascleaner, 1);
            this.silenceDatabase.Add(CardDB.CardName.dispel, 1);
            this.silenceDatabase.Add(CardDB.CardName.earthshock, 1);
            this.silenceDatabase.Add(CardDB.CardName.ironbeakowl, 1);
            this.silenceDatabase.Add(CardDB.CardName.kabalsongstealer, 1);
            this.silenceDatabase.Add(CardDB.CardName.lightschampion, 1);
            this.silenceDatabase.Add(CardDB.CardName.massdispel, 1);
            this.silenceDatabase.Add(CardDB.CardName.purify, -1);
            this.silenceDatabase.Add(CardDB.CardName.silence, 1);
            this.silenceDatabase.Add(CardDB.CardName.spellbreaker, 1);
            this.silenceDatabase.Add(CardDB.CardName.wailingsoul, -2);

            OwnNeedSilenceDatabase.Add(CardDB.CardName.ancientwatcher, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.animagolem, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.bittertidehydra, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.blackknight, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.bombsquad, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.corruptedhealbot, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.dancingswords, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.deathcharger, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.eeriestatue, 0);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.emeraldhivequeen, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.felorcsoulfiend, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.felreaver, 3);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.frozencrusher, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.humongousrazorleaf, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.icehowl, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.mogortheogre, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.natthedarkfisher, 0);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.spectralrider, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.spectraltrainee, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.spectralwarrior, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.spore, 3);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.thebeast, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.unlicensedapothecary, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.unrelentingrider, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.unrelentingtrainee, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.unrelentingwarrior, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.venturecomercenary, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.whiteknight, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.wrathguard, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.zombiechow, 2);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.tickingabomination, 0);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.rattlingrascal, 1);
            OwnNeedSilenceDatabase.Add(CardDB.CardName.masterchest, 1);
        }


        private void setupPriorityList()
        {
            priorityDatabase.Add(CardDB.CardName.acidmaw, 3);
            priorityDatabase.Add(CardDB.CardName.animatedarmor, 2);
            priorityDatabase.Add(CardDB.CardName.archmageantonidas, 6);
            priorityDatabase.Add(CardDB.CardName.aviana, 5);
            priorityDatabase.Add(CardDB.CardName.brannbronzebeard, 4);
            priorityDatabase.Add(CardDB.CardName.cloakedhuntress, 2);
            priorityDatabase.Add(CardDB.CardName.confessorpaletress, 7);
            priorityDatabase.Add(CardDB.CardName.crowdfavorite, 6);
            priorityDatabase.Add(CardDB.CardName.darkshirecouncilman, 2);
            priorityDatabase.Add(CardDB.CardName.direwolfalpha, 6);
            priorityDatabase.Add(CardDB.CardName.emperorthaurissan, 5);
            priorityDatabase.Add(CardDB.CardName.fandralstaghelm, 6);
            priorityDatabase.Add(CardDB.CardName.flametonguetotem, 6);
            priorityDatabase.Add(CardDB.CardName.flamewaker, 5);
            priorityDatabase.Add(CardDB.CardName.frothingberserker, 1);
            priorityDatabase.Add(CardDB.CardName.gadgetzanauctioneer, 1);
            priorityDatabase.Add(CardDB.CardName.grimestreetenforcer, 1);
            priorityDatabase.Add(CardDB.CardName.grimpatron, 5);
            priorityDatabase.Add(CardDB.CardName.grimscaleoracle, 5);
            priorityDatabase.Add(CardDB.CardName.grimygadgeteer, 1);
            priorityDatabase.Add(CardDB.CardName.holychampion, 5);
            priorityDatabase.Add(CardDB.CardName.knifejuggler, 2);
            priorityDatabase.Add(CardDB.CardName.kodorider, 6);
            priorityDatabase.Add(CardDB.CardName.kvaldirraider, 1);
            priorityDatabase.Add(CardDB.CardName.leokk, 5);
            priorityDatabase.Add(CardDB.CardName.lyrathesunshard, 1);
            priorityDatabase.Add(CardDB.CardName.malchezaarsimp, 1);
            priorityDatabase.Add(CardDB.CardName.malganis, 10);
            priorityDatabase.Add(CardDB.CardName.manatidetotem, 5);
            priorityDatabase.Add(CardDB.CardName.mechwarper, 1);
            priorityDatabase.Add(CardDB.CardName.muklaschampion, 5);
            priorityDatabase.Add(CardDB.CardName.murlocknight, 5);
            priorityDatabase.Add(CardDB.CardName.underbellyangler, 5);
            priorityDatabase.Add(CardDB.CardName.murlocwarleader, 5);
            priorityDatabase.Add(CardDB.CardName.nexuschampionsaraad, 6);
            priorityDatabase.Add(CardDB.CardName.northshirecleric, 4);
            priorityDatabase.Add(CardDB.CardName.pintsizedsummoner, 3);
            priorityDatabase.Add(CardDB.CardName.primalfintotem, 5);
            priorityDatabase.Add(CardDB.CardName.prophetvelen, 5);
            priorityDatabase.Add(CardDB.CardName.questingadventurer, 1);
            priorityDatabase.Add(CardDB.CardName.radiantelemental, 3);
            priorityDatabase.Add(CardDB.CardName.ragnaroslightlord, 5);
            priorityDatabase.Add(CardDB.CardName.raidleader, 5);
            priorityDatabase.Add(CardDB.CardName.recruiter, 1);
            priorityDatabase.Add(CardDB.CardName.scavenginghyena, 5);
            priorityDatabase.Add(CardDB.CardName.secretkeeper, 5);
            priorityDatabase.Add(CardDB.CardName.sorcerersapprentice, 3);
            priorityDatabase.Add(CardDB.CardName.southseacaptain, 5);
            priorityDatabase.Add(CardDB.CardName.spiritsingerumbra, 5);
            priorityDatabase.Add(CardDB.CardName.stormwindchampion, 5);
            priorityDatabase.Add(CardDB.CardName.summoningportal, 5);
            priorityDatabase.Add(CardDB.CardName.summoningstone, 5);
            priorityDatabase.Add(CardDB.CardName.thevoraxx, 2);
            priorityDatabase.Add(CardDB.CardName.thunderbluffvaliant, 2);
            priorityDatabase.Add(CardDB.CardName.timberwolf, 5);
            priorityDatabase.Add(CardDB.CardName.tunneltrogg, 1);
            priorityDatabase.Add(CardDB.CardName.viciousfledgling, 4);
            priorityDatabase.Add(CardDB.CardName.violetillusionist, 10);
            priorityDatabase.Add(CardDB.CardName.violetteacher, 1);
            priorityDatabase.Add(CardDB.CardName.warhorsetrainer, 5);
            priorityDatabase.Add(CardDB.CardName.warsongcommander, 5);
            priorityDatabase.Add(CardDB.CardName.wickedwitchdoctor, 5);
            priorityDatabase.Add(CardDB.CardName.wilfredfizzlebang, 1);
            priorityDatabase.Add(CardDB.CardName.rotface, 1);
            priorityDatabase.Add(CardDB.CardName.professorputricide, 1);
            priorityDatabase.Add(CardDB.CardName.moorabi, 1);
        }

        private void setupAttackBuff()
        {
            this.heroAttackBuffDatabase.Add(CardDB.CardName.bite, 4);
            this.heroAttackBuffDatabase.Add(CardDB.CardName.claw, 2);
            this.heroAttackBuffDatabase.Add(CardDB.CardName.evolvespines, 4);
            this.heroAttackBuffDatabase.Add(CardDB.CardName.feralrage, 4);
            this.heroAttackBuffDatabase.Add(CardDB.CardName.heroicstrike, 4);
            this.heroAttackBuffDatabase.Add(CardDB.CardName.gnash, 3);

            this.attackBuffDatabase.Add(CardDB.CardName.abusivesergeant, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.adaptation, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.bananas, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.bestialwrath, 2); // NEVER ON enemy MINION
            this.attackBuffDatabase.Add(CardDB.CardName.blessingofkings, 4);
            this.attackBuffDatabase.Add(CardDB.CardName.blessingofmight, 3);
            this.attackBuffDatabase.Add(CardDB.CardName.bloodfurypotion, 3);
            this.attackBuffDatabase.Add(CardDB.CardName.briarthorntoxin, 3);
            this.attackBuffDatabase.Add(CardDB.CardName.clockworkknight, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.coldblood, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.crueltaskmaster, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.darkirondwarf, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.darkwispers, 5);//choice 2
            this.attackBuffDatabase.Add(CardDB.CardName.demonfuse, 3);
            this.attackBuffDatabase.Add(CardDB.CardName.dinomancy, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.dinosize, 10);
            this.attackBuffDatabase.Add(CardDB.CardName.divinestrength, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.earthenscales, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.explorershat, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.innerrage, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.lancecarrier, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.lanternofpower, 10);
            this.attackBuffDatabase.Add(CardDB.CardName.lightfusedstegodon, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.markofnature, 4);//choice1 
            this.attackBuffDatabase.Add(CardDB.CardName.markofthewild, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.markofyshaarj, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.mutatinginjection, 4);
            this.attackBuffDatabase.Add(CardDB.CardName.nightmare, 5); //destroy minion on next turn
            this.attackBuffDatabase.Add(CardDB.CardName.powerwordtentacles, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.primalfusion, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.rampage, 3);//only damaged minion 
            this.attackBuffDatabase.Add(CardDB.CardName.rockbiterweapon, 3);
            this.attackBuffDatabase.Add(CardDB.CardName.rockpoolhunter, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.screwjankclunker, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.sealofchampions, 3);
            this.attackBuffDatabase.Add(CardDB.CardName.silvermoonportal, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.spikeridgedsteed, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.velenschosen, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.whirlingblades, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.antimagicshell, 2);
            this.attackBuffDatabase.Add(CardDB.CardName.fallensuncleric, 1);
            this.attackBuffDatabase.Add(CardDB.CardName.cryostasis, 3);
            this.attackBuffDatabase.Add(CardDB.CardName.bonemare, 4);
            this.attackBuffDatabase.Add(CardDB.CardName.acherusveteran, 1);
        }

        private void setupHealthBuff()
        {
            //healthBuffDatabase.Add(CardDB.cardName.ancientofwar, 5);//choice2 is only buffing himself!
            //healthBuffDatabase.Add(CardDB.cardName.rooted, 5);
            healthBuffDatabase.Add(CardDB.CardName.adaptation, 1);
            healthBuffDatabase.Add(CardDB.CardName.armorplating, 1);
            healthBuffDatabase.Add(CardDB.CardName.bananas, 1);
            healthBuffDatabase.Add(CardDB.CardName.blessingofkings, 4);
            healthBuffDatabase.Add(CardDB.CardName.clockworkknight, 1);
            healthBuffDatabase.Add(CardDB.CardName.darkwispers, 5);//choice2
            healthBuffDatabase.Add(CardDB.CardName.demonfuse, 3);
            healthBuffDatabase.Add(CardDB.CardName.dinomancy, 2);
            healthBuffDatabase.Add(CardDB.CardName.dinosize, 10);
            healthBuffDatabase.Add(CardDB.CardName.divinestrength, 2);
            healthBuffDatabase.Add(CardDB.CardName.earthenscales, 1);
            healthBuffDatabase.Add(CardDB.CardName.explorershat, 1);
            healthBuffDatabase.Add(CardDB.CardName.lanternofpower, 10);
            healthBuffDatabase.Add(CardDB.CardName.lightfusedstegodon, 1);
            healthBuffDatabase.Add(CardDB.CardName.markofnature, 4);//choice2
            healthBuffDatabase.Add(CardDB.CardName.markofthewild, 2);
            healthBuffDatabase.Add(CardDB.CardName.markofyshaarj, 2);
            healthBuffDatabase.Add(CardDB.CardName.mutatinginjection, 4);
            healthBuffDatabase.Add(CardDB.CardName.nightmare, 5);
            healthBuffDatabase.Add(CardDB.CardName.powerwordshield, 2);
            healthBuffDatabase.Add(CardDB.CardName.powerwordtentacles, 6);
            healthBuffDatabase.Add(CardDB.CardName.primalfusion, 1);
            healthBuffDatabase.Add(CardDB.CardName.rampage, 3);
            healthBuffDatabase.Add(CardDB.CardName.rockpoolhunter, 1);
            healthBuffDatabase.Add(CardDB.CardName.screwjankclunker, 2);
            healthBuffDatabase.Add(CardDB.CardName.silvermoonportal, 2);
            healthBuffDatabase.Add(CardDB.CardName.spikeridgedsteed, 6);
            healthBuffDatabase.Add(CardDB.CardName.upgradedrepairbot, 4);
            healthBuffDatabase.Add(CardDB.CardName.velenschosen, 4);
            healthBuffDatabase.Add(CardDB.CardName.wildwalker, 3);
            healthBuffDatabase.Add(CardDB.CardName.antimagicshell, 2);
            healthBuffDatabase.Add(CardDB.CardName.sunbornevalkyr, 2);
            healthBuffDatabase.Add(CardDB.CardName.fallensuncleric, 1);
            healthBuffDatabase.Add(CardDB.CardName.cryostasis, 3);
            healthBuffDatabase.Add(CardDB.CardName.bonemare, 4);

            tauntBuffDatabase.Add(CardDB.CardName.ancestralhealing, 1);
            tauntBuffDatabase.Add(CardDB.CardName.darkwispers, 1);
            tauntBuffDatabase.Add(CardDB.CardName.markofnature, 1);
            tauntBuffDatabase.Add(CardDB.CardName.markofthewild, 1);
            tauntBuffDatabase.Add(CardDB.CardName.mutatinginjection, 1);
            tauntBuffDatabase.Add(CardDB.CardName.rustyhorn, 1);
            tauntBuffDatabase.Add(CardDB.CardName.sparringpartner, 1);
            tauntBuffDatabase.Add(CardDB.CardName.spikeridgedsteed, 1);
        }

        private void setupCardDrawBattlecry()
        {
            cardDrawBattleCryDatabase.Add(CardDB.CardName.alightinthedarkness, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ancestralknowledge, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ancientoflore, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ancientteachings, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.arcaneintellect, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.archthiefrafaam, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.azuredrake, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.babblingbook, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.battlerage, 0);//only if wounded own minions or hero
            cardDrawBattleCryDatabase.Add(CardDB.CardName.bloodwarriors, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.burgle, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.cabaliststome, 3);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.callpet, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.carnassasbrood, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.chitteringtunneler, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.chooseyourpath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.coldlightoracle, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.commandingshout, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.convert, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.darkpeddler, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.darkshirelibrarian, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.desertcamel, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.divinefavor, 0);//only if enemy has more cards than you
            cardDrawBattleCryDatabase.Add(CardDB.CardName.drakonidoperative, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.echoofmedivh, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.elisestarseeker, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.elitetaurenchieftain, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.etherealconjurer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.excessmana, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.fanofknives, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.farsight, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.fightpromoter, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.finderskeepers, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.firefly, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.flamegeyser, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.flameheart, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.flare, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.freefromamber, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.giftofcards, 1); //choice = 2
            cardDrawBattleCryDatabase.Add(CardDB.CardName.gnomishexperimenter, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.gnomishinventor, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.goldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.gorillabota3, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.grandcrusader, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.grimestreetinformant, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.hallucination, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.hammerofwrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.harrisonjones, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.harvest, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.holywrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.hydrologist, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.iknowaguy, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ivoryknight, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.jeweledmacaw, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.jeweledscarab, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.journeybelow, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.kabalchemist, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.kabalcourier, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.kazakus, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.kingmukla, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.kingsblood, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.kingsbloodtoxin, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.kingselekk, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.layonhands, 3);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.lifetap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.lockandload, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.lotusagents, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.lunarvisions, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.maptothegoldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.markofyshaarj, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.massdispel, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.megafin, 9);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.mimicpod, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.mindpocalypse, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.mindvision, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.mortalcoil, 0);//only if kills
            cardDrawBattleCryDatabase.Add(CardDB.CardName.muklatyrantofthevale, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.museumcurator, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.nefarian, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.neptulon, 4);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.netherspitehistorian, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(CardDB.CardName.noviceengineer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.powerwordshield, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.primalfinlookout, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.primordialglyph, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.purify, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.quickshot, 0);//only if your hand is empty
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ravenidol, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.razorpetallasher, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.razorpetalvolley, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.servantofkalimos, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.shadowcaster, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.shadowoil, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.shadowvisions, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.shieldblock, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.shiv, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.slam, 0); //if survives
            cardDrawBattleCryDatabase.Add(CardDB.CardName.smalltimerecruits, 3);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.solemnvigil, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.soultap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.spellslinger, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.sprint, 4);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.stampede, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.starfire, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.stonehilldefender, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.swashburglar, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.thecurator, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.thistletea, 3);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.thoughtsteal, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.tinkertowntechnician, 0); // If you have a Mech
            cardDrawBattleCryDatabase.Add(CardDB.CardName.tolvirwarden, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.tombspider, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.tortollanforager, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.tortollanprimalist, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.toshley, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.tracking, 1); //NOT SUPPORTED YET
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ungoropack, 5);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.unholyshadow, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.unstableportal, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.varianwrynn, 3);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.wildmagic, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(CardDB.CardName.wrathion, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.xarilpoisonedmind, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ultimateinfestation, 5);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.tomblurker, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.ghastlyconjurer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.deathgrip, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.stitchedtracker, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.rollthebones, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.icefishing, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.howlingcommander, 0);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.frozenclone, 1);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.forgeofsouls, 2);
            cardDrawBattleCryDatabase.Add(CardDB.CardName.devourmind, 3);

            cardDrawDeathrattleDatabase.Add(CardDB.CardName.acolyteofpain, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.anubarak, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.bloodmagethalnos, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.clockworkgnome, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.crystallineoracle, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.dancingswords, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.deadlyfork, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.hook, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.igneouselemental, 2);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.loothoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.meanstreetmarshal, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.mechanicalyeti, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.mechbearcat, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.pollutedhoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.pyros, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.rhonin, 3);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.runicegg, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.shiftingshade, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.shimmeringtempest, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.tentaclesforarms, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.tombpillager, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.toshley, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.undercityhuckster, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.webspinner, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.xarilpoisonedmind, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.shallowgravedigger, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.frozenchampion, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.bonedrake, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.bonebaron, 2);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.arfus, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.CardName.glacialmysteries, 1);
        }


        private void setupUsefulNeedKeepDatabase()
        {
            UsefulNeedKeepDatabase.Add(CardDB.CardName.acidmaw, 4);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.addledgrizzly, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.airelemental, 6);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.alarmobot, 4);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.ancientharbinger, 2);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.animatedarmor, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.archmageantonidas, 7);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.armorsmith, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.aviana, 7);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.backroombouncer, 1);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.bloodimp, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.brannbronzebeard, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.burlyrockjawtrogg, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.cloakedhuntress, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.cobaltguardian, 8);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.coldarradrake, 15);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.confessorpaletress, 32);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.cultmaster, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.cultsorcerer, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.darkshirecouncilman, 0);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.dementedfrostcaller, 15);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.demolisher, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.direwolfalpha, 30);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.dragonkinsorcerer, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.emboldener3000, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.emperorthaurissan, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.faeriedragon, 7);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.fallenhero, 15);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.masterchest, 48);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.fandralstaghelm, 15);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.felcannon, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.flametonguetotem, 30);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.flamewaker, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.flesheatingghoul, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.floatingwatcher, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.frothingberserker, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.gadgetzanauctioneer, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.garrisoncommander, 7);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.gazlowe, 6);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.grimestreetenforcer, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.grimscaleoracle, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.grimygadgeteer, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.gruul, 4);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.hallazealtheascended, 16);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.healingtotem, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.hobgoblin, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.hogger, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.homingchicken, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.illidanstormrage, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.illuminator, 2);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.impmaster, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.ironsensei, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.jeeves, 0);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.junkbot, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.kabaltrafficker, 1);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.kelthuzad, 18);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.knifejuggler, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.kodorider, 20);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.kvaldirraider, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.leokk, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.lightwarden, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.lightwell, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.lyrathesunshard, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.maidenofthelake, 18);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.malchezaarsimp, 0);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.malganis, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.manatidetotem, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.manawyrm, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.masterswordsmith, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.mechwarper, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.mekgineerthermaplugg, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.micromachine, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.moroes, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.muklaschampion, 14);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.murlocknight, 16);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.underbellyangler, 17);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.murloctidecaller, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.murlocwarleader, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.natpagle, 2);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.nexuschampionsaraad, 30);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.northshirecleric, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.obsidiandestroyer, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.pintsizedsummoner, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.priestofthefeast, 3);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.primalfintotem, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.prophetvelen, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.questingadventurer, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.radiantelemental, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.ragnaroslightlord, 19);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.ragnarosthefirelord, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.raidleader, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.recruiter, 15);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.redmanawyrm, 8);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.repairbot, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.rumblingelemental, 7);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.scavenginghyena, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.secretkeeper, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.shadeofnaxxramas, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.shadowboxer, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.shakuthecollector, 25);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.shipscannon, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.siegeengine, 8);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.siltfinspiritwalker, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.silverhandregent, 14);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.sorcerersapprentice, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.southseacaptain, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.spiritsingerumbra, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.starvingbuzzard, 8);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.stonesplintertrogg, 8);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.stormwindchampion, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.summoningportal, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.summoningstone, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.thunderbluffvaliant, 16);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.timberwolf, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.tradeprincegallywix, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.troggzortheearthinator, 4);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.twilightelder, 9);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.undertaker, 8);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.usherofsouls, 2);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.viciousfledgling, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.violetillusionist, 14);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.violetteacher, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.vitalitytotem, 8);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.warhorsetrainer, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.warsongcommander, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.weespellstopper, 11);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.wickedwitchdoctor, 13);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.wilfredfizzlebang, 16);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.windupburglebot, 5);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.youngpriestess, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.shadowascendant, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.festergut, 25);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.drakkarienchanter, 17);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.despicabledreadlord, 14);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.cobaltscalebane, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.valkyrsoulclaimer, 10);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.runeforgehaunter, 1);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.rotface, 26);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.necroticgeist, 12);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.moorabi, 16);
            UsefulNeedKeepDatabase.Add(CardDB.CardName.icewalker, 15);
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(CardDB.CardName.darkbargain, 6);
            cardDiscardDatabase.Add(CardDB.CardName.darkshirelibrarian, 2);
            cardDiscardDatabase.Add(CardDB.CardName.doomguard, 5);
            cardDiscardDatabase.Add(CardDB.CardName.lakkarifelhound, 4);
            cardDiscardDatabase.Add(CardDB.CardName.soulfire, 1);
            cardDiscardDatabase.Add(CardDB.CardName.succubus, 2);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(CardDB.CardName.brawl, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.deathwing, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.golakkacrawler, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.hungrycrab, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.CardName.kingmosh, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.naturalize, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.CardName.ravenouspterrordax, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.sacrificialpact, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.CardName.siphonsoul, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.CardName.shadowflame, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.twistingnether, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.unwillingsacrifice, 0);
            this.destroyOwnDatabase.Add(CardDB.CardName.sanguinereveler, 0);

            this.destroyDatabase.Add(CardDB.CardName.assassinate, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.biggamehunter, 0);
            this.destroyDatabase.Add(CardDB.CardName.bladeofcthun, 0);
            this.destroyDatabase.Add(CardDB.CardName.blastcrystalpotion, 0);
            this.destroyDatabase.Add(CardDB.CardName.bookwyrm, 0);
            this.destroyDatabase.Add(CardDB.CardName.corruption, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.crush, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.darkbargain, 0);
            this.destroyDatabase.Add(CardDB.CardName.deadlyshot, 0);
            this.destroyDatabase.Add(CardDB.CardName.doom, 0);
            this.destroyDatabase.Add(CardDB.CardName.drakkisathscommand, 0);
            this.destroyDatabase.Add(CardDB.CardName.enterthecoliseum, 0);
            this.destroyDatabase.Add(CardDB.CardName.execute, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.hemetnesingwary, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.mindcontrol, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.moatlurker, 1);
            this.destroyDatabase.Add(CardDB.CardName.mulch, 0);
            this.destroyDatabase.Add(CardDB.CardName.necroticpoison, 0);
            this.destroyDatabase.Add(CardDB.CardName.rendblackhand, 0);
            this.destroyDatabase.Add(CardDB.CardName.sabotage, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.shadowworddeath, 0);
            this.destroyDatabase.Add(CardDB.CardName.shadowwordhorror, 0);
            this.destroyDatabase.Add(CardDB.CardName.shadowwordpain, 0);
            this.destroyDatabase.Add(CardDB.CardName.shatter, 0);
            this.destroyDatabase.Add(CardDB.CardName.theblackknight, 0);//not own mins
            this.destroyDatabase.Add(CardDB.CardName.thetruewarchief, 0);
            this.destroyDatabase.Add(CardDB.CardName.vilespineslayer, 0);
            this.destroyDatabase.Add(CardDB.CardName.voidcrusher, 0);
            this.destroyDatabase.Add(CardDB.CardName.obsidianstatue, 0);
            this.destroyDatabase.Add(CardDB.CardName.obliterate, 0);
            this.destroyDatabase.Add(CardDB.CardName.doompact, 0);
        }

        private void setupReturnBackToHandCards()
        {
            returnHandDatabase.Add(CardDB.CardName.ancientbrewmaster, 0);
            returnHandDatabase.Add(CardDB.CardName.bloodthistletoxin, 0);
            returnHandDatabase.Add(CardDB.CardName.dream, 0);
            returnHandDatabase.Add(CardDB.CardName.gadgetzanferryman, 0);
            returnHandDatabase.Add(CardDB.CardName.kidnapper, 0);//if combo
            returnHandDatabase.Add(CardDB.CardName.recycle, 0);
            returnHandDatabase.Add(CardDB.CardName.shadowstep, 0);
            returnHandDatabase.Add(CardDB.CardName.timerewinder, 0);
            returnHandDatabase.Add(CardDB.CardName.vanish, 0);
            returnHandDatabase.Add(CardDB.CardName.youthfulbrewmaster, 0);
        }

        private void setupHeroDamagingAOE()
        {
            this.heroDamagingAoeDatabase.Add(CardDB.CardName.unknown, 0);
        }

        private void setupSpecialMins()
        {
            specialMinions.Add(CardDB.CardName.aberrantberserker, 0);
            specialMinions.Add(CardDB.CardName.abomination, 0);
            specialMinions.Add(CardDB.CardName.acidmaw, 0);
            specialMinions.Add(CardDB.CardName.acolyteofpain, 0);
            specialMinions.Add(CardDB.CardName.addledgrizzly, 0);
            specialMinions.Add(CardDB.CardName.alarmobot, 0);
            specialMinions.Add(CardDB.CardName.amaniberserker, 0);
            specialMinions.Add(CardDB.CardName.ancientharbinger, 0);
            specialMinions.Add(CardDB.CardName.angrychicken, 0);
            specialMinions.Add(CardDB.CardName.animatedarmor, 0);
            specialMinions.Add(CardDB.CardName.anubarak, 0);
            specialMinions.Add(CardDB.CardName.anubarambusher, 0);
            specialMinions.Add(CardDB.CardName.anubisathsentinel, 0);
            specialMinions.Add(CardDB.CardName.arcaneanomaly, 0);
            specialMinions.Add(CardDB.CardName.archmage, 0);
            specialMinions.Add(CardDB.CardName.archmageantonidas, 0);
            specialMinions.Add(CardDB.CardName.armorsmith, 0);
            specialMinions.Add(CardDB.CardName.auchenaisoulpriest, 0);
            specialMinions.Add(CardDB.CardName.aviana, 0);
            specialMinions.Add(CardDB.CardName.axeflinger, 0);
            specialMinions.Add(CardDB.CardName.ayablackpaw, 0);
            specialMinions.Add(CardDB.CardName.azuredrake, 0);
            specialMinions.Add(CardDB.CardName.backroombouncer, 0);
            specialMinions.Add(CardDB.CardName.backstreetleper, 0);
            specialMinions.Add(CardDB.CardName.barongeddon, 0);
            specialMinions.Add(CardDB.CardName.baronrivendare, 0);
            specialMinions.Add(CardDB.CardName.blackwaterpirate, 0);
            specialMinions.Add(CardDB.CardName.bloodhoofbrave, 0);
            specialMinions.Add(CardDB.CardName.bloodimp, 0);
            specialMinions.Add(CardDB.CardName.bloodmagethalnos, 0);
            specialMinions.Add(CardDB.CardName.bolframshield, 0);
            specialMinions.Add(CardDB.CardName.boneguardlieutenant, 0);
            specialMinions.Add(CardDB.CardName.brannbronzebeard, 0);
            specialMinions.Add(CardDB.CardName.bravearcher, 0);
            specialMinions.Add(CardDB.CardName.buccaneer, 0);
            specialMinions.Add(CardDB.CardName.burglybully, 0);
            specialMinions.Add(CardDB.CardName.burlyrockjawtrogg, 0);
            specialMinions.Add(CardDB.CardName.cairnebloodhoof, 0);
            specialMinions.Add(CardDB.CardName.chromaggus, 0);
            specialMinions.Add(CardDB.CardName.chromaticdragonkin, 0);
            specialMinions.Add(CardDB.CardName.cloakedhuntress, 0);
            specialMinions.Add(CardDB.CardName.clockworkgnome, 0);
            specialMinions.Add(CardDB.CardName.cobaltguardian, 0);
            specialMinions.Add(CardDB.CardName.cogmaster, 0);
            specialMinions.Add(CardDB.CardName.coldarradrake, 0);
            specialMinions.Add(CardDB.CardName.coliseummanager, 0);
            specialMinions.Add(CardDB.CardName.confessorpaletress, 0);
            specialMinions.Add(CardDB.CardName.crazedworshipper, 0);
            specialMinions.Add(CardDB.CardName.crowdfavorite, 0);
            specialMinions.Add(CardDB.CardName.crueldinomancer, 0);
            specialMinions.Add(CardDB.CardName.crystallineoracle, 0);
            specialMinions.Add(CardDB.CardName.cthun, 0);
            specialMinions.Add(CardDB.CardName.cultmaster, 0);
            specialMinions.Add(CardDB.CardName.cultsorcerer, 0);
            specialMinions.Add(CardDB.CardName.cutpurse, 0);
            specialMinions.Add(CardDB.CardName.dalaranaspirant, 0);
            specialMinions.Add(CardDB.CardName.dalaranmage, 0);
            specialMinions.Add(CardDB.CardName.dancingswords, 0);
            specialMinions.Add(CardDB.CardName.darkcultist, 0);
            specialMinions.Add(CardDB.CardName.darkshirecouncilman, 0);
            specialMinions.Add(CardDB.CardName.deadlyfork, 0);
            specialMinions.Add(CardDB.CardName.deathlord, 0);
            specialMinions.Add(CardDB.CardName.dementedfrostcaller, 0);
            specialMinions.Add(CardDB.CardName.demolisher, 0);
            specialMinions.Add(CardDB.CardName.direhornhatchling, 0);
            specialMinions.Add(CardDB.CardName.direwolfalpha, 0);
            specialMinions.Add(CardDB.CardName.djinniofzephyrs, 0);
            specialMinions.Add(CardDB.CardName.doomsayer, 0);
            specialMinions.Add(CardDB.CardName.dragonegg, 0);
            specialMinions.Add(CardDB.CardName.dragonhawkrider, 0);
            specialMinions.Add(CardDB.CardName.dragonkinsorcerer, 0);
            specialMinions.Add(CardDB.CardName.dreadscale, 0);
            specialMinions.Add(CardDB.CardName.dreadsteed, 0);
            specialMinions.Add(CardDB.CardName.eggnapper, 0);
            specialMinions.Add(CardDB.CardName.emperorcobra, 0);
            specialMinions.Add(CardDB.CardName.emperorthaurissan, 0);
            specialMinions.Add(CardDB.CardName.etherealarcanist, 0);
            specialMinions.Add(CardDB.CardName.evolvedkobold, 0);
            specialMinions.Add(CardDB.CardName.explosivesheep, 0);
            specialMinions.Add(CardDB.CardName.eydisdarkbane, 0);
            specialMinions.Add(CardDB.CardName.fallenhero, 0);
            specialMinions.Add(CardDB.CardName.fandralstaghelm, 0);
            specialMinions.Add(CardDB.CardName.felcannon, 0);
            specialMinions.Add(CardDB.CardName.feugen, 0);
            specialMinions.Add(CardDB.CardName.finjatheflyingstar, 0);
            specialMinions.Add(CardDB.CardName.fjolalightbane, 0);
            specialMinions.Add(CardDB.CardName.flametonguetotem, 0);
            specialMinions.Add(CardDB.CardName.flamewaker, 0);
            specialMinions.Add(CardDB.CardName.flesheatingghoul, 0);
            specialMinions.Add(CardDB.CardName.floatingwatcher, 0);
            specialMinions.Add(CardDB.CardName.foereaper4000, 0);
            specialMinions.Add(CardDB.CardName.gadgetzanauctioneer, 0);
            specialMinions.Add(CardDB.CardName.gahzrilla, 0);
            specialMinions.Add(CardDB.CardName.garr, 0);
            specialMinions.Add(CardDB.CardName.garrisoncommander, 0);
            specialMinions.Add(CardDB.CardName.gazlowe, 0);
            specialMinions.Add(CardDB.CardName.genzotheshark, 0);
            specialMinions.Add(CardDB.CardName.giantanaconda, 0);
            specialMinions.Add(CardDB.CardName.giantsandworm, 0);
            specialMinions.Add(CardDB.CardName.giantwasp, 0);
            specialMinions.Add(CardDB.CardName.goblinsapper, 0);
            specialMinions.Add(CardDB.CardName.grimestreetenforcer, 0);
            specialMinions.Add(CardDB.CardName.grimpatron, 0);
            specialMinions.Add(CardDB.CardName.grimscaleoracle, 0);
            specialMinions.Add(CardDB.CardName.grimygadgeteer, 0);
            specialMinions.Add(CardDB.CardName.grommashhellscream, 0);
            specialMinions.Add(CardDB.CardName.gruul, 0);
            specialMinions.Add(CardDB.CardName.gurubashiberserker, 0);
            specialMinions.Add(CardDB.CardName.hallazealtheascended, 0);
            specialMinions.Add(CardDB.CardName.harvestgolem, 0);
            specialMinions.Add(CardDB.CardName.hauntedcreeper, 0);
            specialMinions.Add(CardDB.CardName.hobgoblin, 0);
            specialMinions.Add(CardDB.CardName.hogger, 0);
            specialMinions.Add(CardDB.CardName.hoggerdoomofelwynn, 0);
            specialMinions.Add(CardDB.CardName.holychampion, 0);
            specialMinions.Add(CardDB.CardName.hoodedacolyte, 0);
            specialMinions.Add(CardDB.CardName.hugetoad, 0);
            specialMinions.Add(CardDB.CardName.igneouselemental, 0);
            specialMinions.Add(CardDB.CardName.illidanstormrage, 0);
            specialMinions.Add(CardDB.CardName.impgangboss, 0);
            specialMinions.Add(CardDB.CardName.impmaster, 0);
            specialMinions.Add(CardDB.CardName.infestedtauren, 0);
            specialMinions.Add(CardDB.CardName.infestedwolf, 0);
            specialMinions.Add(CardDB.CardName.ironsensei, 0);
            specialMinions.Add(CardDB.CardName.jadeswarmer, 0);
            specialMinions.Add(CardDB.CardName.jeeves, 0);
            specialMinions.Add(CardDB.CardName.junglemoonkin, 0);
            specialMinions.Add(CardDB.CardName.junkbot, 0);
            specialMinions.Add(CardDB.CardName.kabaltrafficker, 0);
            specialMinions.Add(CardDB.CardName.kelthuzad, 0);
            specialMinions.Add(CardDB.CardName.kindlygrandmother, 0);
            specialMinions.Add(CardDB.CardName.knifejuggler, 0);
            specialMinions.Add(CardDB.CardName.knuckles, 0);
            specialMinions.Add(CardDB.CardName.koboldgeomancer, 0);
            specialMinions.Add(CardDB.CardName.kodorider, 0);
            specialMinions.Add(CardDB.CardName.kvaldirraider, 0);
            specialMinions.Add(CardDB.CardName.lepergnome, 0);
            specialMinions.Add(CardDB.CardName.lightspawn, 0);
            specialMinions.Add(CardDB.CardName.lightwarden, 0);
            specialMinions.Add(CardDB.CardName.lightwell, 0);
            specialMinions.Add(CardDB.CardName.loothoarder, 0);
            specialMinions.Add(CardDB.CardName.lorewalkercho, 0);
            specialMinions.Add(CardDB.CardName.lotusassassin, 0);
            specialMinions.Add(CardDB.CardName.lowlysquire, 0);
            specialMinions.Add(CardDB.CardName.lyrathesunshard, 0);
            specialMinions.Add(CardDB.CardName.madscientist, 0);
            specialMinions.Add(CardDB.CardName.maexxna, 0);
            specialMinions.Add(CardDB.CardName.magnatauralpha, 0);
            specialMinions.Add(CardDB.CardName.maidenofthelake, 0);
            specialMinions.Add(CardDB.CardName.majordomoexecutus, 0);
            specialMinions.Add(CardDB.CardName.malchezaarsimp, 0);
            specialMinions.Add(CardDB.CardName.malganis, 0);
            specialMinions.Add(CardDB.CardName.malorne, 0);
            specialMinions.Add(CardDB.CardName.malygos, 0);
            specialMinions.Add(CardDB.CardName.manaaddict, 0);
            specialMinions.Add(CardDB.CardName.manageode, 0);
            specialMinions.Add(CardDB.CardName.manatidetotem, 0);
            specialMinions.Add(CardDB.CardName.manatreant, 0);
            specialMinions.Add(CardDB.CardName.manawraith, 0);
            specialMinions.Add(CardDB.CardName.manawyrm, 0);
            specialMinions.Add(CardDB.CardName.masterswordsmith, 0);
            specialMinions.Add(CardDB.CardName.mechanicalyeti, 0);
            specialMinions.Add(CardDB.CardName.mechbearcat, 0);
            specialMinions.Add(CardDB.CardName.mechwarper, 0);
            specialMinions.Add(CardDB.CardName.mekgineerthermaplugg, 0);
            specialMinions.Add(CardDB.CardName.micromachine, 0);
            specialMinions.Add(CardDB.CardName.mimironshead, 0);
            specialMinions.Add(CardDB.CardName.mistressofpain, 0);
            specialMinions.Add(CardDB.CardName.moroes, 0);
            specialMinions.Add(CardDB.CardName.muklaschampion, 0);
            specialMinions.Add(CardDB.CardName.murlocknight, 0);
            specialMinions.Add(CardDB.CardName.underbellyangler, 0);
            specialMinions.Add(CardDB.CardName.murloctidecaller, 0);
            specialMinions.Add(CardDB.CardName.murlocwarleader, 0);
            specialMinions.Add(CardDB.CardName.natpagle, 0);
            specialMinions.Add(CardDB.CardName.nerubarweblord, 0);
            specialMinions.Add(CardDB.CardName.nexuschampionsaraad, 0);
            specialMinions.Add(CardDB.CardName.northshirecleric, 0);
            specialMinions.Add(CardDB.CardName.obsidiandestroyer, 0);
            specialMinions.Add(CardDB.CardName.ogremagi, 0);
            specialMinions.Add(CardDB.CardName.oldmurkeye, 0);
            specialMinions.Add(CardDB.CardName.orgrimmaraspirant, 0);
            specialMinions.Add(CardDB.CardName.patientassassin, 0);
            specialMinions.Add(CardDB.CardName.pilotedshredder, 0);
            specialMinions.Add(CardDB.CardName.pilotedskygolem, 0);
            specialMinions.Add(CardDB.CardName.pintsizedsummoner, 0);
            specialMinions.Add(CardDB.CardName.pitsnake, 0);
            specialMinions.Add(CardDB.CardName.possessedvillager, 0);
            specialMinions.Add(CardDB.CardName.priestofthefeast, 0);
            specialMinions.Add(CardDB.CardName.primalfinchampion, 0);
            specialMinions.Add(CardDB.CardName.primalfintotem, 0);
            specialMinions.Add(CardDB.CardName.prophetvelen, 0);
            specialMinions.Add(CardDB.CardName.pyros, 0);
            specialMinions.Add(CardDB.CardName.questingadventurer, 0);
            specialMinions.Add(CardDB.CardName.radiantelemental, 0);
            specialMinions.Add(CardDB.CardName.ragingworgen, 0);
            specialMinions.Add(CardDB.CardName.ragnaroslightlord, 0);
            specialMinions.Add(CardDB.CardName.raidleader, 0);
            specialMinions.Add(CardDB.CardName.raptorhatchling, 0);
            specialMinions.Add(CardDB.CardName.ratpack, 0);
            specialMinions.Add(CardDB.CardName.recruiter, 0);
            specialMinions.Add(CardDB.CardName.redmanawyrm, 0);
            specialMinions.Add(CardDB.CardName.rumblingelemental, 0);
            specialMinions.Add(CardDB.CardName.satedthreshadon, 0);
            specialMinions.Add(CardDB.CardName.savagecombatant, 0);
            specialMinions.Add(CardDB.CardName.savannahhighmane, 0);
            specialMinions.Add(CardDB.CardName.scalednightmare, 0);
            specialMinions.Add(CardDB.CardName.scavenginghyena, 0);
            specialMinions.Add(CardDB.CardName.secretkeeper, 0);
            specialMinions.Add(CardDB.CardName.selflesshero, 0);
            specialMinions.Add(CardDB.CardName.sergeantsally, 0);
            specialMinions.Add(CardDB.CardName.shadeofnaxxramas, 0);
            specialMinions.Add(CardDB.CardName.shadowboxer, 0);
            specialMinions.Add(CardDB.CardName.shadowfiend, 0);
            specialMinions.Add(CardDB.CardName.shakuthecollector, 0);
            specialMinions.Add(CardDB.CardName.sherazincorpseflower, 0);
            specialMinions.Add(CardDB.CardName.shiftingshade, 0);
            specialMinions.Add(CardDB.CardName.shimmeringtempest, 0);
            specialMinions.Add(CardDB.CardName.shipscannon, 0);
            specialMinions.Add(CardDB.CardName.siltfinspiritwalker, 0);
            specialMinions.Add(CardDB.CardName.silverhandregent, 0);
            specialMinions.Add(CardDB.CardName.smalltimebuccaneer, 0);
            specialMinions.Add(CardDB.CardName.sneedsoldshredder, 0);
            specialMinions.Add(CardDB.CardName.snowchugger, 0);
            specialMinions.Add(CardDB.CardName.sorcerersapprentice, 0);
            specialMinions.Add(CardDB.CardName.southseacaptain, 0);
            specialMinions.Add(CardDB.CardName.southseasquidface, 0);
            specialMinions.Add(CardDB.CardName.spawnofnzoth, 0);
            specialMinions.Add(CardDB.CardName.spawnofshadows, 0);
            specialMinions.Add(CardDB.CardName.spiritsingerumbra, 0);
            specialMinions.Add(CardDB.CardName.spitefulsmith, 0);
            specialMinions.Add(CardDB.CardName.stalagg, 0);
            specialMinions.Add(CardDB.CardName.starvingbuzzard, 0);
            specialMinions.Add(CardDB.CardName.steamwheedlesniper, 0);
            specialMinions.Add(CardDB.CardName.stewardofdarkshire, 0);
            specialMinions.Add(CardDB.CardName.stonesplintertrogg, 0);
            specialMinions.Add(CardDB.CardName.stormwindchampion, 0);
            specialMinions.Add(CardDB.CardName.summoningportal, 0);
            specialMinions.Add(CardDB.CardName.summoningstone, 0);
            specialMinions.Add(CardDB.CardName.sylvanaswindrunner, 0);
            specialMinions.Add(CardDB.CardName.tarcreeper, 0);
            specialMinions.Add(CardDB.CardName.tarlord, 0);
            specialMinions.Add(CardDB.CardName.tarlurker, 0);
            specialMinions.Add(CardDB.CardName.taurenwarrior, 0);
            specialMinions.Add(CardDB.CardName.tentacleofnzoth, 0);
            specialMinions.Add(CardDB.CardName.thebeast, 0);
            specialMinions.Add(CardDB.CardName.theboogeymonster, 0);
            specialMinions.Add(CardDB.CardName.thevoraxx, 0);
            specialMinions.Add(CardDB.CardName.thunderbluffvaliant, 0);
            specialMinions.Add(CardDB.CardName.timberwolf, 0);
            specialMinions.Add(CardDB.CardName.tinyknightofevil, 0);
            specialMinions.Add(CardDB.CardName.tirionfordring, 0);
            specialMinions.Add(CardDB.CardName.tortollanshellraiser, 0);
            specialMinions.Add(CardDB.CardName.toshley, 0);
            specialMinions.Add(CardDB.CardName.tournamentmedic, 0);
            specialMinions.Add(CardDB.CardName.tradeprincegallywix, 0);
            specialMinions.Add(CardDB.CardName.troggzortheearthinator, 0);
            specialMinions.Add(CardDB.CardName.tundrarhino, 0);
            specialMinions.Add(CardDB.CardName.tunneltrogg, 0);
            specialMinions.Add(CardDB.CardName.twilightelder, 0);
            specialMinions.Add(CardDB.CardName.twilightsummoner, 0);
            specialMinions.Add(CardDB.CardName.unboundelemental, 0);
            specialMinions.Add(CardDB.CardName.undercityhuckster, 0);
            specialMinions.Add(CardDB.CardName.undertaker, 0);
            specialMinions.Add(CardDB.CardName.unstableghoul, 0);
            specialMinions.Add(CardDB.CardName.usherofsouls, 0);
            specialMinions.Add(CardDB.CardName.viciousfledgling, 0);
            specialMinions.Add(CardDB.CardName.violetillusionist, 0);
            specialMinions.Add(CardDB.CardName.violetteacher, 0);
            specialMinions.Add(CardDB.CardName.vitalitytotem, 0);
            specialMinions.Add(CardDB.CardName.voidcaller, 0);
            specialMinions.Add(CardDB.CardName.voidcrusher, 0);
            specialMinions.Add(CardDB.CardName.volatileelemental, 0);
            specialMinions.Add(CardDB.CardName.warbot, 0);
            specialMinions.Add(CardDB.CardName.warhorsetrainer, 0);
            specialMinions.Add(CardDB.CardName.warsongcommander, 0);
            specialMinions.Add(CardDB.CardName.waterelemental, 0);
            specialMinions.Add(CardDB.CardName.voodoohexxer, 0);
            specialMinions.Add(CardDB.CardName.webspinner, 0);
            specialMinions.Add(CardDB.CardName.whiteeyes, 0);
            specialMinions.Add(CardDB.CardName.wickedwitchdoctor, 0);
            specialMinions.Add(CardDB.CardName.wickerflameburnbristle, 0);
            specialMinions.Add(CardDB.CardName.wilfredfizzlebang, 0);
            specialMinions.Add(CardDB.CardName.windupburglebot, 0);
            specialMinions.Add(CardDB.CardName.wobblingrunts, 0);
            specialMinions.Add(CardDB.CardName.xarilpoisonedmind, 0);
            specialMinions.Add(CardDB.CardName.ysera, 0);
            specialMinions.Add(CardDB.CardName.yshaarjrageunbound, 0);
            specialMinions.Add(CardDB.CardName.zealousinitiate, 0);
            specialMinions.Add(CardDB.CardName.vryghoul, 0);
            specialMinions.Add(CardDB.CardName.thelichking, 0);
            specialMinions.Add(CardDB.CardName.skelemancer, 0);
            specialMinions.Add(CardDB.CardName.shallowgravedigger, 0);
            specialMinions.Add(CardDB.CardName.shadowascendant, 0);
            specialMinions.Add(CardDB.CardName.obsidianstatue, 0);
            specialMinions.Add(CardDB.CardName.mountainfirearmor, 0);
            specialMinions.Add(CardDB.CardName.meatwagon, 0);
            specialMinions.Add(CardDB.CardName.hadronox, 0);
            specialMinions.Add(CardDB.CardName.festergut, 0);
            specialMinions.Add(CardDB.CardName.fatespinner, 0);
            specialMinions.Add(CardDB.CardName.explodingbloatbat, 0);
            specialMinions.Add(CardDB.CardName.drakkarienchanter, 0);
            specialMinions.Add(CardDB.CardName.despicabledreadlord, 0);
            specialMinions.Add(CardDB.CardName.deadscaleknight, 0);
            specialMinions.Add(CardDB.CardName.cobaltscalebane, 0);
            specialMinions.Add(CardDB.CardName.chillbladechampion, 0);
            specialMinions.Add(CardDB.CardName.bonedrake, 0);
            specialMinions.Add(CardDB.CardName.bonebaron, 0);
            specialMinions.Add(CardDB.CardName.bloodworm, 0);
            specialMinions.Add(CardDB.CardName.bloodqueenlanathel, 0);
            specialMinions.Add(CardDB.CardName.blackguard, 0);
            specialMinions.Add(CardDB.CardName.arrogantcrusader, 0);
            specialMinions.Add(CardDB.CardName.arfus, 0);
            specialMinions.Add(CardDB.CardName.acolyteofagony, 0);
            specialMinions.Add(CardDB.CardName.abominablebowman, 0);
            specialMinions.Add(CardDB.CardName.venomancer, 0);
            specialMinions.Add(CardDB.CardName.valkyrsoulclaimer, 0);
            specialMinions.Add(CardDB.CardName.stubborngastropod, 0);
            specialMinions.Add(CardDB.CardName.runeforgehaunter, 0);
            specialMinions.Add(CardDB.CardName.rotface, 0);
            specialMinions.Add(CardDB.CardName.professorputricide, 0);
            specialMinions.Add(CardDB.CardName.nighthowler, 0);
            specialMinions.Add(CardDB.CardName.nerubianunraveler, 0);
            specialMinions.Add(CardDB.CardName.necroticgeist, 0);
            specialMinions.Add(CardDB.CardName.moorabi, 0);
            specialMinions.Add(CardDB.CardName.mindbreaker, 0);
            specialMinions.Add(CardDB.CardName.icewalker, 0);
            specialMinions.Add(CardDB.CardName.graveshambler, 0);
            specialMinions.Add(CardDB.CardName.doomedapprentice, 0);
            specialMinions.Add(CardDB.CardName.cryptlord, 0);
            specialMinions.Add(CardDB.CardName.corpsewidow, 0);
        }

        private void setupOwnSummonFromDeathrattle()
        {
            ownSummonFromDeathrattle.Add(CardDB.CardName.anubarak, -10);
            ownSummonFromDeathrattle.Add(CardDB.CardName.ayablackpaw, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.cairnebloodhoof, 5);
            ownSummonFromDeathrattle.Add(CardDB.CardName.crueldinomancer, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.devilsauregg, -20);
            ownSummonFromDeathrattle.Add(CardDB.CardName.dreadsteed, -1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.eggnapper, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.giantanaconda, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.harvestgolem, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.hauntedcreeper, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.infestedtauren, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.infestedwolf, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.jadeswarmer, -1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.kindlygrandmother, -10);
            ownSummonFromDeathrattle.Add(CardDB.CardName.moirabronzebeard, 3);
            ownSummonFromDeathrattle.Add(CardDB.CardName.mountedraptor, 3);
            ownSummonFromDeathrattle.Add(CardDB.CardName.nerubianegg, -16);
            ownSummonFromDeathrattle.Add(CardDB.CardName.pilotedshredder, 4);
            ownSummonFromDeathrattle.Add(CardDB.CardName.pilotedskygolem, 4);
            ownSummonFromDeathrattle.Add(CardDB.CardName.possessedvillager, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.ratpack, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.satedthreshadon, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.savannahhighmane, 8);
            ownSummonFromDeathrattle.Add(CardDB.CardName.sludgebelcher, 10);
            ownSummonFromDeathrattle.Add(CardDB.CardName.sneedsoldshredder, 5);
            ownSummonFromDeathrattle.Add(CardDB.CardName.twilightsummoner, -14);
            ownSummonFromDeathrattle.Add(CardDB.CardName.whiteeyes, -10);
            ownSummonFromDeathrattle.Add(CardDB.CardName.wobblingrunts, 1);
            ownSummonFromDeathrattle.Add(CardDB.CardName.frozenchampion, -12);
        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(CardDB.CardName.abusivesergeant, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.beckonerofevil, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.bladeofcthun, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.bloodsailcultist, 5);
            buffingMinionsDatabase.Add(CardDB.CardName.captaingreenskin, 5);
            buffingMinionsDatabase.Add(CardDB.CardName.cenarius, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.clockworkknight, 2);
            buffingMinionsDatabase.Add(CardDB.CardName.coldlightseer, 3);
            buffingMinionsDatabase.Add(CardDB.CardName.crueltaskmaster, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.cthunschosen, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.cultsorcerer, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.darkarakkoa, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.darkirondwarf, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.defenderofargus, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.direwolfalpha, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.discipleofcthun, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.doomcaller, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.flametonguetotem, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.goblinautobarber, 5);
            buffingMinionsDatabase.Add(CardDB.CardName.grimscaleoracle, 3);
            buffingMinionsDatabase.Add(CardDB.CardName.hoodedacolyte, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.houndmaster, 1);
            buffingMinionsDatabase.Add(CardDB.CardName.lancecarrier, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.leokk, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.malganis, 8);
            buffingMinionsDatabase.Add(CardDB.CardName.metaltoothleaper, 2);
            buffingMinionsDatabase.Add(CardDB.CardName.murlocwarleader, 3);
            buffingMinionsDatabase.Add(CardDB.CardName.quartermaster, 6);
            buffingMinionsDatabase.Add(CardDB.CardName.raidleader, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.screwjankclunker, 2);
            buffingMinionsDatabase.Add(CardDB.CardName.shatteredsuncleric, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.skeramcultist, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.southseacaptain, 4);
            buffingMinionsDatabase.Add(CardDB.CardName.spitefulsmith, 5);
            buffingMinionsDatabase.Add(CardDB.CardName.stormwindchampion, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.templeenforcer, 0);
            buffingMinionsDatabase.Add(CardDB.CardName.thunderbluffvaliant, 9);
            buffingMinionsDatabase.Add(CardDB.CardName.timberwolf, 1);
            buffingMinionsDatabase.Add(CardDB.CardName.upgradedrepairbot, 2);
            buffingMinionsDatabase.Add(CardDB.CardName.usherofsouls, 10);
            buffingMinionsDatabase.Add(CardDB.CardName.warhorsetrainer, 6);
            buffingMinionsDatabase.Add(CardDB.CardName.warsongcommander, 7);
            buffingMinionsDatabase.Add(CardDB.CardName.worshipper, 0);

            buffing1TurnDatabase.Add(CardDB.CardName.abusivesergeant, 0);
            buffing1TurnDatabase.Add(CardDB.CardName.bloodlust, 3);
            buffing1TurnDatabase.Add(CardDB.CardName.darkirondwarf, 0);
            buffing1TurnDatabase.Add(CardDB.CardName.rockbiterweapon, 0);
            buffing1TurnDatabase.Add(CardDB.CardName.worshipper, 0);
        }

        private void setupEnemyTargetPriority()
        {
            priorityTargets.Add(CardDB.CardName.acidmaw, 10);
            priorityTargets.Add(CardDB.CardName.acolyteofpain, 10);
            priorityTargets.Add(CardDB.CardName.addledgrizzly, 10);
            priorityTargets.Add(CardDB.CardName.alarmobot, 10);
            priorityTargets.Add(CardDB.CardName.angrychicken, 10);
            priorityTargets.Add(CardDB.CardName.animatedarmor, 10);
            priorityTargets.Add(CardDB.CardName.anubarak, 10);
            priorityTargets.Add(CardDB.CardName.anubisathsentinel, 10);
            priorityTargets.Add(CardDB.CardName.archmageantonidas, 10);
            priorityTargets.Add(CardDB.CardName.auchenaisoulpriest, 10);
            priorityTargets.Add(CardDB.CardName.auctionmasterbeardo, 10);
            priorityTargets.Add(CardDB.CardName.aviana, 10);
            priorityTargets.Add(CardDB.CardName.ayablackpaw, 10);
            priorityTargets.Add(CardDB.CardName.backroombouncer, 10);
            priorityTargets.Add(CardDB.CardName.barongeddon, 10);
            priorityTargets.Add(CardDB.CardName.baronrivendare, 10);
            priorityTargets.Add(CardDB.CardName.bloodmagethalnos, 10);
            priorityTargets.Add(CardDB.CardName.boneguardlieutenant, 10);
            priorityTargets.Add(CardDB.CardName.brannbronzebeard, 10);
            priorityTargets.Add(CardDB.CardName.burglybully, 10);
            priorityTargets.Add(CardDB.CardName.chromaggus, 10);
            priorityTargets.Add(CardDB.CardName.cloakedhuntress, 10);
            priorityTargets.Add(CardDB.CardName.coldarradrake, 10);
            priorityTargets.Add(CardDB.CardName.confessorpaletress, 10);
            priorityTargets.Add(CardDB.CardName.crowdfavorite, 10);
            priorityTargets.Add(CardDB.CardName.crueldinomancer, 10);
            priorityTargets.Add(CardDB.CardName.crystallineoracle, 10);
            priorityTargets.Add(CardDB.CardName.cthun, 10);
            priorityTargets.Add(CardDB.CardName.cultmaster, 10);
            priorityTargets.Add(CardDB.CardName.cultsorcerer, 10);
            priorityTargets.Add(CardDB.CardName.dalaranaspirant, 10);
            priorityTargets.Add(CardDB.CardName.daringreporter, 10);
            priorityTargets.Add(CardDB.CardName.darkshirecouncilman, 10);
            priorityTargets.Add(CardDB.CardName.dementedfrostcaller, 10);
            priorityTargets.Add(CardDB.CardName.demolisher, 10);
            priorityTargets.Add(CardDB.CardName.devilsauregg, 10);
            priorityTargets.Add(CardDB.CardName.nerubianegg, 10);
            priorityTargets.Add(CardDB.CardName.direhornhatchling, 10);
            priorityTargets.Add(CardDB.CardName.direwolfalpha, 10);
            priorityTargets.Add(CardDB.CardName.djinniofzephyrs, 10);
            priorityTargets.Add(CardDB.CardName.doomsayer, 10);
            priorityTargets.Add(CardDB.CardName.dragonegg, 0);
            priorityTargets.Add(CardDB.CardName.dragonhawkrider, 10);
            priorityTargets.Add(CardDB.CardName.dragonkinsorcerer, 4);
            priorityTargets.Add(CardDB.CardName.dreadscale, 10);
            priorityTargets.Add(CardDB.CardName.dustdevil, 10);
            priorityTargets.Add(CardDB.CardName.eggnapper, 10);
            priorityTargets.Add(CardDB.CardName.emperorthaurissan, 10);
            priorityTargets.Add(CardDB.CardName.etherealarcanist, 10);
            priorityTargets.Add(CardDB.CardName.eydisdarkbane, 10);
            priorityTargets.Add(CardDB.CardName.fallenhero, 10);
            priorityTargets.Add(CardDB.CardName.masterchest, 10);
            priorityTargets.Add(CardDB.CardName.fandralstaghelm, 10);
            priorityTargets.Add(CardDB.CardName.finjatheflyingstar, 10);
            priorityTargets.Add(CardDB.CardName.flametonguetotem, 10);
            priorityTargets.Add(CardDB.CardName.flamewaker, 10);
            priorityTargets.Add(CardDB.CardName.flesheatingghoul, 10);
            priorityTargets.Add(CardDB.CardName.floatingwatcher, 10);
            priorityTargets.Add(CardDB.CardName.foereaper4000, 10);
            priorityTargets.Add(CardDB.CardName.friendlybartender, 10);
            priorityTargets.Add(CardDB.CardName.frothingberserker, 10);
            priorityTargets.Add(CardDB.CardName.gadgetzanauctioneer, 10);
            priorityTargets.Add(CardDB.CardName.gahzrilla, 10);
            priorityTargets.Add(CardDB.CardName.garr, 10);
            priorityTargets.Add(CardDB.CardName.garrisoncommander, 10);
            priorityTargets.Add(CardDB.CardName.genzotheshark, 10);
            priorityTargets.Add(CardDB.CardName.giantanaconda, 10);
            priorityTargets.Add(CardDB.CardName.giantsandworm, 10);
            priorityTargets.Add(CardDB.CardName.grimestreetenforcer, 10);
            priorityTargets.Add(CardDB.CardName.grimpatron, 10);
            priorityTargets.Add(CardDB.CardName.grimygadgeteer, 10);
            priorityTargets.Add(CardDB.CardName.gurubashiberserker, 10);
            priorityTargets.Add(CardDB.CardName.hobgoblin, 10);
            priorityTargets.Add(CardDB.CardName.hogger, 10);
            priorityTargets.Add(CardDB.CardName.hoggerdoomofelwynn, 10);
            priorityTargets.Add(CardDB.CardName.holychampion, 10);
            priorityTargets.Add(CardDB.CardName.hoodedacolyte, 10);
            priorityTargets.Add(CardDB.CardName.igneouselemental, 10);
            priorityTargets.Add(CardDB.CardName.illidanstormrage, 10);
            priorityTargets.Add(CardDB.CardName.impgangboss, 10);
            priorityTargets.Add(CardDB.CardName.impmaster, 10);
            priorityTargets.Add(CardDB.CardName.ironsensei, 10);
            priorityTargets.Add(CardDB.CardName.junglemoonkin, 10);
            priorityTargets.Add(CardDB.CardName.kabaltrafficker, 10);
            priorityTargets.Add(CardDB.CardName.kelthuzad, 10);
            priorityTargets.Add(CardDB.CardName.knifejuggler, 10);
            priorityTargets.Add(CardDB.CardName.knuckles, 10);
            priorityTargets.Add(CardDB.CardName.koboldgeomancer, 10);
            priorityTargets.Add(CardDB.CardName.kodorider, 10);
            priorityTargets.Add(CardDB.CardName.kvaldirraider, 10);
            priorityTargets.Add(CardDB.CardName.leeroyjenkins, 10);
            priorityTargets.Add(CardDB.CardName.leokk, 10);
            priorityTargets.Add(CardDB.CardName.lightwarden, 10);
            priorityTargets.Add(CardDB.CardName.lightwell, 10);
            priorityTargets.Add(CardDB.CardName.lowlysquire, 10);
            priorityTargets.Add(CardDB.CardName.lyrathesunshard, 10);
            priorityTargets.Add(CardDB.CardName.maexxna, 10);
            priorityTargets.Add(CardDB.CardName.maidenofthelake, 10);
            priorityTargets.Add(CardDB.CardName.malchezaarsimp, 10);
            priorityTargets.Add(CardDB.CardName.malganis, 10);
            priorityTargets.Add(CardDB.CardName.malygos, 10);
            priorityTargets.Add(CardDB.CardName.manaaddict, 10);
            priorityTargets.Add(CardDB.CardName.manatidetotem, 10);
            priorityTargets.Add(CardDB.CardName.manatreant, 10);
            priorityTargets.Add(CardDB.CardName.manawyrm, 10);
            priorityTargets.Add(CardDB.CardName.masterswordsmith, 10);
            priorityTargets.Add(CardDB.CardName.mechwarper, 10);
            priorityTargets.Add(CardDB.CardName.micromachine, 10);
            priorityTargets.Add(CardDB.CardName.mogortheogre, 10);
            priorityTargets.Add(CardDB.CardName.moroes, 10);
            priorityTargets.Add(CardDB.CardName.muklaschampion, 10);
            priorityTargets.Add(CardDB.CardName.underbellyangler, 10);
            priorityTargets.Add(CardDB.CardName.murlocknight, 10);
            priorityTargets.Add(CardDB.CardName.natpagle, 10);
            priorityTargets.Add(CardDB.CardName.nerubarweblord, 10);
            priorityTargets.Add(CardDB.CardName.nexuschampionsaraad, 10);
            priorityTargets.Add(CardDB.CardName.northshirecleric, 10);
            priorityTargets.Add(CardDB.CardName.obsidiandestroyer, 10);
            priorityTargets.Add(CardDB.CardName.orgrimmaraspirant, 10);
            priorityTargets.Add(CardDB.CardName.pintsizedsummoner, 10);
            priorityTargets.Add(CardDB.CardName.priestofthefeast, 10);
            priorityTargets.Add(CardDB.CardName.primalfintotem, 10);
            priorityTargets.Add(CardDB.CardName.prophetvelen, 10);
            priorityTargets.Add(CardDB.CardName.pyros, 10);
            priorityTargets.Add(CardDB.CardName.questingadventurer, 10);
            priorityTargets.Add(CardDB.CardName.radiantelemental, 10);
            priorityTargets.Add(CardDB.CardName.ragnaroslightlord, 10);
            priorityTargets.Add(CardDB.CardName.raidleader, 10);
            priorityTargets.Add(CardDB.CardName.raptorhatchling, 10);
            priorityTargets.Add(CardDB.CardName.recruiter, 10);
            priorityTargets.Add(CardDB.CardName.redmanawyrm, 10);
            priorityTargets.Add(CardDB.CardName.rhonin, 10);
            priorityTargets.Add(CardDB.CardName.rumblingelemental, 10);
            priorityTargets.Add(CardDB.CardName.satedthreshadon, 10);
            priorityTargets.Add(CardDB.CardName.savagecombatant, 10);
            priorityTargets.Add(CardDB.CardName.scalednightmare, 10);
            priorityTargets.Add(CardDB.CardName.scavenginghyena, 10);
            priorityTargets.Add(CardDB.CardName.secretkeeper, 10);
            priorityTargets.Add(CardDB.CardName.shadeofnaxxramas, 10);
            priorityTargets.Add(CardDB.CardName.shakuthecollector, 10);
            priorityTargets.Add(CardDB.CardName.sherazincorpseflower, 10);
            priorityTargets.Add(CardDB.CardName.shimmeringtempest, 10);
            priorityTargets.Add(CardDB.CardName.silverhandregent, 10);
            priorityTargets.Add(CardDB.CardName.sorcerersapprentice, 10);
            priorityTargets.Add(CardDB.CardName.spiritsingerumbra, 10);
            priorityTargets.Add(CardDB.CardName.starvingbuzzard, 10);
            priorityTargets.Add(CardDB.CardName.steamwheedlesniper, 10);
            priorityTargets.Add(CardDB.CardName.stormwindchampion, 10);
            priorityTargets.Add(CardDB.CardName.summoningportal, 10);
            priorityTargets.Add(CardDB.CardName.summoningstone, 10);
            priorityTargets.Add(CardDB.CardName.theboogeymonster, 10);
            priorityTargets.Add(CardDB.CardName.thevoraxx, 10);
            priorityTargets.Add(CardDB.CardName.thrallmarfarseer, 10);
            priorityTargets.Add(CardDB.CardName.thunderbluffvaliant, 10);
            priorityTargets.Add(CardDB.CardName.timberwolf, 10);
            priorityTargets.Add(CardDB.CardName.troggzortheearthinator, 10);
            priorityTargets.Add(CardDB.CardName.tundrarhino, 10);
            priorityTargets.Add(CardDB.CardName.tunneltrogg, 10);
            priorityTargets.Add(CardDB.CardName.twilightsummoner, 10);
            priorityTargets.Add(CardDB.CardName.unboundelemental, 10);
            priorityTargets.Add(CardDB.CardName.undertaker, 10);
            priorityTargets.Add(CardDB.CardName.viciousfledgling, 10);
            priorityTargets.Add(CardDB.CardName.violetillusionist, 10);
            priorityTargets.Add(CardDB.CardName.violetteacher, 10);
            priorityTargets.Add(CardDB.CardName.vitalitytotem, 10);
            priorityTargets.Add(CardDB.CardName.warhorsetrainer, 10);
            priorityTargets.Add(CardDB.CardName.warsongcommander, 10);
            priorityTargets.Add(CardDB.CardName.whiteeyes, 10);
            priorityTargets.Add(CardDB.CardName.wickedwitchdoctor, 10);
            priorityTargets.Add(CardDB.CardName.wildpyromancer, 10);
            priorityTargets.Add(CardDB.CardName.wilfredfizzlebang, 10);
            priorityTargets.Add(CardDB.CardName.windupburglebot, 10);
            priorityTargets.Add(CardDB.CardName.youngdragonhawk, 10);
            priorityTargets.Add(CardDB.CardName.yshaarjrageunbound, 10);
            priorityTargets.Add(CardDB.CardName.thelichking, 10);
            priorityTargets.Add(CardDB.CardName.obsidianstatue, 10);
            priorityTargets.Add(CardDB.CardName.moirabronzebeard, 10);
            priorityTargets.Add(CardDB.CardName.highjusticegrimstone, 10);
            priorityTargets.Add(CardDB.CardName.hadronox, 10);
            priorityTargets.Add(CardDB.CardName.festergut, 10);
            priorityTargets.Add(CardDB.CardName.despicabledreadlord, 10);
            priorityTargets.Add(CardDB.CardName.rotface, 10);
            priorityTargets.Add(CardDB.CardName.professorputricide, 10);
            priorityTargets.Add(CardDB.CardName.nighthowler, 10);
            priorityTargets.Add(CardDB.CardName.necroticgeist, 10);
            priorityTargets.Add(CardDB.CardName.moorabi, 10);
            priorityTargets.Add(CardDB.CardName.icewalker, 10);
            priorityTargets.Add(CardDB.CardName.cryptlord, 10);
            priorityTargets.Add(CardDB.CardName.corpsewidow, 10);
        }

        private void setupLethalHelpMinions()
        {
            //spellpower minions
            lethalHelpers.Add(CardDB.CardName.ancientmage, 0);
            lethalHelpers.Add(CardDB.CardName.arcanotron, 0);
            lethalHelpers.Add(CardDB.CardName.archmage, 0);
            lethalHelpers.Add(CardDB.CardName.auchenaisoulpriest, 0);
            lethalHelpers.Add(CardDB.CardName.azuredrake, 0);
            lethalHelpers.Add(CardDB.CardName.bloodmagethalnos, 0);
            lethalHelpers.Add(CardDB.CardName.cultsorcerer, 0);
            lethalHelpers.Add(CardDB.CardName.dalaranaspirant, 0);
            lethalHelpers.Add(CardDB.CardName.dalaranmage, 0);
            lethalHelpers.Add(CardDB.CardName.evolvedkobold, 0);
            lethalHelpers.Add(CardDB.CardName.frigidsnobold, 0);
            lethalHelpers.Add(CardDB.CardName.junglemoonkin, 0);
            lethalHelpers.Add(CardDB.CardName.koboldgeomancer, 0);
            lethalHelpers.Add(CardDB.CardName.malygos, 0);
            lethalHelpers.Add(CardDB.CardName.minimage, 0);
            lethalHelpers.Add(CardDB.CardName.ogremagi, 0);
            lethalHelpers.Add(CardDB.CardName.prophetvelen, 0);
            lethalHelpers.Add(CardDB.CardName.sootspewer, 0);
            lethalHelpers.Add(CardDB.CardName.streettrickster, 0);
            lethalHelpers.Add(CardDB.CardName.wrathofairtotem, 0);
            lethalHelpers.Add(CardDB.CardName.tuskarrfisherman, 0);
            lethalHelpers.Add(CardDB.CardName.taintedzealot, 1);
            lethalHelpers.Add(CardDB.CardName.spellweaver, 2);
        }

        private void setupRelations()
        {
            spellDependentDatabase.Add(CardDB.CardName.arcaneanomaly, 1);
            spellDependentDatabase.Add(CardDB.CardName.archmageantonidas, 2);
            spellDependentDatabase.Add(CardDB.CardName.burglybully, -1);
            spellDependentDatabase.Add(CardDB.CardName.burlyrockjawtrogg, -1);
            spellDependentDatabase.Add(CardDB.CardName.chromaticdragonkin, -1);
            spellDependentDatabase.Add(CardDB.CardName.cultsorcerer, 1);
            spellDependentDatabase.Add(CardDB.CardName.dementedfrostcaller, 1);
            spellDependentDatabase.Add(CardDB.CardName.djinniofzephyrs, 1);
            spellDependentDatabase.Add(CardDB.CardName.flamewaker, 1);
            spellDependentDatabase.Add(CardDB.CardName.gadgetzanauctioneer, 2);
            spellDependentDatabase.Add(CardDB.CardName.gazlowe, 2);
            spellDependentDatabase.Add(CardDB.CardName.hallazealtheascended, 1);
            spellDependentDatabase.Add(CardDB.CardName.lorewalkercho, 0);
            spellDependentDatabase.Add(CardDB.CardName.lyrathesunshard, 2);
            spellDependentDatabase.Add(CardDB.CardName.manaaddict, 1);
            spellDependentDatabase.Add(CardDB.CardName.manawyrm, 1);
            spellDependentDatabase.Add(CardDB.CardName.priestofthefeast, 1);
            spellDependentDatabase.Add(CardDB.CardName.redmanawyrm, 1);
            spellDependentDatabase.Add(CardDB.CardName.stonesplintertrogg, -1);
            spellDependentDatabase.Add(CardDB.CardName.summoningstone, 3);
            spellDependentDatabase.Add(CardDB.CardName.tradeprincegallywix, -1);
            spellDependentDatabase.Add(CardDB.CardName.troggzortheearthinator, -2);
            spellDependentDatabase.Add(CardDB.CardName.violetteacher, 3);
            spellDependentDatabase.Add(CardDB.CardName.wickedwitchdoctor, 3);
            spellDependentDatabase.Add(CardDB.CardName.wildpyromancer, 1);

            dragonDependentDatabase.Add(CardDB.CardName.alexstraszaschampion, 1);
            dragonDependentDatabase.Add(CardDB.CardName.blackwingcorruptor, 1);
            dragonDependentDatabase.Add(CardDB.CardName.blackwingtechnician, 1);
            dragonDependentDatabase.Add(CardDB.CardName.bookwyrm, 1);
            dragonDependentDatabase.Add(CardDB.CardName.drakonidoperative, 1);
            dragonDependentDatabase.Add(CardDB.CardName.netherspitehistorian, 1);
            dragonDependentDatabase.Add(CardDB.CardName.nightbanetemplar, 1);
            dragonDependentDatabase.Add(CardDB.CardName.rendblackhand, 1);
            dragonDependentDatabase.Add(CardDB.CardName.twilightguardian, 1);
            dragonDependentDatabase.Add(CardDB.CardName.twilightwhelp, 1);
            dragonDependentDatabase.Add(CardDB.CardName.wyrmrestagent, 1);

            elementalLTDependentDatabase.Add(CardDB.CardName.blazecaller, 1);
            elementalLTDependentDatabase.Add(CardDB.CardName.kalimosprimallord, 1);
            elementalLTDependentDatabase.Add(CardDB.CardName.ozruk, 1);
            elementalLTDependentDatabase.Add(CardDB.CardName.servantofkalimos, 1);
            elementalLTDependentDatabase.Add(CardDB.CardName.steamsurger, 1);
            elementalLTDependentDatabase.Add(CardDB.CardName.stonesentinel, 1);
            elementalLTDependentDatabase.Add(CardDB.CardName.thunderlizard, 1);
            elementalLTDependentDatabase.Add(CardDB.CardName.tolvirstoneshaper, 1);
        }

        private void setupSilenceTargets()
        {
            silenceTargets.Add(CardDB.CardName.abomination, 0);
            silenceTargets.Add(CardDB.CardName.acidmaw, 0);
            silenceTargets.Add(CardDB.CardName.acolyteofpain, 0);
            silenceTargets.Add(CardDB.CardName.addledgrizzly, 0);
            silenceTargets.Add(CardDB.CardName.ancientharbinger, 0);
            silenceTargets.Add(CardDB.CardName.animatedarmor, 0);
            silenceTargets.Add(CardDB.CardName.anomalus, 0);
            silenceTargets.Add(CardDB.CardName.anubarak, 0);
            silenceTargets.Add(CardDB.CardName.anubisathsentinel, 0);
            silenceTargets.Add(CardDB.CardName.archmageantonidas, 0);
            silenceTargets.Add(CardDB.CardName.armorsmith, 0);
            silenceTargets.Add(CardDB.CardName.auchenaisoulpriest, 0);
            silenceTargets.Add(CardDB.CardName.aviana, 0);
            silenceTargets.Add(CardDB.CardName.axeflinger, 0);
            silenceTargets.Add(CardDB.CardName.ayablackpaw, 0);
            silenceTargets.Add(CardDB.CardName.backroombouncer, 0);
            silenceTargets.Add(CardDB.CardName.barongeddon, 0);
            silenceTargets.Add(CardDB.CardName.baronrivendare, 0);
            silenceTargets.Add(CardDB.CardName.blackwaterpirate, 0);
            silenceTargets.Add(CardDB.CardName.bloodimp, 0);
            silenceTargets.Add(CardDB.CardName.blubberbaron, 0);
            silenceTargets.Add(CardDB.CardName.bolvarfordragon, 0);
            silenceTargets.Add(CardDB.CardName.boneguardlieutenant, 0);
            silenceTargets.Add(CardDB.CardName.brannbronzebeard, 0);
            silenceTargets.Add(CardDB.CardName.bravearcher, 0);
            silenceTargets.Add(CardDB.CardName.burlyrockjawtrogg, 0);
            silenceTargets.Add(CardDB.CardName.cairnebloodhoof, 0);
            silenceTargets.Add(CardDB.CardName.chillmaw, 0);
            silenceTargets.Add(CardDB.CardName.chromaggus, 0);
            silenceTargets.Add(CardDB.CardName.cobaltguardian, 0);
            silenceTargets.Add(CardDB.CardName.coldarradrake, 0);
            silenceTargets.Add(CardDB.CardName.coliseummanager, 0);
            silenceTargets.Add(CardDB.CardName.confessorpaletress, 0);
            silenceTargets.Add(CardDB.CardName.crazedworshipper, 0);
            silenceTargets.Add(CardDB.CardName.crowdfavorite, 0);
            silenceTargets.Add(CardDB.CardName.crueldinomancer, 0);
            silenceTargets.Add(CardDB.CardName.crystallineoracle, 0);
            silenceTargets.Add(CardDB.CardName.cthun, 0);
            silenceTargets.Add(CardDB.CardName.cultmaster, 0);
            silenceTargets.Add(CardDB.CardName.cultsorcerer, 0);
            silenceTargets.Add(CardDB.CardName.dalaranaspirant, 0);
            silenceTargets.Add(CardDB.CardName.darkcultist, 0);
            silenceTargets.Add(CardDB.CardName.darkshirecouncilman, 0);
            silenceTargets.Add(CardDB.CardName.dementedfrostcaller, 0);
            silenceTargets.Add(CardDB.CardName.devilsauregg, 0);
            silenceTargets.Add(CardDB.CardName.nerubianegg, 0);
            silenceTargets.Add(CardDB.CardName.direhornhatchling, 0);
            silenceTargets.Add(CardDB.CardName.direwolfalpha, 0);
            silenceTargets.Add(CardDB.CardName.djinniofzephyrs, 0);
            silenceTargets.Add(CardDB.CardName.doomsayer, 0);
            silenceTargets.Add(CardDB.CardName.dragonegg, 0);
            silenceTargets.Add(CardDB.CardName.dragonhawkrider, 0);
            silenceTargets.Add(CardDB.CardName.dragonkinsorcerer, 0);
            silenceTargets.Add(CardDB.CardName.dreadscale, 0);
            silenceTargets.Add(CardDB.CardName.eggnapper, 0);
            silenceTargets.Add(CardDB.CardName.emboldener3000, 0);
            silenceTargets.Add(CardDB.CardName.emperorcobra, 0);
            silenceTargets.Add(CardDB.CardName.emperorthaurissan, 0);
            silenceTargets.Add(CardDB.CardName.etherealarcanist, 0);
            silenceTargets.Add(CardDB.CardName.evolvedkobold, 0);
            silenceTargets.Add(CardDB.CardName.explosivesheep, 0);
            silenceTargets.Add(CardDB.CardName.eydisdarkbane, 0);
            silenceTargets.Add(CardDB.CardName.fallenhero, 0);
            silenceTargets.Add(CardDB.CardName.masterchest, 0);            
            silenceTargets.Add(CardDB.CardName.fandralstaghelm, 0);
            silenceTargets.Add(CardDB.CardName.feugen, 0);
            silenceTargets.Add(CardDB.CardName.finjatheflyingstar, 0);
            silenceTargets.Add(CardDB.CardName.fjolalightbane, 0);
            silenceTargets.Add(CardDB.CardName.flametonguetotem, 0);
            silenceTargets.Add(CardDB.CardName.flamewaker, 0);
            silenceTargets.Add(CardDB.CardName.flesheatingghoul, 0);
            silenceTargets.Add(CardDB.CardName.floatingwatcher, 0);
            silenceTargets.Add(CardDB.CardName.foereaper4000, 0);
            silenceTargets.Add(CardDB.CardName.frothingberserker, 0);
            silenceTargets.Add(CardDB.CardName.gadgetzanauctioneer, 10);
            silenceTargets.Add(CardDB.CardName.gahzrilla, 0);
            silenceTargets.Add(CardDB.CardName.garr, 0);
            silenceTargets.Add(CardDB.CardName.garrisoncommander, 0);
            silenceTargets.Add(CardDB.CardName.giantanaconda, 0);
            silenceTargets.Add(CardDB.CardName.giantsandworm, 0);
            silenceTargets.Add(CardDB.CardName.giantwasp, 0);
            silenceTargets.Add(CardDB.CardName.grimestreetenforcer, 0);
            silenceTargets.Add(CardDB.CardName.grimpatron, 0);
            silenceTargets.Add(CardDB.CardName.grimscaleoracle, 0);
            silenceTargets.Add(CardDB.CardName.grimygadgeteer, 0);
            silenceTargets.Add(CardDB.CardName.grommashhellscream, 0);
            silenceTargets.Add(CardDB.CardName.gruul, 0);
            silenceTargets.Add(CardDB.CardName.gurubashiberserker, 0);
            silenceTargets.Add(CardDB.CardName.hallazealtheascended, 0);
            silenceTargets.Add(CardDB.CardName.hauntedcreeper, 0);
            silenceTargets.Add(CardDB.CardName.hobgoblin, 0);
            silenceTargets.Add(CardDB.CardName.hogger, 0);
            silenceTargets.Add(CardDB.CardName.hoggerdoomofelwynn, 0);
            silenceTargets.Add(CardDB.CardName.holychampion, 0);
            silenceTargets.Add(CardDB.CardName.homingchicken, 0);
            silenceTargets.Add(CardDB.CardName.hoodedacolyte, 0);
            silenceTargets.Add(CardDB.CardName.igneouselemental, 0);
            silenceTargets.Add(CardDB.CardName.illidanstormrage, 0);
            silenceTargets.Add(CardDB.CardName.impgangboss, 0);
            silenceTargets.Add(CardDB.CardName.impmaster, 0);
            silenceTargets.Add(CardDB.CardName.ironsensei, 0);
            silenceTargets.Add(CardDB.CardName.jadeswarmer, 0);
            silenceTargets.Add(CardDB.CardName.jeeves, 0);
            silenceTargets.Add(CardDB.CardName.junkbot, 0);
            silenceTargets.Add(CardDB.CardName.kabaltrafficker, 0);
            silenceTargets.Add(CardDB.CardName.kelthuzad, 10);
            silenceTargets.Add(CardDB.CardName.kindlygrandmother, 0);
            silenceTargets.Add(CardDB.CardName.knifejuggler, 0);
            silenceTargets.Add(CardDB.CardName.knuckles, 0);
            silenceTargets.Add(CardDB.CardName.kodorider, 0);
            silenceTargets.Add(CardDB.CardName.kvaldirraider, 0);
            silenceTargets.Add(CardDB.CardName.leokk, 0);
            silenceTargets.Add(CardDB.CardName.lightspawn, 0);
            silenceTargets.Add(CardDB.CardName.lightwarden, 0);
            silenceTargets.Add(CardDB.CardName.lightwell, 0);
            silenceTargets.Add(CardDB.CardName.lorewalkercho, 0);
            silenceTargets.Add(CardDB.CardName.lowlysquire, 0);
            silenceTargets.Add(CardDB.CardName.lyrathesunshard, 0);
            silenceTargets.Add(CardDB.CardName.madscientist, 0);
            silenceTargets.Add(CardDB.CardName.maexxna, 0);
            silenceTargets.Add(CardDB.CardName.magnatauralpha, 0);
            silenceTargets.Add(CardDB.CardName.maidenofthelake, 0);
            silenceTargets.Add(CardDB.CardName.majordomoexecutus, 0);
            silenceTargets.Add(CardDB.CardName.malganis, 0);
            silenceTargets.Add(CardDB.CardName.malorne, 0);
            silenceTargets.Add(CardDB.CardName.malygos, 0);
            silenceTargets.Add(CardDB.CardName.manaaddict, 0);
            silenceTargets.Add(CardDB.CardName.manageode, 0);
            silenceTargets.Add(CardDB.CardName.manatidetotem, 0);
            silenceTargets.Add(CardDB.CardName.manatreant, 0);
            silenceTargets.Add(CardDB.CardName.manawraith, 0);
            silenceTargets.Add(CardDB.CardName.manawyrm, 0);
            silenceTargets.Add(CardDB.CardName.masterswordsmith, 0);
            silenceTargets.Add(CardDB.CardName.mekgineerthermaplugg, 0);
            silenceTargets.Add(CardDB.CardName.micromachine, 0);
            silenceTargets.Add(CardDB.CardName.mogortheogre, 0);
            silenceTargets.Add(CardDB.CardName.muklaschampion, 0);
            silenceTargets.Add(CardDB.CardName.murlocknight, 0);
            silenceTargets.Add(CardDB.CardName.underbellyangler, 0);
            silenceTargets.Add(CardDB.CardName.murloctidecaller, 0);
            silenceTargets.Add(CardDB.CardName.murlocwarleader, 0);
            silenceTargets.Add(CardDB.CardName.natpagle, 0);
            silenceTargets.Add(CardDB.CardName.nerubarweblord, 0);
            silenceTargets.Add(CardDB.CardName.nexuschampionsaraad, 0);
            silenceTargets.Add(CardDB.CardName.northshirecleric, 0);
            silenceTargets.Add(CardDB.CardName.obsidiandestroyer, 0);
            silenceTargets.Add(CardDB.CardName.oldmurkeye, 0);
            silenceTargets.Add(CardDB.CardName.oneeyedcheat, 0);
            silenceTargets.Add(CardDB.CardName.orgrimmaraspirant, 0);
            silenceTargets.Add(CardDB.CardName.pilotedskygolem, 0);
            silenceTargets.Add(CardDB.CardName.pitsnake, 0);
            silenceTargets.Add(CardDB.CardName.primalfinchampion, 0);
            silenceTargets.Add(CardDB.CardName.primalfintotem, 0);
            silenceTargets.Add(CardDB.CardName.prophetvelen, 0);
            silenceTargets.Add(CardDB.CardName.pyros, 0);
            silenceTargets.Add(CardDB.CardName.questingadventurer, 0);
            silenceTargets.Add(CardDB.CardName.radiantelemental, 0);
            silenceTargets.Add(CardDB.CardName.ragingworgen, 0);
            silenceTargets.Add(CardDB.CardName.raidleader, 0);
            silenceTargets.Add(CardDB.CardName.raptorhatchling, 0);
            silenceTargets.Add(CardDB.CardName.ratpack, 0);
            silenceTargets.Add(CardDB.CardName.recruiter, 0);
            silenceTargets.Add(CardDB.CardName.redmanawyrm, 0);
            silenceTargets.Add(CardDB.CardName.rhonin, 0);
            silenceTargets.Add(CardDB.CardName.rumblingelemental, 0);
            silenceTargets.Add(CardDB.CardName.satedthreshadon, 0);
            silenceTargets.Add(CardDB.CardName.savagecombatant, 0);
            silenceTargets.Add(CardDB.CardName.savannahhighmane, 0);
            silenceTargets.Add(CardDB.CardName.scalednightmare, 0);
            silenceTargets.Add(CardDB.CardName.scavenginghyena, 0);
            silenceTargets.Add(CardDB.CardName.secretkeeper, 0);
            silenceTargets.Add(CardDB.CardName.selflesshero, 0);
            silenceTargets.Add(CardDB.CardName.sergeantsally, 0);
            silenceTargets.Add(CardDB.CardName.shadeofnaxxramas, 0);
            silenceTargets.Add(CardDB.CardName.shadowboxer, 0);
            silenceTargets.Add(CardDB.CardName.shakuthecollector, 0);
            silenceTargets.Add(CardDB.CardName.sherazincorpseflower, 0);
            silenceTargets.Add(CardDB.CardName.shiftingshade, 0);
            silenceTargets.Add(CardDB.CardName.shimmeringtempest, 0);
            silenceTargets.Add(CardDB.CardName.shipscannon, 0);
            silenceTargets.Add(CardDB.CardName.siegeengine, 0);
            silenceTargets.Add(CardDB.CardName.siltfinspiritwalker, 0);
            silenceTargets.Add(CardDB.CardName.silverhandregent, 0);
            silenceTargets.Add(CardDB.CardName.sneedsoldshredder, 0);
            silenceTargets.Add(CardDB.CardName.sorcerersapprentice, 0);
            silenceTargets.Add(CardDB.CardName.southseacaptain, 0);
            silenceTargets.Add(CardDB.CardName.southseasquidface, 0);
            silenceTargets.Add(CardDB.CardName.spawnofnzoth, 0);
            silenceTargets.Add(CardDB.CardName.spawnofshadows, 0);
            silenceTargets.Add(CardDB.CardName.spiritsingerumbra, 0);
            silenceTargets.Add(CardDB.CardName.spitefulsmith, 0);
            silenceTargets.Add(CardDB.CardName.stalagg, 0);
            silenceTargets.Add(CardDB.CardName.starvingbuzzard, 0);
            silenceTargets.Add(CardDB.CardName.steamwheedlesniper, 0);
            silenceTargets.Add(CardDB.CardName.stewardofdarkshire, 0);
            silenceTargets.Add(CardDB.CardName.stonesplintertrogg, 0);
            silenceTargets.Add(CardDB.CardName.stormwindchampion, 0);
            silenceTargets.Add(CardDB.CardName.summoningportal, 0);
            silenceTargets.Add(CardDB.CardName.summoningstone, 0);
            silenceTargets.Add(CardDB.CardName.sylvanaswindrunner, 0);
            silenceTargets.Add(CardDB.CardName.tarcreeper, 0);
            silenceTargets.Add(CardDB.CardName.tarlord, 0);
            silenceTargets.Add(CardDB.CardName.tarlurker, 0);
            silenceTargets.Add(CardDB.CardName.theboogeymonster, 0);
            silenceTargets.Add(CardDB.CardName.theskeletonknight, 0);
            silenceTargets.Add(CardDB.CardName.thevoraxx, 0);
            silenceTargets.Add(CardDB.CardName.thunderbluffvaliant, 0);
            silenceTargets.Add(CardDB.CardName.timberwolf, 0);
            silenceTargets.Add(CardDB.CardName.tirionfordring, 0);
            silenceTargets.Add(CardDB.CardName.tortollanshellraiser, 0);
            silenceTargets.Add(CardDB.CardName.tournamentmedic, 0);
            silenceTargets.Add(CardDB.CardName.tradeprincegallywix, 0);
            silenceTargets.Add(CardDB.CardName.troggzortheearthinator, 0);
            silenceTargets.Add(CardDB.CardName.tundrarhino, 0);
            silenceTargets.Add(CardDB.CardName.twilightelder, 0);
            silenceTargets.Add(CardDB.CardName.twilightsummoner, 0);
            silenceTargets.Add(CardDB.CardName.unboundelemental, 0);
            silenceTargets.Add(CardDB.CardName.undercityhuckster, 0);
            silenceTargets.Add(CardDB.CardName.undertaker, 0);
            silenceTargets.Add(CardDB.CardName.usherofsouls, 0);
            silenceTargets.Add(CardDB.CardName.v07tr0n, 0);
            silenceTargets.Add(CardDB.CardName.viciousfledgling, 0);
            silenceTargets.Add(CardDB.CardName.violetillusionist, 0);
            silenceTargets.Add(CardDB.CardName.violetteacher, 0);
            silenceTargets.Add(CardDB.CardName.vitalitytotem, 0);
            silenceTargets.Add(CardDB.CardName.voidcrusher, 0);
            silenceTargets.Add(CardDB.CardName.volatileelemental, 0);
            silenceTargets.Add(CardDB.CardName.warhorsetrainer, 0);
            silenceTargets.Add(CardDB.CardName.warsongcommander, 0);
            silenceTargets.Add(CardDB.CardName.webspinner, 0);
            silenceTargets.Add(CardDB.CardName.whiteeyes, 0);
            silenceTargets.Add(CardDB.CardName.wickedwitchdoctor, 0);
            silenceTargets.Add(CardDB.CardName.wilfredfizzlebang, 0);
            silenceTargets.Add(CardDB.CardName.windupburglebot, 0);
            silenceTargets.Add(CardDB.CardName.wobblingrunts, 0);
            silenceTargets.Add(CardDB.CardName.youngpriestess, 0);
            silenceTargets.Add(CardDB.CardName.ysera, 0);
            silenceTargets.Add(CardDB.CardName.yshaarjrageunbound, 0);
            silenceTargets.Add(CardDB.CardName.zealousinitiate, 0);
            silenceTargets.Add(CardDB.CardName.vryghoul, 0);
            silenceTargets.Add(CardDB.CardName.thelichking, 0);
            silenceTargets.Add(CardDB.CardName.skelemancer, 0);
            silenceTargets.Add(CardDB.CardName.shallowgravedigger, 0);
            silenceTargets.Add(CardDB.CardName.shadowascendant, 0);
            silenceTargets.Add(CardDB.CardName.moirabronzebeard, 0);
            silenceTargets.Add(CardDB.CardName.meatwagon, 0);
            silenceTargets.Add(CardDB.CardName.highjusticegrimstone, 0);
            silenceTargets.Add(CardDB.CardName.hadronox, 0);
            silenceTargets.Add(CardDB.CardName.frozenchampion, 0);
            silenceTargets.Add(CardDB.CardName.festergut, 0);
            silenceTargets.Add(CardDB.CardName.fatespinner, 0);
            silenceTargets.Add(CardDB.CardName.explodingbloatbat, 0);
            silenceTargets.Add(CardDB.CardName.drakkarienchanter, 0);
            silenceTargets.Add(CardDB.CardName.despicabledreadlord, 0);
            silenceTargets.Add(CardDB.CardName.cobaltscalebane, 0);
            silenceTargets.Add(CardDB.CardName.bonedrake, 0);
            silenceTargets.Add(CardDB.CardName.bonebaron, 0);
            silenceTargets.Add(CardDB.CardName.blackguard, 0);
            silenceTargets.Add(CardDB.CardName.arrogantcrusader, 0);
            silenceTargets.Add(CardDB.CardName.arfus, 0);
            silenceTargets.Add(CardDB.CardName.abominablebowman, 0);
            silenceTargets.Add(CardDB.CardName.voodoohexxer, 0);
            silenceTargets.Add(CardDB.CardName.venomancer, 0);
            silenceTargets.Add(CardDB.CardName.valkyrsoulclaimer, 0);
            silenceTargets.Add(CardDB.CardName.stubborngastropod, 0);
            silenceTargets.Add(CardDB.CardName.runeforgehaunter, 0);
            silenceTargets.Add(CardDB.CardName.rotface, 0);
            silenceTargets.Add(CardDB.CardName.professorputricide, 0);
            silenceTargets.Add(CardDB.CardName.nighthowler, 0);
            silenceTargets.Add(CardDB.CardName.nerubianunraveler, 0);
            silenceTargets.Add(CardDB.CardName.necroticgeist, 0);
            silenceTargets.Add(CardDB.CardName.moorabi, 0);
            silenceTargets.Add(CardDB.CardName.icewalker, 0);
            silenceTargets.Add(CardDB.CardName.doomedapprentice, 0);
            silenceTargets.Add(CardDB.CardName.cryptlord, 0);
            silenceTargets.Add(CardDB.CardName.corpsewidow, 0);
            silenceTargets.Add(CardDB.CardName.bolvarfireblood, 0);
            silenceTargets.Add(CardDB.CardName.bloodqueenlanathel, 0);
        }

        private void setupRandomCards()
        {
            randomEffects.Add(CardDB.CardName.alightinthedarkness, 1);
            randomEffects.Add(CardDB.CardName.ancestorscall, 1);
            randomEffects.Add(CardDB.CardName.animalcompanion, 1);
            randomEffects.Add(CardDB.CardName.arcanemissiles, 3);
            randomEffects.Add(CardDB.CardName.archthiefrafaam, 1);
            randomEffects.Add(CardDB.CardName.armoredwarhorse, 1);
            randomEffects.Add(CardDB.CardName.avengingwrath, 8);
            randomEffects.Add(CardDB.CardName.babblingbook, 1);
            randomEffects.Add(CardDB.CardName.barnes, 1);
            randomEffects.Add(CardDB.CardName.bomblobber, 1);
            randomEffects.Add(CardDB.CardName.bouncingblade, 3);
            randomEffects.Add(CardDB.CardName.brawl, 1);
            randomEffects.Add(CardDB.CardName.captainsparrot, 1);
            randomEffects.Add(CardDB.CardName.chitteringtunneler, 1);
            randomEffects.Add(CardDB.CardName.chooseyourpath, 1);
            randomEffects.Add(CardDB.CardName.cleave, 2);
            randomEffects.Add(CardDB.CardName.coghammer, 1);
            randomEffects.Add(CardDB.CardName.crackle, 1);
            randomEffects.Add(CardDB.CardName.cthun, 10);
            randomEffects.Add(CardDB.CardName.darkbargain, 2);
            randomEffects.Add(CardDB.CardName.darkpeddler, 1);
            randomEffects.Add(CardDB.CardName.deadlyshot, 1);
            randomEffects.Add(CardDB.CardName.desertcamel, 1);
            randomEffects.Add(CardDB.CardName.elementaldestruction, 1);
            randomEffects.Add(CardDB.CardName.elitetaurenchieftain, 1);
            randomEffects.Add(CardDB.CardName.enhanceomechano, 1);
            randomEffects.Add(CardDB.CardName.etherealconjurer, 1);
            randomEffects.Add(CardDB.CardName.fierybat, 1);
            randomEffects.Add(CardDB.CardName.finderskeepers, 1);
            randomEffects.Add(CardDB.CardName.firelandsportal, 1);
            randomEffects.Add(CardDB.CardName.flamecannon, 1);
            randomEffects.Add(CardDB.CardName.flamejuggler, 1);
            randomEffects.Add(CardDB.CardName.flamewaker, 2);
            randomEffects.Add(CardDB.CardName.forkedlightning, 1);
            randomEffects.Add(CardDB.CardName.freefromamber, 1);
            randomEffects.Add(CardDB.CardName.zarogscrown, 1);
            randomEffects.Add(CardDB.CardName.gelbinmekkatorque, 1);
            randomEffects.Add(CardDB.CardName.glaivezooka, 1);
            randomEffects.Add(CardDB.CardName.grandcrusader, 1);
            randomEffects.Add(CardDB.CardName.greaterarcanemissiles, 3);
            randomEffects.Add(CardDB.CardName.grimestreetinformant, 1);
            randomEffects.Add(CardDB.CardName.hallucination, 1);
            randomEffects.Add(CardDB.CardName.harvest, 1);
            randomEffects.Add(CardDB.CardName.hungrydragon, 1);
            randomEffects.Add(CardDB.CardName.hydrologist, 1);
            randomEffects.Add(CardDB.CardName.iammurloc, 3);
            randomEffects.Add(CardDB.CardName.iknowaguy, 1);
            randomEffects.Add(CardDB.CardName.ironforgeportal, 1);
            randomEffects.Add(CardDB.CardName.ivoryknight, 1);
            randomEffects.Add(CardDB.CardName.jeweledscarab, 1);
            randomEffects.Add(CardDB.CardName.journeybelow, 1);
            randomEffects.Add(CardDB.CardName.kabalchemist, 1);
            randomEffects.Add(CardDB.CardName.kabalcourier, 1);
            randomEffects.Add(CardDB.CardName.kazakus, 1);
            randomEffects.Add(CardDB.CardName.kingsblood, 1);
            randomEffects.Add(CardDB.CardName.lifetap, 1);
            randomEffects.Add(CardDB.CardName.lightningstorm, 1);
            randomEffects.Add(CardDB.CardName.lockandload, 10);
            randomEffects.Add(CardDB.CardName.lotusagents, 1);
            randomEffects.Add(CardDB.CardName.madbomber, 3);
            randomEffects.Add(CardDB.CardName.madderbomber, 1);
            randomEffects.Add(CardDB.CardName.maelstromportal, 1);
            randomEffects.Add(CardDB.CardName.masterjouster, 1);
            randomEffects.Add(CardDB.CardName.menageriemagician, 0);
            randomEffects.Add(CardDB.CardName.mindcontroltech, 1);
            randomEffects.Add(CardDB.CardName.mindgames, 1);
            randomEffects.Add(CardDB.CardName.mindvision, 1);
            randomEffects.Add(CardDB.CardName.mogorschampion, 1);
            randomEffects.Add(CardDB.CardName.mogortheogre, 1);
            randomEffects.Add(CardDB.CardName.moongladeportal, 1);
            randomEffects.Add(CardDB.CardName.multishot, 2);
            randomEffects.Add(CardDB.CardName.museumcurator, 1);
            randomEffects.Add(CardDB.CardName.mysteriouschallenger, 2);
            randomEffects.Add(CardDB.CardName.pileon, 1);
            randomEffects.Add(CardDB.CardName.powerofthehorde, 1);
            randomEffects.Add(CardDB.CardName.primordialglyph, 1);
            randomEffects.Add(CardDB.CardName.ramwrangler, 1);
            randomEffects.Add(CardDB.CardName.ravenidol, 1);
            randomEffects.Add(CardDB.CardName.resurrect, 1);
            randomEffects.Add(CardDB.CardName.sabotage, 0);
            randomEffects.Add(CardDB.CardName.sensedemons, 2);
            randomEffects.Add(CardDB.CardName.servantofkalimos, 1);
            randomEffects.Add(CardDB.CardName.shadowoil, 1);
            randomEffects.Add(CardDB.CardName.shadowvisions, 1);
            randomEffects.Add(CardDB.CardName.silvermoonportal, 1);
            randomEffects.Add(CardDB.CardName.sirfinleymrrgglton, 1);
            randomEffects.Add(CardDB.CardName.soultap, 1);
            randomEffects.Add(CardDB.CardName.spellslinger, 1);
            randomEffects.Add(CardDB.CardName.spreadingmadness, 9);
            randomEffects.Add(CardDB.CardName.stampede, 10);
            randomEffects.Add(CardDB.CardName.stonehilldefender, 1);
            randomEffects.Add(CardDB.CardName.swashburglar, 1);
            randomEffects.Add(CardDB.CardName.timepieceofhorror, 10);
            randomEffects.Add(CardDB.CardName.tinkmasteroverspark, 1);
            randomEffects.Add(CardDB.CardName.tombspider, 1);
            randomEffects.Add(CardDB.CardName.tortollanprimalist, 1);
            randomEffects.Add(CardDB.CardName.totemiccall, 1);
            randomEffects.Add(CardDB.CardName.tuskarrtotemic, 1);
            randomEffects.Add(CardDB.CardName.unholyshadow, 2);
            randomEffects.Add(CardDB.CardName.unstableportal, 1);
            randomEffects.Add(CardDB.CardName.varianwrynn, 2);
            randomEffects.Add(CardDB.CardName.volcano, 15);
            randomEffects.Add(CardDB.CardName.xarilpoisonedmind, 1);
            randomEffects.Add(CardDB.CardName.zoobot, 0);
            randomEffects.Add(CardDB.CardName.tomblurker, 1);
            randomEffects.Add(CardDB.CardName.ghastlyconjurer, 1);
            randomEffects.Add(CardDB.CardName.shadowessence, 1);

        }


        private void setupChooseDatabase()
        {
            this.choose1database.Add(CardDB.CardName.ancientoflore, CardDB.CardIdEnum.NEW1_008a);
            this.choose1database.Add(CardDB.CardName.ancientofwar, CardDB.CardIdEnum.EX1_178b);
            this.choose1database.Add(CardDB.CardName.anodizedrobocub, CardDB.CardIdEnum.GVG_030a);
            this.choose1database.Add(CardDB.CardName.cenarius, CardDB.CardIdEnum.EX1_573a);
            this.choose1database.Add(CardDB.CardName.darkwispers, CardDB.CardIdEnum.GVG_041b);
            this.choose1database.Add(CardDB.CardName.druidoftheclaw, CardDB.CardIdEnum.EX1_165t1);
            this.choose1database.Add(CardDB.CardName.druidoftheflame, CardDB.CardIdEnum.BRM_010t);
            this.choose1database.Add(CardDB.CardName.druidofthesaber, CardDB.CardIdEnum.AT_042t);
            this.choose1database.Add(CardDB.CardName.feralrage, CardDB.CardIdEnum.OG_047a);
            this.choose1database.Add(CardDB.CardName.grovetender, CardDB.CardIdEnum.GVG_032a);
            this.choose1database.Add(CardDB.CardName.jadeidol, CardDB.CardIdEnum.CFM_602a);
            this.choose1database.Add(CardDB.CardName.keeperofthegrove, CardDB.CardIdEnum.EX1_166a);
            this.choose1database.Add(CardDB.CardName.kuntheforgottenking, CardDB.CardIdEnum.CFM_308a);
            this.choose1database.Add(CardDB.CardName.livingroots, CardDB.CardIdEnum.AT_037a);
            this.choose1database.Add(CardDB.CardName.markofnature, CardDB.CardIdEnum.EX1_155a);
            this.choose1database.Add(CardDB.CardName.mirekeeper, CardDB.CardIdEnum.OG_202a);
            this.choose1database.Add(CardDB.CardName.nourish, CardDB.CardIdEnum.EX1_164a);
            this.choose1database.Add(CardDB.CardName.powerofthewild, CardDB.CardIdEnum.EX1_160b);
            this.choose1database.Add(CardDB.CardName.ravenidol, CardDB.CardIdEnum.LOE_115a);
            this.choose1database.Add(CardDB.CardName.shellshifter, CardDB.CardIdEnum.UNG_101t);
            this.choose1database.Add(CardDB.CardName.starfall, CardDB.CardIdEnum.NEW1_007b);
            this.choose1database.Add(CardDB.CardName.wispsoftheoldgods, CardDB.CardIdEnum.OG_195a);
            this.choose1database.Add(CardDB.CardName.wrath, CardDB.CardIdEnum.EX1_154a);
            this.choose1database.Add(CardDB.CardName.malfurionthepestilent, CardDB.CardIdEnum.ICC_832b);
            this.choose1database.Add(CardDB.CardName.plaguelord, CardDB.CardIdEnum.ICC_832pb);
            this.choose1database.Add(CardDB.CardName.druidoftheswarm, CardDB.CardIdEnum.ICC_051t);

            this.choose2database.Add(CardDB.CardName.ancientoflore, CardDB.CardIdEnum.NEW1_008b);
            this.choose2database.Add(CardDB.CardName.ancientofwar, CardDB.CardIdEnum.EX1_178a);
            this.choose2database.Add(CardDB.CardName.anodizedrobocub, CardDB.CardIdEnum.GVG_030b);
            this.choose2database.Add(CardDB.CardName.cenarius, CardDB.CardIdEnum.EX1_573b);
            this.choose2database.Add(CardDB.CardName.darkwispers, CardDB.CardIdEnum.GVG_041a);
            this.choose2database.Add(CardDB.CardName.druidoftheclaw, CardDB.CardIdEnum.EX1_165t2);
            this.choose2database.Add(CardDB.CardName.druidoftheflame, CardDB.CardIdEnum.BRM_010t2);
            this.choose2database.Add(CardDB.CardName.druidofthesaber, CardDB.CardIdEnum.AT_042t2);
            this.choose2database.Add(CardDB.CardName.feralrage, CardDB.CardIdEnum.OG_047b);
            this.choose2database.Add(CardDB.CardName.grovetender, CardDB.CardIdEnum.GVG_032b);
            this.choose2database.Add(CardDB.CardName.jadeidol, CardDB.CardIdEnum.CFM_602b);
            this.choose2database.Add(CardDB.CardName.keeperofthegrove, CardDB.CardIdEnum.EX1_166b);
            this.choose2database.Add(CardDB.CardName.kuntheforgottenking, CardDB.CardIdEnum.CFM_308b);
            this.choose2database.Add(CardDB.CardName.livingroots, CardDB.CardIdEnum.AT_037b);
            this.choose2database.Add(CardDB.CardName.markofnature, CardDB.CardIdEnum.EX1_155b);
            this.choose2database.Add(CardDB.CardName.mirekeeper, CardDB.CardIdEnum.OG_202ae);
            this.choose2database.Add(CardDB.CardName.nourish, CardDB.CardIdEnum.EX1_164b);
            this.choose2database.Add(CardDB.CardName.powerofthewild, CardDB.CardIdEnum.EX1_160t);
            this.choose2database.Add(CardDB.CardName.ravenidol, CardDB.CardIdEnum.LOE_115b);
            this.choose2database.Add(CardDB.CardName.shellshifter, CardDB.CardIdEnum.UNG_101t2);
            this.choose2database.Add(CardDB.CardName.starfall, CardDB.CardIdEnum.NEW1_007a);
            this.choose2database.Add(CardDB.CardName.wispsoftheoldgods, CardDB.CardIdEnum.OG_195b);
            this.choose2database.Add(CardDB.CardName.wrath, CardDB.CardIdEnum.EX1_154b);
            this.choose2database.Add(CardDB.CardName.malfurionthepestilent, CardDB.CardIdEnum.ICC_832a);
            this.choose2database.Add(CardDB.CardName.plaguelord, CardDB.CardIdEnum.ICC_832pa);
            this.choose2database.Add(CardDB.CardName.druidoftheswarm, CardDB.CardIdEnum.ICC_051t2);
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
            GangUpDatabase.Add(CardDB.CardName.addledgrizzly, 1);
            GangUpDatabase.Add(CardDB.CardName.alakirthewindlord, 5);
            GangUpDatabase.Add(CardDB.CardName.aldorpeacekeeper, 5);
            GangUpDatabase.Add(CardDB.CardName.ancientoflore, 5);
            GangUpDatabase.Add(CardDB.CardName.ancientofwar, 5);
            GangUpDatabase.Add(CardDB.CardName.antiquehealbot, 5);
            GangUpDatabase.Add(CardDB.CardName.anubarak, 5);
            GangUpDatabase.Add(CardDB.CardName.archmageantonidas, 3);
            GangUpDatabase.Add(CardDB.CardName.armorsmith, 0);
            GangUpDatabase.Add(CardDB.CardName.ayablackpaw, 5);
            GangUpDatabase.Add(CardDB.CardName.azuredrake, 5);
            GangUpDatabase.Add(CardDB.CardName.baronrivendare, 1);
            GangUpDatabase.Add(CardDB.CardName.biggamehunter, 5);
            GangUpDatabase.Add(CardDB.CardName.biteweed, 5);
            GangUpDatabase.Add(CardDB.CardName.bladeofcthun, 5);
            GangUpDatabase.Add(CardDB.CardName.bloodimp, 1);
            GangUpDatabase.Add(CardDB.CardName.bomblobber, 4);
            GangUpDatabase.Add(CardDB.CardName.boneguardlieutenant, 3);
            GangUpDatabase.Add(CardDB.CardName.burglybully, 0);
            GangUpDatabase.Add(CardDB.CardName.burlyrockjawtrogg, 1);
            GangUpDatabase.Add(CardDB.CardName.cabalshadowpriest, 5);
            GangUpDatabase.Add(CardDB.CardName.cairnebloodhoof, 5);
            GangUpDatabase.Add(CardDB.CardName.cenarius, 5);
            GangUpDatabase.Add(CardDB.CardName.chromaggus, 4);
            GangUpDatabase.Add(CardDB.CardName.cobaltguardian, 1);
            GangUpDatabase.Add(CardDB.CardName.coldarradrake, 1);
            GangUpDatabase.Add(CardDB.CardName.coldlightoracle, 5);
            GangUpDatabase.Add(CardDB.CardName.confessorpaletress, 5);
            GangUpDatabase.Add(CardDB.CardName.corendirebrew, 5);
            GangUpDatabase.Add(CardDB.CardName.cthun, 5);
            GangUpDatabase.Add(CardDB.CardName.cultapothecary, 1);
            GangUpDatabase.Add(CardDB.CardName.cultmaster, 1);
            GangUpDatabase.Add(CardDB.CardName.cultsorcerer, 5);
            GangUpDatabase.Add(CardDB.CardName.dementedfrostcaller, 5);
            GangUpDatabase.Add(CardDB.CardName.demolisher, 1);
            GangUpDatabase.Add(CardDB.CardName.direwolfalpha, 1);
            GangUpDatabase.Add(CardDB.CardName.doppelgangster, 1);
            GangUpDatabase.Add(CardDB.CardName.dragonkinsorcerer, 0);
            GangUpDatabase.Add(CardDB.CardName.drboom, 5);
            GangUpDatabase.Add(CardDB.CardName.earthenringfarseer, 3);
            GangUpDatabase.Add(CardDB.CardName.edwinvancleef, 5);
            GangUpDatabase.Add(CardDB.CardName.emboldener3000, 1);
            GangUpDatabase.Add(CardDB.CardName.emperorthaurissan, 5);
            GangUpDatabase.Add(CardDB.CardName.etherealpeddler, 3);
            GangUpDatabase.Add(CardDB.CardName.felcannon, 0);
            GangUpDatabase.Add(CardDB.CardName.fireelemental, 5);
            GangUpDatabase.Add(CardDB.CardName.fireguarddestroyer, 4);
            GangUpDatabase.Add(CardDB.CardName.flametonguetotem, 4);
            GangUpDatabase.Add(CardDB.CardName.flamewaker, 4);
            GangUpDatabase.Add(CardDB.CardName.flesheatingghoul, 0);
            GangUpDatabase.Add(CardDB.CardName.floatingwatcher, 0);
            GangUpDatabase.Add(CardDB.CardName.foereaper4000, 1);
            GangUpDatabase.Add(CardDB.CardName.friendlybartender, 3);
            GangUpDatabase.Add(CardDB.CardName.frothingberserker, 1);
            GangUpDatabase.Add(CardDB.CardName.gadgetzanauctioneer, 1);
            GangUpDatabase.Add(CardDB.CardName.gahzrilla, 5);
            GangUpDatabase.Add(CardDB.CardName.garr, 5);
            GangUpDatabase.Add(CardDB.CardName.gazlowe, 1);
            GangUpDatabase.Add(CardDB.CardName.gelbinmekkatorque, 3);
            GangUpDatabase.Add(CardDB.CardName.genzotheshark, 5);
            GangUpDatabase.Add(CardDB.CardName.grimestreetenforcer, 3);
            GangUpDatabase.Add(CardDB.CardName.grimscaleoracle, 1);
            GangUpDatabase.Add(CardDB.CardName.grimygadgeteer, 3);
            GangUpDatabase.Add(CardDB.CardName.gruul, 4);
            GangUpDatabase.Add(CardDB.CardName.harrisonjones, 1);
            GangUpDatabase.Add(CardDB.CardName.hemetnesingwary, 1);
            GangUpDatabase.Add(CardDB.CardName.highjusticegrimstone, 5);
            GangUpDatabase.Add(CardDB.CardName.hobgoblin, 1);
            GangUpDatabase.Add(CardDB.CardName.hogger, 5);
            GangUpDatabase.Add(CardDB.CardName.hoggerdoomofelwynn, 1);
            GangUpDatabase.Add(CardDB.CardName.igneouselemental, 1);
            GangUpDatabase.Add(CardDB.CardName.illidanstormrage, 5);
            GangUpDatabase.Add(CardDB.CardName.impmaster, 0);
            GangUpDatabase.Add(CardDB.CardName.infestedtauren, 1);
            GangUpDatabase.Add(CardDB.CardName.ironbeakowl, 4);
            GangUpDatabase.Add(CardDB.CardName.ironjuggernaut, 2);
            GangUpDatabase.Add(CardDB.CardName.ironsensei, 1);
            GangUpDatabase.Add(CardDB.CardName.jadeswarmer, 5);
            GangUpDatabase.Add(CardDB.CardName.jeeves, 0);
            GangUpDatabase.Add(CardDB.CardName.junkbot, 1);
            GangUpDatabase.Add(CardDB.CardName.kelthuzad, 5);
            GangUpDatabase.Add(CardDB.CardName.kingkrush, 5);
            GangUpDatabase.Add(CardDB.CardName.knifejuggler, 3);
            GangUpDatabase.Add(CardDB.CardName.kodorider, 5);
            GangUpDatabase.Add(CardDB.CardName.leeroyjenkins, 3);
            GangUpDatabase.Add(CardDB.CardName.leokk, 3);
            GangUpDatabase.Add(CardDB.CardName.lightwarden, 0);
            GangUpDatabase.Add(CardDB.CardName.lightwell, 1);
            GangUpDatabase.Add(CardDB.CardName.loatheb, 5);
            GangUpDatabase.Add(CardDB.CardName.lucifron, 5);
            GangUpDatabase.Add(CardDB.CardName.lyrathesunshard, 1);
            GangUpDatabase.Add(CardDB.CardName.maexxna, 3);
            GangUpDatabase.Add(CardDB.CardName.malganis, 4);
            GangUpDatabase.Add(CardDB.CardName.malkorok, 2);
            GangUpDatabase.Add(CardDB.CardName.malorne, 1);
            GangUpDatabase.Add(CardDB.CardName.malygos, 1);
            GangUpDatabase.Add(CardDB.CardName.manatidetotem, 0);
            GangUpDatabase.Add(CardDB.CardName.manawyrm, 0);
            GangUpDatabase.Add(CardDB.CardName.masterswordsmith, 1);
            GangUpDatabase.Add(CardDB.CardName.mechwarper, 1);
            GangUpDatabase.Add(CardDB.CardName.medivhtheguardian, 2);
            GangUpDatabase.Add(CardDB.CardName.mekgineerthermaplugg, 4);
            GangUpDatabase.Add(CardDB.CardName.micromachine, 1);
            GangUpDatabase.Add(CardDB.CardName.misha, 5);
            GangUpDatabase.Add(CardDB.CardName.moatlurker, 4);
            GangUpDatabase.Add(CardDB.CardName.moirabronzebeard, 5);
            GangUpDatabase.Add(CardDB.CardName.murlocknight, 5);
            GangUpDatabase.Add(CardDB.CardName.underbellyangler, 5);
            GangUpDatabase.Add(CardDB.CardName.murloctidecaller, 1);
            GangUpDatabase.Add(CardDB.CardName.murlocwarleader, 1);
            GangUpDatabase.Add(CardDB.CardName.nefarian, 5);
            GangUpDatabase.Add(CardDB.CardName.nexuschampionsaraad, 5);
            GangUpDatabase.Add(CardDB.CardName.northshirecleric, 0);
            GangUpDatabase.Add(CardDB.CardName.obsidiandestroyer, 5);
            GangUpDatabase.Add(CardDB.CardName.oldmurkeye, 5);
            GangUpDatabase.Add(CardDB.CardName.onyxia, 4);
            GangUpDatabase.Add(CardDB.CardName.pilotedshredder, 3);
            GangUpDatabase.Add(CardDB.CardName.pintsizedsummoner, 1);
            GangUpDatabase.Add(CardDB.CardName.prophetvelen, 1);
            GangUpDatabase.Add(CardDB.CardName.pyros, 1);
            GangUpDatabase.Add(CardDB.CardName.questingadventurer, 1);
            GangUpDatabase.Add(CardDB.CardName.radiantelemental, 1);
            GangUpDatabase.Add(CardDB.CardName.ragnaroslightlord, 3);
            GangUpDatabase.Add(CardDB.CardName.ragnarosthefirelord, 5);
            GangUpDatabase.Add(CardDB.CardName.raidleader, 2);
            GangUpDatabase.Add(CardDB.CardName.ratpack, 2);
            GangUpDatabase.Add(CardDB.CardName.razorgore, 5);
            GangUpDatabase.Add(CardDB.CardName.recruiter, 5);
            GangUpDatabase.Add(CardDB.CardName.repairbot, 1);
            GangUpDatabase.Add(CardDB.CardName.satedthreshadon, 1);
            GangUpDatabase.Add(CardDB.CardName.savagecombatant, 5);
            GangUpDatabase.Add(CardDB.CardName.savannahhighmane, 5);
            GangUpDatabase.Add(CardDB.CardName.scalednightmare, 3);
            GangUpDatabase.Add(CardDB.CardName.scavenginghyena, 0);
            GangUpDatabase.Add(CardDB.CardName.shadeofnaxxramas, 3);
            GangUpDatabase.Add(CardDB.CardName.shadopanrider, 5);
            GangUpDatabase.Add(CardDB.CardName.shadowboxer, 0);
            GangUpDatabase.Add(CardDB.CardName.shadowfiend, 1);
            GangUpDatabase.Add(CardDB.CardName.shakuthecollector, 5);
            GangUpDatabase.Add(CardDB.CardName.shipscannon, 0);
            GangUpDatabase.Add(CardDB.CardName.siltfinspiritwalker, 0);
            GangUpDatabase.Add(CardDB.CardName.sludgebelcher, 5);
            GangUpDatabase.Add(CardDB.CardName.sneedsoldshredder, 5);
            GangUpDatabase.Add(CardDB.CardName.sorcerersapprentice, 1);
            GangUpDatabase.Add(CardDB.CardName.southseacaptain, 0);
            GangUpDatabase.Add(CardDB.CardName.starvingbuzzard, 0);
            GangUpDatabase.Add(CardDB.CardName.stonesplintertrogg, 0);
            GangUpDatabase.Add(CardDB.CardName.stormwindchampion, 4);
            GangUpDatabase.Add(CardDB.CardName.summoningportal, 5);
            GangUpDatabase.Add(CardDB.CardName.summoningstone, 5);
            GangUpDatabase.Add(CardDB.CardName.swashburglar, 2);
            GangUpDatabase.Add(CardDB.CardName.sylvanaswindrunner, 5);
            GangUpDatabase.Add(CardDB.CardName.theblackknight, 5);
            GangUpDatabase.Add(CardDB.CardName.theboogeymonster, 3);
            GangUpDatabase.Add(CardDB.CardName.timberwolf, 0);
            GangUpDatabase.Add(CardDB.CardName.tirionfordring, 5);
            GangUpDatabase.Add(CardDB.CardName.toshley, 4);
            GangUpDatabase.Add(CardDB.CardName.tradeprincegallywix, 3);
            GangUpDatabase.Add(CardDB.CardName.troggzortheearthinator, 1);
            GangUpDatabase.Add(CardDB.CardName.undercityhuckster, 2);
            GangUpDatabase.Add(CardDB.CardName.undertaker, 0);
            GangUpDatabase.Add(CardDB.CardName.unearthedraptor, 5);
            GangUpDatabase.Add(CardDB.CardName.usherofsouls, 1);
            GangUpDatabase.Add(CardDB.CardName.v07tr0n, 5);
            GangUpDatabase.Add(CardDB.CardName.vaelastrasz, 5);
            GangUpDatabase.Add(CardDB.CardName.viciousfledgling, 2);
            GangUpDatabase.Add(CardDB.CardName.violetillusionist, 5);
            GangUpDatabase.Add(CardDB.CardName.violetteacher, 0);
            GangUpDatabase.Add(CardDB.CardName.vitalitytotem, 1);
            GangUpDatabase.Add(CardDB.CardName.voljin, 5);
            GangUpDatabase.Add(CardDB.CardName.warsongcommander, 3);
            GangUpDatabase.Add(CardDB.CardName.weespellstopper, 0);
            GangUpDatabase.Add(CardDB.CardName.wickedwitchdoctor, 5);
            GangUpDatabase.Add(CardDB.CardName.wobblingrunts, 3);
            GangUpDatabase.Add(CardDB.CardName.xarilpoisonedmind, 3);
            GangUpDatabase.Add(CardDB.CardName.youngpriestess, 1);
            GangUpDatabase.Add(CardDB.CardName.ysera, 5);
            GangUpDatabase.Add(CardDB.CardName.yshaarjrageunbound, 5);
            GangUpDatabase.Add(CardDB.CardName.valkyrsoulclaimer, 0);
            GangUpDatabase.Add(CardDB.CardName.cryptlord, 4);
        }

        private void setupbuffHandDatabase()
        {
            buffHandDatabase.Add(CardDB.CardName.brassknuckles, 1);
            buffHandDatabase.Add(CardDB.CardName.donhancho, 5);
            buffHandDatabase.Add(CardDB.CardName.grimestreetenforcer, 1);
            buffHandDatabase.Add(CardDB.CardName.grimestreetoutfitter, 1);
            buffHandDatabase.Add(CardDB.CardName.grimestreetpawnbroker, 1);
            buffHandDatabase.Add(CardDB.CardName.grimestreetsmuggler, 1);
            buffHandDatabase.Add(CardDB.CardName.grimscalechum, 1);
            buffHandDatabase.Add(CardDB.CardName.grimygadgeteer, 2);
            buffHandDatabase.Add(CardDB.CardName.hiddencache, 2);
            buffHandDatabase.Add(CardDB.CardName.hobartgrapplehammer, 1);
            buffHandDatabase.Add(CardDB.CardName.shakyzipgunner, 2);
            buffHandDatabase.Add(CardDB.CardName.smugglerscrate, 2);
            buffHandDatabase.Add(CardDB.CardName.smugglersrun, 1);
            buffHandDatabase.Add(CardDB.CardName.stolengoods, 3);
            buffHandDatabase.Add(CardDB.CardName.themistcaller, 1);
            buffHandDatabase.Add(CardDB.CardName.troggbeastrager, 1);
        }

        private void setupequipWeaponPlayDatabase()
        {
            equipWeaponPlayDatabase.Add(CardDB.CardName.arathiweaponsmith, 2);
            equipWeaponPlayDatabase.Add(CardDB.CardName.blingtron3000, 3);
            equipWeaponPlayDatabase.Add(CardDB.CardName.daggermastery, 1);
            equipWeaponPlayDatabase.Add(CardDB.CardName.echolocate, 2);
            equipWeaponPlayDatabase.Add(CardDB.CardName.instructorrazuvious, 5);
            equipWeaponPlayDatabase.Add(CardDB.CardName.malkorok, 3);
            equipWeaponPlayDatabase.Add(CardDB.CardName.medivhtheguardian, 1);
            equipWeaponPlayDatabase.Add(CardDB.CardName.musterforbattle, 1);
            equipWeaponPlayDatabase.Add(CardDB.CardName.nzothsfirstmate, 1);
            equipWeaponPlayDatabase.Add(CardDB.CardName.poisoneddaggers, 2);
            equipWeaponPlayDatabase.Add(CardDB.CardName.upgrade, 1);
            equipWeaponPlayDatabase.Add(CardDB.CardName.visionsoftheassassin, 1);
            equipWeaponPlayDatabase.Add(CardDB.CardName.utheroftheebonblade, 5);
            equipWeaponPlayDatabase.Add(CardDB.CardName.scourgelordgarrosh, 4);
        }


    }

}