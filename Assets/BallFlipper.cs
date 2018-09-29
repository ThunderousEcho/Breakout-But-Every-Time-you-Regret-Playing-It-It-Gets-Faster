using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlipper : MonoBehaviour {

    public void Trigger() {
        var ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        Score.ChangeScore(0, ball.transform.position, name);
        ball.velocity.y = -ball.velocity.y;
        //Destroy(gameObject);
        //enabled = false;
    }
}
