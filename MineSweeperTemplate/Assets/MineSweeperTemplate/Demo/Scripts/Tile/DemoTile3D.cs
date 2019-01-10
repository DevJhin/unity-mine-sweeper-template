using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeperTemplate.Demo
{
    public class DemoTile3D : Tile
    {
        [SerializeField] MeshRenderer meshRenderer;
        [SerializeField] TMPro.TextMeshPro textMesh;

        private void Awake()
        {
            textMesh.enabled = false;
        }

        public override void OnSweep()
        {
            base.OnSweep();

            meshRenderer.material = tileSettings.GetTileMaterial(state);

            if (type == TileType.Normal)
            {
                if (mineCount != 0)
                {
                    textMesh.enabled = true;
                    textMesh.color = tileSettings.GetTextColor(mineCount);
                    textMesh.text = mineCount.ToString();
                }
                else
                {
                    textMesh.text = "";
                }
            }
            else if (type == TileType.Mine)
            {
                textMesh.enabled = true;
                textMesh.text = "X";
            }
        }

        public override void OnFlag()
        {
            base.OnFlag();
            meshRenderer.material = tileSettings.GetTileMaterial(state);
        }

        public override void OnClick(BaseEventData baseEventData)
        {
            base.OnClick(baseEventData);

        }
        public override void OnExplode()
        {
            base.OnExplode();
            meshRenderer.material = tileSettings.GetTileMaterial(state);
        }


    }
}