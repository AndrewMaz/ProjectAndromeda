using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    [SerializeField] private float additiveSpeed = 4f;

    public void SpeedUp()
    {
        movement.Speed += additiveSpeed; 
    }

    public override void Die()
    {
        //It doesnt die
    }
}
