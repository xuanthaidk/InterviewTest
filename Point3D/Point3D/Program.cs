using Point;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

class Program
{
    public static Point3D p1;   
    public static Point3D p2;   
    private static void Main(string[] args)
    {
        Calculate();
    }

    private static void Calculate()
    {
        bool input = true;
        while (input)
        {
            Console.WriteLine("1. Cong");
            Console.WriteLine("2. Trư");
            Console.WriteLine("3. Nhan");
            Console.WriteLine("4. Chia");
            Console.WriteLine("5. Khoang cach");
            Console.WriteLine("6. Thoat");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    p1 = Point3D.InputPoint();
                    p2 = Point3D.InputPoint();
                    Console.WriteLine("P1 + P2 = " + (p1 + p2).ToString());
                    break;
                case 2:
                    p1 = Point3D.InputPoint();
                    p2 = Point3D.InputPoint();
                    Console.WriteLine("P1 - P2 = " + (p1 - p2).ToString());
                    break;
                case 3:
                    p1 = Point3D.InputPoint();
                    Console.WriteLine("Nhap he so: ");
                    Console.WriteLine("P1 * P2 = " + (p1 * Convert.ToInt32(Console.ReadLine())));
                    break;
                case 4:
                    p1 = Point3D.InputPoint();
                    Console.WriteLine("Nhap he so: ");
                    Console.WriteLine("P1 * P2 = " + (p1 / Convert.ToInt32(Console.ReadLine())));
                    break;
                case 5:
                    p1 = Point3D.InputPoint();
                    p2 = Point3D.InputPoint();
                    Console.WriteLine("Khoang cach 2 điem: " + Point3D.d(p1, p2));
                    break;
                case 6:
                    input = false;
                    break;
                default:
                    break;
            }
        }
    }
}