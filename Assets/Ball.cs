using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [HideInInspector]
    public Vector2 velocity = Vector2.zero;
    float Speed {
        get{
          return 1.125f * CameraController.intensityMultiplier;
        }
    }
    public AudioClip hitSound;

    public float Radius {
        get {
            return transform.localScale.x * 0.5f;
        }
    }

    void Start() {
        velocity = Vector2.up * Speed;
    }

    private void Update() {

        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y)) {
            velocity.y += Time.deltaTime * 3.5f * Mathf.Sign(velocity.y);
            velocity = velocity.normalized * Speed;
        }

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, Radius, velocity, Speed * Time.deltaTime);
        if (hit.collider != null) {
            switch (hit.collider.tag) {
                case "Paddle":
                    if (hit.normal.y < -0.5f)
                        Score.ChangeScore((int)Random.Range(-100000 * Time.deltaTime, 100000 * Time.deltaTime), hit.point);
                    float paddleWidth = hit.collider.transform.localScale.x;
                    float offsetX = transform.position.x - hit.collider.transform.position.x;
                    float angle = offsetX * Mathf.PI * 0.5f / paddleWidth; //radians
                    velocity = new Vector2(Mathf.Sin(angle) * Speed, Mathf.Cos(angle) * Speed);
                    CameraController.shake += 0.0125f;
                    CameraController.chromaticAberration += 1.25f;
                    if (Random.Range(0, 100) == 0)
                        Score.ChangeScore(-500, hit.point);
                    break;
                default:
                    if (Vector2.Angle(velocity, hit.normal) > 90) {
                        velocity = Vector2.Reflect(velocity, hit.normal).normalized * Speed;
                        if (hit.collider.tag.Equals("Brick")) {
                            hit.collider.SendMessage("Break");
                        } else if (hit.collider.tag.Equals("Ball Kill")) {
                            Score.ChangeScore(-100, hit.point);
                        }
                        CameraController.shake += 0.025f;
                        CameraController.chromaticAberration++;
                    }
                    break;
            }
            AudioSource.PlayClipAtPoint(hitSound, hit.point);
            transform.position = hit.point + hit.normal * Radius;
        } else {
            transform.position = (Vector2)transform.position + velocity * Time.deltaTime;
        }
    }
}