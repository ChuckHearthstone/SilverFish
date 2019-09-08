using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_072 : SimTemplate //* Stonehill Defender
	{
		//Taunt. Battlecry: Discover a Taunt minion.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.pompousthespian, own.own, true);
        }
    }
}