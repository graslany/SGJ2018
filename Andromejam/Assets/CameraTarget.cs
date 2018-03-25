using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

	[Tooltip("Indique si le suivi par la caméra est actif pour cet objet")]
	public bool enableFollowing = false;

	[Tooltip("Indique si la caméra suiveuse doit être automatiquement affectée " +
		"avec la caméra principale si elle est indéfinie")]
	public bool autoSetCamera = true;

	[Tooltip("Caméra suiveuse qui va regarder cet objet")]
	public Camera followerCamera;

	// Indique si le script a déjà présenté un message parce que la caméra était introuvable.
	private bool notifiedCameraLookupFailure;

	protected virtual void Update () {
		if (enableFollowing) {
			Camera currentCam = GetFollowerCamera ();
			if (currentCam != null) {
				Vector3 thisObjectPos = transform.position;
				Vector3 camPos = currentCam.transform.position;
				camPos.x = thisObjectPos.x;
				camPos.y = thisObjectPos.y;
				currentCam.transform.position = camPos;
			} else if (!notifiedCameraLookupFailure) {
				notifiedCameraLookupFailure = true;
				Debug.LogError ("Caméra manquante pour réaliser le suivi de cible.");
			}
		}
	}

	private Camera GetFollowerCamera() {
		if (autoSetCamera) {
			followerCamera = (followerCamera  != null ? followerCamera : Camera.main);
		}
		return followerCamera;
	}
}
