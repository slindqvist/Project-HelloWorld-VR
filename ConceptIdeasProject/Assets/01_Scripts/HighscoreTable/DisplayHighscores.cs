using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighscores : MonoBehaviour
{
    public TextMeshProUGUI[] _highscoreFields;
    Highscores _highscoresManager;

    void Start()
    {
        for (int i = 0; i < _highscoreFields.Length; i++) {
            _highscoreFields[i].text = i + 1 + ". Fetching...";
        }

        _highscoresManager = GetComponent<Highscores>();

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscores.Highscore[] highscoreList) {
        for (int i = 0; i < _highscoreFields.Length; i++) {
            _highscoreFields[i].text = i + 1 + ". ";
            if (i < highscoreList.Length) {
                _highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores() {
        while (true) {
            _highscoresManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
