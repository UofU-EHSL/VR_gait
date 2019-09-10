using UnityEngine;
using Valve.VR;

namespace VRGait.Platforms
{
	public class PlatformGenerator
	{
		private Vector3[] _vertices;

		private int[] _triangles;

		private Vector2[] _uvs;

		public PlatformGenerator()
		{
			// Initialize some related arries.
			_vertices = new Vector3[4];
			_triangles = new int[6];
			_uvs = new Vector2[4];
		}

		// The order for points is counterClockwise: Bottom Left -> Bottom Right -> Top Right -> Top Left
		public GameObject GeneratePlatform(Vector3 pBottomLeft, Vector3 pBottomRight, Vector3 pTopRight, Vector3 pTopLeft, Material platformMaterial, Transform parent = null)
		{
			// Create a new Go and mark it as DontDestroyOnload
			var go = new GameObject("Platform", typeof(MeshFilter), typeof(MeshRenderer));
			Object.DontDestroyOnLoad(go);
			// Move the go to the right high place.
			go.transform.position = new Vector3(go.transform.position.x, pBottomLeft.y, go.transform.position.z);
			// Let the go becomes the child of elevator
			if (parent != null)
			{
				go.transform.parent = parent;
			}

			// Generate the vertices 2D Array
			var vertices2D = new Vector2[4]
			{
				new Vector2(pTopLeft.x, pTopLeft.z),
				new Vector2(pTopRight.x, pTopRight.z),
				new Vector2(pBottomRight.x, pBottomRight.z),
				new Vector2(pBottomLeft.x, pBottomLeft.z)
			};

			// Use the triangulator to get indices for creating triangles
			Triangulator tr = new Triangulator(vertices2D);
			_triangles = tr.Triangulate();

			// Create the Vector3 vertices
			_vertices = new Vector3[vertices2D.Length];
			for (int i = _vertices.Length - 1; i >= 0; --i)
			{
				_vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
			}

			// Assign the uvs based on the texture.
			_uvs[0] = new Vector2(0, 1);
			_uvs[1] = new Vector2(1, 1);
			_uvs[2] = new Vector2(1, 0);
			_uvs[3] = new Vector2(0, 0);

			// Create the mesh
			Mesh msh = new Mesh();
			msh.vertices = _vertices;
			msh.triangles = _triangles;
			msh.uv = _uvs;

			// Recalculate some mesh properties.
			msh.RecalculateNormals();
			msh.RecalculateBounds();

			// Set up game object with mesh;
			go.GetComponent<MeshFilter>().mesh = msh;
			go.GetComponent<MeshRenderer>().material = platformMaterial;

			// Rotate the plank around x axis 90 degrees.
			go.transform.Rotate(90, 0, 0);

			return go;
		}
	}
}