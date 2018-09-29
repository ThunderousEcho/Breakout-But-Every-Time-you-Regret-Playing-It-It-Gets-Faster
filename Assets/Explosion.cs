using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float timetoLive = 5;

    void Update () {
        timetoLive -= Time.deltaTime;
        if (timetoLive <= 0)
            Destroy(gameObject);
    }
}
