using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5
{
    public class House
    {
        private static float[,] verticesHouseFront = new float[3, 3]
        {
            { -0.9f, +2, +1 }, // 0
			{ +0.9f, +2, +1 }, // 1
			{ 0,     +3, +1 },  // 2
		};

        private static float[,] verticesHouseBack = new float[3, 3]
        {
            { +0.9f, +2, -3 }, // 1
            { 0,     +3, -3 },  // 2
            { -0.9f, +2, -3 }, // 0
			
			
		};

        private static float[,] verticesHouse = new float[8, 3]
        {
            { -1, -1, -3 }, // 0
			{ +1, -1, -3 }, // 1
			{ +1, +2, -3 }, // 2
			{ -1, +2, -3 },	// 3
			{ -1, -1, +1 },	// 4
			{ +1, -1, +1 },	// 5
			{ +1, +2, +1 },	// 6
			{ -1, +2, +1 } 	// 7
		};

        private static float[,] verticesHouseRight = new float[8, 3]
        {
            /*{ +1.2f,  1.6f, +1 },	// 4
			{ +1.4f,  1.6f, +1 },	// 5
			{ +1.4f,  1.6f, -3 },   // 1
            { +1.2f,  1.6f, -3 },   // 0
			{ 0f,     +3,   +1 }, 	// 7
			{ 0.2f,   +3,   +1 },	// 6
			{ 0.2f,   +3,   -3 },   // 2
			{ 0f,     +3,   -3 },	// 3*/

            { +1.2f,  1.6f, -3 },   // 0
			{ +1.4f,  1.6f, -3 },   // 1
			{ 0.2f,   +3,   -3 },   // 2
			{ 0f,     +3,   -3 },	// 3
            { +1.2f,  1.6f, +1 },	// 4
			{ +1.4f,  1.6f, +1 },	// 5
             
			{ 0.2f,   +3,   +1 },	// 6
			{ 0f,     +3,   +1 }, 	// 7

		};

        private static float[,] verticesHouseLeft = new float[8, 3]
        {
            { -1.4f, 1.6f, -3 }, // 0
			{ -1.2f, 1.6f, -3 }, // 1
            { +0,    +3,   -3 }, // 2
			{ -0.2f, +3,   -3 }, // 3			
            { -1.4f, 1.6f, +1 }, // 4
			{ -1.2f, 1.6f, +1 }, // 5			
            { +0,    +3,   +1 }, // 6
			{ -0.2f, +3,   +1 }  // 7

        };

        private static float[,] verticesDoor = new float[8, 3]
        {
            { -0.3f, -1, +1 }, // 0
			{ +0.3f, -1, +1 }, // 1
			{ +0.3f, +0, +1 }, // 2
			{ -0.3f, +0, +1 },	// 3
			{ -0.3f, -1, +1.001f },	// 4
			{ +0.3f, -1, +1.001f },	// 5
			{ +0.3f, +0, +1.001f },	// 6
			{ -0.3f, +0, +1.001f } 	// 7
		};

        private static float[,] verticesFundament = new float[8, 3]
        {
            { -1.01f, -1, -3.01f }, // 0
			{ +1.01f, -1, -3.01f }, // 1
			{ +1.01f, -0.8f, -3.01f }, // 2
			{ -1.01f, -0.8f, -3.01f },	// 3
			{ -1.01f, -1, +1.3f },	// 4
			{ +1.01f, -1, +1.3f },	// 5
			{ +1.01f, -0.8f, +1.3f },	// 6
			{ -1.01f, -0.8f, +1.3f } 	// 7
		};

        private static float[,] verticesWindow1 = new float[8, 3]
        {
            { -0.7f, 0.8f, +1 }, // 0
			{ -0.3f, 0.8f, +1 }, // 1
			{ -0.3f, +1.5f, +1 }, // 2
			{ -0.7f, +1.5f, +1 },	// 3
			{ -0.7f, 0.8f, +1.001f },	// 4
			{ -0.3f, 0.8f, +1.001f },	// 5
			{ -0.3f, +1.5f, +1.001f },	// 6
			{ -0.7f, +1.5f, +1.001f } 	// 7
		};

        private static float[,] verticesWindow2 = new float[8, 3]
        {
            { 0.3f, 0.8f, +1 }, // 0
			{ 0.7f, 0.8f, +1 }, // 1
			{ 0.7f, +1.5f, +1 }, // 2
			{ 0.3f, +1.5f, +1 },	// 3
			{ 0.3f, 0.8f, +1.001f },	// 4
			{ 0.7f, 0.8f, +1.001f },	// 5
			{ 0.7f , +1.5f, +1.001f },	// 6
			{ 0.3f, +1.5f, +1.001f } 	// 7
		};

        private static float[,] verticesPorchRight = new float[8, 3]
        {

            { +0.3f,  -0f, 1 },   // 0
			{ +0.5f,  -0f, 1 },   // 1
			{ 0.2f,   +0.1f,   1 },   // 2
			{ 0f,     +0.1f,   1 },	// 3
            { +0.3f,  -0f, +1.3f },	// 4
			{ +0.5f,  -0f, +1.3f },	// 5
             
			{ 0.2f,   +0.1f,   +1.3f },	// 6
			{ 0f,     +0.1f,   +1.3f },   // 7

        };

        private static float[,] verticesPorchLeft = new float[8, 3]
        {
            { -0.5f, 0f, 1 }, // 0
			{ -0.3f, 0f, 1 }, // 1
            { +0,    +0.1f,   1 }, // 2
			{ -0.2f, +0.1f,   1 }, // 3			
            { -0.5f, 0f, +1.3f }, // 4
			{ -0.3f, 0f, +1.3f }, // 5			
            { +0,    +0.1f,   +1.3f }, // 6
			{ -0.2f, +0.1f,   +1.3f }  // 7

        };

		private static float[,] verticesFenceLeft = new float[8, 3]
		{
			{ -4, -1.1f, -5 }, // 0
			{ -3.5f, -1.1f, -5 }, // 1
			{ -3.5f, -0, -5 }, // 2
			{ -4, -0, -5 },	// 3
			{ -4, -1.1f, +5 },	// 4
			{ -3.5f, -1.1f, +5 },	// 5
			{ -3.5f, -0, +5 },	// 6
			{ -4, -0, +5 } 	// 7
		};

		private static float[,] verticesFenceBack = new float[8, 3]
		{
			{ -3.5f, -1.1f, -5 }, // 0
			{ +3.5f, -1.1f, -5 }, // 1
			{ +3.5f, -0, -5 }, // 2
			{ -3.5f, -0, -5 },	// 3
			{ -3.5f, -1.1f, -4.5f },	// 4
			{ +3.5f, -1.1f, -4.5f },	// 5
			{ +3.5f, -0, -4.5f },	// 6
			{ -3.5f, -0, -4.5f } 	// 7
		};

		private static float[,] verticesFenceRight = new float[8, 3]
		{
			{ +3.5f, -1.1f, -5 }, // 0
			{ 4, -1.1f, -5 }, // 1
			{ +4f, -0, -5 }, // 2
			{ +3.5f, -0, -5 },	// 3
			{ +3.5f, -1.1f, +5 },	// 4
			{ +4, -1.1f, +5 },	// 5
			{ +4, -0, +5 },	// 6
			{ +3.5f, -0, +5 } 	// 7
		};

		private Triangle _HouseFront = new Triangle(verticesHouseFront, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\brick.png"), 1, 1);
        private Triangle _HouseBack = new Triangle(verticesHouseBack, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\brick.png"), 1, 1);

        private Cube _HouseMain = new Cube(verticesHouse, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\brick.png"), 1, 2);

        private Cube _HouseRoofRight = new Cube(verticesHouseRight, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\cherep.png"),1, 3);
        private Cube _HouseRoofLeft = new Cube(verticesHouseLeft, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\cherep.png"), 1, 3);

        private Cube _Door = new Cube(verticesDoor, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\door.png"), 1, 1);

        private Cube _Fundament = new Cube(verticesFundament, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\fundament.png"), 1, 1);

        private Cube _WindowFront1 = new Cube(verticesWindow1, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\window.png"), 1, 1);
        private Cube _WindowFront2 = new Cube(verticesWindow2, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\window.png"), 1, 1);
        
        private Cube _LeftPorch = new Cube(verticesPorchLeft, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\cherep.png"), 1, 1);
        private Cube _RightPorch = new Cube(verticesPorchRight, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\cherep.png"), 1, 1);
		private Cube _FenceLeft = new Cube(verticesFenceLeft, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\fence.png"), 1, 5);
		private Cube _FenceBack = new Cube(verticesFenceBack, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\fence.png"), 1, 5);
		private Cube _FenceRight = new Cube(verticesFenceRight, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\fence.png"), 1, 5);
            
        public void Draw()
        {

            _HouseFront.Draw();
            _HouseMain.Draw();
            _HouseRoofRight.Draw();
            _HouseBack.Draw();
            _HouseRoofLeft.Draw();
            _Door.Draw();
            _Fundament.Draw();
            _WindowFront1.Draw();
            _WindowFront2.Draw();
            _RightPorch.Draw();
            _LeftPorch.Draw();
			_FenceLeft.Draw();
			_FenceBack.Draw();
			_FenceRight.Draw();
        }

        
    }
}
