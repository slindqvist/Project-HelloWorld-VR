using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private BookshelfHighscores _bookshelfHighscores;

    public GameObject _placeHolder;
    public float waitTime = 10f;

    // Username
    public string username = "";
    public TextMeshProUGUI _usernameText;
    
    public int _score;
    public Text _scoreText;

    private void Start() {
        _bookshelfHighscores = FindObjectOfType<BookshelfHighscores>();

        _score = 0;

        GenerateUsername();
    }

    public void AddPointsToScoreboard(int amount) {
        _score = _score + amount;
        _scoreText.text = _score.ToString();
    }

    public void GenerateUsername() {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = 0; i < 3; i++) {
            username += alphabet[Random.Range(0, alphabet.Length)];
        }
        _usernameText.text = username;
    }

    public IEnumerator GameOverCoroutine() {
        yield return new WaitForSeconds(waitTime);
        _placeHolder.SetActive(true);
        Debug.Log("Returning to start scene...");
    }
}
