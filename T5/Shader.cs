using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.IO;

namespace T5
{
    public class Shader
    {
        public int Handle { get; private set; }

        public Shader(string vertShader, string fragShader)
        {
            string vertShaderSource = File.ReadAllText(vertShader);
            string fragShaderSource = File.ReadAllText(fragShader);

            var vert = GL.CreateShader(ShaderType.VertexShader);
            var frag = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(vert, vertShaderSource);
            GL.ShaderSource(frag, fragShaderSource);

            GL.CompileShader(vert);
            GL.GetShaderInfoLog(vert, out string vertLog);
            if (vertLog != string.Empty)
                Console.WriteLine($"{nameof(vertLog)}:\n {vertLog}");

            GL.CompileShader(frag);
            GL.GetShaderInfoLog(frag, out string fragLog);
            if (fragLog != string.Empty)
                Console.WriteLine($"{nameof(fragLog)}:\n {fragLog}");

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, vert);
            GL.AttachShader(Handle, frag);

            GL.LinkProgram(Handle);

            GL.DetachShader(Handle, vert);
            GL.DetachShader(Handle, frag);
            GL.DeleteShader(vert);
            GL.DeleteShader(frag);
        }

        public void SetVector3(string name, Vector3 value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform3(location, value);
        }

        public void SetFloat(string name, float value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform1(location, value);
        }

        public void SetMat4(string name, Matrix4 value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            if (location == -1)
                throw new Exception("Location not found");
            GL.UniformMatrix4(location, false, ref value);
        }

        public void SetInt(string name, int value)
        {
            int location = GL.GetUniformLocation(Handle, name); //ссылается на область в памяти, которое зарезервировано числом, поэтому для семплера нужно задать инт
            if (location == -1)
                throw new Exception("Location not found");
            GL.Uniform1(location, value);
        }

        public int GetAttribLocation(string name)
        {
            return GL.GetAttribLocation(Handle, name);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }
    }
}