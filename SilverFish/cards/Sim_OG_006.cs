using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_006 : SimTemplate //* Vilefin Inquisitor
	{
		//Battlecry: Your Hero Power becomes 'Summon a 1/1 Murloc.'
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			CardDB.Card hewHeroPower = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_006b); //The Tidal Hand
            if (own.own)
            {
                p.ownHeroAblility.card = hewHeroPower;
                p.ownAbilityReady = true;
            }
            else
            {
                p.enemyHeroAblility.card = hewHeroPower;
                p.enemyAbilityReady = true;
            }
		}
	}
}