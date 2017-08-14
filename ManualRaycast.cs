using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualRaycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hit;
		if(Physics.Raycast(transform.position, fwd, out hit, 20)){
			//Debug.Log("Hit something - point");
			//Debug.Log (hit.point);
			//print ("text coord");
			//print (hit.textureCoord);
			//Debug.Log("text coord 2");
			//ßDebug.Log (hit.textureCoord2);
			MeshCollider meshCollider = hit.collider as MeshCollider;
			if (meshCollider == null || meshCollider.sharedMesh == null) {
				return;
			}

			Mesh mesh = meshCollider.sharedMesh;
			Vector3[] vertices = mesh.vertices;
			int[] triangles = mesh.triangles;
			Vector3 p0 = vertices [triangles [hit.triangleIndex * 3 + 0]];
			Vector3 p1 = vertices [triangles [hit.triangleIndex * 3 + 1]];
			Vector3 p2 = vertices [triangles [hit.triangleIndex * 3 + 2]];
			Transform hitTransform = hit.collider.transform;
			p0 = hitTransform.TransformPoint (p0);
			p1 = hitTransform.TransformPoint (p1);
			p2 = hitTransform.TransformPoint (p2);
			Debug.DrawLine (p0, p1);
			Debug.DrawLine (p1, p2);
			Debug.DrawLine (p2, p0);
		}
	}
}
