using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_096 : SimTemplate //* Piloted Shredder
    {

        // Deathrattle: Summon a random 2-Cost minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_172);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos - 1, m.own);
        }
    }
}