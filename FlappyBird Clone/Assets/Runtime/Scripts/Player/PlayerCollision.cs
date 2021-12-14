using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Collider2D sensorCollider;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameManager.OnGameOver();
        }
        
        if(collision.gameObject.CompareTag("ScoreSensor"))
        {
            gameManager.scoreUpdate++;
        }
    }
}
