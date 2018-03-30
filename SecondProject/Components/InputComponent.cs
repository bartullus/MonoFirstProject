using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SecondProject
{
	internal class InputComponent : GameComponent
	{
		const float sqrt2 = 0.707f;

		struct directionCode {
			
			public bool keyLeft;
			public bool keyRight;
			public bool keyUp;
			public bool keyDown;
			public float dirX;
			public float dirY;

			public directionCode (bool keyLeft, bool keyRight, bool keyUp, bool keyDown, float dirX, float dirY)
			{
				this.keyLeft = keyLeft;
				this.keyRight = keyRight;
				this.keyUp = keyUp;
				this.keyDown = keyDown;
				this.dirX = dirX;
				this.dirY = dirY;
			}
		};

		directionCode[] codes = { 
			//                left   right  up    down
			new directionCode(false, false, false, false, 0f, 0f), // none presse -> nothing to do
			new directionCode(true, false, false, false, -1f, 0f), // just left
			new directionCode(false, true, false, false, 1f, 0f), // just right
			new directionCode(true, true, false, false, 0f, 0f), // left+right -> nothing
			new directionCode(false, false, true, false, 0f, -1f), // just up
			new directionCode(true, false, true, false, -sqrt2, -sqrt2), // left+up
			new directionCode(false, true, true, false, sqrt2, -sqrt2),  // right+up
			new directionCode(true, true, true, false, 0f, -1f), // just up; left+right -> nothing
			new directionCode(false, false, false, true, 0f, 1f), // just down
			new directionCode(true, false, false, true, -sqrt2, sqrt2), // left+down
			new directionCode(false, true, false, true, sqrt2, sqrt2), // right+down
			new directionCode(true, true, false, true, 0f, 1f), // just down; left+right -> nothing
			new directionCode(false, false, true, true, 0f, 0f), // up+down -> nothing
			new directionCode(true, false, true, true, -1f, 0f), // just left; up+down -> nothing
			new directionCode(false, true, true, true, 1f, 0f), // just right; up+down -> nothing
			new directionCode(true, true, true, true, 0f, 0f), // all pressed -> nothing at all
		}; 

		public Vector2 Direction {
			get;
			private set;
		}

		public InputComponent (StarGame game) : base(game)
		{
		}

		public override void Update (GameTime gameTime)
		{
			// GamePadState state = GamePad.GetState (PlayerIndex.One);
			// Direction = state.ThumbSticks.Left * new Vector2(1f, -1f);

			KeyboardState kstate = Keyboard.GetState();
			foreach (directionCode code in codes)
			{
				if ((code.keyLeft == kstate.IsKeyDown(Keys.Left)) &&
				    (code.keyRight == kstate.IsKeyDown(Keys.Right)) &&
				    (code.keyUp == kstate.IsKeyDown(Keys.Up)) &&
				    (code.keyDown == kstate.IsKeyDown(Keys.Down)))
				{
					Direction = new Vector2(code.dirX, code.dirY);
				}
			}				

			base.Update (gameTime);
		}
	}
}

