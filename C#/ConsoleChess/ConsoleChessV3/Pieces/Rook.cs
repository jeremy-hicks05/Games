﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleChessV3.SuperClasses;

namespace ConsoleChessV3.Pieces
{
    internal class Rook : Piece
    {
        public override bool CanLegallyTryToMoveFromSpaceToSpace(Space fromSpace, Space toSpace)
        {
            return fromSpace.Column - toSpace.Column == 0 ||
                    fromSpace.Row - toSpace.Row == 0;
        }

        public override bool CanLegallyTryToCaptureFromSpaceToSpace(Space fromSpace, Space toSpace)
        {
            return toSpace.Piece is not null &&
                fromSpace.Piece is not null &&
                CanLegallyTryToMoveFromSpaceToSpace(fromSpace, toSpace)
                && fromSpace.Piece.GetBelongsTo() != toSpace.Piece.GetBelongsTo();
        }

        public override void BuildListOfSpacesToInspect(Space fromSpace, Space toSpace)
        {
            SpacesToReview.Clear();
            if (toSpace.Column > fromSpace.Column && toSpace.Row == fromSpace.Row)
            {
                // attacking right
                for (int column = fromSpace.Column + 1; column <= toSpace.Column; column++)
                {
                    SpacesToReview.Add(ChessBoard.Spaces![column][fromSpace.Row]);
                }
            }
            else if (toSpace.Column < fromSpace.Column && toSpace.Row == fromSpace.Row)
            {
                // attacking left
                for (int column = fromSpace.Column - 1; column >= toSpace.Column; column--)
                {
                    SpacesToReview.Add(ChessBoard.Spaces![column][fromSpace.Row]);
                }
            }
            else if (toSpace.Column == fromSpace.Column && toSpace.Row < fromSpace.Row)
            {
                // attacking down
                for (int row = fromSpace.Row - 1; row >= toSpace.Row; row--)
                {
                    SpacesToReview.Add(ChessBoard.Spaces![fromSpace.Column][row]);
                }
            }
            else if (toSpace.Column == fromSpace.Column && toSpace.Row > fromSpace.Row)
            {
                // attacking up
                for (int row = fromSpace.Row + 1; row <= toSpace.Row; row++)
                {
                    SpacesToReview.Add(ChessBoard.Spaces![fromSpace.Column][row]);
                }
            }
        }
    }
}
