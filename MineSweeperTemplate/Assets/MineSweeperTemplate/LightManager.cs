using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeperTemplate.Demo
{
    public class LightManager : MonoBehaviour
    {
        [Header("Main Light")]
        [SerializeField] Light directionalLight;

        [Header("Light Settings")]
        [SerializeField] LightSettings gameStartLight;
        [SerializeField] LightSettings gameClearLight;
        [SerializeField] LightSettings gameOverLight;

        LightSettings targetLightSettings;

        float playTime = 0;
        bool isPlaying = false;

        public void PlayLightEffect(GameEventType gameEventType)
        {
            switch (gameEventType)
            {
                case GameEventType.GameStart:
                    {
                        targetLightSettings = gameStartLight;
                        break;
                    }
                case GameEventType.GameClear:
                    {
                        targetLightSettings = gameClearLight;
                        break;
                    }
                case GameEventType.GameOver:
                    {
                        targetLightSettings = gameOverLight;
                        break;
                    }
            }

            if (!isPlaying)
            {
                StartCoroutine(LightEffect());
            }
            else
            {
                //Reset play time
                playTime = 0;
            }
        }

        IEnumerator LightEffect()
        {
            isPlaying = true;
            Color startColor = directionalLight.color;
            float startIntensity = directionalLight.intensity;
            playTime = 0;

            while (playTime < 1)
            {
                directionalLight.color = Color.Lerp(startColor, targetLightSettings.color, playTime);
                directionalLight.intensity = Mathf.Lerp(startIntensity, targetLightSettings.intensity, playTime);
                playTime += Time.deltaTime;
                yield return null;
            }
            isPlaying = false;
        }

    }

    [System.Serializable]
    public struct LightSettings
    {
        public Color color;
        public float intensity;
    }
}