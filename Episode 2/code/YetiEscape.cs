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
	}

}
