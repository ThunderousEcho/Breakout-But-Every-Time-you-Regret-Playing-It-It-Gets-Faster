using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public MonoBehaviour[] toEnable;
    public GameObject[] toActivate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") != 0) {
            Destroy(gameObject);
            foreach (var e in toEnable)
                e.enabled = true;
            foreach (var a in toActivate)
                a.SetActive(true);
        }
	}
}
