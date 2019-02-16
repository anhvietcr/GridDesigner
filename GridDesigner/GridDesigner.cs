using System;
using System.Drawing;
using System.Windows.Forms;

namespace GridDesigner
{
    public partial class GridDesigner : Form
    {
        private Event.main              _eM;
        private Point                   _mousePoint;
        private Shapes.MyRectangle      saveRect;
        readonly ToolTip                tlp = new ToolTip();
        private bool                    _isActived = false;
        private bool                    _onDrawing = false;


        /// <summary>
        /// Main Load Component and Setup
        /// </summary>
        /// 
        public GridDesigner()
        {
            main_Load();
        }

        public void frm_Actived(object sender, EventArgs e)
        {
            main_Load();
        }

        private void GridDesigner_Deactivate(object sender, EventArgs e)
        {
            _isActived = false;
        }

        public void main_Load()
        {
            InitializeComponent();
            if (_isActived) return;

            try
            {
                _isActived = true;
                _eM = new Event.main(this);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

                //// draw ruler
                txt_horizontal_ruler.Text = _eM.Draw_Ruler("h");
                txt_vertical_ruler.Text = _eM.Draw_Ruler("v");

                // add context menu in ruler text
                txt_horizontal_ruler.ContextMenu = _eM.Add_ContextMenus();
                txt_vertical_ruler.ContextMenu = _eM.Add_ContextMenus();

                // add event
                this.Deactivate     += new EventHandler(_eM.Enable_DoubleClick_Through);
                this.DoubleClick    += new EventHandler(_eM.Enable_DoubleClick_Through);


            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        /// <summary>
        /// Dynamic Create Vertical line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_vertical_ruler_MouseUp(object sender, MouseEventArgs e)
        {
            bool vertical = true;

            try
            {
                Shapes.MyFlex m = new Shapes.MyFlex(vertical);
                m.Location      = new Point(e.Location.X, 0);
                m.Size          = new Size(2, this.Height);
                m.Margin        = new Padding(0, 0, 0, 0);
                m.Padding       = new Padding(0, 0, 0, 0);
                m.Cursor        = Cursors.Cross;

                m.MouseDown     += new MouseEventHandler(myflex_MouseDown);
                m.MouseMove     += new MouseEventHandler(myflex_vertial_MouseMove);

                this.Controls.Add(m);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        /// <summary>
        /// Dynamic Horizontal line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_horizontal_ruler_MouseUp(object sender, MouseEventArgs e)
        {
            bool vertical = false;

            try
            {
                Shapes.MyFlex m = new Shapes.MyFlex(vertical);
                m.Size          = new Size(this.Width, 2);
                m.Location      = new Point(0, e.Location.Y);
                m.Margin        = new Padding(0, 0, 0, 0);
                m.Padding       = new Padding(0, 0, 0, 0);
                m.Cursor        = Cursors.Cross;

                m.MouseDown     += new MouseEventHandler(myflex_MouseDown);
                m.MouseMove     += new MouseEventHandler(myflex_horizontal_MouseMove);

                this.Controls.Add(m);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ReDrawing my Flex to screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myflex_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = e.Location;
        }

        private void myflex_vertial_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Shapes.MyFlex myFlex = (sender as Shapes.MyFlex);

                // Moving my shape
                myFlex.Left = e.X + myFlex.Left - _mousePoint.X;
                
                // Destroy my shape
                if (myFlex.Left < txt_vertical_ruler.Size.Width)
                {
                    this.Controls.Remove(myFlex);
                    myFlex.Dispose();
                }
            }
        }

        private void myflex_horizontal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Shapes.MyFlex myFlex = (sender as Shapes.MyFlex);

                // Moving my shape
                myFlex.Top = e.Y + myFlex.Top - _mousePoint.Y;

                // Destroy my shape
                if (myFlex.Top < txt_horizontal_ruler.Size.Height)
                {
                    this.Controls.Remove(myFlex);
                    myFlex.Dispose();
                }
            }
        }

        /// <summary>
        /// Dynamic Create my Rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDesigner_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !_onDrawing)
            {
                _mousePoint = e.Location;
                _onDrawing = true;
            }
        }

        private void GridDesigner_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (!_onDrawing) return;

            try
            {
                Point tempEndPoint = e.Location;

                var point1 = new Point(
                    Math.Max(0, Math.Min(_mousePoint.X, tempEndPoint.X)),
                    Math.Max(0, Math.Min(_mousePoint.Y, tempEndPoint.Y)));

                var point2 = new Point(
                    Math.Min(this.Width, Math.Max(_mousePoint.X, tempEndPoint.X)),
                    Math.Min(this.Height, Math.Max(_mousePoint.Y, tempEndPoint.Y)));

                Shapes.MyRectangle m = new Shapes.MyRectangle();

                m.Location      = point1;
                m.Size          = new Size(point2.X - point1.X, point2.Y - point1.Y);
                m.Cursor        = Cursors.Cross;

                m.MouseDown     += new MouseEventHandler(myrect_MouseDown);
                m.MouseMove     += new MouseEventHandler(myrect_MouseMove);
                m.Click         += new EventHandler(myrect_clicked);
                m.MouseHover    += new EventHandler(myrect_MouseHover);

                saveRect = m;
                _onDrawing = false;
                this.Controls.Add(m);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Selected my Rectangle (focus)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myrect_clicked(object sender, EventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control)
                saveRect = (sender as Shapes.MyRectangle);
        }

        /// <summary>
        /// Drawing Tooltip on my Rectangle hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myrect_MouseHover(object sender, EventArgs e)
        {
            Shapes.MyRectangle myRect = (sender as Shapes.MyRectangle);
            tlp.SetToolTip(myRect, myRect.Width + ", " + myRect.Height);
        }

        /// <summary>
        /// Ctrl + Left Mouse => Coppy my Rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myrect_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = e.Location;

            if (e.Button == MouseButtons.Left && ((ModifierKeys & Keys.Control) == Keys.Control))
            {
                try
                {
                    Shapes.MyRectangle newRect = new Shapes.MyRectangle();

                    newRect.Location = saveRect.Location;
                    newRect.Size = new Size(saveRect.Width, saveRect.Height);
                    newRect.Cursor = Cursors.Cross;

                    newRect.MouseDown += new MouseEventHandler(myrect_MouseDown);
                    newRect.MouseMove += new MouseEventHandler(myrect_MouseMove);
                    newRect.Click += new EventHandler(myrect_clicked);
                    newRect.MouseHover += new EventHandler(myrect_MouseHover);

                    saveRect = newRect;
                    this.Controls.Add(newRect);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        void myrect_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Shapes.MyRectangle myRect = (sender as Shapes.MyRectangle);

                // Moving my shape
                Point mousePos = GridDesigner.ActiveForm.PointToClient(Cursor.Position);
                mousePos.Offset(-_mousePoint.X, -_mousePoint.Y);
                myRect.Location = mousePos;

                // Destroy my shape
                if (myRect.Top < txt_horizontal_ruler.Size.Height - 15 || myRect.Left < txt_vertical_ruler.Size.Width - 15)
                {
                    this.Controls.Remove(myRect);
                    myRect.Dispose();
                }
            }
        }

        /// <summary>
        /// Detect key with my Rectangle
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (saveRect == null) return false;

            //capture shift + up key
            if (keyData == (Keys.Shift | Keys.Up))
            {
                saveRect.Height -= 1;
            }
            //capture shift + down key
            if (keyData == (Keys.Shift | Keys.Down))
            {
                saveRect.Height += 1;
            }
            //capture shift + left key
            if (keyData == (Keys.Shift | Keys.Left))
            {
                saveRect.Width -= 1;
            }
            //capture shift + right key
            if (keyData == (Keys.Shift | Keys.Right))
            {
                saveRect.Width += 1;
            }
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                saveRect.Location = new Point(saveRect.Location.X, saveRect.Location.Y - 1);
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                saveRect.Location = new Point(saveRect.Location.X, saveRect.Location.Y + 1);
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                saveRect.Location = new Point(saveRect.Location.X - 1, saveRect.Location.Y);
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                saveRect.Location = new Point(saveRect.Location.X + 1, saveRect.Location.Y);
            }
            //re-load tooltip on focus 
            myrect_MouseHover(saveRect, new EventArgs { });

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Moving Application to all position (multi screen)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isan_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = e.Location;
        }

        private void isan_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Cursor.Position;
                mousePos.Offset(-_mousePoint.X, -_mousePoint.Y);
                GridDesigner.ActiveForm.Location = mousePos;
            }
        }

        private void isan_DoubleClick(object sender, EventArgs e)
        {
            if (GridDesigner.ActiveForm.WindowState == FormWindowState.Maximized)
            {
                GridDesigner.ActiveForm.WindowState = FormWindowState.Normal;
            } else
            {
                GridDesigner.ActiveForm.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
