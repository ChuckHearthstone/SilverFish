namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public class PenalityManager
    {
        //todo acolyteofpain
        //todo better aoe-penality

        public Dictionary<CardDB.cardName, int> HealTargetDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealHeroDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> HealAllDatabase = new Dictionary<CardDB.cardName, int>();


        Dictionary<CardDB.cardName, int> DamageAllDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> DamageHeroDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> DamageRandomDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> DamageAllEnemysDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> HeroPowerEquipWeapon = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> enrageDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> silenceDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> OwnNeedSilenceDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> heroAttackBuffDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> attackBuffDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> healthBuffDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> tauntBuffDatabase = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> lethalHelpers = new Dictionary<CardDB.cardName, int>();
        
        Dictionary<CardDB.cardName, int> spellDependentDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> dragonDependentDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> elementalLTDependentDatabase = new Dictionary<CardDB.cardName, int>();

        public Dictionary<CardDB.cardName, int> cardDiscardDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyOwnDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> destroyDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> buffingMinionsDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> buffing1TurnDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> heroDamagingAoeDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> randomEffects = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> silenceTargets = new Dictionary<CardDB.cardName, int>();

        Dictionary<CardDB.cardName, int> returnHandDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> GangUpDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> buffHandDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> equipWeaponPlayDatabase = new Dictionary<CardDB.cardName, int>(); 

        Dictionary<CardDB.cardName, int> priorityDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, int> UsefulNeedKeepDatabase = new Dictionary<CardDB.cardName, int>();
        Dictionary<CardDB.cardName, CardDB.cardIDEnum> choose1database = new Dictionary<CardDB.cardName, CardDB.cardIDEnum>();
        Dictionary<CardDB.cardName, CardDB.cardIDEnum> choose2database = new Dictionary<CardDB.cardName, CardDB.cardIDEnum>();

        public Dictionary<CardDB.cardName, int> DamageTargetDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> DamageTargetSpecialDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> maycauseharmDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> cardDrawBattleCryDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> cardDrawDeathrattleDatabase = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> priorityTargets = new Dictionary<CardDB.cardName, int>();
        public Dictionary<CardDB.cardName, int> specialMinions = new Dictionary<CardDB.cardName, int>(); //minions with cardtext, but no battlecry
        public Dictionary<CardDB.cardName, int> ownSummonFromDeathrattle = new Dictionary<CardDB.cardName, int>();

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

        private static PenalityManager instance;

        public static PenalityManager Instance
        {
            get
            {
                return instance ?? (instance = new PenalityManager());
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

        private PenalityManager()
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
            if (!p.isLethalCheck && m.name == CardDB.cardName.bloodimp) retval += 50;
            switch (m.name)
            {
                case CardDB.cardName.leeroyjenkins:
                    if (!target.own && target.name == CardDB.cardName.whelp) return 500;
                    break;
                case CardDB.cardName.bloodmagethalnos:
                    if (!target.isHero && Ai.Instance.lethalMissing <= 5)
                    {
                        if (!target.taunt)
                        {
                            if (m.Hp <= target.Angr && m.own && !m.divineshild && !m.immune) return 65;
                        }
                    }
                    goto case CardDB.cardName.aiextra1;
                
                
                case CardDB.cardName.acolyteofpain: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.clockworkgnome: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.loothoarder: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.mechanicalyeti: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.mechbearcat: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.tombpillager: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.toshley: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.webspinner: goto case CardDB.cardName.aiextra1;
                case CardDB.cardName.aiextra1:
                    
                    if (m.Hp <= target.Angr && m.own && !m.divineshild && !m.immune)
                    {
                        int carddraw = 1; 
                        if (p.owncards.Count + carddraw > 10) retval += 15 * (p.owncards.Count + carddraw - 10);
                        else retval += 3 * p.optionsPlayedThisTurn;
                    }
                    return retval;
                    break;
            }
            if (this.specialMinions.ContainsKey(m.name) && target.Hp > m.Angr && !target.isHero) retval++;
            if (this.UsefulNeedKeepDatabase.ContainsKey(m.name) && !target.isHero && !(m.divineshild || target.Angr == 0)) retval++;
            if (m.justBuffed > 0)
            {
                if (m.divineshild || m.immune) {}
                else if (target.poisonous || target.Angr >= m.Hp) retval += m.justBuffed;
            }
            return retval;
        }

        public int getAttackWithHeroPenality(Minion target, Playfield p)
        {
            bool isLethalCheck = p.isLethalCheck;
            int retval = ai.botBase.getAttackWithHeroPenality(target, p);
            if (retval < 0 || retval > 499) return retval;

            if (!isLethalCheck && target.isHero && target.Hp > settings.enfacehp)
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

            if (!isLethalCheck && p.enemyWeapon.name == CardDB.cardName.swordofjustice)
            {
                return 28;
            }

            switch (p.ownWeapon.name)
            {
                case CardDB.cardName.atiesh:
                    if (!isLethalCheck)
                    {
                        if (target.isHero) return 500;
                        else return 15;
                    }
                    break;
                case CardDB.cardName.doomhammer:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.cardName.rockbiterweapon && hc.canplayCard(p, true)) return 10;
                    }
                    break;
                case CardDB.cardName.eaglehornbow:
                    if (p.ownWeapon.Durability == 1)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.arcaneshot || hc.card.name == CardDB.cardName.killcommand) return -p.ownWeapon.Angr - 1;
                        }
                        if (p.ownSecretsIDList.Count >= 1) return 20;

                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.Secret) return 20;
                        }
                    }
                    break;
                case CardDB.cardName.spiritclaws:
                    if (!isLethalCheck && p.ownWeapon.Angr == 1)
                    {
                        if (target.isHero) return 500;
                        else if (target.Hp == 1 && this.specialMinions.ContainsKey(target.name)) return 0;
                        else return 7;
                    }
                    break;
                case CardDB.cardName.gorehowl:
                    if (target.isHero && p.ownWeapon.Angr >= 3) return 10;
                    break;
                case CardDB.cardName.brassknuckles:
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
                if (p.ownWeapon.Angr == 1 && wAttack == 0 && (p.ownHeroAblility.card.name == CardDB.cardName.poisoneddaggers || p.ownHeroAblility.card.name == CardDB.cardName.daggermastery)) wAttack = 1;
                if (wAttack > 0) retval = -p.ownWeapon.Angr - 1; // so he doesnt "lose" the weapon in evaluation :D
            }
            if (p.ownWeapon.Angr == 1 && p.ownHeroName == HeroEnum.thief)
            {
                if (target.Hp < 11) retval += 1;
                else retval += -1;
            }
            return retval;
        }

        public int weaponInHandAttackNextTurn(Playfield p)
        {
            foreach (Handmanager.Handcard c in p.owncards)
            {
                if (c.card.type == CardDB.cardtype.WEAPON && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
                {
                    return c.card.Attack;
                }
                if (this.equipWeaponPlayDatabase.ContainsKey(c.card.name) && c.card.name != CardDB.cardName.upgrade && c.card.getManaCost(p, c.manacost) <= p.ownMaxMana + 1)
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

            CardDB.cardName name = card.name;
            //there is no reason to buff HP of minon (because it is not healed)

            int abuff = getAttackBuffPenality(card, target, p);
            int tbuff = getTauntBuffPenality(card, target, p);
            if (name == CardDB.cardName.markofthewild && ((abuff >= 500 && tbuff == 0) || (abuff == 0 && tbuff >= 500)))
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
            CardDB.cardName name = card.name;
            if (name == CardDB.cardName.darkwispers && card.cardIDenum != CardDB.cardIDEnum.GVG_041a) return 0;
            int pen = 0;
            //buff enemy?

            if (!p.isLethalCheck && (card.name == CardDB.cardName.savageroar || card.name == CardDB.cardName.bloodlust))
            {
                int targets = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Ready) targets++;
                }
                if ((p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) && card.name == CardDB.cardName.savageroar) targets++;

                if (targets <= 2)
                {
                    return 20;
                }
            }

            if (!this.attackBuffDatabase.ContainsKey(name)) return 0;
            if (target == null) return 60;
            if (!target.isHero && !target.own)
            {
                if (card.type == CardDB.cardtype.MOB && p.ownMinions.Count == 0) return 2;
                
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    switch (hc.card.name)
                    {
                        case CardDB.cardName.biggamehunter:
                            if (target.Angr + this.attackBuffDatabase[name] > 6) return 5;
                            break;
                        case CardDB.cardName.shadowworddeath:
                            if (target.Angr + this.attackBuffDatabase[name] > 4) return 5;
                            break;
                        default:
                            break;
                    }
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
                            if (hc.card.name == CardDB.cardName.execute) return 0;
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
                        case CardDB.cardName.markofyshaarj:
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
                if (m.Hp == 1 && !m.divineshild && !this.buffing1TurnDatabase.ContainsKey(name))
                {
                    return 10;
                }
                if (m.Angr == 0)
                {
                    if (!m.silenced && m.handcard.card.deathrattle) return -8;
                    return -5;
                }
            }

            return pen;
        }

        private int getHPBuffPenality(CardDB.Card card, Minion target, Playfield p)
        {
            CardDB.cardName name = card.name;
            int pen = 0;

            if (!this.healthBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.cardName.darkwispers && card.cardIDenum != CardDB.cardIDEnum.GVG_041a) return 0;

            if (target != null && !target.own && !this.tauntBuffDatabase.ContainsKey(name))
            {
                pen = 500 + p.ownMinions.Count;
            }

            return pen;
        }


        private int getTauntBuffPenality(CardDB.Card card, Minion target, Playfield p)
        {
            CardDB.cardName name = card.name;
            int pen = 0;
            //buff enemy?
            if (!this.tauntBuffDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.cardName.markofnature && card.cardIDenum != CardDB.cardIDEnum.EX1_155b) return 0;
            if (name == CardDB.cardName.darkwispers && card.cardIDenum != CardDB.cardIDEnum.GVG_041a) return 0;
            
            if (target == null) return 3;
            if (!target.isHero && !target.own)
            {
                //allow it if you have black knight
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.theblackknight) return 0;
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

        private int getSilencePenality(CardDB.cardName name, Minion target, Playfield p)
        {
            int pen = 0;

            if (target == null)
            {
                if (name == CardDB.cardName.ironbeakowl || name == CardDB.cardName.spellbreaker || name == CardDB.cardName.keeperofthegrove)
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
                    if (target.Angr < target.handcard.card.Attack || target.maxHp < target.handcard.card.Health
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
                    case CardDB.cardName.masterchest: return 500;
                }
                if (this.silenceDatabase.ContainsKey(name))
                {
                    pen = 5;
                    if (p.isLethalCheck)
                    {
                        //during lethal we only silence taunt, or if its a mob (owl/spellbreaker) + we can give him charge
                        if (target.taunt || (name == CardDB.cardName.ironbeakowl && (p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) || (name == CardDB.cardName.spellbreaker && p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null)) return 0;

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

                    if (target.Angr <= target.handcard.card.Attack && target.maxHp <= target.handcard.card.Health && !target.taunt && !target.windfury && !target.divineshild && !target.poisonous && !target.lifesteal && !this.specialMinions.ContainsKey(name))
                    {
                        if (name == CardDB.cardName.keeperofthegrove) return 500;
                        return 30;
                    }

                    if (target.Angr > target.handcard.card.Attack || target.maxHp > target.handcard.card.Health)
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
            CardDB.cardName name = card.name;
            int pen = 0;

            if (name == CardDB.cardName.shieldslam && p.ownHero.armor == 0) return 500;
            if (name == CardDB.cardName.savagery && p.ownHero.Angr == 0) return 500;
            
            //aoe damage *************************************************************************************
            int aoeDamageType = 0;
            if (this.DamageAllEnemysDatabase.ContainsKey(name)) aoeDamageType = 1;
            else if (p.anzOwnAuchenaiSoulpriest >= 1 && HealAllDatabase.ContainsKey(name)) aoeDamageType = 2;
            else if (this.DamageAllDatabase.ContainsKey(name)) aoeDamageType = 3;
            if (aoeDamageType > 0)
            {
                if (p.enemyMinions.Count == 0)
                {
                    if (name == CardDB.cardName.cthun) return 0;
                    return 300;
                }

                int aoeDamage = 0;
                if (aoeDamageType == 1) aoeDamage = (card.type == CardDB.cardtype.SPELL) ? p.getSpellDamageDamage(this.DamageAllEnemysDatabase[name]) : this.DamageAllEnemysDatabase[name];
                else if (aoeDamageType == 2) aoeDamage = (card.type == CardDB.cardtype.SPELL) ? p.getSpellDamageDamage(this.HealAllDatabase[name]) : this.HealAllDatabase[name];
                else if (aoeDamageType == 3)
                {
                    if (name == CardDB.cardName.revenge && p.ownHero.Hp <= 12) aoeDamage = p.getSpellDamageDamage(3);
                    else aoeDamage = (card.type == CardDB.cardtype.SPELL) ? p.getSpellDamageDamage(this.DamageAllDatabase[name]) : this.DamageAllDatabase[name];
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
                    if (aoeDamage >= m.Hp && !m.divineshild)
                    {
                        switch (name)
                        {
                            case CardDB.cardName.sleepwiththefishes: 
                                if (!m.wounded) continue;
                                break;
                            case CardDB.cardName.dragonfirepotion: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) continue;
                                break;
                            case CardDB.cardName.corruptedseer: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) continue;
                                break;
                            case CardDB.cardName.shadowvolley: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                break;
                            case CardDB.cardName.demonwrath: 
                                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                break;
                            case CardDB.cardName.scarletpurifier: 
                                if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                break;
                            case CardDB.cardName.yseraawakens: 
                                if (m.name == CardDB.cardName.ysera) continue;
                                break;
                            case CardDB.cardName.lightbomb: 
                                if (m.Hp > m.Angr) continue;
                                break;
                        }
                        
                        if (this.specialMinions.ContainsKey(m.name)) numSpecialMinionsEnemy++;
                        switch (m.name)
                        {
                            case CardDB.cardName.direwolfalpha: 
                                if (m.silenced) break;
                                
                                if (i > 0)
                                {
                                    if (p.enemyMinions[i - 1].divineshild)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i - 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                if (i < anz - 1)
                                {
                                    if (p.enemyMinions[i + 1].divineshild)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i + 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 1;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                break;
                            case CardDB.cardName.flametonguetotem: 
                                if (m.silenced) break;
                                if (i > 0)
                                {
                                    if (p.enemyMinions[i - 1].divineshild)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i - 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i - 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                if (i < anz - 1)
                                {
                                    if (p.enemyMinions[i + 1].divineshild)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                    else if (p.enemyMinions[i + 1].Hp > aoeDamage)
                                    {
                                        preventDamage += 2;
                                        if (preventDamageAdd == 0 && p.ownHero.Ready && p.enemyMinions[i + 1].Hp - aoeDamage <= p.ownHero.Angr) preventDamageAdd = 1;
                                    }
                                }
                                break;
                            case CardDB.cardName.leokk: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardDB.cardName.raidleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardDB.cardName.stormwindchampion: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions) if (mm.Hp > aoeDamage || mm.divineshild) preventDamage += 1;
                                break;
                            case CardDB.cardName.grimscaleoracle: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                                 
                            case CardDB.cardName.murlocwarleader: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardDB.cardName.malganis: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.DEMON && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 2;
                                }
                                break;
                            case CardDB.cardName.southseacaptain: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.cardName.timberwolf: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.cardName.warhorsetrainer: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.name == CardDB.cardName.silverhandrecruit && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.cardName.warsongcommander: 
                                if (m.silenced) break;
                                foreach (Minion mm in p.enemyMinions)
                                {
                                    if (mm.charge > 0 && (mm.Hp > aoeDamage || mm.divineshild)) preventDamage += 1;
                                }
                                break;
                            case CardDB.cardName.tunneltrogg:
                                preventDamage++;
                                break;
                            case CardDB.cardName.secretkeeper:
                                preventDamage++;
                                break;
                        }
                        preventDamage += m.Angr;
                    }
                    else
                    {
                        survivedEnemyMinions++;
                        if (survivedEnemyMinionsAngr < m.Angr) survivedEnemyMinionsAngr = m.Angr;
                        if (!m.wounded && this.enrageDatabase.ContainsKey(name)) preventDamage -= this.enrageDatabase[name];
                        else if (m.name == CardDB.cardName.gurubashiberserker) preventDamage -= 3;
                        else if (m.name == CardDB.cardName.frothingberserker) frothingberserkerEnemy = true;
                        else if (m.name == CardDB.cardName.grimpatron) { preventDamage -= 3; grimpatronEnemy = true; }
                    }
                }
                preventDamage += preventDamageAdd;

                if (aoeDamageType > 1)
                {
                    anz = p.ownMinions.Count;
                    for (int i = 0; i < anz; i++)
                    {
                        Minion m = p.ownMinions[i];
                        if (aoeDamage >= m.Hp && !m.divineshild)
                        {
                            switch (name)
                            {
                                case CardDB.cardName.sleepwiththefishes: 
                                    if (!m.wounded) continue;
                                    break;
                                case CardDB.cardName.dragonfirepotion: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) continue;
                                    break;
                                case CardDB.cardName.corruptedseer: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) continue;
                                    break;
                                case CardDB.cardName.shadowvolley: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                    break;
                                case CardDB.cardName.demonwrath: 
                                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) continue;
                                    break;
                                case CardDB.cardName.scarletpurifier: 
                                    if (!(m.handcard.card.deathrattle && !m.silenced)) continue;
                                    break;
                                case CardDB.cardName.yseraawakens: 
                                    if (m.name == CardDB.cardName.ysera) continue;
                                    break;
                                case CardDB.cardName.lightbomb: 
                                    if (m.Hp > m.Angr) continue;
                                    break;
                            }

                            switch (m.name)
                            {
                                case CardDB.cardName.direwolfalpha: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].Hp > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 1;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].Hp > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 1;
                                    break;
                                case CardDB.cardName.flametonguetotem: 
                                    if (m.silenced) break;
                                    if (i > 0 && (p.ownMinions[i - 1].Hp > aoeDamage || p.ownMinions[i - 1].divineshild)) lostOwnDamage += 2;
                                    if (i < anz - 1 && (p.ownMinions[i + 1].Hp > aoeDamage || p.ownMinions[i + 1].divineshild)) lostOwnDamage += 2;
                                    break;
                                case CardDB.cardName.leokk: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardDB.cardName.raidleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardDB.cardName.stormwindchampion: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions) if (mm.Hp > aoeDamage || mm.divineshild) lostOwnDamage += 1;
                                    break;
                                case CardDB.cardName.grimscaleoracle: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                
                                case CardDB.cardName.murlocwarleader: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.MURLOC && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardDB.cardName.malganis: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.DEMON && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 2;
                                    }
                                    break;
                                case CardDB.cardName.southseacaptain: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PIRATE && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardDB.cardName.timberwolf: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if ((TAG_RACE)mm.handcard.card.race == TAG_RACE.PET && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardDB.cardName.warhorsetrainer: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.name == CardDB.cardName.silverhandrecruit && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                                case CardDB.cardName.warsongcommander: 
                                    if (m.silenced) break;
                                    foreach (Minion mm in p.ownMinions)
                                    {
                                        if (mm.charge > 0 && (mm.Hp > aoeDamage || mm.divineshild)) lostOwnDamage += 1;
                                    }
                                    break;
                            }
                            lostOwnHp += m.Hp; 
                            lostOwnDamage += m.Angr;

                            lostOwnMinions++;
                            if (!m.wounded && this.enrageDatabase.ContainsKey(name)) lostOwnDamage += this.enrageDatabase[name];
                            else if (m.name == CardDB.cardName.gurubashiberserker && m.Hp > 1) lostOwnDamage += 3;
                            else if (m.name == CardDB.cardName.frothingberserker) frothingberserkerOwn = true;
                            else if (m.name == CardDB.cardName.grimpatron) { lostOwnDamage += 3; grimpatronOwn = true; }
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
                            foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == CardDB.cardName.execute) return 0;
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
                    else if (name == CardDB.cardName.holynova && preventDamage >= 0)
                    {
                        int ownWoundedMinions = 0;
                        foreach (Minion m in p.ownMinions) if (m.wounded) ownWoundedMinions++;
                        if (ownWoundedMinions > 2) return 20;
                    }

                    if (survivedEnemyMinions > 0)
                    {
                        int hasExecute = 0;
                        foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.name == CardDB.cardName.execute) hasExecute++;
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
                        if (m.Angr > tmp)
                        {
                            tmp = m.Angr;
                            bogMob = m;
                        }
                    }
                    if (bogMob != null && bogMob.Angr >= 4 && bogMob.Hp > preventDamage)
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
                if (name == CardDB.cardName.baneofdoom)
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
                    
                    if (m.name == CardDB.cardName.madscientist && p.ownHeroStartClass == TAG_CLASS.HUNTER) return 500;

                    // no pen if we have battlerage for example
                    int dmg = this.DamageTargetDatabase.ContainsKey(name) ? this.DamageTargetDatabase[name] : this.HealTargetDatabase[name];
                    switch (card.cardIDenum)
                    {
                        case CardDB.cardIDEnum.EX1_166a: dmg = 2 - p.spellpower; break; 
                        case CardDB.cardIDEnum.CS2_031: if (!target.frozen) return 0; break; 
                        case CardDB.cardIDEnum.EX1_408: if (p.ownHero.Hp <= 12) dmg = 6; break; 
                        case CardDB.cardIDEnum.EX1_539: 
                            foreach (Minion mn in p.ownMinions)
                            {
                                if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.PET) { dmg = 5; break; }
                            }
                            break;
                    }
                    if (card.type == CardDB.cardtype.SPELL) dmg = p.getSpellDamageDamage(dmg);
                
                    if (m.Hp > dmg)
                    {
                        switch (m.name)
                        {
                            case CardDB.cardName.gurubashiberserker: return 0; break;
                            case CardDB.cardName.axeflinger: return 0; break;
                            case CardDB.cardName.gahzrilla: return 0; break;
                            case CardDB.cardName.garr: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardDB.cardName.hoggerdoomofelwynn: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardDB.cardName.acolyteofpain: if (p.owncards.Count <= 3) return 0; break;
                            case CardDB.cardName.dragonegg: if (p.ownMinions.Count <= 6) return 5; break;
                            case CardDB.cardName.impgangboss: if (p.ownMinions.Count <= 6) return 0; break;
                            case CardDB.cardName.grimpatron: if (p.ownMinions.Count <= 6) return 0; break;
                        }
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.battlerage) return pen;
                            if (hc.card.name == CardDB.cardName.rampage) return pen;
                        }
                    }
                    else
                    {
                        if (p.isLethalCheck && dmg == 1 && p.enemyHero.Hp < 3)
                        {
                            switch (m.name)
                            {
                                case CardDB.cardName.lepergnome: return 0; break;
                                case CardDB.cardName.axeflinger: return 0; break;
                            }
                        }
                        if (cardDrawDeathrattleDatabase.ContainsKey(m.name))
                        {
                            if (ai.lethalMissing <= 5 && p.lethalMissing() <= 5) pen += 115 + (dmg - m.Hp) * 10; //behav compensation
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
                        case CardDB.cardName.crueltaskmaster: if (m.Hp >= 2) return 0; break;
                        case CardDB.cardName.innerrage: if (m.Hp >= 2) return 0; break;
                        case CardDB.cardName.demonfire: if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0; break;
                        case CardDB.cardName.demonheart: if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) return 0; break;
                        case CardDB.cardName.earthshock:
                            if (m.Hp >= 2)
                            {
                                if ((!m.silenced && this.OwnNeedSilenceDatabase.ContainsKey(m.name)) 
                                    || m.Angr < m.handcard.card.Attack || m.maxHp < m.handcard.card.Health 
                                    || m.enemyPowerWordGlory > 0 || m.enemyBlessingOfWisdom > 0
                                    || (m.frozen && !m.playedThisTurn && m.numAttacksThisTurn == 0))
                                    return 0;
                                if ((enrageDatabase.ContainsKey(m.name) || priorityDatabase.ContainsKey(m.name)) && !m.silenced) return 500;
                            }
                            else return 500; //dont silence other own minions
                            break;
                    }
                    if (m.Hp > dmg)
                    {
                        if (enrageDatabase.ContainsKey(m.name) && !m.wounded && m.Ready) // no pen if own is enrage
                        {
                            return pen;
                        }

                        foreach (Handmanager.Handcard hc in p.owncards) // no pen if we have battlerage for example
                        {
                            switch (hc.card.name)
                            {
                                case CardDB.cardName.battlerage: return pen; break;
                                case CardDB.cardName.rampage: return pen; break;
                                case CardDB.cardName.bloodwarriors: return pen; break;
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
                    realDamage = (card.type == CardDB.cardtype.SPELL) ? p.getSpellDamageDamage(this.DamageTargetSpecialDatabase[name]) : this.DamageTargetSpecialDatabase[name];
                    switch (name)
                    {
                        case CardDB.cardName.soulfire: if (target.Hp <= realDamage - 2) pen = 10; break; 
                        case CardDB.cardName.baneofdoom: if (target.Hp > realDamage) pen = 10; break; 
                        case CardDB.cardName.shieldslam: if (target.Hp <= 4 || target.Angr <= 4) pen = 20; break; 
                        case CardDB.cardName.bloodtoichor: if (target.Hp <= realDamage) pen = 2; break; 
                    }
                }
                else
                {
                    if (DamageTargetDatabase.ContainsKey(name))
                    {
                        realDamage = this.DamageTargetDatabase[name];
                        switch (card.cardIDenum)
                        {
                            case CardDB.cardIDEnum.EX1_166a: realDamage = 2 - p.spellpower; break; 
                            case CardDB.cardIDEnum.CS2_031: if (!target.frozen) return 0; break; 
                            case CardDB.cardIDEnum.EX1_408: if (p.ownHero.Hp <= 12) realDamage = 6; break; 
                            case CardDB.cardIDEnum.EX1_539: 
                                foreach (Minion mn in p.ownMinions)
                                {
                                    if ((TAG_RACE)mn.handcard.card.race == TAG_RACE.PET) { realDamage = 5; break; }
                                }
                                break;
                        }
                        if (card.type == CardDB.cardtype.SPELL) realDamage = p.getSpellDamageDamage(realDamage);
                    }
                }
                if (realDamage == 0) realDamage = card.Attack;
                if (target.name == CardDB.cardName.grimpatron && realDamage < target.Hp) return 500;
            }

            return pen;
        }

        private int getHealPenality(CardDB.cardName name, Minion target, Playfield p)
        {
            ///Todo healpenality for aoe heal
            ///todo auchenai soulpriest
            if (p.anzOwnAuchenaiSoulpriest >= 1) return 0;
            int pen = 0;
            int heal = 0;


            switch (name)
            {
                case CardDB.cardName.treeoflife:
                    {
                        int mheal = 0;
                        int wounded = 0;
                        if (p.ownHero.wounded) wounded++;
                        foreach (Minion mi in p.ownMinions)
                        {
                            mheal += Math.Min((mi.maxHp - mi.Hp), 4);
                            if (mi.wounded) wounded++;
                        }
                        if (mheal == 0) return 500;
                        if (mheal <= 7 && wounded <= 2) return 20;
                    }
                    break;

                case CardDB.cardName.renojackson:
                    if (p.ownHero.Hp < 16)
                    {
                        int retval = p.ownHero.Hp - 16;
                        if (p.ownHeroHasDirectLethal()) return retval * 10;
                        else return retval * 2;
                    }
                    else
                    {
                        pen = (p.ownHero.Hp - 15) / 2;
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

                case CardDB.cardName.circleofhealing:
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
                if ((target.isHero && target.own) && p.ownHero.Hp == 30) return 150;
                if ((target.isHero && target.own) && p.ownHero.Hp + heal - 1 > 30) pen = p.ownHero.Hp + heal - 30;
                Minion m = new Minion();

                if (!target.isHero && target.own)
                {
                    m = target;
                    int wasted = 0;
                    if (m.Hp == m.maxHp) return 500;
                    if (m.Hp + heal - 1 > m.maxHp) wasted = m.Hp + heal - m.maxHp;
                    pen = wasted;

                    if ((m.taunt || this.UsefulNeedKeepDatabase.ContainsKey(m.name)) && wasted <= 2 && m.Hp < m.maxHp) pen -= 5; // bonus for healing a taunt/useful minion

                    if (m.Hp + heal <= m.maxHp) pen = -1;
                }

                if (!target.isHero && !target.own)
                {
                    m = target;
                    if (m.Hp == m.maxHp) return 500;
                    // no penality if we heal enrage enemy
                    if (enrageDatabase.ContainsKey(m.name))
                    {
                        return pen;
                    }
                    // no penality if we have heal-trigger :D
                    int i = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.name == CardDB.cardName.northshirecleric) i++;
                        if (mnn.name == CardDB.cardName.lightwarden) i++;
                    }
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.name == CardDB.cardName.northshirecleric) i--;
                        if (mnn.name == CardDB.cardName.lightwarden) i--;
                    }
                    if (i >= 1) return pen;

                    // no pen if we have slam

                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardDB.cardName.slam && m.Hp < 2) return pen;
                        if (hc.card.name == CardDB.cardName.backstab) return pen;
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
            CardDB.cardName name = card.name;
            if (!cardDrawBattleCryDatabase.ContainsKey(name)) return 0;
            if (name == CardDB.cardName.wrath && card.cardIDenum != CardDB.cardIDEnum.EX1_154b) return 0;
            if (name == CardDB.cardName.nourish && card.cardIDenum != CardDB.cardIDEnum.EX1_164b) return 0;
            if (name == CardDB.cardName.tracking) return -1;            

            int carddraw = cardDrawBattleCryDatabase[name];
            if (carddraw == 0)
            {
                switch(name)
                {
                    case CardDB.cardName.harrisonjones:
                        carddraw = p.enemyWeapon.Durability;
                        if (carddraw == 0 && (p.enemyHeroStartClass != TAG_CLASS.DRUID && p.enemyHeroStartClass != TAG_CLASS.MAGE && p.enemyHeroStartClass != TAG_CLASS.WARLOCK && p.enemyHeroStartClass != TAG_CLASS.PRIEST)) return 5;
                        break;

                    case CardDB.cardName.divinefavor:
                        carddraw = p.enemyAnzCards - (p.owncards.Count);
                        if (carddraw <= 0) return 500;
                        break;

                    case CardDB.cardName.battlerage:
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
                                    if (hc.card.type == CardDB.cardtype.MOB) return 500;
                                }
                                if (p.owncards.Count < 2) return -10;
                                else if (p.owncards.Count < 4) return -2;
                                else if (p.owncards.Count < 6) return 0;
                                else if (p.owncards.Count < 9) return 3;
                            }
                            return 500;
                        }
                        break;

                    case CardDB.cardName.slam:
                        if (target != null && target.Hp >= 3) carddraw = 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardDB.cardName.mortalcoil:
                        if (target != null && target.Hp == 1) carddraw = 1;
                        if (carddraw == 0) return 15;
                        break;

                    case CardDB.cardName.quickshot:
                        carddraw = (p.owncards.Count > 0) ? 0 : 1;
                        if (carddraw == 0) return 4;
                        break;

                    case CardDB.cardName.thoughtsteal:
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
                    
                    case CardDB.cardName.mindvision:
                        carddraw = Math.Min(1, p.enemyAnzCards);
                        if (carddraw != 1)
                        {
                            int scales = 0;
                            foreach (Minion mnn in p.ownMinions)
                            {
                                if (this.spellDependentDatabase.ContainsKey(mnn.name))
                                    if(mnn.name == CardDB.cardName.lorewalkercho) pen += 20; //if(spellDependentDatabase[mnn.name] == 0);
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
                        
                    case CardDB.cardName.echoofmedivh:
                        if (p.ownMinions.Count == 0) return 500;
                        return 0;
                        break;
                        
                    case CardDB.cardName.tinkertowntechnician:
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if ((TAG_RACE)mnn.handcard.card.race != TAG_RACE.MECHANICAL) pen += 4;
                        }
                        break;

                    case CardDB.cardName.markofyshaarj:
                        if ((TAG_RACE)target.handcard.card.race == TAG_RACE.PET) carddraw = 1;
                        break;

                    case CardDB.cardName.servantofkalimos:
                        if (p.anzOwnElementalsLastTurn > 0) carddraw = 1;
                        break;                        

                    default:
                        break;
                }
            }
            
            if (name == CardDB.cardName.farsight || name == CardDB.cardName.callpet) pen -= 10;
            
            if (name == CardDB.cardName.lifetap)
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
                        if (m.name == CardDB.cardName.doomsayer) return 2;
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
                        else if (c.type == CardDB.cardtype.SPELL && cardDrawBattleCryDatabase.ContainsKey(c.name)) prevCardDraw++;
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
                case CardDB.cardName.solemnvigil:
                    tmp -= 2 * p.diedMinions.Count;
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && this.cardDrawBattleCryDatabase.ContainsKey(a.card.card.name)) tmp -= 2;
                    }
                    break;
                case CardDB.cardName.echoofmedivh:
                    diff = p.ownMinions.Count - prozis.ownMinions.Count;
                    if (diff > 0) tmp -= 2 * diff;
                    break;
                case CardDB.cardName.bloodwarriors:
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

            
            if (card.cost > 0) pen = -carddraw + p.ownMaxMana - p.mana + p.optionsPlayedThisTurn;

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

        private int getRandomPenaltiy(CardDB.Card card, Playfield p, Minion target)
        {
            if (p.turnCounter >= 1)
            {
                return 0;
            }

            if (!this.randomEffects.ContainsKey(card.name) && !(this.cardDrawBattleCryDatabase.ContainsKey(card.name) && card.type != CardDB.cardtype.SPELL))
            {
                return 0;
            }

            if (card.name == CardDB.cardName.brawl)
            {
                return 0;
            }

            if ((card.name == CardDB.cardName.cleave || card.name == CardDB.cardName.multishot) && p.enemyMinions.Count == 2)
            {
                return 0;
            }

            if ((card.name == CardDB.cardName.deadlyshot) && p.enemyMinions.Count == 1)
            {
                return 0;
            }

            if ((card.name == CardDB.cardName.arcanemissiles || card.name == CardDB.cardName.avengingwrath)
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
                if (mnn.name == CardDB.cardName.gadgetzanauctioneer)
                {
                    hasgadget = true;
                }

                if (mnn.name == CardDB.cardName.starvingbuzzard)
                {
                    hasstarving = true;
                }

                if (mnn.name == CardDB.cardName.knifejuggler)
                {
                    hasknife = true;
                }

                if (mnn.name == CardDB.cardName.flamewaker)
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
                    && (p.ownHeroAblility.card.name == CardDB.cardName.totemiccall || p.ownHeroAblility.card.name == CardDB.cardName.lifetap || p.ownHeroAblility.card.name == CardDB.cardName.soultap))
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
                    if (card.name == CardDB.cardName.knifejuggler && card.type == CardDB.cardtype.MOB)
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

                    if (hasgadget && card.type == CardDB.cardtype.SPELL)
                    {
                        continue;
                    }

                    if (hasFlamewaker && card.type == CardDB.cardtype.SPELL)
                    {
                        continue;
                    }

                    if (hasstarving && (TAG_RACE)card.race == TAG_RACE.PET)
                    {
                        continue;
                    }

                    if (hasknife && card.type == CardDB.cardtype.MOB)
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


        private int getBuffHandPenalityPlay(CardDB.cardName name, Playfield p)
        {
            if (!buffHandDatabase.ContainsKey(name)) return 0;

            Handmanager.Handcard hc;
            int anz = 0;
            switch (name)
            {
                case CardDB.cardName.troggbeastrager: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -5;
                    break;
                case CardDB.cardName.grimestreetsmuggler: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -5;
                    break;
                case CardDB.cardName.donhancho: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                    if (hc != null) return -20;
                    break;
                case CardDB.cardName.deathaxepunisher: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.LIFESTEAL);
                    if (hc != null) return -10;
                    break;
                case CardDB.cardName.grimscalechum: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.MURLOC);
                    if (hc == null) return -5;
                    break;
                case CardDB.cardName.grimestreetpawnbroker: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Weapon);
                    if (hc == null) return -5;
                    break;
                case CardDB.cardName.grimestreetoutfitter: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == CardDB.cardtype.MOB) anz++;
                    }
                    anz--; 
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
                case CardDB.cardName.themistcaller: 
                    foreach (Handmanager.Handcard hc1 in p.owncards)
                    {
                        if (hc1.card.type == CardDB.cardtype.MOB) anz++;
                    }
                    anz--; 
                    anz += p.ownDeckSize / 4;
                    return -1 * anz * 4;
                    break;
                case CardDB.cardName.hobartgrapplehammer: 
                    foreach (Handmanager.Handcard hc2 in p.owncards)
                    {
                        if (hc2.card.type == CardDB.cardtype.WEAPON) anz++;
                    }
                    if (anz == 0) return 2;
                    else return -1 * anz * 2;
                    break;
                case CardDB.cardName.smugglerscrate: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                    if (hc != null) return -10;
                    else return 10;
                    break;
                case CardDB.cardName.stolengoods: 
                    hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.TAUNT);
                    if (hc != null) return -15;
                    else return 10;
                    break;
                case CardDB.cardName.smugglersrun: 
                    foreach (Handmanager.Handcard hc3 in p.owncards)
                    {
                        if (hc3.card.type == CardDB.cardtype.MOB) anz++;
                    }
                    anz--; 
                    if (anz > 0) return -1 * anz * 4;
                    else return 5;
                    break;
            }
            return 0;
        }

        private int getCardDiscardPenality(CardDB.cardName name, Playfield p)
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
                        case CardDB.cardName.silverwaregolem: pen -= 12; continue;
                        case CardDB.cardName.fistofjaraxxus: pen -= 6; continue;
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

        private int getDestroyOwnPenality(CardDB.cardName name, Minion target, Playfield p)
        {
            if (!this.destroyOwnDatabase.ContainsKey(name)) return 0;
            
            switch (name)
            {
                case CardDB.cardName.sanguinereveler: goto case CardDB.cardName.shadowflame;
                case CardDB.cardName.ravenouspterrordax: goto case CardDB.cardName.shadowflame;
                case CardDB.cardName.shadowflame:
                    if (target == null || !target.Ready) return 0;
                    else return 1;
                case CardDB.cardName.deathwing:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    break;
                case CardDB.cardName.twistingnether: goto case CardDB.cardName.brawl;
                case CardDB.cardName.doompact: goto case CardDB.cardName.brawl;
                case CardDB.cardName.brawl:
                    if (p.mobsplayedThisTurn >= 1) return 500;
                    
                    if (name == CardDB.cardName.brawl && p.ownMinions.Count + p.enemyMinions.Count <= 1) return 500;
                    int highminion = 0;
                    int veryhighminion = 0;
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.Angr >= 5 || m.Hp >= 5) highminion++;
                        if (m.Angr >= 8 || m.Hp >= 8) veryhighminion++;
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
                        case CardDB.cardName.lepergnome: return -2;
                        case CardDB.cardName.backstreetleper: return -2;
                        case CardDB.cardName.firesworn: return -2;
                        case CardDB.cardName.zombiechow:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -5;
                            else return 500;
                        case CardDB.cardName.corruptedhealbot:
                            if (p.anzOwnAuchenaiSoulpriest > 0) return -8;
                            else return 500;
                        default:
                            int up = 0;
                            foreach (Minion m in p.ownMinions)
                            {
                                switch (m.handcard.card.name)
                                {
                                    case CardDB.cardName.manawyrm: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.flamewaker: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.archmageantonidas: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.gadgetzanauctioneer: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.manaaddict: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.redmanawyrm: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.summoningstone: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.wickedwitchdoctor: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.holychampion: goto case CardDB.cardName.lightwarden;
                                    case CardDB.cardName.lightwarden:
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
                        case CardDB.cardName.unwillingsacrifice:
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

        private int getDestroyPenality(CardDB.cardName name, Minion target, Playfield p)
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

                if (m.allreadyAttacked && name != CardDB.cardName.execute)
                {
                    return 50;
                }

                if (name == CardDB.cardName.shadowwordpain)
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

                if (name == CardDB.cardName.mindcontrol && (m.name == CardDB.cardName.direwolfalpha || m.name == CardDB.cardName.raidleader || m.name == CardDB.cardName.flametonguetotem) && p.enemyMinions.Count == 1)
                {
                    pen = 50;
                }

                if (m.name == CardDB.cardName.doomsayer)
                {
                    pen = 5;
                }

            }

            return pen;
        }

        private int getSpecialCardComboPenalitys(CardDB.Card card, Minion target, Playfield p)
        {
            bool lethal = p.isLethalCheck;
            CardDB.cardName name = card.name;

            if (lethal && card.type == CardDB.cardtype.MOB)
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
                            if (p.ownHero.Ready && p.ownHero.Angr >= 1) return 0;
                            break;
                        case 6:
                            foreach (Minion mm in p.ownMinions)
                            {
                                if (mm.name == CardDB.cardName.silverhandrecruit && mm.Ready) return 0;
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
                                if (mm.name == CardDB.cardName.cthun && mm.Ready) return 0;
                            }
                            break;
                    }
                    return 500;
                }
                else
                {
                    if ((name == CardDB.cardName.rendblackhand && target != null) && !target.own)
                    {
                        if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == CardDB.cardName.malganis)
                        {
                            foreach (Handmanager.Handcard hc in p.owncards)
                            {
                                if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) return 0;
                            }
                        }
                        return 500;
                    }

                    if (name == CardDB.cardName.theblackknight)
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
                                if (mm.Ready && (mm.handcard.card.name == CardDB.cardName.lightwarden || mm.handcard.card.name == CardDB.cardName.holychampion)) beasts++;
                            }
                            if (beasts == 0) return 500;
                        }
                        else
                        {
                            if (!(name == CardDB.cardName.nightblade || card.Charge || this.silenceDatabase.ContainsKey(name) || this.DamageTargetDatabase.ContainsKey(name) || ((TAG_RACE)card.race == TAG_RACE.PET && p.ownMinions.Find(x => x.name == CardDB.cardName.tundrarhino) != null) || p.owncards.Find(x => x.card.name == CardDB.cardName.charge) != null))
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
                case CardDB.cardName.hobartgrapplehammer: return -5; 
                case CardDB.cardName.bloodsailraider: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.cardName.captaingreenskin: if (p.ownWeapon.Durability == 0) return 10; return 0; 
                case CardDB.cardName.luckydobuccaneer: if (!(p.ownWeapon.Durability > 0 && p.ownWeapon.Angr > 2)) return 10; return 0; 
                case CardDB.cardName.nagacorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.cardName.goblinautobarber: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.cardName.dreadcorsair: if (p.ownWeapon.Durability == 0) return 5; return 0; 
                case CardDB.cardName.grimestreetpawnbroker: 
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.WEAPON) return 0;
                    return 5;
                case CardDB.cardName.bloodsailcultist: ; 
                    if (p.ownWeapon.Durability > 0) foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) return 0;
                    return 8;
                case CardDB.cardName.ravasaurrunt: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardDB.cardName.nestingroc: 
                    if (p.ownMinions.Count < 2) return 5;
                    break;
                case CardDB.cardName.gentlemegasaur: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardDB.cardName.primalfinlookout: 
                    targets = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) targets++;
                    }
                    return 20 - targets * 5;
                case CardDB.cardName.spiritecho: 
                    if (p.ownQuest.Id == CardDB.cardIDEnum.UNG_942)
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
                case CardDB.cardName.evolvingspores: 
                    if (p.ownMinions.Count < 3) return 15 - p.ownMinions.Count * 5;
                    return 0;
                case CardDB.cardName.livingmana: 
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
                case CardDB.cardName.elisethetrailblazer: return -7; 
                case CardDB.cardName.cracklingrazormaw:   
                    if (target != null) return 0;
                    return 5;
                case CardDB.cardName.dinomancy: return -7; 
                case CardDB.cardName.moltenblade: return -10; 
                case CardDB.cardName.gluttonousooze: goto case CardDB.cardName.acidicswampooze;
                case CardDB.cardName.acidicswampooze:
                    if (p.enemyWeapon.Angr > 0) return 0;
                    if (p.enemyHeroName == HeroEnum.shaman || p.enemyHeroName == HeroEnum.warrior || p.enemyHeroName == HeroEnum.thief || p.enemyHeroName == HeroEnum.pala) return 10;
                    if (p.enemyHeroName == HeroEnum.hunter) return 6;
                    return 0;
                case CardDB.cardName.darkshirecouncilman:
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
                case CardDB.cardName.deadmanshand: 
                    if (p.owncards.Count > 2) return -5 * p.owncards.Count;
                    break;
                case CardDB.cardName.bringiton: 
                    return 3 * p.enemyAnzCards * (11 - p.enemyMaxMana);
                case CardDB.cardName.strongshellscavenger:
                    int tmp = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp++;
                    return 12 - tmp * 2;

            }

            if (name == CardDB.cardName.unstableportal && p.owncards.Count <= 9) return -15;
            if (name == CardDB.cardName.lunarvisions && p.owncards.Count <= 8) return -5;

            if (name == CardDB.cardName.azuredrake)
            {
                pen = 0;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (mnn.Angr > 3 && p.anzOwnTaunt == 0)
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
                        if (hc.card.name == CardDB.cardName.menageriewarden) { menageriewarden = true; continue; }
                        if ((TAG_RACE)hc.card.race == TAG_RACE.PET && hc.card.cost <= p.ownMaxMana) pet = true;
                    }
                    if (menageriewarden && pet) pen += 23;
                }
                return pen;
            }

            if (name == CardDB.cardName.manatidetotem)
            {
                if (p.owncards.Count > 2)
                {
                    int eAngr = p.enemyWeapon.Angr;
                    foreach (Minion em in p.enemyMinions)
                    {
                        if (!em.frozen) eAngr += em.Angr;
                    }
                    if (p.anzOwnTaunt > 0)
                    {
                        foreach (Minion om in p.ownMinions)
                        {
                            if (om.taunt) eAngr -= om.Hp;
                        }
                    }
                    if (eAngr >= 3) return 5;
                }
                return 0;
            }

            if (name == CardDB.cardName.menageriewarden)
            {
                if (target != null && (TAG_RACE)target.handcard.card.race == TAG_RACE.PET) return 0;
                else return 10;
            }

            if (name == CardDB.cardName.duplicate)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.mirrorentity)
                    {
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.handcard.card.Attack >= 3 && this.UsefulNeedKeepDatabase.ContainsKey(mnn.name)) return 0;
                        }
                        return 16;
                    }
                }
            }

            if ((name == CardDB.cardName.lifetap || name == CardDB.cardName.soultap) && p.owncards.Count <= 9)
            {
                 foreach (Minion mnn in p.ownMinions)
                 {
                     if (mnn.name == CardDB.cardName.wilfredfizzlebang && !mnn.silenced) return -20;
                 }
            }

            if (name == CardDB.cardName.forbiddenritual)
            {
                if (p.ownMinions.Count == 7 || p.mana == 0) return 500;
                return 7;
            }
            
            if (name == CardDB.cardName.competitivespirit)
            {
                if (p.ownMinions.Count < 1) return 500;
                if (p.ownMinions.Count > 2) return 0;
                return (15 - 5 * p.ownMinions.Count);
            }

            if (name == CardDB.cardName.shifterzerus) return 500;

            if (card.name == CardDB.cardName.daggermastery)
            {
                if (p.ownWeapon.Angr >= 2 || p.ownWeapon.Durability >= 2) return 5;
            }

            if (card.name == CardDB.cardName.upgrade)
            {
                if (p.ownWeapon.Durability == 0)
                {
                    if (weaponInHandAttackNextTurn(p) > 0) return 10;
                    return 0;
                }
            }

            if (card.name == CardDB.cardName.malchezaarsimp && p.owncards.Count > 2) return 5;

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
                    if (hc.manacost <= p.ownMaxMana && hc.card.type == CardDB.cardtype.MOB) return 5;
                }

            }
            
            //destroySecretPenality
            pen = 0;
            switch (card.name)
            {
                case CardDB.cardName.flare: 
                    foreach (Minion mn in p.ownMinions) if (mn.stealth) pen++;
                    foreach (Minion mn in p.enemyMinions) if (mn.stealth) pen--;
                    if (p.enemySecretCount > 0)
                    {
                        bool canPlayMinion = false;
                        bool canPlaySpell = false;
                        foreach(Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.name == CardDB.cardName.flare) continue;
                            if (hc.card.cost <= p.mana - 2) 
                            {
                                if (!canPlayMinion && hc.card.type == CardDB.cardtype.MOB)
                                {
                                    
                                    int tmp = p.getSecretTriggersByType(0, true, false, target);
                                    if (tmp > 0) pen -= tmp * 50;
                                    canPlayMinion = true;
                                    continue;
                                }
                                if (!canPlaySpell && hc.card.type == CardDB.cardtype.SPELL)
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
                case CardDB.cardName.eaterofsecrets: 
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
                case CardDB.cardName.kezanmystic: 
                    if (p.enemySecretCount == 1 && p.playactions.Count == 0) pen -= 50;
                    break;

                case CardDB.cardName.totemiccall:
                    if (lethal) return 20;
                    break;

                case CardDB.cardName.frostwolfwarlord:
                    if (p.ownMinions.Count == 0) pen += 5;
                    break;

                case CardDB.cardName.flametonguetotem:
                    if (p.ownMinions.Count == 0) return 100;
                    break;
                
                case CardDB.cardName.stampedingkodo:
                    bool found = false;
                    foreach (Minion mi in p.enemyMinions)
                    {
                        if (mi.Angr <= 2) found = true;
                    }
                    if (!found) return 20;
                    break;

                case CardDB.cardName.windfury:
                    if (!target.own) return 500;
                    else if (!target.Ready) return 500;
                    break;

                case CardDB.cardName.desperatestand: goto case CardDB.cardName.ancestralspirit;
                case CardDB.cardName.ancestralspirit:
                    if (!target.isHero)
                    {
                        if (!target.own)
                        {
                            if (target.name == CardDB.cardName.deathlord || target.name == CardDB.cardName.zombiechow || target.name == CardDB.cardName.dancingswords) return 0;
                            return 500;
                        }
                        else
                        {
                            if (this.specialMinions.ContainsKey(target.name)) return -5;
                            return 0;
                        }
                    }
                    break;

                case CardDB.cardName.houndmaster:
                    if (target == null) return 50;
                    break;

                case CardDB.cardName.beneaththegrounds: return -10;

                case CardDB.cardName.curseofrafaam: return -7;

                case CardDB.cardName.flameimp:
                    if (p.ownHero.Hp + p.ownHero.armor > 20) pen -= 3;
                    break;
             

                case CardDB.cardName.quartermaster:
                    foreach (Minion mm in p.ownMinions)
                    {
                        if (mm.name == CardDB.cardName.silverhandrecruit) return 0;
                    }
                    return 5;

                case CardDB.cardName.mysteriouschallenger: return -14;

                case CardDB.cardName.biggamehunter:
                    if (target == null || target.own) return 40;
                    break;
                    
                case CardDB.cardName.emergencycoolant:
                    if (target != null && target.own) pen = 500;
                    break;

                case CardDB.cardName.shatteredsuncleric:
                    if (target == null) return 10;
                    break;

                case CardDB.cardName.argentprotector:
                    if (target == null) pen = 20;
                    else
                    {
                        if (!target.own) return 500;
                        if (!target.Ready && !target.handcard.card.isSpecialMinion)
                        {
                            if (target.Angr <= 2 && target.Hp <= 2) pen = 15;
                            else pen = 10;
                        }
                    }
                    break;

                case CardDB.cardName.facelessmanipulator:
                    if (target == null) return 50;
                    if (target.Angr >= 5 || target.handcard.card.cost >= 5 || (target.handcard.card.rarity == 5 || target.handcard.card.cost >= 3))
                    {
                        return 0;
                    }
                    return 49;

                case CardDB.cardName.rendblackhand:
                    if (target == null) return 15;
                    if (target.own) return 100;
                    if ((target.taunt && target.handcard.card.rarity == 5) || target.handcard.card.name == CardDB.cardName.malganis)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) return 0;
                        }
                    }
                    return 500;

                case CardDB.cardName.theblackknight:
                    if (target == null) return 50;
                    foreach (Minion mnn in p.enemyMinions)
                    {
                        if (mnn.taunt && (target.Angr >= 3 || target.Hp >= 3)) return 0;
                    }
                    return 20;

                case CardDB.cardName.madderbomber: goto case CardDB.cardName.madbomber;
                case CardDB.cardName.madbomber:
                    pen = 0;
                    foreach (Minion mnn in p.ownMinions)
                    {
                        if (mnn.Ready & mnn.Hp < 3) pen += 5;
                    }
                    return pen;

                case CardDB.cardName.sylvanaswindrunner:
                    if (p.enemyMinions.Count == 0) return 10;
                    break;

                case CardDB.cardName.betrayal:
                    if (!target.own && !target.isHero)
                    {
                        if (target.Angr == 0) return 30;
                        if (p.enemyMinions.Count == 1) return 30;
                    }
                    break;

                case CardDB.cardName.nerubianegg:
                    if (p.owncards.Find(x => this.attackBuffDatabase.ContainsKey(x.card.name)) != null || p.owncards.Find(x => this.tauntBuffDatabase.ContainsKey(x.card.name)) != null)
                    {
                        return -6;
                    }
                    break;

                case CardDB.cardName.bite:
                    if ((p.ownHero.numAttacksThisTurn == 0 || (p.ownHero.windfury && p.ownHero.numAttacksThisTurn == 1)) && !p.ownHero.frozen)
                    {

                    }
                    else return 20;
                    break;

                case CardDB.cardName.deadlypoison:
                    return -(p.ownWeapon.Durability - 1) * 2;

                case CardDB.cardName.coldblood:
                    if (lethal) return 0;
                    return 25;

                case CardDB.cardName.bloodmagethalnos: return 10;

                case CardDB.cardName.frostbolt:
                    if (!target.own && !target.isHero)
                    {
                        if (target.handcard.card.cost < 3 && !this.priorityDatabase.ContainsKey(target.handcard.card.name)) return 15;
                    }
                    return 0;

                case CardDB.cardName.poweroverwhelming:
                    if (target.own && !target.isHero && !target.Ready) return 500;
                    break;

                case CardDB.cardName.frothingberserker:
                    if (p.cardsPlayedThisTurn >= 1) pen = 5;
                    break;

                case CardDB.cardName.handofprotection:
                    if (!target.own)
                    {
                        foreach (Minion mm in p.ownMinions)
                        {
                            if (!mm.divineshild) return 500;
                        }
                    }
                    if (target.Hp == 1) pen = 15;
                    break;

                case CardDB.cardName.wildgrowth: goto case CardDB.cardName.nourish;
                case CardDB.cardName.nourish:
                    if (p.ownMaxMana == 9 && !(p.ownHeroName == HeroEnum.thief && p.cardsPlayedThisTurn == 0)) return 500;
                    break;

                case CardDB.cardName.resurrect:
                    if (p.ownMaxMana < 6) return 50;
                    if (p.ownMinions.Count == 7) return 500;
                    if (p.ownMaxMana > 8) return 0;
                    if (p.OwnLastDiedMinion == CardDB.cardIDEnum.None) return 6;
                    return 0;

                case CardDB.cardName.lavashock:
                    if (p.ueberladung + p.lockedMana < 1) return 15;
                    return (3 - 3 * (p.ueberladung + p.lockedMana));

                case CardDB.cardName.edwinvancleef:
                    if (p.cardsPlayedThisTurn < 1) return 30;
                    else if (p.cardsPlayedThisTurn < 2) return 10;
                    else return 0;

                case CardDB.cardName.enhanceomechano:
                    if (p.ownMinions.Count == 0 && p.ownMaxMana < 5) return 500;
                    pen = 2 * (p.mana - 4 - p.mobsplayedThisTurn);
                    if (p.mobsplayedThisTurn < 1) pen += 30;
                    return pen;

                case CardDB.cardName.knifejuggler:
                    if (p.mobsplayedThisTurn >= 1) return 20;
                    break;

                case CardDB.cardName.flamewaker:
                    foreach (Action a in p.playactions)
                    {
                        if (a.actionType == actionEnum.playcard && a.card.card.type == CardDB.cardtype.SPELL) return 30;
                    }
                    break;

                case CardDB.cardName.polymorph: goto case CardDB.cardName.hex;
                case CardDB.cardName.hex:
                    if (!target.isHero)
                    {
                        if (target.own)
                        {
                            if (target.name == CardDB.cardName.masterchest) return -5;
                            else return 500;
                        }
                        else
                        {
                            if (target.allreadyAttacked) return 30;
                            Minion frog = target;
                            if (this.priorityTargets.ContainsKey(frog.name)) return 0;
                            if (frog.Angr >= 4 && frog.Hp >= 4) return 0;
                            if (frog.Angr >= 2 && frog.Hp >= 6) return 5;
                            return 30;
                        }
                    }
                    break;

                case CardDB.cardName.ravagingghoul:
                    if (p.enemyMinions.Count == 0) return 7;
                    break;

                case CardDB.cardName.bookwyrm:
                    if (target == null) return 20;
                    else
                    {
                        if (this.priorityTargets.ContainsKey(target.name) || this.priorityDatabase.ContainsKey(target.name))
                        {
                            if (target.Hp > 3) return -6;
                            return -3;
                        }
                        else if (target.maxHp > 3) return 0;
                        else return 5;
                    }
                    break;

                case CardDB.cardName.grimestreetprotector:
                    if (p.ownMinions.Count == 1) return 10;
                    else if (p.ownMinions.Count == 0) return 20;
                    break;

                case CardDB.cardName.sunfuryprotector:
                    if (p.ownMinions.Count == 1) return 15;
                    else if (p.ownMinions.Count == 0) return 30;
                    break;

                case CardDB.cardName.defenderofargus:
                    if (p.ownMinions.Count == 1) return 30;
                    else if (p.ownMinions.Count == 0) return 50;
                    break;

                case CardDB.cardName.unearthedraptor:
                    if (target == null) return 10;
                    break;

                case CardDB.cardName.unleashthehounds:
                    if (p.enemyMinions.Count <= 1) return 20;
                    break;

                case CardDB.cardName.equality:
                    if (p.enemyMinions.Count <= 2 || (p.ownMinions.Count - p.enemyMinions.Count >= 1)) return 20;
                    break;

                case CardDB.cardName.bloodsailraider:
                    if (p.ownWeapon.Durability == 0)
                    {
                        foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if (hc.card.type == CardDB.cardtype.WEAPON) return 10;
                        }
                    }
                    break;

                case CardDB.cardName.innerfire:
                    if (target.name == CardDB.cardName.lightspawn) return 500;
                    if (!target.Ready) return 20;
                    break;

                case CardDB.cardName.huntersmark:
                    if (!target.isHero)
                    {
                        if (target.own) return 500;
                        else if (target.Hp <= 4 && target.Angr <= 4 && !(target.poisonous && !target.silenced))
                        {
                            pen = 20;
                        }
                    }
                    break;

                case CardDB.cardName.crazedalchemist:
                    if (target != null) pen -= 1;
                    break;

                case CardDB.cardName.deathwing:
                    int prevDmg = 0;
                    foreach (Minion m1 in p.enemyMinions)
                    {
                        prevDmg += m1.Angr;
                    }
                    if (p.ownHero.Hp + p.ownHero.armor > prevDmg * 2) pen += p.ownMinions.Count * 10 + p.owncards.Count * 25;
                    break;

                case CardDB.cardName.deathwingdragonlord:
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) pen -= 3;
                    }
                    pen += 3;
                    break;

                case CardDB.cardName.humility: goto case CardDB.cardName.aldorpeacekeeper;
                case CardDB.cardName.aldorpeacekeeper:
                    if (target != null)
                    {
                        if (target.own) pen = 500;
                        else if (target.Angr <= 3) pen = 30;
                        if (target.name == CardDB.cardName.lightspawn) pen = 500;
                    }
                    else pen = 40;
                    break;
            
                case CardDB.cardName.direwolfalpha: goto case CardDB.cardName.abusivesergeant;
                case CardDB.cardName.abusivesergeant:
                    int ready = 0;
                    foreach (Minion min in p.ownMinions)
                    {
                        if (min.Ready) ready++;
                    }
                    if (ready == 0) pen = 5;
                    break;
                    
                case CardDB.cardName.gangup:
                    if (this.GangUpDatabase.ContainsKey(target.handcard.card.name))
                    {
                        return (-5 - 1 * GangUpDatabase[target.handcard.card.name]);
                    }
                    else return 40;
                    
                case CardDB.cardName.defiasringleader:
                    if (p.cardsPlayedThisTurn == 0) pen = 10;
                    break;

                case CardDB.cardName.bloodknight:
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

                case CardDB.cardName.reincarnate:
                    if (target.own)
                    {
                        if (target.handcard.card.deathrattle || target.ancestralspirit >= 1 || target.desperatestand >= 1 || target.souloftheforest >= 1 || target.stegodon >= 1 || target.livingspores >= 1 || target.infest >= 1 || target.explorershat >= 1 || target.returnToHand >= 1 || target.deathrattle2 != null || target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.handcard.card.Charge && ((target.numAttacksThisTurn == 1 && !target.windfury) || (target.numAttacksThisTurn == 2 && target.windfury))) return 0;
                        if (target.wounded || target.Angr < target.handcard.card.Attack || (target.silenced && this.specialMinions.ContainsKey(target.name))) return 0;
                        
                        bool hasOnMinionDiesMinion = false;
                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (mnn.name == CardDB.cardName.scavenginghyena && target.handcard.card.race == 20) hasOnMinionDiesMinion = true;
                            if (mnn.name == CardDB.cardName.flesheatingghoul || mnn.name == CardDB.cardName.cultmaster) hasOnMinionDiesMinion = true;
                        }
                        if (hasOnMinionDiesMinion) return 0;
                        return 500;
                    }
                    else
                    {
                        if (target.name == CardDB.cardName.nerubianegg && target.Angr <= 4 && !target.taunt) return 500;
                        if (target.taunt && !target.handcard.card.tank) return 0;
                        if (target.enemyBlessingOfWisdom >= 1 || target.enemyPowerWordGlory >= 1) return 0;
                        if (target.Angr > target.handcard.card.Attack || target.Hp > target.handcard.card.Health) return 0;
                        if (target.name == CardDB.cardName.abomination || target.name == CardDB.cardName.zombiechow || target.name == CardDB.cardName.unstableghoul || target.name == CardDB.cardName.dancingswords) return 0;
                        return 500;
                    }
                    break;

                case CardDB.cardName.divinespirit:
                    if (!target.isHero)
                    {
                        if (target.own)
                        {
                            if (target.Hp >= 4) return 0;
                            return 15;
                        }
                        else if (lethal)
                        {
                            if (!target.taunt) return 500;
                            else
                            {
                                // combo for killing with innerfire and biggamehunter
                                if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && (target.Hp >= 4 || (p.owncards.Find(x => x.card.name == CardDB.cardName.divinespirit) != null && target.Hp >= 2)))
                                {
                                    return 0;
                                }
                                return 500;
                            }
                        }
                        else
                        {
                            // combo for killing with innerfire and biggamehunter
                            if (p.owncards.Find(x => x.card.name == CardDB.cardName.biggamehunter) != null && p.owncards.Find(x => x.card.name == CardDB.cardName.innerfire) != null && target.Hp >= 4)
                            {
                                return 0;
                            }
                            return 500;
                        }
                    }
                    break;
            }


            //------------------------------------------------------------------------------------------------------


            if ((p.ownHeroAblility.card.name == CardDB.cardName.totemiccall || p.ownHeroAblility.card.name == CardDB.cardName.totemicslam) && p.ownAbilityReady == false)
            {
                if (p.owncards.Count > 1)
                {
                    if (card.type == CardDB.cardtype.SPELL)
                    {
                        if (!(DamageTargetDatabase.ContainsKey(card.name) || DamageAllEnemysDatabase.ContainsKey(card.name) 
                            || DamageAllDatabase.ContainsKey(card.name) || DamageRandomDatabase.ContainsKey(card.name) 
                            || DamageTargetSpecialDatabase.ContainsKey(card.name) || DamageHeroDatabase.ContainsKey(card.name))) pen += 10;
                    }
                    else if (card.name == CardDB.cardName.frostwolfwarlord || card.name == CardDB.cardName.thingfrombelow) return -1;
                    else pen += 10;
                }
            }

            if (target != null && (name == CardDB.cardName.sap || name == CardDB.cardName.dream || name == CardDB.cardName.kidnapper))
            {
                if (!target.own && (target.name == CardDB.cardName.theblackknight || name == CardDB.cardName.rendblackhand))
                {
                    return 50;
                }
            }

            if (!lethal && card.cardIDenum == CardDB.cardIDEnum.EX1_165t1) //druidoftheclaw	Charge
            {
                return 20;
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


            if (returnHandDatabase.ContainsKey(name))
            {
                if (target != null && target.own && !target.isHero && target.Ready) pen += 10;

                switch (target.name)
                {
                    case CardDB.cardName.masterchest: return target.own ? -21 : 5;
                }

                if (card.type == CardDB.cardtype.SPELL)
                {
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
                                case CardDB.cardName.ramwrangler: BeastReq = true; break;
                                case CardDB.cardName.druidofthefang: BeastReq = true; break;
                                case CardDB.cardName.goblinblastmage: MechReq = true; break;
                                case CardDB.cardName.tinkertowntechnician: MechReq = true; break;
                                case CardDB.cardName.shadydealer: if (!target.Ready && target.maxHp == 3) PirateReq = true; break;
                                case CardDB.cardName.gormoktheimpaler: if (p.ownMinions.Count > 4) return 0; break;
                                case CardDB.cardName.corerager: if (p.owncards.Count < 1) return 0; break;
                                case CardDB.cardName.drakonidcrusher: if (p.enemyHero.Hp < 16) return 0; break;
                                case CardDB.cardName.mindcontroltech: if (p.enemyMinions.Count > 3) return 0; break;
                                case CardDB.cardName.alexstraszaschampion: if (target.Ready) DragonReq = false; break;
                                case CardDB.cardName.twilightguardian: if (target.taunt) DragonReq = false; break;
                                case CardDB.cardName.wyrmrestagent: if (target.taunt) DragonReq = false; break;
                                case CardDB.cardName.blackwingtechnician: if (target.maxHp > 4) DragonReq = false; break;
                                case CardDB.cardName.twilightwhelp: if (target.maxHp > 1) DragonReq = false; break;
                                case CardDB.cardName.kingselekk: return 0; break;
                                case CardDB.cardName.gadgetzanjouster: if (target.maxHp == 2) return 0; break;
                                case CardDB.cardName.armoredwarhorse: if (!target.Ready) return 0; break;
                                case CardDB.cardName.masterjouster: if (!target.taunt) return 0; break;
                                case CardDB.cardName.tuskarrjouster: if (!target.Ready && p.ownHero.Hp < 26) return 0; break;
                            }
                        }

                        foreach (Minion mnn in p.ownMinions)
                        {
                            if (this.spellDependentDatabase.ContainsKey(mnn.name) && mnn.entitiyID != target.entitiyID) return 0;
                            if (mnn.name == CardDB.cardName.starvingbuzzard && mnn.entitiyID != target.entitiyID && target.handcard.card.race == 20) return 0;

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
                    if (hc.card.name == CardDB.cardName.kirintormage && p.mana >= hc.getManaCost(p))
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
                case CardDB.cardName.flare: return 0; break; 
                case CardDB.cardName.eaterofsecrets: return 0; break; 
                case CardDB.cardName.kezanmystic: 
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

            if ((c.name == CardDB.cardName.acidicswampooze || c.name == CardDB.cardName.gluttonousooze)
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
                if (c.type == CardDB.cardtype.MOB
                    && (attackedbefore == 0 || c.Health <= 4
                        || (p.enemyHero.Hp >= p.enemyHeroHpStarted && attackedbefore >= 1)))
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.MAGE)
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
                    if ((!this.isOwnLowestInHand(m, p) && p.mobsplayedThisTurn == 0)
                        || (p.mobsplayedThisTurn == 0 && attackedbefore >= 1))
                    {
                        pen += 10;
                    }
                }

                if (c.type == CardDB.cardtype.SPELL && p.cardsPlayedThisTurn == p.mobsplayedThisTurn)
                {
                    pen += 10;
                }
            }

            if (p.enemyHeroStartClass == TAG_CLASS.PALADIN)
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
                                    if (a.card.card.type == CardDB.cardtype.MOB || a.card.card.playrequires.Contains(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
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
                                if (hc.card.type == CardDB.cardtype.MOB && hc.canplayCard(p, true)) { pen += 10; break; }
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
                        if (target.Hp > m.Angr || target.divineshild) return 0;
                        else
                        {
                            pen += target.handcard.card.cost;
                            if (target.handcard.card.battlecry && target.name != CardDB.cardName.kingmukla) pen += 1;
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
                    if (!isEnemyLowest(target, p) || m.Hp <= 2) pen += 5;
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

        public int getValueOfUsefulNeedKeepPriority(CardDB.cardName name)
        {
            return UsefulNeedKeepDatabase.ContainsKey(name) ? UsefulNeedKeepDatabase[name] : 0;
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
                if (m.Hp <= 2 && (m.Ready || this.priorityDatabase.ContainsKey(m.name))) ret = true;
            }
            return ret;
        }

        public int guessTotalSpellDamage(Playfield p, CardDB.cardName name, bool ownplay)
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
            enrageDatabase.Add(CardDB.cardName.aberrantberserker, 2);
            enrageDatabase.Add(CardDB.cardName.amaniberserker, 3);
            enrageDatabase.Add(CardDB.cardName.angrychicken, 5);
            enrageDatabase.Add(CardDB.cardName.bloodhoofbrave, 3);
            enrageDatabase.Add(CardDB.cardName.grommashhellscream, 6);
            enrageDatabase.Add(CardDB.cardName.ragingworgen, 2);
            enrageDatabase.Add(CardDB.cardName.spitefulsmith, 2);
            enrageDatabase.Add(CardDB.cardName.taurenwarrior, 3);
            enrageDatabase.Add(CardDB.cardName.warbot, 1);
        }

        private void setupHealDatabase()
        {
            HealAllDatabase.Add(CardDB.cardName.circleofhealing, 4);//allminions
            HealAllDatabase.Add(CardDB.cardName.darkscalehealer, 2);//all friends
            HealAllDatabase.Add(CardDB.cardName.holynova, 2);//to all own minions
            HealAllDatabase.Add(CardDB.cardName.treeoflife, 1000);//all friends

            HealHeroDatabase.Add(CardDB.cardName.amarawardenofhope, 40);
            HealHeroDatabase.Add(CardDB.cardName.antiquehealbot, 8); //tohero
            HealHeroDatabase.Add(CardDB.cardName.bindingheal, 5);
            HealHeroDatabase.Add(CardDB.cardName.cultapothecary, 2);
            HealHeroDatabase.Add(CardDB.cardName.drainlife, 2);//tohero
            HealHeroDatabase.Add(CardDB.cardName.guardianofkings, 6);//tohero
            HealHeroDatabase.Add(CardDB.cardName.holyfire, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.invocationofwater, 12);
            HealHeroDatabase.Add(CardDB.cardName.jinyuwaterspeaker, 6);
            HealHeroDatabase.Add(CardDB.cardName.priestessofelune, 4);//tohero
            HealHeroDatabase.Add(CardDB.cardName.refreshmentvendor, 4);
            HealHeroDatabase.Add(CardDB.cardName.renojackson, 25); //tohero
            HealHeroDatabase.Add(CardDB.cardName.sacrificialpact, 5);//tohero
            HealHeroDatabase.Add(CardDB.cardName.sealoflight, 4); //tohero
            HealHeroDatabase.Add(CardDB.cardName.siphonsoul, 3); //tohero
            HealHeroDatabase.Add(CardDB.cardName.tidalsurge, 4);
            HealHeroDatabase.Add(CardDB.cardName.tournamentmedic, 2);
            HealHeroDatabase.Add(CardDB.cardName.tuskarrjouster, 7);
            HealHeroDatabase.Add(CardDB.cardName.twilightdarkmender, 10);

            HealTargetDatabase.Add(CardDB.cardName.ancestralhealing, 1000);
            HealTargetDatabase.Add(CardDB.cardName.ancientoflore, 5);
            HealTargetDatabase.Add(CardDB.cardName.ancientsecrets, 5);
            HealTargetDatabase.Add(CardDB.cardName.bindingheal, 5);
            HealTargetDatabase.Add(CardDB.cardName.darkshirealchemist, 5);
            HealTargetDatabase.Add(CardDB.cardName.earthenringfarseer, 3);
            HealTargetDatabase.Add(CardDB.cardName.flashheal, 5);
            HealTargetDatabase.Add(CardDB.cardName.forbiddenhealing, 2);
            HealTargetDatabase.Add(CardDB.cardName.gadgetzansocialite, 2);
            HealTargetDatabase.Add(CardDB.cardName.heal, 4);
            HealTargetDatabase.Add(CardDB.cardName.healingtouch, 8);
            HealTargetDatabase.Add(CardDB.cardName.healingwave, 14);
            HealTargetDatabase.Add(CardDB.cardName.holylight, 6);
            HealTargetDatabase.Add(CardDB.cardName.hotspringguardian, 3);
            HealTargetDatabase.Add(CardDB.cardName.hozenhealer, 30);
            HealTargetDatabase.Add(CardDB.cardName.layonhands, 8);
            HealTargetDatabase.Add(CardDB.cardName.lesserheal, 2);
            HealTargetDatabase.Add(CardDB.cardName.lightofthenaaru, 3);
            HealTargetDatabase.Add(CardDB.cardName.moongladeportal, 6);
            HealTargetDatabase.Add(CardDB.cardName.voodoodoctor, 2);
            HealTargetDatabase.Add(CardDB.cardName.willofmukla, 8);
            //HealTargetDatabase.Add(CardDB.cardName.divinespirit, 2);
        }

        private void setupDamageDatabase()
        {
            //DamageAllDatabase.Add(CardDB.cardName.flameleviathan, 2);
            DamageAllDatabase.Add(CardDB.cardName.abomination, 2);
            DamageAllDatabase.Add(CardDB.cardName.abyssalenforcer, 3);
            DamageAllDatabase.Add(CardDB.cardName.anomalus, 8);
            DamageAllDatabase.Add(CardDB.cardName.barongeddon, 2);
            DamageAllDatabase.Add(CardDB.cardName.corruptedseer, 2);
            DamageAllDatabase.Add(CardDB.cardName.demonwrath, 1);
            DamageAllDatabase.Add(CardDB.cardName.dragonfirepotion, 5);
            DamageAllDatabase.Add(CardDB.cardName.dreadinfernal, 1);
            DamageAllDatabase.Add(CardDB.cardName.dreadscale, 1);
            DamageAllDatabase.Add(CardDB.cardName.elementaldestruction, 4);
            DamageAllDatabase.Add(CardDB.cardName.excavatedevil, 3);
            DamageAllDatabase.Add(CardDB.cardName.explosivesheep, 2);
            DamageAllDatabase.Add(CardDB.cardName.felbloom, 4);
            DamageAllDatabase.Add(CardDB.cardName.felfirepotion, 5);
            DamageAllDatabase.Add(CardDB.cardName.hellfire, 3);
            DamageAllDatabase.Add(CardDB.cardName.lava, 2);
            DamageAllDatabase.Add(CardDB.cardName.lightbomb, 5);
            DamageAllDatabase.Add(CardDB.cardName.magmapulse, 1);
            DamageAllDatabase.Add(CardDB.cardName.primordialdrake, 2);
            DamageAllDatabase.Add(CardDB.cardName.ravagingghoul, 1);
            DamageAllDatabase.Add(CardDB.cardName.revenge, 1);
            DamageAllDatabase.Add(CardDB.cardName.scarletpurifier, 2);
            DamageAllDatabase.Add(CardDB.cardName.sleepwiththefishes, 3);
            DamageAllDatabase.Add(CardDB.cardName.tentacleofnzoth, 1);
            DamageAllDatabase.Add(CardDB.cardName.unstableghoul, 1);
            DamageAllDatabase.Add(CardDB.cardName.volcanicpotion, 2);
            DamageAllDatabase.Add(CardDB.cardName.whirlwind, 1);
            DamageAllDatabase.Add(CardDB.cardName.yseraawakens, 5);
            DamageAllDatabase.Add(CardDB.cardName.spiritlash, 1);
            DamageAllDatabase.Add(CardDB.cardName.defile, 1);
            DamageAllDatabase.Add(CardDB.cardName.bloodrazor, 1);
            DamageAllDatabase.Add(CardDB.cardName.bladestorm, 1);

            DamageAllEnemysDatabase.Add(CardDB.cardName.arcaneexplosion, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.bladeflurry, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.blizzard, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.consecration, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.cthun, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.darkironskulker, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.fanofknives, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.flamestrike, 4);
            DamageAllEnemysDatabase.Add(CardDB.cardName.holynova, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.invocationofair, 3);
            DamageAllEnemysDatabase.Add(CardDB.cardName.lightningstorm, 3);
            DamageAllEnemysDatabase.Add(CardDB.cardName.livingbomb, 5);
            DamageAllEnemysDatabase.Add(CardDB.cardName.locustswarm, 3);
            DamageAllEnemysDatabase.Add(CardDB.cardName.maelstromportal, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.poisoncloud, 1);//todo 1 or 2
            DamageAllEnemysDatabase.Add(CardDB.cardName.sergeantsally, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.shadowflame, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.sporeburst, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.starfall, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.stomp, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.swipe, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.twilightflamecaller, 1);
            DamageAllEnemysDatabase.Add(CardDB.cardName.explodingbloatbat, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.deathstalkerrexxar, 2);
            DamageAllEnemysDatabase.Add(CardDB.cardName.deathanddecay, 3);
            DamageAllEnemysDatabase.Add(CardDB.cardName.bonestorm, 1);

            DamageHeroDatabase.Add(CardDB.cardName.backstreetleper, 2);
            DamageHeroDatabase.Add(CardDB.cardName.burningadrenaline, 2);
            DamageHeroDatabase.Add(CardDB.cardName.curseofrafaam, 2);
            DamageHeroDatabase.Add(CardDB.cardName.emeraldreaver, 1);
            DamageHeroDatabase.Add(CardDB.cardName.frostblast, 3);
            DamageHeroDatabase.Add(CardDB.cardName.headcrack, 2);
            DamageHeroDatabase.Add(CardDB.cardName.invocationoffire, 6);
            DamageHeroDatabase.Add(CardDB.cardName.lepergnome, 2);
            DamageHeroDatabase.Add(CardDB.cardName.mindblast, 5);
            DamageHeroDatabase.Add(CardDB.cardName.necroticaura, 3);
            DamageHeroDatabase.Add(CardDB.cardName.nightblade, 3);
            DamageHeroDatabase.Add(CardDB.cardName.purecold, 8);
            DamageHeroDatabase.Add(CardDB.cardName.shadowbomber, 3);
            DamageHeroDatabase.Add(CardDB.cardName.sinisterstrike, 3);

            DamageRandomDatabase.Add(CardDB.cardName.arcanemissiles, 1);
            DamageRandomDatabase.Add(CardDB.cardName.avengingwrath, 1);
            DamageRandomDatabase.Add(CardDB.cardName.bomblobber, 4);
            DamageRandomDatabase.Add(CardDB.cardName.boombot, 1);
            DamageRandomDatabase.Add(CardDB.cardName.boombotjr, 1);
            DamageRandomDatabase.Add(CardDB.cardName.bouncingblade, 1);
            DamageRandomDatabase.Add(CardDB.cardName.cleave, 2);
            DamageRandomDatabase.Add(CardDB.cardName.demolisher, 2);
            DamageRandomDatabase.Add(CardDB.cardName.dieinsect, 8);
            DamageRandomDatabase.Add(CardDB.cardName.dieinsects, 8);
            DamageRandomDatabase.Add(CardDB.cardName.fierybat, 1);
            DamageRandomDatabase.Add(CardDB.cardName.flamecannon, 4);
            DamageRandomDatabase.Add(CardDB.cardName.flamejuggler, 1);
            DamageRandomDatabase.Add(CardDB.cardName.flamewaker, 2);
            DamageRandomDatabase.Add(CardDB.cardName.forkedlightning, 2);
            DamageRandomDatabase.Add(CardDB.cardName.goblinblastmage, 1);
            DamageRandomDatabase.Add(CardDB.cardName.greaterarcanemissiles, 3);
            DamageRandomDatabase.Add(CardDB.cardName.hugetoad, 1);
            DamageRandomDatabase.Add(CardDB.cardName.knifejuggler, 1);
            DamageRandomDatabase.Add(CardDB.cardName.madbomber, 1);
            DamageRandomDatabase.Add(CardDB.cardName.madderbomber, 1);
            DamageRandomDatabase.Add(CardDB.cardName.multishot, 3);
            DamageRandomDatabase.Add(CardDB.cardName.ragnarosthefirelord, 8);
            DamageRandomDatabase.Add(CardDB.cardName.rumblingelemental, 1);
            DamageRandomDatabase.Add(CardDB.cardName.shadowboxer, 1);
            DamageRandomDatabase.Add(CardDB.cardName.shipscannon, 2);
            DamageRandomDatabase.Add(CardDB.cardName.spreadingmadness, 1);
            DamageRandomDatabase.Add(CardDB.cardName.throwrocks, 3);
            DamageRandomDatabase.Add(CardDB.cardName.timepieceofhorror, 1);
            DamageRandomDatabase.Add(CardDB.cardName.volatileelemental, 3);
            DamageRandomDatabase.Add(CardDB.cardName.volcano, 1);
            DamageRandomDatabase.Add(CardDB.cardName.breathofsindragosa, 2);
            DamageRandomDatabase.Add(CardDB.cardName.blackguard, 3);

            DamageTargetDatabase.Add(CardDB.cardName.arcaneblast, 2);
            DamageTargetDatabase.Add(CardDB.cardName.arcaneshot, 2);
            DamageTargetDatabase.Add(CardDB.cardName.backstab, 2);
            DamageTargetDatabase.Add(CardDB.cardName.ballistashot, 3);
            DamageTargetDatabase.Add(CardDB.cardName.barreltoss, 2);
            DamageTargetDatabase.Add(CardDB.cardName.betrayal, 2);
            DamageTargetDatabase.Add(CardDB.cardName.blackwingcorruptor, 3);//if dragon in hand
            DamageTargetDatabase.Add(CardDB.cardName.blazecaller, 5);
            DamageTargetDatabase.Add(CardDB.cardName.blowgillsniper, 1);
            DamageTargetDatabase.Add(CardDB.cardName.bombsquad, 5);
            DamageTargetDatabase.Add(CardDB.cardName.cobrashot, 3);
            DamageTargetDatabase.Add(CardDB.cardName.coneofcold, 1);
            DamageTargetDatabase.Add(CardDB.cardName.crackle, 3);
            DamageTargetDatabase.Add(CardDB.cardName.darkbomb, 3);
            DamageTargetDatabase.Add(CardDB.cardName.discipleofcthun, 2);
            DamageTargetDatabase.Add(CardDB.cardName.dispatchkodo, 2);
            DamageTargetDatabase.Add(CardDB.cardName.dragonsbreath, 4);
            DamageTargetDatabase.Add(CardDB.cardName.drainlife, 2);
            DamageTargetDatabase.Add(CardDB.cardName.elvenarcher, 1);
            DamageTargetDatabase.Add(CardDB.cardName.eviscerate, 2);
            DamageTargetDatabase.Add(CardDB.cardName.explosiveshot, 5);
            DamageTargetDatabase.Add(CardDB.cardName.felcannon, 2);
            DamageTargetDatabase.Add(CardDB.cardName.fireball, 6);
            DamageTargetDatabase.Add(CardDB.cardName.fireblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.fireblastrank2, 2);
            DamageTargetDatabase.Add(CardDB.cardName.firebloomtoxin, 2);
            DamageTargetDatabase.Add(CardDB.cardName.fireelemental, 3);
            DamageTargetDatabase.Add(CardDB.cardName.firelandsportal, 5);
            DamageTargetDatabase.Add(CardDB.cardName.fireplumephoenix, 2);
            DamageTargetDatabase.Add(CardDB.cardName.flamelance, 8);
            DamageTargetDatabase.Add(CardDB.cardName.forbiddenflame, 1);
            DamageTargetDatabase.Add(CardDB.cardName.forgottentorch, 3);
            DamageTargetDatabase.Add(CardDB.cardName.frostbolt, 3);
            DamageTargetDatabase.Add(CardDB.cardName.frostshock, 1);
            DamageTargetDatabase.Add(CardDB.cardName.gormoktheimpaler, 4);
            DamageTargetDatabase.Add(CardDB.cardName.greaterhealingpotion, 12);
            DamageTargetDatabase.Add(CardDB.cardName.grievousbite, 2);
            DamageTargetDatabase.Add(CardDB.cardName.heartoffire, 5);
            DamageTargetDatabase.Add(CardDB.cardName.hoggersmash, 4);
            DamageTargetDatabase.Add(CardDB.cardName.holyfire, 5);
            DamageTargetDatabase.Add(CardDB.cardName.holysmite, 2);
            DamageTargetDatabase.Add(CardDB.cardName.icelance, 4);//only if iced
            DamageTargetDatabase.Add(CardDB.cardName.implosion, 2);
            DamageTargetDatabase.Add(CardDB.cardName.ironforgerifleman, 1);
            DamageTargetDatabase.Add(CardDB.cardName.jadelightning, 4);
            DamageTargetDatabase.Add(CardDB.cardName.jadeshuriken, 2);
            DamageTargetDatabase.Add(CardDB.cardName.keeperofthegrove, 2);
            DamageTargetDatabase.Add(CardDB.cardName.killcommand, 3);//or 5
            DamageTargetDatabase.Add(CardDB.cardName.lavaburst, 5);
            DamageTargetDatabase.Add(CardDB.cardName.lavashock, 2);
            DamageTargetDatabase.Add(CardDB.cardName.lightningbolt, 3);
            DamageTargetDatabase.Add(CardDB.cardName.lightningjolt, 2);
            DamageTargetDatabase.Add(CardDB.cardName.livingroots, 2);//choice 1
            DamageTargetDatabase.Add(CardDB.cardName.medivhsvalet, 3);
            DamageTargetDatabase.Add(CardDB.cardName.meteor, 15);
            DamageTargetDatabase.Add(CardDB.cardName.mindshatter, 3);
            DamageTargetDatabase.Add(CardDB.cardName.mindspike, 2);
            DamageTargetDatabase.Add(CardDB.cardName.moonfire, 1); 
            DamageTargetDatabase.Add(CardDB.cardName.mortalcoil, 1);
            DamageTargetDatabase.Add(CardDB.cardName.mortalstrike, 4);
            DamageTargetDatabase.Add(CardDB.cardName.northseakraken, 4);
            DamageTargetDatabase.Add(CardDB.cardName.onthehunt, 1);
            DamageTargetDatabase.Add(CardDB.cardName.perditionsblade, 1);
            DamageTargetDatabase.Add(CardDB.cardName.powershot, 2);
            DamageTargetDatabase.Add(CardDB.cardName.pyroblast, 10);
            DamageTargetDatabase.Add(CardDB.cardName.razorpetal, 1);
            DamageTargetDatabase.Add(CardDB.cardName.roaringtorch, 6);
            DamageTargetDatabase.Add(CardDB.cardName.shadowbolt, 4);
            DamageTargetDatabase.Add(CardDB.cardName.shadowform, 2);
            DamageTargetDatabase.Add(CardDB.cardName.shadowstrike, 5);
            DamageTargetDatabase.Add(CardDB.cardName.shotgunblast, 1);
            DamageTargetDatabase.Add(CardDB.cardName.si7agent, 2);
            DamageTargetDatabase.Add(CardDB.cardName.sonicbreath, 3);
            DamageTargetDatabase.Add(CardDB.cardName.sonoftheflame, 6);
            DamageTargetDatabase.Add(CardDB.cardName.starfall, 5);//2 to all enemy
            DamageTargetDatabase.Add(CardDB.cardName.starfire, 5);//draw a card
            DamageTargetDatabase.Add(CardDB.cardName.steadyshot, 2);//or 1 + card
            DamageTargetDatabase.Add(CardDB.cardName.stormcrack, 4);
            DamageTargetDatabase.Add(CardDB.cardName.stormpikecommando, 2);
            DamageTargetDatabase.Add(CardDB.cardName.swipe, 4);//1 to others
            DamageTargetDatabase.Add(CardDB.cardName.tidalsurge, 4);
            DamageTargetDatabase.Add(CardDB.cardName.unbalancingstrike, 3);
            DamageTargetDatabase.Add(CardDB.cardName.undercityvaliant, 1);
            DamageTargetDatabase.Add(CardDB.cardName.wrath, 1);//todo 3 or 1+card
            DamageTargetDatabase.Add(CardDB.cardName.voidform, 2);
            DamageTargetDatabase.Add(CardDB.cardName.vampiricleech, 3);
            DamageTargetDatabase.Add(CardDB.cardName.ultimateinfestation, 5);
            DamageTargetDatabase.Add(CardDB.cardName.toxicarrow, 2);
            DamageTargetDatabase.Add(CardDB.cardName.siphonlife, 3);
            DamageTargetDatabase.Add(CardDB.cardName.icytouch, 1);
            DamageTargetDatabase.Add(CardDB.cardName.iceclaw, 2);
            DamageTargetDatabase.Add(CardDB.cardName.drainsoul, 2);
            DamageTargetDatabase.Add(CardDB.cardName.doomerang, 2);
            DamageTargetDatabase.Add(CardDB.cardName.avalanche, 0);

            DamageTargetSpecialDatabase.Add(CardDB.cardName.baneofdoom, 2); 
            DamageTargetSpecialDatabase.Add(CardDB.cardName.bash, 3); //+3 armor
            DamageTargetSpecialDatabase.Add(CardDB.cardName.bloodtoichor, 1); 
            DamageTargetSpecialDatabase.Add(CardDB.cardName.crueltaskmaster, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.cardName.deathbloom, 5);
            DamageTargetSpecialDatabase.Add(CardDB.cardName.demonfire, 2); // friendly demon get +2/+2
            DamageTargetSpecialDatabase.Add(CardDB.cardName.demonheart, 5);
            DamageTargetSpecialDatabase.Add(CardDB.cardName.earthshock, 1); //SILENCE /good for raggy etc or iced
            DamageTargetSpecialDatabase.Add(CardDB.cardName.feedingtime, 3); 
            DamageTargetSpecialDatabase.Add(CardDB.cardName.flamegeyser, 2); 
            DamageTargetSpecialDatabase.Add(CardDB.cardName.hammerofwrath, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.holywrath, 2);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.innerrage, 1); // gives 2 attack
            DamageTargetSpecialDatabase.Add(CardDB.cardName.quickshot, 3); //draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.roguesdoit, 4);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.savagery, 1);//dmg=herodamage
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shieldslam, 1);//dmg=armor
            DamageTargetSpecialDatabase.Add(CardDB.cardName.shiv, 1);//draw a card
            DamageTargetSpecialDatabase.Add(CardDB.cardName.slam, 2);//draw card if it survives
            DamageTargetSpecialDatabase.Add(CardDB.cardName.soulfire, 4);//delete a card

            HeroPowerEquipWeapon.Add(CardDB.cardName.daggermastery, 1);
            HeroPowerEquipWeapon.Add(CardDB.cardName.direshapeshift, 2);
            HeroPowerEquipWeapon.Add(CardDB.cardName.echolocate, 0);
            HeroPowerEquipWeapon.Add(CardDB.cardName.enraged, 2);
            HeroPowerEquipWeapon.Add(CardDB.cardName.poisoneddaggers, 2);
            HeroPowerEquipWeapon.Add(CardDB.cardName.shapeshift, 1);
            HeroPowerEquipWeapon.Add(CardDB.cardName.plaguelord, 3);

            
            this.maycauseharmDatabase.Add(CardDB.cardName.arcaneblast, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.arcaneshot, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.backstab, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.baneofdoom, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.barreltoss, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.bash, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.blastcrystalpotion, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.bloodthistletoxin, 3);
            this.maycauseharmDatabase.Add(CardDB.cardName.bloodtoichor, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.chromaticmutation, 5);
            this.maycauseharmDatabase.Add(CardDB.cardName.cobrashot, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.coneofcold, 6);
            this.maycauseharmDatabase.Add(CardDB.cardName.crackle, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.crush, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.darkbomb, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.deathbloom, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.demonfire, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.demonheart, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.dispel, 4);
            this.maycauseharmDatabase.Add(CardDB.cardName.dragonsbreath, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.drainlife, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.drakkisathscommand, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.dream, 3);
            this.maycauseharmDatabase.Add(CardDB.cardName.dynamite, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.earthshock, 4);
            this.maycauseharmDatabase.Add(CardDB.cardName.emergencycoolant, 6);
            this.maycauseharmDatabase.Add(CardDB.cardName.eviscerate, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.explosiveshot, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.feedingtime, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.fireball, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.firebloomtoxin, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.firelandsportal, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.flamegeyser, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.flamelance, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.forbiddenflame, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.forgottentorch, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.frostbolt, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.grievousbite, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.hakkaribloodgoblet, 5);
            this.maycauseharmDatabase.Add(CardDB.cardName.hammerofwrath, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.hex, 5);
            this.maycauseharmDatabase.Add(CardDB.cardName.hoggersmash, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.holyfire, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.holysmite, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.holywrath, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.humility, 7);
            this.maycauseharmDatabase.Add(CardDB.cardName.huntersmark, 7);
            this.maycauseharmDatabase.Add(CardDB.cardName.icelance, 6);
            this.maycauseharmDatabase.Add(CardDB.cardName.implosion, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.innerrage, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.jadelightning, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.jadeshuriken, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.keeperofthegrove, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.killcommand, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.lavaburst, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.lavashock, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.lightningbolt, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.livingroots, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.madbomber, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.madderbomber, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.meteor, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.moonfire, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.mortalcoil, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.mortalstrike, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.mulch, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.naturalize, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.necroticpoison, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.onthehunt, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.polymorph, 5);
            this.maycauseharmDatabase.Add(CardDB.cardName.powershot, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.pyroblast, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.quickshot, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.razorpetal, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.roaringtorch, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.roguesdoit, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.rottenbanana, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.savagery, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.shadowbolt, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.shadowstep, 3);
            this.maycauseharmDatabase.Add(CardDB.cardName.shadowstrike, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.shadowworddeath, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.shadowwordpain, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.shatter, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.shieldslam, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.shiv, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.silence, 4);
            this.maycauseharmDatabase.Add(CardDB.cardName.siphonsoul, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.slam, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.sonicbreath, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.soulfire, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.spreadingmadness, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.starfall, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.starfire, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.stormcrack, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.swipe, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.tailswipe, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.thetruewarchief, 2);
            this.maycauseharmDatabase.Add(CardDB.cardName.tidalsurge, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.timerewinder, 3);
            this.maycauseharmDatabase.Add(CardDB.cardName.volcano, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.wrath, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.drainsoul, 1);
            this.maycauseharmDatabase.Add(CardDB.cardName.obliterate, 2);
        }

        private void setupsilenceDatabase()
        {
            
            this.silenceDatabase.Add(CardDB.cardName.defiascleaner, 1);
            this.silenceDatabase.Add(CardDB.cardName.dispel, 1);
            this.silenceDatabase.Add(CardDB.cardName.earthshock, 1);
            this.silenceDatabase.Add(CardDB.cardName.ironbeakowl, 1);
            this.silenceDatabase.Add(CardDB.cardName.kabalsongstealer, 1);
            this.silenceDatabase.Add(CardDB.cardName.lightschampion, 1);
            this.silenceDatabase.Add(CardDB.cardName.massdispel, 1);
            this.silenceDatabase.Add(CardDB.cardName.purify, -1);
            this.silenceDatabase.Add(CardDB.cardName.silence, 1);
            this.silenceDatabase.Add(CardDB.cardName.spellbreaker, 1);
            this.silenceDatabase.Add(CardDB.cardName.wailingsoul, -2);

            OwnNeedSilenceDatabase.Add(CardDB.cardName.ancientwatcher, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.animagolem, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.bittertidehydra, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.blackknight, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.bombsquad, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.corruptedhealbot, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.dancingswords, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.deathcharger, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.eeriestatue, 0);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.emeraldhivequeen, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.felorcsoulfiend, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.felreaver, 3);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.frozencrusher, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.humongousrazorleaf, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.icehowl, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.mogortheogre, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.natthedarkfisher, 0);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.spectralrider, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.spectraltrainee, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.spectralwarrior, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.spore, 3);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.thebeast, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.unlicensedapothecary, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.unrelentingrider, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.unrelentingtrainee, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.unrelentingwarrior, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.venturecomercenary, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.whiteknight, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.wrathguard, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.zombiechow, 2);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.tickingabomination, 0);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.rattlingrascal, 1);
            OwnNeedSilenceDatabase.Add(CardDB.cardName.masterchest, 1);
        }


        private void setupPriorityList()
        {
            priorityDatabase.Add(CardDB.cardName.acidmaw, 3);
            priorityDatabase.Add(CardDB.cardName.animatedarmor, 2);
            priorityDatabase.Add(CardDB.cardName.archmageantonidas, 6);
            priorityDatabase.Add(CardDB.cardName.aviana, 5);
            priorityDatabase.Add(CardDB.cardName.brannbronzebeard, 4);
            priorityDatabase.Add(CardDB.cardName.cloakedhuntress, 2);
            priorityDatabase.Add(CardDB.cardName.confessorpaletress, 7);
            priorityDatabase.Add(CardDB.cardName.crowdfavorite, 6);
            priorityDatabase.Add(CardDB.cardName.darkshirecouncilman, 2);
            priorityDatabase.Add(CardDB.cardName.direwolfalpha, 6);
            priorityDatabase.Add(CardDB.cardName.emperorthaurissan, 5);
            priorityDatabase.Add(CardDB.cardName.fandralstaghelm, 6);
            priorityDatabase.Add(CardDB.cardName.flametonguetotem, 6);
            priorityDatabase.Add(CardDB.cardName.flamewaker, 5);
            priorityDatabase.Add(CardDB.cardName.frothingberserker, 1);
            priorityDatabase.Add(CardDB.cardName.gadgetzanauctioneer, 1);
            priorityDatabase.Add(CardDB.cardName.grimestreetenforcer, 1);
            priorityDatabase.Add(CardDB.cardName.grimpatron, 5);
            priorityDatabase.Add(CardDB.cardName.grimscaleoracle, 5);
            priorityDatabase.Add(CardDB.cardName.grimygadgeteer, 1);
            priorityDatabase.Add(CardDB.cardName.holychampion, 5);
            priorityDatabase.Add(CardDB.cardName.knifejuggler, 2);
            priorityDatabase.Add(CardDB.cardName.kodorider, 6);
            priorityDatabase.Add(CardDB.cardName.kvaldirraider, 1);
            priorityDatabase.Add(CardDB.cardName.leokk, 5);
            priorityDatabase.Add(CardDB.cardName.lyrathesunshard, 1);
            priorityDatabase.Add(CardDB.cardName.malchezaarsimp, 1);
            priorityDatabase.Add(CardDB.cardName.malganis, 10);
            priorityDatabase.Add(CardDB.cardName.manatidetotem, 5);
            priorityDatabase.Add(CardDB.cardName.mechwarper, 1);
            priorityDatabase.Add(CardDB.cardName.muklaschampion, 5);
            priorityDatabase.Add(CardDB.cardName.murlocknight, 5);
            priorityDatabase.Add(CardDB.cardName.murlocwarleader, 5);
            priorityDatabase.Add(CardDB.cardName.nexuschampionsaraad, 6);
            priorityDatabase.Add(CardDB.cardName.northshirecleric, 4);
            priorityDatabase.Add(CardDB.cardName.pintsizedsummoner, 3);
            priorityDatabase.Add(CardDB.cardName.primalfintotem, 5);
            priorityDatabase.Add(CardDB.cardName.prophetvelen, 5);
            priorityDatabase.Add(CardDB.cardName.questingadventurer, 1);
            priorityDatabase.Add(CardDB.cardName.radiantelemental, 3);
            priorityDatabase.Add(CardDB.cardName.ragnaroslightlord, 5);
            priorityDatabase.Add(CardDB.cardName.raidleader, 5);
            priorityDatabase.Add(CardDB.cardName.recruiter, 1);
            priorityDatabase.Add(CardDB.cardName.scavenginghyena, 5);
            priorityDatabase.Add(CardDB.cardName.secretkeeper, 5);
            priorityDatabase.Add(CardDB.cardName.sorcerersapprentice, 3);
            priorityDatabase.Add(CardDB.cardName.southseacaptain, 5);
            priorityDatabase.Add(CardDB.cardName.spiritsingerumbra, 5);
            priorityDatabase.Add(CardDB.cardName.stormwindchampion, 5);
            priorityDatabase.Add(CardDB.cardName.summoningportal, 5);
            priorityDatabase.Add(CardDB.cardName.summoningstone, 5);
            priorityDatabase.Add(CardDB.cardName.thevoraxx, 2);
            priorityDatabase.Add(CardDB.cardName.thunderbluffvaliant, 2);
            priorityDatabase.Add(CardDB.cardName.timberwolf, 5);
            priorityDatabase.Add(CardDB.cardName.tunneltrogg, 1);
            priorityDatabase.Add(CardDB.cardName.viciousfledgling, 4);
            priorityDatabase.Add(CardDB.cardName.violetillusionist, 10);
            priorityDatabase.Add(CardDB.cardName.violetteacher, 1);
            priorityDatabase.Add(CardDB.cardName.warhorsetrainer, 5);
            priorityDatabase.Add(CardDB.cardName.warsongcommander, 5);
            priorityDatabase.Add(CardDB.cardName.wickedwitchdoctor, 5);
            priorityDatabase.Add(CardDB.cardName.wilfredfizzlebang, 1);
            priorityDatabase.Add(CardDB.cardName.rotface, 1);
            priorityDatabase.Add(CardDB.cardName.professorputricide, 1);
            priorityDatabase.Add(CardDB.cardName.moorabi, 1);
        }

        private void setupAttackBuff()
        {
            this.heroAttackBuffDatabase.Add(CardDB.cardName.bite, 4);
            this.heroAttackBuffDatabase.Add(CardDB.cardName.claw, 2);
            this.heroAttackBuffDatabase.Add(CardDB.cardName.evolvespines, 4);
            this.heroAttackBuffDatabase.Add(CardDB.cardName.feralrage, 4);
            this.heroAttackBuffDatabase.Add(CardDB.cardName.heroicstrike, 4);
            this.heroAttackBuffDatabase.Add(CardDB.cardName.gnash, 3);

            this.attackBuffDatabase.Add(CardDB.cardName.abusivesergeant, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.adaptation, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.bananas, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.bestialwrath, 2); // NEVER ON enemy MINION
            this.attackBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            this.attackBuffDatabase.Add(CardDB.cardName.blessingofmight, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.bloodfurypotion, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.briarthorntoxin, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.clockworkknight, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.coldblood, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.crueltaskmaster, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.darkirondwarf, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.darkwispers, 5);//choice 2
            this.attackBuffDatabase.Add(CardDB.cardName.demonfuse, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.dinomancy, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.dinosize, 10);
            this.attackBuffDatabase.Add(CardDB.cardName.divinestrength, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.earthenscales, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.explorershat, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.innerrage, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.lancecarrier, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.lanternofpower, 10);
            this.attackBuffDatabase.Add(CardDB.cardName.lightfusedstegodon, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.markofnature, 4);//choice1 
            this.attackBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.markofyshaarj, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.mutatinginjection, 4);
            this.attackBuffDatabase.Add(CardDB.cardName.nightmare, 5); //destroy minion on next turn
            this.attackBuffDatabase.Add(CardDB.cardName.powerwordtentacles, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.primalfusion, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.rampage, 3);//only damaged minion 
            this.attackBuffDatabase.Add(CardDB.cardName.rockbiterweapon, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.rockpoolhunter, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.screwjankclunker, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.sealofchampions, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.silvermoonportal, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.spikeridgedsteed, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.velenschosen, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.whirlingblades, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.antimagicshell, 2);
            this.attackBuffDatabase.Add(CardDB.cardName.fallensuncleric, 1);
            this.attackBuffDatabase.Add(CardDB.cardName.cryostasis, 3);
            this.attackBuffDatabase.Add(CardDB.cardName.bonemare, 4);
            this.attackBuffDatabase.Add(CardDB.cardName.acherusveteran, 1);
        }

        private void setupHealthBuff()
        {
            //healthBuffDatabase.Add(CardDB.cardName.ancientofwar, 5);//choice2 is only buffing himself!
            //healthBuffDatabase.Add(CardDB.cardName.rooted, 5);
            healthBuffDatabase.Add(CardDB.cardName.adaptation, 1);
            healthBuffDatabase.Add(CardDB.cardName.armorplating, 1);
            healthBuffDatabase.Add(CardDB.cardName.bananas, 1);
            healthBuffDatabase.Add(CardDB.cardName.blessingofkings, 4);
            healthBuffDatabase.Add(CardDB.cardName.clockworkknight, 1);
            healthBuffDatabase.Add(CardDB.cardName.darkwispers, 5);//choice2
            healthBuffDatabase.Add(CardDB.cardName.demonfuse, 3);
            healthBuffDatabase.Add(CardDB.cardName.dinomancy, 2);
            healthBuffDatabase.Add(CardDB.cardName.dinosize, 10);
            healthBuffDatabase.Add(CardDB.cardName.divinestrength, 2);
            healthBuffDatabase.Add(CardDB.cardName.earthenscales, 1);
            healthBuffDatabase.Add(CardDB.cardName.explorershat, 1);
            healthBuffDatabase.Add(CardDB.cardName.lanternofpower, 10);
            healthBuffDatabase.Add(CardDB.cardName.lightfusedstegodon, 1);
            healthBuffDatabase.Add(CardDB.cardName.markofnature, 4);//choice2
            healthBuffDatabase.Add(CardDB.cardName.markofthewild, 2);
            healthBuffDatabase.Add(CardDB.cardName.markofyshaarj, 2);
            healthBuffDatabase.Add(CardDB.cardName.mutatinginjection, 4);
            healthBuffDatabase.Add(CardDB.cardName.nightmare, 5);
            healthBuffDatabase.Add(CardDB.cardName.powerwordshield, 2);
            healthBuffDatabase.Add(CardDB.cardName.powerwordtentacles, 6);
            healthBuffDatabase.Add(CardDB.cardName.primalfusion, 1);
            healthBuffDatabase.Add(CardDB.cardName.rampage, 3);
            healthBuffDatabase.Add(CardDB.cardName.rockpoolhunter, 1);
            healthBuffDatabase.Add(CardDB.cardName.screwjankclunker, 2);
            healthBuffDatabase.Add(CardDB.cardName.silvermoonportal, 2);
            healthBuffDatabase.Add(CardDB.cardName.spikeridgedsteed, 6);
            healthBuffDatabase.Add(CardDB.cardName.upgradedrepairbot, 4);
            healthBuffDatabase.Add(CardDB.cardName.velenschosen, 4);
            healthBuffDatabase.Add(CardDB.cardName.wildwalker, 3);
            healthBuffDatabase.Add(CardDB.cardName.antimagicshell, 2);
            healthBuffDatabase.Add(CardDB.cardName.sunbornevalkyr, 2);
            healthBuffDatabase.Add(CardDB.cardName.fallensuncleric, 1);
            healthBuffDatabase.Add(CardDB.cardName.cryostasis, 3);
            healthBuffDatabase.Add(CardDB.cardName.bonemare, 4);

            tauntBuffDatabase.Add(CardDB.cardName.ancestralhealing, 1);
            tauntBuffDatabase.Add(CardDB.cardName.darkwispers, 1);
            tauntBuffDatabase.Add(CardDB.cardName.markofnature, 1);
            tauntBuffDatabase.Add(CardDB.cardName.markofthewild, 1);
            tauntBuffDatabase.Add(CardDB.cardName.mutatinginjection, 1);
            tauntBuffDatabase.Add(CardDB.cardName.rustyhorn, 1);
            tauntBuffDatabase.Add(CardDB.cardName.sparringpartner, 1);
            tauntBuffDatabase.Add(CardDB.cardName.spikeridgedsteed, 1);
        }

        private void setupCardDrawBattlecry()
        {
            cardDrawBattleCryDatabase.Add(CardDB.cardName.alightinthedarkness, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancestralknowledge, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientoflore, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ancientteachings, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.arcaneintellect, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.archthiefrafaam, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.azuredrake, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.babblingbook, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.battlerage, 0);//only if wounded own minions or hero
            cardDrawBattleCryDatabase.Add(CardDB.cardName.bloodwarriors, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.burgle, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.cabaliststome, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.callpet, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.carnassasbrood, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.chitteringtunneler, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.chooseyourpath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.coldlightoracle, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.commandingshout, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.convert, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.darkpeddler, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.darkshirelibrarian, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.desertcamel, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.divinefavor, 0);//only if enemy has more cards than you
            cardDrawBattleCryDatabase.Add(CardDB.cardName.drakonidoperative, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.echoofmedivh, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.elisestarseeker, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.elitetaurenchieftain, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.etherealconjurer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.excessmana, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.fanofknives, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.farsight, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.fightpromoter, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.finderskeepers, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.firefly, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.flamegeyser, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.flameheart, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.flare, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.freefromamber, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.giftofcards, 1); //choice = 2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gnomishexperimenter, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gnomishinventor, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.goldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.gorillabota3, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.grandcrusader, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.grimestreetinformant, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.hallucination, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.hammerofwrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.harrisonjones, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.harvest, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.holywrath, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.hydrologist, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.iknowaguy, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ivoryknight, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.jeweledmacaw, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.jeweledscarab, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.journeybelow, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kabalchemist, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kabalcourier, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kazakus, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kingmukla, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kingsblood, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kingsbloodtoxin, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.kingselekk, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.layonhands, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lifetap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lockandload, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lotusagents, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.lunarvisions, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.maptothegoldenmonkey, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.markofyshaarj, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.massdispel, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.megafin, 9);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.mimicpod, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.mindpocalypse, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.mindvision, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.mortalcoil, 0);//only if kills
            cardDrawBattleCryDatabase.Add(CardDB.cardName.muklatyrantofthevale, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.museumcurator, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.nefarian, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.neptulon, 4);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.netherspitehistorian, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.nourish, 3); //choice = 2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.noviceengineer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.powerwordshield, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.primalfinlookout, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.primordialglyph, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.purify, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.quickshot, 0);//only if your hand is empty
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ravenidol, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.razorpetallasher, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.razorpetalvolley, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.roguesdoit, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.servantofkalimos, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shadowcaster, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shadowoil, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shadowvisions, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shieldblock, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.shiv, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.slam, 0); //if survives
            cardDrawBattleCryDatabase.Add(CardDB.cardName.smalltimerecruits, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.solemnvigil, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.soultap, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.spellslinger, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.sprint, 4);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.stampede, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.starfire, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.stonehilldefender, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.swashburglar, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.thecurator, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.thistletea, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.thoughtsteal, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.tinkertowntechnician, 0); // If you have a Mech
            cardDrawBattleCryDatabase.Add(CardDB.cardName.tolvirwarden, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.tombspider, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.tortollanforager, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.tortollanprimalist, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.toshley, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.tracking, 1); //NOT SUPPORTED YET
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ungoropack, 5);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.unholyshadow, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.unstableportal, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.varianwrynn, 3);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.wildmagic, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.wrath, 1); //choice=2
            cardDrawBattleCryDatabase.Add(CardDB.cardName.wrathion, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.xarilpoisonedmind, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ultimateinfestation, 5);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.tomblurker, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.ghastlyconjurer, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.deathgrip, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.stitchedtracker, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.rollthebones, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.icefishing, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.howlingcommander, 0);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.frozenclone, 1);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.forgeofsouls, 2);
            cardDrawBattleCryDatabase.Add(CardDB.cardName.devourmind, 3);

            cardDrawDeathrattleDatabase.Add(CardDB.cardName.acolyteofpain, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.anubarak, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.bloodmagethalnos, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.clockworkgnome, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.crystallineoracle, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.dancingswords, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.deadlyfork, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.hook, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.igneouselemental, 2);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.loothoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.meanstreetmarshal, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.mechanicalyeti, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.mechbearcat, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.pollutedhoarder, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.pyros, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.rhonin, 3);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.runicegg, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.shiftingshade, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.shimmeringtempest, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.tentaclesforarms, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.tombpillager, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.toshley, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.undercityhuckster, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.webspinner, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.xarilpoisonedmind, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.shallowgravedigger, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.frozenchampion, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.bonedrake, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.bonebaron, 2);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.arfus, 1);
            cardDrawDeathrattleDatabase.Add(CardDB.cardName.glacialmysteries, 1);
        }


        private void setupUsefulNeedKeepDatabase()
        {
            UsefulNeedKeepDatabase.Add(CardDB.cardName.acidmaw, 4);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.addledgrizzly, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.airelemental, 6);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.alarmobot, 4);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.ancientharbinger, 2);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.animatedarmor, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.archmageantonidas, 7);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.armorsmith, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.aviana, 7);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.backroombouncer, 1);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.bloodimp, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.brannbronzebeard, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.burlyrockjawtrogg, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.cloakedhuntress, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.cobaltguardian, 8);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.coldarradrake, 15);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.confessorpaletress, 32);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.cultmaster, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.cultsorcerer, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.darkshirecouncilman, 0);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.dementedfrostcaller, 15);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.demolisher, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.direwolfalpha, 30);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.dragonkinsorcerer, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.emboldener3000, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.emperorthaurissan, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.faeriedragon, 7);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.fallenhero, 15);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.masterchest, 48);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.fandralstaghelm, 15);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.felcannon, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.flametonguetotem, 30);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.flamewaker, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.flesheatingghoul, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.floatingwatcher, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.frothingberserker, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.gadgetzanauctioneer, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.garrisoncommander, 7);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.gazlowe, 6);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.grimestreetenforcer, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.grimscaleoracle, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.grimygadgeteer, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.gruul, 4);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.hallazealtheascended, 16);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.healingtotem, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.hobgoblin, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.hogger, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.homingchicken, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.illidanstormrage, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.illuminator, 2);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.impmaster, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.ironsensei, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.jeeves, 0);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.junkbot, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.kabaltrafficker, 1);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.kelthuzad, 18);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.knifejuggler, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.kodorider, 20);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.kvaldirraider, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.leokk, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.lightwarden, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.lightwell, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.lyrathesunshard, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.maidenofthelake, 18);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.malchezaarsimp, 0);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.malganis, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.manatidetotem, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.manawyrm, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.masterswordsmith, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.mechwarper, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.mekgineerthermaplugg, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.micromachine, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.moroes, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.muklaschampion, 14);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.murlocknight, 16);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.murloctidecaller, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.murlocwarleader, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.natpagle, 2);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.nexuschampionsaraad, 30);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.northshirecleric, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.obsidiandestroyer, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.pintsizedsummoner, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.priestofthefeast, 3);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.primalfintotem, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.prophetvelen, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.questingadventurer, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.radiantelemental, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.ragnaroslightlord, 19);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.ragnarosthefirelord, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.raidleader, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.recruiter, 15);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.redmanawyrm, 8);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.repairbot, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.rumblingelemental, 7);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.scavenginghyena, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.secretkeeper, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.shadeofnaxxramas, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.shadowboxer, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.shakuthecollector, 25);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.shipscannon, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.siegeengine, 8);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.siltfinspiritwalker, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.silverhandregent, 14);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.sorcerersapprentice, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.southseacaptain, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.spiritsingerumbra, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.starvingbuzzard, 8);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.stonesplintertrogg, 8);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.stormwindchampion, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.summoningportal, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.summoningstone, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.thunderbluffvaliant, 16);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.timberwolf, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.tradeprincegallywix, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.troggzortheearthinator, 4);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.twilightelder, 9);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.undertaker, 8);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.usherofsouls, 2);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.viciousfledgling, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.violetillusionist, 14);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.violetteacher, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.vitalitytotem, 8);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.warhorsetrainer, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.warsongcommander, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.weespellstopper, 11);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.wickedwitchdoctor, 13);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.wilfredfizzlebang, 16);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.windupburglebot, 5);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.youngpriestess, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.shadowascendant, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.festergut, 25);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.drakkarienchanter, 17);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.despicabledreadlord, 14);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.cobaltscalebane, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.valkyrsoulclaimer, 10);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.runeforgehaunter, 1);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.rotface, 26);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.necroticgeist, 12);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.moorabi, 16);
            UsefulNeedKeepDatabase.Add(CardDB.cardName.icewalker, 15);
        }

        private void setupDiscardCards()
        {
            cardDiscardDatabase.Add(CardDB.cardName.darkbargain, 6);
            cardDiscardDatabase.Add(CardDB.cardName.darkshirelibrarian, 2);
            cardDiscardDatabase.Add(CardDB.cardName.doomguard, 5);
            cardDiscardDatabase.Add(CardDB.cardName.lakkarifelhound, 4);
            cardDiscardDatabase.Add(CardDB.cardName.soulfire, 1);
            cardDiscardDatabase.Add(CardDB.cardName.succubus, 2);
        }

        private void setupDestroyOwnCards()
        {
            this.destroyOwnDatabase.Add(CardDB.cardName.brawl, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.deathwing, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.golakkacrawler, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.hungrycrab, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.kingmosh, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.naturalize, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.ravenouspterrordax, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.sacrificialpact, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.siphonsoul, 0);//not own mins
            this.destroyOwnDatabase.Add(CardDB.cardName.shadowflame, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.twistingnether, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.unwillingsacrifice, 0);
            this.destroyOwnDatabase.Add(CardDB.cardName.sanguinereveler, 0);

            this.destroyDatabase.Add(CardDB.cardName.assassinate, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.biggamehunter, 0);
            this.destroyDatabase.Add(CardDB.cardName.bladeofcthun, 0);
            this.destroyDatabase.Add(CardDB.cardName.blastcrystalpotion, 0);
            this.destroyDatabase.Add(CardDB.cardName.bookwyrm, 0);
            this.destroyDatabase.Add(CardDB.cardName.corruption, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.crush, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.darkbargain, 0);
            this.destroyDatabase.Add(CardDB.cardName.deadlyshot, 0);
            this.destroyDatabase.Add(CardDB.cardName.doom, 0);
            this.destroyDatabase.Add(CardDB.cardName.drakkisathscommand, 0);
            this.destroyDatabase.Add(CardDB.cardName.enterthecoliseum, 0);
            this.destroyDatabase.Add(CardDB.cardName.execute, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.hemetnesingwary, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.mindcontrol, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.moatlurker, 1);
            this.destroyDatabase.Add(CardDB.cardName.mulch, 0);
            this.destroyDatabase.Add(CardDB.cardName.necroticpoison, 0);
            this.destroyDatabase.Add(CardDB.cardName.rendblackhand, 0);
            this.destroyDatabase.Add(CardDB.cardName.sabotage, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.shadowworddeath, 0);
            this.destroyDatabase.Add(CardDB.cardName.shadowwordhorror, 0);
            this.destroyDatabase.Add(CardDB.cardName.shadowwordpain, 0);
            this.destroyDatabase.Add(CardDB.cardName.shatter, 0);
            this.destroyDatabase.Add(CardDB.cardName.theblackknight, 0);//not own mins
            this.destroyDatabase.Add(CardDB.cardName.thetruewarchief, 0);
            this.destroyDatabase.Add(CardDB.cardName.vilespineslayer, 0);
            this.destroyDatabase.Add(CardDB.cardName.voidcrusher, 0);
            this.destroyDatabase.Add(CardDB.cardName.obsidianstatue, 0);
            this.destroyDatabase.Add(CardDB.cardName.obliterate, 0);
            this.destroyDatabase.Add(CardDB.cardName.doompact, 0);
        }

        private void setupReturnBackToHandCards()
        {
            returnHandDatabase.Add(CardDB.cardName.ancientbrewmaster, 0);
            returnHandDatabase.Add(CardDB.cardName.bloodthistletoxin, 0);
            returnHandDatabase.Add(CardDB.cardName.dream, 0);
            returnHandDatabase.Add(CardDB.cardName.gadgetzanferryman, 0);
            returnHandDatabase.Add(CardDB.cardName.kidnapper, 0);//if combo
            returnHandDatabase.Add(CardDB.cardName.recycle, 0);
            returnHandDatabase.Add(CardDB.cardName.shadowstep, 0);
            returnHandDatabase.Add(CardDB.cardName.timerewinder, 0);
            returnHandDatabase.Add(CardDB.cardName.vanish, 0);
            returnHandDatabase.Add(CardDB.cardName.youthfulbrewmaster, 0);
        }

        private void setupHeroDamagingAOE()
        {
            this.heroDamagingAoeDatabase.Add(CardDB.cardName.unknown, 0);
        }

        private void setupSpecialMins()
        {
            specialMinions.Add(CardDB.cardName.aberrantberserker, 0);
            specialMinions.Add(CardDB.cardName.abomination, 0);
            specialMinions.Add(CardDB.cardName.acidmaw, 0);
            specialMinions.Add(CardDB.cardName.acolyteofpain, 0);
            specialMinions.Add(CardDB.cardName.addledgrizzly, 0);
            specialMinions.Add(CardDB.cardName.alarmobot, 0);
            specialMinions.Add(CardDB.cardName.amaniberserker, 0);
            specialMinions.Add(CardDB.cardName.ancientharbinger, 0);
            specialMinions.Add(CardDB.cardName.angrychicken, 0);
            specialMinions.Add(CardDB.cardName.animatedarmor, 0);
            specialMinions.Add(CardDB.cardName.anubarak, 0);
            specialMinions.Add(CardDB.cardName.anubarambusher, 0);
            specialMinions.Add(CardDB.cardName.anubisathsentinel, 0);
            specialMinions.Add(CardDB.cardName.arcaneanomaly, 0);
            specialMinions.Add(CardDB.cardName.archmage, 0);
            specialMinions.Add(CardDB.cardName.archmageantonidas, 0);
            specialMinions.Add(CardDB.cardName.armorsmith, 0);
            specialMinions.Add(CardDB.cardName.auchenaisoulpriest, 0);
            specialMinions.Add(CardDB.cardName.aviana, 0);
            specialMinions.Add(CardDB.cardName.axeflinger, 0);
            specialMinions.Add(CardDB.cardName.ayablackpaw, 0);
            specialMinions.Add(CardDB.cardName.azuredrake, 0);
            specialMinions.Add(CardDB.cardName.backroombouncer, 0);
            specialMinions.Add(CardDB.cardName.backstreetleper, 0);
            specialMinions.Add(CardDB.cardName.barongeddon, 0);
            specialMinions.Add(CardDB.cardName.baronrivendare, 0);
            specialMinions.Add(CardDB.cardName.blackwaterpirate, 0);
            specialMinions.Add(CardDB.cardName.bloodhoofbrave, 0);
            specialMinions.Add(CardDB.cardName.bloodimp, 0);
            specialMinions.Add(CardDB.cardName.bloodmagethalnos, 0);
            specialMinions.Add(CardDB.cardName.bolframshield, 0);
            specialMinions.Add(CardDB.cardName.boneguardlieutenant, 0);
            specialMinions.Add(CardDB.cardName.brannbronzebeard, 0);
            specialMinions.Add(CardDB.cardName.bravearcher, 0);
            specialMinions.Add(CardDB.cardName.buccaneer, 0);
            specialMinions.Add(CardDB.cardName.burglybully, 0);
            specialMinions.Add(CardDB.cardName.burlyrockjawtrogg, 0);
            specialMinions.Add(CardDB.cardName.cairnebloodhoof, 0);
            specialMinions.Add(CardDB.cardName.chromaggus, 0);
            specialMinions.Add(CardDB.cardName.chromaticdragonkin, 0);
            specialMinions.Add(CardDB.cardName.cloakedhuntress, 0);
            specialMinions.Add(CardDB.cardName.clockworkgnome, 0);
            specialMinions.Add(CardDB.cardName.cobaltguardian, 0);
            specialMinions.Add(CardDB.cardName.cogmaster, 0);
            specialMinions.Add(CardDB.cardName.coldarradrake, 0);
            specialMinions.Add(CardDB.cardName.coliseummanager, 0);
            specialMinions.Add(CardDB.cardName.confessorpaletress, 0);
            specialMinions.Add(CardDB.cardName.crazedworshipper, 0);
            specialMinions.Add(CardDB.cardName.crowdfavorite, 0);
            specialMinions.Add(CardDB.cardName.crueldinomancer, 0);
            specialMinions.Add(CardDB.cardName.crystallineoracle, 0);
            specialMinions.Add(CardDB.cardName.cthun, 0);
            specialMinions.Add(CardDB.cardName.cultmaster, 0);
            specialMinions.Add(CardDB.cardName.cultsorcerer, 0);
            specialMinions.Add(CardDB.cardName.cutpurse, 0);
            specialMinions.Add(CardDB.cardName.dalaranaspirant, 0);
            specialMinions.Add(CardDB.cardName.dalaranmage, 0);
            specialMinions.Add(CardDB.cardName.dancingswords, 0);
            specialMinions.Add(CardDB.cardName.darkcultist, 0);
            specialMinions.Add(CardDB.cardName.darkshirecouncilman, 0);
            specialMinions.Add(CardDB.cardName.deadlyfork, 0);
            specialMinions.Add(CardDB.cardName.deathlord, 0);
            specialMinions.Add(CardDB.cardName.dementedfrostcaller, 0);
            specialMinions.Add(CardDB.cardName.demolisher, 0);
            specialMinions.Add(CardDB.cardName.direhornhatchling, 0);
            specialMinions.Add(CardDB.cardName.direwolfalpha, 0);
            specialMinions.Add(CardDB.cardName.djinniofzephyrs, 0);
            specialMinions.Add(CardDB.cardName.doomsayer, 0);
            specialMinions.Add(CardDB.cardName.dragonegg, 0);
            specialMinions.Add(CardDB.cardName.dragonhawkrider, 0);
            specialMinions.Add(CardDB.cardName.dragonkinsorcerer, 0);
            specialMinions.Add(CardDB.cardName.dreadscale, 0);
            specialMinions.Add(CardDB.cardName.dreadsteed, 0);
            specialMinions.Add(CardDB.cardName.eggnapper, 0);
            specialMinions.Add(CardDB.cardName.emperorcobra, 0);
            specialMinions.Add(CardDB.cardName.emperorthaurissan, 0);
            specialMinions.Add(CardDB.cardName.etherealarcanist, 0);
            specialMinions.Add(CardDB.cardName.evolvedkobold, 0);
            specialMinions.Add(CardDB.cardName.explosivesheep, 0);
            specialMinions.Add(CardDB.cardName.eydisdarkbane, 0);
            specialMinions.Add(CardDB.cardName.fallenhero, 0);
            specialMinions.Add(CardDB.cardName.fandralstaghelm, 0);
            specialMinions.Add(CardDB.cardName.felcannon, 0);
            specialMinions.Add(CardDB.cardName.feugen, 0);
            specialMinions.Add(CardDB.cardName.finjatheflyingstar, 0);
            specialMinions.Add(CardDB.cardName.fjolalightbane, 0);
            specialMinions.Add(CardDB.cardName.flametonguetotem, 0);
            specialMinions.Add(CardDB.cardName.flamewaker, 0);
            specialMinions.Add(CardDB.cardName.flesheatingghoul, 0);
            specialMinions.Add(CardDB.cardName.floatingwatcher, 0);
            specialMinions.Add(CardDB.cardName.foereaper4000, 0);
            specialMinions.Add(CardDB.cardName.gadgetzanauctioneer, 0);
            specialMinions.Add(CardDB.cardName.gahzrilla, 0);
            specialMinions.Add(CardDB.cardName.garr, 0);
            specialMinions.Add(CardDB.cardName.garrisoncommander, 0);
            specialMinions.Add(CardDB.cardName.gazlowe, 0);
            specialMinions.Add(CardDB.cardName.genzotheshark, 0);
            specialMinions.Add(CardDB.cardName.giantanaconda, 0);
            specialMinions.Add(CardDB.cardName.giantsandworm, 0);
            specialMinions.Add(CardDB.cardName.giantwasp, 0);
            specialMinions.Add(CardDB.cardName.goblinsapper, 0);
            specialMinions.Add(CardDB.cardName.grimestreetenforcer, 0);
            specialMinions.Add(CardDB.cardName.grimpatron, 0);
            specialMinions.Add(CardDB.cardName.grimscaleoracle, 0);
            specialMinions.Add(CardDB.cardName.grimygadgeteer, 0);
            specialMinions.Add(CardDB.cardName.grommashhellscream, 0);
            specialMinions.Add(CardDB.cardName.gruul, 0);
            specialMinions.Add(CardDB.cardName.gurubashiberserker, 0);
            specialMinions.Add(CardDB.cardName.hallazealtheascended, 0);
            specialMinions.Add(CardDB.cardName.harvestgolem, 0);
            specialMinions.Add(CardDB.cardName.hauntedcreeper, 0);
            specialMinions.Add(CardDB.cardName.hobgoblin, 0);
            specialMinions.Add(CardDB.cardName.hogger, 0);
            specialMinions.Add(CardDB.cardName.hoggerdoomofelwynn, 0);
            specialMinions.Add(CardDB.cardName.holychampion, 0);
            specialMinions.Add(CardDB.cardName.hoodedacolyte, 0);
            specialMinions.Add(CardDB.cardName.hugetoad, 0);
            specialMinions.Add(CardDB.cardName.igneouselemental, 0);
            specialMinions.Add(CardDB.cardName.illidanstormrage, 0);
            specialMinions.Add(CardDB.cardName.impgangboss, 0);
            specialMinions.Add(CardDB.cardName.impmaster, 0);
            specialMinions.Add(CardDB.cardName.infestedtauren, 0);
            specialMinions.Add(CardDB.cardName.infestedwolf, 0);
            specialMinions.Add(CardDB.cardName.ironsensei, 0);
            specialMinions.Add(CardDB.cardName.jadeswarmer, 0);
            specialMinions.Add(CardDB.cardName.jeeves, 0);
            specialMinions.Add(CardDB.cardName.junglemoonkin, 0);
            specialMinions.Add(CardDB.cardName.junkbot, 0);
            specialMinions.Add(CardDB.cardName.kabaltrafficker, 0);
            specialMinions.Add(CardDB.cardName.kelthuzad, 0);
            specialMinions.Add(CardDB.cardName.kindlygrandmother, 0);
            specialMinions.Add(CardDB.cardName.knifejuggler, 0);
            specialMinions.Add(CardDB.cardName.knuckles, 0);
            specialMinions.Add(CardDB.cardName.koboldgeomancer, 0);
            specialMinions.Add(CardDB.cardName.kodorider, 0);
            specialMinions.Add(CardDB.cardName.kvaldirraider, 0);
            specialMinions.Add(CardDB.cardName.lepergnome, 0);
            specialMinions.Add(CardDB.cardName.lightspawn, 0);
            specialMinions.Add(CardDB.cardName.lightwarden, 0);
            specialMinions.Add(CardDB.cardName.lightwell, 0);
            specialMinions.Add(CardDB.cardName.loothoarder, 0);
            specialMinions.Add(CardDB.cardName.lorewalkercho, 0);
            specialMinions.Add(CardDB.cardName.lotusassassin, 0);
            specialMinions.Add(CardDB.cardName.lowlysquire, 0);
            specialMinions.Add(CardDB.cardName.lyrathesunshard, 0);
            specialMinions.Add(CardDB.cardName.madscientist, 0);
            specialMinions.Add(CardDB.cardName.maexxna, 0);
            specialMinions.Add(CardDB.cardName.magnatauralpha, 0);
            specialMinions.Add(CardDB.cardName.maidenofthelake, 0);
            specialMinions.Add(CardDB.cardName.majordomoexecutus, 0);
            specialMinions.Add(CardDB.cardName.malchezaarsimp, 0);
            specialMinions.Add(CardDB.cardName.malganis, 0);
            specialMinions.Add(CardDB.cardName.malorne, 0);
            specialMinions.Add(CardDB.cardName.malygos, 0);
            specialMinions.Add(CardDB.cardName.manaaddict, 0);
            specialMinions.Add(CardDB.cardName.manageode, 0);
            specialMinions.Add(CardDB.cardName.manatidetotem, 0);
            specialMinions.Add(CardDB.cardName.manatreant, 0);
            specialMinions.Add(CardDB.cardName.manawraith, 0);
            specialMinions.Add(CardDB.cardName.manawyrm, 0);
            specialMinions.Add(CardDB.cardName.masterswordsmith, 0);
            specialMinions.Add(CardDB.cardName.mechanicalyeti, 0);
            specialMinions.Add(CardDB.cardName.mechbearcat, 0);
            specialMinions.Add(CardDB.cardName.mechwarper, 0);
            specialMinions.Add(CardDB.cardName.mekgineerthermaplugg, 0);
            specialMinions.Add(CardDB.cardName.micromachine, 0);
            specialMinions.Add(CardDB.cardName.mimironshead, 0);
            specialMinions.Add(CardDB.cardName.mistressofpain, 0);
            specialMinions.Add(CardDB.cardName.moroes, 0);
            specialMinions.Add(CardDB.cardName.muklaschampion, 0);
            specialMinions.Add(CardDB.cardName.murlocknight, 0);
            specialMinions.Add(CardDB.cardName.murloctidecaller, 0);
            specialMinions.Add(CardDB.cardName.murlocwarleader, 0);
            specialMinions.Add(CardDB.cardName.natpagle, 0);
            specialMinions.Add(CardDB.cardName.nerubarweblord, 0);
            specialMinions.Add(CardDB.cardName.nexuschampionsaraad, 0);
            specialMinions.Add(CardDB.cardName.northshirecleric, 0);
            specialMinions.Add(CardDB.cardName.obsidiandestroyer, 0);
            specialMinions.Add(CardDB.cardName.ogremagi, 0);
            specialMinions.Add(CardDB.cardName.oldmurkeye, 0);
            specialMinions.Add(CardDB.cardName.orgrimmaraspirant, 0);
            specialMinions.Add(CardDB.cardName.patientassassin, 0);
            specialMinions.Add(CardDB.cardName.pilotedshredder, 0);
            specialMinions.Add(CardDB.cardName.pilotedskygolem, 0);
            specialMinions.Add(CardDB.cardName.pintsizedsummoner, 0);
            specialMinions.Add(CardDB.cardName.pitsnake, 0);
            specialMinions.Add(CardDB.cardName.possessedvillager, 0);
            specialMinions.Add(CardDB.cardName.priestofthefeast, 0);
            specialMinions.Add(CardDB.cardName.primalfinchampion, 0);
            specialMinions.Add(CardDB.cardName.primalfintotem, 0);
            specialMinions.Add(CardDB.cardName.prophetvelen, 0);
            specialMinions.Add(CardDB.cardName.pyros, 0);
            specialMinions.Add(CardDB.cardName.questingadventurer, 0);
            specialMinions.Add(CardDB.cardName.radiantelemental, 0);
            specialMinions.Add(CardDB.cardName.ragingworgen, 0);
            specialMinions.Add(CardDB.cardName.ragnaroslightlord, 0);
            specialMinions.Add(CardDB.cardName.raidleader, 0);
            specialMinions.Add(CardDB.cardName.raptorhatchling, 0);
            specialMinions.Add(CardDB.cardName.ratpack, 0);
            specialMinions.Add(CardDB.cardName.recruiter, 0);
            specialMinions.Add(CardDB.cardName.redmanawyrm, 0);
            specialMinions.Add(CardDB.cardName.rumblingelemental, 0);
            specialMinions.Add(CardDB.cardName.satedthreshadon, 0);
            specialMinions.Add(CardDB.cardName.savagecombatant, 0);
            specialMinions.Add(CardDB.cardName.savannahhighmane, 0);
            specialMinions.Add(CardDB.cardName.scalednightmare, 0);
            specialMinions.Add(CardDB.cardName.scavenginghyena, 0);
            specialMinions.Add(CardDB.cardName.secretkeeper, 0);
            specialMinions.Add(CardDB.cardName.selflesshero, 0);
            specialMinions.Add(CardDB.cardName.sergeantsally, 0);
            specialMinions.Add(CardDB.cardName.shadeofnaxxramas, 0);
            specialMinions.Add(CardDB.cardName.shadowboxer, 0);
            specialMinions.Add(CardDB.cardName.shadowfiend, 0);
            specialMinions.Add(CardDB.cardName.shakuthecollector, 0);
            specialMinions.Add(CardDB.cardName.sherazincorpseflower, 0);
            specialMinions.Add(CardDB.cardName.shiftingshade, 0);
            specialMinions.Add(CardDB.cardName.shimmeringtempest, 0);
            specialMinions.Add(CardDB.cardName.shipscannon, 0);
            specialMinions.Add(CardDB.cardName.siltfinspiritwalker, 0);
            specialMinions.Add(CardDB.cardName.silverhandregent, 0);
            specialMinions.Add(CardDB.cardName.smalltimebuccaneer, 0);
            specialMinions.Add(CardDB.cardName.sneedsoldshredder, 0);
            specialMinions.Add(CardDB.cardName.snowchugger, 0);
            specialMinions.Add(CardDB.cardName.sorcerersapprentice, 0);
            specialMinions.Add(CardDB.cardName.southseacaptain, 0);
            specialMinions.Add(CardDB.cardName.southseasquidface, 0);
            specialMinions.Add(CardDB.cardName.spawnofnzoth, 0);
            specialMinions.Add(CardDB.cardName.spawnofshadows, 0);
            specialMinions.Add(CardDB.cardName.spiritsingerumbra, 0);
            specialMinions.Add(CardDB.cardName.spitefulsmith, 0);
            specialMinions.Add(CardDB.cardName.stalagg, 0);
            specialMinions.Add(CardDB.cardName.starvingbuzzard, 0);
            specialMinions.Add(CardDB.cardName.steamwheedlesniper, 0);
            specialMinions.Add(CardDB.cardName.stewardofdarkshire, 0);
            specialMinions.Add(CardDB.cardName.stonesplintertrogg, 0);
            specialMinions.Add(CardDB.cardName.stormwindchampion, 0);
            specialMinions.Add(CardDB.cardName.summoningportal, 0);
            specialMinions.Add(CardDB.cardName.summoningstone, 0);
            specialMinions.Add(CardDB.cardName.sylvanaswindrunner, 0);
            specialMinions.Add(CardDB.cardName.tarcreeper, 0);
            specialMinions.Add(CardDB.cardName.tarlord, 0);
            specialMinions.Add(CardDB.cardName.tarlurker, 0);
            specialMinions.Add(CardDB.cardName.taurenwarrior, 0);
            specialMinions.Add(CardDB.cardName.tentacleofnzoth, 0);
            specialMinions.Add(CardDB.cardName.thebeast, 0);
            specialMinions.Add(CardDB.cardName.theboogeymonster, 0);
            specialMinions.Add(CardDB.cardName.thevoraxx, 0);
            specialMinions.Add(CardDB.cardName.thunderbluffvaliant, 0);
            specialMinions.Add(CardDB.cardName.timberwolf, 0);
            specialMinions.Add(CardDB.cardName.tinyknightofevil, 0);
            specialMinions.Add(CardDB.cardName.tirionfordring, 0);
            specialMinions.Add(CardDB.cardName.tortollanshellraiser, 0);
            specialMinions.Add(CardDB.cardName.toshley, 0);
            specialMinions.Add(CardDB.cardName.tournamentmedic, 0);
            specialMinions.Add(CardDB.cardName.tradeprincegallywix, 0);
            specialMinions.Add(CardDB.cardName.troggzortheearthinator, 0);
            specialMinions.Add(CardDB.cardName.tundrarhino, 0);
            specialMinions.Add(CardDB.cardName.tunneltrogg, 0);
            specialMinions.Add(CardDB.cardName.twilightelder, 0);
            specialMinions.Add(CardDB.cardName.twilightsummoner, 0);
            specialMinions.Add(CardDB.cardName.unboundelemental, 0);
            specialMinions.Add(CardDB.cardName.undercityhuckster, 0);
            specialMinions.Add(CardDB.cardName.undertaker, 0);
            specialMinions.Add(CardDB.cardName.unstableghoul, 0);
            specialMinions.Add(CardDB.cardName.usherofsouls, 0);
            specialMinions.Add(CardDB.cardName.viciousfledgling, 0);
            specialMinions.Add(CardDB.cardName.violetillusionist, 0);
            specialMinions.Add(CardDB.cardName.violetteacher, 0);
            specialMinions.Add(CardDB.cardName.vitalitytotem, 0);
            specialMinions.Add(CardDB.cardName.voidcaller, 0);
            specialMinions.Add(CardDB.cardName.voidcrusher, 0);
            specialMinions.Add(CardDB.cardName.volatileelemental, 0);
            specialMinions.Add(CardDB.cardName.warbot, 0);
            specialMinions.Add(CardDB.cardName.warhorsetrainer, 0);
            specialMinions.Add(CardDB.cardName.warsongcommander, 0);
            specialMinions.Add(CardDB.cardName.waterelemental, 0);
            specialMinions.Add(CardDB.cardName.voodoohexxer, 0);
            specialMinions.Add(CardDB.cardName.webspinner, 0);
            specialMinions.Add(CardDB.cardName.whiteeyes, 0);
            specialMinions.Add(CardDB.cardName.wickedwitchdoctor, 0);
            specialMinions.Add(CardDB.cardName.wickerflameburnbristle, 0);
            specialMinions.Add(CardDB.cardName.wilfredfizzlebang, 0);
            specialMinions.Add(CardDB.cardName.windupburglebot, 0);
            specialMinions.Add(CardDB.cardName.wobblingrunts, 0);
            specialMinions.Add(CardDB.cardName.xarilpoisonedmind, 0);
            specialMinions.Add(CardDB.cardName.ysera, 0);
            specialMinions.Add(CardDB.cardName.yshaarjrageunbound, 0);
            specialMinions.Add(CardDB.cardName.zealousinitiate, 0);
            specialMinions.Add(CardDB.cardName.vryghoul, 0);
            specialMinions.Add(CardDB.cardName.thelichking, 0);
            specialMinions.Add(CardDB.cardName.skelemancer, 0);
            specialMinions.Add(CardDB.cardName.shallowgravedigger, 0);
            specialMinions.Add(CardDB.cardName.shadowascendant, 0);
            specialMinions.Add(CardDB.cardName.obsidianstatue, 0);
            specialMinions.Add(CardDB.cardName.mountainfirearmor, 0);
            specialMinions.Add(CardDB.cardName.meatwagon, 0);
            specialMinions.Add(CardDB.cardName.hadronox, 0);
            specialMinions.Add(CardDB.cardName.festergut, 0);
            specialMinions.Add(CardDB.cardName.fatespinner, 0);
            specialMinions.Add(CardDB.cardName.explodingbloatbat, 0);
            specialMinions.Add(CardDB.cardName.drakkarienchanter, 0);
            specialMinions.Add(CardDB.cardName.despicabledreadlord, 0);
            specialMinions.Add(CardDB.cardName.deadscaleknight, 0);
            specialMinions.Add(CardDB.cardName.cobaltscalebane, 0);
            specialMinions.Add(CardDB.cardName.chillbladechampion, 0);
            specialMinions.Add(CardDB.cardName.bonedrake, 0);
            specialMinions.Add(CardDB.cardName.bonebaron, 0);
            specialMinions.Add(CardDB.cardName.bloodworm, 0);
            specialMinions.Add(CardDB.cardName.bloodqueenlanathel, 0);
            specialMinions.Add(CardDB.cardName.blackguard, 0);
            specialMinions.Add(CardDB.cardName.arrogantcrusader, 0);
            specialMinions.Add(CardDB.cardName.arfus, 0);
            specialMinions.Add(CardDB.cardName.acolyteofagony, 0);
            specialMinions.Add(CardDB.cardName.abominablebowman, 0);
            specialMinions.Add(CardDB.cardName.venomancer, 0);
            specialMinions.Add(CardDB.cardName.valkyrsoulclaimer, 0);
            specialMinions.Add(CardDB.cardName.stubborngastropod, 0);
            specialMinions.Add(CardDB.cardName.runeforgehaunter, 0);
            specialMinions.Add(CardDB.cardName.rotface, 0);
            specialMinions.Add(CardDB.cardName.professorputricide, 0);
            specialMinions.Add(CardDB.cardName.nighthowler, 0);
            specialMinions.Add(CardDB.cardName.nerubianunraveler, 0);
            specialMinions.Add(CardDB.cardName.necroticgeist, 0);
            specialMinions.Add(CardDB.cardName.moorabi, 0);
            specialMinions.Add(CardDB.cardName.mindbreaker, 0);
            specialMinions.Add(CardDB.cardName.icewalker, 0);
            specialMinions.Add(CardDB.cardName.graveshambler, 0);
            specialMinions.Add(CardDB.cardName.doomedapprentice, 0);
            specialMinions.Add(CardDB.cardName.cryptlord, 0);
            specialMinions.Add(CardDB.cardName.corpsewidow, 0);
        }

        private void setupOwnSummonFromDeathrattle()
        {
            ownSummonFromDeathrattle.Add(CardDB.cardName.anubarak, -10);
            ownSummonFromDeathrattle.Add(CardDB.cardName.ayablackpaw, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.cairnebloodhoof, 5);
            ownSummonFromDeathrattle.Add(CardDB.cardName.crueldinomancer, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.devilsauregg, -20);
            ownSummonFromDeathrattle.Add(CardDB.cardName.dreadsteed, -1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.eggnapper, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.giantanaconda, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.harvestgolem, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.hauntedcreeper, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.infestedtauren, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.infestedwolf, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.jadeswarmer, -1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.kindlygrandmother, -10);
            ownSummonFromDeathrattle.Add(CardDB.cardName.moirabronzebeard, 3);
            ownSummonFromDeathrattle.Add(CardDB.cardName.mountedraptor, 3);
            ownSummonFromDeathrattle.Add(CardDB.cardName.nerubianegg, -16);
            ownSummonFromDeathrattle.Add(CardDB.cardName.pilotedshredder, 4);
            ownSummonFromDeathrattle.Add(CardDB.cardName.pilotedskygolem, 4);
            ownSummonFromDeathrattle.Add(CardDB.cardName.possessedvillager, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.ratpack, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.satedthreshadon, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.savannahhighmane, 8);
            ownSummonFromDeathrattle.Add(CardDB.cardName.sludgebelcher, 10);
            ownSummonFromDeathrattle.Add(CardDB.cardName.sneedsoldshredder, 5);
            ownSummonFromDeathrattle.Add(CardDB.cardName.twilightsummoner, -14);
            ownSummonFromDeathrattle.Add(CardDB.cardName.whiteeyes, -10);
            ownSummonFromDeathrattle.Add(CardDB.cardName.wobblingrunts, 1);
            ownSummonFromDeathrattle.Add(CardDB.cardName.frozenchampion, -12);
        }

        private void setupBuffingMinions()
        {
            buffingMinionsDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.beckonerofevil, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.bladeofcthun, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.bloodsailcultist, 5);
            buffingMinionsDatabase.Add(CardDB.cardName.captaingreenskin, 5);
            buffingMinionsDatabase.Add(CardDB.cardName.cenarius, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.clockworkknight, 2);
            buffingMinionsDatabase.Add(CardDB.cardName.coldlightseer, 3);
            buffingMinionsDatabase.Add(CardDB.cardName.crueltaskmaster, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.cthunschosen, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.cultsorcerer, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.darkarakkoa, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.darkirondwarf, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.defenderofargus, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.direwolfalpha, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.discipleofcthun, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.doomcaller, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.flametonguetotem, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.goblinautobarber, 5);
            buffingMinionsDatabase.Add(CardDB.cardName.grimscaleoracle, 3);
            buffingMinionsDatabase.Add(CardDB.cardName.hoodedacolyte, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.houndmaster, 1);
            buffingMinionsDatabase.Add(CardDB.cardName.lancecarrier, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.leokk, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.malganis, 8);
            buffingMinionsDatabase.Add(CardDB.cardName.metaltoothleaper, 2);
            buffingMinionsDatabase.Add(CardDB.cardName.murlocwarleader, 3);
            buffingMinionsDatabase.Add(CardDB.cardName.quartermaster, 6);
            buffingMinionsDatabase.Add(CardDB.cardName.raidleader, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.screwjankclunker, 2);
            buffingMinionsDatabase.Add(CardDB.cardName.shatteredsuncleric, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.skeramcultist, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.southseacaptain, 4);
            buffingMinionsDatabase.Add(CardDB.cardName.spitefulsmith, 5);
            buffingMinionsDatabase.Add(CardDB.cardName.stormwindchampion, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.templeenforcer, 0);
            buffingMinionsDatabase.Add(CardDB.cardName.thunderbluffvaliant, 9);
            buffingMinionsDatabase.Add(CardDB.cardName.timberwolf, 1);
            buffingMinionsDatabase.Add(CardDB.cardName.upgradedrepairbot, 2);
            buffingMinionsDatabase.Add(CardDB.cardName.usherofsouls, 10);
            buffingMinionsDatabase.Add(CardDB.cardName.warhorsetrainer, 6);
            buffingMinionsDatabase.Add(CardDB.cardName.warsongcommander, 7);
            buffingMinionsDatabase.Add(CardDB.cardName.worshipper, 0);

            buffing1TurnDatabase.Add(CardDB.cardName.abusivesergeant, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.bloodlust, 3);
            buffing1TurnDatabase.Add(CardDB.cardName.darkirondwarf, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.rockbiterweapon, 0);
            buffing1TurnDatabase.Add(CardDB.cardName.worshipper, 0);
        }

        private void setupEnemyTargetPriority()
        {
            priorityTargets.Add(CardDB.cardName.acidmaw, 10);
            priorityTargets.Add(CardDB.cardName.acolyteofpain, 10);
            priorityTargets.Add(CardDB.cardName.addledgrizzly, 10);
            priorityTargets.Add(CardDB.cardName.alarmobot, 10);
            priorityTargets.Add(CardDB.cardName.angrychicken, 10);
            priorityTargets.Add(CardDB.cardName.animatedarmor, 10);
            priorityTargets.Add(CardDB.cardName.anubarak, 10);
            priorityTargets.Add(CardDB.cardName.anubisathsentinel, 10);
            priorityTargets.Add(CardDB.cardName.archmageantonidas, 10);
            priorityTargets.Add(CardDB.cardName.auchenaisoulpriest, 10);
            priorityTargets.Add(CardDB.cardName.auctionmasterbeardo, 10);
            priorityTargets.Add(CardDB.cardName.aviana, 10);
            priorityTargets.Add(CardDB.cardName.ayablackpaw, 10);
            priorityTargets.Add(CardDB.cardName.backroombouncer, 10);
            priorityTargets.Add(CardDB.cardName.barongeddon, 10);
            priorityTargets.Add(CardDB.cardName.baronrivendare, 10);
            priorityTargets.Add(CardDB.cardName.bloodmagethalnos, 10);
            priorityTargets.Add(CardDB.cardName.boneguardlieutenant, 10);
            priorityTargets.Add(CardDB.cardName.brannbronzebeard, 10);
            priorityTargets.Add(CardDB.cardName.burglybully, 10);
            priorityTargets.Add(CardDB.cardName.chromaggus, 10);
            priorityTargets.Add(CardDB.cardName.cloakedhuntress, 10);
            priorityTargets.Add(CardDB.cardName.coldarradrake, 10);
            priorityTargets.Add(CardDB.cardName.confessorpaletress, 10);
            priorityTargets.Add(CardDB.cardName.crowdfavorite, 10);
            priorityTargets.Add(CardDB.cardName.crueldinomancer, 10);
            priorityTargets.Add(CardDB.cardName.crystallineoracle, 10);
            priorityTargets.Add(CardDB.cardName.cthun, 10);
            priorityTargets.Add(CardDB.cardName.cultmaster, 10);
            priorityTargets.Add(CardDB.cardName.cultsorcerer, 10);
            priorityTargets.Add(CardDB.cardName.dalaranaspirant, 10);
            priorityTargets.Add(CardDB.cardName.daringreporter, 10);
            priorityTargets.Add(CardDB.cardName.darkshirecouncilman, 10);
            priorityTargets.Add(CardDB.cardName.dementedfrostcaller, 10);
            priorityTargets.Add(CardDB.cardName.demolisher, 10);
            priorityTargets.Add(CardDB.cardName.devilsauregg, 10);
            priorityTargets.Add(CardDB.cardName.nerubianegg, 10);
            priorityTargets.Add(CardDB.cardName.direhornhatchling, 10);
            priorityTargets.Add(CardDB.cardName.direwolfalpha, 10);
            priorityTargets.Add(CardDB.cardName.djinniofzephyrs, 10);
            priorityTargets.Add(CardDB.cardName.doomsayer, 10);
            priorityTargets.Add(CardDB.cardName.dragonegg, 0);
            priorityTargets.Add(CardDB.cardName.dragonhawkrider, 10);
            priorityTargets.Add(CardDB.cardName.dragonkinsorcerer, 4);
            priorityTargets.Add(CardDB.cardName.dreadscale, 10);
            priorityTargets.Add(CardDB.cardName.dustdevil, 10);
            priorityTargets.Add(CardDB.cardName.eggnapper, 10);
            priorityTargets.Add(CardDB.cardName.emperorthaurissan, 10);
            priorityTargets.Add(CardDB.cardName.etherealarcanist, 10);
            priorityTargets.Add(CardDB.cardName.eydisdarkbane, 10);
            priorityTargets.Add(CardDB.cardName.fallenhero, 10);
            priorityTargets.Add(CardDB.cardName.masterchest, 10);
            priorityTargets.Add(CardDB.cardName.fandralstaghelm, 10);
            priorityTargets.Add(CardDB.cardName.finjatheflyingstar, 10);
            priorityTargets.Add(CardDB.cardName.flametonguetotem, 10);
            priorityTargets.Add(CardDB.cardName.flamewaker, 10);
            priorityTargets.Add(CardDB.cardName.flesheatingghoul, 10);
            priorityTargets.Add(CardDB.cardName.floatingwatcher, 10);
            priorityTargets.Add(CardDB.cardName.foereaper4000, 10);
            priorityTargets.Add(CardDB.cardName.friendlybartender, 10);
            priorityTargets.Add(CardDB.cardName.frothingberserker, 10);
            priorityTargets.Add(CardDB.cardName.gadgetzanauctioneer, 10);
            priorityTargets.Add(CardDB.cardName.gahzrilla, 10);
            priorityTargets.Add(CardDB.cardName.garr, 10);
            priorityTargets.Add(CardDB.cardName.garrisoncommander, 10);
            priorityTargets.Add(CardDB.cardName.genzotheshark, 10);
            priorityTargets.Add(CardDB.cardName.giantanaconda, 10);
            priorityTargets.Add(CardDB.cardName.giantsandworm, 10);
            priorityTargets.Add(CardDB.cardName.grimestreetenforcer, 10);
            priorityTargets.Add(CardDB.cardName.grimpatron, 10);
            priorityTargets.Add(CardDB.cardName.grimygadgeteer, 10);
            priorityTargets.Add(CardDB.cardName.gurubashiberserker, 10);
            priorityTargets.Add(CardDB.cardName.hobgoblin, 10);
            priorityTargets.Add(CardDB.cardName.hogger, 10);
            priorityTargets.Add(CardDB.cardName.hoggerdoomofelwynn, 10);
            priorityTargets.Add(CardDB.cardName.holychampion, 10);
            priorityTargets.Add(CardDB.cardName.hoodedacolyte, 10);
            priorityTargets.Add(CardDB.cardName.igneouselemental, 10);
            priorityTargets.Add(CardDB.cardName.illidanstormrage, 10);
            priorityTargets.Add(CardDB.cardName.impgangboss, 10);
            priorityTargets.Add(CardDB.cardName.impmaster, 10);
            priorityTargets.Add(CardDB.cardName.ironsensei, 10);
            priorityTargets.Add(CardDB.cardName.junglemoonkin, 10);
            priorityTargets.Add(CardDB.cardName.kabaltrafficker, 10);
            priorityTargets.Add(CardDB.cardName.kelthuzad, 10);
            priorityTargets.Add(CardDB.cardName.knifejuggler, 10);
            priorityTargets.Add(CardDB.cardName.knuckles, 10);
            priorityTargets.Add(CardDB.cardName.koboldgeomancer, 10);
            priorityTargets.Add(CardDB.cardName.kodorider, 10);
            priorityTargets.Add(CardDB.cardName.kvaldirraider, 10);
            priorityTargets.Add(CardDB.cardName.leeroyjenkins, 10);
            priorityTargets.Add(CardDB.cardName.leokk, 10);
            priorityTargets.Add(CardDB.cardName.lightwarden, 10);
            priorityTargets.Add(CardDB.cardName.lightwell, 10);
            priorityTargets.Add(CardDB.cardName.lowlysquire, 10);
            priorityTargets.Add(CardDB.cardName.lyrathesunshard, 10);
            priorityTargets.Add(CardDB.cardName.maexxna, 10);
            priorityTargets.Add(CardDB.cardName.maidenofthelake, 10);
            priorityTargets.Add(CardDB.cardName.malchezaarsimp, 10);
            priorityTargets.Add(CardDB.cardName.malganis, 10);
            priorityTargets.Add(CardDB.cardName.malygos, 10);
            priorityTargets.Add(CardDB.cardName.manaaddict, 10);
            priorityTargets.Add(CardDB.cardName.manatidetotem, 10);
            priorityTargets.Add(CardDB.cardName.manatreant, 10);
            priorityTargets.Add(CardDB.cardName.manawyrm, 10);
            priorityTargets.Add(CardDB.cardName.masterswordsmith, 10);
            priorityTargets.Add(CardDB.cardName.mechwarper, 10);
            priorityTargets.Add(CardDB.cardName.micromachine, 10);
            priorityTargets.Add(CardDB.cardName.mogortheogre, 10);
            priorityTargets.Add(CardDB.cardName.moroes, 10);
            priorityTargets.Add(CardDB.cardName.muklaschampion, 10);
            priorityTargets.Add(CardDB.cardName.murlocknight, 10);
            priorityTargets.Add(CardDB.cardName.natpagle, 10);
            priorityTargets.Add(CardDB.cardName.nerubarweblord, 10);
            priorityTargets.Add(CardDB.cardName.nexuschampionsaraad, 10);
            priorityTargets.Add(CardDB.cardName.northshirecleric, 10);
            priorityTargets.Add(CardDB.cardName.obsidiandestroyer, 10);
            priorityTargets.Add(CardDB.cardName.orgrimmaraspirant, 10);
            priorityTargets.Add(CardDB.cardName.pintsizedsummoner, 10);
            priorityTargets.Add(CardDB.cardName.priestofthefeast, 10);
            priorityTargets.Add(CardDB.cardName.primalfintotem, 10);
            priorityTargets.Add(CardDB.cardName.prophetvelen, 10);
            priorityTargets.Add(CardDB.cardName.pyros, 10);
            priorityTargets.Add(CardDB.cardName.questingadventurer, 10);
            priorityTargets.Add(CardDB.cardName.radiantelemental, 10);
            priorityTargets.Add(CardDB.cardName.ragnaroslightlord, 10);
            priorityTargets.Add(CardDB.cardName.raidleader, 10);
            priorityTargets.Add(CardDB.cardName.raptorhatchling, 10);
            priorityTargets.Add(CardDB.cardName.recruiter, 10);
            priorityTargets.Add(CardDB.cardName.redmanawyrm, 10);
            priorityTargets.Add(CardDB.cardName.rhonin, 10);
            priorityTargets.Add(CardDB.cardName.rumblingelemental, 10);
            priorityTargets.Add(CardDB.cardName.satedthreshadon, 10);
            priorityTargets.Add(CardDB.cardName.savagecombatant, 10);
            priorityTargets.Add(CardDB.cardName.scalednightmare, 10);
            priorityTargets.Add(CardDB.cardName.scavenginghyena, 10);
            priorityTargets.Add(CardDB.cardName.secretkeeper, 10);
            priorityTargets.Add(CardDB.cardName.shadeofnaxxramas, 10);
            priorityTargets.Add(CardDB.cardName.shakuthecollector, 10);
            priorityTargets.Add(CardDB.cardName.sherazincorpseflower, 10);
            priorityTargets.Add(CardDB.cardName.shimmeringtempest, 10);
            priorityTargets.Add(CardDB.cardName.silverhandregent, 10);
            priorityTargets.Add(CardDB.cardName.sorcerersapprentice, 10);
            priorityTargets.Add(CardDB.cardName.spiritsingerumbra, 10);
            priorityTargets.Add(CardDB.cardName.starvingbuzzard, 10);
            priorityTargets.Add(CardDB.cardName.steamwheedlesniper, 10);
            priorityTargets.Add(CardDB.cardName.stormwindchampion, 10);
            priorityTargets.Add(CardDB.cardName.summoningportal, 10);
            priorityTargets.Add(CardDB.cardName.summoningstone, 10);
            priorityTargets.Add(CardDB.cardName.theboogeymonster, 10);
            priorityTargets.Add(CardDB.cardName.thevoraxx, 10);
            priorityTargets.Add(CardDB.cardName.thrallmarfarseer, 10);
            priorityTargets.Add(CardDB.cardName.thunderbluffvaliant, 10);
            priorityTargets.Add(CardDB.cardName.timberwolf, 10);
            priorityTargets.Add(CardDB.cardName.troggzortheearthinator, 10);
            priorityTargets.Add(CardDB.cardName.tundrarhino, 10);
            priorityTargets.Add(CardDB.cardName.tunneltrogg, 10);
            priorityTargets.Add(CardDB.cardName.twilightsummoner, 10);
            priorityTargets.Add(CardDB.cardName.unboundelemental, 10);
            priorityTargets.Add(CardDB.cardName.undertaker, 10);
            priorityTargets.Add(CardDB.cardName.viciousfledgling, 10);
            priorityTargets.Add(CardDB.cardName.violetillusionist, 10);
            priorityTargets.Add(CardDB.cardName.violetteacher, 10);
            priorityTargets.Add(CardDB.cardName.vitalitytotem, 10);
            priorityTargets.Add(CardDB.cardName.warhorsetrainer, 10);
            priorityTargets.Add(CardDB.cardName.warsongcommander, 10);
            priorityTargets.Add(CardDB.cardName.whiteeyes, 10);
            priorityTargets.Add(CardDB.cardName.wickedwitchdoctor, 10);
            priorityTargets.Add(CardDB.cardName.wildpyromancer, 10);
            priorityTargets.Add(CardDB.cardName.wilfredfizzlebang, 10);
            priorityTargets.Add(CardDB.cardName.windupburglebot, 10);
            priorityTargets.Add(CardDB.cardName.youngdragonhawk, 10);
            priorityTargets.Add(CardDB.cardName.yshaarjrageunbound, 10);
            priorityTargets.Add(CardDB.cardName.thelichking, 10);
            priorityTargets.Add(CardDB.cardName.obsidianstatue, 10);
            priorityTargets.Add(CardDB.cardName.moirabronzebeard, 10);
            priorityTargets.Add(CardDB.cardName.highjusticegrimstone, 10);
            priorityTargets.Add(CardDB.cardName.hadronox, 10);
            priorityTargets.Add(CardDB.cardName.festergut, 10);
            priorityTargets.Add(CardDB.cardName.despicabledreadlord, 10);
            priorityTargets.Add(CardDB.cardName.rotface, 10);
            priorityTargets.Add(CardDB.cardName.professorputricide, 10);
            priorityTargets.Add(CardDB.cardName.nighthowler, 10);
            priorityTargets.Add(CardDB.cardName.necroticgeist, 10);
            priorityTargets.Add(CardDB.cardName.moorabi, 10);
            priorityTargets.Add(CardDB.cardName.icewalker, 10);
            priorityTargets.Add(CardDB.cardName.cryptlord, 10);
            priorityTargets.Add(CardDB.cardName.corpsewidow, 10);
        }

        private void setupLethalHelpMinions()
        {
            //spellpower minions
            lethalHelpers.Add(CardDB.cardName.ancientmage, 0);
            lethalHelpers.Add(CardDB.cardName.arcanotron, 0);
            lethalHelpers.Add(CardDB.cardName.archmage, 0);
            lethalHelpers.Add(CardDB.cardName.auchenaisoulpriest, 0);
            lethalHelpers.Add(CardDB.cardName.azuredrake, 0);
            lethalHelpers.Add(CardDB.cardName.bloodmagethalnos, 0);
            lethalHelpers.Add(CardDB.cardName.cultsorcerer, 0);
            lethalHelpers.Add(CardDB.cardName.dalaranaspirant, 0);
            lethalHelpers.Add(CardDB.cardName.dalaranmage, 0);
            lethalHelpers.Add(CardDB.cardName.evolvedkobold, 0);
            lethalHelpers.Add(CardDB.cardName.frigidsnobold, 0);
            lethalHelpers.Add(CardDB.cardName.junglemoonkin, 0);
            lethalHelpers.Add(CardDB.cardName.koboldgeomancer, 0);
            lethalHelpers.Add(CardDB.cardName.malygos, 0);
            lethalHelpers.Add(CardDB.cardName.minimage, 0);
            lethalHelpers.Add(CardDB.cardName.ogremagi, 0);
            lethalHelpers.Add(CardDB.cardName.prophetvelen, 0);
            lethalHelpers.Add(CardDB.cardName.sootspewer, 0);
            lethalHelpers.Add(CardDB.cardName.streettrickster, 0);
            lethalHelpers.Add(CardDB.cardName.wrathofairtotem, 0);
            lethalHelpers.Add(CardDB.cardName.tuskarrfisherman, 0);
            lethalHelpers.Add(CardDB.cardName.taintedzealot, 1);
            lethalHelpers.Add(CardDB.cardName.spellweaver, 2);
        }

        private void setupRelations()
        {
            spellDependentDatabase.Add(CardDB.cardName.arcaneanomaly, 1);
            spellDependentDatabase.Add(CardDB.cardName.archmageantonidas, 2);
            spellDependentDatabase.Add(CardDB.cardName.burglybully, -1);
            spellDependentDatabase.Add(CardDB.cardName.burlyrockjawtrogg, -1);
            spellDependentDatabase.Add(CardDB.cardName.chromaticdragonkin, -1);
            spellDependentDatabase.Add(CardDB.cardName.cultsorcerer, 1);
            spellDependentDatabase.Add(CardDB.cardName.dementedfrostcaller, 1);
            spellDependentDatabase.Add(CardDB.cardName.djinniofzephyrs, 1);
            spellDependentDatabase.Add(CardDB.cardName.flamewaker, 1);
            spellDependentDatabase.Add(CardDB.cardName.gadgetzanauctioneer, 2);
            spellDependentDatabase.Add(CardDB.cardName.gazlowe, 2);
            spellDependentDatabase.Add(CardDB.cardName.hallazealtheascended, 1);
            spellDependentDatabase.Add(CardDB.cardName.lorewalkercho, 0);
            spellDependentDatabase.Add(CardDB.cardName.lyrathesunshard, 2);
            spellDependentDatabase.Add(CardDB.cardName.manaaddict, 1);
            spellDependentDatabase.Add(CardDB.cardName.manawyrm, 1);
            spellDependentDatabase.Add(CardDB.cardName.priestofthefeast, 1);
            spellDependentDatabase.Add(CardDB.cardName.redmanawyrm, 1);
            spellDependentDatabase.Add(CardDB.cardName.stonesplintertrogg, -1);
            spellDependentDatabase.Add(CardDB.cardName.summoningstone, 3);
            spellDependentDatabase.Add(CardDB.cardName.tradeprincegallywix, -1);
            spellDependentDatabase.Add(CardDB.cardName.troggzortheearthinator, -2);
            spellDependentDatabase.Add(CardDB.cardName.violetteacher, 3);
            spellDependentDatabase.Add(CardDB.cardName.wickedwitchdoctor, 3);
            spellDependentDatabase.Add(CardDB.cardName.wildpyromancer, 1);

            dragonDependentDatabase.Add(CardDB.cardName.alexstraszaschampion, 1);
            dragonDependentDatabase.Add(CardDB.cardName.blackwingcorruptor, 1);
            dragonDependentDatabase.Add(CardDB.cardName.blackwingtechnician, 1);
            dragonDependentDatabase.Add(CardDB.cardName.bookwyrm, 1);
            dragonDependentDatabase.Add(CardDB.cardName.drakonidoperative, 1);
            dragonDependentDatabase.Add(CardDB.cardName.netherspitehistorian, 1);
            dragonDependentDatabase.Add(CardDB.cardName.nightbanetemplar, 1);
            dragonDependentDatabase.Add(CardDB.cardName.rendblackhand, 1);
            dragonDependentDatabase.Add(CardDB.cardName.twilightguardian, 1);
            dragonDependentDatabase.Add(CardDB.cardName.twilightwhelp, 1);
            dragonDependentDatabase.Add(CardDB.cardName.wyrmrestagent, 1);

            elementalLTDependentDatabase.Add(CardDB.cardName.blazecaller, 1);
            elementalLTDependentDatabase.Add(CardDB.cardName.kalimosprimallord, 1);
            elementalLTDependentDatabase.Add(CardDB.cardName.ozruk, 1);
            elementalLTDependentDatabase.Add(CardDB.cardName.servantofkalimos, 1);
            elementalLTDependentDatabase.Add(CardDB.cardName.steamsurger, 1);
            elementalLTDependentDatabase.Add(CardDB.cardName.stonesentinel, 1);
            elementalLTDependentDatabase.Add(CardDB.cardName.thunderlizard, 1);
            elementalLTDependentDatabase.Add(CardDB.cardName.tolvirstoneshaper, 1);
        }

        private void setupSilenceTargets()
        {
            silenceTargets.Add(CardDB.cardName.abomination, 0);
            silenceTargets.Add(CardDB.cardName.acidmaw, 0);
            silenceTargets.Add(CardDB.cardName.acolyteofpain, 0);
            silenceTargets.Add(CardDB.cardName.addledgrizzly, 0);
            silenceTargets.Add(CardDB.cardName.ancientharbinger, 0);
            silenceTargets.Add(CardDB.cardName.animatedarmor, 0);
            silenceTargets.Add(CardDB.cardName.anomalus, 0);
            silenceTargets.Add(CardDB.cardName.anubarak, 0);
            silenceTargets.Add(CardDB.cardName.anubisathsentinel, 0);
            silenceTargets.Add(CardDB.cardName.archmageantonidas, 0);
            silenceTargets.Add(CardDB.cardName.armorsmith, 0);
            silenceTargets.Add(CardDB.cardName.auchenaisoulpriest, 0);
            silenceTargets.Add(CardDB.cardName.aviana, 0);
            silenceTargets.Add(CardDB.cardName.axeflinger, 0);
            silenceTargets.Add(CardDB.cardName.ayablackpaw, 0);
            silenceTargets.Add(CardDB.cardName.backroombouncer, 0);
            silenceTargets.Add(CardDB.cardName.barongeddon, 0);
            silenceTargets.Add(CardDB.cardName.baronrivendare, 0);
            silenceTargets.Add(CardDB.cardName.blackwaterpirate, 0);
            silenceTargets.Add(CardDB.cardName.bloodimp, 0);
            silenceTargets.Add(CardDB.cardName.blubberbaron, 0);
            silenceTargets.Add(CardDB.cardName.bolvarfordragon, 0);
            silenceTargets.Add(CardDB.cardName.boneguardlieutenant, 0);
            silenceTargets.Add(CardDB.cardName.brannbronzebeard, 0);
            silenceTargets.Add(CardDB.cardName.bravearcher, 0);
            silenceTargets.Add(CardDB.cardName.burlyrockjawtrogg, 0);
            silenceTargets.Add(CardDB.cardName.cairnebloodhoof, 0);
            silenceTargets.Add(CardDB.cardName.chillmaw, 0);
            silenceTargets.Add(CardDB.cardName.chromaggus, 0);
            silenceTargets.Add(CardDB.cardName.cobaltguardian, 0);
            silenceTargets.Add(CardDB.cardName.coldarradrake, 0);
            silenceTargets.Add(CardDB.cardName.coliseummanager, 0);
            silenceTargets.Add(CardDB.cardName.confessorpaletress, 0);
            silenceTargets.Add(CardDB.cardName.crazedworshipper, 0);
            silenceTargets.Add(CardDB.cardName.crowdfavorite, 0);
            silenceTargets.Add(CardDB.cardName.crueldinomancer, 0);
            silenceTargets.Add(CardDB.cardName.crystallineoracle, 0);
            silenceTargets.Add(CardDB.cardName.cthun, 0);
            silenceTargets.Add(CardDB.cardName.cultmaster, 0);
            silenceTargets.Add(CardDB.cardName.cultsorcerer, 0);
            silenceTargets.Add(CardDB.cardName.dalaranaspirant, 0);
            silenceTargets.Add(CardDB.cardName.darkcultist, 0);
            silenceTargets.Add(CardDB.cardName.darkshirecouncilman, 0);
            silenceTargets.Add(CardDB.cardName.dementedfrostcaller, 0);
            silenceTargets.Add(CardDB.cardName.devilsauregg, 0);
            silenceTargets.Add(CardDB.cardName.nerubianegg, 0);
            silenceTargets.Add(CardDB.cardName.direhornhatchling, 0);
            silenceTargets.Add(CardDB.cardName.direwolfalpha, 0);
            silenceTargets.Add(CardDB.cardName.djinniofzephyrs, 0);
            silenceTargets.Add(CardDB.cardName.doomsayer, 0);
            silenceTargets.Add(CardDB.cardName.dragonegg, 0);
            silenceTargets.Add(CardDB.cardName.dragonhawkrider, 0);
            silenceTargets.Add(CardDB.cardName.dragonkinsorcerer, 0);
            silenceTargets.Add(CardDB.cardName.dreadscale, 0);
            silenceTargets.Add(CardDB.cardName.eggnapper, 0);
            silenceTargets.Add(CardDB.cardName.emboldener3000, 0);
            silenceTargets.Add(CardDB.cardName.emperorcobra, 0);
            silenceTargets.Add(CardDB.cardName.emperorthaurissan, 0);
            silenceTargets.Add(CardDB.cardName.etherealarcanist, 0);
            silenceTargets.Add(CardDB.cardName.evolvedkobold, 0);
            silenceTargets.Add(CardDB.cardName.explosivesheep, 0);
            silenceTargets.Add(CardDB.cardName.eydisdarkbane, 0);
            silenceTargets.Add(CardDB.cardName.fallenhero, 0);
            silenceTargets.Add(CardDB.cardName.masterchest, 0);            
            silenceTargets.Add(CardDB.cardName.fandralstaghelm, 0);
            silenceTargets.Add(CardDB.cardName.feugen, 0);
            silenceTargets.Add(CardDB.cardName.finjatheflyingstar, 0);
            silenceTargets.Add(CardDB.cardName.fjolalightbane, 0);
            silenceTargets.Add(CardDB.cardName.flametonguetotem, 0);
            silenceTargets.Add(CardDB.cardName.flamewaker, 0);
            silenceTargets.Add(CardDB.cardName.flesheatingghoul, 0);
            silenceTargets.Add(CardDB.cardName.floatingwatcher, 0);
            silenceTargets.Add(CardDB.cardName.foereaper4000, 0);
            silenceTargets.Add(CardDB.cardName.frothingberserker, 0);
            silenceTargets.Add(CardDB.cardName.gadgetzanauctioneer, 10);
            silenceTargets.Add(CardDB.cardName.gahzrilla, 0);
            silenceTargets.Add(CardDB.cardName.garr, 0);
            silenceTargets.Add(CardDB.cardName.garrisoncommander, 0);
            silenceTargets.Add(CardDB.cardName.giantanaconda, 0);
            silenceTargets.Add(CardDB.cardName.giantsandworm, 0);
            silenceTargets.Add(CardDB.cardName.giantwasp, 0);
            silenceTargets.Add(CardDB.cardName.grimestreetenforcer, 0);
            silenceTargets.Add(CardDB.cardName.grimpatron, 0);
            silenceTargets.Add(CardDB.cardName.grimscaleoracle, 0);
            silenceTargets.Add(CardDB.cardName.grimygadgeteer, 0);
            silenceTargets.Add(CardDB.cardName.grommashhellscream, 0);
            silenceTargets.Add(CardDB.cardName.gruul, 0);
            silenceTargets.Add(CardDB.cardName.gurubashiberserker, 0);
            silenceTargets.Add(CardDB.cardName.hallazealtheascended, 0);
            silenceTargets.Add(CardDB.cardName.hauntedcreeper, 0);
            silenceTargets.Add(CardDB.cardName.hobgoblin, 0);
            silenceTargets.Add(CardDB.cardName.hogger, 0);
            silenceTargets.Add(CardDB.cardName.hoggerdoomofelwynn, 0);
            silenceTargets.Add(CardDB.cardName.holychampion, 0);
            silenceTargets.Add(CardDB.cardName.homingchicken, 0);
            silenceTargets.Add(CardDB.cardName.hoodedacolyte, 0);
            silenceTargets.Add(CardDB.cardName.igneouselemental, 0);
            silenceTargets.Add(CardDB.cardName.illidanstormrage, 0);
            silenceTargets.Add(CardDB.cardName.impgangboss, 0);
            silenceTargets.Add(CardDB.cardName.impmaster, 0);
            silenceTargets.Add(CardDB.cardName.ironsensei, 0);
            silenceTargets.Add(CardDB.cardName.jadeswarmer, 0);
            silenceTargets.Add(CardDB.cardName.jeeves, 0);
            silenceTargets.Add(CardDB.cardName.junkbot, 0);
            silenceTargets.Add(CardDB.cardName.kabaltrafficker, 0);
            silenceTargets.Add(CardDB.cardName.kelthuzad, 10);
            silenceTargets.Add(CardDB.cardName.kindlygrandmother, 0);
            silenceTargets.Add(CardDB.cardName.knifejuggler, 0);
            silenceTargets.Add(CardDB.cardName.knuckles, 0);
            silenceTargets.Add(CardDB.cardName.kodorider, 0);
            silenceTargets.Add(CardDB.cardName.kvaldirraider, 0);
            silenceTargets.Add(CardDB.cardName.leokk, 0);
            silenceTargets.Add(CardDB.cardName.lightspawn, 0);
            silenceTargets.Add(CardDB.cardName.lightwarden, 0);
            silenceTargets.Add(CardDB.cardName.lightwell, 0);
            silenceTargets.Add(CardDB.cardName.lorewalkercho, 0);
            silenceTargets.Add(CardDB.cardName.lowlysquire, 0);
            silenceTargets.Add(CardDB.cardName.lyrathesunshard, 0);
            silenceTargets.Add(CardDB.cardName.madscientist, 0);
            silenceTargets.Add(CardDB.cardName.maexxna, 0);
            silenceTargets.Add(CardDB.cardName.magnatauralpha, 0);
            silenceTargets.Add(CardDB.cardName.maidenofthelake, 0);
            silenceTargets.Add(CardDB.cardName.majordomoexecutus, 0);
            silenceTargets.Add(CardDB.cardName.malganis, 0);
            silenceTargets.Add(CardDB.cardName.malorne, 0);
            silenceTargets.Add(CardDB.cardName.malygos, 0);
            silenceTargets.Add(CardDB.cardName.manaaddict, 0);
            silenceTargets.Add(CardDB.cardName.manageode, 0);
            silenceTargets.Add(CardDB.cardName.manatidetotem, 0);
            silenceTargets.Add(CardDB.cardName.manatreant, 0);
            silenceTargets.Add(CardDB.cardName.manawraith, 0);
            silenceTargets.Add(CardDB.cardName.manawyrm, 0);
            silenceTargets.Add(CardDB.cardName.masterswordsmith, 0);
            silenceTargets.Add(CardDB.cardName.mekgineerthermaplugg, 0);
            silenceTargets.Add(CardDB.cardName.micromachine, 0);
            silenceTargets.Add(CardDB.cardName.mogortheogre, 0);
            silenceTargets.Add(CardDB.cardName.muklaschampion, 0);
            silenceTargets.Add(CardDB.cardName.murlocknight, 0);
            silenceTargets.Add(CardDB.cardName.murloctidecaller, 0);
            silenceTargets.Add(CardDB.cardName.murlocwarleader, 0);
            silenceTargets.Add(CardDB.cardName.natpagle, 0);
            silenceTargets.Add(CardDB.cardName.nerubarweblord, 0);
            silenceTargets.Add(CardDB.cardName.nexuschampionsaraad, 0);
            silenceTargets.Add(CardDB.cardName.northshirecleric, 0);
            silenceTargets.Add(CardDB.cardName.obsidiandestroyer, 0);
            silenceTargets.Add(CardDB.cardName.oldmurkeye, 0);
            silenceTargets.Add(CardDB.cardName.oneeyedcheat, 0);
            silenceTargets.Add(CardDB.cardName.orgrimmaraspirant, 0);
            silenceTargets.Add(CardDB.cardName.pilotedskygolem, 0);
            silenceTargets.Add(CardDB.cardName.pitsnake, 0);
            silenceTargets.Add(CardDB.cardName.primalfinchampion, 0);
            silenceTargets.Add(CardDB.cardName.primalfintotem, 0);
            silenceTargets.Add(CardDB.cardName.prophetvelen, 0);
            silenceTargets.Add(CardDB.cardName.pyros, 0);
            silenceTargets.Add(CardDB.cardName.questingadventurer, 0);
            silenceTargets.Add(CardDB.cardName.radiantelemental, 0);
            silenceTargets.Add(CardDB.cardName.ragingworgen, 0);
            silenceTargets.Add(CardDB.cardName.raidleader, 0);
            silenceTargets.Add(CardDB.cardName.raptorhatchling, 0);
            silenceTargets.Add(CardDB.cardName.ratpack, 0);
            silenceTargets.Add(CardDB.cardName.recruiter, 0);
            silenceTargets.Add(CardDB.cardName.redmanawyrm, 0);
            silenceTargets.Add(CardDB.cardName.rhonin, 0);
            silenceTargets.Add(CardDB.cardName.rumblingelemental, 0);
            silenceTargets.Add(CardDB.cardName.satedthreshadon, 0);
            silenceTargets.Add(CardDB.cardName.savagecombatant, 0);
            silenceTargets.Add(CardDB.cardName.savannahhighmane, 0);
            silenceTargets.Add(CardDB.cardName.scalednightmare, 0);
            silenceTargets.Add(CardDB.cardName.scavenginghyena, 0);
            silenceTargets.Add(CardDB.cardName.secretkeeper, 0);
            silenceTargets.Add(CardDB.cardName.selflesshero, 0);
            silenceTargets.Add(CardDB.cardName.sergeantsally, 0);
            silenceTargets.Add(CardDB.cardName.shadeofnaxxramas, 0);
            silenceTargets.Add(CardDB.cardName.shadowboxer, 0);
            silenceTargets.Add(CardDB.cardName.shakuthecollector, 0);
            silenceTargets.Add(CardDB.cardName.sherazincorpseflower, 0);
            silenceTargets.Add(CardDB.cardName.shiftingshade, 0);
            silenceTargets.Add(CardDB.cardName.shimmeringtempest, 0);
            silenceTargets.Add(CardDB.cardName.shipscannon, 0);
            silenceTargets.Add(CardDB.cardName.siegeengine, 0);
            silenceTargets.Add(CardDB.cardName.siltfinspiritwalker, 0);
            silenceTargets.Add(CardDB.cardName.silverhandregent, 0);
            silenceTargets.Add(CardDB.cardName.sneedsoldshredder, 0);
            silenceTargets.Add(CardDB.cardName.sorcerersapprentice, 0);
            silenceTargets.Add(CardDB.cardName.southseacaptain, 0);
            silenceTargets.Add(CardDB.cardName.southseasquidface, 0);
            silenceTargets.Add(CardDB.cardName.spawnofnzoth, 0);
            silenceTargets.Add(CardDB.cardName.spawnofshadows, 0);
            silenceTargets.Add(CardDB.cardName.spiritsingerumbra, 0);
            silenceTargets.Add(CardDB.cardName.spitefulsmith, 0);
            silenceTargets.Add(CardDB.cardName.stalagg, 0);
            silenceTargets.Add(CardDB.cardName.starvingbuzzard, 0);
            silenceTargets.Add(CardDB.cardName.steamwheedlesniper, 0);
            silenceTargets.Add(CardDB.cardName.stewardofdarkshire, 0);
            silenceTargets.Add(CardDB.cardName.stonesplintertrogg, 0);
            silenceTargets.Add(CardDB.cardName.stormwindchampion, 0);
            silenceTargets.Add(CardDB.cardName.summoningportal, 0);
            silenceTargets.Add(CardDB.cardName.summoningstone, 0);
            silenceTargets.Add(CardDB.cardName.sylvanaswindrunner, 0);
            silenceTargets.Add(CardDB.cardName.tarcreeper, 0);
            silenceTargets.Add(CardDB.cardName.tarlord, 0);
            silenceTargets.Add(CardDB.cardName.tarlurker, 0);
            silenceTargets.Add(CardDB.cardName.theboogeymonster, 0);
            silenceTargets.Add(CardDB.cardName.theskeletonknight, 0);
            silenceTargets.Add(CardDB.cardName.thevoraxx, 0);
            silenceTargets.Add(CardDB.cardName.thunderbluffvaliant, 0);
            silenceTargets.Add(CardDB.cardName.timberwolf, 0);
            silenceTargets.Add(CardDB.cardName.tirionfordring, 0);
            silenceTargets.Add(CardDB.cardName.tortollanshellraiser, 0);
            silenceTargets.Add(CardDB.cardName.tournamentmedic, 0);
            silenceTargets.Add(CardDB.cardName.tradeprincegallywix, 0);
            silenceTargets.Add(CardDB.cardName.troggzortheearthinator, 0);
            silenceTargets.Add(CardDB.cardName.tundrarhino, 0);
            silenceTargets.Add(CardDB.cardName.twilightelder, 0);
            silenceTargets.Add(CardDB.cardName.twilightsummoner, 0);
            silenceTargets.Add(CardDB.cardName.unboundelemental, 0);
            silenceTargets.Add(CardDB.cardName.undercityhuckster, 0);
            silenceTargets.Add(CardDB.cardName.undertaker, 0);
            silenceTargets.Add(CardDB.cardName.usherofsouls, 0);
            silenceTargets.Add(CardDB.cardName.v07tr0n, 0);
            silenceTargets.Add(CardDB.cardName.viciousfledgling, 0);
            silenceTargets.Add(CardDB.cardName.violetillusionist, 0);
            silenceTargets.Add(CardDB.cardName.violetteacher, 0);
            silenceTargets.Add(CardDB.cardName.vitalitytotem, 0);
            silenceTargets.Add(CardDB.cardName.voidcrusher, 0);
            silenceTargets.Add(CardDB.cardName.volatileelemental, 0);
            silenceTargets.Add(CardDB.cardName.warhorsetrainer, 0);
            silenceTargets.Add(CardDB.cardName.warsongcommander, 0);
            silenceTargets.Add(CardDB.cardName.webspinner, 0);
            silenceTargets.Add(CardDB.cardName.whiteeyes, 0);
            silenceTargets.Add(CardDB.cardName.wickedwitchdoctor, 0);
            silenceTargets.Add(CardDB.cardName.wilfredfizzlebang, 0);
            silenceTargets.Add(CardDB.cardName.windupburglebot, 0);
            silenceTargets.Add(CardDB.cardName.wobblingrunts, 0);
            silenceTargets.Add(CardDB.cardName.youngpriestess, 0);
            silenceTargets.Add(CardDB.cardName.ysera, 0);
            silenceTargets.Add(CardDB.cardName.yshaarjrageunbound, 0);
            silenceTargets.Add(CardDB.cardName.zealousinitiate, 0);
            silenceTargets.Add(CardDB.cardName.vryghoul, 0);
            silenceTargets.Add(CardDB.cardName.thelichking, 0);
            silenceTargets.Add(CardDB.cardName.skelemancer, 0);
            silenceTargets.Add(CardDB.cardName.shallowgravedigger, 0);
            silenceTargets.Add(CardDB.cardName.shadowascendant, 0);
            silenceTargets.Add(CardDB.cardName.moirabronzebeard, 0);
            silenceTargets.Add(CardDB.cardName.meatwagon, 0);
            silenceTargets.Add(CardDB.cardName.highjusticegrimstone, 0);
            silenceTargets.Add(CardDB.cardName.hadronox, 0);
            silenceTargets.Add(CardDB.cardName.frozenchampion, 0);
            silenceTargets.Add(CardDB.cardName.festergut, 0);
            silenceTargets.Add(CardDB.cardName.fatespinner, 0);
            silenceTargets.Add(CardDB.cardName.explodingbloatbat, 0);
            silenceTargets.Add(CardDB.cardName.drakkarienchanter, 0);
            silenceTargets.Add(CardDB.cardName.despicabledreadlord, 0);
            silenceTargets.Add(CardDB.cardName.cobaltscalebane, 0);
            silenceTargets.Add(CardDB.cardName.bonedrake, 0);
            silenceTargets.Add(CardDB.cardName.bonebaron, 0);
            silenceTargets.Add(CardDB.cardName.blackguard, 0);
            silenceTargets.Add(CardDB.cardName.arrogantcrusader, 0);
            silenceTargets.Add(CardDB.cardName.arfus, 0);
            silenceTargets.Add(CardDB.cardName.abominablebowman, 0);
            silenceTargets.Add(CardDB.cardName.voodoohexxer, 0);
            silenceTargets.Add(CardDB.cardName.venomancer, 0);
            silenceTargets.Add(CardDB.cardName.valkyrsoulclaimer, 0);
            silenceTargets.Add(CardDB.cardName.stubborngastropod, 0);
            silenceTargets.Add(CardDB.cardName.runeforgehaunter, 0);
            silenceTargets.Add(CardDB.cardName.rotface, 0);
            silenceTargets.Add(CardDB.cardName.professorputricide, 0);
            silenceTargets.Add(CardDB.cardName.nighthowler, 0);
            silenceTargets.Add(CardDB.cardName.nerubianunraveler, 0);
            silenceTargets.Add(CardDB.cardName.necroticgeist, 0);
            silenceTargets.Add(CardDB.cardName.moorabi, 0);
            silenceTargets.Add(CardDB.cardName.icewalker, 0);
            silenceTargets.Add(CardDB.cardName.doomedapprentice, 0);
            silenceTargets.Add(CardDB.cardName.cryptlord, 0);
            silenceTargets.Add(CardDB.cardName.corpsewidow, 0);
            silenceTargets.Add(CardDB.cardName.bolvarfireblood, 0);
            silenceTargets.Add(CardDB.cardName.bloodqueenlanathel, 0);
        }

        private void setupRandomCards()
        {
            randomEffects.Add(CardDB.cardName.alightinthedarkness, 1);
            randomEffects.Add(CardDB.cardName.ancestorscall, 1);
            randomEffects.Add(CardDB.cardName.animalcompanion, 1);
            randomEffects.Add(CardDB.cardName.arcanemissiles, 3);
            randomEffects.Add(CardDB.cardName.archthiefrafaam, 1);
            randomEffects.Add(CardDB.cardName.armoredwarhorse, 1);
            randomEffects.Add(CardDB.cardName.avengingwrath, 8);
            randomEffects.Add(CardDB.cardName.babblingbook, 1);
            randomEffects.Add(CardDB.cardName.barnes, 1);
            randomEffects.Add(CardDB.cardName.bomblobber, 1);
            randomEffects.Add(CardDB.cardName.bouncingblade, 3);
            randomEffects.Add(CardDB.cardName.brawl, 1);
            randomEffects.Add(CardDB.cardName.captainsparrot, 1);
            randomEffects.Add(CardDB.cardName.chitteringtunneler, 1);
            randomEffects.Add(CardDB.cardName.chooseyourpath, 1);
            randomEffects.Add(CardDB.cardName.cleave, 2);
            randomEffects.Add(CardDB.cardName.coghammer, 1);
            randomEffects.Add(CardDB.cardName.crackle, 1);
            randomEffects.Add(CardDB.cardName.cthun, 10);
            randomEffects.Add(CardDB.cardName.darkbargain, 2);
            randomEffects.Add(CardDB.cardName.darkpeddler, 1);
            randomEffects.Add(CardDB.cardName.deadlyshot, 1);
            randomEffects.Add(CardDB.cardName.desertcamel, 1);
            randomEffects.Add(CardDB.cardName.elementaldestruction, 1);
            randomEffects.Add(CardDB.cardName.elitetaurenchieftain, 1);
            randomEffects.Add(CardDB.cardName.enhanceomechano, 1);
            randomEffects.Add(CardDB.cardName.etherealconjurer, 1);
            randomEffects.Add(CardDB.cardName.fierybat, 1);
            randomEffects.Add(CardDB.cardName.finderskeepers, 1);
            randomEffects.Add(CardDB.cardName.firelandsportal, 1);
            randomEffects.Add(CardDB.cardName.flamecannon, 1);
            randomEffects.Add(CardDB.cardName.flamejuggler, 1);
            randomEffects.Add(CardDB.cardName.flamewaker, 2);
            randomEffects.Add(CardDB.cardName.forkedlightning, 1);
            randomEffects.Add(CardDB.cardName.freefromamber, 1);
            randomEffects.Add(CardDB.cardName.zarogscrown, 1);
            randomEffects.Add(CardDB.cardName.gelbinmekkatorque, 1);
            randomEffects.Add(CardDB.cardName.glaivezooka, 1);
            randomEffects.Add(CardDB.cardName.grandcrusader, 1);
            randomEffects.Add(CardDB.cardName.greaterarcanemissiles, 3);
            randomEffects.Add(CardDB.cardName.grimestreetinformant, 1);
            randomEffects.Add(CardDB.cardName.hallucination, 1);
            randomEffects.Add(CardDB.cardName.harvest, 1);
            randomEffects.Add(CardDB.cardName.hungrydragon, 1);
            randomEffects.Add(CardDB.cardName.hydrologist, 1);
            randomEffects.Add(CardDB.cardName.iammurloc, 3);
            randomEffects.Add(CardDB.cardName.iknowaguy, 1);
            randomEffects.Add(CardDB.cardName.ironforgeportal, 1);
            randomEffects.Add(CardDB.cardName.ivoryknight, 1);
            randomEffects.Add(CardDB.cardName.jeweledscarab, 1);
            randomEffects.Add(CardDB.cardName.journeybelow, 1);
            randomEffects.Add(CardDB.cardName.kabalchemist, 1);
            randomEffects.Add(CardDB.cardName.kabalcourier, 1);
            randomEffects.Add(CardDB.cardName.kazakus, 1);
            randomEffects.Add(CardDB.cardName.kingsblood, 1);
            randomEffects.Add(CardDB.cardName.lifetap, 1);
            randomEffects.Add(CardDB.cardName.lightningstorm, 1);
            randomEffects.Add(CardDB.cardName.lockandload, 10);
            randomEffects.Add(CardDB.cardName.lotusagents, 1);
            randomEffects.Add(CardDB.cardName.madbomber, 3);
            randomEffects.Add(CardDB.cardName.madderbomber, 1);
            randomEffects.Add(CardDB.cardName.maelstromportal, 1);
            randomEffects.Add(CardDB.cardName.masterjouster, 1);
            randomEffects.Add(CardDB.cardName.menageriemagician, 0);
            randomEffects.Add(CardDB.cardName.mindcontroltech, 1);
            randomEffects.Add(CardDB.cardName.mindgames, 1);
            randomEffects.Add(CardDB.cardName.mindvision, 1);
            randomEffects.Add(CardDB.cardName.mogorschampion, 1);
            randomEffects.Add(CardDB.cardName.mogortheogre, 1);
            randomEffects.Add(CardDB.cardName.moongladeportal, 1);
            randomEffects.Add(CardDB.cardName.multishot, 2);
            randomEffects.Add(CardDB.cardName.museumcurator, 1);
            randomEffects.Add(CardDB.cardName.mysteriouschallenger, 2);
            randomEffects.Add(CardDB.cardName.pileon, 1);
            randomEffects.Add(CardDB.cardName.powerofthehorde, 1);
            randomEffects.Add(CardDB.cardName.primordialglyph, 1);
            randomEffects.Add(CardDB.cardName.ramwrangler, 1);
            randomEffects.Add(CardDB.cardName.ravenidol, 1);
            randomEffects.Add(CardDB.cardName.resurrect, 1);
            randomEffects.Add(CardDB.cardName.sabotage, 0);
            randomEffects.Add(CardDB.cardName.sensedemons, 2);
            randomEffects.Add(CardDB.cardName.servantofkalimos, 1);
            randomEffects.Add(CardDB.cardName.shadowoil, 1);
            randomEffects.Add(CardDB.cardName.shadowvisions, 1);
            randomEffects.Add(CardDB.cardName.silvermoonportal, 1);
            randomEffects.Add(CardDB.cardName.sirfinleymrrgglton, 1);
            randomEffects.Add(CardDB.cardName.soultap, 1);
            randomEffects.Add(CardDB.cardName.spellslinger, 1);
            randomEffects.Add(CardDB.cardName.spreadingmadness, 9);
            randomEffects.Add(CardDB.cardName.stampede, 10);
            randomEffects.Add(CardDB.cardName.stonehilldefender, 1);
            randomEffects.Add(CardDB.cardName.swashburglar, 1);
            randomEffects.Add(CardDB.cardName.timepieceofhorror, 10);
            randomEffects.Add(CardDB.cardName.tinkmasteroverspark, 1);
            randomEffects.Add(CardDB.cardName.tombspider, 1);
            randomEffects.Add(CardDB.cardName.tortollanprimalist, 1);
            randomEffects.Add(CardDB.cardName.totemiccall, 1);
            randomEffects.Add(CardDB.cardName.tuskarrtotemic, 1);
            randomEffects.Add(CardDB.cardName.unholyshadow, 2);
            randomEffects.Add(CardDB.cardName.unstableportal, 1);
            randomEffects.Add(CardDB.cardName.varianwrynn, 2);
            randomEffects.Add(CardDB.cardName.volcano, 15);
            randomEffects.Add(CardDB.cardName.xarilpoisonedmind, 1);
            randomEffects.Add(CardDB.cardName.zoobot, 0);
            randomEffects.Add(CardDB.cardName.tomblurker, 1);
            randomEffects.Add(CardDB.cardName.ghastlyconjurer, 1);
            randomEffects.Add(CardDB.cardName.shadowessence, 1);

        }


        private void setupChooseDatabase()
        {
            this.choose1database.Add(CardDB.cardName.ancientoflore, CardDB.cardIDEnum.NEW1_008a);
            this.choose1database.Add(CardDB.cardName.ancientofwar, CardDB.cardIDEnum.EX1_178b);
            this.choose1database.Add(CardDB.cardName.anodizedrobocub, CardDB.cardIDEnum.GVG_030a);
            this.choose1database.Add(CardDB.cardName.cenarius, CardDB.cardIDEnum.EX1_573a);
            this.choose1database.Add(CardDB.cardName.darkwispers, CardDB.cardIDEnum.GVG_041b);
            this.choose1database.Add(CardDB.cardName.druidoftheclaw, CardDB.cardIDEnum.EX1_165t1);
            this.choose1database.Add(CardDB.cardName.druidoftheflame, CardDB.cardIDEnum.BRM_010t);
            this.choose1database.Add(CardDB.cardName.druidofthesaber, CardDB.cardIDEnum.AT_042t);
            this.choose1database.Add(CardDB.cardName.feralrage, CardDB.cardIDEnum.OG_047a);
            this.choose1database.Add(CardDB.cardName.grovetender, CardDB.cardIDEnum.GVG_032a);
            this.choose1database.Add(CardDB.cardName.jadeidol, CardDB.cardIDEnum.CFM_602a);
            this.choose1database.Add(CardDB.cardName.keeperofthegrove, CardDB.cardIDEnum.EX1_166a);
            this.choose1database.Add(CardDB.cardName.kuntheforgottenking, CardDB.cardIDEnum.CFM_308a);
            this.choose1database.Add(CardDB.cardName.livingroots, CardDB.cardIDEnum.AT_037a);
            this.choose1database.Add(CardDB.cardName.markofnature, CardDB.cardIDEnum.EX1_155a);
            this.choose1database.Add(CardDB.cardName.mirekeeper, CardDB.cardIDEnum.OG_202a);
            this.choose1database.Add(CardDB.cardName.nourish, CardDB.cardIDEnum.EX1_164a);
            this.choose1database.Add(CardDB.cardName.powerofthewild, CardDB.cardIDEnum.EX1_160b);
            this.choose1database.Add(CardDB.cardName.ravenidol, CardDB.cardIDEnum.LOE_115a);
            this.choose1database.Add(CardDB.cardName.shellshifter, CardDB.cardIDEnum.UNG_101t);
            this.choose1database.Add(CardDB.cardName.starfall, CardDB.cardIDEnum.NEW1_007b);
            this.choose1database.Add(CardDB.cardName.wispsoftheoldgods, CardDB.cardIDEnum.OG_195a);
            this.choose1database.Add(CardDB.cardName.wrath, CardDB.cardIDEnum.EX1_154a);
            this.choose1database.Add(CardDB.cardName.malfurionthepestilent, CardDB.cardIDEnum.ICC_832b);
            this.choose1database.Add(CardDB.cardName.plaguelord, CardDB.cardIDEnum.ICC_832pb);
            this.choose1database.Add(CardDB.cardName.druidoftheswarm, CardDB.cardIDEnum.ICC_051t);

            this.choose2database.Add(CardDB.cardName.ancientoflore, CardDB.cardIDEnum.NEW1_008b);
            this.choose2database.Add(CardDB.cardName.ancientofwar, CardDB.cardIDEnum.EX1_178a);
            this.choose2database.Add(CardDB.cardName.anodizedrobocub, CardDB.cardIDEnum.GVG_030b);
            this.choose2database.Add(CardDB.cardName.cenarius, CardDB.cardIDEnum.EX1_573b);
            this.choose2database.Add(CardDB.cardName.darkwispers, CardDB.cardIDEnum.GVG_041a);
            this.choose2database.Add(CardDB.cardName.druidoftheclaw, CardDB.cardIDEnum.EX1_165t2);
            this.choose2database.Add(CardDB.cardName.druidoftheflame, CardDB.cardIDEnum.BRM_010t2);
            this.choose2database.Add(CardDB.cardName.druidofthesaber, CardDB.cardIDEnum.AT_042t2);
            this.choose2database.Add(CardDB.cardName.feralrage, CardDB.cardIDEnum.OG_047b);
            this.choose2database.Add(CardDB.cardName.grovetender, CardDB.cardIDEnum.GVG_032b);
            this.choose2database.Add(CardDB.cardName.jadeidol, CardDB.cardIDEnum.CFM_602b);
            this.choose2database.Add(CardDB.cardName.keeperofthegrove, CardDB.cardIDEnum.EX1_166b);
            this.choose2database.Add(CardDB.cardName.kuntheforgottenking, CardDB.cardIDEnum.CFM_308b);
            this.choose2database.Add(CardDB.cardName.livingroots, CardDB.cardIDEnum.AT_037b);
            this.choose2database.Add(CardDB.cardName.markofnature, CardDB.cardIDEnum.EX1_155b);
            this.choose2database.Add(CardDB.cardName.mirekeeper, CardDB.cardIDEnum.OG_202ae);
            this.choose2database.Add(CardDB.cardName.nourish, CardDB.cardIDEnum.EX1_164b);
            this.choose2database.Add(CardDB.cardName.powerofthewild, CardDB.cardIDEnum.EX1_160t);
            this.choose2database.Add(CardDB.cardName.ravenidol, CardDB.cardIDEnum.LOE_115b);
            this.choose2database.Add(CardDB.cardName.shellshifter, CardDB.cardIDEnum.UNG_101t2);
            this.choose2database.Add(CardDB.cardName.starfall, CardDB.cardIDEnum.NEW1_007a);
            this.choose2database.Add(CardDB.cardName.wispsoftheoldgods, CardDB.cardIDEnum.OG_195b);
            this.choose2database.Add(CardDB.cardName.wrath, CardDB.cardIDEnum.EX1_154b);
            this.choose2database.Add(CardDB.cardName.malfurionthepestilent, CardDB.cardIDEnum.ICC_832a);
            this.choose2database.Add(CardDB.cardName.plaguelord, CardDB.cardIDEnum.ICC_832pa);
            this.choose2database.Add(CardDB.cardName.druidoftheswarm, CardDB.cardIDEnum.ICC_051t2);
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
            GangUpDatabase.Add(CardDB.cardName.addledgrizzly, 1);
            GangUpDatabase.Add(CardDB.cardName.alakirthewindlord, 5);
            GangUpDatabase.Add(CardDB.cardName.aldorpeacekeeper, 5);
            GangUpDatabase.Add(CardDB.cardName.ancientoflore, 5);
            GangUpDatabase.Add(CardDB.cardName.ancientofwar, 5);
            GangUpDatabase.Add(CardDB.cardName.antiquehealbot, 5);
            GangUpDatabase.Add(CardDB.cardName.anubarak, 5);
            GangUpDatabase.Add(CardDB.cardName.archmageantonidas, 3);
            GangUpDatabase.Add(CardDB.cardName.armorsmith, 0);
            GangUpDatabase.Add(CardDB.cardName.ayablackpaw, 5);
            GangUpDatabase.Add(CardDB.cardName.azuredrake, 5);
            GangUpDatabase.Add(CardDB.cardName.baronrivendare, 1);
            GangUpDatabase.Add(CardDB.cardName.biggamehunter, 5);
            GangUpDatabase.Add(CardDB.cardName.biteweed, 5);
            GangUpDatabase.Add(CardDB.cardName.bladeofcthun, 5);
            GangUpDatabase.Add(CardDB.cardName.bloodimp, 1);
            GangUpDatabase.Add(CardDB.cardName.bomblobber, 4);
            GangUpDatabase.Add(CardDB.cardName.boneguardlieutenant, 3);
            GangUpDatabase.Add(CardDB.cardName.burglybully, 0);
            GangUpDatabase.Add(CardDB.cardName.burlyrockjawtrogg, 1);
            GangUpDatabase.Add(CardDB.cardName.cabalshadowpriest, 5);
            GangUpDatabase.Add(CardDB.cardName.cairnebloodhoof, 5);
            GangUpDatabase.Add(CardDB.cardName.cenarius, 5);
            GangUpDatabase.Add(CardDB.cardName.chromaggus, 4);
            GangUpDatabase.Add(CardDB.cardName.cobaltguardian, 1);
            GangUpDatabase.Add(CardDB.cardName.coldarradrake, 1);
            GangUpDatabase.Add(CardDB.cardName.coldlightoracle, 5);
            GangUpDatabase.Add(CardDB.cardName.confessorpaletress, 5);
            GangUpDatabase.Add(CardDB.cardName.corendirebrew, 5);
            GangUpDatabase.Add(CardDB.cardName.cthun, 5);
            GangUpDatabase.Add(CardDB.cardName.cultapothecary, 1);
            GangUpDatabase.Add(CardDB.cardName.cultmaster, 1);
            GangUpDatabase.Add(CardDB.cardName.cultsorcerer, 5);
            GangUpDatabase.Add(CardDB.cardName.dementedfrostcaller, 5);
            GangUpDatabase.Add(CardDB.cardName.demolisher, 1);
            GangUpDatabase.Add(CardDB.cardName.direwolfalpha, 1);
            GangUpDatabase.Add(CardDB.cardName.doppelgangster, 1);
            GangUpDatabase.Add(CardDB.cardName.dragonkinsorcerer, 0);
            GangUpDatabase.Add(CardDB.cardName.drboom, 5);
            GangUpDatabase.Add(CardDB.cardName.earthenringfarseer, 3);
            GangUpDatabase.Add(CardDB.cardName.edwinvancleef, 5);
            GangUpDatabase.Add(CardDB.cardName.emboldener3000, 1);
            GangUpDatabase.Add(CardDB.cardName.emperorthaurissan, 5);
            GangUpDatabase.Add(CardDB.cardName.etherealpeddler, 3);
            GangUpDatabase.Add(CardDB.cardName.felcannon, 0);
            GangUpDatabase.Add(CardDB.cardName.fireelemental, 5);
            GangUpDatabase.Add(CardDB.cardName.fireguarddestroyer, 4);
            GangUpDatabase.Add(CardDB.cardName.flametonguetotem, 4);
            GangUpDatabase.Add(CardDB.cardName.flamewaker, 4);
            GangUpDatabase.Add(CardDB.cardName.flesheatingghoul, 0);
            GangUpDatabase.Add(CardDB.cardName.floatingwatcher, 0);
            GangUpDatabase.Add(CardDB.cardName.foereaper4000, 1);
            GangUpDatabase.Add(CardDB.cardName.friendlybartender, 3);
            GangUpDatabase.Add(CardDB.cardName.frothingberserker, 1);
            GangUpDatabase.Add(CardDB.cardName.gadgetzanauctioneer, 1);
            GangUpDatabase.Add(CardDB.cardName.gahzrilla, 5);
            GangUpDatabase.Add(CardDB.cardName.garr, 5);
            GangUpDatabase.Add(CardDB.cardName.gazlowe, 1);
            GangUpDatabase.Add(CardDB.cardName.gelbinmekkatorque, 3);
            GangUpDatabase.Add(CardDB.cardName.genzotheshark, 5);
            GangUpDatabase.Add(CardDB.cardName.grimestreetenforcer, 3);
            GangUpDatabase.Add(CardDB.cardName.grimscaleoracle, 1);
            GangUpDatabase.Add(CardDB.cardName.grimygadgeteer, 3);
            GangUpDatabase.Add(CardDB.cardName.gruul, 4);
            GangUpDatabase.Add(CardDB.cardName.harrisonjones, 1);
            GangUpDatabase.Add(CardDB.cardName.hemetnesingwary, 1);
            GangUpDatabase.Add(CardDB.cardName.highjusticegrimstone, 5);
            GangUpDatabase.Add(CardDB.cardName.hobgoblin, 1);
            GangUpDatabase.Add(CardDB.cardName.hogger, 5);
            GangUpDatabase.Add(CardDB.cardName.hoggerdoomofelwynn, 1);
            GangUpDatabase.Add(CardDB.cardName.igneouselemental, 1);
            GangUpDatabase.Add(CardDB.cardName.illidanstormrage, 5);
            GangUpDatabase.Add(CardDB.cardName.impmaster, 0);
            GangUpDatabase.Add(CardDB.cardName.infestedtauren, 1);
            GangUpDatabase.Add(CardDB.cardName.ironbeakowl, 4);
            GangUpDatabase.Add(CardDB.cardName.ironjuggernaut, 2);
            GangUpDatabase.Add(CardDB.cardName.ironsensei, 1);
            GangUpDatabase.Add(CardDB.cardName.jadeswarmer, 5);
            GangUpDatabase.Add(CardDB.cardName.jeeves, 0);
            GangUpDatabase.Add(CardDB.cardName.junkbot, 1);
            GangUpDatabase.Add(CardDB.cardName.kelthuzad, 5);
            GangUpDatabase.Add(CardDB.cardName.kingkrush, 5);
            GangUpDatabase.Add(CardDB.cardName.knifejuggler, 3);
            GangUpDatabase.Add(CardDB.cardName.kodorider, 5);
            GangUpDatabase.Add(CardDB.cardName.leeroyjenkins, 3);
            GangUpDatabase.Add(CardDB.cardName.leokk, 3);
            GangUpDatabase.Add(CardDB.cardName.lightwarden, 0);
            GangUpDatabase.Add(CardDB.cardName.lightwell, 1);
            GangUpDatabase.Add(CardDB.cardName.loatheb, 5);
            GangUpDatabase.Add(CardDB.cardName.lucifron, 5);
            GangUpDatabase.Add(CardDB.cardName.lyrathesunshard, 1);
            GangUpDatabase.Add(CardDB.cardName.maexxna, 3);
            GangUpDatabase.Add(CardDB.cardName.malganis, 4);
            GangUpDatabase.Add(CardDB.cardName.malkorok, 2);
            GangUpDatabase.Add(CardDB.cardName.malorne, 1);
            GangUpDatabase.Add(CardDB.cardName.malygos, 1);
            GangUpDatabase.Add(CardDB.cardName.manatidetotem, 0);
            GangUpDatabase.Add(CardDB.cardName.manawyrm, 0);
            GangUpDatabase.Add(CardDB.cardName.masterswordsmith, 1);
            GangUpDatabase.Add(CardDB.cardName.mechwarper, 1);
            GangUpDatabase.Add(CardDB.cardName.medivhtheguardian, 2);
            GangUpDatabase.Add(CardDB.cardName.mekgineerthermaplugg, 4);
            GangUpDatabase.Add(CardDB.cardName.micromachine, 1);
            GangUpDatabase.Add(CardDB.cardName.misha, 5);
            GangUpDatabase.Add(CardDB.cardName.moatlurker, 4);
            GangUpDatabase.Add(CardDB.cardName.moirabronzebeard, 5);
            GangUpDatabase.Add(CardDB.cardName.murlocknight, 5);
            GangUpDatabase.Add(CardDB.cardName.murloctidecaller, 1);
            GangUpDatabase.Add(CardDB.cardName.murlocwarleader, 1);
            GangUpDatabase.Add(CardDB.cardName.nefarian, 5);
            GangUpDatabase.Add(CardDB.cardName.nexuschampionsaraad, 5);
            GangUpDatabase.Add(CardDB.cardName.northshirecleric, 0);
            GangUpDatabase.Add(CardDB.cardName.obsidiandestroyer, 5);
            GangUpDatabase.Add(CardDB.cardName.oldmurkeye, 5);
            GangUpDatabase.Add(CardDB.cardName.onyxia, 4);
            GangUpDatabase.Add(CardDB.cardName.pilotedshredder, 3);
            GangUpDatabase.Add(CardDB.cardName.pintsizedsummoner, 1);
            GangUpDatabase.Add(CardDB.cardName.prophetvelen, 1);
            GangUpDatabase.Add(CardDB.cardName.pyros, 1);
            GangUpDatabase.Add(CardDB.cardName.questingadventurer, 1);
            GangUpDatabase.Add(CardDB.cardName.radiantelemental, 1);
            GangUpDatabase.Add(CardDB.cardName.ragnaroslightlord, 3);
            GangUpDatabase.Add(CardDB.cardName.ragnarosthefirelord, 5);
            GangUpDatabase.Add(CardDB.cardName.raidleader, 2);
            GangUpDatabase.Add(CardDB.cardName.ratpack, 2);
            GangUpDatabase.Add(CardDB.cardName.razorgore, 5);
            GangUpDatabase.Add(CardDB.cardName.recruiter, 5);
            GangUpDatabase.Add(CardDB.cardName.repairbot, 1);
            GangUpDatabase.Add(CardDB.cardName.satedthreshadon, 1);
            GangUpDatabase.Add(CardDB.cardName.savagecombatant, 5);
            GangUpDatabase.Add(CardDB.cardName.savannahhighmane, 5);
            GangUpDatabase.Add(CardDB.cardName.scalednightmare, 3);
            GangUpDatabase.Add(CardDB.cardName.scavenginghyena, 0);
            GangUpDatabase.Add(CardDB.cardName.shadeofnaxxramas, 3);
            GangUpDatabase.Add(CardDB.cardName.shadopanrider, 5);
            GangUpDatabase.Add(CardDB.cardName.shadowboxer, 0);
            GangUpDatabase.Add(CardDB.cardName.shadowfiend, 1);
            GangUpDatabase.Add(CardDB.cardName.shakuthecollector, 5);
            GangUpDatabase.Add(CardDB.cardName.shipscannon, 0);
            GangUpDatabase.Add(CardDB.cardName.siltfinspiritwalker, 0);
            GangUpDatabase.Add(CardDB.cardName.sludgebelcher, 5);
            GangUpDatabase.Add(CardDB.cardName.sneedsoldshredder, 5);
            GangUpDatabase.Add(CardDB.cardName.sorcerersapprentice, 1);
            GangUpDatabase.Add(CardDB.cardName.southseacaptain, 0);
            GangUpDatabase.Add(CardDB.cardName.starvingbuzzard, 0);
            GangUpDatabase.Add(CardDB.cardName.stonesplintertrogg, 0);
            GangUpDatabase.Add(CardDB.cardName.stormwindchampion, 4);
            GangUpDatabase.Add(CardDB.cardName.summoningportal, 5);
            GangUpDatabase.Add(CardDB.cardName.summoningstone, 5);
            GangUpDatabase.Add(CardDB.cardName.swashburglar, 2);
            GangUpDatabase.Add(CardDB.cardName.sylvanaswindrunner, 5);
            GangUpDatabase.Add(CardDB.cardName.theblackknight, 5);
            GangUpDatabase.Add(CardDB.cardName.theboogeymonster, 3);
            GangUpDatabase.Add(CardDB.cardName.timberwolf, 0);
            GangUpDatabase.Add(CardDB.cardName.tirionfordring, 5);
            GangUpDatabase.Add(CardDB.cardName.toshley, 4);
            GangUpDatabase.Add(CardDB.cardName.tradeprincegallywix, 3);
            GangUpDatabase.Add(CardDB.cardName.troggzortheearthinator, 1);
            GangUpDatabase.Add(CardDB.cardName.undercityhuckster, 2);
            GangUpDatabase.Add(CardDB.cardName.undertaker, 0);
            GangUpDatabase.Add(CardDB.cardName.unearthedraptor, 5);
            GangUpDatabase.Add(CardDB.cardName.usherofsouls, 1);
            GangUpDatabase.Add(CardDB.cardName.v07tr0n, 5);
            GangUpDatabase.Add(CardDB.cardName.vaelastrasz, 5);
            GangUpDatabase.Add(CardDB.cardName.viciousfledgling, 2);
            GangUpDatabase.Add(CardDB.cardName.violetillusionist, 5);
            GangUpDatabase.Add(CardDB.cardName.violetteacher, 0);
            GangUpDatabase.Add(CardDB.cardName.vitalitytotem, 1);
            GangUpDatabase.Add(CardDB.cardName.voljin, 5);
            GangUpDatabase.Add(CardDB.cardName.warsongcommander, 3);
            GangUpDatabase.Add(CardDB.cardName.weespellstopper, 0);
            GangUpDatabase.Add(CardDB.cardName.wickedwitchdoctor, 5);
            GangUpDatabase.Add(CardDB.cardName.wobblingrunts, 3);
            GangUpDatabase.Add(CardDB.cardName.xarilpoisonedmind, 3);
            GangUpDatabase.Add(CardDB.cardName.youngpriestess, 1);
            GangUpDatabase.Add(CardDB.cardName.ysera, 5);
            GangUpDatabase.Add(CardDB.cardName.yshaarjrageunbound, 5);
            GangUpDatabase.Add(CardDB.cardName.valkyrsoulclaimer, 0);
            GangUpDatabase.Add(CardDB.cardName.cryptlord, 4);
        }

        private void setupbuffHandDatabase()
        {
            buffHandDatabase.Add(CardDB.cardName.brassknuckles, 1);
            buffHandDatabase.Add(CardDB.cardName.donhancho, 5);
            buffHandDatabase.Add(CardDB.cardName.grimestreetenforcer, 1);
            buffHandDatabase.Add(CardDB.cardName.grimestreetoutfitter, 1);
            buffHandDatabase.Add(CardDB.cardName.grimestreetpawnbroker, 1);
            buffHandDatabase.Add(CardDB.cardName.grimestreetsmuggler, 1);
            buffHandDatabase.Add(CardDB.cardName.grimscalechum, 1);
            buffHandDatabase.Add(CardDB.cardName.grimygadgeteer, 2);
            buffHandDatabase.Add(CardDB.cardName.hiddencache, 2);
            buffHandDatabase.Add(CardDB.cardName.hobartgrapplehammer, 1);
            buffHandDatabase.Add(CardDB.cardName.shakyzipgunner, 2);
            buffHandDatabase.Add(CardDB.cardName.smugglerscrate, 2);
            buffHandDatabase.Add(CardDB.cardName.smugglersrun, 1);
            buffHandDatabase.Add(CardDB.cardName.stolengoods, 3);
            buffHandDatabase.Add(CardDB.cardName.themistcaller, 1);
            buffHandDatabase.Add(CardDB.cardName.troggbeastrager, 1);
        }

        private void setupequipWeaponPlayDatabase()
        {
            equipWeaponPlayDatabase.Add(CardDB.cardName.arathiweaponsmith, 2);
            equipWeaponPlayDatabase.Add(CardDB.cardName.blingtron3000, 3);
            equipWeaponPlayDatabase.Add(CardDB.cardName.daggermastery, 1);
            equipWeaponPlayDatabase.Add(CardDB.cardName.echolocate, 2);
            equipWeaponPlayDatabase.Add(CardDB.cardName.instructorrazuvious, 5);
            equipWeaponPlayDatabase.Add(CardDB.cardName.malkorok, 3);
            equipWeaponPlayDatabase.Add(CardDB.cardName.medivhtheguardian, 1);
            equipWeaponPlayDatabase.Add(CardDB.cardName.musterforbattle, 1);
            equipWeaponPlayDatabase.Add(CardDB.cardName.nzothsfirstmate, 1);
            equipWeaponPlayDatabase.Add(CardDB.cardName.poisoneddaggers, 2);
            equipWeaponPlayDatabase.Add(CardDB.cardName.upgrade, 1);
            equipWeaponPlayDatabase.Add(CardDB.cardName.visionsoftheassassin, 1);
            equipWeaponPlayDatabase.Add(CardDB.cardName.utheroftheebonblade, 5);
            equipWeaponPlayDatabase.Add(CardDB.cardName.scourgelordgarrosh, 4);
        }


    }

}