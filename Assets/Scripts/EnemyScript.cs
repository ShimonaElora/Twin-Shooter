using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int enemyNumber;

    private Vector3 velocity;

    private Rigidbody2D rigidbody2D;

    private bool canAlterScore;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        velocity = rigidbody2D.velocity;

        canAlterScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMechsScript.isPaused)
        {
            rigidbody2D.velocity = Vector3.zero;
        }
        else
        {
            rigidbody2D.velocity = velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Boundary Bottom") || collision.gameObject.name.Equals("Player"))
        {
            GameMechsScript.isGameOver = true;
        } 

        else if (collision.gameObject.tag.Equals("Bullet " + enemyNumber) && !GameMechsScript.isGameOver)
        {
            if (canAlterScore)
            {
                canAlterScore = false;
                GameMechsScript.score++;
            }
            Destroy(gameObject);
        }
    }
}
