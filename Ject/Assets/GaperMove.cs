using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaperMove : MonoBehaviour
{

    public float speed = 1.0f;
    public float RSpeed = 1.0f;
    public Transform Player;
    public bool Iftouch = false;
    public float Waiter = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
      
        Player = GameObject.Find("OVRPlayerController").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);

        
        Vector3 targetDirection = Player.position - transform.position;
        float singleStep = RSpeed * Time.deltaTime;
        Vector3 NewDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, NewDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(NewDirection);
    }
    public void OnTriggerEnter(Collider other)
    {
        Iftouch = true;
        if (other.gameObject.CompareTag("Player"))
        {
            print("yeah");
           
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
            }
        }
    }
}
