using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotRune : Rune
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            collision.GetComponentInChildren<ArrowController>().IsTripple = true;
            gameObject.SetActive(false);
        }
    }
}
