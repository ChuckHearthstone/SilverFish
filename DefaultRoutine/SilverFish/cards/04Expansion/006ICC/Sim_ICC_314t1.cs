using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_314t1 : SimTemplate //* Frostmourne
    {
        // Deathrattle: Summon every minion killed by this weapon.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_314t1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_110t), m.zonepos - 1, m.own);//4/5 Baine Bloodhoof
        }
    }
}