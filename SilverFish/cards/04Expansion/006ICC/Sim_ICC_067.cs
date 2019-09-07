using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_067: SimTemplate //* Vryghoul
    {
        // Deathrattle: If it's your opponent's turn, summon a 2/2 Ghoul.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_900t); //Ghoul 2/2

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.CallKid(kid, m.zonepos, m.own);
        }
    }
}