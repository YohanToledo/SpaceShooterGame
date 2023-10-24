using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int life = 5;
    private int playerScore = 0;
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private string currentScene;
   

    Vector2 moveDirection;
    

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 15f;

    public Transform skin;

    public Text playerLife;
    public Text playerScoreText;

    public GameObject gameOverScreen;
    public Transform pauseScreen;

    public AudioSource audioSource;
    public AudioClip explosionAudio;
    public AudioClip damageAudio;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        currentScene = SceneManager.GetActiveScene().name;
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals(currentScene))
        {
            life = 5;
            playerScore = 0;
            currentScene = SceneManager.GetActiveScene().name;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
            Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        playerLife.text = "x" + life.ToString();
        playerScoreText.text = playerScore.ToString() + " pontos";

        if (Input.GetButtonDown("Cancel"))
        {
            pauseScreen.GetComponent<PauseMenuController>().enabled = !pauseScreen.GetComponent<PauseMenuController>().enabled;
        }


        if (currentScene.Equals("Fase1") && playerScore >= 30)
        {
            SceneManager.LoadScene("Fase2");
        }

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
        audioSource.PlayOneShot(damageAudio, 1);

        life -= damage;

        if (life <= 0)
        {
            skin.GetComponent<Animator>().Play("Explosion", -1);
            audioSource.PlayOneShot(explosionAudio, 1);
            Invoke("OnExplosionAnimationFinished", 0.5f);
        }
    }

    public void scoreUp(int points)
    {
        playerScore += points;
    }

    void OnExplosionAnimationFinished()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        this.enabled = false;
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Damage(1);
            collision.GetComponent<EnemyController>().Damage(1);
        }
    }
}
