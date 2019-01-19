using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMechsScript : MonoBehaviour
{

    public Text scoreText;

    public static int score;

    public static int bulletNumber;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bulletNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
