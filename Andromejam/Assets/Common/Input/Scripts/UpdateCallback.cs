using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Classe qui permet à des objets qui ne sont pas des MonoBehaviours d'exécuter du code pendant Update.
/// </summary>
public class UpdateCallback : MonoBehaviour {

	private static float lastUpdateTime = 0;

	public static readonly List<IUpdateListener> listeners = new List<IUpdateListener>();

	protected virtual void Update() {
		if (lastUpdateTime < Time.time) {
			lastUpdateTime = Time.time;
			foreach (IUpdateListener listener in listeners.Where(l => l != null)) {
				try {
					listener.UpdateCallback();
				} catch (System.Exception e) {
					Debug.LogError (e);
				}
			}
		}
	}

}
