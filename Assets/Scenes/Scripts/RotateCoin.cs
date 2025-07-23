using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float speed = 3f;
    void Update()
    {
        transform.Rotate(0f, speed, 0f * Time.deltaTime / 0.01f, Space.Self);
    }
}
