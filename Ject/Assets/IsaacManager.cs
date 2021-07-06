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
   
    
    // Start is called before the first frame update
    void Start()
    {
        tearShotScript = thePlayer.GetComponent<tearShot>();
        PlayerScript = OvrPlayer.GetComponent<Player>();
        GameObject Tear = GameObject.Find("Tear");
        tears.transform.localScale = new Vector3(1, 1, 1);
        Scale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Speed"))
        {
            gameManager.EnemySpawn();
            Destroy(other.gameObject);
            tearShotScript.FireTimer = tearShotScript.FireTimer =- 0.5f;
            
        }
        if (other.gameObject.CompareTag("Scale"))
        {
            gameManager.EnemySpawn();
            Destroy(other.gameObject);
            if (Scale != (new Vector3(6f, 6f, 6f)))
            {
                tears.transform.localScale += Scale;
            }
            
        }
        if (other.gameObject.CompareTag("Health"))
        {
            gameManager.EnemySpawn();
            PlayerScript.HealthUp();
            Destroy(other.gameObject);
        }
        
    }
    public void gameOber()
    {

    }
}
