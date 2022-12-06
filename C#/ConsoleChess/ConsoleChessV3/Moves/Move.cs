﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleChessV3.SuperClasses;

namespace ConsoleChessV3.Moves
{
    internal class Move : ChessMove
    {
        public Move(Space initialSpace, Space targetSpace, Space affectedSpace) : base(initialSpace, targetSpace, affectedSpace)
        {
            initialSpace.Piece.CanLegallyTryToMoveFromSpaceToSpace(initialSpace, targetSpace);
        }
    }
}