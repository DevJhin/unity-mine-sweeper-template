using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeperTemplate
{
    public enum TileType { Normal, Mine }
    public enum TileState { Interactable, Flagged, Sweeped, Exploded }

    public class Tile : MonoBehaviour
    {
        public static TileSettings tileSettings;

        public TileType type;
        public TileState state;

        public int index;

        public int mineCount = 0;

        public List<Tile> adjacentTiles;

        public static event TileExplodeEventHandler TileExplodeEvent;
        public delegate void TileExplodeEventHandler(Tile tile);

        public static event TileSweepEventHandler TileSweepEvent;
        public delegate void TileSweepEventHandler(Tile tile);

        public static event TileFlagEventHandler TileFlagEvent;
        public delegate void TileFlagEventHandler();

        public virtual void OnFlag()
        {
            if (state == TileState.Flagged)
            {
                state = TileState.Interactable;
            }
            else if (state == TileState.Interactable)
            {
                state = TileState.Flagged;
            }

        }

        public virtual void OnExplode()
        {
            if (state == TileState.Interactable)
            {
                state = TileState.Exploded;
            }
        }

        public virtual void OnSweep()
        {
            if (state == TileState.Interactable)
            {
                state = TileState.Sweeped;
            }
        }


        public virtual void OnClick(BaseEventData baseEventData)
        {
            PointerEventData pointerEventData = (PointerEventData)baseEventData;

            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Left Click");
                switch (type)
                {
                    case TileType.Mine:
                        {
                            if (state == TileState.Interactable)
                            {
                                TileExplodeEvent(this);
                            }
                            break;
                        }
                    case TileType.Normal:
                        {
                            if (state == TileState.Interactable)
                            {
                                TileSweepEvent(this);
                            }
                            break;
                        }
                }
            }
            else if (pointerEventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Right Click");
                TileFlagEvent();
                OnFlag();
            }
        }
    }

}

