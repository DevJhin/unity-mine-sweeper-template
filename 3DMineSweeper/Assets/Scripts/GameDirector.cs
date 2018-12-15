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

        [SerializeField] TileManager tileManager;
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
        }

        private void Start()
        {
            tileManager.GenerateTileData(tileRow, tileCol, mineNum);
        }


        public void ClickEvent(int row, int col) {

            Sweep(row,col);
        }

        public void Sweep(int row, int col)
        {

            if (row < 0 || row >= tileRow || col < 0 || col >= tileCol)
            {
                return;
            }
            else
            {
                
            }
            Sweep(row - 1, col-1);
            Sweep(row - 1, col);
            Sweep(row + 1, col+1);

            Sweep(row, col - 1);
            Sweep(row, col + 1);

        }

    }
}