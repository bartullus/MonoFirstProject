using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MiniAdventure.Models
{
	class GameArea : AbstractModel
	{
		/// <summary>
		/// the parent world of this area
		/// </summary>
		public GameWorld World { get; private set; }

		// widht of this area in tiles
		public int Width { get;	private set; }

		// height of this area in tiles
		public int Height {	get; private set; }

		/// <summary>
		/// all basement tiles of this world
		/// </summary>
		public GameTile[,] Tiles { get; private set; }

		/// <summary>
		/// all items in this world
		/// </summary>
		private List<GameObject> Objects;

		public GameArea(GameWorld world, int width, int height)
		{
			World = world;
			Width = width;
			Height = height;
		}

		/// <summary>
		/// initialise the area by creating its tiles and items
		/// </summary>
		public override void Init()
		{
			Tiles = new GameTile[Width, Height];
			Objects = new List<GameObject>();

			for (int x = 0; x < Width; x++)
			{
				for (int y = 0; y < Height; y++)
				{
					// tiles around the borders are blocked, inside tiles not
					bool blocked = ((x == 0) || (y == 0) || (x == Width - 1) || (y == Height - 1));

					Tiles[x, y] = new GameTile(x, y, blocked);
				}
			}

			Tiles[5, 5].Blocked = true;
			Tiles[5, 6].Blocked = true;
			Tiles[6, 5].Blocked = true;
		}

		/// <summary>
		/// Load the resources for this world
		/// </summary>
		public override void Load(GraphicsDevice graphics, ContentManager content)
		{
			for (int x = 0; x < Width; x++)
			{
				for (int y = 0; y < Height; y++)
				{
					Tiles[x, y].Load(graphics, content);
				}
			}
			
			foreach (GameObject obj in Objects)
			{
				obj.Load(graphics, content);
			}
		}

		/// <summary>
		/// Do next step for this world
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			foreach (GameObject obj in Objects)
			{
				obj.Update(gameTime);
			}
		}

		/// <summary>
		/// Draw this world
		/// </summary>
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 scale, Vector2 offset)
		{
			for (int x = 0; x<Width; x++)
			{
				for (int y = 0; y<Height; y++)
				{
					Tiles[x, y].Draw(gameTime, spriteBatch, scale, offset);
				}
			}
			
			foreach (GameObject obj in Objects)
			{
				obj.Draw(gameTime, spriteBatch, scale, offset);
			}

		}

		/// <summary>
		/// add the given object to this area
		/// </summary>
		public GameObject addObject(GameObject obj)
		{
			obj.setArea(this);
			Objects.Add(obj);
			return obj;
		}

		/// <summary>
		/// add the given object to this area
		/// </summary>
		public bool checkCollision(int x, int y)
		{
			if ((x < 0) || (y < 0) || (x >= Width) || (y >= Height))
			{
				// position out of bound always collide
				return false;
			}

			// return if this tile is blocked
			return Tiles[x, y].Blocked;
		}

	}
}
