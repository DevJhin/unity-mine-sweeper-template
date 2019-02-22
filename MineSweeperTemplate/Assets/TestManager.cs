using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public enum FrameRateMode { TargetFrameRate, Fluctuate }

    [Header("Settings")]
    public int fps;
    public Runner.FrameDependency frameDependency;
    public FrameRateMode frameRateMode = FrameRateMode.TargetFrameRate;

    [Header("Object Reference")]
    public Runner runner;
    // Start is called before the first frame update
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;

        runner.mode = frameDependency;
        if (frameRateMode == FrameRateMode.Fluctuate)
        {
            StartCoroutine(FluctuateFrameRate());
        }
    }

    IEnumerator FluctuateFrameRate()
    {
        bool flag = false;
        while (true)
        {
            SetFrameRate(flag ? Random.Range(10, 50) : Random.Range(800, 1000));
            flag = !flag;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void SetFrameRate(int fps)
    {
        Application.targetFrameRate = fps;
    }

}
