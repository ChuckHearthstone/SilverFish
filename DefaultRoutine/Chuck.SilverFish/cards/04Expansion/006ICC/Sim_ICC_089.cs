using System.Collections.Generic;
using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_089: SimTemplate //* Ice Fishing
    {
        // Draw 2 Murlocs from your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                CardDB.Card c;
                int count = 0;
                foreach (var cid in p.prozis.turnDeck)
                {
                    c = CardDB.Instance.getCardDataFromID(cid.Key);
                    if ((TAG_RACE)c.race == TAG_RACE.MURLOC)
                    {
                        for (int i = 0; i < cid.Value; i++)
                        {
                            p.drawACard(c.name, ownplay);
                            count++;
                            if (count > 1) break;
                        }
                        if (count > 1) break;
                    }
                }
            }
            else
            {
                p.drawACard(CardName.unknown, ownplay);
                p.drawACard(CardName.unknown, ownplay);
            }
        }
    }
}