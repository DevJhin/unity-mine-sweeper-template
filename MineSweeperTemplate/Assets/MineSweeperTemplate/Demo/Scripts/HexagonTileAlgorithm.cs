using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{/*
    public class HexagonTileAlgorithm : TileAlgorithm
    {
        int size;
        int line;

        public HexagonTileAlgorithm(int size)
        {
            this.size=size;
            for (int i = 0; i < size * 2 - 1; i++)
            {
                line.Add(size);
            }

        }

        public override void SetAdjacentTiles(Tile tile, List<Tile> tiles)
        {
            List<Tile> adjacentTiles = new List<Tile>();

            int index = tile.index;

            int line = index / maxColumn;
            int order = index % maxColumn;

            if (CheckBound(line - 1, order - 1)) adjacentTiles.Add(tiles[GetIndex(line - 1, order - 1)]);
            if (CheckBound(line - 1, order)) adjacentTiles.Add(tiles[GetIndex(line - 1, order)]);

            if (CheckBound(line, order - 1)) adjacentTiles.Add(tiles[GetIndex(line, order - 1)]);
            if (CheckBound(line, order + 1)) adjacentTiles.Add(tiles[GetIndex(line, order + 1)]);

            if (CheckBound(line + 1, order - 1)) adjacentTiles.Add(tiles[GetIndex(line + 1, order - 1)]);
            if (CheckBound(line + 1, order)) adjacentTiles.Add(tiles[GetIndex(line + 1, order)]);
            if (CheckBound(line + 1, order + 1)) adjacentTiles.Add(tiles[GetIndex(line + 1, order + 1)]);


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
    */
}

    
