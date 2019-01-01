using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate.Demo
{
    public class DemoTile3D : Tile
    {
        private MeshRenderer meshRenderer;
        private TMPro.TextMeshPro textMesh;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            textMesh = GetComponent<TMPro.TextMeshPro>();
        }

        public override void OnSweep()
        {
            base.OnSweep();

            meshRenderer.material.color = TileManager.instance.tileSettings.GetTextColor(mineCount);
            textMesh.enabled = true;
            textMesh.text = mineCount.ToString();
        }

        public override void OnFlag()
        {
            base.OnFlag();
        }

        public virtual void OnClick()
        {


        }


    }
}