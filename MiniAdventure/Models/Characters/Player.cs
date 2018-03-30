using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MiniAdventure.Models.Characters
{
	class Player : GameCharacter
	{
		/// <summary>
		/// speed of the player on the ground
		/// </summary>
		public float movementSpeed = 5.0f;

		public Player()
		{
		}

		/// <summary>
		/// Load the resources for the player
		/// </summary>
		public override void Load(GraphicsDevice graphics, ContentManager content)
		{
			drawColor = Color.Red;
			base.Load(graphics, content);
		}

		/// <summary>
		/// Do next step for this tile
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			if (Area != null)
			{
				Vector2 movement = Area.World.Game.Input.Movement;
				Velocity = movement * movementSpeed;
			}
			base.Update(gameTime);
		}
	}
}
