using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpringBallNoteManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			var seq1 = DOTween.Sequence ()
			.Append ( transform.DOScale ( Vector3.one, 0.25f ) )
			.Append ( transform.DOScale ( Vector3.zero, 0.25f ) );
			seq1.Play();
		}
	}
}
