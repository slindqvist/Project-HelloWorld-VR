using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveUserInputs : MonoBehaviour
{
    public TMP_InputField _inputFieldText;
    string _usernameText;

    private void Start() {
        _usernameText = PlayerPrefs.GetString("Username");
        _inputFieldText.text = _usernameText;
    }

    public void SaveInfo() {
        _usernameText = _inputFieldText.text;
        PlayerPrefs.SetString("Username", _usernameText);
    }
}
