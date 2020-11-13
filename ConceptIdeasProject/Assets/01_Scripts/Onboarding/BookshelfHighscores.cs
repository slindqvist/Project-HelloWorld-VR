using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class BookshelfHighscores : MonoBehaviour {
    const string _privateCode = "CT27V4-jn0WBtQtf_MYBxwcO5fU2yHCUOm89oRnC1r6A";
    const string _publicCode = "5fa84f0deb371a09c4c1e6f4";
    const string _webURL = "http://dreamlo.com/lb/";

    BookshelfHighscoresDisplay _bookshelfHighscoresDisplay;
    public BookshelfHighscore[] _bookshelfHighscoreslist;
    static BookshelfHighscores instance;

    private void Awake() {
        _bookshelfHighscoresDisplay = GetComponent<BookshelfHighscoresDisplay>();
        instance = this;
    }

    public void AddNewHighscore(string username, int score) {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score) {
        UnityWebRequest www = new UnityWebRequest(_webURL + _privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error)) {
            print("Upload successful");
            DownloadHighscores();
        }
        else {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores() {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    private IEnumerator DownloadHighscoresFromDatabase() {
        UnityWebRequest www = new UnityWebRequest(_webURL + _publicCode + "/pipe/");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error)) {
            //print(www.downloadHandler.text);
            FormatHighscores(www.downloadHandler.text);
            _bookshelfHighscoresDisplay.OnHighscoresDownloaded(_bookshelfHighscoreslist);
        }
        else {
            print("Error downloading: " + www.error);
        }
    }

    private void FormatHighscores(string textStream) {
        string[] entries = textStream.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        _bookshelfHighscoreslist = new BookshelfHighscore[entries.Length];

        for (int i = 0; i < entries.Length; i++) {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            _bookshelfHighscoreslist[i] = new BookshelfHighscore(username, score);
            //print(_bookshelfHighscoreslist[i].username + ": " + _bookshelfHighscoreslist[i].score);
        }
    }

    public struct BookshelfHighscore {
        public string username;
        public int score;

        public BookshelfHighscore(string _username, int _score) {
            username = _username;
            score = _score;
        }
    }
}
