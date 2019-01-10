using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    public enum BoardType { Rectangle, Cross, Hexagon, Cube }
    public enum GameDifficulty { Easy = 10, Normal = 20, Hard = 30,Custom }

    [System.Serializable]
    public class GameSettings
    {
        [Header("Difficulty")]
        public GameDifficulty difficulty;

        [Header("Board Settings")]
        public BoardType boardType;
        public BoardSettings boardSettings;

        [Header("Advanced")]
        [Tooltip("Counts the adjacent mines for each tiles before the game starts. This may increase the loading time, but it can reduce the calculation during runtime")]
        public bool countAdjacentMinesBeforePlay = true;

        [Tooltip("Forces the first tile to be 'normal' tile, not 'mine' tile. This prevents from player finding a mine at the first click and ends at the just beginning")]
        public bool forceFirstTileToNormal = true;

        [Tooltip("Enable AI")]
        public bool enableAI = true;

        [Tooltip("Disable animation/")]
        public bool fastMode = true;
    }

}