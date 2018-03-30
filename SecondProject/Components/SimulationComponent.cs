using System;
using Microsoft.Xna.Framework;

namespace SecondProject
{
	internal class SimulationComponent : GameComponent
	{
		private StarGame game;

		public Vector2 Position {
			get;
			private set;
		}

		public SimulationComponent (StarGame game) : base(game)
		{
			this.game = game;
		}

		public override void Initialize()
		{
			base.Initialize();

			Position = new Vector2(100, 100);
		}

		public override void Update (GameTime gameTime)
		{
			Position += game.Input.Direction;

			base.Update (gameTime);
		}
	}
}

