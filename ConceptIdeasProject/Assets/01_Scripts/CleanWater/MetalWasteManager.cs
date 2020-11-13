using UnityEngine;
using TMPro;

public class MetalWasteManager : MonoBehaviour
{
    public TextMeshProUGUI _metalText;
    public int _metalCount;

    private Animator _metalAnimator;

    //public GameObject _metal;
    //public Transform _rod;
    //public Rigidbody _metalRigidbody;

    void Start() {
        _metalAnimator = GetComponentInChildren<Animator>();
        
        SetMetalCountText();

        _metalAnimator.SetBool("IsFull", false);
    }

    private void Update() {
        if (_metalCount == 0) {
            PlayMetalAnim();
        }
    }

    public void SetMetalCountText() {
        _metalText.text = _metalCount.ToString();
    }

    [ContextMenu("RecyclingFull")]
    public void PlayMetalAnim() {
        _metalAnimator.SetBool("IsFull", true);
    }

    //public void CollectMetalWaste() {
    //    _metal.transform.SetParent(_rod);
    //    _metalRigidbody.isKinematic = true;
    //    Debug.Log("Metal collected");
    //}

    //public void MetalDropZone() {
    //    _metal.transform.SetParent(null);
    //    _metalRigidbody.isKinematic = false;
    //    Debug.Log("Metal unparented");
    //}
}
