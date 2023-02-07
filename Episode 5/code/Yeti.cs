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
}
