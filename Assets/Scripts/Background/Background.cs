using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour, ITeleportable
{
    public void Teleport()
    {
       gameObject.SetActive(false);
    }
}
