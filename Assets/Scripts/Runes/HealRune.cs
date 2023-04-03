using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRune : Rune
{
    [SerializeField] float heal = -50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player playerController))
        {
            playerController.TakeDamage(heal);
            gameObject.SetActive(false);
        }
    }
}
