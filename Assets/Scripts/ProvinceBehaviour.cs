using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class ProvinceBehaviour : MonoBehaviour
{
    public Province province;
    
    private SpriteRenderer _sprite;
    
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        province.fortressState = 0;
        province.economicState = 1;
        province.militaryPower = 0;
        province.provincePower = province.militaryPower + 10000 * (province.fortressState + 1);
    }

    private void OnMouseDown()
    {
        ShowProvinceInfo();
   }

    public void TintColor(Color32 color)
    {
        _sprite.color = color;
        _sprite.material.color = color;
    }
    private void ShowProvinceInfo()
    {
        GameObject provinceDataField = GameObject.Find("ProvinceDataField");
        provinceDataField.GetComponent<TextMeshProUGUI>().text = "Інформація про провінцію:<br><br>Назва: "+ province.getStringName() +
                                                                 "<br><br>Економічне становище: "+ province.economicState +
                                                                 "<br><br>Рівень укріплень: "+ province.fortressState +
                                                                 "<br><br>Сила війск: "+ province.militaryPower +
                                                                 "<br><br>Захисна сила: "+province.provincePower;
    }
    private void OnDrawGizmos()
    {
        province.name = this.name;
        this.tag = "Province";
        province.provincePower = province.militaryPower + 10000 * (province.fortressState + 1);
    }
}
