using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreCounter;
    public Text scorePenaltyPrefab;

    public static Score main;

    void Start () {
        main = this;
    }

    void Update() {
        scoreCounter.transform.localScale = Vector3.one * Mathf.Lerp(scoreCounter.transform.localScale.x, 1, Time.deltaTime * 5);
    }

    public static void ChangeScore (int delta, Vector3 worldPosition, string forceText = null) {

        var t = Instantiate(main.scorePenaltyPrefab, Camera.main.WorldToScreenPoint(worldPosition), Quaternion.identity);
        
        t.transform.SetParent(main.transform.parent);

        if (forceText == null) {
            int fun = Random.Range(0, 100);
            switch (fun) {
                case 0:
                    delta = 0;
                    t.text = "999999999";
                    break;
                case 95:
                    delta = 0;
                    t.text = "0";
                    break;
                case 96:
                    delta = 0;
                    t.text = "???";
                    break;
                case 97:
                    delta = 0;
                    t.text = "numberwang";
                    break;
                case 98:
                    delta = 0;
                    t.text = "lasagna";
                    break;
                case 99:
                    delta = 0;
                    t.text = "5138008";
                    break;
                default:
                    if (fun <= 10)
                        delta = Random.Range(-100, 100);
                    t.text = delta.ToString();
                    break;
            }
        } else {
            t.text = forceText;
        }

        score += delta;
        main.scoreCounter.text = "Score: " + score;
        if (delta > 0)
            t.color = Color.green;
        else if (delta < 0)
            t.color = Color.red;
        main.transform.localScale = Vector3.one * (main.transform.localScale.x + 0.25f);
    }
}
