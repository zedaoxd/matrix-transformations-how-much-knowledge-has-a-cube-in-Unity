using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeshTranformation : MonoBehaviour
{
    public abstract void TransformPoint(Vector3[] points);
}
