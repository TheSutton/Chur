using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Timer()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        print("yeah");
        yield return new WaitForSeconds(3);
        print("nah");
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        yield return new WaitForSeconds(3);
        
    }
    
}
