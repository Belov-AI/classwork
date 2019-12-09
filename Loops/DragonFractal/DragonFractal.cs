using System;

// В этом пространстве имен содержатся средства для работы с изображениями. Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System.Drawing; 

// Это пространство имен содержит средства создания оконных приложений. В частности в нем находится класс Form.
// Для того, чтобы оно стало доступно, в проект был подключен на System.Windows.Forms.dll
using System.Windows.Forms;

namespace Fractals
{
	class DragonFractal
	{
		const int Size = 800;
		const int MarginSize = 100;

		static void Main()
		{
			var image = CreateDragonImage(100000);

			// При желании можно сохранить созданное изображение в файл вот так:
			// image.Save("dragon.png", ImageFormat.Png);
	
			ShowImageInWindow(image);
		}

		private static void ShowImageInWindow(Bitmap image)
		{
			// Создание нового окна заданного размера:
			var form = new Form
			{
				Text = "Harter–Heighway dragon",
				ClientSize = new Size(Size, Size)
			};

			//Добавляем специальный элемент управления PictureBox, который умеет отображать созданное нами изображение.
			form.Controls.Add(new PictureBox {Image = image, Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.CenterImage});
			form.ShowDialog();
		}


		static Bitmap CreateDragonImage(int iterationsCount)
		{
			var image = new Bitmap(Size, Size);
			var g = Graphics.FromImage(image);
			g.FillRectangle(Brushes.Black, 0, 0, image.Width, image.Height);

            var random = new Random();

            double x = 1, y = 0;
            SetPixel(image, x, y);

            for (var i = 0; i < iterationsCount; i++)
            {
                double x1, y1;
                double angle;
                double shift;

                if(random.Next(2) == 0)
                {
                    angle = 45;
                    shift = 0;
                }
                else
                {
                    angle = 135;
                    shift = 1;
                }

                x1 = GetX(x, y, angle, shift);
                y1 = GetY(x, y, angle);
                x = x1;
                y = y1;

                SetPixel(image, x, y);
            }


			return image;
		}

        static double GetX(double x, double y, double angle, double shift)
        {
            angle = Deg2Rad(angle);
            return (x *Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2) + shift;
        }

        static double GetY(double x, double y, double angle) 
        {
            angle = Deg2Rad(angle);
            return (x * Math.Cos(angle) + y * Math.Sin(angle)) / Math.Sqrt(2);
        }

        static double Deg2Rad(double angle)
        {
            return Math.PI * angle / 180;
        }

        static void SetPixel(Bitmap image, double x, double y)
		{
			var xx = Scale(x, image.Width);
			var yy = Scale(y, image.Height);
			if (xx >=0 && xx < image.Width && yy >= 0 && yy < image.Height)
				image.SetPixel(xx, yy, Color.Yellow);
		}

		static int Scale(double x, double maxX)
		{
			return (int)Math.Round(maxX / 2.0 + (maxX / 2.0 - MarginSize) * x);
		}
	}
}
