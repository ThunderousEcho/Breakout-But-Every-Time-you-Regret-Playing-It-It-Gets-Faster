using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Backdrop : MonoBehaviour {

    SpriteRenderer spriteRenderer;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        float h, s, v;
        Color.RGBToHSV(spriteRenderer.color, out h, out s, out v);
        h += Time.deltaTime * CameraController.intensityMultiplier;
        spriteRenderer.color = Color.HSVToRGB(h, 0.5f, 1);
    }
}
