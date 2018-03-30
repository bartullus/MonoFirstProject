using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SecondProject
{
	internal class SceneComponent : DrawableGameComponent
	{
		private SpriteBatch spriteBatch;
		private Texture2D star;
		private StarGame game;

		public SceneComponent (StarGame game) : base(game)
		{
			this.game = game;
		}

		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here
			star = Game.Content.Load<Texture2D> ("starGold");

			base.LoadContent ();
		}

		public override void Draw (GameTime gameTime)
		{
			GraphicsDevice.Clear (Color.CornflowerBlue);

			//TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(star, game.Simulation.Position, Color.White);
			spriteBatch.End ();

			base.Draw (gameTime);
		}
	}
}

