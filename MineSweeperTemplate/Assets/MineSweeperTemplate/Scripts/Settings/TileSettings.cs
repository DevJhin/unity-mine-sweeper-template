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
        [SerializeField] Material sweepMaterial;
        [SerializeField] Material flagMaterial;

        [SerializeField] Material mineMaterial;

        public Color GetTextColor(int num)
        {
            return colors[num];
        }


    }
}