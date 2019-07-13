using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive= 0;
    
    public float timebetween = 5f;
    private float countdown = 2f;
    private int wavenum = 0;
    public Transform spawnPoint;
    public Text wavecountdown;
    public enemyStats[] waves;
    public gameManager GameManager;

    private void Update()
    {
        if(EnemiesAlive>0)
        {
            return;
        }
        if (wavenum == waves.Length)
        {
            GameManager.WinLevel();

            this.enabled = false;

        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timebetween;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        wavecountdown.text = string.Format("{0:00}", countdown);
    }
  
    IEnumerator SpawnWave()
    {
        playerStats.rounds++;
        enemyStats wave = waves[wavenum];
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);

        }
        wavenum++;
       
       
     
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }
   
}
