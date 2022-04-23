using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public void NextColor()
    {
        TargetObject[] targets = FindObjectsOfType<TargetObject>();
        if (targets.Length > 0) targets[0].NextColor();
    }
}
