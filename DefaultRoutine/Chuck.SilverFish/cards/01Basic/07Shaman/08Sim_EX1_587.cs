namespace Chuck.SilverFish.cards._01Basic._07Shaman
{
	class Sim_EX1_587 : SimTemplate //windspeaker
	{

//    kampfschrei:/ verleiht einem befreundeten diener windzorn/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetWindfurry(target);
		}


	}
}