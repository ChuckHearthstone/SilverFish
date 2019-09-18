using System.Collections.Generic;
using SilverFish.Enums;

namespace Chuck.SilverFish
{

    public class BehaviorControl : Behavior
    {
        public override string BehaviorName() { return "Control"; }


        PenaltyManager penman = PenaltyManager.Instance;

        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value >= -2000000)
            {
                return p.value;
            }
            int resultValue = 0;
            int healthPointsBoarder = 10;
            if (p.ownHeroName == HeroEnum.warlock && p.enemyHeroName != HeroEnum.mage)
            {
                healthPointsBoarder = 6;
            }
            int attackBoarder = 11;

            resultValue -= p.evaluatePenality;
            resultValue += p.owncards.Count * 5;
            resultValue += p.ownQuest.questProgress * 10;

            resultValue += p.ownMaxMana;
            resultValue -= p.enemyMaxMana;

            resultValue += p.ownMaxMana * 20 - p.enemyMaxMana * 20;
            resultValue += (p.enemyHeroAblility.manacost - p.ownHeroAblility.manacost) * 4;
            if (p.ownHeroPowerAllowedQuantity != p.enemyHeroPowerAllowedQuantity)
            {
                if (p.ownHeroPowerAllowedQuantity > p.enemyHeroPowerAllowedQuantity)
                {
                    resultValue += 3;
                }
                else
                {
                    resultValue -= 3;
                }
            }

            if (p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.druid)
            {
                resultValue -= 2 * p.enemyspellpower;
            }

            if (p.ownHero.HealthPoints + p.ownHero.armor > healthPointsBoarder)
            {
                resultValue += p.ownHero.HealthPoints + p.ownHero.armor;
            }
            else
            {
                if (p.nextTurnWin())
                {
                    resultValue -= (healthPointsBoarder + 1 - p.ownHero.HealthPoints - p.ownHero.armor);
                }
                else
                {
                    resultValue -= 2 * (healthPointsBoarder + 1 - p.ownHero.HealthPoints - p.ownHero.armor) * (healthPointsBoarder + 1 - p.ownHero.HealthPoints - p.ownHero.armor);
                }
            }

            if (p.enemyHero.HealthPoints + p.enemyHero.armor > attackBoarder)
            {
                resultValue += -p.enemyHero.HealthPoints - p.enemyHero.armor;
            }
            else
            {
                resultValue += 4 * (attackBoarder + 1 - p.enemyHero.HealthPoints - p.enemyHero.armor);
            }

            if (p.ownWeapon.Angr > 0)
            {
                if (p.ownWeapon.Angr > 1)
                {
                    resultValue += p.ownWeapon.Angr * p.ownWeapon.Durability;
                }
                else
                {
                    resultValue += p.ownWeapon.Angr * p.ownWeapon.Durability + 1;
                }
            }

            if (!p.enemyHero.frozen)
            {
                resultValue -= p.enemyWeapon.Durability * p.enemyWeapon.Angr;
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    resultValue += 12;
                }
            }

            //RR card draw value depending on the turn and distance to lethal
            //RR if lethal is close, carddraw value is increased
            if (p.lethalMissing() <= 5) //RR
            {
                resultValue += p.owncarddraw * 100;
            }
            if (p.ownMaxMana < 4)
            {
                resultValue += p.owncarddraw * 2;
            }
            else
            {
                resultValue += p.owncarddraw * 5;
            }

            if (p.owncarddraw + 1 >= p.enemycarddraw)
            {
                resultValue -= p.enemycarddraw * 7;
            }
            else
            {
                resultValue -= (p.owncarddraw + 1) * 7 + (p.enemycarddraw - p.owncarddraw - 1) * 12;
            }

            //int owntaunt = 0;
            int readycount = 0;
            int ownMinionsCount = 0;
            foreach (Minion m in p.ownMinions)
            {
                resultValue += 5;
                resultValue += m.HealthPoints * 2;
                resultValue += m.Attack * 2;
                resultValue += m.handcard.card.rarity;
                if (!m.playedThisTurn && m.windfury)
                {
                    resultValue += m.Attack;
                }

                if (m.DivineShield)
                {
                    resultValue += 1;
                }

                if (m.stealth)
                {
                    resultValue += 1;
                }
                if (m.handcard.card.isSpecialMinion && !m.silenced)
                {
                    resultValue += 1;
                    if (!m.taunt && m.stealth)
                    {
                        resultValue += 20;
                    }
                }
                else
                {
                    if (m.Attack <= 2 && m.HealthPoints <= 2 && !m.DivineShield) resultValue -= 5;
                }
                //if (!m.taunt && m.stealth && penman.specialMinions.ContainsKey(m.name)) retval += 20;
                //if (m.poisonous) retval += 1;
                if (m.lifesteal)
                {
                    resultValue += m.Attack/2;
                }

                if (m.DivineShield && m.taunt)
                {
                    resultValue += 4;
                }
                //if (m.taunt && m.handcard.card.name == CardName.frog) owntaunt++;
                //if (m.handcard.card.isToken && m.Angr <= 2 && m.Hp <= 2) retval -= 5;
                //if (!penman.specialMinions.ContainsKey(m.name) && m.Angr <= 2 && m.Hp <= 2) retval -= 5;
                if (p.ownMinions.Count > 2
                    && (m.handcard.card.name == CardName.direwolfalpha
                        || m.handcard.card.name == CardName.flametonguetotem
                        || m.handcard.card.name == CardName.stormwindchampion
                        || m.handcard.card.name == CardName.raidleader))
                {
                    resultValue += 10;
                }

                if (m.handcard.card.name == CardName.bloodmagethalnos)
                {
                    resultValue += 10;
                }
                if (m.handcard.card.name == CardName.nerubianegg)
                {
                    if (m.Attack >= 1)
                    {
                        resultValue += 2;
                    }

                    if (!m.taunt && m.Attack == 0
                        && (m.DivineShield 
                            || m.maxHp > 2))
                    {
                        resultValue -= 10;
                    }
                }

                if (m.Ready)
                {
                    readycount++;
                }

                if (m.HealthPoints <= 4
                    && (m.Attack > 2
                        || m.HealthPoints > 3))
                {
                    ownMinionsCount++;
                }
                resultValue += m.synergy;
            }
            resultValue += p.anzOgOwnCThunAngrBonus;
            resultValue += p.anzOwnExtraAngrHp - p.anzEnemyExtraAngrHp;

            /*if (p.enemyMinions.Count >= 0)
            {
                int anz = p.enemyMinions.Count;
                if (owntaunt == 0) retval -= 10 * anz;
                retval += owntaunt * 10 - 11 * anz;
            }*/


            bool useAbili = false;
            int usecoin = 0;
            //soulfire etc
            int deletecardsAtLast = 0;
            int wasCombo = 0;
            bool firstSpellToEnHero = false;
            int count = p.playactions.Count;
            int ownActCount = 0;
            for (int i = 0; i < count; i++)
            {
                Action a = p.playactions[i];
                ownActCount++;
                switch (a.actionType)
                {
                    case actionEnum.attackWithHero:
                        if (p.enemyHero.HealthPoints <= p.attackFaceHP)
                        {
                            resultValue++;
                        }

                        if (p.ownHeroName == HeroEnum.warrior && useAbili)
                        {
                            resultValue -= 1;
                        }
                        continue;
                    case actionEnum.useHeroPower:
                        useAbili = true;
                        continue;
                    case actionEnum.playcard:
                        break;
                    default:
                        continue;
                }
                switch (a.card.card.name)
                {
                    case CardName.innervate:
                    case CardName.thecoin:
                        usecoin++;
                        if (i == count - 1)
                        {
                            resultValue -= 10;
                        }
                        goto default;
                    case CardName.darkshirelibrarian:
                        goto case CardName.soulfire;
                    case CardName.darkbargain:
                        goto case CardName.soulfire;
                    case CardName.doomguard:
                        goto case CardName.soulfire;
                    case CardName.succubus:
                        goto case CardName.soulfire;
                    case CardName.soulfire:
                        deletecardsAtLast = 1;
                        break;
                    default:
                        if (deletecardsAtLast == 1)
                        {
                            resultValue -= 20;
                        }
                        break;
                }

                if (a.card.card.Combo && i > 0)
                {
                    wasCombo++;
                }

                if (a.target == null)
                {
                    continue;
                }
                //save spell for all classes
                if (a.card.card.type == CardType.SPELL 
                    && a.target.isHero 
                    && !a.target.own)
                {
                    if (i == 0)
                    {
                        firstSpellToEnHero = true;
                    }
                    resultValue -= 11;
                }
            }
            if (wasCombo > 0 && firstSpellToEnHero)
            {
                if (wasCombo + 1 == ownActCount)
                {
                    resultValue += 10;
                }
            }
            if (usecoin > 0)
            {
                if (useAbili && p.ownMaxMana <= 2)
                {
                    resultValue -= 40;
                }
                resultValue -= 5 * p.manaTurnEnd;
                if (p.manaTurnEnd + usecoin > 10)
                {
                    resultValue -= 5 * usecoin;
                }
            }
            if (p.manaTurnEnd >= 2 && !useAbili && p.ownAbilityReady)
            {
                switch (p.ownHeroAblility.card.name)
                {
                    case CardName.heal: goto case CardName.lesserheal;
                    case CardName.lesserheal:
                        bool wereTarget = p.ownHero.HealthPoints < p.ownHero.maxHp;
                        if (!wereTarget)
                        {
                            foreach (Minion m in p.ownMinions)
                            {
                                if (m.wounded) { wereTarget = true; break;}
                            }
                        }
                        if (wereTarget && !(p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0)) resultValue -= 10;
                        break;
                    case CardName.poisoneddaggers: goto case CardName.daggermastery;
                    case CardName.daggermastery:
                         if (!(p.ownWeapon.Durability > 1 || p.ownWeapon.Angr > 1)) resultValue -= 10;
                         break;
                    case CardName.totemicslam: goto case CardName.totemiccall;
                    case CardName.totemiccall:
                        if (p.ownMinions.Count < 7) resultValue -= 10;
                        else resultValue -= 3;
                        break;
                    case CardName.thetidalhand: goto case CardName.reinforce;
                    case CardName.thesilverhand: goto case CardName.reinforce;
                    case CardName.reinforce:
                        if (p.ownMinions.Count < 7) resultValue -= 10;
                        else resultValue -= 3;
                        break;
                    case CardName.soultap: 
                        if (p.owncards.Count < 10 && p.ownDeckSize > 0) resultValue -= 10;
                        break;
                    case CardName.lifetap: 
                        if (p.owncards.Count < 10 && p.ownDeckSize > 0)
                        {
                            resultValue -= 10;
                            if (p.ownHero.immune) resultValue-= 5;
                        }
                        break;
                    default:
                        resultValue -= 10;
                        break;
                }
            }
            //if (usecoin && p.mana >= 1) retval -= 20;

            int mobsInHand = 0;
            int bigMobsInHand = 0;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == CardType.Minion)
                {
                    mobsInHand++;
                    if (hc.card.Attack + hc.addattack >= 3) bigMobsInHand++;
                    resultValue += hc.addattack + hc.addHp + hc.elemPoweredUp;
                }
            }

            if (ownMinionsCount - p.enemyMinions.Count >= 4 && bigMobsInHand >= 1)
            {
                resultValue += bigMobsInHand * 25;
            }


            //bool hasTank = false;
            foreach (Minion m in p.enemyMinions)
            {
                resultValue -= this.getEnemyMinionValue(m, p);
                //hasTank = hasTank || m.taunt;
            }
            resultValue -= p.enemyMinions.Count * 2;
            /*foreach (SecretItem si in p.enemySecretList)
            {
                if (readycount >= 1 && !hasTank && si.canbeTriggeredWithAttackingHero)
                {
                    retval -= 100;
                }
                if (readycount >= 1 && p.enemyMinions.Count >= 1 && si.canbeTriggeredWithAttackingMinion)
                {
                    retval -= 100;
                }
                if (si.canbeTriggeredWithPlayingMinion && mobsInHand >= 1)
                {
                    retval -= 25;
                }
            }*/

            resultValue -= p.enemySecretCount;
            resultValue -= p.lostDamage;//damage which was to high (like killing a 2/1 with an 3/3 -> => lostdamage =2
            resultValue -= p.lostWeaponDamage;

            //if (p.ownMinions.Count == 0) retval -= 20;
            //if (p.enemyMinions.Count == 0) retval += 20;

            if (p.enemyHero.HealthPoints <= 0)
            {
                resultValue += 10000;
                if (resultValue < 10000) resultValue = 10000;
            }

            if (p.enemyHero.HealthPoints >= 1 && p.guessingHeroHP <= 0)
            {
                if (p.turnCounter < 2) resultValue += p.owncarddraw * 100;
                resultValue -= 1000;
            }
            if (p.ownHero.HealthPoints <= 0) resultValue -= 10000;

            p.value = resultValue;
            return resultValue;
        }



        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            int retval = 5;
            retval += m.HealthPoints * 2;
            if (!m.frozen && !(m.cantAttack && m.name != CardName.argentwatchman))
            {
                retval += m.Attack * 2;
                if (m.windfury) retval += m.Attack * 2;
                if (m.Attack >= 4) retval += 10;
                if (m.Attack >= 7) retval += 50;
            }

            if (!m.handcard.card.isSpecialMinion)
            {
                if (m.Attack == 0) retval -= 7;
                else if (m.Attack <= 2 && m.HealthPoints <= 2 && !m.DivineShield) retval -= 5;
            }
            else retval += m.handcard.card.rarity;
			
            if (m.taunt) retval += 5;
            if (m.DivineShield) retval += m.Attack;
            if (m.DivineShield && m.taunt) retval += 5;
            if (m.stealth) retval += 1;

            if (m.poisonous)
            {
                retval += 4;
                if (p.ownMinions.Count < p.enemyMinions.Count) retval += 10;
            }
            if (m.lifesteal) retval += m.Attack;

            if (m.handcard.card.targetPriority >= 1 && !m.silenced)
            {
                retval += m.handcard.card.targetPriority;
            }
            if (m.name == CardName.nerubianegg && m.Attack <= 3 && !m.taunt) retval = 0;
            retval += m.synergy;
            return retval;
        }


        public override int getSirFinleyPriority(List<Handmanager.Handcard> discoverCards)
        {
            
            return -1; //comment out or remove this to set manual priority
            int sirFinleyChoice = -1;
            int tmp = int.MinValue;
            for (int i = 0; i < discoverCards.Count; i++)
            {
                CardName name = discoverCards[i].card.name;
                if (SirFinleyPriorityList.ContainsKey(name) && SirFinleyPriorityList[name] > tmp)
                {
                    tmp = SirFinleyPriorityList[name];
                    sirFinleyChoice = i;
                }
            }
            return sirFinleyChoice;
        }

        private Dictionary<CardName, int> SirFinleyPriorityList = new Dictionary<CardName, int>
        {
            //{HeroPowerName, Priority}, where 0-9 = manual priority
            { CardName.lesserheal, 0 }, 
            { CardName.shapeshift, 6 },
            { CardName.fireblast, 7 },
            { CardName.totemiccall, 1 },
            { CardName.lifetap, 9 },
            { CardName.daggermastery, 5 },
            { CardName.reinforce, 4 },
            { CardName.armorup, 2 },
            { CardName.steadyshot, 8 }
        };
		
    }

}