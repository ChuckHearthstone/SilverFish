using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_045 : SimTemplate //Imp-losion
    {

        //   Deal $2-$4 damage to a minion. Summon a 1/1 Imp for each damage dealt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.GVG_045t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);

            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, posi, ownplay);
            posi++;
            p.CallKid(kid, posi, ownplay);
        }


    }

}