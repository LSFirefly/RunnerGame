using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObstacle : MonoBehaviour
{
    GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (transform.position.z < player.transform.position.z - 5)
        {
            Destroy(gameObject);
        }
    }
}
