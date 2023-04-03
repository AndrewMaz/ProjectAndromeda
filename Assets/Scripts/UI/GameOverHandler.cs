using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1.0f;
      /*  ScrollMovement.floorIndex = 0;*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
