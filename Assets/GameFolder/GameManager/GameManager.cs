using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    private float minRange = -8f;
    private float maxRange = 8f;
    
    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 1f, 1f);
    }

    public void InstantiateEnemy()
    {
        Vector3 enemyPosition = new Vector3(Random.Range(minRange, maxRange), 6f);
        GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        Destroy(enemy, 20);
    }
}
