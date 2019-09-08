using System;
using System.Collections.Generic;
using SilverFish.Helpers;
using SilverFish.Enums;

namespace HREngine.Bots
{
    public partial class CardDB
    {
        public class Card
        {
            //public string CardID = "";
            public Bots.CardDB.CardName name = Bots.CardDB.CardName.unknown;
            public int race = 0;
            public int rarity = 0;
            public int cost = 0;
            public int Class = 0;
            public Bots.CardDB.CardType type = CardDB.CardType.NONE;
            //public string description = "";

            public int Attack = 0;
            public int Health = 0;
            public int Durability = 0;//for weapons
            public bool tank = false;
            public bool Silence = false;
            public bool choice = false;
            public bool windfury = false;
            public bool poisonous = false;
            public bool lifesteal = false;
            public bool deathrattle = false;
            public bool battlecry = false;
            public bool discover = false;
            public bool oneTurnEffect = false;
            public bool Enrage = false;
            public bool Aura = false;
            public bool Elite = false;
            public bool Combo = false;
            public int overload = 0;
            public bool immuneWhileAttacking = false;
            public bool untouchable = false;
            public bool Stealth = false;
            public bool Freeze = false;
            public bool AdjacentBuff = false;
            public bool Shield = false;
            public bool Charge = false;
            public bool Secret = false;
            public bool Quest = false;
            public bool Morph = false;
            public bool Spellpower = false;
            public bool Inspire = false;



            public int needEmptyPlacesForPlaying = 0;
            public int needWithMinAttackValueOf = 0;
            public int needWithMaxAttackValueOf = 0;
            public int needRaceForPlaying = 0;
            public int needMinNumberOfEnemy = 0;
            public int needMinTotalMinions = 0;
            public int needMinOwnMinions = 0;
            public int needMinionsCapIfAvailable = 0;
            public int needControlaSecret = 0;

            //additional data
            public bool isToken = false;
            public int isCarddraw = 0;
            public bool damagesTarget = false;
            public bool damagesTargetWithSpecial = false;
            public int targetPriority = 0;
            public bool isSpecialMinion = false;

            public int spellpowervalue = 0;
            public CardIdEnum cardIDenum = CardIdEnum.None;
            public List<ErrorType2> playrequires;

            public List<Bots.CardDB.CardTrigger> Triggers { get; set; }

            public SimTemplate CardSimulation
            {
                get
                {
                    return _cardSimulation;
                }
                set
                {
                    if (CardHelper.IsCardSimulationImplemented(value))
                    {
                        CardSimulationImplemented = true;
                    }
                    _cardSimulation = value;
                }
            }

            private SimTemplate _cardSimulation;

            public bool CardSimulationImplemented { get; set; }

            public Card()
            {
                playrequires = new List<Bots.CardDB.ErrorType2>();
            }

            public Card(Card c)
            {
                //this.entityID = c.entityID;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;
                this.discover = c.discover;
                //this.CardID = c.CardID;
                this.Charge = c.Charge;
                this.choice = c.choice;
                this.Combo = c.Combo;
                this.cost = c.cost;
                this.deathrattle = c.deathrattle;
                this.Inspire = c.Inspire;
                //this.description = c.description;
                this.Durability = c.Durability;
                this.Elite = c.Elite;
                this.Enrage = c.Enrage;
                this.Freeze = c.Freeze;
                this.Health = c.Health;
                this.immuneWhileAttacking = c.immuneWhileAttacking;
                this.untouchable = c.untouchable;
                this.Morph = c.Morph;
                this.name = c.name;
                this.needEmptyPlacesForPlaying = c.needEmptyPlacesForPlaying;
                this.needMinionsCapIfAvailable = c.needMinionsCapIfAvailable;
                this.needMinNumberOfEnemy = c.needMinNumberOfEnemy;
                this.needMinTotalMinions = c.needMinTotalMinions;
                this.needMinOwnMinions = c.needMinOwnMinions;
                this.needRaceForPlaying = c.needRaceForPlaying;
                this.needControlaSecret = c.needControlaSecret;
                this.needWithMaxAttackValueOf = c.needWithMaxAttackValueOf;
                this.needWithMinAttackValueOf = c.needWithMinAttackValueOf;
                this.oneTurnEffect = c.oneTurnEffect;
                this.playrequires = new List<Bots.CardDB.ErrorType2>(c.playrequires);
                this.poisonous = c.poisonous;
                this.lifesteal = c.lifesteal;
                this.race = c.race;
                this.overload = c.overload;
                this.Secret = c.Secret;
                this.Quest = c.Quest;
                this.Shield = c.Shield;
                this.Silence = c.Silence;
                this.Spellpower = c.Spellpower;
                this.spellpowervalue = c.spellpowervalue;
                this.Stealth = c.Stealth;
                this.tank = c.tank;
                this.type = c.type;
                this.windfury = c.windfury;
                this.cardIDenum = c.cardIDenum;
                this.CardSimulation = c.CardSimulation;
                this.isToken = c.isToken;
            }

            public bool isRequirementInList(CardDB.ErrorType2 et)
            {
                return this.playrequires.Contains(et);
            }

            public List<Minion> getTargetsForCard(Playfield p, bool isLethalCheck, bool own)
            {
                //if wereTargets=true and 0 targets at end -> then can not play this card
                List<Minion> retval = new List<Minion>();
                if (this.type == CardDB.CardType.MOB && ((own && p.ownMinions.Count >= 7) || (!own && p.enemyMinions.Count >= 7))) return retval; // cant play mob, if we have allready 7 mininos
                if (this.Secret && ((own && (p.ownSecretsIDList.Contains(this.cardIDenum) || p.ownSecretsIDList.Count >= 5)) || (!own && p.enemySecretCount >= 5))) return retval;
                //if (p.mana < this.getManaCost(p, 1)) return retval;

                if (this.playrequires.Count == 0) { retval.Add(null); return retval; }

                List<Minion> targets = new List<Minion>();
                bool targetAll = false;
                bool targetAllEnemy = false;
                bool targetAllFriendly = false;
                bool targetEnemyHero = false;
                bool targetOwnHero = false;
                bool targetOnlyMinion = false;
                bool extraParam = false;
                bool wereTargets = false;
                bool REQ_UNDAMAGED_TARGET = false;
                bool REQ_TARGET_WITH_DEATHRATTLE = false;
                bool REQ_TARGET_WITH_RACE = false;
                bool REQ_TARGET_MIN_ATTACK = false;
                bool REQ_TARGET_MAX_ATTACK = false;
                bool REQ_MUST_TARGET_TAUNTER = false;
                bool REQ_STEADY_SHOT = false;
                bool REQ_FROZEN_TARGET = false;
                bool REQ_HERO_TARGET = false;
                bool REQ_DAMAGED_TARGET = false;
                bool REQ_LEGENDARY_TARGET = false;
                bool REQ_TARGET_IF_AVAILABLE = false;
                bool REQ_STEALTHED_TARGET = false;
                bool REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = false;

                foreach (CardDB.ErrorType2 PlayReq in this.playrequires)
                {
                    switch (PlayReq)
                    {
                        case Bots.CardDB.ErrorType2.REQ_TARGET_TO_PLAY:
                            targetAll = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MINION_TARGET:
                            targetOnlyMinion = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE:
                            REQ_TARGET_IF_AVAILABLE = true;
                            targetAll = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_FRIENDLY_TARGET:
                            if (own) targetAllFriendly = true;
                            else targetAllEnemy = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_NUM_MINION_SLOTS:
                            if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needEmptyPlacesForPlaying) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT:
                            if (own) { if (p.ownMinions.Count > 6 & p.ownMaxMana > 9) return retval; }
                            else if (p.enemyMinions.Count > 6 & p.enemyMaxMana > 9) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_ENEMY_TARGET:
                            if (own) targetAllEnemy = true;
                            else targetAllFriendly = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_HERO_TARGET:
                            REQ_HERO_TARGET = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MINIMUM_ENEMY_MINIONS:
                            if ((own ? p.enemyMinions.Count : p.ownMinions.Count) < this.needMinNumberOfEnemy) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_NONSELF_TARGET:
                            targetAll = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_WITH_RACE:
                            REQ_TARGET_WITH_RACE = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_DAMAGED_TARGET:
                            REQ_DAMAGED_TARGET = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK:
                            REQ_TARGET_MAX_ATTACK = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_WEAPON_EQUIPPED:
                            if ((own ? p.ownWeapon.Durability : p.enemyWeapon.Durability) == 0) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_FOR_COMBO:
                            if (p.cardsPlayedThisTurn >= 1) targetAll = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK:
                            REQ_TARGET_MIN_ATTACK = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MINIMUM_TOTAL_MINIONS:
                            if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE:
                            if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needMinionsCapIfAvailable) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY:
                            int difftotem = 0;
                            foreach (Minion m in (own ? p.ownMinions : p.enemyMinions))
                            {
                                if (m.name == CardDB.CardName.healingtotem || m.name == CardDB.CardName.wrathofairtotem || m.name == CardDB.CardName.searingtotem || m.name == CardDB.CardName.stoneclawtotem) difftotem++;
                            }
                            if (difftotem == 4) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER:
                            REQ_MUST_TARGET_TAUNTER = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND:
                            if (own)
                            {
                                foreach (Handmanager.Handcard hc in p.owncards)
                                {
                                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) { targetAll = true; break; }
                                }
                            }
                            else targetAll = true; // apriori the enemy have a dragon
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_LEGENDARY_TARGET:
                            REQ_LEGENDARY_TARGET = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_UNDAMAGED_TARGET:
                            REQ_UNDAMAGED_TARGET = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_WITH_DEATHRATTLE:
                            REQ_TARGET_WITH_DEATHRATTLE = true;
                            targetOnlyMinion = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN:
                            REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_STEADY_SHOT:
                            REQ_STEADY_SHOT = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_FROZEN_TARGET:
                            REQ_FROZEN_TARGET = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MINION_OR_ENEMY_HERO:
                            REQ_STEADY_SHOT = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_STEALTHED_TARGET:
                            REQ_STEALTHED_TARGET = true;
                            extraParam = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_ENEMY_WEAPON_EQUIPPED:
                            if (own)
                            {
                                if (p.enemyWeapon.Durability > 0) targetEnemyHero = true;
                                else return retval;
                            }
                            else
                            {
                                if (p.ownWeapon.Durability > 0) targetOwnHero = true;
                                else return retval;
                            }
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS:
                            int tmp = (own) ? p.ownMinions.Count : p.enemyMinions.Count;
                            if (tmp >= needMinOwnMinions) targetAll = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS:
                            if (p.ownSecretsIDList.Count >= needControlaSecret) targetAll = true;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_MUST_PLAY_OTHER_CARD_FIRST:
                            if (p.cardsPlayedThisTurn == 0) return retval;
                            continue;
                        case Bots.CardDB.ErrorType2.REQ_HAND_NOT_FULL:
                            if (p.owncards.Count == 10) return retval;
                            continue;

                            //default:
                    }
                }

                if (targetAll)
                {
                    wereTargets = true;
                    if (targetAllFriendly != targetAllEnemy)
                    {
                        if (targetAllFriendly)
                        {
                            foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                        }
                        else
                        {
                            foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                        }
                    }
                    else
                    {
                        foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                        foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                    }
                    if (targetOnlyMinion)
                    {
                        targetEnemyHero = false;
                        targetOwnHero = false;
                    }
                    else
                    {
                        if (!p.enemyHero.immune) targetEnemyHero = true;
                        if (!p.ownHero.immune) targetOwnHero = true;
                        if (targetAllEnemy) targetOwnHero = false;
                        if (targetAllFriendly) targetEnemyHero = false;
                    }
                }

                if (extraParam)
                {
                    wereTargets = true;
                    if (REQ_TARGET_WITH_RACE)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.handcard.card.race != this.needRaceForPlaying) m.extraParam = true;
                        }
                        targetOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                        targetEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    }
                    if (REQ_HERO_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            m.extraParam = true;
                        }
                        targetOwnHero = true;
                        targetEnemyHero = true;
                    }
                    if (REQ_DAMAGED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.wounded)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_MAX_ATTACK)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.Attack > this.needWithMaxAttackValueOf)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_MIN_ATTACK)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.Attack < this.needWithMinAttackValueOf)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_MUST_TARGET_TAUNTER)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.taunt)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_UNDAMAGED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.wounded)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_STEALTHED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.stealth)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_WITH_DEATHRATTLE)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.silenced && (m.handcard.card.deathrattle || m.deathrattle2 != null ||
                            m.ancestralspirit + m.desperatestand + m.souloftheforest + m.stegodon + m.livingspores + m.explorershat + m.returnToHand + m.infest > 0)) continue;
                            else m.extraParam = true;
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN)
                    {
                        if (p.anzOwnElementalsLastTurn < 1)
                        {
                            foreach (Minion m in targets) m.extraParam = true;
                            targetOwnHero = false;
                            targetEnemyHero = false;
                        }
                    }
                    if (REQ_LEGENDARY_TARGET)
                    {
                        wereTargets = false;
                        foreach (Minion m in targets)
                        {
                            if (m.handcard.card.rarity != 5) m.extraParam = true;
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_STEADY_SHOT)
                    {
                        if ((p.weHaveSteamwheedleSniper && own) || (p.enemyHaveSteamwheedleSniper && !own))
                        {
                            foreach (Minion m in targets)
                            {
                                if (m.cantBeTargetedBySpellsOrHeroPowers && (this.type == Bots.CardDB.CardType.HEROPWR || this.type == Bots.CardDB.CardType.SPELL))
                                {
                                    m.extraParam = true;
                                    if (m.stealth && !m.own) m.extraParam = true;
                                }
                            }
                            if (own) targetEnemyHero = true;
                            else targetOwnHero = true;
                        }
                        else wereTargets = false;
                    }
                    if (REQ_FROZEN_TARGET)
                    {

                        foreach (Minion m in targets)
                        {
                            if (!m.frozen) m.extraParam = true;
                        }
                    }
                }

                if (targetEnemyHero && own && p.enemyHero.stealth) targetEnemyHero = false;
                if (targetOwnHero && !own && p.ownHero.stealth) targetOwnHero = false;

                if (isLethalCheck)
                {
                    if (targetEnemyHero && own) retval.Add(p.enemyHero);
                    else if (targetOwnHero && !own) retval.Add(p.ownHero);

                    switch (this.type)
                    {
                        case Bots.CardDB.CardType.SPELL:
                            if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                            {
                                if (targetOwnHero && own) retval.Add(p.ownHero);
                                foreach (Minion m in targets)
                                {
                                    if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                    {
                                        if (m.own)
                                        {
                                            if (m.Ready) retval.Add(m);
                                        }
                                        else if (m.taunt) retval.Add(m);
                                    }
                                    m.extraParam = false;
                                }
                            }
                            else
                            {
                                switch (this.name)
                                {
                                    case Bots.CardDB.CardName.polymorphboar:
                                        foreach (Minion m in targets)
                                        {
                                            m.extraParam = false;
                                            if (m.cantBeTargetedBySpellsOrHeroPowers) continue;
                                            if (m.own) retval.Add(m);
                                            else if (m.taunt) retval.Add(m);
                                        }
                                        break;
                                    case Bots.CardDB.CardName.hex: goto case Bots.CardDB.CardName.polymorph;
                                    case Bots.CardDB.CardName.polymorph:
                                        foreach (Minion m in targets)
                                        {
                                            m.extraParam = false;
                                            if (!m.own && m.taunt && !m.cantBeTargetedBySpellsOrHeroPowers) retval.Add(m);
                                        }
                                        break;
                                }
                            }
                            break;
                        case Bots.CardDB.CardType.MOB:
                            foreach (Minion m in targets)
                            {
                                if (m.extraParam != true)
                                {
                                    if (m.stealth && !m.own) continue;
                                    retval.Add(m);
                                }
                                m.extraParam = false;
                            }
                            break;
                        case Bots.CardDB.CardType.HEROPWR:
                            if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                            {
                                foreach (Minion m in targets)
                                {
                                    if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                    {
                                        if (m.own)
                                        {
                                            if (m.Ready) retval.Add(m);
                                        }
                                        else if (m.taunt) retval.Add(m);
                                    }
                                    m.extraParam = false;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    if (targetEnemyHero) retval.Add(p.enemyHero);
                    if (targetOwnHero) retval.Add(p.ownHero);

                    foreach (Minion m in targets)
                    {
                        if (m.extraParam != true)
                        {
                            if (m.stealth && !m.own) continue;
                            if (m.cantBeTargetedBySpellsOrHeroPowers && (this.type == Bots.CardDB.CardType.SPELL || this.type == Bots.CardDB.CardType.HEROPWR)) continue;
                            retval.Add(m);
                        }
                        m.extraParam = false;
                    }
                }

                if (retval.Count == 0 && (!wereTargets || REQ_TARGET_IF_AVAILABLE)) retval.Add(null);

                return retval;
            }


            public List<Minion> getTargetsForHeroPower(Playfield p, bool own)
            {
                List<Minion> trgts = getTargetsForCard(p, p.isLethalCheck, own);
                Bots.CardDB.CardName abName = own ? p.ownHeroAblility.card.name : p.enemyHeroAblility.card.name;
                int abType = 0; //0 none, 1 damage, 2 heal, 3 baff
                switch (abName)
                {
                    case Bots.CardDB.CardName.heal: goto case Bots.CardDB.CardName.lesserheal;
                    case Bots.CardDB.CardName.lesserheal:
                        if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0) abType = 1;
                        else abType = 2;
                        break;
                    case Bots.CardDB.CardName.ballistashot: abType = 1; break;
                    case Bots.CardDB.CardName.steadyshot: abType = 1; break;
                    case Bots.CardDB.CardName.fireblast: abType = 1; break;
                    case Bots.CardDB.CardName.fireblastrank2: abType = 1; break;
                    case Bots.CardDB.CardName.lightningjolt: abType = 1; break;
                    case Bots.CardDB.CardName.mindspike: abType = 1; break;
                    case Bots.CardDB.CardName.mindshatter: abType = 1; break;
                    case Bots.CardDB.CardName.powerofthefirelord: abType = 1; break;
                    case Bots.CardDB.CardName.shotgunblast: abType = 1; break;
                    case Bots.CardDB.CardName.unbalancingstrike: abType = 1; break;
                    case Bots.CardDB.CardName.dinomancy: abType = 3; break;
                }

                switch (abType)
                {
                    case 2:
                        List<Minion> minions = own ? p.ownMinions : p.enemyMinions;
                        int tCount = minions.Count;
                        bool needCut = true;
                        for (int i = 0; i < tCount; i++)
                        {
                            switch (minions[i].name)
                            {
                                case Bots.CardDB.CardName.shadowboxer:
                                    if (own && p.enemyHero.HealthPoints == 1 && p.enemyMinions.Count > 0) needCut = false;
                                    break;
                                case Bots.CardDB.CardName.holychampion: needCut = false; break;
                                case Bots.CardDB.CardName.lightwarden: needCut = false; break;
                                case Bots.CardDB.CardName.northshirecleric: needCut = false; break;


                            }
                        }

                        tCount = trgts.Count;
                        if (tCount > 0)
                        {
                            if (trgts[0] != null)
                            {
                                List<Minion> tmp = new List<Minion>();
                                for (int i = 0; i < tCount; i++)
                                {
                                    Minion m = trgts[i];
                                    if (m.HealthPoints < m.maxHp)
                                    {
                                        if (needCut)
                                        {
                                            if (m.own == own) tmp.Add(m);
                                        }
                                        else tmp.Add(m);
                                    }
                                }
                                return tmp;
                            }
                        }
                        break;
                }
                return trgts;
            }

            public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects and new draw
            {
                int retval = this.cost;
                int offset = 0;

                if (p.anzOwnShadowfiend > 0) offset -= p.anzOwnShadowfiend;

                switch (this.type)
                {
                    case Bots.CardDB.CardType.MOB:
                        if (p.anzOwnAviana > 0) retval = 1;

                        offset += p.ownMinionsCostMore;

                        if (this.deathrattle) offset += p.ownDRcardsCostMore;

                        offset += p.managespenst;

                        int temp = -(p.startedWithbeschwoerungsportal) * 2;
                        if (retval + temp <= 0) temp = -retval + 1;
                        offset = offset + temp;

                        if (p.mobsplayedThisTurn == 0)
                        {
                            offset -= p.winzigebeschwoererin;
                        }

                        if (this.battlecry)
                        {
                            offset += p.nerubarweblord * 2;
                        }

                        if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        { //if the number of zauberlehrlings change
                            offset -= p.anzOwnMechwarper;
                        }
                        break;
                    case Bots.CardDB.CardType.SPELL:
                        if (p.nextSpellThisTurnCost0) return 0;
                        offset += p.ownSpelsCostMore;
                        if (p.playedPreparation)
                        { //if the number of zauberlehrlings change
                            offset -= 3;
                        }
                        break;
                    case Bots.CardDB.CardType.WEAPON:
                        offset -= p.blackwaterpirate * 2;
                        if (this.deathrattle) offset += p.ownDRcardsCostMore;
                        break;
                }

                offset -= p.myCardsCostLess;

                switch (this.name)
                {
                    case CardDB.CardName.happyghoul:
                        if (p.ownHero.anzGotHealed > 0) retval = offset;
                        break;
                    case CardDB.CardName.wildmagic:
                        retval = offset;
                        break;
                    case CardDB.CardName.dreadcorsair:
                        retval = retval + offset - p.ownWeapon.Angr;
                        break;
                    case CardDB.CardName.volcanicdrake:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.CardName.knightofthewild:
                        retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                        break;
                    case CardDB.CardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case CardDB.CardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case CardDB.CardName.clockworkgiant:
                        retval = retval + offset - p.enemyAnzCards;
                        break;
                    case CardDB.CardName.moltengiant:
                        retval = retval + offset - p.ownHero.maxHp + p.ownHero.HealthPoints;
                        break;
                    case CardDB.CardName.frostgiant:
                        retval = retval + offset - p.anzUsedOwnHeroPower;
                        break;
                    case CardDB.CardName.arcanegiant:
                        retval = retval + offset - p.spellsplayedSinceRecalc;
                        break;
                    case CardDB.CardName.snowfurygiant:
                        retval = retval + offset - p.ueberladung;
                        break;
                    case CardDB.CardName.kabalcrystalrunner:
                        retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                        break;
                    case CardDB.CardName.secondratebruiser:
                        retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2);
                        break;
                    case CardDB.CardName.golemagg:
                        retval = retval + offset - p.ownHero.maxHp + p.ownHero.HealthPoints;
                        break;
                    case CardDB.CardName.volcaniclumberer:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.CardName.skycapnkragg:
                        int costBonus = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) costBonus++;
                        }
                        retval = retval + offset - costBonus;
                        break;
                    case CardDB.CardName.everyfinisawesome:
                        int costBonusM = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) costBonusM++;
                        }
                        retval = retval + offset - costBonusM;
                        break;
                    case CardDB.CardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions)
                        {
                            retval = retval + offset - 4;
                        }
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret)
                {
                    if (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0) retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public int getManaCost(Playfield p, int currentcost)
            {
                int retval = currentcost;

                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase/decrease the manacosts of others ##############################
                switch (this.type)
                {
                    case Bots.CardDB.CardType.HEROPWR:
                        retval += p.ownHeroPowerCostLessOnce;
                        if (retval < 0) retval = 0;
                        return retval;
                    case Bots.CardDB.CardType.MOB:

                        if (p.ownMinionsCostMore != p.ownMinionsCostMoreAtStart)
                        {
                            offset += (p.ownMinionsCostMore - p.ownMinionsCostMoreAtStart);
                        }


                        if (this.deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                        {
                            offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                        }


                        if (p.managespenst != p.startedWithManagespenst)
                        {
                            offset += (p.managespenst - p.startedWithManagespenst);
                        }


                        if (this.battlecry && p.nerubarweblord != p.startedWithnerubarweblord)
                        {
                            offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                        }


                        if (p.anzOwnAviana > 0)
                        {
                            retval = 1;
                        }


                        if (p.anzOwnMechwarper != p.anzOwnMechwarperStarted && (TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        {
                            offset += (p.anzOwnMechwarperStarted - p.anzOwnMechwarper);
                        }


                        if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal)
                        {
                            offset += (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                        }


                        if (p.winzigebeschwoererin != p.startedWithWinzigebeschwoererin && ((p.turnCounter == 0 && p.startedWithMobsPlayedThisTurn == 0) || (p.turnCounter > 0 && p.mobsplayedThisTurn == 0)))
                        {
                            offset += (p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin);
                        }


                        if (p.anzOwnDragonConsort != p.anzOwnDragonConsortStarted && (TAG_RACE)this.race == TAG_RACE.DRAGON)
                        {
                            offset += (p.anzOwnDragonConsortStarted - p.anzOwnDragonConsort) * 2;
                        }
                        break;
                    case Bots.CardDB.CardType.SPELL:

                        if (p.nextSpellThisTurnCost0) return 0;


                        if (p.ownSpelsCostMoreAtStart != p.ownSpelsCostMore)
                        {
                            offset += p.ownSpelsCostMore - p.ownSpelsCostMoreAtStart;
                        }


                        if (p.playedPreparation)
                        {
                            offset -= 3;
                        }
                        break;
                    case Bots.CardDB.CardType.WEAPON:

                        if (p.blackwaterpirateStarted != p.blackwaterpirate)
                        {
                            offset += (p.blackwaterpirateStarted - p.blackwaterpirate) * 2;
                        }

                        if (this.deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                        {
                            offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                        }
                        break;
                }


                if (p.startedWithmyCardsCostLess != p.myCardsCostLess)
                {
                    offset += p.startedWithmyCardsCostLess - p.myCardsCostLess;
                }

                switch (this.name)
                {
                    case CardDB.CardName.volcaniclumberer:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.CardName.solemnvigil:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.CardName.volcanicdrake:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.CardName.knightofthewild:
                        retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                        break;
                    case CardDB.CardName.dragonsbreath:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.CardName.dreadcorsair:
                        retval = retval + offset - p.ownWeapon.Angr + p.ownWeaponAttackStarted; // if weapon attack change we change manacost
                        break;
                    case CardDB.CardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted + p.enemyMobsCountStarted;
                        break;
                    case CardDB.CardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case CardDB.CardName.clockworkgiant:
                        retval = retval + offset - p.enemyAnzCards + p.enemyCardsCountStarted;
                        break;
                    case CardDB.CardName.moltengiant:
                        retval = retval + offset - p.ownHeroHpStarted + p.ownHero.HealthPoints;
                        break;
                    case CardDB.CardName.frostgiant:
                        retval = retval + offset - p.anzUsedOwnHeroPower;
                        break;
                    case CardDB.CardName.arcanegiant:
                        retval = retval + offset - p.spellsplayedSinceRecalc;
                        break;
                    case CardDB.CardName.snowfurygiant:
                        retval = retval + offset - p.ueberladung;
                        break;
                    case CardDB.CardName.kabalcrystalrunner:
                        retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                        break;
                    case CardDB.CardName.secondratebruiser:
                        retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2) + ((p.enemyMobsCountStarted < 3) ? 0 : 2);
                        break;
                    case CardDB.CardName.golemagg:
                        retval = retval + offset - p.ownHeroHpStarted + p.ownHero.HealthPoints;
                        break;
                    case CardDB.CardName.skycapnkragg:
                        int costBonus = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) costBonus++;
                        }
                        retval = retval + offset - costBonus + p.anzOwnPiratesStarted;
                        break;
                    case CardDB.CardName.everyfinisawesome:
                        int costBonusM = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) costBonusM++;
                        }
                        retval = retval + offset - costBonusM + p.anzOwnMurlocStarted;
                        break;
                    case CardDB.CardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions != p.startedWithDamagedMinions)
                        {
                            if (dmgedminions)
                            {
                                retval = retval + offset - 4;
                            }
                            else
                            {
                                retval = retval + offset + 4;
                            }
                        }
                        break;
                    case CardDB.CardName.happyghoul:
                        if (p.ownHero.anzGotHealed > 0) retval = 0;
                        break;
                    case CardDB.CardName.wildmagic:
                        retval = 0;
                        break;
                    case CardDB.CardName.thingfrombelow:
                        if (p.playactions.Count > 0)
                        {
                            foreach (Action a in p.playactions)
                            {
                                if (a.actionType == actionEnum.playcard)
                                {
                                    switch (a.card.card.name)
                                    {
                                        case Bots.CardDB.CardName.tuskarrtotemic: retval -= p.ownBrannBronzebeard + 1; break;
                                        default:
                                            if ((TAG_RACE)a.card.card.race == TAG_RACE.TOTEM) retval--;
                                            break;
                                    }
                                }
                                else if (a.actionType == actionEnum.useHeroPower)
                                {
                                    switch (a.card.card.name)
                                    {
                                        case Bots.CardDB.CardName.totemiccall: retval--; break;
                                        case Bots.CardDB.CardName.totemicslam: retval--; break;
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0))
                {
                    retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public bool canplayCard(Playfield p, int manacost, bool own)
            {
                if (p.mana < this.getManaCost(p, manacost)) return false;
                if (this.getTargetsForCard(p, false, own).Count == 0) return false;
                return true;
            }

        }

    }
}
