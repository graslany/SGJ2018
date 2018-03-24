using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput {

	ICommand GoLeftCommand { get; }
	ICommand GoRightCommand { get; }
	ICommand JumpCommand { get; }
}
