using System;
using System.Windows.Forms;
using System.Drawing;

namespace GridDesigner.Shapes
{
    class MyRectangle : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.ResizeRedraw = true;
            this.DoubleBuffered = true;

            using (var pen = new Pen(Color.FromArgb(128, 179, 229, 240), 1))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(188, 5, 72)))
                {
                    Rectangle r = new Rectangle(0, 0, 999, 999);

                    e.Graphics.DrawRectangle(pen, r);
                    e.Graphics.FillRectangle(brush, r);

                    pen.Dispose();
                    brush.Dispose();
                }
            }
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();
        }
    }
}
