using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int life = 1;
    public Transform skin;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 5f;
    private float moveSpeed = 0.6f;

    private float fireDelay;
    private float time = 0;

    private PlayerController playerController;


    void Start()
    {
        fireDelay = Random.Range(0.9f, 2.6f);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        move();

        if (time > fireDelay)
        {
            Fire();
            time = 0;
        }

        time += Time.deltaTime;
    }

    void move()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }


    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void Damage(int damage)
    {
        life -= damage;
       
        if (life <= 0)
        {
            playerController.scoreUp(10);
            this.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            skin.GetComponent<Animator>().Play("Explosion", -1);
            Invoke("OnExplosionAnimationFinished", 0.5f);
        }
    }

    void OnExplosionAnimationFinished()
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
