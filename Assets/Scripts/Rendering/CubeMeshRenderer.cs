using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeMesh), typeof(TransformComponent))]
public class CubeMeshRenderer : MonoBehaviour
{
    private CubeMesh mesh;
    private CubeMesh Mesh => mesh == null ? (mesh = GetComponent<CubeMesh>()) : mesh;
    private TransformComponent transformComponent;
    private TransformComponent TransformComponent => transformComponent == null
        ? (transformComponent = GetComponent<TransformComponent>())
        : transformComponent;

    private Vector3[] transformMeshPoints = new Vector3[8];
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(TransformComponent.Position, TransformComponent.Right);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(TransformComponent.Position, TransformComponent.Up);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(TransformComponent.Position, TransformComponent.Forward);
        
        System.Array.Copy(Mesh.Points, transformMeshPoints, Mesh.Points.Length);
        for (var i = 0; i < transformMeshPoints.Length; i++)
        {
            transformMeshPoints[i] = TransformComponent.TransformPoint(transformMeshPoints[i]);
        }

        Gizmos.color = Mesh.Color;
        SimpleRenderer.DrawCube(transformMeshPoints);
    }
}
