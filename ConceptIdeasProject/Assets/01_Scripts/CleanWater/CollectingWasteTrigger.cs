using UnityEngine;
using UnityEngine.Events;

public class CollectingWasteTrigger : MonoBehaviour
{
    public UnityEvent PlasticCollect;
    public UnityEvent MetalCollect;
    public UnityEvent ElectronicCollect;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Plastic")) {
            PlasticCollect.Invoke();
        }
        else if (other.CompareTag("Metal")) {
            MetalCollect.Invoke();
        }
        else if (other.CompareTag("Electronic")) {
            ElectronicCollect.Invoke();
        }
    }
}
