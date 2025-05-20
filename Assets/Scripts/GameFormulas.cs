using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFormulas
{

    public static bool HasElementAdvantage(Element attackElement, Hero defender)
    {
        return attackElement == defender.Weakness;
    }

    public static bool HasElementDisadvantage(Element attackElement, Hero defender)
    {
        return attackElement == defender.Resistance;
    }

    public static float EvalueateElemtalModifier(Element attackElement, Hero defender)
    {
        float modificatore = 1f;

        if (HasElementAdvantage(attackElement, defender))
        {
            modificatore += 0.5f;
        }

        if(HasElementDisadvantage(attackElement, defender))
        {
            modificatore -= 0.5f;
        }

        return modificatore;
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int HitChance = attacker.aim - defender.eva;

        if(Random.Range(0, 99) > HitChance)
        {
            Debug.Log("MISS");

            return false;
        }

        return true;

    }

    public static bool IsCrit(int critValue)
    {
        if(Random.Range(0, 99) < critValue){

            Debug.Log("CRIT");

            return true;
        }

        return false;
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats SumAtk = Stats.Sum(attacker.GetBaseStats(), attacker.Weapon.BonusStats);
        Stats SumDef = Stats.Sum(defender.GetBaseStats(), defender.Weapon.BonusStats);

        defender.SetBaseStats(SumDef);
        int defence = 0;
        if (defender.Weapon.GetDmgType() == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            defence = SumDef.def;
        }
        else if (defender.Weapon.GetDmgType() == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            defence = SumDef.res;
        }

        int dmg = SumAtk.atk - defence;
        float dmgMod = (EvalueateElemtalModifier(attacker.Weapon.GetElem(), defender)) * dmg;

        if (IsCrit(attacker.GetBaseStats().crt))
        {
            dmgMod *= 2;
        }

        if (dmgMod > 0)
        {
            return(int) dmgMod;
        }
        else
        {
            dmgMod = 0;
            return (int)dmgMod;
        }
    }
}
