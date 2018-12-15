using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public struct Utils
    {
        /// <summary>
        /// Shuffles data in list using Fisher-Yates algorithm
        /// </summary>
        public static void Shuffle<T>(List<T> list)
        {
            int num = list.Count;

            for (int i = 0; i < list.Count; i++)
            {
                int randIndex = Random.Range(i, num);

                T temp = list[i];
                list[i] = list[randIndex];
                list[randIndex] = temp;
                
                num--;
            }
        }

    }
}
