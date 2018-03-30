using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MiniAdventure.Models
{
	class GameObject : AbstractModel
	{
		/// <summary>
		/// the parent area of this object
		/// </summary>
		public GameArea Area { get; private set; }

		/// <summary>
		/// position of this element in the game area
		/// </summary>
		public Vector2 Position { get; set; }

		/// <summary>
		/// collision radius around this element
		/// </summary>
		public float drawRadius { get; set; }

		/// <summary>
		/// collision radius around this element
		/// </summary>
		public float collisionRadius { get; set; }

		/// <summary>
		/// the texture of this element
		/// </summary>
		protected Texture2D texture;

		/// <summary>
		/// the color of this element
		/// </summary>
		protected Color drawColor = Color.YellowGreen;

		public GameObject()
		{
		}

		/// <summary>
		/// assign this object to a given area
		/// </summary>
		public GameArea setArea(GameArea area)
		{
			return Area = area;
		}

		/// <summary>
		/// initialise the tile
		/// </summary>
		public override void Init()
		{
			// nothing to do
		}

		/// <summary>
		/// Load the resources for this object
		/// </summary>
		public override void Load(GraphicsDevice graphics, ContentManager content)
		{
			texture = new Texture2D(graphics, 1, 1);
			texture.SetData(new[] { drawColor });
		}

		/// <summary>
		/// Do next step for this tile
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			// most objects don't move or change
		}

		/// <summary>
		/// Draw this tile
		/// </summary>
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 scale, Vector2 offset)
		{
			int posX = (int)((Position.X - drawRadius) * scale.X + offset.X);
			int posY = (int)((Position.Y - drawRadius) * scale.Y + offset.Y);
			int sizeX = (int)(drawRadius * 2 * scale.X);
			int sizeY = (int)(drawRadius * 2 * scale.Y);
			spriteBatch.Draw(texture, new Rectangle(posX, posY, sizeX, sizeY), Color.White);
		}
	}
}
