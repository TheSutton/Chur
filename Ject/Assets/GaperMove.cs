using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaperMove : MonoBehaviour
{

    public float speed = 1.0f;
    public float RSpeed = 1.0f;
    public Transform Player;
    public bool Iftouch = false;
    public float Waiter = 1f;
    public float EnemyHealt = 3;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealt = 3;
        Player = GameObject.Find("OVRPlayerController").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealt <= 0)
        {
            Destroy(gameObject);
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
       //moves towards the player

        if (Iftouch == true)
        {
            if (Waiter > 0f)
            {
                Waiter -= Time.deltaTime;
                speed = 0f;
            }
            else if (Waiter <= 0)
            {
                Waiter = 1;
                speed = 1.0f;
                Iftouch = false;
            }
            //this is the movement for Gaper and it moves it towards the player and rotates him towards the player makeing the following motion 
            Vector3 targetDirection = Player.position - transform.position;
            float singleStep = RSpeed * Time.deltaTime;
            Vector3 NewDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(transform.position, NewDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(NewDirection);
        }
    }
     private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tear"))
        {
            EnemyHealthDown();
            print("tearhitGaper/fly");
        }
     

        if (other.gameObject.CompareTag("Player"))
        {
            print("chur");
            Iftouch = true;
        }
        }
    public void EnemyHealthDown()
    {
        EnemyHealt = EnemyHealt - 1;
    }
    }

