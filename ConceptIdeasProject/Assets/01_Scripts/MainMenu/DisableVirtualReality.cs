using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class DisableVirtualReality : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(DeactivatorVR("none"));
        StartCoroutine(DisableVR());
    }

    //public IEnumerator DeactivatorVR(string NoVR) {
    //    XRSettings.LoadDeviceByName(NoVR);
    //    yield return null;
    //    //XRSettings.enabled = false;
    //    SteamVR.enabled = false;
    //}

    public IEnumerator DisableVR() {
        print("Disabling VR ...");
        SteamVR_Behaviour.instance.enabled = false;
        XRSettings.LoadDeviceByName("None");
        yield return null;
        XRSettings.enabled = false;
    }
}
