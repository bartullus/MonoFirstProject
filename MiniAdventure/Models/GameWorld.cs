using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MiniAdventure.Models.Characters;
using MiniAdventure.Models.Items;

namespace MiniAdventure.Models
{
	class GameWorld : AbstractModel
	{
		
		/// <summary>
		/// the parent game main object
		/// </summary>
		public AdventureGame Game { get; private set; }
	
		/// <summary>
		/// output all the sprites here
		/// </summary>
		private SpriteBatch spriteBatch;

		/// <summary>
		/// list of all areas in this world
		/// </summary>
		public List<GameArea> Areas { get; private set; }

		/// <summary>
		/// this is the currently visible game area
		/// all the other areas are invisible (currently not displayed)
		/// </summary>
		public GameArea visibleArea { get; private set; }

		public GameWorld(AdventureGame game) 
		{
			Game = game;	
		}

		/// <summary>
		/// initialise the world
		/// </summary>
		public override void Init()
		{
			Areas = new List<GameArea>();

			GameArea mainArea = new GameArea(this, 30, 20);
			mainArea.Init();
			Areas.Add(mainArea);

			visibleArea = mainArea;

			mainArea.addObject(new Player() { Position = new Vector2(15, 10), drawRadius = 0.25f, collisionRadius = 0.25f });
			mainArea.addObject(new Diamond() { Position = new Vector2(10, 10), drawRadius = 0.25f, collisionRadius = 0.25f });
			mainArea.addObject(new Diamond() { Position = new Vector2(10, 15), drawRadius = 0.25f, collisionRadius = 0.25f });
		}

		/// <summary>
		/// Load the resources for this world
		/// </summary>
		public override void Load(GraphicsDevice graphics, ContentManager content)
		{
			spriteBatch = new SpriteBatch(graphics);

			foreach (GameArea area in Areas)
			{
				area.Load(graphics, content);
			}
		}

		/// <summary>
		/// Do next step for this world
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			foreach (GameArea area in Areas)
			{
				area.Update(gameTime);
			}
		}

		/// <summary>
		/// do some preparation befor drawing the visible area
		/// </summary>
		public void DrawWorld(GameTime gameTime, GraphicsDevice graphics)
		{
			Vector2 offset = new Vector2(10, 10);
			float scaleX = (graphics.Viewport.Width - 20) / visibleArea.Width;
			float scaleY = (graphics.Viewport.Height - 20) / visibleArea.Height;

			Draw(gameTime, spriteBatch, new Vector2(scaleX, scaleY), offset);
		}

		/// <summary>
		/// Draw the currently visible area with all its content
		/// </summary>
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 scale, Vector2 offset)
		{
			spriteBatch.Begin();
			visibleArea.Draw(gameTime, spriteBatch, scale, offset);	
			spriteBatch.End();
		}

	}
}
