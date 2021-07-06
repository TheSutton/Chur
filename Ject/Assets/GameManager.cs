using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> PowerUps;
    public List<GameObject> Spawnpoints;
    public List<GameObject> Enemies;
    public GameObject OvrPlayer;
    private Player PlayerScript;
    public bool IsGameActive;
    public float SpawnAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
       

        PlayerScript = OvrPlayer.GetComponent<Player>();
        IsGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
           if(GameObject.FindGameObjectsWithTag("Speed").Length == 0 && GameObject.FindGameObjectsWithTag("Health").Length == 0 && GameObject.FindGameObjectsWithTag("Scale").Length == 0)
            {
                SpawnPowerups();
              
            }            
        }
        
    }
    public void SpawnNewEnemy()
    {

        int Enemy = Random.Range(0, Enemies.Count);
        int Spawns = Random.Range(0, Spawnpoints.Count);
        Vector3 spawnPos = new Vector3(0.02f,1.575f,8.38f);
        Instantiate(Enemies[Enemy], spawnPos, Enemies[Enemy].transform.rotation);
    }
    public void SpawnPowerups()
    {
        Vector3 SpawnPower = new Vector3(0, 1, 0);
        int Powers = Random.Range(0, PowerUps.Count);
        Instantiate(PowerUps[Powers], SpawnPower, PowerUps[Powers].transform.rotation);
    }

    public void GameOver()
    {
        if(PlayerScript.Health == 0)
        {
            IsGameActive = false;
        }
    }
    public void EnemySpawn()
    {
        if (GameObject.FindGameObjectsWithTag("Speed").Length == 0)
        {
            for (SpawnAmount = 0; SpawnAmount < 1; SpawnAmount++)
            {
                SpawnNewEnemy();
            }

        }
        if ((GameObject.FindGameObjectsWithTag("Health").Length == 0))
        {
            for (SpawnAmount = 0; SpawnAmount < 1; SpawnAmount++)
            {
                SpawnNewEnemy();
            }
        }
        if ((GameObject.FindGameObjectsWithTag("Scale").Length == 0))
        {
            for (SpawnAmount = 0; SpawnAmount < 1; SpawnAmount++)
            {
                SpawnNewEnemy();
            }
        }
     }

}
