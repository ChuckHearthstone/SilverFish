using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_812: SimTemplate //* Meat Wagon
    {
        // Deathrattle: Summon a minion from your deck with less Attack than this minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            CardDB.cardIDEnum cId = CardDB.cardIDEnum.None;
            for (int i = m.Attack - 1; i >= 0; i--)
            {
                cId = p.prozis.getDeckCardsForCost(i);
                if (cId != CardDB.cardIDEnum.None) break;
            }
            if (cId != CardDB.cardIDEnum.None)
            {
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(cId);
                p.CallKid(kid, m.zonepos - 1, m.own);
            }
        }
    }
}