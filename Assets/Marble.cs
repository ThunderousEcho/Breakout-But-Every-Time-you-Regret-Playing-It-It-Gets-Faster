using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour {

    MarbleType type;
    public enum MarbleType {
        Points,
        ScaleUp,
        ScaleDown
    }

    void Start() {
        type = (MarbleType)Random.Range(0, 3);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        switch (type) {
            case MarbleType.Points:
                Score.ChangeScore(1000, transform.position);
                break;
            case MarbleType.ScaleUp:
                if (collision.collider.tag.Equals("Paddle")) {
                    Destroy(gameObject);
                    var k = collision.collider.transform.localScale;
                    if (k.x < 0.375f) {
                        k.x *= 2;
                        collision.collider.transform.localScale = k;
                    } else {
                        Score.ChangeScore(1, transform.position);
                    }
                }
                break;
            case MarbleType.ScaleDown:
                if (collision.collider.tag.Equals("Paddle")) {
                    Destroy(gameObject);
                    var k = collision.collider.transform.localScale;
                    k.x *= 0.5f;
                    collision.collider.transform.localScale = k;
                }
                break;
        }
    }
}
