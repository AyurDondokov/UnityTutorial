using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public void TimeScaleChange(float TimeK) {
        Time.timeScale = TimeK;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
