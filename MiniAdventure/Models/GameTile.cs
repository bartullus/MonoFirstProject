using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MiniAdventure.Models
{
	class GameTile : AbstractModel
	{
		/// <summary>
		/// the x position of this tile in its area
		/// </summary>
		public int PosX { get; private set; }

		/// <summary>
		/// the y position of this tile in its area
		/// </summary>
		public int PosY { get; private set; }

		/// <summary>
		/// defines if this tile blocks movements
		/// </summary>
		public bool Blocked { get; set; }

		/// <summary>
		/// the texture of this tile
		/// </summary>
		private Texture2D texture;

		public GameTile(int x, int y, bool blocked)
		{
			PosX = x;
			PosY = y;
			Blocked = blocked;
		}

		/// <summary>
		/// initialise the tile
		/// </summary>
		public override void Init()
		{

		}

		/// <summary>
		/// Load the resources for this tile
		/// </summary>
		public override void Load(GraphicsDevice graphics, ContentManager content)
		{
			Color drawColor = (Blocked) ? Color.DarkRed : Color.DarkGreen;
			texture = new Texture2D(graphics, 1, 1);
			texture.SetData(new[] { drawColor });
		}

		/// <summary>
		/// Do next step for this tile
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			// tiles usually don't move or change
		}

		/// <summary>
		/// Draw this tile
		/// </summary>
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 scale, Vector2 offset)
		{
			int offsetX = (int)(PosX * scale.X + offset.X);
			int offsetY = (int)(PosY * scale.Y + offset.Y);
			int scaleX = (int)scale.X;
			int scaleY = (int)scale.Y;

			spriteBatch.Draw(texture, new Rectangle(offsetX, offsetY, scaleX, scaleY), Color.White);
            spriteBatch.Draw(texture, new Rectangle(offsetX, offsetY, 1, scaleY), Color.Black);
            spriteBatch.Draw(texture, new Rectangle(offsetX, offsetY, scaleX, 1), Color.Black);
		}
	}
}
