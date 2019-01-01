using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
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