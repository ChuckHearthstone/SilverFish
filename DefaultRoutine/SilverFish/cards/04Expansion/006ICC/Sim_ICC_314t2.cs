using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
	class Sim_ICC_314t2 : SimTemplate //* Army of the Dead
    {
        // Remove the top 5 cards of your deck. Summon any minions removed.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            int anz = (ownplay) ? p.ownDeckSize : p.enemyDeckSize;
            if (anz > 5) anz = 5;
            if (ownplay) p.ownDeckSize -= anz;
            else p.enemyDeckSize -= anz;

            if (anz > 0) p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_120), pos, ownplay, false);//river crocolisk
            if (anz > 2) p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.CS1_042), pos, ownplay, false);//goldshire footman
            if (anz > 4) p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_048), pos, ownplay, false);//spellbreaker
        }
    }
}