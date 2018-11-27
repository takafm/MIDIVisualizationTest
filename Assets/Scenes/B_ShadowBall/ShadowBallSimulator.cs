using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBallSimulator : MonoBehaviour {
	
	public Vector3 targetPos;
    Vector3 acc, vel, pos;
    public Vector3 localGravity;
    private Rigidbody rb;

	void Start () {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
		// acc = vel = Vector3.zero;
        // targetPos = Vector3.zero;
        // pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void OnDrawGizmos ()
    {
        Gizmos.DrawLine (this.pos, this.targetPos);
    }

    void FixedUpdate () {
        rb.AddForce (localGravity, ForceMode.Acceleration);
    }

	void Update () {
        // // Spring Simulation
        // Vector3 diff = this.targetPos - this.pos;
        // this.acc = diff * 0.1f;
        // this.vel += this.acc;
        // this.vel *= 0.9f;
        // this.pos += this.vel;
        // transform.position = this.pos;
	}
}
