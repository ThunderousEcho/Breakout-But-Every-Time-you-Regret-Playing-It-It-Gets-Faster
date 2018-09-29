using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public void Trigger () {
        if (Random.Range(0, 3) == 0)
            Camera.main.transform.rotation = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward);
	}
}
