using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{

    public GameObject panel;

    public TextMeshProUGUI score;

    // Update is called once per frame
    void Update()
    {
        if (GameMechsScript.isGameOver)
        {
            panel.SetActive(true);
            score.text = GameMechsScript.score.ToString();
            if (PlayerPrefs.GetInt("highscore", 0) < GameMechsScript.score)
            {
                PlayerPrefs.SetInt("highscore", GameMechsScript.score);
            }
        } else
        {
            panel.SetActive(false);
        }
    }
}
