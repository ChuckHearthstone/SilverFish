using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_209 : SimTemplate //* Hallazeal the Ascended
	{
		//Whenever your spells deal damage, restore that much Health to your hero.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == CardDB.CardType.SPELL)
            {
                Minion target = (ownplay) ? p.ownHero : p.enemyHero;
                p.minionGetDamageOrHeal(target, -p.prozis.penman.guessTotalSpellDamage(p, hc.card.name, ownplay));
            }
        }
    }
}