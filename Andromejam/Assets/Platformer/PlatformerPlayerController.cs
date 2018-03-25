using System.Collections;
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

	[Tooltip("Vitesse maximale du joueur")]
	public float jumpSpeed = 8;

	private static readonly float landingDistance = 1;
	bool wasGroundedLastFrame = true;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	protected virtual void Update () {

		// Calcul de la vitesse horizontale pour cette frame
		bool isGoingLeft = input.GoLeftCommand.IsActive ();
		bool isGoingRight = input.GoRightCommand.IsActive ();
		float desiredHorizontalSpeed = 0;
		if (isGoingLeft)
			desiredHorizontalSpeed = -maxSpeed;
		else if (isGoingRight)
			desiredHorizontalSpeed = maxSpeed;

		// Est-on sur le sol ?
		LayerMask mask = LayerMask.GetMask (new string[] { Layers.PlatformsLayerName });
		Collider2D ground = Physics2D.OverlapBox (playerFeetPosition.position, new Vector2(playerWidth, 0.1f), 0, mask);
		bool groundedThisFrame = (ground != null);

		UpdateAnimation (desiredHorizontalSpeed, groundedThisFrame);
		UpdateHorizontalMovement (desiredHorizontalSpeed);
		UpdateVerticalMovement (groundedThisFrame, ground);

		wasGroundedLastFrame = groundedThisFrame;
	}

	/// <summary>
	/// Met à jour l'animation du joueur.
	/// </summary>
	private void UpdateAnimation(float desiredHorizontalSpeed, bool groundedThisFrame) {
		
		animator.SetBool ("MovesHorizontally", desiredHorizontalSpeed != 0);

		if (groundedThisFrame && input.JumpCommand.IsRisingEdge ()) {
			animator.ResetTrigger ("LandingTrigger");
			animator.SetTrigger ("JumpTrigger");
		}

		bool isGoingDown = (GetComponent<Rigidbody2D> ().velocity.y < 0);
		RaycastHit2D hitResult = Physics2D.Raycast (playerFeetPosition.position, -Vector2.up, landingDistance);
		bool isLanding = (isGoingDown && hitResult.collider != null);
		animator.SetBool ("GroundClosing", isLanding);

		if (groundedThisFrame && !wasGroundedLastFrame) {
			animator.SetTrigger ("LandingTrigger");
			animator.ResetTrigger ("JumpTrigger");
		}
	}

	/// <summary>
	/// Met à jour le déplacement horizontal du joueur.
	/// </summary>
	private void UpdateHorizontalMovement(float desiredHorizontalSpeed) {
		
		Rigidbody2D rBody = GetComponent<Rigidbody2D> ();
		rBody.velocity = new Vector2 (desiredHorizontalSpeed, rBody.velocity.y);
		if (desiredHorizontalSpeed > 0) {
			Vector3 lScale = transform.localScale;
			lScale.x = 1;
			transform.localScale = lScale;
		} else if (desiredHorizontalSpeed < 0) {
			Vector3 lScale = transform.localScale;
			lScale.x = -1;
			transform.localScale = lScale;
		}
	}

	/// <summary>
	/// Met à jour le déplacement vertical du joueur.
	/// </summary>
	private void UpdateVerticalMovement(bool groundedThisFrame, Collider2D ground) {

		// Saut
		if (groundedThisFrame && input.JumpCommand.IsRisingEdge()) {
			Rigidbody2D rBody = GetComponent<Rigidbody2D> ();
			rBody.velocity = new Vector2 (rBody.velocity.x, jumpSpeed);
		}

		// Descente
		if (groundedThisFrame && input.DropCommand.IsRisingEdge()) {
			Platform platformUnderPlayer = ground.GetComponent<Platform> ();
			if (platformUnderPlayer != null) {
				platformUnderPlayer.DeactivateUntilPlayerLeaves ();
			}
		}
	}
}
