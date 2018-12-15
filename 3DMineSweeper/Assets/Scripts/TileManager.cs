using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public class TileManager : MonoBehaviour
    {
        private Tile[,] tiles;

        public GameObject normalTilePrefab;
        public GameObject mineTilePrefab;

        public void GenerateTileData(int row, int col, int mineTileNum)
        {
            List<TileType> tileData = new List<TileType>();
            int totalTileNum = row * col;

            for (int i = 0; i < mineTileNum; i++)
            {
                tileData.Add(TileType.Mine);
            }

            tiles = new Tile[row, col];

            int normalTileNum = totalTileNum - mineTileNum;

            for (int i = 0; i < normalTileNum; i++)
            {
                tileData.Add(TileType.Normal);
            }

            MineSweeper.Utils.Shuffle(tileData);

            int cnt = 0;

            foreach (TileType tileType in tileData)
            {
                int r = cnt / col;
                int c = cnt % col;

                switch (tileType)
                {
                    case TileType.Normal:
                        {
                            tiles[r, c] = new NormalTile();
                            break;
                        }

                    case TileType.Mine:
                        {
                            {
                                tiles[r, c] = new MineTile();
                                break;
                            }

                        }
                }
                cnt++;
            }
        }

        /*
        public Tile CreateTile(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Normal:
                    {
                        
                        break;
                    }

                case TileType.Mine:
                    {
    
                        break;
                    }

            }
        }
        */
    }
}

    
