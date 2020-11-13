using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CleanWaterTimer : MonoBehaviour
{
    private Highscores _highscores;

    ScoreManager _scoreManager;
    AudioManager _audioManager;

    public TextMeshProUGUI _timerText;
    public TextMeshProUGUI _gameOverText;
    public float _timeRemaining = 180f;

    public bool _timerIsRunning;
    private bool _gameOver;

    void Start()
    {
        _highscores = FindObjectOfType<Highscores>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        _gameOverText.enabled = false;
        _timerIsRunning = true;
        _gameOver = false;
    }

    void Update()
    {
        CountDownTimer();
    }

    public void CountDownTimer() {
        if(_timeRemaining > 0) {
            _timeRemaining -= Time.deltaTime;
            DisplayTime(_timeRemaining);
        }
        else if (!_gameOver) {
            // Game over text
            Debug.Log("Time has run out!");
            _timeRemaining = 0;

            _highscores.AddNewHighscore(_scoreManager.username, _scoreManager._points);

            _timerText.enabled = false;
            _gameOverText.enabled = true;
            _timerIsRunning = false;
            _audioManager.StopTimerCountdown();
            _audioManager.PlayGameOver();
            _gameOver = true;
            _scoreManager.StartCoroutine("GameOverCoroutine");
        }
    }

    void DisplayTime(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (minutes == 0 && seconds == 20) {
            _timerText.color = Color.red;
            // Play timer sound
            _audioManager.PlayTimerCountdown();
        }
    }
}
