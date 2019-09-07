using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_033 : SimTemplate //* Tentacles for Arms
    {
        //Deathrattle: Return this to your hand.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_033);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(p.ownWeapon.name, m.own, true);
        }
    }
}