using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ChargerMove : MonoBehaviour
{
    public float speed = 5;
    public int health = 10;
    public float RotateY;
    public float GaperHelth = 3;
    // Start is called before the first frame update
    void Start()
    {
        GaperHelth = 3; 
        

    }

    // Update is called once per frame
    void Update()
    {
        if(GaperHelth == 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (RotateY < 90) ;
        {
            RotateY = 180;
        }
        if (RotateY < -90) ;
        {
            RotateY = 180;
        }
        //changes the rotation of the charger between 180 and -180 unless its between 90 and -90 then it turns around, this is so it doesnt get stuck in conrners 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("wall"))
        {
            
            RotateY = Random.Range(-180, 180);
            transform.Rotate(new Vector3( 0, RotateY, 0));
        }

        if (other.gameObject.CompareTag("Tear"))
        {
            HealthDown();
            print("TearHitCharger");
        }
    }
    public void HealthDown()
    {
        GaperHelth = GaperHelth - 1;
    }
}
