using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour, ITeleportable
{
    public float Size { get; private set; }

    BoxCollider2D boxColliderwqqwq;

    private void Start()
    {
        boxColliderwqqwq = gameObject.GetComponent<BoxCollider2D>();
        Size = boxColliderwqqwq.size.x;
    }

    public void Teleport()
    {
        //gameObject.SetActive(false);
    }
}
