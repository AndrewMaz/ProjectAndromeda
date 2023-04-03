using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    [SerializeField] float attackTime = 1f;

    Animator animator;

    float timer;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        timer = attackTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0f) return;

        animator.SetTrigger("attack");
        timer = attackTime;
    }
}
