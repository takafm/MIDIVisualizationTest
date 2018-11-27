using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTweenTest : MonoBehaviour {

	private Vector3 localGravity;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
		localGravity = new Vector3(-1.0f, -4.0f, 0.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (localGravity, ForceMode.Acceleration);
	}
}
