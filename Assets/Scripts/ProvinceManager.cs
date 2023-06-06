using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Networking;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ProvinceManager : MonoBehaviour
{
    public static ProvinceManager instance;
    private PhotonView photonView;
    public List<GameObject> provinceList = new List<GameObject>();
    private void Awake()
    {
        instance = this;
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    { 
        AddProvinceData();
    }
    
     private void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             photonView.RPC("TintProvinces", RpcTarget.All, null);
             Debug.Log("Provinces are tinted");
         }
     }
     
     [PunRPC]
     public void ChangeColor()
     {
        for (int i = 0; i < provinceList.Count; i++)
         {
             ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();
             switch (provinceBehaviour.province.faction)
             {
                 case Province.Factions.RichPospolita:
                     provinceBehaviour.TintColor(new Color32(255, 235, 205, 255));
                     provinceBehaviour.province.faction = Province.Factions.Hetmanate;
                     break;

                 case Province.Factions.Hetmanate:
                     provinceBehaviour.TintColor(new Color32(225, 243, 252, 255));
                     provinceBehaviour.province.faction = Province.Factions.Moscovy;
                     break;
                 case Province.Factions.Moscovy:
                     provinceBehaviour.TintColor(new Color32(211, 232, 211, 255));
                     provinceBehaviour.province.faction = Province.Factions.Khanate;
                     break;

                 case Province.Factions.Khanate:
                     provinceBehaviour.TintColor(new Color32(252, 239, 234, 255));
                     provinceBehaviour.province.faction = Province.Factions.RichPospolita;
                     break;
             }
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
    }
     
    [PunRPC]
    public void TintProvinces()
    {
        for (int i = 0; i < provinceList.Count; i++)
        {
            ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();
            provinceBehaviour.province.fortressState = 2;
            GameObject soldierRP = GameObject.Find(provinceBehaviour.province.name + "_SoldierRP");
            GameObject soldierG = GameObject.Find(provinceBehaviour.province.name + "_SoldierG");
            GameObject soldierM = GameObject.Find(provinceBehaviour.province.name + "_SoldierM");
            GameObject soldierH = GameObject.Find(provinceBehaviour.province.name + "_SoldierH");
            GameObject soldierCounter = GameObject.Find(provinceBehaviour.province.name + "_SoldierCounter");
            soldierCounter.GetComponent<TextMeshProUGUI>().enabled = false;
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
                        soldierCounter.GetComponent<TextMeshProUGUI>().enabled = true;
                        soldierCounter.GetComponent<TextMeshProUGUI>().text = "x" + provinceBehaviour.province.militaryPower / 5000;
                    }
                    break;
                
                case Province.Factions.Hetmanate:
                    provinceBehaviour.TintColor(new Color32(255, 235, 205, 255));
                    if (provinceBehaviour.province.militaryPower != 0)
                    {
                        soldierG.GetComponent<SpriteRenderer>().enabled = true;
                        soldierCounter.GetComponent<TextMeshProUGUI>().enabled = true;
                        soldierCounter.GetComponent<TextMeshProUGUI>().text = "x" + provinceBehaviour.province.militaryPower / 5000;
                    }
                    break;
                
                case Province.Factions.Moscovy:
                    provinceBehaviour.TintColor(new Color32(225, 243, 252, 255));
                    if (provinceBehaviour.province.militaryPower != 0)
                    {
                        soldierM.GetComponent<SpriteRenderer>().enabled = true;
                        soldierCounter.GetComponent<TextMeshProUGUI>().enabled = true;
                        soldierCounter.GetComponent<TextMeshProUGUI>().text = "x" + provinceBehaviour.province.militaryPower / 5000;
                    }
                    break;
                
                case Province.Factions.Khanate:
                    provinceBehaviour.TintColor(new Color32(211, 232, 211, 255));
                    if (provinceBehaviour.province.militaryPower != 0)
                    {
                        soldierH.GetComponent<SpriteRenderer>().enabled = true;
                        soldierCounter.GetComponent<TextMeshProUGUI>().enabled = true;
                        soldierCounter.GetComponent<TextMeshProUGUI>().text = "x" + provinceBehaviour.province.militaryPower / 5000;
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
}
