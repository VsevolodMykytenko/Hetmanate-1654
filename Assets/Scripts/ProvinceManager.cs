using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Networking;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


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
        PhotonNetwork.SendRate = 50;
    }

    private void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             int [] randomArray = new int[64];
             for (int i = 0; i < 16; i++)
             {
                 randomArray[4*i] = Random.Range(0, 3);
                 randomArray[4*i+1] = Random.Range(0, 3);
                 randomArray[4*i+2] = Random.Range(0, 6);
                 randomArray[4*i+3] = Random.Range(0, 4);
             }
             
             StringBuilder aaaaaaaa = new StringBuilder();
             foreach (var i in randomArray)
             {
                 aaaaaaaa.Append(i + " ");
             }
             Debug.Log(aaaaaaaa.ToString());
             photonView.RPC("RandomProvinceDataFill", RpcTarget.All, randomArray);
             photonView.RPC("TintProvinces", RpcTarget.All, null);
             Debug.Log("Provinces are tinted");
         }
     }
    
     void AddProvinceData ()
     { 
         string[] nameArray = {"RP1","RP2","RP3","RP4","G1","G2","G3","G4","M1","M2","M3","M4","H1","H2","H3","H4"}; 
         for(int i = 0; i < 16; i++)
        {
            provinceList.Add(GameObject.Find(nameArray[i]));
        }
         TintProvinces();
    }

     [PunRPC]
     public void RandomProvinceDataFill(int[] randomArray)
     {
         for (int i = 0; i < provinceList.Count; i++)
         {
             ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();
             Debug.Log(provinceBehaviour.province.name.ToString());
             provinceBehaviour.province.fortressState = randomArray[4*i];
             provinceBehaviour.province.economicState = randomArray[4*i+1];
             provinceBehaviour.province.militaryPower = randomArray[4*i+2] * 5000;
             provinceBehaviour.province.provincePower = provinceBehaviour.province.militaryPower +
                                                        10000 * (provinceBehaviour.province.fortressState + 1);

             switch (randomArray[4*i+3])
             {
                 case 0:
                     provinceBehaviour.province.faction = Province.Factions.RichPospolita;
                     break;
                 case 1:
                     provinceBehaviour.province.faction = Province.Factions.Hetmanate;
                     break;
                 case 2:
                     provinceBehaviour.province.faction = Province.Factions.Moscovy;
                     break;
                 case 3:
                     provinceBehaviour.province.faction = Province.Factions.Khanate;
                     break;
             }
         }

     }

     [PunRPC]
    public void TintProvinces()
    {
        for (int i = 0; i < provinceList.Count; i++)
        {
            ProvinceBehaviour provinceBehaviour = provinceList[i].GetComponent<ProvinceBehaviour>();
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
