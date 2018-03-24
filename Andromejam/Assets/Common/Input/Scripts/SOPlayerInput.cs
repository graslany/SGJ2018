using System;
using UnityEngine;

public class SOPlayerInput : ScriptableObject, IPlayerInput
{

	public ICommand GoLeftCommand {
		get {
			return goLeftCommand;
		}
	}
	private ICommand goLeftCommand;

	public ICommand GoRightCommand {
		get {
			return goRightCommand;
		}
	}
	private ICommand goRightCommand;

	public ICommand JumpCommand {
		get {
			return jumpCommand;
		}
	}
	private ICommand jumpCommand;

	protected virtual void OnEnable ()
	{
		goLeftCommand = OrCommand.Create (new ICommand[] {
			KeyCommand.Create(KeyCode.LeftArrow),
			KeyCommand.Create(KeyCode.Q)
		});
		goRightCommand = OrCommand.Create (new ICommand[] {
			KeyCommand.Create(KeyCode.RightArrow),
			KeyCommand.Create(KeyCode.D)
		});
		jumpCommand = OrCommand.Create (new ICommand[] {
			KeyCommand.Create(KeyCode.UpArrow),
			KeyCommand.Create(KeyCode.Space)
		});
	}
}

