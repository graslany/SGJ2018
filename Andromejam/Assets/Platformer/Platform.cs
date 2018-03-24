using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public bool IsActive { get ; private set ; }

	private static readonly float deactivationDelay = 1.0f;
	float? deactivationDate;

	public void DeactivateUntilPlayerLeaves() {
		
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
		if (deactivationDate.HasValue && Time.time > deactivationDate.Value + deactivationDelay)
			Reactivate ();
	}

	private void Reactivate() {

		Collider2D myCollider = GetComponent<Collider2D> ();
		deactivationDate = null;
		myCollider.isTrigger = false;
		IsActive = true;
	}
}
