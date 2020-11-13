using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTestHighscore : MonoBehaviour
{
    Highscores _highscores;
    ScoreManager _scoreManager;

    private void Start() {
        _highscores = FindObjectOfType<Highscores>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            int score = Random.Range(0, 2000);
            string username = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < Random.Range(5, 10); i++) {
                username += alphabet[Random.Range(0, alphabet.Length)];
            }

            _highscores.AddNewHighscore(username, score);
        }
    }
}
