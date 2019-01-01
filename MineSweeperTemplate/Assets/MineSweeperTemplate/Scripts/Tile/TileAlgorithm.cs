using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    public abstract class TileAlgorithm
    {
        /// <summary>
        /// Define algorithm to achieve adjacent tiles of a tile
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public abstract void SetAdjacentTiles(Tile tile, List<Tile> tiles);

        /// <summary>
        ///  Define algorithm to locate tiles
        /// </summary>
        /// <param name="tiles"></param>
        /// <param name="board"></param>
        public abstract void LocateTiles(List<Tile> tiles, Transform board);

    }
}