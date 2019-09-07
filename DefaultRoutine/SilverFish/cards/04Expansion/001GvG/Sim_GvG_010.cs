using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_010 : SimTemplate //Velen's Chosen
    {

        //    Give a minion +2/+4 and Spell Damage +1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 4);
            target.spellpower++;
            if (target.own) p.spellpower++;
            else p.enemyspellpower++;

        }


    }

}