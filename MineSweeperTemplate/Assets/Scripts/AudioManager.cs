using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    public class AudioManager : MonoBehaviour
    {

        public static AudioManager instance = null;

        [Header("AudioPlayer")]
        public AudioSource bgmAudioPlayer;
        public AudioSource sfxAudioPlayer;

        [Header("BGM")]
        public AudioClip gameBGM;
        public AudioClip successBGM;
        public AudioClip failBGM;

        [Header("System Sound Effects")]
        public AudioClip clickSFX;
        public AudioClip cancelSFX;

        [Header("Tile Sound Effects")]
        public AudioClip explodeSFX;
        public AudioClip sweepSFX;

        void Awake()
        {
            //Check if instance already exists
            if (instance == null)
            {
                //if not, set instance to this
                instance = this;
            }
            //If instance already exists and it's not this:
            else if (instance != this)
            {
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
            }

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }

        public void PlaySFX()
        {

        }

        public void PlayBGM()
        {

        }
    }
}