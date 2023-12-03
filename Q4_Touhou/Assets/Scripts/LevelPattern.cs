using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPattern : MonoBehaviour
{
    public p_Circle circlePattern;
    public p_DoubleSpiral doubleSpiralPattern;
    public p_Spiral spiralSpiral;

    public void StartSpritalPattern()
    {
        doubleSpiralPattern.StartPattern();
    }
    
    public void StopSpiralPattern()
    {
        doubleSpiralPattern.StopPattern();
    }

    public void StartOneSpiralPattern()
    {
        spiralSpiral.StartPattern();
    }
    
    public void StopOneSpiralPattern()
    {
        spiralSpiral.StopPattern();
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
