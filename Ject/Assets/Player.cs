using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health = 3;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("yeah");
            HealthDown();
        }
    }
    public void HealthDown()
    {
        Health = Health - 1;
        if(Health == 0)
        {
            Heart1.SetActive(false);
        }
        if(Health == 1)
        {
            Heart2.SetActive(false);
        }
        if (Health == 2)
        {
            Heart3.SetActive(false);
        }
    }
    public void HealthUp()
    {
        if(Health >= 2)
        {
            Health = Health + 1;
        }
      
    }

}
