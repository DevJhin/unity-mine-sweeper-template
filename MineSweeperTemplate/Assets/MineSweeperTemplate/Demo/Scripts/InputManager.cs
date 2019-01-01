using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MineSweeperTemplate.Demo
{
    public class InputManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClick(BaseEventData baseEventData)
        {
            PointerEventData pointerEventData = (PointerEventData)baseEventData;

            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                //TileManager.instance.Sweep(gameObject);
            }
            else if (pointerEventData.button == PointerEventData.InputButton.Right)
            {
               // OnFlag;
            }
        }
    }
}