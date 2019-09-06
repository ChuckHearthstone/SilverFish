using HREngine.Bots;

namespace SilverFish.cards.EX1
{
    /// <summary>
    /// Ice Block
    /// 寒冰屏障
    /// </summary>
	public class Sim_EX1_295 : SimTemplate
	{
        /// <summary>
        /// Secret: When your hero takes fatal damage, prevent it and become Immune this turn.
        /// 奥秘：当你的英雄将要承受致命伤害时，防止这些伤害，并使其在本回合中获得免疫。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="number"></param>
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            target.HealthPoints += number;
            target.immune = true;
        }

	}

}