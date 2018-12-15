using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public enum TileType { Normal, Mine, Special}
    public enum TileState {Interactable, Flag, Disabled}

    public class Tile
    {
        public TileType Type { get; private set; }
        public TileState State { get; private set; }

        public int MineCount { get; set; }

        public Tile(TileType type)
        {
            Type = type;
        }

        public virtual void OnClick()
        {
            State = TileState.Disabled;
        }

        public void CreateTile(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Normal:
                    {
                        //Instantiate(normalTilePrefab);
                        break;
                    }

                case TileType.Mine:
                    {
                        //Instantiate(mineTilePrefab);
                        break;
                    }

            }
        }

    }
}
