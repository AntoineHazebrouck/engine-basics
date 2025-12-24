using System;
using Godot;

namespace Scripts.Player;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Movement")]
    [Export]
    private float BaseMovementSpeed = 10;

    [Export]
    private float BaseRotationSpeed = 6;

    [ExportGroup("References")]
    [Export]
    private Vector2 Movement = Vector2.Zero;

    [Export]
    private Node3D Model;

    public override void _UnhandledKeyInput(InputEvent @event)
    {
        Movement = Input
            .GetVector("move_right", "move_left", "move_backward", "move_forward")
            .Normalized();
    }

    private void HandleMovement()
    {
        Vector3 currentVelocity = Velocity;

        currentVelocity.X = Movement.X * BaseMovementSpeed;
        currentVelocity.Z = Movement.Y * BaseMovementSpeed;

        Velocity = currentVelocity;
    }

    private void HandleRotation()
    {
        if (Model == null || Movement == Vector2.Zero)
            return;

        float targetAngle = Mathf.Atan2(Movement.X, Movement.Y);
        float smoothAngle = Mathf.LerpAngle(
            Model.Rotation.Y,
            targetAngle,
            (float)(GetProcessDeltaTime() * BaseRotationSpeed)
        );

        Model.Rotation = new Vector3(Model.Rotation.X, smoothAngle, Model.Rotation.Z);
    }

    public override void _Ready()
    {
        GD.Print("Hello from C#");
    }

    public override void _Process(double delta)
    {
        HandleRotation();
        HandleMovement();
        MoveAndSlide();
    }
}
