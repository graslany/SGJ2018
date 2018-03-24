using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisCommand : ScriptableObject, IUpdateListener, ICommand {

	public string AxisName {
		get {
			return axisName;
		}
	}
	[SerializeField]
	private string axisName;

	private bool activeLastFrame;
	private bool activeThisFrame;

	public static AxisCommand Create(string axisName) {
		AxisCommand res = ScriptableObject.CreateInstance<AxisCommand> ();
		res.axisName = axisName;
		return res;
	}

	protected virtual void OnEnable() {
		UpdateCallback.listeners.Add(this);
	}

	protected virtual void OnDisable() {
		UpdateCallback.listeners.Remove(this);
	}

	public bool IsRisingEdge() {
		return !activeLastFrame && activeThisFrame;
	}

	public bool IsFallingEdge() {
		return activeLastFrame && !activeThisFrame;
	}

	public bool IsActive() {
		return Input.GetAxis (axisName) > 0.5f;
	}

	void IUpdateListener.UpdateCallback() {
		activeLastFrame = activeThisFrame;
		activeThisFrame = IsActive();
	}
}
