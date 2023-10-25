using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public int life = 30;
    public Transform skin;

    public GameObject bulletPrefab;
    public Transform[] guns;
    public float fireForce = 8f;

    private float fireDelay;
    private float time = 0;

    private PlayerController playerController;

    public AudioSource audioSource;
    public AudioClip explosionAudio;
    public AudioClip damageAudio;


    void Start()
    {
        fireDelay = 1.1f;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

        if (time > fireDelay)
        {
            foreach (Transform gun in guns)
            {
                Fire(gun);
            }
            time = 0;
        }

        time += Time.deltaTime;
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
        audioSource.PlayOneShot(damageAudio, 1);
        skin.GetComponent<Animator>().Play("Damage", -1);

        if (life <= 0)
        {
            playerController.scoreUp(5000);
            this.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            skin.GetComponent<Animator>().Play("Explosion", -1);
            audioSource.PlayOneShot(explosionAudio, 1);
            Invoke("OnExplosionAnimationFinished", 1f);
        }
    }

    void OnExplosionAnimationFinished()
    {
        Destroy(gameObject);
    }
}
