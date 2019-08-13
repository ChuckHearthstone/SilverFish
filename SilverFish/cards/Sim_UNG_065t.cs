using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_065t : SimTemplate //* Sherazin, Seed
	{
		//When you play 4 cards in a turn, revive this minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_065); //Sherazin, Corpse Flower

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            triggerEffectMinion.Angr++;
            triggerEffectMinion.cantAttack = true;
            if (triggerEffectMinion.Angr > 3) p.minionTransform(triggerEffectMinion, kid);
        }

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                triggerEffectMinion.Angr = 0;
            }
        }
    }
}