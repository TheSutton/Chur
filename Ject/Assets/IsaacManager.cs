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
        
        if (PlayerScript.Health == 0)
        { 
            Destroy(GameObject.FindWithTag("Enemy"));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Speed"))
        {
            gameManager.EnemySpawn();
            Destroy(other.gameObject);
            tearShotScript.FireTimer = tearShotScript.FireTimer = -0.5f;
            print("speed");
        }
        if (other.gameObject.CompareTag("Scale"))
        {
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
            gameManager.EnemySpawn();
            PlayerScript.HealthUp();
            Destroy(other.gameObject);
            print("Health");
        }
        if (other.gameObject.CompareTag("Start "))
        {

            StartButton.SetActive(false);
            gameManager.enabled = true;
            gameManager.Starting();
            
        }
        if(PlayerScript.Health == 0)
        {
           
            EndButton.SetActive(true);
            gameManager.enabled = false;
            if (other.gameObject.CompareTag("End"))
            {
                gameManager.EndRestart();
            }
        }
      

    }
}
