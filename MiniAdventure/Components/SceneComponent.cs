using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MiniAdventure.Models;

namespace MiniAdventure.Components
{
	class SceneComponent : DrawableGameComponent
	{
		public SceneComponent(AdventureGame game) : base(game)
		{
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			AdventureGame game = (AdventureGame)Game;
			game.World.Load(GraphicsDevice, Game.Content);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			AdventureGame game = (AdventureGame)Game;
			game.World.DrawWorld(gameTime, GraphicsDevice);

		}
	}
}
