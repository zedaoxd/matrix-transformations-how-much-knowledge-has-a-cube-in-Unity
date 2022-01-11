using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorScaler : MeshTranformation
{
    [SerializeField] private Vector3 scaler = Vector3.one;
    
    public override void TransformPoint(Vector3[] points)
    {
        var scaleMatrix = new Matrix3x3(scaler.x, 0, 0, 0, scaler.y, 0, 0, 0, scaler.z);
        for (var i = 0; i < points.Length; i++)
        {
            points[i] = scaleMatrix * points[i];
        }
    }
}
