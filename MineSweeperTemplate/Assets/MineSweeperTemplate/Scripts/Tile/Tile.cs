using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeperTemplate
{
    public enum TileType { Normal, Mine }
    public enum TileState { Activated, Flagged, Sweeped }

    public class Tile : MonoBehaviour
    {

        public TileType type;
        public TileState state;

        public int index;

        public int mineCount = 0;

        public List<Tile> adjacentTiles;


        public virtual void OnFlag()
        {
            if (state == TileState.Flagged)
            {
                state = TileState.Activated;
            }
            else if (state == TileState.Activated)
            {
                state = TileState.Flagged;
            }

        }


        public virtual void OnSweep()
        {
            if (state == TileState.Activated)
            {
                state = TileState.Sweeped;
            }
        }

    }

}

