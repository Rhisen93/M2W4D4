using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    // Definisco un enum per la tipologia di danno dell'arma
    public enum DAMAGE_TYPE
    {
        PHYSICAL,
        MAGICAL
    }

    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private Element elem;
    [SerializeField] private Stats bonusStats;

    public Weapon(string name, DAMAGE_TYPE dmgType, Element elem, Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public DAMAGE_TYPE GetDmgType()
    {
        return dmgType;
    }

    public void SetDmgType(DAMAGE_TYPE DmgType)
    {
        this.dmgType = DmgType;
    }

    public Element GetElem()
    {
        return elem;
    }

    public void SetElement(Element elem)
    {
        this.elem = elem;
    }

    public Stats GetBonusStats()
    {
        return bonusStats;
    }

    public void SetBonusStats(Stats BonusStats)
    {
        this.bonusStats = BonusStats;
    }
    public Stats BonusStats
    {
        get { return bonusStats; }   // Restituisce 'bonusStats'
        set { bonusStats = value; }  // Imposta un nuovo valore a 'bonusStats'
    }
}
