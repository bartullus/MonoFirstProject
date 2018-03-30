using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MiniAdventure.Models.Items
{
	class Diamond : GameObject
	{
		public Diamond()
		{
		}

		/// <summary>
		/// Load the resources for the player
		/// </summary>
		public override void Load(GraphicsDevice graphics, ContentManager content)
		{
			drawColor = Color.Yellow;
			base.Load(graphics, content);
		}
	
	}
}
