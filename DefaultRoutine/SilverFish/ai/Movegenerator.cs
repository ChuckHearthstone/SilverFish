using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace HREngine.Bots
{
    public class Movegenerator
    {
        PenaltyManager pen = PenaltyManager.Instance;

        private static Movegenerator instance;

        public static Movegenerator Instance
        {
            get
            {
                return instance ?? (instance = new Movegenerator());
            }
        }

        private Movegenerator()
        {
        }

        public List<Action> GetMoveList(Playfield p, bool usePenalityManager, bool useCutingTargets, bool own)
        {
            //generates only own moves
            List<Action> ret = new List<Action>();
            List<Minion> targetMinions;

            if (p.complete || p.ownHero.HealthPoints <= 0)
            {
                return ret;
            }

            //play cards:
            if (own)
            {
                List<string> playedCards = new List<string>();
                StringBuilder cardNcost = new StringBuilder();

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    int cardCost = hc.card.getManaCost(p, hc.manacost);
                    if ((p.nextSpellThisTurnCostHealth && hc.card.type == CardType.SPELL) ||
                        (p.nextMurlocThisTurnCostHealth && (TAG_RACE) hc.card.race == TAG_RACE.MURLOC))
                    {
                        if (p.ownHero.HealthPoints > cardCost || p.ownHero.immune)
                        {
                        }
                        else
                        {
                            // if not enough Hp
                            continue; 
                        }
                    }
                    else if (p.mana < cardCost)
                    {  
                        // if not enough manna
                        continue; 
                    }

                    CardDB.Card c = hc.card;
                    cardNcost.Clear();
                    cardNcost.Append(c.name).Append(hc.manacost);
                    if (playedCards.Contains(cardNcost.ToString()))
                    {
                        // don't play the same card in one loop
                        continue; 
                    }

                    playedCards.Add(cardNcost.ToString());

                    int isChoice = (c.choice) ? 1 : 0;
                    bool choiceDamageFound = false;
                    for (int choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = pen.getChooseCard(hc.card, choice); // do all choice
                            if (p.ownFandralStaghelm > 0)
                            {
                                if (choiceDamageFound) break;
                                for (int i = 1; i < 3; i++)
                                {
                                    CardDB.Card cTmp = pen.getChooseCard(hc.card, i); // do all choice
                                    if (pen.DamageTargetDatabase.ContainsKey(cTmp.name) ||
                                        (p.anzOwnAuchenaiSoulpriest > 0 &&
                                         pen.HealTargetDatabase.ContainsKey(cTmp.name)))
                                    {
                                        choice = i;
                                        choiceDamageFound = true;
                                        c = cTmp;
                                        break;
                                    }

                                    //- Draw a card must be at end in the Sim_xxx - then it will selected!
                                }
                            }
                        }

                        if (p.ownMinions.Count > 6 &&
                            (c.type == CardType.MOB || hc.card.type == CardType.MOB))
                        {
                            continue;
                        }
                        targetMinions = c.getTargetsForCard(p, p.isLethalCheck, true);
                        if (targetMinions.Count == 0)
                        {
                            continue;
                        }

                        int cardPlayPenalty = 0;
                        CardDB.Card card;
                        if (c.type == CardType.MOB)
                        {
                            card = c;
                        }
                        else
                        {
                            card = hc.card;
                        }

                        int bestPlace = p.getBestPlace(card, p.isLethalCheck);

                        foreach (Minion targetMinion in targetMinions)
                        {
                            if (usePenalityManager)
                            {
                                cardPlayPenalty = pen.getPlayCardPenality(c, targetMinion, p);
                            }
                            if (cardPlayPenalty <= 499)
                            {
                                Action a = new Action(actionEnum.playcard, hc, null, bestPlace, targetMinion, cardPlayPenalty,
                                    choice);
                                ret.Add(a);
                            }
                        }
                    }
                }
            }

            //get targets for Hero weapon and Minions  ###################################################################################

            targetMinions = p.getAttackTargets(own, p.isLethalCheck);
            if (!p.isLethalCheck)
            {
                targetMinions = this.cutAttackList(targetMinions);
            }

            // attack with minions
            List<Minion> attackingMinions = new List<Minion>(8);
            var minions = own ? p.ownMinions : p.enemyMinions;
            foreach (Minion minion in minions)
            {
                if (minion.Ready && minion.Attack >= 1 && !minion.frozen)
                {
                    //add non-attacking minions
                    attackingMinions.Add(minion);
                }
            }

            attackingMinions = cutAttackList(attackingMinions);

            foreach (Minion m in attackingMinions)
            {
                int attackPenalty = 0;
                foreach (Minion targetMinion in targetMinions)
                {
                    //can not attack hero
                    if (m.cantAttackHeroes && targetMinion.isHero)
                    {
                        continue;
                    }

                    if (usePenalityManager)
                    {
                        attackPenalty = pen.getAttackWithMininonPenality(m, p, targetMinion);
                    }

                    if (attackPenalty <= 499)
                    {
                        Action a = new Action(actionEnum.attackWithMinion, null, m, 0, targetMinion, attackPenalty, 0);
                        ret.Add(a);
                    }
                }
            }

            // attack with hero (weapon)
            if ((own && p.ownHero.Ready && p.ownHero.Attack >= 1) || (!own && p.enemyHero.Ready && p.enemyHero.Attack >= 1))
            {
                int heroAttackPen = 0;
                foreach (Minion targetMinion in targetMinions)
                {
                    if ((own ? p.ownWeapon.cantAttackHeroes : p.enemyWeapon.cantAttackHeroes) && targetMinion.isHero)
                    {
                        continue;
                    }

                    if (usePenalityManager)
                    {
                        heroAttackPen = pen.getAttackWithHeroPenality(targetMinion, p);
                    }

                    if (heroAttackPen <= 499)
                    {
                        Action a = new Action(actionEnum.attackWithHero, null, (own ? p.ownHero : p.enemyHero), 0, targetMinion,
                            heroAttackPen, 0);
                        ret.Add(a);
                    }
                }
            }

            //#############################################################################################################

            // use own ability
            if (own)
            {
                if (p.ownAbilityReady 
                    && p.mana >= p.ownHeroAblility.card.getManaCost(p, p.ownHeroAblility.manacost)) // if ready and enough manna
                {
                    CardDB.Card c = p.ownHeroAblility.card;
                    int isChoice = (c.choice) ? 1 : 0;
                    for (int choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = pen.getChooseCard(p.ownHeroAblility.card, choice); // do all choice
                        }

                        int cardPlayPenalty = 0;
                        int bestPlace = p.ownMinions.Count + 1; //we can not manage it
                        targetMinions = p.ownHeroAblility.card.getTargetsForHeroPower(p, true);
                        foreach (Minion targetMinion in targetMinions)
                        {
                            if (usePenalityManager)
                            {
                                cardPlayPenalty = pen.getPlayCardPenality(p.ownHeroAblility.card, targetMinion, p);
                            }

                            if (cardPlayPenalty <= 499)
                            {
                                Action a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, bestPlace, targetMinion,
                                    cardPlayPenalty, choice);
                                ret.Add(a);
                            }
                        }
                    }
                }
            }

            return ret;
        }

        public List<Minion> cutAttackList(List<Minion> oldlist)
        {
            List<Minion> retvalues = new List<Minion>(oldlist.Count);
            List<Minion> addedmins = new List<Minion>(oldlist.Count);

            foreach (Minion m in oldlist)
            {
                if (m.isHero)
                {
                    retvalues.Add(m);
                    continue;
                }

                bool goingtoadd = true;
                bool isSpecial = m.handcard.card.isSpecialMinion;
                foreach (Minion mnn in addedmins)
                {
                    //LogHelper.WriteCombatLog(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                    bool otherisSpecial = mnn.handcard.card.isSpecialMinion;
			        bool onlySpecial = isSpecial && otherisSpecial && !m.silenced && !mnn.silenced;
			        bool onlyNotSpecial =(!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced));
			
			        if(onlySpecial && (m.name != mnn.name)) continue; // different name -> take it
                    if ((onlySpecial || onlyNotSpecial) && (mnn.Attack == m.Attack && mnn.HealthPoints == m.HealthPoints && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal && m.handcard.card.isToken == mnn.handcard.card.isToken && mnn.handcard.card.race == m.handcard.card.race))
                    {
				        goingtoadd = false;
				        break;
                    }
                }

                if (goingtoadd)
                {
                    addedmins.Add(m);
                    retvalues.Add(m);
                    //LogHelper.WriteCombatLog(m.name + " " + m.id +" is added to targetlist");
                }
                else
                {
                    //LogHelper.WriteCombatLog(m.name + " is not needed to attack");
                    continue;
                }
            }
            //LogHelper.WriteCombatLog("end targetcutting");

            return retvalues;
        }


        public bool didAttackOrderMatters(Playfield p)
        {
            //return true;
            if (p.isOwnTurn)
            {
                if (p.enemySecretCount >= 1) return true;
                if (p.enemyHero.immune) return true;

            }
            else
            {
                if (p.ownHero.immune) return true;
            }
            List<Minion> enemym = (p.isOwnTurn) ? p.enemyMinions : p.ownMinions;
            List<Minion> ownm = (p.isOwnTurn) ? p.ownMinions : p.enemyMinions;

            int strongestAttack = 0;
            foreach (Minion m in enemym)
            {
                if (m.Attack > strongestAttack) strongestAttack = m.Attack;
                if (m.taunt) return true;
                if (m.name == CardName.dancingswords || m.name == CardName.deathlord) return true;
            }

            int haspets = 0;
            bool hashyena = false;
            bool hasJuggler = false;
            bool spawnminions = false;
            foreach (Minion m in ownm)
            {
                if (m.name == CardName.cultmaster) return true;
                if (m.name == CardName.knifejuggler) hasJuggler = true;
                if (m.Ready && m.Attack >= 1)
                {
                    if (m.AdjacentAttack >= 1) return true;//wolphalfa or flametongue is in play
                    if (m.name == CardName.northshirecleric) return true;
                    if (m.name == CardName.armorsmith) return true;
                    if (m.name == CardName.loothoarder) return true;
                    //if (m.name == CardName.madscientist) return true; // dont change the tactic
                    if (m.name == CardName.sylvanaswindrunner) return true;
                    if (m.name == CardName.darkcultist) return true;
                    if (m.ownBlessingOfWisdom >= 1) return true;
                    if (m.ownPowerWordGlory >= 1) return true;
                    if (m.name == CardName.acolyteofpain) return true;
                    if (m.name == CardName.frothingberserker) return true;
                    if (m.name == CardName.flesheatingghoul) return true;
                    if (m.name == CardName.bloodmagethalnos) return true;
                    if (m.name == CardName.webspinner) return true;
                    if (m.name == CardName.tirionfordring) return true;
                    if (m.name == CardName.baronrivendare) return true;


                    //if (m.name == CardName.manawraith) return true;
                    //buffing minions (attack with them last)
                    if (m.name == CardName.raidleader 
                        || m.name == CardName.stormwindchampion 
                        || m.name == CardName.timberwolf 
                        || m.name == CardName.southseacaptain 
                        || m.name == CardName.murlocwarleader 
                        || m.name == CardName.grimscaleoracle 
                        || m.name == CardName.leokk 
                        || m.name == CardName.fallenhero 
                        || m.name == CardName.warhorsetrainer)
                        return true;


                    if (m.name == CardName.scavenginghyena) hashyena = true;
                    if (m.handcard.card.race == 20) haspets++;
                    if (m.name == CardName.harvestgolem || m.name == CardName.hauntedcreeper || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.ancestralspirit >= 1 || m.desperatestand  >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.name == CardName.nerubianegg || m.name == CardName.savannahhighmane || m.name == CardName.sludgebelcher || m.name == CardName.cairnebloodhoof || m.name == CardName.feugen || m.name == CardName.stalagg || m.name == CardName.thebeast) spawnminions = true;
                    
                }
            }

            if (haspets >= 1 && hashyena) return true;
            if (hasJuggler && spawnminions) return true;




            return false;
        }
    }

}