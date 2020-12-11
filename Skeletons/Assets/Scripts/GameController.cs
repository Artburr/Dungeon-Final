using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject countdownScreen; 
    public GameObject controlsScreen;
    public TextMeshProUGUI coundownText;

    public int countdownStart;
    public UnityEvent resetGame;

    public UnityEvent OnGameStart;

    public PlayerControls playerControls;

    public static bool gameIsPaused;


    void Start()
    {
        startScreen.SetActive(true);
        endScreen.SetActive(false);
    }


    public void StartGame()
    {
        startScreen.SetActive(false);
        StartCoroutine(Countdown(countdownStart));
    }


    public void ResetGame()
    {
        resetGame.Invoke();
    }


    IEnumerator Countdown(int _start)
    {
        coundownText.text = _start.ToString();
        countdownScreen.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        for(int i = _start; i >= 0; i--)
        {
            coundownText.text = i.ToString();
            if (i < 1)
            {
                coundownText.text = "Start!";
            }
            yield return new WaitForSeconds(1.0f);
            yield return null;
        }
        countdownScreen.SetActive(false);
        OnGameStart.Invoke();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            controlsScreen.SetActive(true);
}
        else
        {
            Time.timeScale = 1;
            controlsScreen.SetActive(false);
        }
    }
}
