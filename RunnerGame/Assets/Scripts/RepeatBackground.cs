using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private GameManager gameManager;

    void Start()
    {
        startPos = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.isGameActive && transform.position.z < startPos.z - 8.93)
        {
            transform.position = startPos;
        }
    }
}
