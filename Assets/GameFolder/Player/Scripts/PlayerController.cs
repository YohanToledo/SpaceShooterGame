using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int life = 5;
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
   

    Vector2 moveDirection;
    

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 15f;

    public Transform skin;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }


    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void Damage(int damage)
    {
        skin.GetComponent<Animator>().Play("Damage", -1);
        life -= damage;

        if (life <= 0)
        {
            skin.GetComponent<Animator>().Play("Explosion", -1);
            Invoke("OnExplosionAnimationFinished", 0.5f);
        }
    }

    void OnExplosionAnimationFinished()
    {
        Destroy(gameObject);
    }
}
