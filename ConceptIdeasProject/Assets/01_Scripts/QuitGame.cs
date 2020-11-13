using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuitGame : MonoBehaviour
{
    const string _clearCleanWaterWebURL = "http://dreamlo.com/lb/Bnh5F_gCikq52sWu6dBb-wgeQxiAC_ske6vpn5_YjjAA/clear";
    const string _clearBookshelfWebURL = "http://dreamlo.com/lb/CT27V4-jn0WBtQtf_MYBxwcO5fU2yHCUOm89oRnC1r6A/clear";

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
            StartCoroutine(ClearCleanWaterHighscores(_clearCleanWaterWebURL));
            StartCoroutine(ClearBookshelfHighscores(_clearBookshelfWebURL));
        }
    }

    private IEnumerator ClearCleanWaterHighscores(string uri) {
        using (UnityWebRequest www = UnityWebRequest.Get(uri)) {
            yield return www.SendWebRequest();
        }
    }

    private IEnumerator ClearBookshelfHighscores(string uri) {
        using (UnityWebRequest www = UnityWebRequest.Get(uri)) {
            yield return www.SendWebRequest();
        }
    }
}
