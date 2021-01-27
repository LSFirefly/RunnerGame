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
    private float itemSpawnInterval = 0.3f;
    private float treeSpawnInterval = 1.5f;
    private float treeStartDelay = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomItem", itemStartDelay, itemSpawnInterval);
        InvokeRepeating("SpawnRandomTree", treeStartDelay, treeSpawnInterval);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

    }
    
    void SpawnRandomTree()
    {
        if (gameManager.isGameActive)
        {
            int treesIndex = Random.Range(0, trees.Length);
            Vector3 itemPos1 = new Vector3(Random.Range(-6, -4), 0, player.transform.position.z + 7);
            Vector3 itemPos2 = new Vector3(Random.Range(4, 6), 0, player.transform.position.z + 7);

            Instantiate(trees[treesIndex], itemPos1, trees[treesIndex].transform.rotation);
            Instantiate(trees[treesIndex], itemPos2, trees[treesIndex].transform.rotation);
        }
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
