using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace GridDesigner.Event
{
    class main : Form
    {
        GridDesigner    frm;
        Control[]       _bootstrapGrids;
        bool            _createdBootstrapGrid;
        bool            _showBootstrapGrid;

        public main(GridDesigner frmSender)
        {
            frm = frmSender;
            _createdBootstrapGrid = false;
            _showBootstrapGrid = true;
            _bootstrapGrids = new Control[12];
        }

        /// <summary>
        /// Call User32.dll interactive WIN32
        /// 
        /// public const uint WS_EX_LAYERED = 0x00080000;
        /// public const uint WS_EX_TRANSPARENT = 0x00000020;
        /// </summary>
        public enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }

        public enum GWL
        {
            ExStyle = -20
        }

        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x4
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);

        /// <summary>
        /// Symbol Drawing Ruler
        /// </summary>
        string _u2014 = "—";
        string _u2502 = "￨ ";
        string _enter = "\n";
        string _u2575 = "╵ ";

        /// <summary>
        /// Add Contexts menu (Right Click)
        /// </summary>
        /// <returns>ContextMenu</returns>
        public ContextMenu Add_ContextMenus()
        {
            ContextMenu exit = new ContextMenu();
            exit.MenuItems.Add("Exit", (sender, e) => {
                Application.Exit();
            });

            exit.MenuItems.Add("Bootstrap Grid", (sender, e) => {

                if (_createdBootstrapGrid)
                {
                    toggleBootstrapGrid();
                } else
                {
                    createBootstrapGrid();
                }
            });

            return exit;
        }

        void createBootstrapGrid()
        {
            _createdBootstrapGrid = true;
            var space = GridDesigner.ActiveForm.Width / 12;
            var pos = 0;

            try
            {
                for (int i = 0; i < 12; i++)
                {
                    bool vertical = true;

                    Shapes.MyFlex m = new Shapes.MyFlex(vertical);
                    m.Location = new Point(pos, 0);
                    m.Size = new Size(2, GridDesigner.ActiveForm.Height);
                    m.Margin = new Padding(0, 0, 0, 0);
                    m.Padding = new Padding(0, 0, 0, 0);
                    m.Cursor = Cursors.No;

                    pos += space;
                    _bootstrapGrids[i] = m;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            GridDesigner.ActiveForm.Controls.AddRange(_bootstrapGrids);
        }

        void toggleBootstrapGrid()
        {
            _showBootstrapGrid = _showBootstrapGrid ? false : true;

            foreach (Control m in _bootstrapGrids)
            {
                m.Visible = _showBootstrapGrid;
            }
        }

        /// <summary>
        /// Drawing ruler belong to Top and Left Screen
        /// </summary>
        /// <param name="type"></param>
        /// <returns>string</returns>
        public string Draw_Ruler(string type)
        {
            int count = 0;
            StringBuilder ruler = new StringBuilder();

            if (type == "h")
            {
                for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i++, count++)
                {
                    if (count == 0)
                    {
                        ruler.Append(_u2502);
                    }
                    else if (count == 5)
                    {
                        ruler.Append(_u2502);
                        count = 0;
                    }
                    else
                    {
                        ruler.Append(_u2575);
                    }
                }
            }

            if (type == "v")
            {
                for (int i = 0; i < Screen.PrimaryScreen.Bounds.Height; i++, count++)
                {
                    if (count == 0)
                    {
                        ruler.Append(_u2014 + _u2014);
                    }
                    else if (count == 5)
                    {
                        ruler.Append(_u2014 + _u2014);
                        count = 0;
                    }
                    else
                    {
                        ruler.Append(_u2014);
                    }
                    ruler.Append(_enter);
                }
            }
            return ruler.ToString();
        }

        /// <summary>
        /// Double Click to active another program behind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Enable_DoubleClick_Through(object sender, EventArgs e)
        {
            try
            {
                int wl = GetWindowLong(frm.Handle, GWL.ExStyle);
                wl = wl | 0x80000 | 0x20;

                SetWindowLong(frm.Handle, -20, wl);
                SetLayeredWindowAttributes(frm.Handle, 0, 128, LWA.Alpha);

                // register and call actived event
                frm.Activated += new EventHandler(frm.frm_Actived);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // main
            // 
            this.ClientSize = new System.Drawing.Size(120, 0);
            this.Name = "main";
            this.ResumeLayout(false);
        }
    }
}
