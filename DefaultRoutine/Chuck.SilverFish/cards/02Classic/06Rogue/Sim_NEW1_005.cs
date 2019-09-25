namespace Chuck.SilverFish.cards._02Classic._06Rogue
{
	class Sim_NEW1_005 : SimTemplate //kidnapper
	{

//    combo:/ lasst einen diener auf die hand seines besitzers zurückkehren.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1) p.minionReturnToHand(target,target.own, 0);
		}


	}
}