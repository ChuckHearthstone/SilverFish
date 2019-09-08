using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_054: SimTemplate //* Spreading Plague
    {
        // Summon a 1/5 Scarab with Taunt. If your opponent has more minions, cast this again.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.ICC_832t4); //Scarab Beetle

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                do
                {
                    p.CallKid(kid, p.ownMinions.Count, ownplay);
                }
                while (p.enemyMinions.Count > p.ownMinions.Count);
            }
        }
    }
}