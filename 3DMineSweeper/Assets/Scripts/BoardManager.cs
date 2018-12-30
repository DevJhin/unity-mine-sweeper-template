using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public class BoardManager : MonoBehaviour
    {

        private Tile[][] tiles;

        [SerializeField] StageSettings settings;

        public GameObject normalTilePrefab;
        public GameObject mineTilePrefab;

        private void Awake()
        {
            
        }



        public void GenerateTileData(int row, int col, int mineTileNum)
        {
            List<TileType> tileData = new List<TileType>();

            int[][] adjacentMineCnt = new int[row][];
            for (int i = 0; i < row; i++)
            {
                adjacentMineCnt[i] = new int[col];
            }

            tiles = new Tile[row][];

            for (int i = 0; i < row; i++)
            {
                tiles[i] = new Tile[col];
            }

            int totalTileNum = row * col;

            for (int i = 0; i < mineTileNum; i++)
            {
                tileData.Add(TileType.Mine);
            }

            int normalTileNum = totalTileNum - mineTileNum;

            for (int i = 0; i < normalTileNum; i++)
            {
                tileData.Add(TileType.Normal);
            }

            MineSweeper.Utils.Shuffle(tileData);    //Shuffles data

            int cnt = 0;

            foreach (TileType tileType in tileData)
            {
                int r = cnt / col;
                int c = cnt % col;

                switch (tileType)
                {
                    case TileType.Normal:
                        {
                            tiles[r][c] = new NormalTile();
                            break;
                        }

                    case TileType.Mine:
                        {

                            tiles[r][c] = new MineTile();
                            break;

                        }
                }
                cnt++;
            }
        }

  

        public void RecursiveSweep(int row, int col)
        {
            //Out of bound
            if (row < 0 || row >= settings.Row || col < 0 || col >= settings.Col)
            {
                return;
            }
            else
            {
                    tiles[row][col].Sweep();
            }

            RecursiveSweep(row - 1, col - 1);
            RecursiveSweep(row - 1, col);
            RecursiveSweep(row - 1, col + 1);

            RecursiveSweep(row, col - 1);
            RecursiveSweep(row, col + 1);

            RecursiveSweep(row + 1, col - 1);
            RecursiveSweep(row + 1, col);
            RecursiveSweep(row + 1, col + 1);

        }

        public void ClickEvent(int row, int col)
        {
            RecursiveSweep(row, col);
        }


    }
}

    
