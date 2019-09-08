using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_750 : SimTemplate //* Krul the Unshackled
	{
		// Battlecry: If your deck has no duplicates, summon all Demons from your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                if (p.prozis.noDuplicates)
                {
				    if (p.ownMinions.Count < 7)
				    {
					    bool needTrigger = false;
					    foreach (Handmanager.Handcard hc in p.owncards.ToArray())
					    {
                            if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON)
						    {
							    p.CallKid(hc.card, p.ownMinions.Count, true);
							    p.removeCard(hc);
							    needTrigger = true;
							    if (p.ownMinions.Count > 6) break;
						    }
					    }
					    if (needTrigger) p.triggerCardsChanged(true);
				    }
                }
            }
            else
            {
                if (p.enemyAnzCards > 1)
                {
                    int pos = p.enemyMinions.Count;
                    p.CallKid(CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_306), pos, false); //Succubus
                    p.enemyAnzCards--;
                    p.triggerCardsChanged(false);
                    if (p.ownHeroHasDirectLethal())
                    {
                        p.enemyMinions[pos].Attack = 2;
                        if (p.ownHeroHasDirectLethal())
                        {
                            p.enemyMinions[pos].Attack = 0;
                        }
                    }
                }
            }
        }
    }
}