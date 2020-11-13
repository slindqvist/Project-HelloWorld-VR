using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class EnableVirtualReality : MonoBehaviour {
    // Start is called before the first frame update
    public void Start() {
        //StartCoroutine(ActivatorVR("openvr"));
        StartCoroutine(EnableVR());
    }

    //public IEnumerator ActivatorVR(string YesVR) {
    //    XRSettings.LoadDeviceByName("YesVR");
    //    yield return null;
    //    //XRSettings.enabled = true;
    //    SteamVR.enabled = true;
    //}

    public IEnumerator EnableVR() {
        print("Enabling VR...");
        SteamVR.Initialize(true);
        SteamVR_Behaviour.instance.enabled = true;
        XRSettings.LoadDeviceByName("OpenVR");
        yield return null;
        XRSettings.enabled = true;
    }
}
