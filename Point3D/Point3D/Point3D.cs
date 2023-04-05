using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    public class Point3D
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
        }

        public static Point3D operator -(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }

        public static Point3D operator *(Point3D p1, float n)
        {
            return new Point3D(p1.x * n, p1.y * n, p1.z * n);
        }

        public static Point3D operator /(Point3D p1, float n)
        {
            return new Point3D(p1.x / n, p1.y / n, p1.z / n);
        }

        public static double d(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2) + Math.Pow(p1.z - p2.z, 2));
        }

        public override string? ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

        public static Point3D InputPoint()
        {
            Console.WriteLine("Nhap toa do x y z:");
            float x = Convert.ToInt32(Console.ReadLine());
            float y = Convert.ToInt32(Console.ReadLine());
            float z = Convert.ToInt32(Console.ReadLine());
            return new Point3D(x, y, z);
        }

    }
}
