using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTranslation : MeshTranformation
{
    [SerializeField] 
    private Vector3 translation;
    public override void TransformPoint(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] += translation;
        }
    }
}
