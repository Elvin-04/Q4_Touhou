using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPattern : MonoBehaviour
{
    public p_Circle circlePattern;
    public p_DoubleSpiral spiralPattern;


    public void StartSpritalPattern()
    {
        spiralPattern.StartPattern();
    }
    
    public void StopSpiralPattern()
    {
        spiralPattern.StopPattern();
    }

    public void Circle()
    {
        circlePattern.StartPattern();
    }

    public void CircleRepeating(float delay)
    {
        circlePattern.StartPatternRepeating(delay);
    }

    public void StopCirclePattern()
    {
        circlePattern.StopPattern();
    }
}
