using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMaker : MonoBehaviour {

    public Brick[] brickPrefabs;
    public Explosion altExplosionPrefab;


    void Start() {
        for (int x = -4; x < 4; x++) {
            float _x = (x + 0.5f) * 0.125f;
            for (int y = 0; y < 12; y++) {
                float _y = y * 0.0625f;
                if (Random.Range(0, 2) == 0) {
                    SpawnBrick(new Vector3(_x, _y), new Vector3(2, 1, 1));
                } else {
                    SpawnBrick(new Vector3(_x + 0.03125f, _y), Vector3.one);
                    SpawnBrick(new Vector3(_x - 0.03125f, _y), Vector3.one);
                }
            }
        }
    }

    private void Update() {
        if (Random.Range(0f, 1f) < Time.deltaTime) {
            int x = Random.Range(-4, 4);
            int y = Random.Range(0, 12);
            float _x = (x + 0.5f) * 0.125f;
            float _y = y * 0.0625f;

            if (!Physics2D.OverlapBox(new Vector2(_x, _y), new Vector2(0.0625f, 0.0625f), 0)) {
                if (Random.Range(0, 2) == 0) {
                    SpawnBrick(new Vector3(_x, _y), new Vector3(2, 1, 1));
                } else {
                    SpawnBrick(new Vector3(_x + 0.03125f, _y), Vector3.one);
                    SpawnBrick(new Vector3(_x - 0.03125f, _y), Vector3.one);
                }
                CameraController.RecalculateIntensityMultiplier();
            }
        }
    }

    void SpawnBrick(Vector3 position, Vector2 scale) {

        scale.x -= 0.125f;
        scale.y -= 0.125f;

        int brickType = Random.Range(0, brickPrefabs.Length + 1);
        if (brickType > 0)
            brickType--;
        var brick = Instantiate(brickPrefabs[brickType], position, Quaternion.identity);
        if (Random.Range(0, 2) == 0)
            brick.transform.Rotate(0, 180, 0);
        if (Random.Range(0, 2) == 0)
            brick.transform.Rotate(180, 0, 0);
        brick.transform.localScale = new Vector3(scale.x * brick.transform.localScale.x, scale.y * brick.transform.localScale.y);

        if (Random.Range(0, 25) == 0)
            brick.explosion = altExplosionPrefab;
    }
}
