using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpringSimulator : MonoBehaviour {
	
	Vector3 targetPos;
    Vector3 acc, vel;
	public Vector3 pos;

	void Start () {
		acc = vel = Vector3.zero;
		targetPos = new Vector3(0.0f, transform.position.y, -0.1f);
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void OnDrawGizmos ()
    {
        Gizmos.DrawLine (this.pos, this.targetPos);
    }

	void Update () {
        // Spring Simulation
        Vector3 diff = this.targetPos - this.pos;
        this.acc = diff * 0.1f;
        this.vel += this.acc;
        this.vel *= 0.9f;
        this.pos += this.vel;
        transform.position = this.pos;
	}
}
