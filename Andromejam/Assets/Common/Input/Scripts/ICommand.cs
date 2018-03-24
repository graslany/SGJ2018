using System;

public interface ICommand
{
	/// <summary>
	/// Indique si la commande vient d'être activé (au cours de la frame courante).
	/// </summary>
	bool IsRisingEdge();

	/// <summary>
	/// Indique si la commande vient d'être désactivée (au cours de la frame courante).
	/// </summary>
	bool IsFallingEdge();

	/// <summary>
	/// Indique si la commande est présentement active (comme un bouton poussoir enfoncé).
	/// </summary>
	bool IsActive();
}

