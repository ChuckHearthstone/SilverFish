using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_031 : SimTemplate //* Hammer of Twilight
    {
        //Deathrattle: Summon a 4/2 Elemental.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_031);
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_031a);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, m.own);
        }
    }
}