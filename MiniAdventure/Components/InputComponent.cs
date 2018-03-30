using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MiniAdventure.Components
{
	class InputComponent : GameComponent
	{
		public Vector2 Movement { get; private set; }

		public InputComponent(AdventureGame game) : base(game)
		{
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			Vector2 movement = Vector2.Zero;

			// finish game 
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
				Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				AdventureGame game = (AdventureGame)Game;
				game.ExitGame();
			}

			// Gamepad Steuerung
			GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
			movement += gamePad.ThumbSticks.Left* new Vector2(1f, -1f);

			// Keyboard Steuerung
			KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
                movement += new Vector2(-1f, 0f);
            if (keyboard.IsKeyDown(Keys.Right))
                movement += new Vector2(1f, 0f);
            if (keyboard.IsKeyDown(Keys.Up))
                movement += new Vector2(0f, -1f);
            if (keyboard.IsKeyDown(Keys.Down))
                movement += new Vector2(0f, 1f);

            if (Movement.Length() > 1f)
                movement.Normalize();

			Movement = movement;

			base.Update(gameTime);
		}
	}
}
