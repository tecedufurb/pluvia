using UnityEngine;

public class MakeSomeNoise : MonoBehaviour {

	public float power = 3;
	public float scale = 1;
	public float timeScale = 1;

	private float offsetX;
	private float offsetY;
	private MeshFilter mesh;
	
	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter>();
		MakeNoise();
	}

	// Update is called once per frame
	void Update () {
		MakeNoise();
		offsetX += Time.deltaTime * timeScale;
		offsetY += Time.deltaTime * timeScale;
	}
	
	private void MakeNoise() {
		Vector3[] vertices = mesh.mesh.vertices;

		for (int i = 0; i < vertices.Length; i++) {
			vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power;
		}

		mesh.mesh.vertices = vertices;
	}

	private float CalculateHeight(float x, float y) {
		float cordX = x * scale + offsetX;
		float cordY = y * scale + offsetY;

		return Mathf.PerlinNoise(cordX, cordY);
	}
}
