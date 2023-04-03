using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeToSpawn = 15f;
    [SerializeField] float timeToHeal = 45f;
    [Space]
    [SerializeField] GameObject[] runes;
    [Space]
    [SerializeField] EnvironmentSpawner spawner;

    float timer, offsetX, defaultSpeed, healCD;
    Vector3 offsetPosition;

    void Start()
    {
        healCD = 0f;
        defaultSpeed = -2f;
        offsetX = 10f;
        offsetPosition = new Vector3(spawnPoint.position.x + offsetX, 1f, spawnPoint.position.z);
        timer = timeToSpawn;
    }

    void Update()
    {
        /*healCD -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer > 0) return;

        int randomNumber = Random.Range(0, runes.Length);
        
        //0 - healRune, 1 - tripleShotRune, 2 - explosionRune
        switch (randomNumber) 
        {
            case 0:
                if (healCD <= 0f)
                {
                    Instantiate(runes[randomNumber], spawnPoint.position, spawnPoint.rotation);
                    healCD = timeToHeal;
                }
                else
                {
                    Instantiate(runes[randomNumber + 1], spawnPoint.position, spawnPoint.rotation);
                    Instantiate(enemies[randomNumber + 1], offsetPosition, spawnPoint.rotation);
                    Instantiate(enemies[randomNumber + 1], offsetPosition + Vector3.right * 0.001f, spawnPoint.rotation);
                    Instantiate(enemies[randomNumber + 1], offsetPosition + Vector3.right * 0.002f, spawnPoint.rotation);
                }
                break;

            case 1:
                Destroy(Instantiate(runes[randomNumber], spawnPoint.position, spawnPoint.rotation), 60f);
                Destroy(Instantiate(enemies[randomNumber], offsetPosition, spawnPoint.rotation), 60f);
                Destroy(Instantiate(enemies[randomNumber], offsetPosition + Vector3.right * 0.001f, spawnPoint.rotation), 60f);
                Destroy(Instantiate(enemies[randomNumber], offsetPosition + Vector3.right * 0.002f, spawnPoint.rotation), 60f);
                break;

            case 2:
                Destroy(Instantiate(runes[randomNumber], spawnPoint.position, spawnPoint.rotation), 60f);
                GameObject bird1 = Instantiate(enemies[0], offsetPosition + Vector3.up, spawnPoint.rotation);
                bird1.GetComponent<ScrollMovement>().ScrollSpeed = defaultSpeed;
                Destroy(bird1, 60f);
                GameObject bird2 = Instantiate(enemies[0], offsetPosition + Vector3.up + Vector3.right, spawnPoint.rotation);
                bird2.GetComponent<ScrollMovement>().ScrollSpeed = defaultSpeed;
                Destroy(bird2, 60f);
                Destroy(Instantiate(enemies[randomNumber], offsetPosition, spawnPoint.rotation), 60f);
                Destroy(Instantiate(enemies[randomNumber], offsetPosition + Vector3.right * 0.002f, spawnPoint.rotation), 60f);
                break;
        }

        timer = timeToSpawn;*/
    }
}
