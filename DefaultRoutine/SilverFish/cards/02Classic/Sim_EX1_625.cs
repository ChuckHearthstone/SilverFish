using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_625 : SimTemplate //* Shadowform
    {
        // Your Hero Power becomes 'Deal 2 damage'. If already in Shadowform: 3 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardIdEnum newHeroPower = CardIdEnum.EX1_625t; // Mind Spike
            if ((ownplay ? p.ownHeroAblility.card.cardIDenum : p.enemyHeroAblility.card.cardIDenum) == CardIdEnum.EX1_625t) newHeroPower = CardIdEnum.EX1_625t2; // Mind Shatter
            p.setNewHeroPower(newHeroPower, ownplay);
        }
    }
}