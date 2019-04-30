using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MeshCollider))]

public class WaveCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
	}
}
