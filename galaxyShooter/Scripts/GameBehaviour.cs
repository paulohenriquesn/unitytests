using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour {

    bool CanISpawnPowerup;
    public GameObject[] Powerups;

    [SerializeField]
    private GameObject EnemyExplosionAnimation;

    [SerializeField]
    private GameObject Explosion;

    void Start () {
        CanISpawnPowerup = true;
	}

	void Update () {
        if (CanISpawnPowerup)
        {
            StartCoroutine(SpawnPowerup());
            CanISpawnPowerup = false;
        }
	}

    public void SpawnEnemyExplosion(Vector3 pos)
    {
        GameObject explosion = Instantiate(EnemyExplosionAnimation, pos, Quaternion.identity) as GameObject;
        Destroy(explosion, 5.0f);
    }

    public void SpawnExplosion(Vector3 pos,GameObject object_)
    {
        GameObject explosion = Instantiate(Explosion, pos, Quaternion.identity) as GameObject;
        Destroy(explosion, 2.5f);
        Destroy(object_);
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(5.0f);
        switch (Random.Range(0, 3)) {
            case 1:
                Instantiate(Powerups[0],new Vector3(Random.Range(-7,7),7,0),Quaternion.identity);
                break;
            case 2:
                Instantiate(Powerups[1], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
                break;
        }
        CanISpawnPowerup = true;
    }
}
