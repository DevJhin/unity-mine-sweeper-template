using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageSettings",menuName ="Settings/Create Stage Settings")]
[System.Serializable]
public class StageSettings : ScriptableObject {
    public static string[] stageName = { "Stage" };

    public int Row { get; set; }
    public int Col { get; set; }

    public int MineNumber { get; set; }

    [SerializeField] int stage=1;


    public string GetStageName() {
        if (stage == 1)
        {
            return stageName[0]+" "+stage.ToString();
        }
        else {
            return null;
        }
    }


}
