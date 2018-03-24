using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public SOPlayerInput input;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		animator.SetBool ("IsLeftPressed", input.GoLeftCommand.IsActive());
		animator.SetBool ("IsRightPressed", input.GoRightCommand.IsActive());

		RaycastHit2D hit = Physics2D.BoxCast (transform.position, new Vector2 (2, 0.01f), 0, new Vector2 (0, -1));
	}
}
