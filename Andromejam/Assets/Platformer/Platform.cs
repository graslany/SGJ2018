using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public bool IsActive { get ; private set ; }

	private static readonly float deactivationDelay = 0.25f;
	float? deactivationDate;
	bool isPlayerInside;

	public void DeactivateUntilPlayerLeaves() {
		Debug.Log ("Deactivate");

		Collider2D myCollider = GetComponent<Collider2D> ();
		deactivationDate = Time.time;
		myCollider.isTrigger = true;
		IsActive = false;
	}

	protected virtual void OnEnable() {
		Collider2D myCollider = GetComponent<Collider2D> ();
		if (myCollider == null)
			Debug.LogError ("Il manque un collider à ce game object");
	}

	protected virtual void Update () {
		if (deactivationDate.HasValue && Time.time > deactivationDate.Value + deactivationDelay && !isPlayerInside)
			Reactivate ();
	}

	protected virtual void OnTriggerEnter() {
		Debug.Log ("Enter");
		isPlayerInside = true;
	}

	protected virtual void OnTriggerStay() {
		Debug.Log ("Stay");
		isPlayerInside = true;
	}

	protected virtual void OnTriggerExit() {
		isPlayerInside = false;
		Reactivate ();
	}

	private void Reactivate() {
		Debug.Log ("Reactivate");

		Collider2D myCollider = GetComponent<Collider2D> ();
		deactivationDate = null;
		myCollider.isTrigger = false;
		IsActive = true;
	}
}
