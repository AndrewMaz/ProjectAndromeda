using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image backGround;
    [SerializeField] private Image vibrationImage;
    [SerializeField] private float timeToChange;
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite secondImage;
    [SerializeField] private Sprite vibrationOff;
    [SerializeField] private Sprite vibrationOn;

    private float changeTime;
    private bool isVibrationOff = true;

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

    public void Options()
    {
        animator.SetTrigger("options");
    }

    public void Vibration()
    {
        if (isVibrationOff)
        {
            vibrationImage.sprite = vibrationOn;
            isVibrationOff = false;
        }
        else
        {
            vibrationImage.sprite = vibrationOff;
            isVibrationOff = true;
        }
    }
}
