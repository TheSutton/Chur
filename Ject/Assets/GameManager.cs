using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> PowerUps;
    public List<GameObject> Enemies;
    public GameObject OvrPlayer;
    private Player PlayerScript;
    public bool IsGameActive;
    public float SpawnAmount = 0;
    public float roundTimer = 2;

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
            //This checks if there are any entities with the tag Enemy on them
        {
           while(GameObject.FindGameObjectsWithTag("Speed").Length == 0 && GameObject.FindGameObjectsWithTag("Health").Length == 0 && GameObject.FindGameObjectsWithTag("Scale").Length == 0)
            {
                SpawnPowerups();
              // This section checks for if there is a powerup in the scene buy checking for the seperate tages of each powerups
            }            
        }
        
    }
    public void SpawnNewEnemy()
    {
       //This  code is for spawning a new enemy in certain locations and then random locations using vectors and random number functions
        int Enemy = Random.Range(0, Enemies.Count);
       
        Vector3 spawnPos = new Vector3(0.02f,1.575f,8.38f);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= 2)
        {
            Vector3 spawnPosRand = new Vector3(Random.Range(-6f,5.8f), 1.575f, Random.Range(-7f,6.31f));
            Instantiate(Enemies[Enemy], spawnPosRand, Enemies[Enemy].transform.rotation);
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
        {
            Vector3 spawnPos2 = new Vector3(0.02f, 1.575f, -8.38f);
            Instantiate(Enemies[Enemy], spawnPos2, Enemies[Enemy].transform.rotation);
        }
        else if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
            Instantiate(Enemies[Enemy], spawnPos, Enemies[Enemy].transform.rotation);
        }
        
    }
    public void SpawnPowerups()
    {
        //this  spaws enetities from a list of powerups at a set location
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
        //this checks if there are no powerups and spawns another enemy aswell as putting the "round timer" which is like a round number which depends on how many enemies are spawned
        if (GameObject.FindGameObjectsWithTag("Speed").Length == 0 || (GameObject.FindGameObjectsWithTag("Scale").Length == 0) || (GameObject.FindGameObjectsWithTag("Health").Length == 0))
        {
            print(roundTimer);
            for (SpawnAmount = 0; SpawnAmount < roundTimer; SpawnAmount++)
            {
                SpawnNewEnemy();
                
            }
            roundTimer = roundTimer + 1;
        }
     }
    public void Starting()
    {
        IsGameActive = true;
        SpawnNewEnemy();
    }
    public void EndRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
