using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Explosion explosion;
    public GameObject marble;
    public void Break() {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        CameraController.chromaticAberration += 5f;
        Score.ChangeScore(25, transform.position);
        if (Random.Range(0, Mathf.CeilToInt(10 / CameraController.intensityMultiplier)) == 0) {
            Instantiate(marble, transform.position, Quaternion.identity);
        }

        CameraController.RecalculateIntensityMultiplier();
    }
}
