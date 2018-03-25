using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketGarage : MonoBehaviour {

	public Rocket rocket;
	public Transform upperDoor;
	public Transform lowerDoor;

	private bool launchendRocket;

	private static readonly float doorsOpeningDelay = 4.0f;
	private static readonly float takingOffDelay = 4.0f;
	private static readonly float doorsOpeningSpeed = 2.5f;

	protected virtual void OnTriggerEnter2D (Collider2D other) {
		PlatformerPlayerController player = other.GetComponentInChildren<PlatformerPlayerController> ();
		if (player == null) {
			player = other.GetComponentInParent<PlatformerPlayerController> ();
		}

		if (player != null) {
			player.gameObject.SetActive (false);
			StartCoroutine (RocketCoroutine (player));
		}
	}

	private IEnumerator RocketCoroutine (PlatformerPlayerController player) {
		
		// camera
		CameraTarget camControl = player.GetComponentInChildren<CameraTarget>();
		if (camControl != null)
			camControl.enableFollowing = false;
		Camera cam = Camera.main;
		if (cam != null) {
			Vector3 camPos = cam.transform.position;
			camPos.x = rocket.transform.position.x;
			camPos.y = rocket.transform.position.y;
			cam.transform.position = camPos;
		}

		// Ouverture des portes
		float startTime = Time.time;
		while (true) {
			float moveSpeed = doorsOpeningSpeed;
			upperDoor.localPosition += Vector3.up * Time.deltaTime * moveSpeed;
			lowerDoor.localPosition -= Vector3.up * Time.deltaTime * moveSpeed;

			// Lancement de la fusée
			if (Time.time >= startTime + doorsOpeningDelay && !launchendRocket) {
				launchendRocket = true;
				rocket.Fire ();
			}

			// Tempo + changement de niveau
			if (Time.time >= startTime + doorsOpeningDelay + takingOffDelay) {
				SceneManager.LoadScene ("Odyssey");
			}

			yield return null;
		}
	}
}
