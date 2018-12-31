using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    public class RectangleTileAlgorithm : TileAlgorithm
    {

        [SerializeField] int maxRow;
        [SerializeField] int maxColumn;

        public RectangleTileAlgorithm(int row, int column)
        {
            maxRow = row;
            maxColumn = column;
        }

        public override void SetAdjacentTiles(Tile tile, List<Tile> tiles)
        {
            List<Tile> adjacentTiles = new List<Tile>();

            int index = tile.index;

            int row = index / maxColumn;
            int column = index % maxColumn;

            if (CheckBound(row - 1, column - 1)) adjacentTiles.Add(tiles[GetIndex(row - 1, column - 1)]);
            if (CheckBound(row - 1, column)) adjacentTiles.Add(tiles[GetIndex(row - 1, column)]);
            if (CheckBound(row - 1, column + 1)) adjacentTiles.Add(tiles[GetIndex(row - 1, column + 1)]);

            if (CheckBound(row, column - 1)) adjacentTiles.Add(tiles[GetIndex(row, column - 1)]);
            if (CheckBound(row, column + 1)) adjacentTiles.Add(tiles[GetIndex(row, column + 1)]);

            if (CheckBound(row + 1, column - 1)) adjacentTiles.Add(tiles[GetIndex(row + 1, column - 1)]);
            if (CheckBound(row + 1, column)) adjacentTiles.Add(tiles[GetIndex(row + 1, column)]);
            if (CheckBound(row + 1, column + 1)) adjacentTiles.Add(tiles[GetIndex(row + 1, column + 1)]);


            tile.adjacentTiles.AddRange(adjacentTiles);
        }

        private int GetIndex(int row, int column)
        {
            return row * maxColumn + column;
        }

        private bool CheckBound(int row, int column)
        {
            if (row >= 0 && row < maxRow && column >= 0 && column < maxColumn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void LocateTiles(List<Tile> tiles, Transform board)
        {
            for (int row = 0; row < maxRow; row++)
            {
                for (int col = 0; col < maxColumn; col++)
                {
                    int index = GetIndex(row, col);
                    tiles[index].transform.parent = board;
                    tiles[index].transform.position = board.transform.position + new Vector3(col, 0, row);
                }
            }

        }
    }

}

    
