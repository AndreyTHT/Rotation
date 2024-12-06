using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Rotation
{
    public partial class Form1 : Form
    {
        // Массив для хранения кодов яркости пикселей изображения
        ushort[,] data;

        // Высота и ширина изображения
        ushort h, w;

        // Базовое изображение, загруженное из файла
        Bitmap bitmap;

        // Таймер для плавной анимации поворота
        private Timer rotationTimer;

        // Текущий угол поворота изображения
        private double currentAngle;

        // Целевой угол для завершения анимации
        private double targetAngle;

        // Шаг изменения угла поворота на каждый тик таймера
        private double stepAngle;

        // Уменьшенное изображение для работы (например, 500x500)
        private Bitmap resizedBitmap;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer(); // Инициализация таймера при создании формы
        }

        private void InitializeTimer()
        {
            // Создаем таймер для обновления изображения в процессе анимации
            rotationTimer = new Timer();
            rotationTimer.Interval = 1; // Интервал обновления в миллисекундах
            rotationTimer.Tick += RotationTimer_Tick; // Обработчик события "тик" таймера
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            // Обновляем текущий угол
            currentAngle += stepAngle;

            // Если достигнут целевой угол, останавливаем анимацию
            if ((stepAngle > 0 && currentAngle >= targetAngle) ||
                (stepAngle < 0 && currentAngle <= targetAngle))
            {
                currentAngle = targetAngle; // Устанавливаем точный целевой угол
                rotationTimer.Stop(); // Остановка таймера
            }

            // Выполняем поворот изображения на текущий угол
            Rotate(currentAngle);
        }

        private void Loading_Click(object sender, EventArgs e)
        {
            // Открываем диалоговое окно для выбора файла изображения
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Выберите файл", // Заголовок окна
                Filter = "Все файлы (*.*)|*.*", // Фильтр файлов
                InitialDirectory = @"C:\" // Стартовая папка
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                string filePath = openFileDialog.FileName;

                // Отображаем имя файла в метке интерфейса
                NamePicture.Text = Path.GetFileName(filePath);

                // Читаем данные из файла в массив
                data = readFile(filePath);

                // Создаем изображение на основе считанных данных
                bitmap = new Bitmap(w, h);
                for (ushort y = 0; y < h; y++)
                {
                    for (ushort x = 0; x < w; x++)
                    {
                        // Преобразуем код яркости в цвет пикселя (оттенок серого)
                        ushort rgb = (ushort)((data[y, x] >> 2) & 0xFF);
                        Color pixelColor = Color.FromArgb(rgb, rgb, rgb);
                        bitmap.SetPixel(x, y, pixelColor);
                    }
                }

                // Уменьшаем изображение до размера 500x500
                resizedBitmap = ResizeBitmap(bitmap, 500, 500);

                // Обновляем элемент PictureBox для отображения уменьшенного изображения
                UpdatePictureBox(resizedBitmap);
            }
        }

        private Bitmap ResizeBitmap(Bitmap source, int width, int height)
        {
            // Определяем область для вырезания изображения по центру
            int startX = (source.Width - width) / 2;
            int startY = (source.Height - height) / 2;

            // Убедимся, что область вырезания остается в пределах изображения
            startX = Math.Max(0, startX);
            startY = Math.Max(0, startY);
            width = Math.Min(width, source.Width - startX);
            height = Math.Min(height, source.Height - startY);

            // Создаем новый объект Bitmap для обрезанного изображения
            Rectangle sourceRectangle = new Rectangle(startX, startY, width, height);
            Bitmap cropped = new Bitmap(width, height);

            // Используем Graphics для высококачественного масштабирования
            using (Graphics g = Graphics.FromImage(cropped))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(source,
                            new Rectangle(0, 0, width, height), // Куда рисуем
                            sourceRectangle,                  // Что вырезаем
                            GraphicsUnit.Pixel);
            }

            return cropped; // Возвращаем уменьшенное изображение
        }

        private ushort[,] readFile(string filePath)
        {
            // Чтение бинарного файла изображения
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                // Читаем ширину и высоту изображения
                w = reader.ReadUInt16();
                h = reader.ReadUInt16();

                // Создаем массив для хранения данных изображения
                data = new ushort[h, w];
                for (ushort y = 0; y < h; y++)
                {
                    for (ushort x = 0; x < w; x++)
                    {
                        // Считываем каждый пиксель
                        data[y, x] = reader.ReadUInt16();
                    }
                }

                return data; // Возвращаем считанные данные
            }
        }

        private void apply_angle_Click(object sender, EventArgs e)
        {
            // Получаем новое значение угла из интерфейса (NumericUpDown)
            double newAngle = (double)Angle.Value;

            // Устанавливаем целевой угол и шаг для анимации
            targetAngle = newAngle;
            stepAngle = (newAngle - currentAngle) / 20;

            // Запускаем анимацию
            rotationTimer.Start();
        }

        public void Rotate(double angle)
        {
            double radians = angle * Math.PI / 180;

            // Центр исходного изображения
            double centerX = resizedBitmap.Width / 2.0;
            double centerY = resizedBitmap.Height / 2.0;

            // Рассчитываем размеры нового изображения после поворота
            int newWidth = (int)Math.Ceiling(resizedBitmap.Width * Math.Abs(Math.Cos(radians)) +
                                             resizedBitmap.Height * Math.Abs(Math.Sin(radians)));
            int newHeight = (int)Math.Ceiling(resizedBitmap.Width * Math.Abs(Math.Sin(radians)) +
                                              resizedBitmap.Height * Math.Abs(Math.Cos(radians)));

            // Центр нового изображения
            double newCenterX = newWidth / 2.0;
            double newCenterY = newHeight / 2.0;

            // Создаем новое изображение
            Bitmap newBitmap = new Bitmap(newWidth, newHeight);

            // Матрица поворота
            double[,] rotationMatrix = {
        { Math.Cos(radians), Math.Sin(radians) },
        { -Math.Sin(radians), Math.Cos(radians) }
    };

            // Преобразование координат и установка цвета
            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    // Обратное преобразование координат
                    double relX = x - newCenterX;
                    double relY = y - newCenterY;

                    // Вычисляем исходные координаты с учетом поворота
                    double srcX = rotationMatrix[0, 0] * relX + rotationMatrix[0, 1] * relY + centerX;
                    double srcY = rotationMatrix[1, 0] * relX + rotationMatrix[1, 1] * relY + centerY;

                    // Проверяем, находится ли исходный пиксель в пределах границ
                    if (srcX >= 0 && srcX < resizedBitmap.Width && srcY >= 0 && srcY < resizedBitmap.Height)
                    {
                        // Получаем цвет исходного пикселя
                        Color originalColor = resizedBitmap.GetPixel((int)srcX, (int)srcY);
                        newBitmap.SetPixel(x, y, originalColor);
                    }
                    else
                    {
                        // Белый фон для пикселей вне границ
                        newBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }

            bitmap = newBitmap; // Обновляем текущий Bitmap
            UpdatePictureBox(bitmap); // Перерисовываем PictureBox
        }



        private void UpdatePictureBox(Bitmap bmp)
        {
            // Обновляем изображение в PictureBox
            pictureBox1.Image = bmp;

            // Устанавливаем размеры и режим отображения PictureBox
            pictureBox1.Width = bmp.Width;
            pictureBox1.Height = bmp.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
