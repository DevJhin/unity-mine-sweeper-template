using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public class NormalTile : Tile
    {

        public NormalTile() : base(TileType.Normal)
        {

        }

        public override int Sweep()
        {
            if (State == TileState.Active)
            {
                State = TileState.Sweeped;
            }

            return 0;
        }
    }
}