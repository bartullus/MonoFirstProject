using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

namespace FirstProject
{
	public class MovingStar
	{
		Texture2D star;
		const int minx = 10, maxx = 590;
		const int miny = 10, maxy = 440;
		int posx = 100, posy = 100;
		int dx = 1, dy = 1;

		public MovingStar()
		{
		}

		public void Init(int _posx, int _posy)
		{
			posx = _posx;
			posy = _posy;
		}

		public void Load(ContentManager Content)
		{

			star = Content.Load<Texture2D>("starGold");
		}

		public void Move()
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

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(star, new Vector2(posx, posy), Color.White);
		}

	}
}
