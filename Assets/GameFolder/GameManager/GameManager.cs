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

    private bool isInvokedBoss;

    // Start is called before the first frame update
    void Start()
    {
        isInvokedBoss = false;
        if (SceneManager.GetActiveScene().name.Equals("Fase1"))
        { 
            InvokeRepeating("InstantiateEnemy", 1f, 2f);
        }
    }

    public void InstantiateEnemy()
    {
        Vector3 enemyPosition = new Vector3(Random.Range(minRange, maxRange), 6f);
        GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        Destroy(enemy, 20);


        if (SceneManager.GetActiveScene().name.Equals("Fase2") && !isInvokedBoss)
        {
            Invoke("InstantiateBoss", 2f);
            isInvokedBoss = true;
        }

    }

    public void InstantiateBoss()
    {
        print("teste");
        Instantiate(bossPrefab, new Vector3(0,9), Quaternion.identity);
    }
}
