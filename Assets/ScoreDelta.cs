using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDelta : MonoBehaviour {

    Text text;
	void Start () {
        text = GetComponent<Text>();
    }
	
	void Update () {
        transform.position += Vector3.up * Time.deltaTime * Screen.height * 0.1f;
        var c = text.color;
        c.a -= Time.deltaTime;
        text.color = c;
        if (c.a <= 0)
            Destroy(gameObject);
    }
}
