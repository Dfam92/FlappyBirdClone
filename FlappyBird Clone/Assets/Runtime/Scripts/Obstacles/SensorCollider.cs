using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCollider : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BoxCollider2D sensorCollider;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(gameManager.isScoring);
            gameManager.isScoring = true;
            this.sensorCollider.enabled = false;
        }
        
    }
}
