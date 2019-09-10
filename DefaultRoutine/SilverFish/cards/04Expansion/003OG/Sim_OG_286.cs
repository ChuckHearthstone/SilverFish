using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_286 : SimTemplate //* Twilight Elder
	{
		//At the end of your turn, give your C'Thun +1/+1 (wherever it is).
		
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (triggerEffectMinion.own) p.cthunGetBuffed(1, 1, 0);
            }
        }
	}
}