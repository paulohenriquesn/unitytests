using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{

    bool CanISpawnPowerup;
    public GameObject[] Powerups;

    public int Score = 0;


    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private float TimeToDestroyPowerup = 5.0f;

    [SerializeField]
    private GameObject EnemyExplosionAnimation;

    [SerializeField]
    private GameObject Explosion;

    public GameObject MyCanvas;

    void Start()
    {
        CanISpawnPowerup = true;
            StartCoroutine(SpawnEnemie());
    }

    IEnumerator SpawnEnemie()
    {
        while (true)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-7, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }

    void Update()
    {
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

    public void SpawnExplosion(Vector3 pos, GameObject object_)
    {
        GameObject explosion = Instantiate(Explosion, pos, Quaternion.identity) as GameObject;
        Destroy(explosion, 2.5f);
        Destroy(object_);
        StartCoroutine(GoMenu());
    }

    IEnumerator GoMenu()
    {
        yield return new WaitForSeconds(3);
        MyCanvas.GetComponent<UIManager>().GoMenu();
    }

        IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(5.0f);
        int randomPowerUp = Random.Range(0, Powerups.Length);
        GameObject PowerUpObject = Instantiate(Powerups[randomPowerUp], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity) as GameObject;
        Destroy(PowerUpObject, TimeToDestroyPowerup);
        CanISpawnPowerup = true;
    }
}
