namespace Chuck.SilverFish.cards._01Basic._04Paladin
{
	class Sim_EX1_371 : SimTemplate //handofprotection
	{

//    verleiht einem diener gottesschild/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            target.DivineShield = true;
		}

	}
}