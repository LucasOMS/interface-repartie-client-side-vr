﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRandomMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotateSpeed = 5.0f;

    Vector3 newPosition;

    void Start()
    {
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector3(Random.Range(-30.0f, 20.0f), 0, Random.Range(-30.0f, 30.0f));
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, newPosition) < 1)
            PositionChange();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);

       //LookAt2D(newPosition);
    }

    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;

        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
    }
}
