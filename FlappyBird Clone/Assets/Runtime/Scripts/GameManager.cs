using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private PlayerControlAnim playerAnim;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int scoreUpdate = 0;
    private bool startGame;
    public bool StartGame { get => startGame; private set => startGame = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }

    private bool gameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = " " + scoreUpdate;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.enabled = true;
            startGame = true;
            playerAnim.StopFly();
            
        }

        scoreText.text = " " + scoreUpdate;

    }

    public void OnGameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        Debug.Log(GameOver);
    }

   
}
