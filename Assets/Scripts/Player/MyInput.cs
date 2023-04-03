using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyInput : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float arrowSpeed = 2.5f;
    [SerializeField] private float minMultiplier = 0.1f;
    [SerializeField] private float maxMultiplier = 1.1f;

    private float speedMultiplier, multiplierTimer;

    private void Start()
    {
        multiplierTimer = 0f;
    }

    private void Update()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = camera.WorldToViewportPoint(player.transform.position);
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)camera.ScreenToViewportPoint(Input.mousePosition);
        //Get the angle between the points



        if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    player.Attack();
                    break;

                case TouchPhase.Stationary:

                case TouchPhase.Moved:
                    player.Stance(positionOnScreen, mouseOnScreen);
                    break;

                case TouchPhase.Ended:
                    player.Release(mouseOnScreen, arrow, arrowSpeed * speedMultiplier);
                    break;
            }
        }

#if UNITY_EDITOR_WIN

        if (Input.GetMouseButtonDown(1))
        {
            player.Attack();
        }
        if (Input.GetMouseButton(1))
        {
            player.Stance(positionOnScreen, mouseOnScreen);
            multiplierTimer += Time.deltaTime;
            if (multiplierTimer > 1f)
                multiplierTimer = 1f;
            speedMultiplier = Mathf.Lerp(minMultiplier, maxMultiplier, multiplierTimer);
        }
        if (Input.GetMouseButtonUp(1))
        {
            player.Release(camera.ScreenToWorldPoint(Input.mousePosition), arrow, arrowSpeed * speedMultiplier);
            multiplierTimer = 0f;
        }

#endif
    }

}
