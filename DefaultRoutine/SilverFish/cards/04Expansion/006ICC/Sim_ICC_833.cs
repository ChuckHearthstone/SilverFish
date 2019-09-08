using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_833: SimTemplate //* Frost Lich Jaina
    {
        // Battlecry: Summon a 3/6 Water Elemental. Your Elementals have Lifesteal for the rest of the game.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.ICC_833t); //Water Elemental

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.CardIdEnum.ICC_833h, ownplay); // Icy Touch
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;
            
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay);
        }
    }
}