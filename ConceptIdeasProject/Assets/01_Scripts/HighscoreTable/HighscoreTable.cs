using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HighscoreTable : MonoBehaviour {
    public Transform _entryContainer;
    public Transform _entryTemplate;
    //private List<HighscoreEntry> _highscoreEntryList;
    private List<Transform> _highscoreEntryTransformList;

    private void Awake() {
        //_entryContainer = transform.Find("HighscoreEntryContainer");
        //_entryTemplate = _entryContainer.Find("HighscoreEntryTemplate");

        _entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("HighscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j]._score > highscores.highscoreEntryList[i]._score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        _highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, _entryContainer, _highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 10f;
        Transform entryTransform = Instantiate(_entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            default:
                rankString = rank + "TH";
                break;

            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
        }

        entryTransform.Find("PosText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry._score;
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry._name;
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;

        // Set background visible odds and evens
        entryTransform.Find("BackgroundText").gameObject.SetActive(rank % 2 == 1);

        // Highlight First
        if (rank == 1) {
            entryTransform.Find("PosText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().color = Color.green;
        }

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { _score = score, _name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("HighscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("HighscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    // Represents a single highscore entry
    [Serializable]
    private class HighscoreEntry {
        public int _score;
        public string _name;
    }
}
