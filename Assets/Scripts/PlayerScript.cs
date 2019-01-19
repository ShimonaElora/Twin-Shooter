using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed = 1f;

    public float width;

    public float[] bulletSpeeds;
    public int[] timeInSecBulletSpawn;

    public Transform BulletParent;

    public Transform left;
    public Transform right;

    public GameObject[] bullets;

    public static bool shouldMoveLeft;
    public static bool shouldMoveRight;

    private float ratio;

    // Start is called before the first frame update
    void Start()
    {
        shouldMoveLeft = false;
        shouldMoveRight = false;

        ratio = Screen.height * 1f / Screen.width;

        StartCoroutine(ThrowBullets());
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMoveLeft && transform.position.x >= (-2.5 + width / 2))
        {
            Debug.Log("here");
            transform.position = new Vector3(transform.position.x - speed * 0.1f, transform.position.y, transform.position.z);
        }

        if (shouldMoveRight && transform.position.x <= (2.5 - width / 2))
        {
            Debug.Log("here1");
            transform.position = new Vector3(transform.position.x + speed * 0.1f, transform.position.y, transform.position.z);
        }

    }

    IEnumerator ThrowBullets()
    {
        yield return new WaitForSeconds(timeInSecBulletSpawn[GameMechsScript.bulletNumber % bullets.Length]);

        GameObject objectLeft = Instantiate(bullets[GameMechsScript.bulletNumber % bullets.Length], left);
        objectLeft.transform.SetParent(BulletParent);
        objectLeft.transform.localScale = bullets[GameMechsScript.bulletNumber % bullets.Length].transform.localScale;
        objectLeft.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeeds[GameMechsScript.bulletNumber % bullets.Length] * 0.1f, 0);

        GameObject objectRight = Instantiate(bullets[GameMechsScript.bulletNumber % bullets.Length], right);
        objectRight.transform.SetParent(BulletParent);
        objectRight.transform.localScale = bullets[GameMechsScript.bulletNumber % bullets.Length].transform.localScale;
        objectRight.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeeds[GameMechsScript.bulletNumber % bullets.Length] * 0.1f, 0);

        StartCoroutine(ThrowBullets());

    }

}
