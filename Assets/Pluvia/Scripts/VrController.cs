using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class VrController : MonoBehaviour {
    
    enum SDKType {
        Cardboard, None
    }

    [SerializeField] private SDKType VrType;

    void Start() {
        StartCoroutine(ChangeVrSdk());
    }

    private IEnumerator ChangeVrSdk() {
        XRSettings.LoadDeviceByName(VrType.ToString());
        yield return null;
        XRSettings.enabled = true;
    }

}
