using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private float queueTime;
    private float time = 0;
    public GameObject enemy;

    private void Start()
    {
        //set queueTime 2 seconds in the first spawn
        queueTime = 2f;
    }


    void Update()
    {
        //change queue time to 5 seconds
        queueTime = 5f;

        if (time > queueTime)
        {
            GameObject gameObject = Instantiate(enemy);
            gameObject.transform.position = transform.position + new Vector3(0, 0, 0);

            time = 0;

            Destroy(gameObject, 24);
        }

        time += Time.deltaTime;
    }
}