using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeperTemplate
{
    [CreateAssetMenu(fileName = "New BoardSettings", menuName = "Settings/Create Board Settings")]
    [System.Serializable]
    public class BoardSettings:ScriptableObject
    {
        public BoardType boardType;

        public int row;
        public int column;

        public int mineTileNumber;

        public int GetTileNumber()
        {
            return row*column;
        }

        public int GetMineTileNumber()
        {
            return mineTileNumber;
        }
    }
}