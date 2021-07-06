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
    // Start is called before the first frame update
    void Start()
    {
         
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (RotateY < 90) ;
        {
            RotateY = 180;
        }
        if (RotateY < -90) ;
        {
            RotateY = 180;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("wall"))
        {
            print(RotateY);
            RotateY = Random.Range(-180, 180);
            transform.Rotate(new Vector3( 0, RotateY, 0));
        }
    }

}
