using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeperTemplate
{
    public enum TileType { Normal, Mine }
    public enum TileState { Activated, Flagged, Sweeped }

    public class Tile : MonoBehaviour
    {
        public static TileSettings tileSettings;

        public TileType type;
        public TileState state;

        public int index;

        public int mineCount = 0;

        public List<Tile> adjacentTiles;

        public static event TileClickEventHandler TileClickEvent;
        public delegate void TileClickEventHandler(Tile tile);

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

        public virtual void OnClick(BaseEventData baseEventData)
        {
            PointerEventData pointerEventData = (PointerEventData)baseEventData;

            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                TileClickEvent(this);
            }
            else if (pointerEventData.button == PointerEventData.InputButton.Right)
            {
                OnFlag();
            }
        }
    }

}

