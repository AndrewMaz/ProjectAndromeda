using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRune : Rune
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            /*GameObject arrow = ArrowPool.instance.GetPooledObject();

            if (arrow !=null)
            {
                arrow.GetComponent<Arrow>().IsExxplosive = true;
                gameObject.SetActive(false);
            }*/
        }
    }
}
