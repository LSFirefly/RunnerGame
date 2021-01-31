using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] items;
    public GameObject player;
    private GameManager gameManager;

    private float itemStartDelay = 0.1f;
    public float itemSpawnInterval = 0.3f;
   
    void Start()
    {
        InvokeRepeating("SpawnRandomItem", itemStartDelay, itemSpawnInterval);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

    }
    
   

    void SpawnRandomItem()
    {
        if (gameManager.isGameActive)
        {
            int itemIndex = Random.Range(0, items.Length);
            Vector3 itemPos = new Vector3(Random.Range(-2, 3), 0, player.transform.position.z + 5);
           
            Instantiate(items[itemIndex], itemPos, items[itemIndex].transform.rotation);
        }   
    }
  
}
