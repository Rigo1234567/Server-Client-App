using servidor_interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.forms
{
    public partial class frminicio : Form
    {
        public frminicio()
        {
            InitializeComponent();
        }

        private void btnsede_Click(object sender, EventArgs e)
        {
            frmsede nuevo = new frmsede();
            nuevo.Show();
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            frmcliente nuevo = new frmcliente();
            nuevo.Show();
        }

        private void btnasignar_Click(object sender, EventArgs e)
        {
            frmasignar nuevo = new frmasignar();
            nuevo.Show();

        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            mostrarafiliaciones nuevo = new mostrarafiliaciones();
            nuevo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmcupos nuevo = new frmcupos();
            nuevo.Show();
        }

        private void btnmostrarcupos_Click(object sender, EventArgs e)
        {
            mostrarcupos nuevo = new mostrarcupos();
            nuevo.Show();
        }

        private void btnmostrarsedes_Click(object sender, EventArgs e)
        {
            frmmostrarsedes nuevo = new frmmostrarsedes();
            nuevo.Show();
        }

        private void btnmostrarclientes_Click(object sender, EventArgs e)
        {
            frmmostrarclientes nuevo = new frmmostrarclientes();
            nuevo.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelcontenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int lx, ly;
        int sw, sh;

        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnmaximizar.Visible = false;
            btnrestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnrestaurar_Click_1(object sender, EventArgs e)
        {
            btnmaximizar.Visible = true;
            btnrestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

       

        //private void btncerrar_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //int lx, ly;
        //int sw, sh;

        //private void btnmaximizar_Click(object sender, EventArgs e)
        //{
        //    lx = this.Location.X;
        //    ly = this.Location.Y;
        //    sw = this.Size.Width;
        //    sh = this.Size.Height;
        //    btnmaximizar.Visible = false;
        //    btnrestaurar.Visible = true;
        //    this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        //    this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        //}

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button9_Click(object sender, EventArgs e)
        {
            abrirformularios<frmsede>();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            abrirformularios<frmcliente>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirformularios<frmmostrarsedes>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            abrirformularios<frmcupos>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            abrirformularios<mostrarafiliaciones>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            abrirformularios<frmasignar>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirformularios<frmmostrarclientes>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirformularios<mostrarcupos>();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            abrirformularios<Form1>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelbarratitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //private void btnminimizar_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //}

        //private void panelformularios_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private void abrirformularios<MiForm>() where MiForm : Form, new()
        {

            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {

                formulario.BringToFront();
            }
        }

        //private void btnrestaurar_Click(object sender, EventArgs e)
        //{
        //    btnmaximizar.Visible = true;
        //    btnrestaurar.Visible = false;
        //    this.Size = new Size(sw, sh);
        //    this.Location = new Point(lx, ly);
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    abrirformularios<frmmostrarcliente>();
        //}

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    abrirformularios<frmcliente>();
        //}
    }
}
