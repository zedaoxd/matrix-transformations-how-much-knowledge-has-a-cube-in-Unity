using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformComponent))]
public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float acceleration = 10;
    private TransformComponent transformComponent;
    private Vector3 velocity;

    private void Awake()
    {
        transformComponent = GetComponent<TransformComponent>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var targetVelocity = new Vector3(horizontal, 0, vertical) * moveSpeed;

        velocity = Vector3.Lerp(velocity, targetVelocity, acceleration * Time.deltaTime);

        var frameMoviment = velocity * Time.deltaTime;
        transformComponent.Position += frameMoviment;
        if (velocity != Vector3.zero)
        {
            transformComponent.Rotation = Quaternion.LookRotation(velocity, transformComponent.Up);
        }
    }
}
