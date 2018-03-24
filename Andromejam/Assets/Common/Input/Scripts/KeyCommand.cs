using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommand : ScriptableObject, ICommand {

	public KeyCode Key {
		get {
			return key;
		}
	}
	[SerializeField]
	private KeyCode key;

	public static KeyCommand Create(KeyCode key) {
		KeyCommand res = ScriptableObject.CreateInstance<KeyCommand> ();
		res.key = key;
		return res;
	}

	public bool IsRisingEdge() {
		return Input.GetKeyDown (key);
	}

	public bool IsFallingEdge() {
		return Input.GetKeyUp (key);
	}

	public bool IsActive() {
		return Input.GetKey (key);
	}
}
