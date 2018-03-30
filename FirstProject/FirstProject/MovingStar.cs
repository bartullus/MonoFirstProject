using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

namespace FirstProject
{
	internal class MovingStar : DrawableGameComponent
	{
		Texture2D star;
		const int minx = 10, maxx = 590;
		const int miny = 10, maxy = 440;
		int posx = 100, posy = 100;
		int dx = 1, dy = 1;

		public MovingStar(Game1 game, int _posx, int _posy) : base (game)
		{
			posx = _posx;
			posy = _posy;
		}

		protected override void LoadContent()
		{
			star = Game.Content.Load<Texture2D>("starGold");
		}

		public override void Update(GameTime gameTime)
		{
			posx += dx;
			posy += dy;

			if (posx <= minx)
			{
				dx = 1;
			}
			if (posx >= maxx)
			{
				dx = -1;
			}
			if (posy <= miny)
			{
				dy = 1;
			}
			if (posy >= maxy)
			{
				dy = -1;
			}
		}

		public override void Draw(GameTime gameTime)
		{
			Game1 g = (Game1)Game;
			g.spriteBatch.Draw(star, new Vector2(posx, posy), Color.White);
		}

	}
}
