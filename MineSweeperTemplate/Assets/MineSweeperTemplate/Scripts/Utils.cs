using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate
{
    public struct Utils
    {
        /// <summary>
        /// Shuffles a list by using Fisher-Yates algorithm
        /// </summary>
        public static void Shuffle<T>(List<T> list)
        {
            int size = list.Count;

            for (int index = 0; index < size; index++)
            {
                int randIndex = Random.Range(index, size);

                T temp = list[index];
                list[index] = list[randIndex];
                list[randIndex] = temp;
            }
        }

        /// <summary>
        /// Shuffles an array by using Fisher-Yates algorithm
        /// </summary>
        public static void Shuffle<T>(T[] data)
        {
            int size = data.Length;

            for (int index = 0; index < size; index++)
            {
                int randIndex = Random.Range(index, size);

                T temp = data[index];
                data[index] = data[randIndex];
                data[randIndex] = temp;
            }
        }

    }

}
