using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    class Sim_GIL_553 : SimTemplate //精灵之森
    {

        //   你每有一张手牌，便召唤一个1/1的小精灵。
        
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231); //小精灵

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, posi, ownplay);
            posi++;
            p.CallKid(kid, posi, ownplay);
        }


    }

}