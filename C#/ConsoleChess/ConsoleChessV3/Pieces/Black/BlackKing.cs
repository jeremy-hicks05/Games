﻿namespace ConsoleChessV3.Pieces.Black
{
    using static ConsoleChessV3.Enums.Notation;
    internal class BlackKing : King
    {
        public BlackKing()
        {
            Name = "k";
            BelongsTo = Enums.Player.Black;
        }

        public override void BuildListOfSpacesToInspect(Space fromSpace, Space toSpace)
        {
            SpacesToReview.Clear();

            if (ChessBoard.Spaces is not null)
            {
                // if non-castling move
                if (fromSpace.Column - 1 >= 0)
                {
                    // attacking left
                    if (fromSpace.Column - 1 == toSpace.Column &&
                        fromSpace.Row == toSpace.Row)
                    {
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column - 1][fromSpace.Row]);
                    }
                }
                if (fromSpace.Row - 1 >= 0)
                {
                    // attacking down
                    if (fromSpace.Row - 1 == toSpace.Row &&
                        fromSpace.Column == toSpace.Column)
                    {
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column][fromSpace.Row - 1]);
                    }
                }
                if (fromSpace.Row + 1 <= 7)
                {
                    // attacking up
                    if (fromSpace.Row + 1 == toSpace.Row &&
                        fromSpace.Column == toSpace.Column)
                    {
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column][fromSpace.Row + 1]);
                    }
                }
                if (fromSpace.Column + 1 <= 7)
                {
                    // attacking right
                    if (fromSpace.Column + 1 == toSpace.Column &&
                        fromSpace.Row == toSpace.Row)
                    {
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column + 1][fromSpace.Row]);
                    }
                }
                if (fromSpace.Row + 1 <= 7 && fromSpace.Column + 1 <= 7)
                {
                    // attacking up and right
                    if (fromSpace.Row + 1 == toSpace.Row &&
                        fromSpace.Column + 1 == toSpace.Column)
                    {
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column + 1][fromSpace.Row + 1]);
                    }
                }
                if (fromSpace.Row + 1 <= 7 && fromSpace.Column - 1 >= 0)
                {
                    // attacking up and left
                    if (fromSpace.Row + 1 == toSpace.Row &&
                        fromSpace.Column - 1 == toSpace.Column)
                    {
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column - 1][fromSpace.Row + 1]);
                    }
                }
                if (fromSpace.Row - 1 >= 0 && fromSpace.Column + 1 <= 7)
                {
                    // attacking down and right
                    if (fromSpace.Row - 1 == toSpace.Row &&
                        fromSpace.Column + 1 == toSpace.Column)
                    {
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column + 1][fromSpace.Row - 1]);
                    }
                }
                if (fromSpace.Column - 1 >= 0 && fromSpace.Row - 1 >= 0)
                {
                    // attacking down and left
                    if (fromSpace.Row - 1 == toSpace.Row &&
                        fromSpace.Column - 1 == toSpace.Column)
                        SpacesToReview.Add(ChessBoard.Spaces[fromSpace.Column - 1][fromSpace.Row - 1]);
                }
                // if castling King side
                if ((HasMoved == false &&
                    (ChessBoard.Spaces[C["H"]][R["8"]].Piece is Rook) &&
                    ChessBoard.Spaces[C["H"]][R["8"]].Piece is not null &&
                    ChessBoard.Spaces[C["H"]][R["8"]].Piece?.GetHasMoved() == false &&
                    fromSpace.Row == toSpace.Row &&
                    fromSpace.Column == C["E"] && toSpace.Column == C["G"]))
                {
                    SpacesToReview.Add(ChessBoard.Spaces[C["F"]][R["8"]]);
                    SpacesToReview.Add(ChessBoard.Spaces[C["G"]][R["8"]]);
                }

                // if castling Queen side
                else if (HasMoved == false &&
                    ChessBoard.Spaces[C["A"]][R["8"]].Piece is Rook &&
                    ChessBoard.Spaces[C["A"]][R["8"]].Piece?.GetHasMoved() == false &&
                    fromSpace.Row == toSpace.Row &&
                    fromSpace.Column == C["E"] && toSpace.Column == C["C"])
                {
                    SpacesToReview.Add(ChessBoard.Spaces[C["B"]][R["8"]]);
                    SpacesToReview.Add(ChessBoard.Spaces[C["C"]][R["8"]]);
                    SpacesToReview.Add(ChessBoard.Spaces[C["D"]][R["8"]]);
                }
            }
        }
    }
}
