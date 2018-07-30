using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGenerator : MonoBehaviour {

	public float size = 1;
	public int gridSize = 16;

	private MeshFilter filter;

	private void Start () {
		filter = GetComponent<MeshFilter>();
		filter.mesh = GenerateMesh();
	}

//	void Update () {
//		
//	}
	
	private Mesh GenerateMesh() {
		
		Mesh mesh = new Mesh();
		
		var vertices = new List<Vector3>();
		var normals = new List<Vector3>();
		var uvs = new List<Vector2>();

		for (int x = 0; x < gridSize+1; x++) {
			for (int y = 0; y < gridSize+1; y++) {
				vertices.Add(new Vector3(
					-size * .5f + size * (x / (float)gridSize), 0, -size * .5f + size * (y / (float)gridSize)));
				normals.Add(Vector3.up);
				uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
			}
		}

		var triangles = new List<int>();
		int verticesCount = gridSize + 1;

		for (int i = 0; i < verticesCount * verticesCount - verticesCount; i++) {
			if ((i + 1) % verticesCount == 0)
				continue;
			
			triangles.AddRange(new List<int>() {
				i+1+verticesCount, i+verticesCount, i,
				i, i+1, i+verticesCount + 1
			});
		}
		
		mesh.SetVertices(vertices);
		mesh.SetNormals(normals);
		mesh.SetUVs(0, uvs);
		mesh.SetTriangles(triangles, 0);
		
		return mesh;
	}
}
