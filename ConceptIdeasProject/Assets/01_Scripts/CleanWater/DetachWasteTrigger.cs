using UnityEngine;
using UnityEngine.Events;

public class DetachWasteTrigger : MonoBehaviour {

    public UnityEvent PlasticDrop;
    public UnityEvent MetalDrop;
    public UnityEvent ElectronicDrop;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Plastic")) {
            PlasticDrop.Invoke();
        }
        else if (other.CompareTag("Metal")) {
            MetalDrop.Invoke();
        }
        else if (other.CompareTag("Electronic")) {
            ElectronicDrop.Invoke();
        }
    }
}
