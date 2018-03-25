using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrCommand : ScriptableObject, IUpdateListener, ICommand
{

	public List<ICommand> SubCommands {
		get {
			return subCommands;
		}
	}

	[SerializeField]
	private List<ICommand> subCommands;

	private bool activeLastFrame;
	private bool activeThisFrame;

	public static OrCommand Create (IEnumerable<ICommand> commands)
	{
		OrCommand res = ScriptableObject.CreateInstance<OrCommand> ();
		res.subCommands = new List<ICommand> ();
		if (commands != null)
			res.subCommands.AddRange (commands);
		return res;
	}

	protected virtual void OnEnable ()
	{
		UpdateCallback.listeners.Add (this);
	}

	protected virtual void OnDisable ()
	{
		UpdateCallback.listeners.Remove (this);
	}

	public bool IsRisingEdge ()
	{
		return !activeLastFrame && activeThisFrame;
	}

	public bool IsFallingEdge ()
	{
		return activeLastFrame && !activeThisFrame;
	}

	public bool IsActive ()
	{
		return subCommands.Any(c => c != null && c.IsActive());
	}

	void IUpdateListener.UpdateCallback ()
	{
		activeLastFrame = activeThisFrame;
		activeThisFrame = IsActive();
	}
}
