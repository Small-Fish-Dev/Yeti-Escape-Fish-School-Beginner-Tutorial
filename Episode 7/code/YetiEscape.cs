using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YetiEscape;

public partial class YetiEscape : GameManager
{

	public static float LakeRadius = 512f;

	public override void ClientJoined( IClient cl )
	{
		base.ClientJoined( cl );

		Reset( cl );
	}

	public static void Reset( IClient cl )
	{
		cl.Pawn?.Delete();

		var pawn = new SwimmingPlayer();
		cl.Pawn = pawn;

		var clothing = new ClothingContainer();
		clothing.LoadFromClient( cl );
		clothing.DressEntity( pawn );

		var allSpawnPoints = Entity.All.OfType<SpawnPoint>();
		var randomSpawnPoint = allSpawnPoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		pawn.Position = randomSpawnPoint.Position;
	}

}
