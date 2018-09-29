using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public GameObject prefab;
    public Vector3 position;

	public void Trigger () {
        Instantiate(prefab, position, Quaternion.identity);
        //Destroy(gameObject);
	}
}
