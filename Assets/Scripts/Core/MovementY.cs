using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementY : MonoBehaviour
{
    [SerializeField] private float speedY = 2f;
    [SerializeField] private float period = 3f;

    private float infTimer;

    private void OnEnable()
    {
        infTimer = 0f;
    }

    void FixedUpdate()
    {
        infTimer += Time.fixedDeltaTime;
        transform.localPosition += Mathf.Sin(infTimer * speedY) * Time.fixedDeltaTime * period * Vector3.down;
    }
}
