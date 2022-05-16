using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCounter
{
    float duration;
    float maxTime;

    public void Start(float duration)
    {
        this.duration = duration;
        maxTime = 0.0f;
    }

    public void Reset()
    {
        maxTime = Time.time + duration;
    }

    public bool Ended()
    {
        return Time.time > maxTime;
    }
}
