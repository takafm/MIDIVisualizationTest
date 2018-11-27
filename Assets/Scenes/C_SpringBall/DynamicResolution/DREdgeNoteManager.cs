using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DREdgeNoteManager : MonoBehaviour {

	// Use this for initialization
	public float velocity;
	void Start () {
		var seq = DOTween.Sequence ()
		.Append ( transform.DOScale ( Vector3.one*0.7f, 0.25f ) ) // 円の大きさとか、velocityを反映しても面白い
		.Append ( transform.DOScale ( Vector3.zero, 0.25f ) );;
		seq.Play();

		Destroy(gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
