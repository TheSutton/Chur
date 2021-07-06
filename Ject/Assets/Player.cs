﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health = 3;
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
        if (CompareTag("Enemy"))
        {
            HealthDown();
        }
    }
    public void HealthDown()
    {
        Health = Health - 1;
    }
    public void HealthUp()
    {
        Health = Health + 1 ;
    }

}
