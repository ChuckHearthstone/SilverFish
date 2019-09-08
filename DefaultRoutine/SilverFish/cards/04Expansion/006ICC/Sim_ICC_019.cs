using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_019: SimTemplate //* Skelemancer
    {
        // Deathrattle: If it's your opponent's turn, summon an 8/8 Skeleton.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.ICC_019t); //Skeletal Flayer

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.CallKid(kid, m.zonepos, m.own);
        }
    }
}