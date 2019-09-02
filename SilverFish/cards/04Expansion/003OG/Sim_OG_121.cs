using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_121 : SimTemplate //* Cho'Gall
    {
        //Battlecry: The next spell you cast this turn costs Health instead of Mana.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own) p.nextSpellThisTurnCostHealth = true;
        }
    }
}