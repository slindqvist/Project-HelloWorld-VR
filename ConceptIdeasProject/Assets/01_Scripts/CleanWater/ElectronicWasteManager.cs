using UnityEngine;
using TMPro;

public class ElectronicWasteManager : MonoBehaviour
{
    public TextMeshProUGUI _electronicText;
    public int _electronicCount;

    private Animator _electronicAnimator;

    //public GameObject _electronic;
    //public Transform _rod;
    //public Rigidbody _electronicRigidbody;

    void Start() {
        _electronicAnimator = GetComponentInChildren<Animator>();
        
        SetElectronicCountText();

        _electronicAnimator.SetBool("IsFull", false);
    }

    private void Update() {
        if(_electronicCount == 0) {
            PlayElectronicAnim();
        }
    }

    public void SetElectronicCountText() {
        _electronicText.text = _electronicCount.ToString();
    }

    [ContextMenu("RecyclingFull")]
    public void PlayElectronicAnim() {
        _electronicAnimator.SetBool("IsFull", true);
    }

    //public void CollectElectronicWaste() {
    //    _electronic.transform.SetParent(_rod);
    //    _electronicRigidbody.isKinematic = true;
    //    Debug.Log("Electronic collected");
    //}

    //public void ElectronicDropZone() {
    //    _electronic.transform.SetParent(null);
    //    _electronicRigidbody.isKinematic = false;
    //    Debug.Log("Electronic unparented");
    //}
}
