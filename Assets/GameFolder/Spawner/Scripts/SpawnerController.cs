using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private float queueTime = 5f;
    private float time = 0;
    public GameObject enemy;


    void Update()
    {
        if (time > queueTime)
        {
            GameObject gameObject = Instantiate(enemy);
            gameObject.transform.position = transform.position + new Vector3(0, 0, 0);

            time = 0;

            Destroy(gameObject, 18);
        }

        time += Time.deltaTime;
    }
}