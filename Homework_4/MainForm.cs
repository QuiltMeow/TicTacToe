using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using WMPLib;

namespace Homework_4
{
    public partial class MainForm : Form
    {
        public static readonly Random random = new Random();

        private bool isOPlaying, computerPlaying, haveResult;

        private OXComputerHandler ch;
        private readonly WindowsMediaPlayer wmp;
        private readonly IList<Button> buttonControl = new List<Button>();

        public MainForm()
        {
            InitializeComponent();
            cbMode.SelectedIndex = 0;
            wmp = new WindowsMediaPlayer();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnExit.Text == "結束遊戲")
            {
                Environment.Exit(Environment.ExitCode);
            }
            else if (btnExit.Text == "強制結束")
            {
                gameOver(true);
                btnExit.Text = "結束遊戲";

                // MessageBox.Show("已強制結束本次遊戲", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                writeTip("已強制結束 ...");
                new MapleMessageBox("已強制結束本次遊戲");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Button target = (Button)sender;
            if (target.Text == "開始遊戲")
            {
                target.Enabled = false;
                cbMode.Enabled = false;
                bool computerFirst = false;
                if (cbMode.SelectedIndex == 1)
                {
                    writeTip("正在決定順序 ...");
                    TimeMillis.wait(2000, false);

                    computerFirst = random.Next(100) % 2 == 1;
                    if (computerFirst)
                    {
                        writeTip("電腦先下 ...");
                    }
                    else
                    {
                        writeTip("玩家先下 ...");
                    }
                    ch = new OXComputerHandler(computerFirst, this);
                    TimeMillis.wait(1500, false);
                }
                else
                {
                    writeTip("玩家 VS 玩家模式");
                }

                enableOXButton(true);
                btnExit.Text = "強制結束";

                if (cbMode.SelectedIndex == 1)
                {
                    if (computerFirst)
                    {
                        startComputer();
                    }
                    else
                    {
                        writeTip("輪到玩家了 !");
                    }
                }
            }
            else if (target.Text == "重置遊戲")
            {
                resetGame();
                target.Text = "開始遊戲";
            }
        }

        private void enableOXButton(bool enable, IList<Button> exclude = null)
        {
            foreach (Button button in buttonControl)
            {
                if (exclude == null || !exclude.Contains(button))
                {
                    button.Enabled = enable;
                }
            }
        }

        private void initButtonLayout()
        {
            for (int i = 0; i < 9; ++i)
            {
                Button button = new Button()
                {
                    BackColor = Color.LightBlue,
                    Enabled = false,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Arial", 48, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Location = new Point(70 + 106 * (i % 3), 75 + 106 * (i / 3)),
                    Name = "btnOX" + i,
                    Size = new Size(100, 100),
                    TabStop = false
                };
                button.FlatAppearance.BorderSize = 0;

                button.Click += new EventHandler(OXButtonClickHandler);
                button.MouseEnter += new EventHandler(OXButtonMouseOverEvent);

                Controls.Add(button);
                buttonControl.Add(button);
            }
        }

        private void OXButtonMouseOverEvent(object sender, EventArgs e)
        {
            SoundPlayer spButtonMouseOver = new SoundPlayer(MapleMessageBoxResource.ButtonMouseOverSound);
            spButtonMouseOver.Play();
        }

        private void resetGame()
        {
            isOPlaying = true;
            computerPlaying = false;
            enableOXButton(false);
            foreach (Button button in buttonControl)
            {
                button.Text = "";
            }
            cbMode.Enabled = true;
            haveResult = false;
            writeTip("等待中 ...");
        }

        private void clickSound()
        {
            SoundPlayer spButtonMouseClick = new SoundPlayer(MapleMessageBoxResource.ButtonPressSound);
            spButtonMouseClick.Play();
        }

        private int readOXButtonIndex(Button target)
        {
            if (!target.Name.Contains("btnOX"))
            {
                throw new ArgumentException("按鈕屬性錯誤");
            }
            return int.Parse(target.Name.Substring(5));
        }

        private void OXButtonClickHandler(object sender, EventArgs e)
        {
            clickSound();
            if (computerPlaying || haveResult)
            {
                return;
            }

            Button target = (Button)sender;
            if (target.Text != "")
            {
                // MessageBox.Show("該位置已被下過囉 ! 請重新選擇", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new MapleMessageBox("該位置已被下過囉 ! 請重新選擇");
                return;
            }
            processResult(target);

            if (processWin())
            {
                gameOver();
                return;
            }
            isOPlaying = !isOPlaying;
            if (cbMode.SelectedIndex == 1)
            {
                ch.placePiecePlayer(readOXButtonIndex(target));
                startComputer();
            }
        }

        private void gameOver(bool force = false)
        {
            haveResult = true;
            enableOXButton(false, force ? null : checkOXWinLine());
            btnExit.Text = "結束遊戲";
            btnStart.Text = "重置遊戲";
            btnStart.Enabled = true;
            btnExit.Enabled = true;
        }

        private void startComputer()
        {
            computerPlaying = true;
            btnExit.Enabled = false;
            writeTip("電腦思考中 ...");
            ch.startTimer();
        }

        public void processComputer(Button target)
        {
            clickSound();
            processResult(target);
            if (processWin())
            {
                gameOver();
                return;
            }
            isOPlaying = !isOPlaying;

            computerPlaying = false;
            btnExit.Enabled = true;
            writeTip("輪到玩家了 !");
        }

        private void processResult(Button target)
        {
            if (isOPlaying)
            {
                target.ForeColor = Color.Red;
                target.Text = "O";
            }
            else
            {
                target.ForeColor = Color.Blue;
                target.Text = "X";
            }
        }

        private bool processWin()
        {
            OXStatus status = checkOXWin();
            if (status != OXStatus.PLAYING)
            {
                switch (status)
                {
                    case OXStatus.O_WIN:
                        {
                            // MessageBox.Show("O 獲得了本次勝利", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            writeTip("O 獲得勝利 !");
                            new MapleMessageBox("O 獲得了本次勝利");
                            break;
                        }
                    case OXStatus.X_WIN:
                        {
                            // MessageBox.Show("X 獲得了本次勝利", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            writeTip("X 獲得勝利 !");
                            new MapleMessageBox("X 獲得了本次勝利");
                            break;
                        }
                    case OXStatus.DRAW:
                        {
                            // MessageBox.Show("和局 本次無人勝出", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            writeTip("和局 ...");
                            new MapleMessageBox("和局 本次無人勝出");
                            break;
                        }
                }
                return true;
            }
            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            initButtonLayout();
            playBGM();
            isOPlaying = true;
        }

        private OXStatus getWinner(string winner)
        {
            switch (winner)
            {
                case "O":
                    {
                        return OXStatus.O_WIN;
                    }
                case "X":
                    {
                        return OXStatus.X_WIN;
                    }
                default:
                    {
                        return OXStatus.PLAYING;
                    }
            }
        }

        private IList<Button> checkOXWinLine()
        {
            IList<Button> ret = new List<Button>();
            for (int i = 0; i < 3; ++i)
            {
                int row = i * 3;
                if (buttonControl[i].Text == buttonControl[3 + i].Text && buttonControl[3 + i].Text == buttonControl[6 + i].Text)
                {
                    if (buttonControl[i].Text == "")
                    {
                        continue;
                    }
                    ret.Add(buttonControl[i]);
                    ret.Add(buttonControl[3 + i]);
                    ret.Add(buttonControl[6 + i]);
                    return ret;
                }
                else if (buttonControl[row].Text == buttonControl[row + 1].Text && buttonControl[row + 1].Text == buttonControl[row + 2].Text)
                {
                    if (buttonControl[row].Text == "")
                    {
                        continue;
                    }
                    ret.Add(buttonControl[row]);
                    ret.Add(buttonControl[row + 1]);
                    ret.Add(buttonControl[row + 2]);
                    return ret;
                }
            }

            if (buttonControl[0].Text == buttonControl[4].Text && buttonControl[4].Text == buttonControl[8].Text)
            {
                if (buttonControl[0].Text != "")
                {
                    ret.Add(buttonControl[0]);
                    ret.Add(buttonControl[4]);
                    ret.Add(buttonControl[8]);
                    return ret;
                }
            }
            else if (buttonControl[2].Text == buttonControl[4].Text && buttonControl[4].Text == buttonControl[6].Text)
            {
                if (buttonControl[2].Text != "")
                {
                    ret.Add(buttonControl[2]);
                    ret.Add(buttonControl[4]);
                    ret.Add(buttonControl[6]);
                    return ret;
                }
            }
            return null;
        }

        private OXStatus checkOXWin()
        {
            for (int i = 0; i < 3; ++i)
            {
                int row = i * 3;
                if (buttonControl[i].Text == buttonControl[3 + i].Text && buttonControl[3 + i].Text == buttonControl[6 + i].Text)
                {
                    if (buttonControl[i].Text == "")
                    {
                        continue;
                    }
                    return getWinner(buttonControl[i].Text);
                }
                else if (buttonControl[row].Text == buttonControl[row + 1].Text && buttonControl[row + 1].Text == buttonControl[row + 2].Text)
                {
                    if (buttonControl[row].Text == "")
                    {
                        continue;
                    }
                    return getWinner(buttonControl[row].Text);
                }
            }

            if (buttonControl[0].Text == buttonControl[4].Text && buttonControl[4].Text == buttonControl[8].Text)
            {
                if (buttonControl[0].Text != "")
                {
                    return getWinner(buttonControl[0].Text);
                }
            }
            else if (buttonControl[2].Text == buttonControl[4].Text && buttonControl[4].Text == buttonControl[6].Text)
            {
                if (buttonControl[2].Text != "")
                {
                    return getWinner(buttonControl[2].Text);
                }
            }

            foreach (Button button in buttonControl)
            {
                if (button.Text == "")
                {
                    return OXStatus.PLAYING;
                }
            }
            return OXStatus.DRAW;
        }

        public Button getButton(int index)
        {
            if (index < 0 || index >= 9)
            {
                return null;
            }
            return buttonControl[index];
        }

        public Button getButtonPosition(int position)
        {
            if (position < 1 || position > 9)
            {
                return null;
            }
            return buttonControl[position - 1];
        }

        public Button getButton2DArray(int row, int column)
        {
            if (row < 0 || row >= 3 || column < 0 || column >= 3)
            {
                return null;
            }
            return buttonControl[row * 3 + column];
        }

        public void writeTip(string data)
        {
            labelTip.Text = data;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphic = e.Graphics;
            Pen linePen = new Pen(Color.Purple);
            linePen.Width = 3;

            graphic.DrawLine(linePen, 50, 178, 400, 178);
            graphic.DrawLine(linePen, 50, 284, 400, 284);

            graphic.DrawLine(linePen, 173, 55, 173, 405);
            graphic.DrawLine(linePen, 278, 55, 278, 405);
        }

        private void extractBGM()
        {
            string path = Path.Combine(Path.GetTempPath(), "BGM.mp3");
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(Properties.Resources.BGM, 0, Properties.Resources.BGM.Length);
                fs.Flush();
            }
        }

        public void playBGM()
        {
            try
            {
                extractBGM();
                wmp.URL = Path.Combine(Path.GetTempPath(), "BGM.mp3");
                wmp.settings.volume = 50;
                wmp.settings.setMode("loop", true);
                wmp.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("BGM 播放時發生例外狀況 : " + ex);
            }
        }
    }
}