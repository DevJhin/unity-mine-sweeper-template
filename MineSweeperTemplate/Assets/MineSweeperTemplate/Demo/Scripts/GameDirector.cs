using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace MineSweeperTemplate.Demo
{

    public enum GameEventType {GameStart, GameClear, GameOver}
    
    public class GameDirector : MonoBehaviour
    {
        public GameSettings gameSettings;

        [Header("Game Managers")]
        [SerializeField] BoardManager tileManager;
        [SerializeField] AudioManager audioManager;
        [SerializeField] LightManager lightManager;

        [Header("Controllers")]
        [SerializeField] CameraController cameraController;
        [SerializeField] PhysicsRaycaster rayCaster;
        

        private void OnEnable()
        {
            BoardManager.GameOverEvent += OnGameOver;
            BoardManager.GameClearEvent += OnGameClear;

            Tile.TileFlagEvent += OnFlagged;
        }

        private void OnDisable()
        {
            BoardManager.GameOverEvent -= OnGameOver;
            BoardManager.GameClearEvent -= OnGameClear;

            Tile.TileFlagEvent += OnFlagged;
        }

        private void Awake()
        {

        }

        private void Start()
        {
            OnGameStart();
        }

        public void OnFlagged()
        {


        }

        public void OnGameStart()
        {
            tileManager.GenerateTiles();
            lightManager.PlayLightEffect(GameEventType.GameStart);
          //  audioManager.PlayBGM();
        }

        public void OnGameClear()
        {
            rayCaster.enabled = false;
            lightManager.PlayLightEffect(GameEventType.GameClear);
        }


        public void OnGameOver()
        {
            rayCaster.enabled = false;
            lightManager.PlayLightEffect(GameEventType.GameOver);
        }

        public void OnGamePause()
        {
            rayCaster.enabled = false;
            Time.timeScale = 0;
        }



    }
}