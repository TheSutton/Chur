using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject ThePlayer;
    public GameObject gameManager;
    private GameManager GameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            ThePlayer.transform.position = teleportTarget.transform.position;
            GameManagerScript.SpawnNewEnemy();
        }
        
    }
}
