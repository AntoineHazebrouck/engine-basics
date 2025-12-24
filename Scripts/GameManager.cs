using System;
using Godot;

public partial class GameManager : Node3D
{
    [Export]
    private AnObject AnObject;

    public override void _Ready()
    {
        AnObject.AnObjectCollected += (eventqsd) =>
        {
            GD.Print("Collected item");
        };
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}
