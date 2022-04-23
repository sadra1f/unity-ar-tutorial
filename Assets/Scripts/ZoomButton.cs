using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomButton : MonoBehaviour
{
    [SerializeField] float amount = 0.01f;

    public void Zoom()
    {
        TargetObject[] targets = FindObjectsOfType<TargetObject>();
        if (targets.Length > 0) targets[0].Zoom(amount);
    }
}
