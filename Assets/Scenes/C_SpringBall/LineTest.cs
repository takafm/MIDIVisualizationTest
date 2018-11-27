using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			var seq1 = DOTween.Sequence ()
			.Append ( transform.DOMove ( new Vector3(2.0f, 2.0f, -0.1f), 0.25f ) )
			.Append ( transform.DOMove ( new Vector3(0.0f, 0.0f, -0.1f), 0.25f ) );
			seq1.Play();
		}
	}
}
