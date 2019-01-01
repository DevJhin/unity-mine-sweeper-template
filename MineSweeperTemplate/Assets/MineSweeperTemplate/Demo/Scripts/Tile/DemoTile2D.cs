using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MineSweeperTemplate
{
    public class DemoTile2D : Tile
    {


        private Image image;
        private Button button;

        private void Awake()
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();

        }


    }
}