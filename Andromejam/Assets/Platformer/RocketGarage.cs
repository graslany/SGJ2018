using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketGarage : MonoBehaviour {

	public Rocket rocket;
	public Transform upperDoor;
	public Transform lowerDoor;

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
		while (Time.time < startTime + 6) {
			float moveSpeed = 1.5f;
			upperDoor.localPosition += Vector3.up * Time.deltaTime * moveSpeed;
			lowerDoor.localPosition -= Vector3.up * Time.deltaTime * moveSpeed;
			yield return null;
		}

		// Lancement de la fusée
		rocket.Fire ();

		// Tempo + changement de niveau
		yield return new WaitForSeconds (6);
		SceneManager.LoadScene ("Odyssey");
	}
}
