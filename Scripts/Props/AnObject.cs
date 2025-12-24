using Godot;
using System;

public partial class AnObject : Area3D
{
	[Signal]
	public delegate void AnObjectCollectedEventHandler(int amount);

	private bool playerInArea = false;

	public override void _Ready()
	{
		BodyEntered += body =>
		{
			playerInArea = true;
		};

		BodyExited += body =>
		{
			playerInArea = false;
		};
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (playerInArea && Input.IsActionJustPressed("interact"))
		{
			GD.Print("Interact");
			EmitSignalAnObjectCollected(1);
		}
	}

	public override void _Process(double delta)
	{
	}
}
