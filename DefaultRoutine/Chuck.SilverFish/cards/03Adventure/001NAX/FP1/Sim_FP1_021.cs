using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
    class Sim_FP1_021 : SimTemplate//* Death's Bite
    {
        //Deathrattle: Deal 1 damage to all minions.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.FP1_021);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
            p.doDmgTriggers();
        }
    }
}
