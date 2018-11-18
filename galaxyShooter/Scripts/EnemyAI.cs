using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    bool isDead = false;

    public GameObject WorldController;

    [SerializeField]
    private float Speed = 2.0f;

    [SerializeField]
    private int Life = 100;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")

        {
            Life = Life - 10;
            if (coll.transform.parent != null)
                Destroy(coll.gameObject.transform.parent.gameObject);
            else
                Destroy(coll.gameObject);
        }

        else if (coll.gameObject.tag == "Player")
            coll.gameObject.GetComponent<Player>().Damage();
    }

    void Update () {

        if (Life <= 0)
        {
            WorldController.gameObject.GetComponent<GameBehaviour>().SpawnEnemyExplosion(this.transform.position);
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if(transform.position.y <= -7)
        {
            transform.position = new Vector3(Random.Range(-7,7), 7) ;
        }   
	}
}
