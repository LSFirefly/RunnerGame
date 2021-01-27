using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
   // public float speed = 5.0f;
    public float horizontalInput;
    public float horizontalspeed = 5.0f;
    public float leftBoarder = -3.0f;
    public float rightBoarder = 3.0f;

    public int lives = 3;
    public int score = 0;
    //public bool gameOver = false;

    public AudioClip flowerSound;
    public AudioClip crashSound;
    public AudioClip gameOverSound;

    private AudioSource playerAudio;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;

    private GameManager gameManager;




    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBoarder)
        {
            transform.position = new Vector3(leftBoarder, transform.position.y, transform.position.z);
        }

        if (transform.position.x > rightBoarder)
        {
            transform.position = new Vector3(rightBoarder, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");

        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * horizontalspeed);
            //transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * horizontalspeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flower")
        {
            score++;
            playerAudio.PlayOneShot(flowerSound);
            gameManager.scoreText.text = "Score: " + score;
        }
        if (other.tag == "Obstacle")
        {
            lives--;
            if (lives > 0) playerAudio.PlayOneShot(crashSound);
            explosionParticle.Play();
            gameManager.livesText.text = "Lives: " + lives;
            if (lives == 0)
            {
                gameManager.GameOver();
                playerAudio.PlayOneShot(gameOverSound);
                gameManager.isGameActive = false;
                playerAnim.SetInteger("AnimIndex", 2);
                playerAnim.SetTrigger("Next");
            }
        }
        Destroy(other.gameObject);
    }


}
