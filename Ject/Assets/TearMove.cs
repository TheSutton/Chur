﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearMove : MonoBehaviour
{

    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            print("wallHit");
            Destroy(gameObject);
        }

    }
}
