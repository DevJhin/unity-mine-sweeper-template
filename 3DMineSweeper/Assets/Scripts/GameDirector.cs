using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeper
{
    public class GameDirector : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of GameDirector class
        /// </summary>
        public static GameDirector instance;

        [SerializeField] StageManager stageManager;
        [SerializeField] AudioManager audioManager;

        [SerializeField] int tileRow;
        [SerializeField] int tileCol;

        [SerializeField] int mineNum;

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

            OnStageStart();
        }


        public void OnStageStart() {
            stageManager.GenerateTileData(tileRow, tileCol, mineNum);           
        }

        public void OnStageEnd()
        {
           
        }

   
    }
}