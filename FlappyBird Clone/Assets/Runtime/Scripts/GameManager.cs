using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private PlayerControlAnim playerAnim;
    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreOnBox;
    [SerializeField] private TextMeshProUGUI scoreRecord;
    [Header("UI Objects")]
    [SerializeField] private GameObject mainTitle;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private List<GameObject> medals;

    [SerializeField] private AudioManager gameManagerSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip buttonClickSound;

    public int scoreUpdate = 0;
    private int betterScore;
    private bool startGame;
    public bool StartGame { get => startGame; private set => startGame = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }

    private bool gameOver;

    private void Awake()
    {
        betterScore = PlayerPrefs.GetInt("HighScore", scoreUpdate);
        scoreText.text = " " + scoreUpdate;
    }
   
    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = " " + scoreUpdate;
        
    }

    public void OnGameOver()
    {
        SaveState();
        SetMedals();
        scoreOnBox.text = scoreText.text;
        player.enabled = false;
        gameOver = true;
        gameOverText.SetActive(true);
        inGameUI.SetActive(false);
        StartCoroutine(OpenHUD());
    }

    public void StartPlay()
    {
        player.enabled = true;
        startGame = true;
        playerAnim.StopFly();
        mainTitle.SetActive(false);
        inGameUI.SetActive(true);

    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
    IEnumerator OpenHUD()
    {
        yield return new WaitForSeconds(2);
        HUD.SetActive(true);
        gameManagerSound.PlayAudio(gameOverSound);
    }

    private void SaveState()
    {
        if (scoreUpdate > betterScore)
        {
            PlayerPrefs.SetInt("HighScore", scoreUpdate);
            betterScore = PlayerPrefs.GetInt("HighScore", scoreUpdate);
        }
        scoreRecord.text = " " + betterScore;
    }

    public void ButtonSound()
    {
        gameManagerSound.PlayAudio(buttonClickSound);
    }

    private void SetMedals()
    {
       if(scoreUpdate  < 10 && scoreUpdate > 0)
        {
           medals[0].SetActive(true);
        }
       else if(scoreUpdate > 9 && scoreUpdate < 15)
        {
            medals[1].SetActive(true);
        }
       else if(scoreUpdate > 14 && scoreUpdate < 20)
        {
            medals[2].SetActive(true);
        }
       else if(scoreUpdate > 19)
        {
            medals[3].SetActive(true);
        }
       else
        {
            return;
        }
    }
}
