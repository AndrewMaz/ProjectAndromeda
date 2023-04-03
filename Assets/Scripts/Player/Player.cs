using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] Transform body;
    [SerializeField] Slider heathSlider;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float deadPositionY = -2f;
    [SerializeField] Transform arrowPosition;

    Rigidbody2D rb;
    Animator animator;

    Vector3 startPosition;

    float timer = 0f, currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        startPosition = transform.position;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (transform.position.y < deadPositionY)
        {
            animator.SetTrigger("die");
        }

        if (transform.position != startPosition) 
        {
            timer += Time.deltaTime;
            transform.position = new Vector3(
                Vector3.Lerp(transform.position, startPosition, timer).x, 
                transform.position.y, 
                transform.position.z);

            if (timer > 1f)
            {
                timer = 0f;
            }
        }

        /*if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    animator.SetTrigger("attack");
                    break;

                case TouchPhase.Stationary:
                    //Get the Screen positions of the object
                    Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
                    //Get the Screen position of the mouse
                    Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    //Get the angle between the points
                    float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

                    if (angle <= 0f)
                    {
                        body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Max(-90, angle)));
                    }
                    else
                    {
                        body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Min(90, angle)));
                    }

                    animator.SetBool("isStance", true);
                    break;

                case TouchPhase.Moved:
                    //Get the Screen positions of the object
                    positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
                    //Get the Screen position of the mouse
                    mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    //Get the angle between the points
                    angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

                    if (angle <= 0f)
                    {
                        body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Max(-90, angle)));
                    }
                    else
                    {
                        body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Min(90, angle)));
                    }

                    animator.SetBool("isStance", true);
                    break;

                case TouchPhase.Ended:
                    animator.SetBool("isStance", false);
                    break;
            }
        }

#if UNITY_EDITOR_WIN

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("attack");
        }
        if (Input.GetMouseButton(1))
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            if (angle <= 0f)
            {
                body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Max(-90, angle)));
            }
            else
            {
                body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Min(90, angle)));
            }

            animator.SetBool("isStance", true);
        }
        if (Input.GetMouseButtonUp(1))
        {

            animator.SetBool("isStance", false);
        }

#endif*/
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    }

    public void ResetRotation()
    {
        body.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void Jump() 
    {
        if (rb.velocity != Vector2.zero) return;

        rb.velocity = new Vector2(0, jumpForce);
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }

    public void Stance(Vector2 positionOnScreen, Vector2 mouseOnScreen)
    {
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        if (angle <= 0f)
        {
            body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Max(-90, angle)));
        }
        else
        {
            body.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Min(90, angle)));
        }

        animator.SetBool("isStance", true);
    }

    public void Release(Vector2 mouseOnScreen, GameObject arrow, float speed)
    {
        arrow.transform.SetPositionAndRotation(arrowPosition.position, arrowPosition.rotation);
        arrow.TryGetComponent(out Rigidbody2D rb);
        arrow.TryGetComponent(out Movement movement);
        movement.enabled = false;

       /* //float angle = Vector3.SignedAngle(arrowPosition.position, mouseOnScreen, Vector3.down) * Mathf.Deg2Rad;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(mouseOnScreen.y - arrowPosition.position.y, mouseOnScreen.x - arrowPosition.position.x) - 90;
        float xComponent = Mathf.Cos(angle) * speed;
        float zComponent = Mathf.Sin(angle) * speed;
        Vector3 forceApplied = new(xComponent, zComponent, 0);*/
        rb.velocity = Vector2.zero;


        rb.velocity = new Vector2(mouseOnScreen.x - arrow.transform.position.x, (mouseOnScreen.y - arrow.transform.position.y) * 1.3f) * speed;
        //rb.AddForce(forceApplied);
        animator.SetBool("isStance", false);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0f)
        {
            //gameOverCanvas.SetActive(true);
            animator.SetTrigger("die");
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        GetComponentInChildren<Animator>().SetTrigger("takeDamage");

        heathSlider.value = currentHealth / maxHealth;
    }
}
