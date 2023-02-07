using Sandbox;
using System;
using System.Linq;

namespace YetiEscape;

partial class SwimmingPlayer : AnimatedEntity
{

	public float Speed = 200f;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/citizen/citizen.vmdl" );
	}

	public override void Simulate( IClient cl )
	{
		base.Simulate( cl );

		var moveDirection = InputDirection.Normal;

		Velocity = Vector3.Lerp( Velocity, moveDirection * Speed, Time.Delta * 10f );
		Position += Velocity * Time.Delta;

		if ( !Velocity.IsNearlyZero( 0.1f ) )
			Rotation = Rotation.Lerp( Rotation, Rotation.LookAt( Velocity, Vector3.Up ), Time.Delta * 10f );

		var animationHelper = new CitizenAnimationHelper( this );
		animationHelper.WithVelocity( Velocity );
		animationHelper.IsSwimming = true;


	}

	public override void FrameSimulate( IClient cl )
	{
		base.FrameSimulate( cl );

		Camera.Position = Position + Vector3.Up * 1000f;

		Camera.Rotation = Rotation.FromPitch( 90f );
	}

	[ClientInput] public Vector3 InputDirection { get; set; }

	public override void BuildInput()
	{
		base.BuildInput();

		InputDirection = Input.AnalogMove;
	}

}
