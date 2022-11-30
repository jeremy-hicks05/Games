﻿namespace ConsoleChessV2.Pieces
{
    using static Notation;
    internal class BlackKing : Piece
    {
        
        public BlackKing()
        {
            Name = "[k]";
            PointValue = 99;
            BelongsTo = Player.Black;
        }

        public override bool CanLegallyTryToMoveFromSpaceToSpace(Space fromSpace, Space toSpace)
        {
            if (fromSpace == toSpace)
            {
                return false;
            }
            if (Math.Abs(fromSpace.Column - toSpace.Column) <= 1 && Math.Abs(fromSpace.Row - toSpace.Row) <= 1)
            {
                return true;
            }
            return false;
        }
        public override void CreateListOfPiecesToInspect(Space fromSpace, Space toSpace)
        {
            spacesToMoveToReview?.Clear();

            // if non-castling move
            if (fromSpace.Column - 1 >= 0)
            {
                // attacking left
                if (fromSpace.Column - 1 == toSpace.Column &&
                    fromSpace.Row == toSpace.Row)
                {
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column - 1][fromSpace.Row]);
                }
            }
            if (fromSpace.Row - 1 >= 0)
            {
                // attacking down
                if (fromSpace.Row - 1 == toSpace.Row &&
                    fromSpace.Column == toSpace.Column)
                {
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column][fromSpace.Row - 1]);
                }
            }
            if (fromSpace.Row + 1 <= 7)
            {
                // attacking up
                if (fromSpace.Row + 1 == toSpace.Row &&
                    fromSpace.Column == toSpace.Column)
                {
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column][fromSpace.Row + 1]);
                }
            }
            if (fromSpace.Column + 1 <= 7)
            {
                // attacking right
                if (fromSpace.Column + 1 == toSpace.Column &&
                    fromSpace.Row == toSpace.Row)
                {
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column + 1][fromSpace.Row]);
                }
            }
            if (fromSpace.Row + 1 <= 7 && fromSpace.Column + 1 <= 7)
            {
                // attacking up and right
                if (fromSpace.Row + 1 == toSpace.Row &&
                    fromSpace.Column + 1 == toSpace.Column)
                {
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column + 1][fromSpace.Row + 1]);
                }
            }
            if (fromSpace.Row + 1 <= 7 && fromSpace.Column - 1 >= 0)
            {
                // attacking up and left
                if (fromSpace.Row + 1 == toSpace.Row &&
                    fromSpace.Column - 1 == toSpace.Column)
                {
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column - 1][fromSpace.Row + 1]);
                }
            }
            if (fromSpace.Row - 1 >= 0 && fromSpace.Column + 1 <= 7)
            {
                // attacking down and right
                if (fromSpace.Row - 1 == toSpace.Row &&
                    fromSpace.Column + 1 == toSpace.Column)
                {
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column + 1][fromSpace.Row - 1]);
                }
            }
            if (fromSpace.Column - 1 >= 0 && fromSpace.Row - 1 >= 0)
            {
                // attacking down and left
                if (fromSpace.Row - 1 == toSpace.Row &&
                    fromSpace.Column - 1 == toSpace.Column)
                    spacesToMoveToReview?.Add(ChessBoard.Spaces![fromSpace.Column - 1][fromSpace.Row - 1]);
            }
            // if castling King side
            if (fromSpace.Row == toSpace.Row &&
                fromSpace.Column == C["E"] && toSpace.Column == C["G"])
            {
                spacesToMoveToReview?.Add(ChessBoard.Spaces![C["F"]][R["8"]]);
                spacesToMoveToReview?.Add(ChessBoard.Spaces![C["G"]][R["8"]]);
            }

            // if castling Queen side
            if (HasMoved == false &&
                fromSpace.Row == toSpace.Row &&
                fromSpace.Column == C["E"] && toSpace.Column == C["C"])
            {
                spacesToMoveToReview?.Add(ChessBoard.Spaces![C["B"]][R["8"]]);
                spacesToMoveToReview?.Add(ChessBoard.Spaces![C["C"]][R["8"]]);
                spacesToMoveToReview?.Add(ChessBoard.Spaces![C["D"]][R["8"]]);
            }
        }

        public override bool TryMove(Space fromSpace, Space toSpace)
        {
            Piece? tempFromSpacePiece = fromSpace.Piece;
            Piece? tempToSpacePiece = toSpace.Piece;

            ChessBoard.BlackKingSpace = toSpace;
            
            toSpace.Piece = fromSpace.Piece;

            fromSpace.Clear();
            ChessBoard.FindAllSpacesAttacked();

            // verify your king is not in check
            if (ChessBoard.turn == Player.White && ChessBoard.WhiteKingSpace!.IsUnderAttackByBlack)
            {
                // cancel move
                fromSpace.Piece = tempFromSpacePiece;
                toSpace.Piece = tempToSpacePiece;

                ChessBoard.BlackKingSpace = fromSpace;
                return false;
            }
            else if (ChessBoard.turn == Player.Black && ChessBoard.BlackKingSpace!.IsUnderAttackByWhite)
            {
                // cancel move
                fromSpace.Piece = tempFromSpacePiece;
                toSpace.Piece = tempToSpacePiece;

                ChessBoard.BlackKingSpace = fromSpace;
                return false;
            }
            fromSpace.Piece = tempFromSpacePiece;
            toSpace.Piece = tempToSpacePiece;

            ChessBoard.BlackKingSpace = fromSpace;
            return true;
        }

        public override bool TryCapture(Space fromSpace, Space toSpace)
        {
            Piece? tempFromSpacePiece = fromSpace.Piece;
            Piece? tempToSpacePiece = toSpace.Piece;

            ChessBoard.BlackKingSpace = toSpace;
            toSpace.Piece = fromSpace.Piece;

            fromSpace.Clear();
            toSpace.Clear();
            ChessBoard.FindAllSpacesAttacked();

            // verify your king is not in check
            if (ChessBoard.turn == Player.White && ChessBoard.WhiteKingSpace!.IsUnderAttackByBlack)
            {
                // cancel move
                fromSpace.Piece = tempFromSpacePiece;
                toSpace.Piece = tempToSpacePiece;

                ChessBoard.BlackKingSpace = fromSpace;

                return false;
            }
            else if (ChessBoard.turn == Player.Black && ChessBoard.BlackKingSpace!.IsUnderAttackByWhite)
            {
                // cancel move
                fromSpace.Piece = tempFromSpacePiece;
                toSpace.Piece = tempToSpacePiece;

                ChessBoard.BlackKingSpace = fromSpace;

                return false;
            }
            fromSpace.Piece = tempFromSpacePiece;
            toSpace.Piece = tempToSpacePiece;

            ChessBoard.BlackKingSpace = fromSpace;

            return true;
        }
    }
}
