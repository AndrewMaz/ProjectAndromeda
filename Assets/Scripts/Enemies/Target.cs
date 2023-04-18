using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Rigidbody2D platform;

    Vector2 platformStartPosition;

    private void Awake()
    {
        platformStartPosition = platform.transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Arrow _))
        {
            platform.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnEnable()
    {
        platform.transform.localPosition = platformStartPosition;
        platform.bodyType = RigidbodyType2D.Kinematic;
    }
}
