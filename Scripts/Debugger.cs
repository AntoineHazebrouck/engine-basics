using System;
using Godot;

public partial class Debugger : Node3D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // GD.PushWarning("A warning");

        // GD.PushError("An error");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}
