using Sandbox;
using System;
using System.Linq;

namespace YetiEscape;

partial class Yeti : AnimatedEntity
{
	public SwimmingPlayer Victim;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/citizen/citizen.vmdl" );
		Scale = 1.5f;

		Position = Vector3.Forward * YetiEscape.LakeRadius;
	}

	[Event.Tick.Server]
	public void ComputeAI()
	{
		if ( Victim == null ) return;

		Rotation currentRotation = Rotation.LookAt( Position, Vector3.Up );
		Rotation targetRotation = Rotation.LookAt( Victim.Position, Vector3.Up );
		float rotationDistance = currentRotation.Distance( targetRotation );
		float rotationStep = Time.Delta / rotationDistance * 90f;

		Rotation newRotation = Rotation.Slerp( currentRotation, targetRotation, rotationStep );
		Position = newRotation.Forward * YetiEscape.LakeRadius;

		if ( Position.Distance( Victim.Position ) <= 30f )
			YetiEscape.Reset( Victim.Client );
	}
}
