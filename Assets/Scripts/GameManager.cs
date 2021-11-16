using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject enemyPrefab;
    public Transform positionSpawn;
    public int nbEnemiesAtStart = 10;
    public int spawningSize = 100;
    public float spawnInterval = 0.1f;

    // UI
    public ProgressBar healthBar;
    public Text killCounter;

    private bool _isSpawningEnemies = true;
    public int killedEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        killCounter.text = "Ennemis tués: " + killedEnemy;

        for (int i=0; i < nbEnemiesAtStart; i++)
        {
            //Vector2 v = Random.insideUnitSphere;
            //Vector3 v3 = new Vector3(v.x, v.y, 0);
            Instantiate(enemyPrefab, positionSpawn.position + (Random.onUnitSphere * spawningSize), Quaternion.identity, positionSpawn);
        }
        StartCoroutine(SpawningLoop());
    }

    IEnumerator SpawningLoop()
    {
        while(_isSpawningEnemies)
        {
            Instantiate(enemyPrefab, positionSpawn.position + (Random.onUnitSphere * spawningSize), Quaternion.identity, positionSpawn);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Nombre d'ennemis méchants : " + positionSpawn.childCount);
        killCounter.text = "Ennemis tués: " + killedEnemy;
    }
}
