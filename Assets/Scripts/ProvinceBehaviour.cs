using System;
using System.Collections;
using System.Collections.Generic;
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
        province.provincePower = province.militaryPower + 10000 * (province.fortressState + 1);
    }

    private void OnMouseDown()
    {
        _sprite.color = new Color32(211, 232, 211, 255);
        _sprite.material.color = new Color32(211, 232, 211, 255);
    }

    public void TintColor(Color32 color)
    {
        _sprite.color = color;
        _sprite.material.color = color;
    }

    private void OnDrawGizmos()
    {
        province.name = this.name;
        this.tag = "Province";
    }
}
