using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

using OpenTK.Graphics.OpenGL;

namespace T5
{
	public enum CubeSide
	{
		NEGATIVE_X = 0,
		POSITIVE_X = 1,
		NEGATIVE_Y = 2,
		POSITIVE_Y = 3,
		NEGATIVE_Z = 4,
		POSITIVE_Z = 5,
	};

	public class Cube
	{
		private float _size;
		private Vector4[] _sideColors = new Vector4[6];
		private Vector4 _specularColor = new(0, 0, 0, 1);
		private float _shininess = 1f;
		private Texture _texture;
		private float[,] _vertices;
		private float _scaleVert;
		private float _scaleHor;


		private static int[,] _faces = new int[6, 4]
		{
			{ 4, 7, 3, 0 }, // грань x<0
			{ 1, 2, 6, 5 }, // грань x>0
			{ 4, 0, 1, 5 }, // грань y<0
			{ 7, 6, 2, 3 }, // грань y>0
			{ 0, 3, 2, 1 }, // грань z<0
			{ 5, 6, 7, 4 }  // грань z>0
		};

		public Cube(float[,] vertices, Texture texture, float vert, float hor, float size = 1)
		{
			_texture = texture;
			_size = size;
			_vertices = vertices;
			_scaleVert = vert;
		    _scaleHor = hor;
			Vector4 defaultColor = (Vector4)Color4.White;
			SetSideColor(CubeSide.NEGATIVE_X, defaultColor);
			SetSideColor(CubeSide.POSITIVE_X, defaultColor);
			SetSideColor(CubeSide.NEGATIVE_Y, defaultColor);
			SetSideColor(CubeSide.POSITIVE_Y, defaultColor);
			SetSideColor(CubeSide.NEGATIVE_Z, defaultColor);
			SetSideColor(CubeSide.POSITIVE_Z, defaultColor);

		}

		public void Draw()
		{
			GL.Enable(EnableCap.ColorMaterial);
			GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.AmbientAndDiffuse);
			GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, _specularColor);
			GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, _shininess);
			var faceCount = (_faces.Length * sizeof(float) / 4) / sizeof(float);

			List<float> colorPointer = new();
			List<float> vertexPointer = new();
			List<float> normalArray = new();
			List<float> texCoord = new();
			for (int face = 0; face < faceCount; ++face)
			{
				var facePoints = new int[] { _faces[face, 0], _faces[face, 1], _faces[face, 2], _faces[face, 3] };

				var p0 = new Vector3(_vertices[facePoints[0], 0], _vertices[facePoints[0], 1], _vertices[facePoints[0], 2]);
				var p1 = new Vector3(_vertices[facePoints[1], 0], _vertices[facePoints[1], 1], _vertices[facePoints[1], 2]);
				var p2 = new Vector3(_vertices[facePoints[2], 0], _vertices[facePoints[2], 1], _vertices[facePoints[2], 2]);
				var p3 = new Vector3(_vertices[facePoints[3], 0], _vertices[facePoints[3], 1], _vertices[facePoints[3], 2]);

				p0 *= _size * 0.5f;
				p1 *= _size * 0.5f;
				p2 *= _size * 0.5f;
				p3 *= _size * 0.5f;

				var v01 = p1 - p0;
				var v02 = p2 - p0;
				var normal = Vector3.Normalize(Vector3.Cross(v01, v02));

				normalArray.Add(normal.X); normalArray.Add(normal.Y); normalArray.Add(normal.Y);
				normalArray.Add(normal.X); normalArray.Add(normal.Y); normalArray.Add(normal.Y);
				normalArray.Add(normal.X); normalArray.Add(normal.Y); normalArray.Add(normal.Y);
				normalArray.Add(normal.X); normalArray.Add(normal.Y); normalArray.Add(normal.Y);

				vertexPointer.Add(p0.X); vertexPointer.Add(p0.Y); vertexPointer.Add(p0.Z);
				AddColor(colorPointer, _sideColors[face]);
				vertexPointer.Add(p1.X); vertexPointer.Add(p1.Y); vertexPointer.Add(p1.Z);
				AddColor(colorPointer, _sideColors[face]);
				vertexPointer.Add(p2.X); vertexPointer.Add(p2.Y); vertexPointer.Add(p2.Z);
				AddColor(colorPointer, _sideColors[face]);
				vertexPointer.Add(p3.X); vertexPointer.Add(p3.Y); vertexPointer.Add(p3.Z);
				AddColor(colorPointer, _sideColors[face]);
                texCoord.Add(0.0f); texCoord.Add(0.0f);
				texCoord.Add(0.0f); texCoord.Add(1f*_scaleVert);
				texCoord.Add(1f * _scaleHor); texCoord.Add(1f * _scaleVert);
				texCoord.Add(1f * _scaleHor); texCoord.Add(0.0f);
			}
			_texture.Use(TextureUnit.Texture0);
			GL.EnableClientState(ArrayCap.TextureCoordArray);
			GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, texCoord.ToArray());
			GL.EnableClientState(ArrayCap.VertexArray);
			GL.VertexPointer(3, VertexPointerType.Float, 0, vertexPointer.ToArray());
			//GL.EnableClientState(ArrayCap.ColorArray);
			//GL.ColorPointer(4, ColorPointerType.Float, 0, colorPointer.ToArray());
			GL.EnableClientState(ArrayCap.NormalArray);
			GL.NormalPointer(NormalPointerType.Float, 0, normalArray.ToArray());
			
				GL.DrawArrays(PrimitiveType.Quads, 0, vertexPointer.Count / 3);
			
			//GL.DisableClientState(ArrayCap.ColorArray);
			GL.DisableClientState(ArrayCap.VertexArray);
			GL.DisableClientState(ArrayCap.NormalArray);
			GL.DisableClientState(ArrayCap.TextureCoordArray);
		}

		public void SetSideColor(CubeSide side, Vector4 color)
		{
			int index = (int)side;
			_sideColors[index] = color;
		}
		public void SetSpecularColor(Vector4 color) => _specularColor = color;
		public void SetShininess(float shininess) => _shininess = shininess;
		private void AddColor(List<float> colorPointer, Vector4 color)
		{
			colorPointer.Add(color.X);
			colorPointer.Add(color.Y);
			colorPointer.Add(color.Z);
			colorPointer.Add(color.W);
		}
	}
}