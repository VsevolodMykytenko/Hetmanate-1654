using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TintProvinces();
            // ShowTowerTokens();
        }
    }

    void AddProvinceData ()
    {
        GameObject[] theArray = GameObject.FindGameObjectsWithTag("Province") as GameObject[];
        foreach (GameObject province in theArray)
        {
            provinceList.Add(province);
        }
        TintProvinces();
        // ShowTowerTokens();
    }
    
    void TintProvinces()
    {
        for (int i = 0; i < provinceList.Count; i++)
        {
            ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();
            
            GameObject soldierRP = GameObject.Find(provinceBehaviour.province.name + "_SoldierRP");
            GameObject soldierG = GameObject.Find(provinceBehaviour.province.name + "_SoldierG");
            GameObject soldierM = GameObject.Find(provinceBehaviour.province.name + "_SoldierM");
            GameObject soldierH = GameObject.Find(provinceBehaviour.province.name + "_SoldierH");
            soldierRP.GetComponent<SpriteRenderer>().enabled = false;
            soldierG.GetComponent<SpriteRenderer>().enabled = false;
            soldierM.GetComponent<SpriteRenderer>().enabled = false;
            soldierH.GetComponent<SpriteRenderer>().enabled = false;
            
            switch (provinceBehaviour.province.faction)
            {
                case Province.Factions.RichPospolita:
                    provinceBehaviour.TintColor(new Color32(252, 239, 234, 255));
                    if (provinceBehaviour.province.militaryPower != 0)
                    {
                        soldierRP.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    break;
                
                case Province.Factions.Hetmanate:
                    provinceBehaviour.TintColor(new Color32(255, 235, 205, 255));
                    if (provinceBehaviour.province.militaryPower != 0)
                    {
                        soldierG.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    break;
                
                case Province.Factions.Moscovy:
                    provinceBehaviour.TintColor(new Color32(225, 243, 252, 255));
                    if (provinceBehaviour.province.militaryPower != 0)
                    {
                        soldierM.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    break;
                
                case Province.Factions.Khanate:
                    provinceBehaviour.TintColor(new Color32(211, 232, 211, 255));
                    if (provinceBehaviour.province.militaryPower != 0)
                    {
                        soldierH.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    break;
            }
            
            GameObject tower1 = GameObject.Find(provinceBehaviour.province.name + "_Tower1");
            GameObject tower2 = GameObject.Find(provinceBehaviour.province.name + "_Tower2");
            
            switch (provinceBehaviour.province.fortressState)
            {
                case 0:
                    tower1.GetComponent<SpriteRenderer>().enabled = false;
                    tower2.GetComponent<SpriteRenderer>().enabled = false;
                    break;
                case 1:
                    tower1.GetComponent<SpriteRenderer>().enabled = true;
                    tower2.GetComponent<SpriteRenderer>().enabled = false;
                    break;
                case 2:
                    tower1.GetComponent<SpriteRenderer>().enabled = false;
                    tower2.GetComponent<SpriteRenderer>().enabled = true;
                    break;
            }
        }
    }

    // void ShowTowerTokens()
    // {
    //     for (int i = 0; i < provinceList.Count; i++)
    //     {
    //         ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();
    //         
    //         GameObject tower1 = GameObject.Find(provinceBehaviour.province.name + "_Tower1");
    //         GameObject tower2 = GameObject.Find(provinceBehaviour.province.name + "_Tower2");
    //         
    //         switch (provinceBehaviour.province.fortressState)
    //         {
    //             case 0:
    //                 tower1.GetComponent<SpriteRenderer>().enabled = false;
    //                 tower2.GetComponent<SpriteRenderer>().enabled = false;
    //                 break;
    //             case 1:
    //                 tower1.GetComponent<SpriteRenderer>().enabled = true;
    //                 tower2.GetComponent<SpriteRenderer>().enabled = false;
    //                 break;
    //             case 2:
    //                 tower1.GetComponent<SpriteRenderer>().enabled = false;
    //                 tower2.GetComponent<SpriteRenderer>().enabled = true;
    //                 break;
    //         }
    //         
    //     }
    // }
    //
    // void ShowSoldierTokens()
    // {
    //     for (int i = 0; i < provinceList.Count; i++)
    //     {
    //         ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();
    //     }
    // }
}
