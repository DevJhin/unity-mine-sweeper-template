using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public enum TileType { Normal = 0, Mine = -1, Special }
    public enum TileState { Active, Flag, Sweeped }

    public class Tile
    {
        public TileType Type { get; set; }
        public TileState State { get; set; }

        public int MineCount { get; set; }

        protected Tile(TileType type)
        {
            Type = type;
        }

        public virtual void OnClick()
        {
            if (State == TileState.Active)
            {
                State = TileState.Sweeped;
            }
        }

        public virtual void OnFlag()
        {
            if (State == TileState.Active)
            {
                State = TileState.Flag;
            }
        }

        public virtual int Sweep()
        {
            return 0;
        }

        public virtual void CreateTile()
        {

        }

    }
}

