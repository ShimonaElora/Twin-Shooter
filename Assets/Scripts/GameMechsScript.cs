using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMechsScript : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public static int score;

    public static int bulletNumber;

    public static bool isPaused;

    public static bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bulletNumber = 0;
        isPaused = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
