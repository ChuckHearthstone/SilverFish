using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_034 : SimTemplate //* Arrogant Crusader
    {
        // Deathrattle: If it's your opponent's turn, summon a 2/2 Ghoul.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_900t); //Ghoul 2/2

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.CallKid(kid, m.zonepos, m.own);
        }
    }
}