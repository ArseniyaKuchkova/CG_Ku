using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CG
{
    internal class HeartButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                // Рисуем сердце с помощью кривых Безье
                // Координаты зависят от размера кнопки (this.Width, this.Height)
                path.AddBezier(Width / 2, Height / 4, Width, 0, Width, Height * 3 / 4, Width / 2, Height);
                path.AddBezier(Width / 2, Height / 4, 0, 0, 0, Height * 3 / 4, Width / 2, Height);

                // Ограничиваем область клика формой сердца
                this.Region = new Region(path);

                // Отрисовка фона
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(this.BackColor))
                {
                    pevent.Graphics.FillPath(brush, path);
                }

                // Отрисовка текста (опционально)
                TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, ForeColor);
            }
        }

    }
}
