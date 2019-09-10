using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_008 : SimTemplate //spectralknight
	{

//    kann nicht als ziel von zaubern oder heldenfähigkeiten gewählt werden.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
	}
}