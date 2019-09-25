namespace Chuck.SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Emberscale Drake
    /// 烬鳞幼龙
    /// </summary>
    public class Sim_TRL_323 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you're holding a Dragon, gain 5 Armor.
        /// 战吼：如果你的手牌中有龙牌，便获得5点护甲值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                bool dragonInHand = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }
                if (dragonInHand) p.minionGetArmor(p.ownHero, 5);
            }
            else
            {
                if (p.enemyAnzCards >= 2) p.minionGetArmor(p.enemyHero, 5);
            }
        }
    }
}