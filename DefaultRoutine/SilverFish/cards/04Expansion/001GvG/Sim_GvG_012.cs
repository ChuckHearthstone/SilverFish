using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_012 : SimTemplate //Light of the Naaru
    {

        //    Restore #3 Health. If the target is still damaged, summon a Lightwarden.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_001);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(3) : p.getEnemySpellHeal(3);
            p.minionGetDamageOrHeal(target, -heal);
            if (target.HealthPoints < target.maxHp)
            {
                int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(kid, posi, ownplay);
            }
        }


    }

}