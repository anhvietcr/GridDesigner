using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridDesigner.Shapes
{
    class MyFlex : Control
    {
        private bool _vertical;

        public MyFlex()
        {
            _vertical = false;
        }

        public MyFlex(bool vertical)
        {
            _vertical = vertical;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.ResizeRedraw = true;
            this.DoubleBuffered = true;

            var pos = _vertical ? Height / 2 : Width / 2;

            e.Graphics.TranslateTransform(Width / 2f, Height / 2f);

            using (var pen = new Pen(Color.Red, 0.1f))
            {
                if (!_vertical)
                {
                    e.Graphics.DrawLine(pen, pos, 0, -pos, 0);
                }
                else
                {
                    e.Graphics.DrawLine(pen, 0, pos, 0, -pos);
                }

                pen.Dispose();
            }
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();
        }
    }
}
