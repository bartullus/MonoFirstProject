using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MiniAdventure.Models
{
	abstract class AbstractModel
	{
		/// <summary>
		/// initialise the model
		/// </summary>
		abstract public void Init();

		/// <summary>
		/// Load the resources for this model
		/// </summary>
		abstract public void Load(GraphicsDevice graphics, ContentManager content);

		/// <summary>
		/// Do next step for this model
		/// </summary>
		abstract public void Update(GameTime gameTime);

		/// <summary>
		/// Draw this model on a spritebatch
		/// </summary>
		abstract public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 scale, Vector2 offset);
	}
}
