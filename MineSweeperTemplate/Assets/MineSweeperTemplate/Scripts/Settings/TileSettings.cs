using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile Settings", menuName = "Settings/Create New Tile Settings")]
[System.Serializable]
public class TileSettings : ScriptableObject
{
    [Header("Prefabs")]
    public GameObject tile;

    [Header("Text Color")]
    public List<Color> color;

}
