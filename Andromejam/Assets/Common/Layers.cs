using System;
using System.Collections.Generic;
using UnityEngine;

public class Layers
{
	
	/// Identifiant du calque où sont placées les plateformes désactivées (parce que le joueur
	/// est en train de passer à travers typiquement).
	/// </summary>
	public static int DisabledPlatformsLayerID {
		get {
			return LayerMask.NameToLayer(disabledPlatformsLayerName);
		}
	}

	/// Nom du calque où sont placées les plateformes désactivées (parce que le joueur
	/// est en train de passer à travers typiquement).
	/// </summary>
	public static string DisabledPlatformsLayerName {
		get {
			return disabledPlatformsLayerName;
		}
	}
	private static readonly string disabledPlatformsLayerName = "Disabled platforms";

	/// <summary>
	/// Identifiant du calque où sont placées les plateformes désactivées (parce que le joueur
	/// est en train de passer à travers typiquement).
	/// </summary>
	public static int PlayerLayerID {
		get {
			return LayerMask.NameToLayer(playerLayerName);
		}
	}

	/// Nom du calque où sont placées les plateformes désactivées (parce que le joueur
	/// est en train de passer à travers typiquement).
	/// </summary>
	public static string PlayerLayerName {
		get {
			return playerLayerName;
		}
	}
	private static readonly string playerLayerName = "Player";

	/// Identifiant du calque où sont placées les plateformes désactivées (parce que le joueur
	/// est en train de passer à travers typiquement).
	/// </summary>
	public static int PlatformsLayerID {
		get {
			return LayerMask.NameToLayer(platformsLayerName);
		}
	}

	/// Nom du calque où sont placées les plateformes désactivées (parce que le joueur
	/// est en train de passer à travers typiquement).
	/// </summary>
	public static string PlatformsLayerName {
		get {
			return platformsLayerName;
		}
	}
	private static readonly string platformsLayerName = "Default";


}

