using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    public enum GameDifficulty { Easy=10, Normal=20, Hard=30 }
    public enum GraphicLevel { Custom, Low, Mid, High }

    /// <summary>
    /// Determines how to render 
    /// Unity2D: renders using Unity UI components
    /// Unity3D: renders using 3D models
    /// </summary>
    public enum RenderMode { Unity2D, Unity3D }

    public enum BoardType { Rectangle, Cross, Hexagon, Cube }

    [CreateAssetMenu(fileName = "New MineSweeperOptions", menuName = "Settings/Create MineSweeper Options")]
    [System.Serializable]
    public class MineSweeperOptions : ScriptableObject
    {
        public GameSettings gameSettings;
        public VideoSettings videoSettings;
        public AudioSettings audioSettings;
    }

    [System.Serializable]
    public class GameSettings
    {
        [Header("Mode")]
        bool isCustomMode;

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

    }

    /// <summary>
    /// Settings for adjusting graphics 
    /// </summary>
    /// 
    [System.Serializable]
    public class VideoSettings
    {
        public GraphicLevel graphicQuality;
        public bool enableMotionBlur;
        public bool enableMSAA;
        public bool enableColorGrading;

        public bool textureQuality;
    }

    [System.Serializable]
    public class AudioSettings
    {
        public float masterVolume = 1;

        public float sfxVolume = 1;
        public bool sfxMuted = false;

        public float bgmVolume = 1;
        public bool bgmMuted = false;
    }

}