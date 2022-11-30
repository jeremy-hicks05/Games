﻿namespace ConsoleChessV2.Pieces
{
    internal class BlackBishop : Piece
    {
        public BlackBishop()
        {
            Name = "[b]";
            PointValue = 3;
            BelongsTo = Player.Black;
        }

        public override bool CanLegallyTryToMoveFromSpaceToSpace(Space fromSpace, Space toSpace)
        {
            if (fromSpace.Column != toSpace.Column && fromSpace.Row != toSpace.Row)
            {
                if ((float)Math.Abs(fromSpace.Column - toSpace.Column) / (float)Math.Abs(fromSpace.Row - toSpace.Row) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override void CreateListOfPiecesToInspect(Space fromSpace, Space toSpace)
        {
            spacesThisPieceCanMoveTo?.Clear();
            if (toSpace.Column > fromSpace.Column && toSpace.Row > fromSpace.Row)
            {
                // attacking up and right
                for (int column = fromSpace.Column + 1, row = fromSpace.Row + 1; column <= toSpace.Column && row <= toSpace.Row; column++, row++)
                {
                    spacesThisPieceCanMoveTo!.Add(ChessBoard.Spaces![column][row]);
                }
            }
            else if (toSpace.Column > fromSpace.Column && toSpace.Row < fromSpace.Row)
            {
                // attacking down and right
                for (int column = fromSpace.Column + 1, row = fromSpace.Row - 1; column <= toSpace.Column && row >= toSpace.Row; column++, row--)
                {
                    spacesThisPieceCanMoveTo!.Add(ChessBoard.Spaces![column][row]);
                }
            }
            else if (toSpace.Column < fromSpace.Column && toSpace.Row < fromSpace.Row)
            {
                // attacking down and left
                for (int column = fromSpace.Column - 1, row = fromSpace.Row - 1; column >= toSpace.Column && row >= toSpace.Row; column--, row--)
                {
                    spacesThisPieceCanMoveTo!.Add(ChessBoard.Spaces![column][row]);
                }
            }
            else if (toSpace.Column < fromSpace.Column && toSpace.Row > fromSpace.Row)
            {
                // attacking up and left
                for (int column = fromSpace.Column - 1, row = fromSpace.Row + 1; column >= toSpace.Column && row <= toSpace.Row; column--, row++)
                {
                    spacesThisPieceCanMoveTo!.Add(ChessBoard.Spaces![column][row]);
                }
            }
        }
    }
}
