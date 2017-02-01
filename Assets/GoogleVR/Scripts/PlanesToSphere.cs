using UnityEngine;
using System.Collections;

public class PlanesToSphere : MonoBehaviour {

	public float radius;

	void Start() {
		Vector3[] positionArr = {
			new Vector3(0,0.5f,0),
			new Vector3(0,-0.5f,0),
			new Vector3(0,0,0.5f),
			new Vector3(0,0,-0.5f),
			new Vector3(0.5f,0,0),
			new Vector3(-0.5f,0,0)
		};

		Vector3[] rotationArr = {
			Vector3.zero,
			new Vector3(180,0,0),
			new Vector3(90,0,0),
			new Vector3(-90,0,0),
			new Vector3(0,0,-90),
			new Vector3(0,0,90)
		};

		for(int p = 0; p<6; p++)
		{
			//make 6 planes for the sphere in this loop
			GameObject newPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			newPlane.transform.SetParent(transform);
			newPlane.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
			newPlane.transform.position = positionArr[p];
			newPlane.transform.eulerAngles = rotationArr[p];
			Vector3[] vertices = newPlane.GetComponent<MeshFilter>().mesh.vertices;
			for (var i = 0; i < vertices.Length; i++)
			{
				vertices[i] = newPlane.transform.InverseTransformPoint(newPlane.transform.TransformPoint(vertices[i]).normalized * this.radius);
			}
			newPlane.GetComponent<MeshFilter>().mesh.vertices = vertices;
			newPlane.GetComponent<MeshFilter>().mesh.RecalculateNormals();
			newPlane.GetComponent<MeshFilter>().mesh.RecalculateBounds();
		}
	}
}