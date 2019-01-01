using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate.Demo
{
    public class AudioManager : MonoBehaviour
    {
        public enum EventType {Click, Sweep, Explode, Cancel }
        public static AudioManager instance = null;

        [Header("AudioPlayer")]
        public AudioSource bgmAudioPlayer;
        public AudioSource sfxAudioPlayer;

        [Header("Music")]
        public AudioClip gameBGM;
        public AudioClip successBGM;
        public AudioClip failBGM;

        [Header("System SFX")]
        public AudioClip clickSFX;
        public AudioClip cancelSFX;

        [Header("Game SFX")]
        public AudioClip explodeSFX;
        public AudioClip sweepSFX;
        public AudioClip tileClickSFX;


        private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

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

        private void LoadClip()
        {
            audioClips.Add("Click", clickSFX);
            audioClips.Add("Cancel", clickSFX);
            audioClips.Add("Explode", clickSFX);
            audioClips.Add("MainMenu", clickSFX);
            audioClips.Add("Explode", clickSFX);

        }

        public void PlaySFX(string name)
        {
            sfxAudioPlayer.Play();
        }

        public void PlayBGM(string name)
        {
            
        }
    }
}