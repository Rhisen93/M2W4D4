using System;
using UnityEngine;

// Rende la classe visibile nell'Inspector quando usata da altri oggetti Unity
[Serializable]
public class Hero
{
    [SerializeField] private string name;             // Nome dell'eroe
    [SerializeField] private int hp;                  // Punti vita dell'eroe
    [SerializeField] private Stats baseStats;         // Statistiche base dell'eroe
    [SerializeField] private Element resistance;      // Elemento a cui l'eroe è resistente
    [SerializeField] private Element weakness;        // Elemento a cui l'eroe è vulnerabile
    [SerializeField] private Weapon weapon;           // Arma equipaggiata dall'eroe

    // Costruttore per inizializzare tutti i campi
    public Hero(string name, int hp, Stats baseStats, Element resistance, Element weakness, Element lightning, Weapon weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;
    }

    // Getter e Setter per il nome
    public string GetName()
    {
        return name;
    }

    private void SetName(string name)
    {
        this.name = name;
    }

    // Getter e Setter per gli HP
    public int Hp
    {
        get { return hp; }
        private set { hp = value; } // reso private per forzare l’uso di SetHp()
    }

    // Setter per HP (funzione separata per controlli futuri, come limiti min/max)
    public void SetHp(int value)
    {
        hp = Mathf.Max(0, value);
    }

    // Getter e Setter per le statistiche base
   
    public Stats GetBaseStats()
    {
        return baseStats;
    }

    public void SetBaseStats(Stats baseStats)
    {
        this.baseStats = baseStats;
    }

    // Getter e Setter per la resistenza
    public Element Resistance
    {
        get { return resistance; }
        set { resistance = value; }
    }

    // Getter e Setter per la debolezza
    public Element Weakness
    {
        get { return weakness; }
        set { weakness = value; }
    }

    // Getter e Setter per l’arma
    public Weapon Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }

    // Aumenta gli HP di una certa quantità (positiva o negativa), usando SetHp
    public void AddHp(int amount)
    {
        SetHp(hp + amount);
    }

    // Riduce gli HP chiamando AddHp con valore negativo
    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    // Restituisce true se l'eroe è ancora vivo
    public bool IsAlive()
    {
        return hp > 0;
    }
}
