﻿using ConsoleChess.Interfaces;
using ConsoleChess.Pieces;
using ConsoleChess.Enums;

namespace ConsoleChess
{
    internal static class Board
    {
        public static Space[][] spaces { get; set; } = new Space[8][];

        public static void InitBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                spaces[i] = new Space[8];
                for (int j = 0; j < 8; j++)
                {
                    spaces[i][j] = new Space();
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Space space = new Space();
                    space.X = i;
                    space.Y = j;
                    space.Piece = new Piece(name: "[ ]", Player.None);
                    spaces[i][j] = space;
                }
            }

            spaces[0][0].Piece = new Rook("[r]", Player.Black);
            spaces[0][1].Piece = new Knight("[n]", Player.Black);
            spaces[0][2].Piece = new Bishop("[b]", Player.Black);
            spaces[0][3].Piece = new Queen("[q]", Player.Black);
            spaces[0][4].Piece = new King("[k]", Player.Black);
            spaces[0][5].Piece = new Bishop("[b]", Player.Black);
            spaces[0][6].Piece = new Knight("[n]", Player.Black);
            spaces[0][7].Piece = new Rook("[r]", Player.Black);

            for (int i = 0; i < 8; i++)
            {
                spaces[1][i].Piece = new Pawn("[p]", Player.Black);
            }

            for (int i = 0; i < 8; i++)
            {
                spaces[6][i].Piece = new Pawn("[P]", Player.White);
            }

            spaces[7][0].Piece = new Rook("[R]", Player.White);
            spaces[7][1].Piece = new Knight("[N]", Player.White);
            spaces[7][2].Piece = new Bishop("[B]", Player.White);
            spaces[7][3].Piece = new Queen("[Q]", Player.White);
            spaces[7][4].Piece = new King("[K]", Player.White);
            spaces[7][5].Piece = new Bishop("[B]", Player.White);
            spaces[7][6].Piece = new Knight("[N]", Player.White);
            spaces[7][7].Piece = new Rook("[R]", Player.White);

            PrintBoard();
        }

        public static void PrintBoard()
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(8 - i);
                    }
                    Console.Write(spaces[i][j].Piece.Name);
                }

                Console.WriteLine();
            }
            Console.WriteLine("  A  B  C  D  E  F  G  H");
        }

        public static void MovePieceFromSpaceToSpace(Space fromSpace, Space toSpace)
        {
            toSpace.Piece = fromSpace.Piece;
            fromSpace.Piece = new Piece("[ ]", Player.None);
        }

        public static int NotationToInt(string? notation)
        {
            int translatedNotaion = -1;

            if (notation is not null)
            {

                switch (notation.ToUpper())
                {
                    case "A":
                    case "8":
                        translatedNotaion = 0;
                        break;
                    case "B":
                    case "7":
                        translatedNotaion = 1;
                        break;
                    case "C":
                    case "6":
                        translatedNotaion = 2;
                        break;
                    case "D":
                    case "5":
                        translatedNotaion = 3;
                        break;
                    case "E":
                    case "4":
                        translatedNotaion = 4;
                        break;
                    case "F":
                    case "3":
                        translatedNotaion = 5;
                        break;
                    case "2":
                    case "G":
                        translatedNotaion = 6;
                        break;
                    case "H":
                    case "1":
                        translatedNotaion = 7;
                        break;
                }
            }
            return translatedNotaion;
        }

        public static void CastleKingSideWhite()
        {
            //testing
            if (spaces[NotationToInt("1")][NotationToInt("F")].Piece.belongsToPlayer == Player.None &&
                spaces[NotationToInt("1")][NotationToInt("G")].Piece.belongsToPlayer == Player.None)
            {
                Rook myRook = (Rook)spaces[NotationToInt("1")][NotationToInt("H")].Piece;
                King myKing = (King)spaces[NotationToInt("1")][NotationToInt("E")].Piece;
                if (!myRook.hasMoved && !myKing.hasMoved)
                {
                    spaces[NotationToInt("1")][NotationToInt("E")].Piece = new Piece("[ ]", Player.None);
                    spaces[NotationToInt("1")][NotationToInt("H")].Piece = new Piece("[ ]", Player.None);

                    spaces[NotationToInt("1")][NotationToInt("G")].Piece = new King("[K]", Player.White);
                    spaces[NotationToInt("1")][NotationToInt("F")].Piece = new Rook("[R]", Player.White);
                }
            }
        }

        public static void CastleQueenSideWhite()
        {
            // works
            if (spaces[NotationToInt("1")][NotationToInt("B")].Piece.belongsToPlayer == Player.None &&
                spaces[NotationToInt("1")][NotationToInt("C")].Piece.belongsToPlayer == Player.None &&
                spaces[NotationToInt("1")][NotationToInt("D")].Piece.belongsToPlayer == Player.None)
            {
                Rook myRook = (Rook)spaces[NotationToInt("1")][NotationToInt("A")].Piece;
                King myKing = (King)spaces[NotationToInt("1")][NotationToInt("E")].Piece;
                if (!myRook.hasMoved && !myKing.hasMoved)
                {
                    spaces[NotationToInt("1")][NotationToInt("A")].Piece = new Piece("[ ]", Player.None);
                    spaces[NotationToInt("1")][NotationToInt("E")].Piece = new Piece("[ ]", Player.None);

                    spaces[NotationToInt("1")][NotationToInt("C")].Piece = new King("[k]", Player.Black);
                    spaces[NotationToInt("1")][NotationToInt("D")].Piece = new Rook("[r]", Player.Black);
                }
            }
        }

        public static void CastleKingSideBlack()
        {
            // works
            if (spaces[NotationToInt("8")][NotationToInt("F")].Piece.belongsToPlayer == Player.None &&
                spaces[NotationToInt("8")][NotationToInt("G")].Piece.belongsToPlayer == Player.None)
            {
                Rook myRook = (Rook)spaces[NotationToInt("8")][NotationToInt("H")].Piece;
                King myKing = (King)spaces[NotationToInt("8")][NotationToInt("E")].Piece;
                if (!myRook.hasMoved && !myKing.hasMoved)
                {
                    spaces[NotationToInt("8")][NotationToInt("E")].Piece = new Piece("[ ]", Player.None);
                    spaces[NotationToInt("8")][NotationToInt("H")].Piece = new Piece("[ ]", Player.None);

                    spaces[NotationToInt("8")][NotationToInt("G")].Piece = new King("[k]", Player.Black);
                    spaces[NotationToInt("8")][NotationToInt("F")].Piece = new Rook("[r]", Player.Black);
                }
            }
        }

        public static void CastleQueenSideBlack()
        {
            // works
            if (spaces[NotationToInt("8")][NotationToInt("B")].Piece.belongsToPlayer == Player.None &&
                spaces[NotationToInt("8")][NotationToInt("C")].Piece.belongsToPlayer == Player.None &&
                spaces[NotationToInt("8")][NotationToInt("D")].Piece.belongsToPlayer == Player.None)
            {
                Rook myRook = (Rook)spaces[NotationToInt("8")][NotationToInt("A")].Piece;
                King myKing = (King)spaces[NotationToInt("8")][NotationToInt("E")].Piece;
                if (!myRook.hasMoved && !myKing.hasMoved)
                {
                    spaces[NotationToInt("8")][NotationToInt("E")].Piece = new Piece("[ ]", Player.None);
                    spaces[NotationToInt("8")][NotationToInt("A")].Piece = new Piece("[ ]", Player.None);

                    spaces[NotationToInt("8")][NotationToInt("C")].Piece = new King("[k]", Player.Black);
                    spaces[NotationToInt("8")][NotationToInt("D")].Piece = new Rook("[r]", Player.Black);
                }
            }
        }
    }
}
