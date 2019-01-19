using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayScript : MonoBehaviour
{

    TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();

        score.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }
}
