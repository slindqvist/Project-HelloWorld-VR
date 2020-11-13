using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkeaBoxTrigger : MonoBehaviour
{
    private StartGUIManager _startGUIManager;

    private void Start() {
        _startGUIManager = FindObjectOfType<StartGUIManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            _startGUIManager.IKEABoxFadeOut();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Item") {
            _startGUIManager.IKEABoxFadeIn();
        }
    }
}
