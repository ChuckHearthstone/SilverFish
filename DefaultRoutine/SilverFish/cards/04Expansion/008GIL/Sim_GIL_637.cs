using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Ferocious Howl
    /// 凶猛咆哮
    /// </summary>
    public class Sim_GIL_637 : SimTemplate
    {
        /// <summary>
        /// "Draw a card. Gain 1 Armor for each card in your hand.",
        /// "抽一张牌。你每有一张手牌，便获得1点护甲值。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);

            int armor = (ownplay) ? p.owncards.Count : p.enemyAnzCards;
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, armor);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, armor);
            }
        }
    }
}
