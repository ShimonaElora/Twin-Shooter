using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject[] enemies;

    public float[] enemySpeeds;

    public int maxEnemies;

    public float[] maxSpeeds;

    public Transform[] spawnPoints;

    public float spawnTimeDiff;

    public int[] timeInMinSpeedChange;

    public float[] speedDiff;

    public int[] timeInMinEnemyNumChange;

    private int numberOfEnemies;

    private float[] speeds;

    private bool speedChange, enemyNumChange;

    private int i, j;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSpawnTimeDiff());

        numberOfEnemies = 1;

        speedChange = true;
        enemyNumChange = true;

        i = 0;
        j = 0;

        speeds = enemySpeeds;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedChange)
        {
            speedChange = false;
            StartCoroutine(WaitForSpeedChange());
        }

        if (enemyNumChange)
        {
            enemyNumChange = false;
            StartCoroutine(WaitForEnemyNumChange());
        }
    }

    IEnumerator WaitForSpawnTimeDiff()
    {
        yield return new WaitForSeconds(spawnTimeDiff);

        SelectAndSpawn();

        StartCoroutine(WaitForSpawnTimeDiff());
    }

    IEnumerator WaitForSpeedChange()
    {
        yield return new WaitForSeconds(timeInMinSpeedChange[i] * 60);

        if (i < timeInMinSpeedChange.Length - 1)
        {
            i++;

            for (int k = 0; k < speeds.Length; k++)
            {
                if (speeds[k] + speedDiff[k] < maxSpeeds[k])
                {
                    speeds[k] = speeds[k] + speedDiff[k];
                }
            }

            speedChange = true;
        }
    }

    IEnumerator WaitForEnemyNumChange()
    {
        yield return new WaitForSeconds(timeInMinEnemyNumChange[j] * 60);

        if (j < timeInMinEnemyNumChange.Length - 1)
        {
            j++;
            
            if (numberOfEnemies < maxEnemies - 1)
            {
                numberOfEnemies++;
            }

            enemyNumChange = true;
        }
    }

    void SelectAndSpawn()
    {
        int numberOfEnemiesCurr = Random.Range(1, numberOfEnemies + 1);

        int selectedIndex;

        Transform[] selectedTransforms = SelectSpawnPoints(numberOfEnemiesCurr);

        for (int k = 0; k < numberOfEnemiesCurr; k++)
        {
            selectedIndex = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[selectedIndex], selectedTransforms[k]);
            enemy.transform.SetParent(transform);
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speeds[selectedIndex]);
        }

    }

    Transform[] SelectSpawnPoints(int num)
    {
        int selectedIndex;
        if (num == maxEnemies)
        {
            return spawnPoints;
        }
        else
        {
            Transform[] transforms = new Transform[4];
            for (int l = 0; l < spawnPoints.Length; l++)
            {
                transforms[l] = spawnPoints[l];
            }
            Transform[] selected = new Transform[num];
            for (int k = 0; k < num; k++)
            {
                Random.seed = System.DateTime.Now.Millisecond;
                selectedIndex = Random.Range(0, 4 - k);

                selected[k] = transforms[selectedIndex];
                Debug.Log(selected[k].position.x + " " + selectedIndex);
                for (int l = selectedIndex; l < 3; l++)
                {
                    transforms[l] = transforms[l + 1];
                }
                string values = "";
                for (int l = 0; l < transforms.Length; l++)
                {
                    values += transforms[l].position.x + " ";
                }

                Debug.Log(values);

            }
            return selected;
        }
    }

}
