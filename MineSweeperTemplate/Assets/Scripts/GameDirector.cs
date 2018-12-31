using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeperTemplate
{
    public class GameDirector : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of GameDirector class
        /// </summary>
        public static GameDirector instance;

        public GameSettings gameSettings;

        [SerializeField] TileManager tileManager;
        [SerializeField] AudioManager audioManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }
        private void Start()
        {
            audioManager.PlayBGM();
        }


        public void StartGame()
        {
            tileManager.GenerateTiles();
            audioManager.PlayBGM();
        }

        public void GameEnd()
        {

        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

    }
}