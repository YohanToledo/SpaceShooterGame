using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{

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
