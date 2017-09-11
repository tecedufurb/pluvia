using UnityEngine;

public class Sun : MonoBehaviour {
    
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, 15f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
