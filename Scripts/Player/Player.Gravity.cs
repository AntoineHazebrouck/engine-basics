using System;
using Godot;

namespace Scripts.Player;

public partial class Player : CharacterBody3D
{
    [Export]
    private float Gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle() * 3;

    public override void _PhysicsProcess(double delta)
    {
        Vector3 velocity = Velocity;
        float dt = (float)delta;

        if (!IsOnFloor())
        {
            velocity.Y -= Gravity * dt;
        }
        else
        {
            // Apply a tiny bit of downward force to keep IsOnFloor() stable
            velocity.Y = -0.1f;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
