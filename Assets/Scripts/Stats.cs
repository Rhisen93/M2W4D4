
using System;
using UnityEngine;

[Serializable]
public struct Stats
{
    public int atk; // Attacco
    public int def; // Difesa
    public int res; // Resistenza magica
    public int spd; // Velocità
    public int crt; // Critico
    public int aim; // Precisione
    public int eva; // Evasione

    // Costruttore con valori numerici predefiniti
    public Stats(int atk = 10, int def = 8, int res = 6, int spd = 12, int crt = 5, int aim = 80, int eva = 15)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }

    // Funzione statica per sommare due Stats
    public static Stats Sum(Stats a, Stats b)
    {
        return new Stats(
            a.atk + b.atk,
            a.def + b.def,
            a.res + b.res,
            a.spd + b.spd,
            a.crt + b.crt,
            a.aim + b.aim,
            a.eva + b.eva
        );
    }
}
