using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeper
{
    public class MineTile : Tile
    {

        public MineTile() : base(TileType.Mine) {
      
        }

        public override void OnClick()
        {
            
        }

        public override int Sweep()
        {
            if (State == TileState.Active)
            {
                State = TileState.Sweeped;
            }

            return -1;
        }
    }
}