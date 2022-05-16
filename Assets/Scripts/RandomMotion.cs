using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMotion : MonoBehaviour
{
    public float positionFrequency = 0.2f;
    public float positionAmplitude = 0.5f;
    public Vector3 positionScale = Vector3.one;
    [Range(0, 8)]
    public int positionFractalLevel = 3;

    const float fbmNorm = 1 / 0.75f;

    Vector3 initialPosition;
    float[] time;

    public void RecalculateTime()
    {
        for (var i = 0; i < 6; i++)
            time[i] = Random.Range(-10000.0f, 0.0f);
    }

    // Use this for initialization
    void Start()
    {
        time = new float[6];
        RecalculateTime();
    }

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        var dt = Time.deltaTime;

        for (var i = 0; i < 3; i++) time[i] += positionFrequency * dt;

        var n = new Vector3
        (
            Mathf.PerlinNoise(time[0], positionFractalLevel),
            Mathf.PerlinNoise(time[1], positionFractalLevel),
            Mathf.PerlinNoise(time[2], positionFractalLevel)
        );

        n = Vector3.Scale(n, positionScale);
        n *= positionAmplitude * fbmNorm;

        transform.localPosition = initialPosition + n;
    }
}
