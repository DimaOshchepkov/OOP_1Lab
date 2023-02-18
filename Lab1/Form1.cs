using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Fifteen : Form
    {
        private Button[] tableButton;
        private Game game;
        private int size;
        private int seconds;
        public Fifteen()
        {
            InitializeComponent();
            
            tableButton = new Button[16]
            {
                button0,
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
            };

            size = 4;
           
            game = new Game(size);
        }

        private void RefreshButtonField()
        {
            LabelCountMove.Text = "Кол-во ходов " + game.CountMove.ToString();
            for (int position = 0; position < 16; position++)
            {
                GetButton(position).Text = game.GetNumber(position).ToString();
                GetButton(position).Visible = (game.GetNumber(position) > 0);
            }
        }


        private Button GetButton(int index)
        {
            return tableButton[index];
        }

        private void GameStart()
        {
            game.Start();
            game.ShiftRandom(100);   
            RefreshButtonField();
            seconds = 0;
            labelTimer.Text = Int2StringTime(0);
            timer1.Start();
        }

        private void StartMenu_Click(object sender, EventArgs e)
        {
            GameStart();
        }

        private void Fifteen_Load(object sender, EventArgs e)
        {
            GameStart();
        }

        private void SwapCard(object sender) // ?
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.Shift(position);
            RefreshButtonField();
            if (game.Check())
            {
                MessageBox.Show("Победа");
                GameStart();
            }
        }

        #region pressing on buttons

        private void button0_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
            
        }

       
        #endregion

        private string Int2StringTime(int time)
        {
            int hours = (time - (time % (60 * 60))) / (60 * 60);
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time - hours * 60 * 60 - minutes * 60;
            return String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            labelTimer.Text = Int2StringTime(seconds);
        }
    }
}
