using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Collider2D sensorCollider;

    [SerializeField] private AudioManager collisionAudio;
    [SerializeField] private AudioClip obstacleCollisionSound;
    [SerializeField] private AudioClip scoreUpdateSound;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            collisionAudio.PlayAudio(obstacleCollisionSound);
            gameManager.OnGameOver();
        }
        
        if(collision.gameObject.CompareTag("ScoreSensor"))
        {
            collisionAudio.PlayAudio(scoreUpdateSound);
            gameManager.scoreUpdate++;
        }
    }
}
