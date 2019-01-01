using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeperTemplate
{
    public enum TileType { Normal, Mine }
    public enum TileState { Active, Flag, Sweeped }

    public class Tile : MonoBehaviour
    {

        public static TileSettings tileSettings;

        public TileType type;
        public TileState state;

        public int index;

        public int mineCount = 0;

        public List<Tile> adjacentTiles;
        public TMPro.TextMeshPro textMesh;

        public MeshRenderer meshRenderer;

        private void Awake()
        {
            textMesh.enabled = false;
            adjacentTiles = new List<Tile>();
        }


        public virtual void OnFlagButtonClick()
        {
            if (state == TileState.Flag)
            {
                state = TileState.Active;
            }
            else if (state == TileState.Active)
            {
                state = TileState.Flag;
            }

        }


        public virtual void OnSweep()
        {
            if (state == TileState.Active)
            {
                meshRenderer.material.color = tileSettings.color[mineCount];
                textMesh.enabled = true;
                textMesh.text = mineCount.ToString();
                state = TileState.Sweeped;
            }
        }


        public void OnClick(BaseEventData baseEventData)
        {
            PointerEventData pointerEventData = (PointerEventData)baseEventData;

            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                TileManager.instance.Sweep(this);
            }
            else if(pointerEventData.button == PointerEventData.InputButton.Right)
            {
                OnFlagButtonClick();
            }
        }
    }

}

