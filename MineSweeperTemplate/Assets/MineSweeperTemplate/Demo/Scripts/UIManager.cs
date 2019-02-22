using UnityEngine;
using UnityEngine.UI;

namespace MineSweeperTemplate.Demo
{
    public class UIManager : MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] Canvas mainCanvas;
        [SerializeField] Canvas gameClearCanvas;
        [SerializeField] Canvas gameOverCanvas;

        [Header("Text")]
        [SerializeField] Text mineCountText;
   

        public void OnFlagged()
        {
           // mineCountText = "Mines: " + 12.ToString(); 
        }

        public void SetMineText(int mineCount)
        {
            mineCountText.text = "Mines" + mineCount.ToString();
        }


    }
}