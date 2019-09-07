using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
class Sim_TRL_566 : SimTemplate //*荒野的复仇
{


public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
{
foreach (GraveYardItem gyi in p.diedMinions.ToArray()) // toArray() because a knifejuggler could kill a minion due to the summon :D
{
if (gyi.own == ownplay)
{
CardDB.Card card = CardDB.Instance.getCardDataFromID(gyi.cardid);
int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
p.CallKid(card, p.ownMinions.Count, gyi.own);
}
}






}
}
}

