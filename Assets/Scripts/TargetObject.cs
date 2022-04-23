using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] List<Color> colors;

    int color = 0;

    private void Start()
    {
        if (!obj)
            obj = transform.GetChild(0).gameObject;
        if (!meshRenderer)
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        SetColor(color);
    }

    public void Zoom(float amount = 0.01f)
    {
        Vector3 currentScale = obj.transform.localScale;
        if (currentScale.x + amount > 0)
        {
            obj.transform.localScale = new Vector3(
                currentScale.x + amount,
                currentScale.y + amount,
                currentScale.z + amount
            );
            obj.transform.position = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + (amount / 2),
                obj.transform.position.z
            );
        }
    }

    public void SetColor(int num)
    {
        if (num >= 0 && num < colors.Count)
        {
            meshRenderer.material.color = colors[num];
            color = num;
        }
    }

    public void NextColor()
    {
        SetColor((color + 1) % colors.Count);
    }
}
