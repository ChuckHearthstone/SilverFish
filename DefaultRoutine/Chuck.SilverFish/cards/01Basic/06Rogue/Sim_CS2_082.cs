using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._06Rogue
{
    /// <summary>
    /// Wicked Knife
    /// Ð°¶ñ¶Ìµ¶
    /// </summary>
	class Sim_CS2_082 : SimTemplate
	{
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_082);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}