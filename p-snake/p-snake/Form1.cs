using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_snake
{
    public partial class Form1 : Form
    {
        const int GAME_POS_X = 200, GAME_POS_Y = 20;
        const int GAME_ROW = 20, GAME_COL = 20;
        const int GRID_WIDTH = 20, GRID_HEIGHT = 20;
        const int SNAKE_INIT_LEMGTH = 5;
        const int SNAKE_INIT_ROW = 10;
        const int SNAKE_Q_LENGTH = GAME_ROW * GAME_COL + 100;
        const int SNAKE_ADD_LENGTH = 5;
        Color SNAKE_COLOR = Color.White;
        Color SNAKE_HEAD_COLOR = Color.Yellow;
        Color BG_COLOR = Color.Black;
        Color BONUS_COLOR = Color.Red;
        int R = 255, G = 255, B = 255;
        Label[,] grids = new Label[GAME_ROW, GAME_COL];
        Point[] snake_q = new Point[SNAKE_Q_LENGTH];
        Point bonus = new Point();
        int snake_head, snake_tail, snake_dir;
        int snake_move = 1;
        int game_mode = 1;
        Random rander = new Random(System.DateTime.Now.Millisecond);
        int score=0;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < GAME_ROW; i++)
                for (int j = 0; j < GAME_COL; j++)
                {
                    grids[i, j] = new Label();
                    grids[i, j].Width = GRID_WIDTH; grids[i, j].Height = GRID_HEIGHT;
                    //grids[i, j].BorderStyle = BorderStyle.FixedSingle;
                    grids[i, j].BackColor = BG_COLOR;
                    grids[i, j].Left = j * GRID_WIDTH + GAME_POS_X;
                    grids[i, j].Top = i * GRID_HEIGHT + GAME_POS_Y;
                    grids[i, j].Visible = true;
                    this.Controls.Add(grids[i, j]);
                }
            gmae_init();          
            timer1.Enabled = true;
        }

        void gmae_init()
        {
            SNAKE_COLOR = Color.White;
            R = G = B = 255;

            for (int i = 0; i < GAME_ROW; i++)
                for (int j = 0; j < GAME_COL; j++)
                    grids[i, j].BackColor = BG_COLOR;

            for (int i = 0; i < SNAKE_INIT_LEMGTH; i++)
            {
                snake_q[i].Y = SNAKE_INIT_ROW; snake_q[i].X = i;
                grids[SNAKE_INIT_ROW, i].BackColor = SNAKE_COLOR;                
            }
            snake_head = SNAKE_INIT_LEMGTH-1; snake_tail = 0;
            grids[snake_q[snake_head].Y, snake_q[snake_head].X].BackColor = SNAKE_HEAD_COLOR;

            do { snake_dir = rander.Next(0, 4) + 1; } while (snake_dir == 3);

            game_mode = 1; snake_move = 1; score = 0;
            label1.Text = ""; label2.Text = "Score:" + score;
            new_bonus();
        }

        void new_bonus()
        {
            do
            {   bonus.X = rander.Next(0, GAME_COL);
                bonus.Y = rander.Next(0, GAME_ROW);
            } while (inside_snake(1, bonus.X, bonus.Y));
            grids[bonus.Y, bonus.X].BackColor = BONUS_COLOR;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up   ){ if (snake_dir != 2) snake_dir = 1;}
            if (e.KeyCode == Keys.Down ){ if (snake_dir != 1) snake_dir = 2; }
            if (e.KeyCode == Keys.Left ){ if (snake_dir != 4) snake_dir = 3; }
            if (e.KeyCode == Keys.Right){ if (snake_dir != 3) snake_dir = 4; }

            if (e.KeyCode == Keys.P)
            {
                if (game_mode == 1){game_mode = 0; timer1.Enabled = false; }
                else{ game_mode = 1; timer1.Enabled = true; }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //---------------  snake head update ------------------------------------            
            int y = snake_q[snake_head].Y, x = snake_q[snake_head].X;

            if (++snake_head == SNAKE_Q_LENGTH) snake_head = 0;

            snake_q[snake_head].Y = y; snake_q[snake_head].X = x;

            switch (snake_dir)
            {
                case 1:
                    if (--snake_q[snake_head].Y < 0) snake_q[snake_head].Y = GAME_ROW - 1;
                    break;
                case 2:
                    if (++snake_q[snake_head].Y >= GAME_ROW) snake_q[snake_head].Y = 0;
                    break;
                case 3:
                    if (--snake_q[snake_head].X < 0) snake_q[snake_head].X = GAME_COL - 1;
                    break;
                case 4:
                    if (++snake_q[snake_head].X >= GAME_COL) snake_q[snake_head].X = 0;
                    break;
            }
            grids[snake_q[snake_head].Y, snake_q[snake_head].X].BackColor = SNAKE_HEAD_COLOR;
            grids[y, x].BackColor = SNAKE_COLOR;

            if (inside_snake(1, bonus.X, bonus.Y))
            {   // snake gets the bonus square
                new_bonus();
                snake_move += SNAKE_ADD_LENGTH;
                score += 100;
                label2.Text = "Score:" + score;
                if (R > 0) { R -= 8; if (R < 0) R = 0; }
                else { G -= 8; if (G < 0) G = 0; }

                SNAKE_COLOR = Color.FromArgb(R, G, B);
            }

            if (inside_snake(0, snake_q[snake_head].X, snake_q[snake_head].Y))
            {   //snake bites itself and "game over"!
                timer1.Enabled = false;
                draw_snake();
                label1.Text = "Game Over";                
                button1.Enabled = true; button1.Visible = true;
                return; 
            }
            //---------------  snake tail update -------------------------------------- 
            if (snake_move == 1)
            {
                grids[snake_q[snake_tail].Y, snake_q[snake_tail].X].BackColor = BG_COLOR;
                if (++snake_tail == SNAKE_Q_LENGTH) snake_tail = 0;
            }
            else
                snake_move--;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false; button1.Visible = false;
            gmae_init();
            timer1.Enabled = true;
        }

        bool inside_snake(int mode, int x, int y)
        { // mode:0 => head exclusive, 1=> head inclusive
            int s, e;
            
            s = snake_head; e = snake_tail;
            if (mode == 1){ if (x == snake_q[s].X && y == snake_q[s].Y) return true; }
            
            do
            {   if (--s == -1) s = SNAKE_Q_LENGTH - 1;
                if (x == snake_q[s].X && y == snake_q[s].Y) return true;

            } while (s != e);

            return false;
        }

        void draw_snake()
        {
            int s, e;

            s = snake_head; e = snake_tail;           
            do
            {
                if (--s == -1) s = SNAKE_Q_LENGTH - 1;

                grids[snake_q[s].Y, snake_q[s].X].BackColor = SNAKE_HEAD_COLOR;

            } while (s != e);

            grids[snake_q[snake_head].Y, snake_q[snake_head].X].BackColor = Color.Blue;
        }        
    }
}
