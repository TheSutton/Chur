using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tearShot : MonoBehaviour
{
    public GameObject HeaD;
    private IEnumerator Cor;
       
    public GameObject Tear;
    private Quaternion fuck;
    private bool FireRate;
    public float FireTimer =1f;

    // Start is called before the first frame update
    void Start()
    {
        
        FireRate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FireRate == true)
        {
            if (FireTimer > 0f)
            {
                FireTimer -= Time.deltaTime;
            }
            else if (FireTimer <= 0)
            {
                FireTimer = 0;
                Fire();
            }


            

        }
        
    }
    private void Fire()
    {
        fuck = Quaternion.Euler(HeaD.transform.eulerAngles.x, HeaD.transform.eulerAngles.y, HeaD.transform.eulerAngles.z);
        var offset = new Vector3(0.5f, -0.2f, 0);
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Instantiate(Tear, HeaD.transform.position , fuck);
            FireTimer = 1f;
            
        }
    }
}
