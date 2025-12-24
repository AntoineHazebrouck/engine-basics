using System;
using Godot;

namespace Scripts.Player;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Movement")]
    [Export]
    private float BaseMovementSpeed = 5;

    [Export]
    private float BaseRotationSpeed = 6;

    [ExportGroup("References")]
    [Export]
    private Vector2 Movement = Vector2.Zero;

    [Export]
    private Node3D model;

    public override void _UnhandledKeyInput(InputEvent @event)
    {
        Movement = Input.GetVector("move_right", "move_left", "move_backward", "move_forward");

        // Movement = new Vector3(direction.X, 0, direction.Y).Normalized();
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
        if (model == null || Movement == Vector2.Zero)
            return;

        float targetAngle = Mathf.Atan2(Movement.X, Movement.Y);
        float smoothAngle = Mathf.LerpAngle(
            model.Rotation.Y,
            targetAngle,
            (float)(GetProcessDeltaTime() * BaseRotationSpeed)
        );

        model.Rotation = new Vector3(model.Rotation.X, smoothAngle, model.Rotation.Z);
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
