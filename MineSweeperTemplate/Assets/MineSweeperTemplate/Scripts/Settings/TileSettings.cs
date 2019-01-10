using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    [CreateAssetMenu(fileName = "New Tile Settings", menuName = "Settings/Create New Tile Settings")]
    [System.Serializable]
    public class TileSettings : ScriptableObject
    {
        [Header("Text Color")]
        [SerializeField] List<Color> colors;

        [Header("Material")]
        [SerializeField] Material activatedMaterial;
        [SerializeField] Material sweepedMaterial;
        [SerializeField] Material flaggedMaterial;
        [SerializeField] Material explodedMaterial;

        public Color GetTextColor(int num)
        {
            return colors[num];
        }

        public Material GetTileMaterial(TileState state)
        {
            switch (state)
            {
                case TileState.Interactable:
                    {
                        return activatedMaterial;
                    }
                case TileState.Flagged:
                    {
                        return flaggedMaterial;
                    }
                case TileState.Sweeped:
                    {
                        return sweepedMaterial;
                    }
                case TileState.Exploded:
                    {
                        return explodedMaterial;
                    }
                default:
                    {
                        return null;
                    }

            }
        }


    }
}