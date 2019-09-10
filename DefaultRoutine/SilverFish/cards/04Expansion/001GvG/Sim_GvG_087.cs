using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_087 : SimTemplate //* Steamwheedle Sniper
    {

        //  Your Hero Power can target minions. 

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own) p.weHaveSteamwheedleSniper = true;
            else p.enemyHaveSteamwheedleSniper = true;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                bool hasss = false;
                foreach (Minion mnn in p.ownMinions)
                {
                    if (m.name == CardName.steamwheedlesniper && !mnn.silenced) hasss = true;
                }
                p.weHaveSteamwheedleSniper = hasss;
            }
            else
            {
                bool hasss = false;
                foreach (Minion mnn in p.enemyMinions)
                {
                    if (m.name == CardName.steamwheedlesniper && !mnn.silenced) hasss = true;
                }
                p.enemyHaveSteamwheedleSniper = hasss;
            }
        }
    }
}