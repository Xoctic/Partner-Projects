﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoggleClient
{
    public partial class BoggleView : Form, IBogleView
    {
        public bool IsUserRegistered { get; set; }
        public bool RegistrationComplete { get; set; }

        public event Action<string, string> RegisterPressed;

        public event Action<int> JoinGamePressed;

        public event Action QuitGamePressed;

        public event Action CancelJoinGamePressed;

        public event Action<string> EnterPressedInWordTextBox;

        public event Action CancelRegisterPressed;

        public event Action HelpMenuPressed;

        public BoggleView()
        {
            InitializeComponent();
        }

        public void EnableControls(bool state)
        {
            RegisterUserButton.Enabled = state && NameTextBox.Text.Length > 0 && ServerTextBox.Text.Length > 0;
            JoinGameButton.Enabled = state && IsUserRegistered && TimeTextBox.Text.Length > 0;
            QuitGameButton.Enabled = state && IsUserRegistered;

            ServerTextBox.Enabled = state;
            NameTextBox.Enabled = state;
            TimeTextBox.Enabled = state;
            WordTextBox.Enabled = state;

            foreach (Control control in BogleGrid.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = state && IsUserRegistered;
                }
            }
            if(RegistrationComplete == false)
            {
                CancelRegisterUser.Enabled = !state;
            }
            if(RegistrationComplete == true)
            {
                CancelJoinGameButton.Enabled = !state;
            }
        }

        public void DisableControls(bool state)
        {
            RegisterUserButton.Enabled = state && NameTextBox.Text.Length > 0 && ServerTextBox.Text.Length > 0;
            JoinGameButton.Enabled = state && IsUserRegistered && TimeTextBox.Text.Length > 0;

            ServerTextBox.Enabled = state;
            NameTextBox.Enabled = state;
            TimeTextBox.Enabled = state;

            foreach (Control control in BogleGrid.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = state && IsUserRegistered;
                }
            }
        }
        public void SetBoard(string board)
        {
            //int counter = 0;
            char[] array = board.ToCharArray();


            for(int i = 1; i < 17; i++)
            {
                switch (i)
                {
                    case 1:
                        cell1.Text = array[i - 1].ToString();
                        break;

                    case 2:
                        cell2.Text = array[i - 1].ToString();
                        break;

                    case 3:
                        cell3.Text = array[i - 1].ToString();
                        break;

                    case 4:
                        cell4.Text = array[i - 1].ToString();
                        break;

                    case 5:
                        cell5.Text = array[i - 1].ToString();
                        break;

                    case 6:
                        cell6.Text = array[i - 1].ToString();
                        break;

                    case 7:
                        cell7.Text = array[i - 1].ToString();
                        break;

                    case 8:
                        cell8.Text = array[i - 1].ToString();
                        break;

                    case 9:
                        cell9.Text = array[i - 1].ToString();
                        break;

                    case 10:
                        cell10.Text = array[i - 1].ToString();
                        break;

                    case 11:
                        cell11.Text = array[i - 1].ToString();
                        break;

                    case 12:
                        cell12.Text = array[i - 1].ToString();
                        break;

                    case 13:
                        cell13.Text = array[i - 1].ToString();
                        break;

                    case 14:
                        cell14.Text = array[i - 1].ToString();
                        break;

                    case 15:
                        cell15.Text = array[i - 1].ToString();
                        break;

                    case 16:
                        cell16.Text = array[i - 1].ToString();
                        break;

                }
                
            }


            //foreach (Control control in BogleGrid.Controls)
            //{
            //    Label label = control as Label;
            //    if (label != null)
            //    {
            //        if (array[counter].ToString() == "Q")
            //        {
            //            label.Text = "QU";
            //            label.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            //        }
            //        else
            //        {
            //            label.Text = array[counter].ToString();
            //        }
            //    }

            //    counter++;
            //}
        }

        private void RegisterUserButton_Click(object sender, EventArgs e)
        {
            CancelRegisterUser.Visible = true;
            CancelRegisterUser.Enabled = true;
            RegisterPressed?.Invoke(NameTextBox.Text.Trim(), ServerTextBox.Text.Trim());
        }

        private void JoinGameButton_Click(object sender, EventArgs e)
        {
            CancelJoinGameButton.Visible = true;
            CancelJoinGameButton.Enabled = true;
            JoinGamePressed?.Invoke(Convert.ToInt32(TimeTextBox.Text.Trim()));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            QuitGamePressed?.Invoke();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelJoinGamePressed?.Invoke();
            CancelJoinGameButton.Visible = false;
        }

        private void WordTextBox_EnterPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                EnterPressedInWordTextBox?.Invoke(WordTextBox.Text.Trim());
                WordTextBox.Text = "";
                e.Handled = true;
            }
        }

        private void Registration_TextChanged(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void TimeLimit_TextChanged(object sender, EventArgs e)
        {
            EnableControls(true);
        }
        public void Clear()
        {
            BogleGrid.Controls.Clear();
        }

        public void SetPlayer1NameLabel(string name)
        {
            Player1NameLabel.Text = name;
        }

        public void SetPlayer2NameLabel(string name)
        {
            Player2NameLabel.Text = name;
        }

        public void SetSecondsLabel(string seconds)
        {
            SecondsLabel.Text = seconds;
        }

        public void SetPlayer1Score(string score)
        {
            Player1ScoreLabel.Text = score;
        }

        public void SetPlayer2Score(string score)
        {
            Player2ScoreLabel.Text = score;
        }

        public void SetWordsPlayed(List<string> p1, List<string> p2)
        {
            string p1Words = "";
            string p2Words = "";

            foreach (string el in p1)
            {
                p1Words += "\n" + el;
            }

            foreach (string el in p2)
            {
                p2Words += "\n" + el;
            }

            Player1WordsPlayed.Text = p1Words;
            Player2WordsPlayed.Text = p2Words;
        }
    

        private void CancelRegisterUser_Click(object sender, EventArgs e)
        {
            CancelRegisterPressed?.Invoke();
            CancelRegisterUser.Visible = false;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpMenuPressed?.Invoke();
        }
    }
}
