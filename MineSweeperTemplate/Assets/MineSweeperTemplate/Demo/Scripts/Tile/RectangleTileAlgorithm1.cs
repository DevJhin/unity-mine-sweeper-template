using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    public class CubeTileAlgorithm : TileAlgorithm
    {

        [SerializeField] int maxRow;
        [SerializeField] int maxColumn;
        [SerializeField] int maxHeight;

        public CubeTileAlgorithm(int row, int column, int height)
        {
            maxRow = row;
            maxColumn = column;
            maxHeight = height;
        }

        public override void SetAdjacentTiles(Tile tile, List<Tile> tiles)
        {
            List<Tile> adjacentTiles = new List<Tile>();

            int index = tile.index;

            int height = 0;
            int row = index / maxColumn;
            int column = index % maxColumn;

            /*
            if (CheckBound(row - 1, column - 1, height - 1) adjacentTiles.Add(tiles[GetIndex(row - 1, column - 1, column - 1)]);
            if (CheckBound(row - 1, column)) adjacentTiles.Add(tiles[GetIndex(row - 1, column)]);
            if (CheckBound(row - 1, column + 1)) adjacentTiles.Add(tiles[GetIndex(row - 1, column + 1)]);

            if (CheckBound(row, column - 1)) adjacentTiles.Add(tiles[GetIndex(row, column - 1)]);
            if (CheckBound(row, column + 1)) adjacentTiles.Add(tiles[GetIndex(row, column + 1)]);

            if (CheckBound(row + 1, column - 1)) adjacentTiles.Add(tiles[GetIndex(row + 1, column - 1)]);
            if (CheckBound(row + 1, column)) adjacentTiles.Add(tiles[GetIndex(row + 1, column)]);
            if (CheckBound(row + 1, column + 1)) adjacentTiles.Add(tiles[GetIndex(row + 1, column + 1)]);
            */
            
            tile.adjacentTiles.AddRange(adjacentTiles);
        }

        private int GetIndex(int row, int column, int height)
        {
            return row * maxColumn + column;
        }

        private bool CheckBound(int row, int column, int height)
        {
            if (row >= 0 && row < maxRow && column >= 0 && column < maxColumn && column < maxHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void LocateTiles(List<Tile> tiles, BoardSettings settings)
        {
            Vector3 startPos = new Vector3(settings.tileSize.x, 0, settings.tileSize.z);

            for (int row = 0; row < maxRow; row++)
            {
                for (int col = 0; col < maxColumn; col++)
                {
                    for (int height = 0; col < maxColumn; col++)
                    {
                        int index = GetIndex(row, col, height);
                        tiles[index].transform.localPosition = new Vector3(settings.tileSize.x * col, 0, -settings.tileSize.z * row);
                    }
                }
            }

        }
    }

}

    
