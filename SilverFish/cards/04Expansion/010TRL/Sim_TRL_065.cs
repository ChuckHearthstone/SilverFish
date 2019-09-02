using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
class Sim_TRL_065: SimTemplate //* 祖尔金
{



CardDB cdb = CardDB.Instance;
CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOOT_077t);//Wolf
CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DAL_378t1);//双足飞龙
CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_032);//misha


public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
{

p.setNewHeroPower(CardDB.cardIDEnum.TRL_065h, ownplay); //
if (ownplay) p.ownHero.armor += 5;
else p.enemyHero.armor += 5;


int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
if(ownplay)
{


foreach (KeyValuePair<CardDB.cardIDEnum, int> e in Probabilitymaker.Instance.ownCardsOut)
{
kid = cdb.getCardDataFromID(e.Key);

if (kid.type == CardDB.cardtype.SPELL)
{
{


if (kid.Secret)
{
if (p.ownSecretsIDList.Count < 5 && !p.ownSecretsIDList.Contains(kid.cardIDenum))
p.ownSecretsIDList.Add(kid.cardIDenum);

}
else if(kid.name == CardDB.cardName.unleashthebeasts)
{
p.CallKid(kid2, pos, ownplay);
p.drawACard(CardDB.cardName.unknown, ownplay, true);
if(e.Value>1)p.CallKid(kid2, pos, ownplay);
}
else if(kid.name == CardDB.cardName.animalcompanion)
{
if(e.Value>1)p.CallKid(kid3, pos, ownplay);
p.CallKid(kid3, pos, ownplay);
}
else if(kid.name == CardDB.cardName.masterscall)
{
p.drawACard(CardDB.cardName.unknown, ownplay, true);
p.drawACard(CardDB.cardName.unknown, ownplay, true);
if(e.Value>1)
{
p.drawACard(CardDB.cardName.unknown, ownplay, true);
p.drawACard(CardDB.cardName.unknown, ownplay, true);
}
p.drawACard(CardDB.cardName.unknown, ownplay, true);
if(e.Value>1)
{
p.drawACard(CardDB.cardName.unknown, ownplay, true);
}
}
}


}
}
}

}
}
}
