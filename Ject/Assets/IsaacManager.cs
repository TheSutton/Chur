using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacManager : MonoBehaviour
{
    public GameObject thePlayer;
    private tearShot tearShotScript;
    public GameObject tears;
    public Vector3 Scale;
    public GameObject OvrPlayer;
    private Player PlayerScript;
    public GameManager gameManager;
    public GameObject StartButton;
    public GameObject EndButton;



    // Start is called before the first frame update
    void Start()
    {
        tearShotScript = thePlayer.GetComponent<tearShot>();
        PlayerScript = OvrPlayer.GetComponent<Player>();
        GameObject Tear = GameObject.Find("Tear");
        tears.transform.localScale = new Vector3(1, 1, 1);
        Scale = new Vector3(1.5f, 1.5f, 1.5f);
        gameManager.enabled = false;
        EndButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //This Kills the enemy when hit 3 times 
        if (PlayerScript.Health == 0)
        { 
            Destroy(GameObject.FindWithTag("Enemy"));
        }
        if (gameObject.transform.position.y <= -1)
        {
            gameManager.EndRestart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //these are all the powerup scripts
        if (other.gameObject.CompareTag("Speed"))
        {
            //this shortens the time between shots of the tears
            gameManager.EnemySpawn();
            Destroy(other.gameObject);
            tearShotScript.FireTimer = tearShotScript.FireTimer = -0.5f;
            print("speed");
        }
        if (other.gameObject.CompareTag("Scale"))
        {
            //this changed the scale of the tears by 1.5 each time the powerup is picked up and stops when a max of 6 is reached 
            gameManager.EnemySpawn();
            Destroy(other.gameObject);
            if (Scale != (new Vector3(6f, 6f, 6f)))
            {
                tears.transform.localScale += Scale;
                print("Scale");
            }

        }
        if (other.gameObject.CompareTag("Health"))
        {
            //this ups the health of the player by 1 and max of 3
            gameManager.EnemySpawn();
            PlayerScript.HealthUp();
            Destroy(other.gameObject);
            print("Health");
        }
        if (other.gameObject.CompareTag("Start "))
        {
            //this starts the game
            StartButton.SetActive(false);
            gameManager.enabled = true;
            gameManager.Starting();
            
        }
        if(PlayerScript.Health == 0)
        {
           //when the player dies the restart button appears 
            EndButton.SetActive(true);
            gameManager.enabled = false;
            if (other.gameObject.CompareTag("End"))
            {
                gameManager.EndRestart();
            }
        }
      

    }
}
