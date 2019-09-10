using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_085: SimTemplate //* Ultimate Infestation
    {
        // Deal 5 damage. Draw 5 cards. Gain 5 Armor. Summon a 5/5 Ghoul.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_085t); //Ghoul Infestor

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);

            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);

            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 5);

            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay);
        }
    }
}