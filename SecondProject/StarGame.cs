using System;

using Microsoft.Xna.Framework;

namespace SecondProject
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	internal class StarGame : Game
	{
		GraphicsDeviceManager graphics;

		public InputComponent Input
		{
			get;
			private set;
		}

		public SimulationComponent Simulation
		{
			get;
			private set;
		}

		public SceneComponent Scene
		{
			get;
			private set;	
		}

		public StarGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.IsFullScreen = false;

			Input = new InputComponent(this);
			Input.UpdateOrder = 0;
			Components.Add(Input);

			Simulation = new SimulationComponent(this);
			Simulation.UpdateOrder = 1;
			Components.Add(Simulation);

			Scene = new SceneComponent(this);
			Scene.UpdateOrder = 2;
			Scene.DrawOrder = 0;
			Components.Add(Scene);
		}
	}
}
