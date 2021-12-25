using System;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Homework_4
{
    public partial class MapleMessageBox : Form
    {
        private const int HT_CAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;

        private readonly bool EXIT_ON_CLOSE;

        public MapleMessageBox()
        {
            InitializeComponent();
            initButton();

            CenterToScreen();
            Visible = true;
        }

        public MapleMessageBox(string message) : this()
        {
            labelMessage.Text = message;
        }

        public MapleMessageBox(string message, bool exitOnClose) : this(message)
        {
            EXIT_ON_CLOSE = exitOnClose;
        }

        public Label getMessageLabel()
        {
            return labelMessage;
        }

        private void initButton()
        {
            btnOK.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnOK.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            SoundPlayer spButtonMouseOver = new SoundPlayer(MapleMessageBoxResource.ButtonMouseOverSound);
            spButtonMouseOver.Play();
            ((Button)sender).Image = MapleMessageBoxResource.ButtonOKMouseOver;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).Image = MapleMessageBoxResource.ButtonOKNormal;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (EXIT_ON_CLOSE)
            {
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                Close();
            }
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MapleMessageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnOK_MouseDown(object sender, MouseEventArgs e)
        {
            SoundPlayer spButtonPress = new SoundPlayer(MapleMessageBoxResource.ButtonPressSound);
            spButtonPress.Play();
            ((Button)sender).Image = MapleMessageBoxResource.ButtonOKPress;
        }

        private void MapleMessageBox_Load(object sender, EventArgs e)
        {
            SoundPlayer spDialogNotice = new SoundPlayer(MapleMessageBoxResource.DialogNotice);
            spDialogNotice.Play();
        }

        private void btnOK_EnabledChanged(object sender, EventArgs e)
        {
            if (btnOK.Enabled)
            {
                btnOK.Image = MapleMessageBoxResource.ButtonOKNormal;
            }
            else
            {
                btnOK.Image = MapleMessageBoxResource.ButtonOKDisable;
            }
        }
    }
}