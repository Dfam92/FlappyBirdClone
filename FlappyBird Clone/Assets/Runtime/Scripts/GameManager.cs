using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private PlayerControlAnim playerAnim;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject mainTitle;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject gameOverText;
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
       scoreText.text = " " + scoreUpdate;
    }

    public void OnGameOver()
    {
        player.enabled = false;
        gameOver = true;
        //Time.timeScale = 0;
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
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
    IEnumerator OpenHUD()
    {
        yield return new WaitForSeconds(2);
        HUD.SetActive(true);
        gameOverText.SetActive(false);

    }
}
