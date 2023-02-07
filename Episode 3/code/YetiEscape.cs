using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YetiEscape;

public partial class YetiEscape : GameManager
{

	public override void ClientJoined( IClient cl )
	{
		base.ClientJoined( cl );

		var pawn = new SwimmingPlayer();
		
		cl.Pawn = pawn;

		var allSpawnPoints = Entity.All.OfType<SpawnPoint>();
		var randomSpawnPoint = allSpawnPoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		pawn.Position = randomSpawnPoint.Position;
	}

}
