using System;
using System.Runtime.InteropServices;
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
            
            bool isRunning = true;

            Console.WriteLine($"Welcome to the TicTacToe console game by pacokeks!");
            Console.WriteLine($"Have fun!");
            Console.WriteLine($"");
            while (isRunning)
            {
                // initialize the game board
                InitializeGameBoard();
                // game loop
                while (!CheckWinCondition())
                {
                    // show the board state
                    ShowBoard();

                    // player move
                    GetPlayerMove();

                    // check if theres a winner
                    if (CheckWinCondition())
                    {
                        ShowBoard(); // refresh the board
                        Console.WriteLine($"Player {currentPlayer} has won! Congratulations!");
                        if (PlayAgain())
                        {
                            continue;
                        }
                        else
                        {
                            isRunning = false;
                        }
                        //isRunning = false; // end the game loop
                    }
                    // check if its a draw
                    else if (CheckDraw())
                    {
                        ShowBoard(); // refresh the board
                        Console.WriteLine($"It's a draw!");
                        if (PlayAgain())
                        {
                            continue;
                        }
                        else
                        {
                            isRunning = false;
                        }
                        //isRunning = false; // end the game loop
                    }
                }
            }

            Console.WriteLine($"Thanks for playing!");
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
                        // if col is below 2, add a | after the number, so after 1 and 2 but not after 3 which gives us 1 | 2 | 3
                        if (col < 2)
                        {
                            Console.Write("|");
                        }
                    }
                    Console.WriteLine("");
                    // if row is below 2, add "-----------" after the row, so after 1 | 2 | 3 and 4 | 5 | 6, but not after 7 | 8 | 9
                    if (row < 2)
                    {
                        Console.WriteLine("-----------");
                    }
                }
            }
            
            static void ChangePlayer()
            {
                //Console.WriteLine($"CurrentPlayer: {currentPlayer}"); // Debugging test
                if (currentPlayer == 'X')
                {
                    currentPlayer = 'O';
                    //Console.WriteLine($"Changed CurrentPlayer to: {currentPlayer}"); // Debugging test
                }
                else
                {
                    currentPlayer = 'X';
                    //Console.WriteLine($"Changed CurrentPlayer to: {currentPlayer}"); // Debugging test
                }
            }

            static bool CheckWinCondition()
            {
                // check win conditions
                for (int i = 0; i < 3; i++)
                {
                    if (CheckRow(i, currentPlayer) || CheckCol(i, currentPlayer)) // checks row and col win conditions
                    {
                        return true;
                    }
                }

                // checking both diagonal winning possabilities
                bool diagonal1 = gameboard[0, 0] == currentPlayer && gameboard[1, 1] == currentPlayer && gameboard[2, 2] == currentPlayer;
                bool diagonal2 = gameboard[0, 2] == currentPlayer && gameboard[1, 1] == currentPlayer && gameboard[2, 0] == currentPlayer;

                return diagonal1 || diagonal2;
            }

            // checking row win conditions
            static bool CheckRow(int row, char player)
            {
                // checking for 1 | 2 | 3 and 4 | 5 | 6 and  7 | 8 | 9
                return gameboard[row, 0] == player && gameboard[row, 1] == player && gameboard[row, 2] == player;
            }

            // checking col win conditions
            static bool CheckCol(int col, char player)
            {
                // checking 1 | 4 | 7 and 2 | 5 | 8 and  3 | 6 | 9
                return gameboard[0, col] == player && gameboard[1, col] == player && gameboard[2, col] == player;
            }

            // check for a draw
            static bool CheckDraw()
            {
                if (CheckWinCondition() == false) // if the game isn't won / over yet
                {
                    for (int row = 0; row < 3; row++) // for each row (there are 3)
                    {
                        for (int col = 0; col < 3; col++) // for each col (there are 3)
                        {
                            if (gameboard[row, col] != 'X' && gameboard[row, col] != 'O') // check if the board has all X or O, if no, return false, if yes true is returned
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }

            static void GetPlayerMove()
            {
                int move;
                bool isValidMove;

                // do while runs atleast once, regardless of the condition
                do
                {
                    Console.Write($"Player {currentPlayer}, choose a number between 1-9: ");
                    isValidMove = int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9;  // TryParse checks if the input is an integer, if not if return false and if it is, its saved in the variable move

                    if (isValidMove)
                    {
                        // convert int to indicies
                        // checks for the dividend, which will be the row
                        int row = (move - 1) / 3;
                        // checks for the remainder of the division, which will be the col
                        int col = (move - 1) % 3;

                        if (gameboard[row, col] == 'X' || gameboard[row, col] == 'O')
                        {
                            Console.WriteLine($"The field is already occlupied with {gameboard[row, col]}.");
                            
                        }
                        else
                        {
                            // set the player to the chosen row and col in the array
                            gameboard[row, col] = currentPlayer;
                            // change currentPlayer to the opposite (from x to o and vice versa
                            if (CheckWinCondition() == false) // if the game isn't won / over yet
                            {
                                ChangePlayer();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid move, please enter a correct number between 1-9");
                    }
                } while (!isValidMove);
            }

            static bool PlayAgain()
            {
                string again = "";
                bool isEntryValid = false;

                // checking wether the entered string is "yes" or "no"
                while (!isEntryValid)
                {
                    Console.Write($"Wanna play again? Yes / No: ");
                    again = Console.ReadLine().ToLower();

                    if (again == "yes" || again == "no")
                    {
                        isEntryValid = true;
                    }
                    else
                    {
                        isEntryValid = false;
                    }

                    // if yes, clear console and play again, no just ends it
                    switch (again)
                    {
                        case "yes":
                            Console.Clear();
                            return true;
                        case "no":
                            return false;
                    }
                }
                return false;
            }

        }
    }
}