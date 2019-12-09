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

			/*
			Начните с точки (1, 0)
			На каждой итерации:

			1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

				Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
				x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
				y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

				Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
				x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
				y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
		
			2. Нарисуйте текущую точку методом SetPixel.
			*/

			return image;
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
