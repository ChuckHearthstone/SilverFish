using System.Collections.Generic;
using SilverFish.Enums;


namespace HREngine.Bots
{
class Sim_TRL_065: SimTemplate //* 祖尔金
{



CardDB cdb = CardDB.Instance;
CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.LOOT_077t);//Wolf
CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardIdEnum.DAL_378t1);//双足飞龙
CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardIdEnum.NEW1_032);//misha


public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
{

p.setNewHeroPower(CardIdEnum.TRL_065h, ownplay); //
if (ownplay) p.ownHero.armor += 5;
else p.enemyHero.armor += 5;


int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
if(ownplay)
{


foreach (KeyValuePair<CardIdEnum, int> e in Probabilitymaker.Instance.ownCardsOut)
{
kid = cdb.getCardDataFromID(e.Key);

if (kid.type == CardType.SPELL)
{
{


if (kid.Secret)
{
if (p.ownSecretsIDList.Count < 5 && !p.ownSecretsIDList.Contains(kid.cardIDenum))
p.ownSecretsIDList.Add(kid.cardIDenum);

}
else if(kid.name == CardName.unleashthebeasts)
{
p.CallKid(kid2, pos, ownplay);
p.drawACard(CardName.unknown, ownplay, true);
if(e.Value>1)p.CallKid(kid2, pos, ownplay);
}
else if(kid.name == CardName.animalcompanion)
{
if(e.Value>1)p.CallKid(kid3, pos, ownplay);
p.CallKid(kid3, pos, ownplay);
}
else if(kid.name == CardName.masterscall)
{
p.drawACard(CardName.unknown, ownplay, true);
p.drawACard(CardName.unknown, ownplay, true);
if(e.Value>1)
{
p.drawACard(CardName.unknown, ownplay, true);
p.drawACard(CardName.unknown, ownplay, true);
}
p.drawACard(CardName.unknown, ownplay, true);
if(e.Value>1)
{
p.drawACard(CardName.unknown, ownplay, true);
}
}
}


}
}
}

}
}
}
