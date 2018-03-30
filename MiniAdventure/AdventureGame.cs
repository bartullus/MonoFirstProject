using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MiniAdventure.Components;
using MiniAdventure.Models;

namespace MiniAdventure
{
	/// <summary>
	/// This is the main class of this game.
	/// </summary>
	class AdventureGame : Game
	{
		GraphicsDeviceManager graphics;

		public InputComponent Input { get; private set; }

		public SimulationComponent Simulation { get; private set; }

		public SceneComponent Scene { get; private set; }

		public GameWorld World;

		public AdventureGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			World = new GameWorld(this);

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

		/// <summary>
		/// Finish Game
		/// </summary>
		public void ExitGame()
		{
			Exit();
		}
	}
}
