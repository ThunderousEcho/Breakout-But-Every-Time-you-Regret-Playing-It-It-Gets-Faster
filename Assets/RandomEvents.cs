using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour {

    float timeToNextRandomEvent;

    private void Start() {
        timeToNextRandomEvent = Random.Range(5, 10);
    }

    private void Update() {
        timeToNextRandomEvent -= Time.deltaTime;
        if (timeToNextRandomEvent <= 0) {
            if (transform.childCount == 0) {
                Destroy(gameObject);
            } else {
                timeToNextRandomEvent += Random.Range(0, 10);
                int i = Random.Range(0, transform.childCount);
                var child = transform.GetChild(i);
                child.SendMessage("Trigger");
            }
        }
    }
}
