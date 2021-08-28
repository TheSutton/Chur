using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearMove : MonoBehaviour
{
    public GameObject Gaper;
    public GaperMove GaperMoveScript ;
    public float speed = 20f;
    public GameObject Charger;
    public ChargerMove ChargerMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        GaperMoveScript = Gaper.GetComponent<GaperMove>();
        ChargerMoveScript = Charger.GetComponent<ChargerMove>();
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("gaperHit");
            print(GaperMoveScript.EnemyHealt);
            GaperMoveScript.EnemyHealthDown();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy2"))
        {
            print("charger hit");
            ChargerMoveScript.HealthDown();
            Destroy(gameObject);
        }
    }
}
