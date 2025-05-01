using System;
using System.Xml.Serialization;

namespace TicTacToe
{
    class Program
    {
        // create the gamefield as a global variable
        static char[,] gameboard = new char[3, 3];
        // sets the first player to be X at the start of the game
        static char currentPlayer = 'X';

        static void Main(String[] args)
        {
            // initialize the game board
            InitializeGameBoard();

            // game loop
            bool isRunning = true;
            while (isRunning)
            {
                // show the board state
                ShowBoard();

                ChangePlayer();

                // player move
                GetPlayerMove();

                // check if theres a winner
                if (CheckWinCondition())
                {
                    ShowBoard(); // refresh the board
                    Console.WriteLine($"Player {currentPlayer} has won! Congratulations!");
                    Console.WriteLine($"Wanna play again?");
                    isRunning = false; // end the game loop
                }
                // check if its a draw
                else if (CheckDraw())
                {
                    ShowBoard(); // refresh the board
                    Console.WriteLine($"It's a draw!");
                    Console.WriteLine($"Wanna play again?");
                    isRunning = false; // end the game loop
                }

                // change currentPlayer to the opposite (from x to o and vice versa)
                ChangePlayer();

            }

            static void InitializeGameBoard()
            {
                // set the first char to 1
                char number = '1';

                // for each row (there are 3) and
                for (int row = 0; row < 3; row++)
                {
                    // for each column (there are also 3)
                    for (int col = 0; col < 3; col++)
                    {
                        gameboard[row, col] = number++; // add number +1 (++)
                    }
                }
            }

            static void ShowBoard()
            {
                for (int row = 0; row <3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write($" {gameboard[row, col]} ");
                        if (col < 2)
                        {
                            Console.Write("|");
                        }
                    }
                    Console.WriteLine("");
                    if (row < 2)
                    {
                        Console.WriteLine("-----------");
                    }
                }
            }
            
            static void ChangePlayer()
            {
                Console.WriteLine($"CurrentPlayer: {currentPlayer}");
                if (currentPlayer == 'X')
                {
                    currentPlayer = 'O';
                    Console.WriteLine($"Changed CurrentPlayer to: {currentPlayer}");
                }
                else
                {
                    currentPlayer = 'X';
                    Console.WriteLine($"Changed CurrentPlayer to: {currentPlayer}");
                }
            }

            

            static bool CheckWinCondition()
            {
                throw new NotImplementedException();
            }

            static bool CheckDraw()
            {
                throw new NotImplementedException();
            }

            static void GetPlayerMove()
            {
                throw new NotImplementedException();
            }
        }
    }
}