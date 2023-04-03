using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;  

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] private Teleportator teleportator;
    [SerializeField] private Floor[] floors;
    [SerializeField] private Background[] backgrounds;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private GameObject[] runes;
    [Space]
    [SerializeField] private List<Floor> floorsPool = new ();
    [SerializeField] private List<Background> backgroundsPool = new ();
    [SerializeField] private List<Enemy> enemiesPool = new ();
    [SerializeField] private List<GameObject> runesPool = new ();
    [Space]
    [SerializeField] private float timeToSpawnRune = 15f;

    private Floor lastFloor;

    private float backgroundTimer, runeTimer;

    public float NewTimerValue => Random.Range(0.5f, 1.5f);

    private void Awake()
    {
        floorsPool.AddRange(floors);
        enemiesPool.AddRange(enemies);
        lastFloor = floors.LastOrDefault();
        backgroundsPool.AddRange(backgrounds);
        runesPool.AddRange(runes);
        backgroundTimer = NewTimerValue;
        runeTimer = timeToSpawnRune;
    }

    private void Spawner(GameObject gameObject, float spawnPosition)
    {
        gameObject.transform.localPosition =
            new Vector3(spawnPosition, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

        gameObject.SetActive(true);
    }


    public void FixedUpdate()
    {
        int randomBackground = Random.Range(0, backgroundsPool.Count);
        int randomRune = Random.Range(0, runesPool.Count);
        backgroundTimer -= Time.fixedDeltaTime;
        runeTimer -= Time.fixedDeltaTime;

        if(backgroundTimer < 0 && !backgroundsPool[randomBackground].gameObject.activeInHierarchy)
        {
            Spawner(backgroundsPool[randomBackground].gameObject, transform.localPosition.x);
            backgroundTimer = NewTimerValue;
        }
      
        if (runeTimer < 0)
        {
            if (!runesPool[randomRune].activeInHierarchy)
            {
                Spawner(runesPool[randomRune], transform.localPosition.x);
            }

            runeTimer = timeToSpawnRune;
        }
    }
    private void OnEnable()
    {
        teleportator.TeleportCompleting += OnTeleporting;
    }

    private void OnDisable()
    {
        teleportator.TeleportCompleting -= OnTeleporting;
    }

    private void OnTeleporting(GameObject gameObject)
    {
        if(gameObject.TryGetComponent(out Floor floor))
        {
            floor.gameObject.SetActive(false);
            Spawner(floor.gameObject, lastFloor.transform.localPosition.x + floor.Size);
            lastFloor = floor;
        }
        else if (gameObject.TryGetComponent(out Background background))
        {
            background.gameObject.SetActive(false);
        }
        else if (gameObject.TryGetComponent(out Enemy enemy)) 
        {
            enemy.gameObject.SetActive(false);
            Spawner(enemiesPool[Random.Range(0, enemiesPool.Count)].gameObject, transform.localPosition.x);
        }
        else if (gameObject.TryGetComponent(out Rune rune))
        {
            rune.gameObject.SetActive(false);
        }
    }
}
