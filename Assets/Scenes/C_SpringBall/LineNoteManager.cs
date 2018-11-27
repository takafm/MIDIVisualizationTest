using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineNoteManager : MonoBehaviour {

	public Vector3 rootPoint;
	public Vector3 endPoint; 
	// Use this for initialization
	void Start () {
		print("endPoint: "+endPoint);
		var seq = DOTween.Sequence ()
		.Append ( transform.DOMove ( endPoint, 0.25f ) )
		.Append ( transform.DOMove ( rootPoint, 0.25f ) );;
		seq.Play();

		Destroy(gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
