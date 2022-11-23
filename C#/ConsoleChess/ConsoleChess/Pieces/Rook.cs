﻿using ConsoleChess.Interfaces;
using ConsoleChess.Players;

namespace ConsoleChess.Pieces
{
    internal class Rook : Piece
    {
        public Rook(string name, Player belongsTo) : base(name, belongsTo)
        {

        }

        public override void MoveTo(Space spaceMovedTo)
        {
            // move like a rook
            spaceMovedTo.Piece.Name = Name;
            Name = "[ ]";
        }

        public override bool CanMoveFromSpaceToSpace(Space fromSpace, Space toSpace)
        {
            if(fromSpace.X == toSpace.X || fromSpace.Y == toSpace.Y)
            {
                for(int i = fromSpace.X + 1; i <= toSpace.X; i++)
                {
                    if (Board.spaces[i][toSpace.Y].Piece.belongsToPlayer != Player.None)
                    {
                        return false;
                    }
                }

                for (int i = fromSpace.Y + 1; i < toSpace.Y; i++)
                {
                    if (Board.spaces[toSpace.X][i].Piece.belongsToPlayer != Player.None)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
