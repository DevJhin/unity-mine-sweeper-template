using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate.Demo
{
    public class BoardManager : MonoBehaviour
    {
        private List<Tile> tiles;

        public GameObject board;

        public TileAlgorithm tileAlgorithm;

        [Header("Settings")]
        public BoardSettings boardSettings;
        public TileSettings tileSettings;

        [Header("Prefabs")]
        public GameObject tilePrefab;

        private void Awake()
        {
            Tile.TileClickEvent += Sweep;
        }

        private void Start()
        {
            boardSettings = GameDirector.instance.gameSettings.boardSettings;
            Tile.tileSettings = tileSettings;
            switch (boardSettings.boardType)
            {
                case BoardType.Rectangle:
                    {
                        tileAlgorithm = new RectangleTileAlgorithm(boardSettings.row, boardSettings.column);
                        break;
                    }
                case BoardType.Cross:
                    {
                        break;
                    }
                case BoardType.Hexagon:
                    {
                        break;
                    }
                case BoardType.Cube:
                    {
                        break;
                    }
            }
            GenerateTiles();
        }

        public void GenerateTiles()
        {
            tiles = new List<Tile>();

            List<TileType> tileData = new List<TileType>();

            int totalTileNum = boardSettings.GetTileNumber();

            int mineTileNum = boardSettings.GetMineTileNumber();
            int normalTileNum = totalTileNum - mineTileNum;

            for (int i = 0; i < mineTileNum; i++)
            {
                tileData.Add(TileType.Mine);
            }

            for (int i = 0; i < normalTileNum; i++)
            {
                tileData.Add(TileType.Normal);
            }

            MineSweeperTemplate.Utils.Shuffle(tileData);    //Shuffles data

            for (int i = 0; i < totalTileNum; i++)
            {
                GenerateTile(i, tileData[i]);
            }

            SetAdjacentTiles();
            tileAlgorithm.LocateTiles(tiles, boardSettings);
            CountAdjacentMine();
        }

        private void GenerateTile(int index, TileType type)
        {
            GameObject newTile = Instantiate(tilePrefab) as GameObject;
            Tile tile = newTile.GetComponent<Tile>();

            tile.index = index;
            tile.type = type;
            tile.state = TileState.Activated;

            tiles.Add(tile);
        }

        private void SetAdjacentTiles()
        {
            foreach (Tile tile in tiles)
            {
                tileAlgorithm.SetAdjacentTiles(tile, tiles);
            }
        }

        public void Sweep(Tile tile)
        {
            switch (tile.type)
            {
                case TileType.Mine:
                    {
                        //SendEvent
                        Explode(tile);
                        break;
                    }
                case TileType.Normal:
                    {
                        StartCoroutine(ProceduralSweep(tile));
                        break;
                    }
            }
        }

        private void Explode(Tile tile)
        {
            Debug.Log("Explode!");
        }


        IEnumerator ProceduralSweep(Tile firstTile)
        {
            Queue<Tile> queue = new Queue<Tile>();
            queue.Enqueue(firstTile);

            while (queue.Count != 0)
            {
                int cnt = queue.Count;

                for (int i = 0; i < cnt; i++)
                {
                    Tile tile = queue.Dequeue();

                    if (tile.type == TileType.Normal && tile.state == TileState.Activated)
                    {
                        tile.OnSweep();

                        if (tile.mineCount != 0)
                        {
                            foreach (Tile adjacentTile in tile.adjacentTiles)
                            {
                                queue.Enqueue(adjacentTile);
                            }
                        }
                    }
                }
                yield return null;
            }
        }

        protected void CountAdjacentMine()
        {
            foreach (Tile tile in tiles)
            {
                if (tile.type == TileType.Mine)
                {
                    foreach (Tile adjacentTile in tile.adjacentTiles)
                    {
                        adjacentTile.mineCount += 1;
                    }
                }
            }
        }
    }

}

