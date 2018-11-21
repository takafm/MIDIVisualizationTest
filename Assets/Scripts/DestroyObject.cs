using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	[SerializeField] float lifeTime = 3.0f;

	void Start () {
		Destroy(gameObject, lifeTime);
	}
	
	void Update () {
		
	}
}
