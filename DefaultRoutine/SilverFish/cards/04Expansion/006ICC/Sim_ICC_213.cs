using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_213: SimTemplate //* Eternal Servitude
    {
        // Discover a friendly minion that died this game. Summon it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.ownMaxMana >= 6)
            {
                int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID((p.OwnLastDiedMinion == CardIdEnum.None) ? CardIdEnum.EX1_345t : p.OwnLastDiedMinion); // Shadow of Nothing 0:1 or ownMinion
                p.CallKid(kid, pos, ownplay, false);
            }
        }
    }
}