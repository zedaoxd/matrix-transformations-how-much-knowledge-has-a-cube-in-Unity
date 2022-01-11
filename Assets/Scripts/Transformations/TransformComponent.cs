using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformComponent : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 scale = Vector3.one;

    private Matrix4x4 modelMatrix;
    private Matrix4x4 rotationMatrix;

    public Vector3 Position
    {
        get => position;
        set
        {
            position = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Scale
    {
        get => scale;
        set
        {
            scale = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Right => rotationMatrix * Vector3.right;
    public Vector3 Up => rotationMatrix * Vector3.up;
    public Vector3 Forward => rotationMatrix * Vector3.forward;

    public Vector3 TransformPoint(in Vector3 point)
    {
        return modelMatrix.MultiplyPoint(point);
    }

    private void Awake()
    {
        UpdateModelMatrix();
    }

    private void OnValidate()
    {
        UpdateModelMatrix();
    }

    private void UpdateModelMatrix()
    {
        var scaleMatrix = new Matrix4x4(
            new Vector4(scale.x, 0, 0, 0),
            new Vector4(0, scale.y, 0, 0),
            new Vector4(0, 0, scale.z, 0),
            new Vector4(0, 0, 0, 1)
        );

        var rotX = RotationMatrixX();
        var rotY = RotationMatrixY();
        var rotZ = RotationMatrixZ();
        rotationMatrix = rotY * rotX * rotZ;

        var translationMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(position.x, position.y, position.z, 1)
        );

        modelMatrix = translationMatrix * rotationMatrix * scaleMatrix;
    }

    private Matrix4x4 RotationMatrixX()
    {
        var sin = Mathf.Sin(rotation.x * Mathf.Deg2Rad);
        var cos = Mathf.Cos(rotation.x * Mathf.Deg2Rad);
        var rot = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, cos, sin, 0),
            new Vector4(0, -sin, cos, 0),
            new Vector4(0, 0, 0, 1)
        );
        return rot;
    }
    
    private Matrix4x4 RotationMatrixY()
    {
        var sin = Mathf.Sin(rotation.y * Mathf.Deg2Rad);
        var cos = Mathf.Cos(rotation.y * Mathf.Deg2Rad);
        var rot = new Matrix4x4(
            new Vector4(cos, 0, -sin, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(sin, 0, cos, 0),
            new Vector4(0, 0, 0, 1)
        );
        return rot;
    }
    
    private Matrix4x4 RotationMatrixZ()
    {
        var sin = Mathf.Sin(rotation.z * Mathf.Deg2Rad);
        var cos = Mathf.Cos(rotation.z * Mathf.Deg2Rad);
        var rot = new Matrix4x4(
            new Vector4(cos, sin, 0, 0),
            new Vector4(-sin, cos, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        );
        return rot;
    }
    
}
