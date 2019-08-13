using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_004 : SimTemplate //vanish
	{

//    lasst alle diener auf die hand ihrer besitzer zurückkehren.
        //todo clear playfield
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.anzOwnRaidleader = 0;
            p.anzEnemyRaidleader = 0;
            p.anzOwnStormwindChamps = 0;
            p.anzEnemyStormwindChamps = 0;
            p.anzOwnAnimatedArmor = 0;
            p.anzEnemyAnimatedArmor = 0;
            p.anzOwnWarhorseTrainer = 0;
            p.anzEnemyWarhorseTrainer = 0;
            p.anzOwnTundrarhino = 0;
            p.anzEnemyTundrarhino = 0;
            p.anzOwnTimberWolfs = 0;
            p.anzEnemyTimberWolfs = 0;
            p.anzOwnMurlocWarleader = 0;
            p.anzEnemyMurlocWarleader = 0;
            p.anzAcidmaw = 0;
            p.anzOwnGrimscaleOracle = 0;
            p.anzEnemyGrimscaleOracle = 0;
            p.anzOwnShadowfiend = 0;
            p.anzOwnAuchenaiSoulpriest = 0;
            p.anzEnemyAuchenaiSoulpriest = 0;
            p.blackwaterpirate = 0;
            p.anzOwnSouthseacaptain = 0;
            p.anzEnemySouthseacaptain = 0;
            p.anzEnemyTaunt = 0;
            p.anzOwnTaunt = 0;
            p.doublepriest = 0;
            p.enemydoublepriest = 0;
            p.ownBaronRivendare = 0;
            p.enemyBaronRivendare = 0;
            p.ownBrannBronzebeard = 0;
            p.enemyBrannBronzebeard = 0;            
            p.ownTurnEndEffectsTriggerTwice = 0;
            p.enemyTurnEndEffectsTriggerTwice = 0;
            p.ownFandralStaghelm = 0;
            p.anzOwnChromaggus = 0;
            p.anzEnemyChromaggus = 0;
            p.anzOwnPiratesStarted = 0;
            p.anzOwnMurlocStarted = 0;
            p.ownMistcaller = 0;
            p.ownAbilityFreezesTarget = 0;
            p.enemyAbilityFreezesTarget = 0;

            p.spellpower = 0;
            p.enemyspellpower = 0;
            
            p.winzigebeschwoererin = 0;
            p.managespenst = 0;
            p.ownMinionsCostMore = 0;
            p.ownDRcardsCostMore = 0;
            p.beschwoerungsportal = 0;
            p.myCardsCostLess = 0;
            p.anzOwnAviana = 0;
            p.anzOwnCloakedHuntress = 0;
            p.nerubarweblord = 0;
            p.ownSpelsCostMore = 0;
            

            p.ownHeroPowerExtraDamage = 0;
            p.enemyHeroPowerExtraDamage = 0;

            foreach (Minion m in p.ownMinions)
            {
                p.drawACard(m.name, true, true);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.drawACard(m.name, false, true);
            }
            p.ownMinions.Clear();
            p.enemyMinions.Clear();

        }

	}
}