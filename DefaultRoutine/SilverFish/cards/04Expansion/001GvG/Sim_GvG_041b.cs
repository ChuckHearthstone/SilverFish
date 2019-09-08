using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_041b : SimTemplate //* Dark Wispers
    {
        //   Summon 5 Wisps;

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_231);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            for (int i = 0; i < 5; i++)
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(kid, pos, ownplay);
            }
        }
    }
}