using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputController : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		animator.SetBool ("IsLeftPressed", Input.GetKey(KeyCode.LeftArrow));
		animator.SetBool ("IsRightPressed", Input.GetKey(KeyCode.RightArrow));
	}
}
