using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    private string currentScene;

    public AudioSource audioSource;
    public AudioClip shotAudio;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        audioSource.PlayOneShot(shotAudio, 1);
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
        string parentName = transform.parent.name;
        string collisionParentName = collision.transform.name;

        if(!parentName.Equals(collisionParentName))
        {
            if(parentName.Equals("Enemy") && collisionParentName.Equals("Boss") || parentName.Equals("Boss") && collisionParentName.Equals("Enemy"))
            {
                //do nothing
            }
            else
            {
                if (parentName.Equals("Enemy") && collision.CompareTag("Boss"))
                {
                    //do nothing

                }
                else if (parentName.Equals("Boss") && collision.CompareTag("Enemy"))
                {
                    //do nothing

                }
                else
                {
                    Destroy(gameObject);
                }
                
            }
        

            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
                collision.GetComponent<PlayerController>().Damage(1);
            }

            if (parentName.Equals("Player") && collision.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                collision.GetComponent<EnemyController>().Damage(1);

            }

            if (parentName.Equals("Player") && collision.CompareTag("Boss"))
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
