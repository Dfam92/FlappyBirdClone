using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float distanceImpulse;
    [SerializeField] private float flyTime;
    [SerializeField] private Vector3 startPos;
    private void Awake()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = PlayerMovimentation();
        if(Input.GetKeyDown(KeyCode.W))
        {
            position.y = PlayerMoveUp();
        }
        transform.position = position;
    }

    private float PlayerMovimentation()
    { 
        return transform.position.x + playerSpeed * Time.deltaTime;
    }
    private float PlayerMoveUp()
    {
        return distanceImpulse  + transform.position.y;
    }
}
