using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_311 : SimTemplate //* A Light in the Darkness
    {
        //Discover a minion. Give it +1/+1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.lepergnome, ownplay, true);
            p.owncards[p.owncards.Count - 1].addattack++;
            p.owncards[p.owncards.Count - 1].addHp++;
        }
    }
}