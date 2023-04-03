using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float deadSpeed = 2f;

    public float Speed { get; set; }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    public float DeadSpeed { get { return deadSpeed; } set { deadSpeed = value; } }

    private void Start()
    {
        Speed = movementSpeed;
    }

    public void FixedUpdate()
    {
        transform.localPosition += Speed * Time.fixedDeltaTime * Vector3.left;
    }
}
