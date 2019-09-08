using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_829p: SimTemplate //* The Four Horsemen
    {
        // Hero Power: Summon a 2/2 Horseman. If you have all 4, destroy the enemy hero.

        CardDB.Card kid1 = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_829t2); //Deathlord Nazgrim
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_829t3); //Thoras Trollbane
        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_829t4); //Inquisitor Whitemane
        CardDB.Card kid4 = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_829t5); //Darion Mograine

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid1, pos, ownplay, false);
        }
    }
}