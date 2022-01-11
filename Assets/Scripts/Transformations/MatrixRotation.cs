using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotation : MeshTranformation
{
    [SerializeField] private Vector3 rotation;

    public override void TransformPoint(Vector3[] points)
    {
        var rotY = RotationY();
        var rotX = RotationX();
        var rotZ = RotationZ();
        var result = rotY * rotX * rotZ;
        
        for (var i = 0; i < points.Length; i++)
        {
            points[i] = result * points[i];
        }
    }

    private Matrix3x3 RotationX()
    {
        var sinX = Mathf.Sin(rotation.x * Mathf.Deg2Rad);
        var cosX = Mathf.Cos(rotation.x * Mathf.Deg2Rad);
        var rot = new Matrix3x3(1, 0, 0, 0, cosX, -sinX, 0, sinX, cosX);
        return rot;
    }

    private Matrix3x3 RotationY()
    {
        var sinY = Mathf.Sin(rotation.y * Mathf.Deg2Rad);
        var cosY = Mathf.Cos(rotation.y * Mathf.Deg2Rad);
        var rot = new Matrix3x3(cosY, 0, sinY, 0, 1, 0, -sinY, 0, cosY);
        return rot;
    }

    private Matrix3x3 RotationZ()
    {
        var sinZ = Mathf.Sin(rotation.z * Mathf.Deg2Rad);
        var cosZ = Mathf.Cos(rotation.z * Mathf.Deg2Rad);
        var rot = new Matrix3x3(cosZ, -sinZ, 0, sinZ, cosZ, 0, 0, 0, 1);
        return rot;
    }
}
