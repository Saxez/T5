using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace T5
{
    public static class Matrix4Ext
    {
        public static Matrix4 Rotate(this Matrix4 m, float angle, Vector3 v)
        {
            var a = angle;
            var c = MathF.Cos(a);
            var s = MathF.Sin(a);

            Vector3 axis = Vector3.Normalize(v);
            Vector3 temp = axis * (1 - c);

            Matrix4 rotate = Matrix4.Zero;
            rotate[0, 0] = c + temp[0] * axis[0];
            rotate[0, 1] = temp[0] * axis[1] + s * axis[2];
            rotate[0, 2] = temp[0] * axis[2] - s * axis[1];

            rotate[1, 0] = temp[1] * axis[0] - s * axis[2];
            rotate[1, 1] = c + temp[1] * axis[1];
            rotate[1, 2] = temp[1] * axis[2] + s * axis[0];

            rotate[2, 0] = temp[2] * axis[0] + s * axis[1];
            rotate[2, 1] = temp[2] * axis[1] - s * axis[0];
            rotate[2, 2] = c + temp[2] * axis[2];

            Matrix4 result = Matrix4.Zero;
            result.Row0 = m.Row0 * rotate[0, 0] + m.Row1 * rotate[0, 1] + m.Row2 * rotate[0, 2];
            result.Row1 = m.Row0 * rotate[1, 0] + m.Row1 * rotate[1, 1] + m.Row2 * rotate[1, 2];
            result.Row2 = m.Row0 * rotate[2, 0] + m.Row1 * rotate[2, 1] + m.Row2 * rotate[2, 2];
            result.Row3 = m.Row3;

            return result;
        }
    }
}