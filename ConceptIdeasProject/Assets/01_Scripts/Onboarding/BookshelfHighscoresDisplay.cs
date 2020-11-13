using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookshelfHighscoresDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] _highscoreFields;
    BookshelfHighscores _bookshelfHighscoresManager;

    void Start() {
        for (int i = 0; i < _highscoreFields.Length; i++) {
            _highscoreFields[i].text = i + 1 + ". Fetching...";
        }

        _bookshelfHighscoresManager = GetComponent<BookshelfHighscores>();

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(BookshelfHighscores.BookshelfHighscore[] highscoreList) {
        for (int i = 0; i < _highscoreFields.Length; i++) {
            _highscoreFields[i].text = i + 1 + ". ";
            if (i < highscoreList.Length) {
                _highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores() {
        while (true) {
            _bookshelfHighscoresManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
