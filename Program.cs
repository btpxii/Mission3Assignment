using System;

namespace Mission3Assignment
{
    class Driver
    {
        // Create a game board array to store the players' choices
        static char[] gameBoard = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static void Main(string[] args)
        {
            // Welcome the user to the game
            Console.WriteLine("Welcome User! You are now playing Tic-Tac-Toe");
            bool gameOver = false; // Initially set game over to false
            int turns = 0; // Count turns to determine which player is going (p1 is X, p2 is O)
            Supporting.printBoard(gameBoard); // Show blank game board
            while (!gameOver)
            {
                int playerNum = turns % 2 == 0 ? 1 : 2; // Set playerNum based on turn
                // Ask each player in turn for their choice
                Console.WriteLine("\nPlayer " + playerNum + ", where would you like to play?\nEnter an integer for spots 1-9:");
                // Validate player input
                int playSpot;
                try
                {
                    playSpot = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: You must enter an integer 1-9, signifying spots 1-9 on the board");
                    continue;
                }

                if (!ValidateInput(playSpot, gameBoard))
                {
                    continue;
                } else {
                    if (playerNum == 1) // Places an X if player 1 is playing
                    {
                        gameBoard[playSpot - 1] = 'X';
                    } else // Places an O if player 2 is playing
                    {
                        gameBoard[playSpot - 1] = 'O';
                    }
                    turns++; // Increments the turns variable, switching to the next player turn
                    // Print the board by calling the method in the supporting class
                    Supporting.printBoard(gameBoard);
                    // Check for a winner by calling the method in the supporting class
                    var turnResult = Supporting.checkWinner(gameBoard);
                    // notify the players when a win has occured and which player won the game
                    if (turnResult.Item1)
                    {
                        Console.WriteLine("Game Over!");
                        if (turnResult.Item2 == 'X')
                        {
                            Console.WriteLine("Player 1 wins!");
                        } else if (turnResult.Item2 == 'O')
                        {
                            Console.WriteLine("Player 2 wins!");
                        } else if (turnResult.Item2 == '-')
                        {
                            Console.WriteLine("The game ended in a draw!");
                        }
                    }
                    gameOver = turnResult.Item1; // Sets the while loop indicator to the result of the checkWinner function
                }

            }
        }
        static bool ValidateInput(int playSpot, char[] gameBoard)
        {
            if (playSpot < 1 || playSpot > 9) // Prevents player from entering an integer that isn't between 1 and 9
            {
                Console.WriteLine("Error: Your integer input must be 1-9, signifying spots 1-9 on the board");
                return false;
            } else if (gameBoard[playSpot - 1] == 'X' || gameBoard[playSpot - 1] == 'O') // Prevents player from playing on an already taken spot
            {
                Console.WriteLine("Error: The spot that you selected is not open");
                return false;
            } else
            {
                return true; // Allows player to proceed
            }
        }
    }
    class Supporting
    {
        public static void printBoard(char[] arr)
        {
            // Print numbered board
            if ((arr[0] == ' ') && (arr[1] == ' ') && (arr[2] == ' ') && (arr[3] == ' ') && (arr[4] == ' ') && (arr[5] == ' ') && (arr[6] == ' ') && (arr[7] == ' ') && (arr[8] == ' '))
            {
                Console.WriteLine("  1  |  2  |  3");
                Console.WriteLine("-----|-----|-----");
                Console.WriteLine("  4  |  5  |  6");
                Console.WriteLine("-----|-----|------");
                Console.WriteLine("  7  |  8  |  9");
            } else // Print playing board
            {
                Console.WriteLine("  " + arr[0] + "  |  " + arr[1] + "  |  " + arr[2]);
                Console.WriteLine("-----|-----|-----");
                Console.WriteLine("  " + arr[3] + "  |  " + arr[4] + "  |  " + arr[5]);
                Console.WriteLine("-----|-----|-----");
                Console.WriteLine("  " + arr[6] + "  |  " + arr[7] + "  |  " + arr[8]);
            }
        }
        public static (bool, char) checkWinner(char[] arr)
        {
            char winnerToken = ' ';
            bool gameOver = false;
            // horizontal wins
            if ((arr[0] == arr[1]) && (arr[0] == arr[2]) && arr[0] != ' ')
            {
                winnerToken = arr[0];
                gameOver = true;
            }
            else if ((arr[3] == arr[4]) && (arr[3] == arr[5]) && arr[3] != ' ')
            {
                winnerToken = arr[3];
                gameOver = true;
            }
            else if ((arr[6] == arr[7]) && (arr[6] == arr[8]) && arr[6] != ' ')
            {
                winnerToken = arr[6];
                gameOver = true;
            }
            //vertical wins
            else if ((arr[0] == arr[3]) && (arr[0] == arr[6]) && arr[0] != ' ')
            {
                winnerToken = arr[0];
                gameOver = true;
            }
            else if ((arr[1] == arr[4]) && (arr[1] == arr[7]) && arr[1] != ' ')
            {
                winnerToken = arr[1];
                gameOver = true;
            }
            else if ((arr[2] == arr[5]) && (arr[2] == arr[8]) && arr[2] != ' ')
            {
                winnerToken = arr[2];
                gameOver = true;
            }
            //diagonal win
            else if ((arr[0] == arr[4]) && (arr[0] == arr[8]) && arr[0] != ' ')
            {
                winnerToken = arr[0];
                gameOver = true;
            }
            else if ((arr[2] == arr[4]) && (arr[2] == arr[6]) && arr[2] != ' ')
            {
                winnerToken = arr[2];
                gameOver = true;
            }
            //draw
            else if ((arr[0] != ' ') && (arr[1] != ' ') && (arr[2] != ' ') && (arr[3] != ' ') && (arr[4] != ' ') && (arr[5] != ' ') && (arr[6] != ' ') && (arr[7] != ' ') && (arr[8] != ' '))
            {
                winnerToken = '-';
                gameOver = true;
            }
            return (gameOver, winnerToken);
        }
    }
}
