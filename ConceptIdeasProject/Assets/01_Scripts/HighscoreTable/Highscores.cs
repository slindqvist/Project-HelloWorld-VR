using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Highscores : MonoBehaviour {
    const string _privateCode = "Bnh5F_gCikq52sWu6dBb-wgeQxiAC_ske6vpn5_YjjAA";
    const string _publicCode = "5fa276c2eb371a09c4980a50";
    const string _webURL = "http://dreamlo.com/lb/";

    DisplayHighscores _highscoresDisplay;
    public Highscore[] _highscoresList;
    static Highscores instance;

    private void Awake() {
        _highscoresDisplay = GetComponent<DisplayHighscores>();
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
            _highscoresDisplay.OnHighscoresDownloaded(_highscoresList);
        }
        else {
            print("Error downloading: " + www.error);
        }
    }

    private void FormatHighscores(string textStream) {
        string[] entries = textStream.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        _highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++) {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            _highscoresList[i] = new Highscore(username, score);
            //print(_highscoresList[i].username + ": " + _highscoresList[i].score);
        }
    }

    public struct Highscore {
        public string username;
        public int score;

        public Highscore(string _username, int _score) {
            username = _username;
            score = _score;
        }
    }
}
