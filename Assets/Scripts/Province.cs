using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Province
{
    public string name;

    public enum Factions
    {
        RichPospolita,
        Hetmanate,
        Moscovy,
        Khanate
    }

    public Factions faction;

    public int economicState;
    public int fortressState;
    public int militaryPower;
    public int provincePower;

    public string getStringName()
    {
        var names = new Dictionary<string, string>
        {
            {"RP1", "Варшава"},
            {"RP2", "Волинь"},
            {"RP3", "Бессарабія"},
            {"RP4", "Поділля"},
            {"G1", "Київщина"},
            {"G2", "Чернігівщина"},
            {"G3", "Запорізька січ"},
            {"G4", "Полтавщина"},
            {"M1", "Смоленщина"},
            {"M2", "Москва"},
            {"M3", "Слобожанщина"},
            {"M4", "Поволжя"},
            {"H1", "Перекоп"},
            {"H2", "Дике поле"},
            {"H3", "Бахчисарай"},
            {"H4", "Керч"}
        };
        return names[name];
    }
}
