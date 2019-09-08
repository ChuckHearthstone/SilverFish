using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_825: SimTemplate //* Abominable Bowman
    {
        // Deathrattle: Summon a random friendly Beast that died this game.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_172); //3/2 Bloodfen Raptor

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos - 1, m.own);
        }
    }
}