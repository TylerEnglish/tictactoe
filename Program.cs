using System;
using System.Collections.Generic;

namespace Cse210Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Setting the state of board
            List<string> board = new List<string>(9) {"1","2","3","4","5","6","7","8","9"};

            // Game
            Game(board);            
        }
        static void Game(List<string> board)
        {
            //declare var
            bool won = false;
            bool player1 = true;
            string choice;
            List<string> boardCon = new List<string>();
            boardCon = board;

            //Game
            while (!won)
            {
                //Display board
                 BoardState(board);

                 //Check if it's player 1 turn or not
                 if (player1)
                 {
                     Console.Write("\nx's turn to choose a square (1-9)");
                     choice = Console.ReadLine();
                     board[board.IndexOf(choice)] = "x";
                 }
                 else
                 {
                     Console.Write("\no's turn to choose a square (1-9)");
                     choice = Console.ReadLine();
                     board[board.IndexOf(choice)] = "o";
                 }
                 //Change player turn
                 player1 = UserTurn(player1);

                //Check if someone won
                 boardCon = BoardCondition(board);
                 if (won == false)
                 {
                     won = WinCon(boardCon);
                 }

                 if (won == false)
                 {
                     won = Tie(board);
                 }
                 
                 
            }

            //Display winner
            Console.WriteLine("\n\n\n");
            BoardState(board);
            if (Tie(board))
            {
                Console.WriteLine("\n\n\nDang, you guys tied.");

            }
            else if (!player1)
            {
                Console.WriteLine("\n\n\nCongrates for Player 1! Good Game");
            }
            else
            {
                Console.WriteLine("\n\n\nCongrates for Player 2! Good Game");
            }
        }

        static void BoardState(List<string> board)
        {   
            // Produce the board state for tictactoe

            //Follow the index of board
            int i = 0;

            //r = row c = column
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    //Make the 1|2|3 pattern   
                    if (c < 2)
                    {
                        Console.Write( board[i]);
                        Console.Write("|");
                    }
                    else
                    {
                        Console.WriteLine(board[i]);
                    }
                    i++;
                }
                //Makes the -+-+- pattern
                if (r < 2)
                {
                    Console.WriteLine("-+-+-");
                }

            }

        }
        static bool UserTurn(bool player1)
        {
            //Checking players turn by checking if player1 went or not
            if (player1 == false)
            {
                player1 = true;
            }
            else 
            {
                player1 = false;
            }

            return player1;
        }
        static bool WinCon(List<string> board)
        {
            //Checking if someone won
            bool win = false;

            //Declaring the wining state
            List<string> winState = new List<string>();
            winState.Add("xxx");
            winState.Add("ooo");

            for (int i = 0; i < board.Count; i++)
            {
                if (board[i] == winState[0] || board[i] == winState[1])
                {
                    win = true;
                }
            }

            return win;
            
        }
        static List<string> BoardCondition(List<string> board)
        {

            //turning the board into conditions to check if someone won
            List<string> boardCondition = new List<string>();
            int i = 0;
            for (int rows = 0; rows < 3; rows++)
            {
                boardCondition.Add(board[i]+board[i+1]+board[i+2]);
                i = i+ 3;
            }
            i = 0;
            for (int col = 0; col < 3; col++)
            {
                boardCondition.Add(board[i]+board[i+3]+board[i+6]);
                i++;
            }
            boardCondition.Add(board[0]+board[4]+board[8]);
            boardCondition.Add(board[2]+board[4]+board[6]);

            return boardCondition;
        }
        static bool Tie(List<string> board)
        {
            bool isTie = false;
            foreach (string values in board)
            {
                if (char.IsDigit(values[0]))
                {
                    isTie = true;
                    break;
                    
                }   
                
            }
            return !isTie;
        }
    }
}