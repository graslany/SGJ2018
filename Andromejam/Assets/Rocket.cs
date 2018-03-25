using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	public SpriteRenderer flameRenderer;
	private bool isFired;

	private static readonly float flamePeriod = 0.5f;
	private static readonly float flameMinScale = 0.7f;

	private static readonly float acceleration = 0.5f;
	private float speed;

	public void Fire () {
		flameRenderer.enabled = true;
		speed = 0;
		isFired = true;
	}

	void Update () {
		if (isFired) {
			// Flammes
			float phase = (2 * Mathf.PI / flamePeriod * Time.time) - Mathf.PI / 2;
			float a = (1 - flameMinScale) * (Mathf.Sin(phase) + 1) / 2 ;
			flameRenderer.transform.localScale = Vector3.one * (flameMinScale + a);

			// Poussée
			speed += Time.deltaTime * acceleration;
			transform.position += (Time.deltaTime * speed) * Vector3.up;
		}
	}
}
