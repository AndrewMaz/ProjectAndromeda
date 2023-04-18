using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private TextMeshProUGUI missedKillCountText;

    public static GameOverHandler instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
    }

    public void Pause()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        menuPanel.SetActive(false);
    }

    public void UpdateUI(int killsValue)
    {
        instance.killCountText.text = $"Убито: {killsValue} ";
    }
    //float for missedKills
    public void UpdateUI(float missedKillsValue)
    {
        instance.missedKillCountText.text = $"Пропущено: {missedKillsValue} ";
    }
}
