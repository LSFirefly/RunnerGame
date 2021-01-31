using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    public GameObject startTitle;
    private Animator playerAnim;
    private SpawnManager spawnManager;
    public Button resetButton;
    public bool isGameActive = false;

    // public float speed = 2;
    public float speed;

    void Start()
    {
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        scoreText.text = "Score: 0";
        livesText.text = "Lives: 3";
        startTitle.SetActive(false);
        speed +=  difficulty; 
        startTitle.gameObject.SetActive(false);




        spawnManager.itemSpawnInterval *= difficulty;

        playerAnim.SetInteger("AnimIndex", 1);
        playerAnim.SetTrigger("Next");
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
