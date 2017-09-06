using UnityEngine;

public class ToggleVrMode : MonoBehaviour {
    
    public void ToggleVr() {
        Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
    }

    public void MoveObject() {

    }
}
