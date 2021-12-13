using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private PlayerControlAnim playerAnim;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int scoreUpdate = 0;
    private bool startGame;
    public bool isScoring = false;
    public bool StartGame { get => startGame; private set => startGame = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }

    private bool gameOver;
    

    // Start is called before the first frame update
    void Awake()
    {
        scoreText.text = " " + scoreUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isScoring);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.enabled = true;
            startGame = true;
            playerAnim.StopFly();
            if (isScoring == true)
            {
                UpdateScore();
            }
                
        }

    }

    public void OnGameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        Debug.Log(GameOver);
    }

    private void UpdateScore()
    {
        scoreUpdate++;
        scoreText.text = " " + scoreUpdate;
        isScoring = false;
    }
}
