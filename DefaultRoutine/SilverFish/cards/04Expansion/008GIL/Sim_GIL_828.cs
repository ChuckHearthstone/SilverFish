using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
	class Sim_GIL_828 : SimTemplate //* 凶猛狂暴
	{
		//使一个野兽获得+3/+3。将它的三张复制洗入你的牌库，且这些复制都具有+3/+3。
        //未添加洗入牌库特效

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 3);
        }
	}
}