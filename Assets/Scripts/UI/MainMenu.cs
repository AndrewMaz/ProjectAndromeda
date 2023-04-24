using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image backGround;
    [SerializeField] private Sprite secondImage;
    [SerializeField] private float timeToChange;
    [SerializeField] private Animator animator;

    private float changeTime;

    private void Awake()
    {
        changeTime = timeToChange;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { animator.SetTrigger("continue"); }

        if (Input.touchCount > 0) { animator.SetTrigger("continue"); }

        changeTime -= Time.deltaTime;
        if (changeTime > 0) return;

        backGround.sprite = secondImage;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}
