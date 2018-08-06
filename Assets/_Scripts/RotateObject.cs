using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	void Start () {
		StartCoroutine(RotateObjectInX(0, .1f));
	}

	private IEnumerator RotateObjectInX (float limit, float speed) {
		print(transform.eulerAngles.x);
		while (true) {
//			print("repete");
			transform.Rotate(Vector3.right * speed);
			yield return null;
		}
	}
}
