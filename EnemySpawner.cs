using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject skullEnemyPrefab;

    [SerializeField]
    private GameObject slimeEnemyPrefab;

    [SerializeField]
    private float skullEnemyTimer = 1.5f;

    [SerializeField]
    private float slimeEnemyTimer = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(skullEnemyTimer, skullEnemyPrefab));
        StartCoroutine(spawnEnemy(slimeEnemyTimer, slimeEnemyPrefab));
    }

    private IEnumerator spawnEnemy(float intervalTimer, GameObject enemy)
    {
        yield return new WaitForSeconds(intervalTimer);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 100)
        {

            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-3f, 3f), Random.Range(-4f, 4f), 0), Quaternion.identity);
            StartCoroutine(spawnEnemy(intervalTimer, enemy));
        }
        


    }
}
