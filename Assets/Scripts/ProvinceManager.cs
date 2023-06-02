using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceManager : MonoBehaviour
{
    public static ProvinceManager instance;

    public List<GameObject> provinceList = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AddProvinceData();
    }

    void AddProvinceData ()
    {
        GameObject[] theArray = GameObject.FindGameObjectsWithTag("Province") as GameObject[];
        foreach (GameObject province in theArray)
        {
            provinceList.Add(province);
        }
        TintProvinces();
    }

    void TintProvinces()
    {
        for (int i = 0; i < provinceList.Count; i++)
        {
            ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();

            switch (provinceBehaviour.province.faction)
            {
                case Province.Factions.RichPospolita:
                    provinceBehaviour.TintColor(new Color32(252, 239, 234, 255));
                    break;
                
                case Province.Factions.Hetmanate:
                    provinceBehaviour.TintColor(new Color32(255,235,205,255));
                    break;
                
                case Province.Factions.Moscovy:
                    provinceBehaviour.TintColor(new Color32(225, 243, 252, 255));
                    break;
                
                case Province.Factions.Khanate:
                    provinceBehaviour.TintColor(new Color32(211, 232, 211, 255));
                    break;
            }
            
        }
    }
}
