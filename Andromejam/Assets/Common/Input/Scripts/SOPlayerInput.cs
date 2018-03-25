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

	public ICommand DropCommand {
		get {
			return dropCommand;
		}
	}
	private ICommand dropCommand;

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
			KeyCommand.Create(KeyCode.Z),
			KeyCommand.Create(KeyCode.Space)
		});
		dropCommand = OrCommand.Create (new ICommand[] {
			KeyCommand.Create(KeyCode.DownArrow),
			KeyCommand.Create(KeyCode.S),
			KeyCommand.Create(KeyCode.LeftControl)
		});
	}
}

