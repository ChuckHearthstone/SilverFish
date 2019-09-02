using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_006 : SimTemplate //* Vilefin Inquisitor
	{
		//Battlecry: Your Hero Power becomes 'Summon a 1/1 Murloc.'
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.OG_006b, own.own); // The Tidal Hand
		}
	}
}