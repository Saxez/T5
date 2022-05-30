using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace T5
{
	public static class Matrix3Ext
	{
		public static Matrix3 Orthonormalize(this Matrix3 m)
		{
			m.Row0.Normalize();

			float d0 = Vector3.Dot((Vector3)m.Row0, (Vector3)m.Row1);
			m.Row1 -= m.Row0 * d0;
			m.Row1.Normalize();

			float d1 = Vector3.Dot((Vector3)m.Row1, (Vector3)m.Row2);
			d0 = Vector3.Dot((Vector3)m.Row0, (Vector3)m.Row2);
			m.Row2 -= m.Row0 * d0 + m.Row1 * d1;
			m.Row2.Normalize();

			return m;
		}
	}
}