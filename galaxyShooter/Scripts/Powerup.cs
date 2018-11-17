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
            coll.gameObject.GetComponent<Player>().EnablePowerUp(TypePowerup);
            Destroy(this.gameObject);
        }

    }
}
