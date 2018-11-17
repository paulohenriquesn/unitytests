using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private string TypePowerup;
    [SerializeField]
    private float Speed = 3.0f;

    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            switch (TypePowerup)
            {
                case "TripleShot":
                    coll.GetComponent<Player>().TripleShotOn();
                    break;
                case "SpeedBoost":
                    coll.GetComponent<Player>().SpeedBoostOn();
                    break;  
            }
            Destroy(this.gameObject);
        }

    }
}
