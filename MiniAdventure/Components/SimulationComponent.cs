using System;

using Microsoft.Xna.Framework;

namespace MiniAdventure.Components
{
	class SimulationComponent : GameComponent
	{
		public SimulationComponent(AdventureGame game) : base(game)
		{
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		public override void Initialize()
		{
			((AdventureGame)Game).World.Init();
			base.Initialize();
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			((AdventureGame)Game).World.Update(gameTime);
			base.Update(gameTime);
		}
	}
}
