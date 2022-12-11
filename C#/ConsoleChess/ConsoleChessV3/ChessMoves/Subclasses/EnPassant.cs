﻿namespace ConsoleChessV3.ChessMoves.Subclasses
{
    using ConsoleChessV3.ChessMoves;

    internal class EnPassant : ChessMove
    {
        public EnPassant(Space startingSpace, Space endingSpace) : base(startingSpace, endingSpace)
        {
            StartingSpace = startingSpace;
            TargetSpace = endingSpace;

            //CapturedSpace = piece to the left/right of pawn
            if (ChessBoard.Spaces is not null)
            {
                RestoreSpace =
                    StartingPiece.GetBelongsTo() == Enums.Player.White ?
                    ChessBoard.Spaces[TargetSpace.Column][TargetSpace.Row - 1] : // If WhitePawn
                    ChessBoard.Spaces[TargetSpace.Column][TargetSpace.Row + 1];  // If BlackPawn
            }
            RestorePiece = RestoreSpace?.Piece;
        }

        public override void Perform()
        {
            if (StartingPiece.CanLegallyTryToCaptureFromSpaceToSpace(StartingSpace, TargetSpace))
            {
                //TODO: Insert code to perform an EnPassant capture
                TargetSpace.Piece = StartingPiece;
                StartingSpace.Clear();
                RestorePiece = RestoreSpace?.Piece;
                if (RestoreSpace is not null)
                {
                    RestoreSpace.Clear();
                }
            }
        }

        public override void Reverse()
        {
            TargetSpace.Clear();
            if (RestoreSpace is not null)
            {
                RestoreSpace.Piece = RestorePiece;
            }
            if (RestoreSpace is not null && RestoreSpace.Piece is not null)
            {
                RestoreSpace.Piece.SetHasMoved(RestorePieceHasMoved);
            }

            StartingSpace.Piece = StartingPiece;
        }

        public override bool IsValidChessMove()
        {
            if (StartingSpace is not null && StartingSpace.Piece is not null)
            {
                if (StartingSpace.Piece.CanLegallyTryToCaptureFromSpaceToSpace(StartingSpace, TargetSpace))
                {
                    return true;
                }
            }
            return false;
        }
    }
}