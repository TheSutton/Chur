using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpin : MonoBehaviour
{

    public float Speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Speed, 0 * Time.deltaTime);
    }
}
