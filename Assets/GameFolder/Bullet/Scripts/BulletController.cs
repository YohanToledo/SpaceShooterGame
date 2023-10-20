using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    private string currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals(currentScene))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!transform.parent.name.Equals(collision.transform.name))
        {
            Destroy(gameObject);

            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerController>().Damage(1);
            }

            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyController>().Damage(1);

            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
