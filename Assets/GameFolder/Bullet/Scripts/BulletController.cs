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

            if(transform.parent.name.Equals("Player") && collision.transform.name.Equals("Enemy"))
            {
                Destroy(gameObject);
            }

            if (transform.parent.name.Equals("Player") && collision.transform.name.Equals("Boss"))
            {
                Destroy(gameObject);
            }

            if (transform.parent.name.Equals("Boss") && collision.transform.name.Equals("Player"))
            {
                Destroy(gameObject);
            }

            if (transform.parent.name.Equals("Enemy") && collision.transform.name.Equals("Player"))
            {
                Destroy(gameObject);
            }



            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
                collision.GetComponent<PlayerController>().Damage(1);
            }

            if (transform.parent.name.Equals("Player") && collision.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                collision.GetComponent<EnemyController>().Damage(1);

            }

            if (transform.parent.name.Equals("Player") && collision.CompareTag("Boss"))
            {
                Destroy(gameObject);
                collision.GetComponent<BossController>().Damage(1);

            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
