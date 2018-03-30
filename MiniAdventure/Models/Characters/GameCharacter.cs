using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MiniAdventure.Models.Characters
{
	class GameCharacter : GameObject
	{
		/// <summary>
		/// movement vector of this character
		/// </summary>
		public Vector2 Velocity { get; set; }

		public GameCharacter()
		{
		}

		/// <summary>
		/// initialise the character
		/// </summary>
		public override void Init()
		{
			base.Init();
		}

		/// <summary>
		/// Load the resources for this character
		/// </summary>
		public override void Load(GraphicsDevice graphics, ContentManager content)
		{
			base.Load(graphics, content);
		}

		/// <summary>
		/// Do next step for this tile
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			Position = doMovement(gameTime);
			base.Update(gameTime);
		}

		/// <summary>
		/// Draw this tile
		/// </summary>
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 scale, Vector2 offset)
		{
			base.Draw(gameTime, spriteBatch, scale, offset);
		}

		private Vector2 doMovement(GameTime gameTime)
		{
			Vector2 movement = Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
			Vector2 newPosition = Position + movement;

			if (Area == null)
			{
				// this object belongs to no area -> no collisions possible
				return newPosition;
			}

			bool collision = false;
			float minImpact = float.MaxValue;
			int axis = 0;

			// this is the bounding box of the object
			int minCellX = (int)(newPosition.X - collisionRadius);
			int minCellY = (int)(newPosition.Y - collisionRadius);
			int maxCellX = (int)(newPosition.X + collisionRadius);
			int maxCellY = (int)(newPosition.Y + collisionRadius);

			for (int x = minCellX; x <= maxCellX; x++)
			{
				for (int y = minCellY; y <= maxCellY; y++)
				{
					if (!Area.checkCollision(x, y))
					{
						// there is no collision with a tile
						continue;
					}

					// time of collision on X Axis
					float diffX;
					float impactX = float.MaxValue;
					if (movement.X > 0.0f)
					{
						diffX = newPosition.X + collisionRadius - x;
						impactX = 1.0f - diffX / movement.X;
					}
					if (movement.X < 0.0f)
					{
						diffX = newPosition.X - collisionRadius - (x + 1);
						impactX = 1.0f - diffX / movement.X;
					}
					// check if this impact war earlier than the alread found ones
					if (impactX < minImpact)
					{
						collision = true;
						minImpact = impactX;
						axis = 1; // impact on the x axis
					}

					// time of collision on X Axis
					float diffY;
					float impactY = float.MaxValue;
					if (movement.Y > 0.0f)
					{
						diffY = newPosition.Y + collisionRadius - y;
						impactY = 1.0f - diffY / movement.Y;
					}
					if (movement.Y < 0.0f)
					{
						diffY = newPosition.Y - collisionRadius - (y + 1);
						impactY = 1.0f - diffY / movement.Y;
					}
					if (impactY < minImpact)
					{
						collision = true;
						minImpact = impactY;
						axis = 2; // impact on the y axis
					}
				}
			}

			if (collision)
			{
				if (axis == 1)
				{
					movement *= new Vector2(minImpact, 1.0f);
				}
				if (axis == 2)
				{
					movement *= new Vector2(1.0f, minImpact);
				}
				newPosition = Position + movement;
			}

			return newPosition;
		}

	}
}
