﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformerPlayerController : MonoBehaviour {

	public SOPlayerInput input;

	[Tooltip("Position des pieds du joueur")]
	public Transform playerFeetPosition;

	[Tooltip("Largeur du socle du joueur")]
	public float playerWidth = 1;

	[Tooltip("Vitesse maximale du joueur")]
	public float maxSpeed = 3;


	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	protected virtual void Update () {
		bool isGoingLeft = input.GoLeftCommand.IsActive ();
		bool isGoingRight = input.GoRightCommand.IsActive ();

		// Animation
		animator.SetBool ("IsLeftPressed", isGoingLeft);
		animator.SetBool ("IsRightPressed", isGoingRight);

		// Déplacement
		float desiredHorizontalSpeed = 0;
		if (isGoingLeft)
			desiredHorizontalSpeed = -maxSpeed;
		else if (isGoingRight)
			desiredHorizontalSpeed = maxSpeed;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (desiredHorizontalSpeed, 0);

		LayerMask mask = LayerMask.GetMask (new string[] { Layers.PlatformsLayerName });
		Collider2D ground = Physics2D.OverlapBox (playerFeetPosition.position, new Vector2(playerWidth, 0.1f), 0, mask);
		bool groundedThisFrame = (ground != null);
	}
}
