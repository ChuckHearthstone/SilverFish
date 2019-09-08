using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_PRO_001b : SimTemplate //* Rogues Do It...
    {
        //Deal $4 damage. Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardName.unknown, ownplay);
        }
    }
}
