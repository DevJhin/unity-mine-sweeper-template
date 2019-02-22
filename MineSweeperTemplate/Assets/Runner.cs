using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public enum FrameDependency { FrameDependent, FrameIndependent }
    public Transform target;
    float timer = 0;

    [Header("Settings")]
    public FrameDependency mode;
    [Range(0, 1)]
    public float dampCoefficient = 0.1f;
    public float delay = 0;

    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (mode == FrameDependency.FrameDependent)
        {
            StartCoroutine(FrameDependentDamp());
        }
        else if (mode == FrameDependency.FrameIndependent)
        {
            StartCoroutine(FrameIndependentDamp_3());
        }

        startPosition = transform.position;
    }

    IEnumerator FrameDependentDamp()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position, 0.03f);
            yield return null;
        }
    }

    IEnumerator FrameIndependentDamp_1()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
            yield return null;
        }
    }


    IEnumerator FrameIndependentDamp_2()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position, 1 - Mathf.Pow(1 - dampCoefficient, Time.deltaTime));
            yield return null;
        }
    }

    IEnumerator FrameIndependentDamp_3()
    {
        yield return new WaitForSeconds(delay);
        int frameCnt = 1;
        float time = 0;
        while (true)
        {

            transform.position = Vector3.Lerp(transform.position, target.position, 1 - Mathf.Pow(1 - dampCoefficient, time/frameCnt));
            time += Time.deltaTime;
            timer += Time.deltaTime;
            frameCnt++;
            yield return null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finished Running: "+ timer);
    }


}
