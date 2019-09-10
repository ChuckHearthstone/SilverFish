namespace Chuck.SilverFish
{
    /// <summary>
    /// Savage Roar
    /// 野蛮咆哮
    /// </summary>
    class Pen_CS2_011 : PenTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "Give your characters +2_Attack this turn.",
        /// "LocStringZhCn": "在本回合中，使你的所有角色获得+2攻击力。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        /// <param name="isLethal"></param>
        /// <returns></returns>
        public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (!isLethal)
            {
                int targets = 0;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (mnn.Ready) targets++;
                }

                if (p.ownHero.Ready || p.ownHero.numAttacksThisTurn == 0) targets++;

                if (targets <= 1)
                {
                    return 40;
                }

                if (targets <= 2)
                {
                    return 20;
                }

            }

            return 0;
        }

    }
}