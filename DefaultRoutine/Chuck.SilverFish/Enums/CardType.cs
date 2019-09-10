
namespace SilverFish.Enums
{

    // Data is stored in hearthstone-folder -> data->win cardxml0
    //(data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
    public enum CardType
    {
        NONE = 0,
        HERO = 3,
        Minion = 4,
        SPELL = 5,
        ENCHANTMENT = 6,
        WEAPON = 7,
        Token = 9,
        HEROPWR = 10,
    }
}
