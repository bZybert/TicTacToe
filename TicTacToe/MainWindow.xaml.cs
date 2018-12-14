using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        private bool mPlayerOneTurn;

        private bool mGameEnded;


        #endregion

        /// <summary>
        /// starts a new game and clears all values back to the start
        /// </summary>
        private void NewGame()
        {
            // create a new blank array of free cells
            mResults = new MarkType[9];

            for (var i=0; i<mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;

                //make sure playerOne start game
                mPlayerOneTurn = true;

                //iterate every botton of the grid
                 Container.Children.Cast<Button>().ToList().ForEach(btn =>
                {
                    btn.Content = string.Empty;
                    btn.Background = Brushes.White;
                    btn.Foreground = Brushes.Blue;
                });

                // make shure the game hasn't finished 
                mGameEnded = false;
            }
        }

        /// <summary>
        /// Handles buttons click event
        /// </summary>
        /// <param name="sender">the button that was clicked</param>
        /// <param name="e">event of the clicks</param>
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            // cast the sender to a botton
            var button = (Button)sender;

            // find the bottons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // don't do anything if the cell already has a value
            if (mResults[index] != MarkType.Free)
                return;

            // set the  cell value based on which player turn it is
            mResults[index] = mPlayerOneTurn ? MarkType.Cross : MarkType.Nought;

            // set button text to the result
            button.Content = mPlayerOneTurn ? "X" : "O";

            //change nought to green
            if (!mPlayerOneTurn)
                button.Foreground = Brushes.Red;

            // toggle the players turn
            mPlayerOneTurn ^= true;

            // check for a winner
            CheckForWinner();
        }

        /// <summary>
        /// Check for a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner()
        {
            //check for horizontal win
            //row 0
            if(mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn0_0.Background = Btn1_0.Background = Btn2_0.Background = Brushes.LimeGreen;

            }

            //row 1
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn0_1.Background = Btn1_1.Background = Btn2_1.Background = Brushes.LimeGreen;

            }
           
            //row 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn0_2.Background = Btn1_2.Background = Btn2_2.Background = Brushes.LimeGreen;

            }

            //check for Vertical win
            //col 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn0_0.Background = Btn0_1.Background = Btn0_2.Background = Brushes.LimeGreen;

            }

            //col 1
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn1_0.Background = Btn1_1.Background = Btn2_2.Background = Brushes.LimeGreen;

            }

            //col 2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn2_0.Background = Btn2_1.Background = Btn2_2.Background = Brushes.LimeGreen;

            }

            //check for diagonal win
            //top left bottom right
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn0_0.Background = Btn1_1.Background = Btn2_2.Background = Brushes.LimeGreen;

            }

            //top right bottem left
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn2_0.Background = Btn1_1.Background = Btn0_2.Background = Brushes.LimeGreen;

            }

            //check for cross win
            //cross
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8] & mResults[2] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                //highlight winning cells in green
                Btn0_0.Background = Btn1_1.Background = Btn2_2.Background = Btn2_0.Background = Btn0_2.Background = Brushes.LimeGreen;

            }


            if (!mResults.Any(res => res == MarkType.Free) && !(mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8] & mResults[2] & mResults[6]) == mResults[0]))
            {
                mGameEnded = true;

                //there is no winner, change backgroung to orange
                //iterate every botton of the grid
                Container.Children.Cast<Button>().ToList().ForEach(btn =>
                {
                    btn.Background = Brushes.Orange;
                    btn.Foreground = Brushes.Black;
                });
            }

           
        }
    }
}
