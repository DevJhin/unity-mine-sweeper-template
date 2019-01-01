using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeperTemplate.Demo
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

        public Canvas mainCanvas;

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
            StartGame();
        }


        public void StartGame()
        {
            tileManager.GenerateTiles();
          //  audioManager.PlayBGM();
        }


        public void GameOver()
        {

        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

    }
}