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

            for (int i = 0; i < 100; i++)
                game.ShiftRandom();
            
            RefreshButtonField();
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
        }

        private void button0_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button11_Click(object sender, EventArgs e)
        {

            SwapCard(sender);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SwapCard(sender);
        }
    }
}
