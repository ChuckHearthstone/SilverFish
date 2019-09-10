using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_091 : SimTemplate //Arcane Nullifier X-21
    {

        //   Taunt  can't be targeted by spells or Hero Powers.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }

    }

}