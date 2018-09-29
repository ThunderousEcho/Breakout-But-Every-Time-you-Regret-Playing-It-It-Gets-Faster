using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour {

    new Rigidbody2D rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float x = transform.position.x + Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        x = Mathf.Clamp(x, -0.5f + transform.localScale.x * 0.5f, 0.5f - transform.localScale.x * 0.5f);
        rigidbody.MovePosition(new Vector2(x, -0.7f));
    }
}
