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
    [SerializeField] Button resumeButton;
    [SerializeField] GameObject deathText;

    Rigidbody2D rb;
    Animator animator;

    Vector3 startPosition;

    float timer = 0f, currentHealth;

    public bool UIPressed { get; private set; }

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

        UIPressed = false;
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
        UIPressed = true;
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
        arrow.SetActive(true);
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
            resumeButton.interactable = false;
            deathText.SetActive(true);
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
