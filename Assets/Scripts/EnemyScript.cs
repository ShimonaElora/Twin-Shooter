using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int enemyNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Boundary Bottom") || collision.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
            //gameover
        } 

        else if (collision.gameObject.tag.Equals("Bullet " + enemyNumber))
        {
            GameMechsScript.score++;
            Destroy(gameObject);
        }
    }
}
