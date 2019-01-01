using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeperTemplate
{
    /// <summary>
    /// Determines how to render tiles
    /// UnityUI: render tiles with Unity UI components
    /// Unity3D: render tiles with 3D models
    /// </summary>
    /// 
    public enum RenderMode { UnityUI, Unity3D }

    [System.Serializable]
    public class VideoSettings
    {
        public RenderMode renderMode;
        public bool textureQuality;
        public bool postProcessing;
    }
}