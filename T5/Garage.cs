using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace T5
{
    public class Garage
    {

		private static float[,] verticesGarage = new float[8, 4]
		{
			{ +1, -1, -3 , 1}, // 0
			{ +2.3f, -1, -3, 0 }, // 1
			{ +2.3f, +0.5f, -3, 0 }, // 2
			{ +1, +0.5f, -3, 1 },	// 3
			{ +1, -1, -1, 1 },	// 4
			{ +2.3f, -1, -1, 0 },	// 5
			{ +2.3f, +0.5f, -1, 0 },	// 6
			{ +1, +0.5f, -1, 1 } 	// 7
		};

		private static float[,] verticesGarageDoor = new float[8, 3]
		{
			{ +2.2f, -1f, -0.99f }, // 0
			{ +1.1f, -1f, -0.99f }, // 1
			{ +1.1f, +0.1f, -0.99f }, // 2.2
			{ +2.2f, +0.1f, -0.99f },	// 3
			{ +2.2f, -1f, -1.01f },	// 4
			{ +1.1f, -1f, -1.01f },	// 5
			{ +1.1f, +0.1f, -1.01f },	// 6
			{ +2.2f, +0.1f, -1.01f } 	// 7
        };
		private static float[,] verticesGarageRoof = new float[8, 3]
		{
			{ +2.6f,  0.37f, -3 },   // 0
			{ +2.8f,  0.37f, -3 },   // 1
			{ 1.2f,   +1f,  -3 },   // 2
			{ 1f,     +1f,  -3 },	// 3
			{ +2.6f,  0.37f, -1 },	// 4
			{ +2.8f,  0.37f, -1 },	// 5
			{ 1.2f,   +1f,   -1 },	// 6
			{ 1f,     +1f,   -1 } 	// 7
		};

		private static float[,] verticesGarageWindow = new float[8, 3]
		{
			{ +1.7f, -0.5f,-3f }, // 0
			{ +1.3f, -0.5f,-3f }, //-3
			{ +1.3f, +0.1f,-3f }, // 2
			{ +1.7f, +0.1f,-3f },	// 3
			{ +1.7f, -0.5f,-3.01f },	// 4
			{ +1.3f, -0.5f,-3.01f },	// 5
			{ +1.3f, +0.1f,-3.01f },	// 6
			{ +1.7f, +0.1f,-3.01f } 	// 7
        };

		

		private static float[,] verticesGarageFront = new float[3, 3]
		{
			{ +2.3f, +0.5f, -3 }, // 1
            { 1f, +0.5f, -3 }, // 0
			{ 1f,     +0.99f, -3 },  // 2
		};

		private static float[,] verticesGarageBack = new float[3, 3]
		{

            { 1f, +0.49f, -1 }, // 0
			{ +2.3f, +0.49f, -1 }, // 1
			{ 1f,     +0.99f, -1 },  // 2
		};


		private Cube _Main = new Cube(verticesGarage, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\brick.png"), 1, 1);
		private Cube _GarageDoor = new Cube(verticesGarageDoor, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\garageDoor.png"), 1, 1);
		private Cube _GarageRoof = new Cube(verticesGarageRoof, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\cherep.png"), 1, 1);
		private Cube _GarageWindow = new Cube(verticesGarageWindow, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\window.png"), 1, 1);
		private Triangle _GarageRoofFront = new Triangle(verticesGarageFront, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\siding.png"), 0.5f, 0.5f);
		private Triangle _GarageRoofBack = new Triangle(verticesGarageBack, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\siding.png"), 0.5f, 0.5f);

		public void Draw()
        {
			_Main.Draw();
			_GarageRoof.Draw();
			_GarageWindow.Draw();
			_GarageRoofFront.Draw();
			_GarageRoofBack.Draw();
			_GarageDoor.Draw();
		}
	}
}
