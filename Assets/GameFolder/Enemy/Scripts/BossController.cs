using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private int life = 20;
    public Transform skin;

    public GameObject bulletPrefab;
    public Transform gun1;
    public Transform gun2;
    public Transform gun3;
    public Transform gun4;
    public float fireForce = 8f;
    private float moveSpeed = 0.2f;

    private float fireDelay;
    private float time = 0;

    private PlayerController playerController;


    void Start()
    {
        fireDelay = 1.2f;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        move();

        if (time > fireDelay)
        {
            Fire(gun1);
            Fire(gun2);
            Fire(gun3);
            Fire(gun4);
            time = 0;
        }

        time += Time.deltaTime;
    }

    void move()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }


    public void Fire(Transform gun)
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Rigidbody2D>().AddForce(-gun.up * fireForce, ForceMode2D.Impulse);
    }

    public void Damage(int damage)
    {
        life -= damage;
       
        if (life <= 0)
        {
            playerController.scoreUp(5000);
            this.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            skin.GetComponent<Animator>().Play("Explosion", -1);
            Invoke("OnExplosionAnimationFinished", 1f);
        }
    }

    void OnExplosionAnimationFinished()
    {
        Destroy(gameObject);
    }
}
