using UnityEngine;
using System.Collections;

public class testMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position -= new Vector3 (Time.deltaTime*4f, 0f, 0f);
	}
}
