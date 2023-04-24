using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private SpriteAtlas atlas;
    [SerializeField] private Image imageToChange;
    [SerializeField] private float timeToChange = 1f;

    private float timer;
    private int counter = 0;

    private Sprite[] sprites;

    private void Awake()
    {
        sprites = new Sprite[atlas.spriteCount];
        timer = timeToChange;
        atlas.GetSprites(sprites);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return;

        imageToChange.sprite = sprites[counter];
        if (counter < atlas.spriteCount - 1)
        {
            counter++;
        }

        timer = timeToChange;
    }
}
