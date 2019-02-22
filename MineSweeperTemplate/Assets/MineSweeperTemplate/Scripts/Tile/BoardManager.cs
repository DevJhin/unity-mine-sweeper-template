using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate.Demo
{
    public class BoardManager : MonoBehaviour
    {
        private List<Tile> tiles;

        private List<Tile> mineTiles;
        private List<Tile> normalTiles;
        public GameObject board;

        public TileAlgorithm tileAlgorithm;


        [Header("Debug")]
        public int sweepedTileCount = 0;
        public int normalTileCount = 0;

        [Header("Settings")]
        public BoardSettings boardSettings;
        public TileSettings tileSettings;

        [Header("Prefabs")]
        public GameObject tilePrefab;

        [Header("MineSweep")]
        public float sweepIntervalTime;

        public bool isFirstClick=true;

        public static event GameOverEventHandler GameOverEvent;
        public delegate void GameOverEventHandler();

        public static event GameClearEventHandler GameClearEvent;
        public delegate void GameClearEventHandler();

        private void OnEnable()
        {
            Tile.TileExplodeEvent += Explode;
            Tile.TileSweepEvent += Sweep;
        }

        private void OnDisable()
        {
            Tile.TileExplodeEvent -= Explode;
            Tile.TileSweepEvent -= Sweep;
        }

        private void Start()
        {
            Tile.tileSettings = tileSettings;
            Tile[,,] test = new Tile[3,3,3];
            foreach (Tile tile in test)
            {
            }
            switch (boardSettings.boardType)
            {
                case BoardType.Rectangle:
                    {
                        tileAlgorithm = new RectangleTileAlgorithm(boardSettings.row, boardSettings.column);
                        break;
                    }
                case BoardType.Hexagon:
                    {
                        //tileAlgorithm = new HexagonTileAlgorithm(4);
                        break;
                    }
                case BoardType.Cube:
                    {
                        tileAlgorithm = new CubeTileAlgorithm(boardSettings.row, boardSettings.column, boardSettings.row);
                        break;
                    }
            }
        }

        public void GenerateTiles()
        {   
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

            tiles = new List<Tile>();

            mineTiles = new List<Tile>();
            normalTiles = new List<Tile>();

            for (int i = 0; i < tileData.Count; i++)
            {
                GenerateTile(i, tileData[i]);
            }

            SetAdjacentTiles();
            tileAlgorithm.LocateTiles(tiles, boardSettings);

            ComputeAdjacentMineCount();
        }

        private void GenerateTile(int index, TileType type)
        {
            GameObject newTile = Instantiate(tilePrefab) as GameObject;
            newTile.transform.parent = board.transform;
            Tile tile = newTile.GetComponent<Tile>();

            tile.index = index;
            tile.type = type;
            tile.state = TileState.Interactable;

            tiles.Add(tile);

            if (tile.type == TileType.Mine)
            {
                mineTiles.Add(tile);
            }
            else if (tile.type == TileType.Normal)
            {
                normalTiles.Add(tile);
            }

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
            isFirstClick = false;
            StartCoroutine(ProceduralSweep(tile));
        }


        private void Explode(Tile tile)
        {
            if (isFirstClick)
            {
                SwapTile(normalTiles[Random.Range(0,normalTiles.Count)], tile);
                isFirstClick = false;
                Sweep(tile);
            }
            else
            {             
                foreach (Tile mineTile in mineTiles)
                {
                    mineTile.OnExplode();
                }

                GameOverEvent();
               }
            Debug.Log("Explode!");
            isFirstClick = false;
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

                    if (tile.state == TileState.Interactable)
                    {
                        tile.OnSweep();
                        sweepedTileCount += 1;

                        switch (tile.type)
                        {
                            case TileType.Normal:
                                {
                                    if (tile.mineCount == 0)
                                    {
                                        foreach (Tile adjacentTile in tile.adjacentTiles)
                                        {
                                            queue.Enqueue(adjacentTile);
                                        }
                                    }
                                    break;
                                }
                            case TileType.Mine:
                                {

                                    break;
                                }
                        }
                    }
                }
                yield return new WaitForSeconds(sweepIntervalTime);
            }

            if (sweepedTileCount == tiles.Count - mineTiles.Count)
            {
                GameClearEvent();
            }
        }

        /// <summary>
        /// Compute the adjacent mine count
        /// </summary>
        protected void ComputeAdjacentMineCount()
        {
            foreach (Tile tile in mineTiles)
            {
                foreach (Tile adjacentTile in tile.adjacentTiles)
                {
                    adjacentTile.mineCount += 1;
                }

            }

        }

        public void ForceNormalPick(Tile tile)
        {
           // if(normal)
           // Tile normalTile = 
        }

        /// <summary>
        /// Swap the tile by changing their data
        /// </summary>
        private void SwapTile(Tile normalTile, Tile mineTile)
        {
            normalTile.type = TileType.Mine;
            mineTile.type = TileType.Normal;

            normalTiles.Remove(normalTile);
            normalTiles.Add(mineTile);

            mineTiles.Remove(mineTile);
            mineTiles.Add(normalTile);

            foreach (Tile adjacentTile in normalTile.adjacentTiles)
            {
                adjacentTile.mineCount += 1;
            }

            foreach (Tile adjacentTile in mineTile.adjacentTiles)
            {
                adjacentTile.mineCount -= 1;
            }
        }
    }
}

