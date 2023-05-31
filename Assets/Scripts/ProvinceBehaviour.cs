using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class ProvinceBehaviour : MonoBehaviour
{
    public Province province;
    
    private SpriteRenderer _sprite;

    public Color32 colorRP;
    public Color32 colorG;
    public Color32 colorM;
    public Color32 colorH;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        colorRP = new Color32(252, 239, 234, 255);
        colorG = new Color32(255,235,205,255);
        colorM = new Color32(225, 243, 252, 255);
        colorH = new Color32(211, 232, 211, 255);
    }

    private void OnMouseDown()
    {
        _sprite.color = colorM;
    }
}
