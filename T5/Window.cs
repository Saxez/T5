using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace T5
{
    public class Window : GameWindow
    {
        private const float FIELD_OF_VIEW = 60f * (float)Math.PI / 180f;
        private const float CUBE_SIZE = 1;

        private const float Z_NEAR = 0.1f;
        private const float Z_FAR = 10f;

        private bool _leftMouseBtnPressed = false;

        private Matrix4 _cameraMatrix = Matrix4.LookAt(
            new(0, 0, 6),
            new(0, 0, 0),
            new(0, 2, 0));

        private static float[,] verticesGarageFront = new float[3, 3]
        {
            { -0.9f, +1, +1 }, // 0
			{ +0.9f, +1, +1 }, // 1
			{ 0, +2, +1 },  // 2
		};

        private static float[,] verticesGarageBack = new float[3, 3]
        {
            { -0.9f, +1, -3 }, // 0
			{ +0.9f, +1, -3 }, // 1
			{ 0, +2, -3 },  // 2
		};

        private static float[,] verticesGarage = new float[8, 3]
        {
            { -1, -1, -3 }, // 0
			{ +1, -1, -3 }, // 1
			{ +1, +1, -3 }, // 2
			{ -1, +1, -3 },	// 3
			{ -1, -1, +1 },	// 4
			{ +1, -1, +1 },	// 5
			{ +1, +1, +1 },	// 6
			{ -1, +1, +1 } 	// 7
		};

        private static float[,] verticesGarageRight = new float[8, 3]
        {
            { +1.2f,  0.6f, -3 },   // 0
			{ +1.4f,  0.6f, -3 },   // 1
			{ 0.2f,   +2,   -3 },   // 2
			{ 0f,     +2,   -3 },	// 3
			{ +1.2f,  0.6f, +1 },	// 4
			{ +1.4f,  0.6f, +1 },	// 5
			{ 0.2f,   +2,   +1 },	// 6
			{ 0f,     +2,   +1 } 	// 7
             

		};

        private static float[,] verticesGarageLeft = new float[8, 3]
        {
            { -1.4f, 0.6f, -3 }, // 0
			{ -1.2f, 0.6f, -3 }, // 1
            { +0,    +2,   -3 }, // 2
			{ -0.2f, +2,   -3 }, // 3			
            { -1.4f, 0.6f, +1 }, // 4
			{ -1.2f, 0.6f, +1 }, // 5			
            { +0,    +2,   +1 }, // 6
			{ -0.2f, +2,   +1 }  // 7

        };

        private Triangle _garageFront = new Triangle(verticesGarageFront);
        private Triangle _garageBack = new Triangle(verticesGarageBack);

        private Cube _garageMain = new Cube(verticesGarage);

        private Cube _garageRoofRight = new Cube(verticesGarageRight);
        private Cube _garageRoofLeft = new Cube(verticesGarageLeft);


        public Window(NativeWindowSettings cfg)
            : base(GameWindowSettings.Default, cfg)
        {
            _garageFront.SetSideColor(CubeSide.NEGATIVE_X, new(1, 0, 0, 1));
            _garageFront.SetSideColor(CubeSide.POSITIVE_X, new(0, 1, 0, 1));
            _garageFront.SetSideColor(CubeSide.NEGATIVE_Y, new(0, 0, 1, 1));
            _garageFront.SetSideColor(CubeSide.POSITIVE_Y, new(1, 1, 0, 1));
            _garageFront.SetSideColor(CubeSide.NEGATIVE_Z, new(0, 1, 1, 1));
            _garageFront.SetSideColor(CubeSide.POSITIVE_Z, new(1, 0, 1, 1));

            _garageBack.SetSideColor(CubeSide.NEGATIVE_X, new(1, 0, 0, 1));
            _garageBack.SetSideColor(CubeSide.POSITIVE_X, new(0, 1, 0, 1));
            _garageBack.SetSideColor(CubeSide.NEGATIVE_Y, new(0, 0, 1, 1));
            _garageBack.SetSideColor(CubeSide.POSITIVE_Y, new(1, 1, 0, 1));
            _garageBack.SetSideColor(CubeSide.NEGATIVE_Z, new(0, 1, 1, 1));
            _garageBack.SetSideColor(CubeSide.POSITIVE_Z, new(1, 0, 1, 1));

            _garageMain.SetSideColor(CubeSide.NEGATIVE_X, new(1, 0, 0, 1));
            _garageMain.SetSideColor(CubeSide.POSITIVE_X, new(0, 1, 0, 1));
            _garageMain.SetSideColor(CubeSide.NEGATIVE_Y, new(0, 0, 1, 1));
            _garageMain.SetSideColor(CubeSide.POSITIVE_Y, new(1, 1, 0, 1));
            _garageMain.SetSideColor(CubeSide.NEGATIVE_Z, new(0, 1, 1, 1));
            _garageMain.SetSideColor(CubeSide.POSITIVE_Z, new(1, 0, 1, 1));

            _garageRoofRight.SetSideColor(CubeSide.NEGATIVE_X, new(1, 0, 0, 1));
            _garageRoofRight.SetSideColor(CubeSide.POSITIVE_X, new(0, 1, 0, 1));
            _garageRoofRight.SetSideColor(CubeSide.NEGATIVE_Y, new(0, 0, 1, 1));
            _garageRoofRight.SetSideColor(CubeSide.POSITIVE_Y, new(1, 1, 0, 1));
            _garageRoofRight.SetSideColor(CubeSide.NEGATIVE_Z, new(0, 1, 1, 1));
            _garageRoofRight.SetSideColor(CubeSide.POSITIVE_Z, new(1, 0, 1, 1));
            _garageRoofRight.SetSideColor(CubeSide.NEGATIVE_X, new(1, 0, 0, 1));

            _garageRoofLeft.SetSideColor(CubeSide.POSITIVE_X, new(0, 1, 0, 1));
            _garageRoofLeft.SetSideColor(CubeSide.NEGATIVE_Y, new(0, 0, 1, 1));
            _garageRoofLeft.SetSideColor(CubeSide.POSITIVE_Y, new(1, 1, 0, 1));
            _garageRoofLeft.SetSideColor(CubeSide.NEGATIVE_Z, new(0, 1, 1, 1));
            _garageRoofLeft.SetSideColor(CubeSide.POSITIVE_Z, new(1, 0, 1, 1));
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(1, 1, 1, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.PushMatrix();
            Draw();
            GL.PopMatrix();

            SwapBuffers();

            base.OnRenderFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);

            float aspect = (float)e.Width / (float)e.Height;
            GL.MatrixMode(MatrixMode.Projection);
            var proj = Matrix4.CreatePerspectiveFieldOfView(FIELD_OF_VIEW, aspect, Z_NEAR, Z_FAR);
            GL.LoadMatrix(ref proj);
            GL.MatrixMode(MatrixMode.Modelview);

            base.OnResize(e);
        }

        protected override void OnLoad()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light2);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.Enable(EnableCap.DepthTest);

            DirectLight light = new(new(0, 0, 0));
            light.SetDiffuseIntensity(new(0.5f, 0.5f, 0.5f, 1f));
            light.SetAmbientIntensity(new(0.3f, 0.3f, 0.3f, 1.0f));
            light.SetSpecularIntensity(new(1.0f, 1.0f, 1.0f, 1.0f));
            light.Apply(LightName.Light2);

        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Button1)
            {
                _leftMouseBtnPressed = true;
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButton.Button1)
            {
                _leftMouseBtnPressed = false;
            }
        }

        protected override void OnMouseLeave()
        {
            base.OnMouseLeave();
            _leftMouseBtnPressed = false;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            if (_leftMouseBtnPressed)
            {
                float xAngle = e.DeltaY * MathF.PI / Size.Y;
                float yAngle = e.DeltaX * MathF.PI / Size.X;
                RotateCamera(xAngle, yAngle);
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        private void RotateCamera(float xAngle, float yAngle)
        {
            Vector3 xAxis = new(_cameraMatrix.M11, _cameraMatrix.M21, _cameraMatrix.M31);
            Vector3 yAxis = new(_cameraMatrix.M12, _cameraMatrix.M22, _cameraMatrix.M32);

            _cameraMatrix = _cameraMatrix.Rotate(xAngle, xAxis);
            _cameraMatrix = _cameraMatrix.Rotate(yAngle, yAxis);


            _cameraMatrix = Orthonormalize(_cameraMatrix);
        }

        private void Draw()
        {
            GL.ClearColor(Color4.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SetupCameraMatrix();

            _garageFront.Draw();
            _garageMain.Draw();
            _garageRoofRight.Draw();
            _garageBack.Draw();
            _garageRoofLeft.Draw();
        }

        private void SetupCameraMatrix()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref _cameraMatrix);
        }

        private Matrix4 Orthonormalize(Matrix4 m)
        {
            Matrix3 normalizedMatrix = new Matrix3(m).Orthonormalize();
            Matrix4 result = new Matrix4(normalizedMatrix);
            result.Row3 = m.Row3;
            result.Column3 = m.Column3;
            return result;
        }
    }
}