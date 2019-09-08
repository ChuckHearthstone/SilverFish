using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace HREngine.Bots
{
	class Sim_TRL_339 : SimTemplate //主人的召唤
	{

//    从你的牌库中发现一张随从牌。如果三张牌都是野兽，则抽取全部三张牌。
//    未添加发现机制，改为直接抽取三张牌

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
		p.drawACard(CardName.unknown, ownplay);
		}

	}
}