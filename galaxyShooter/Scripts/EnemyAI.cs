using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    bool isDead = false;

    GameObject WorldController;

    [SerializeField]
    private float Speed = 2.0f;

    [SerializeField]
    private int Life = 30;

    void Start()
    {
        WorldController = GameObject.FindGameObjectWithTag("World");
    }

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

    void Update()
    {

        if (Life <= 0)
        {
            WorldController.GetComponent<GameBehaviour>().SpawnEnemyExplosion(this.transform.position);
            WorldController.GetComponent<GameBehaviour>().MyCanvas.GetComponent<UIManager>().UpdateScore(WorldController.GetComponent<GameBehaviour>().Score);
            Debug.Log(WorldController.GetComponent<GameBehaviour>().Score);
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y <= -7)
        {
            transform.position = new Vector3(Random.Range(-7, 7), 7);
        }
    }
}
