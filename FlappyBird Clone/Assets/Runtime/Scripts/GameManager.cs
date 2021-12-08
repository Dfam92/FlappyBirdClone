using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private PlayerControlAnim playerAnim;
    private bool startGame;
    public bool StartGame { get => startGame; private set => startGame = value; }
    private bool gameOver;
    public bool GameOver { get => gameOver;  set => gameOver = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.enabled = true;
            startGame = true;
            playerAnim.StopFly();
        }
        
    }
}
