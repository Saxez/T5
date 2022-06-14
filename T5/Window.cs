using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace T5
{
    public class Window : GameWindow
    {
        private const float FIELD_OF_VIEW = 60f * (float)Math.PI / 180f;

        private const float Z_NEAR = 0.1f;
        private const float Z_FAR = 10f;

        private bool _leftMouseBtnPressed = false;

        private Matrix4 _cameraMatrix = Matrix4.LookAt(
            new(0, 0, 5),
            new(0, 0, 0),
            new(0, 2, 0));

        private static float[,] verticesGround = new float[8, 3]
        {
            { -4, -1.1f, -5 }, // 0
			{ +4, -1.1f, -5 }, // 1
			{ +4, -1, -5 }, // 2
			{ -4, -1, -5 },	// 3
			{ -4, -1.1f, +5 },	// 4
			{ +4, -1.1f, +5 },	// 5
			{ +4, -1, +5 },	// 6
			{ -4, -1, +5 } 	// 7
		};

        private Garage _Garage;

        private House _HouseMain;

        private Cube _Ground;
        

        public Window(NativeWindowSettings cfg)
            : base(GameWindowSettings.Default, cfg)
        {
           
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
            GL.Enable(EnableCap.Texture2D);
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

            _HouseMain =  new House();


            
            _Garage = new Garage();
            _Ground = new Cube(verticesGround, Texture.LoadFromFile(@"C:\Users\Данила\source\repos\T5\T5\bin\Debug\net5.0\textures\grass.png"), 5, 5);
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

            _HouseMain.Draw();
            _Ground.Draw();
            _Garage.Draw();
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