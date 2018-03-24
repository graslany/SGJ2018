using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

	private List<Platform> traversedPlatforms;
	private Animator animator;

	protected virtual void Awake() {

	}

	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	protected virtual void Update () {
		UpdateAnimation ();
		UpdateHorizontalMovement ();
		UpdateVerticalMovement ();
	}

	/// <summary>
	/// Met à jour l'animation du joueur.
	/// </summary>
	private void UpdateAnimation() {
		bool isGoingLeft = input.GoLeftCommand.IsActive ();
		bool isGoingRight = input.GoRightCommand.IsActive ();

		// Animation
		animator.SetBool ("IsLeftPressed", isGoingLeft);
		animator.SetBool ("IsRightPressed", isGoingRight);
	}

	/// <summary>
	/// Met à jour le déplacement horizontal du joueur.
	/// </summary>
	private void UpdateHorizontalMovement() {
		
		bool isGoingLeft = input.GoLeftCommand.IsActive ();
		bool isGoingRight = input.GoRightCommand.IsActive ();
		float desiredHorizontalSpeed = 0;
		if (isGoingLeft)
			desiredHorizontalSpeed = -maxSpeed;
		else if (isGoingRight)
			desiredHorizontalSpeed = maxSpeed;
		Rigidbody2D rBody = GetComponent<Rigidbody2D> ();
		rBody.velocity = new Vector2 (desiredHorizontalSpeed, rBody.velocity.y);

	}

	/// <summary>
	/// Met à jour le déplacement vertical du joueur.
	/// </summary>
	private void UpdateVerticalMovement() {
		
		// Est-on sur le sol ?
		LayerMask mask = LayerMask.GetMask (new string[] { Layers.PlatformsLayerName });
		Collider2D ground = Physics2D.OverlapBox (playerFeetPosition.position, new Vector2(playerWidth, 0.1f), 0, mask);
		bool groundedThisFrame = (ground != null);

		// Saut
		if (groundedThisFrame && input.JumpCommand.IsRisingEdge()) {
			Rigidbody2D rBody = GetComponent<Rigidbody2D> ();
			rBody.velocity = new Vector2 (rBody.velocity.x, jumpSpeed);
		}

		// Descente
		if (groundedThisFrame && input.DropCommand.IsRisingEdge()) {
			Platform[] platformsUnderPlayer = GetPlatformsUnderPlayer (); ground.GetComponent<Platform> ();

			if (platformsUnderPlayer.Length > 0) {

			}
		}
	}

	private Platform[] GetPlatformsUnderPlayer() {
		
		LayerMask mask = LayerMask.GetMask (new string[] { Layers.PlatformsLayerName });
		ContactFilter2D filter = new ContactFilter2D();
		filter.layerMask = mask;
		Collider2D[] colliders = new Collider2D[5];
		int collCount = Physics2D.OverlapBox (playerFeetPosition.position, new Vector2(playerWidth, 0.1f), 0, filter, colliders);
		if (collCount > colliders.Length) {
			colliders = new Collider2D[collCount];
			collCount = Physics2D.OverlapBox (playerFeetPosition.position, new Vector2(playerWidth, 0.1f), 0, filter, colliders);
		}

		return colliders.
			Take(collCount).
			Select(coll => coll.GetComponent<Platform>()).
			Where(p => p != null && p.IsActive).
			ToArray();
		
	}
}
