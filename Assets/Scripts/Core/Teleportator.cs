using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleportator : MonoBehaviour
{
    public event Action<GameObject> TeleportCompleting;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ITeleportable teleporter))
        {
            TeleportCompleting.Invoke(other.gameObject);
        }
    }
}
