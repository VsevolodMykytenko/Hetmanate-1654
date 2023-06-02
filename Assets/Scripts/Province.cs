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
}
