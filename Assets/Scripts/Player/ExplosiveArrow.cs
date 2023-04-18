using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveArrow : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor _) || collision.gameObject.TryGetComponent(out Enemy _))
        {
            Instantiate(explosionPrefab, gameObject.transform.position, explosionPrefab.transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
