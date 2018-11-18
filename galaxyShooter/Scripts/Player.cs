using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject WorldController;
    bool amiLive;

    public bool canTripleShot;
    public bool isthereaShield;


    [SerializeField]
    int Life = 30;

    [SerializeField]
    private GameObject Laser;

    [SerializeField]
    private GameObject TripleShot;

    [SerializeField]
    private GameObject ShieldObject;

    [SerializeField]
    private float fireRate = 0.25f;

    private float canFire = 0.0f;

    public float playerSpeed = 1;

    private float horizontalInput, verticalInput;

    void Start()
    {
        amiLive = true;
    }

    void Update()
    {
        WorldController.GetComponent<GameBehaviour>().MyCanvas.GetComponent<UIManager>().UpdateLives(Life);
        if (Life <= 0)
        {
            if (amiLive == true)
            {
                WorldController.GetComponent<GameBehaviour>().SpawnExplosion(this.gameObject.transform.position, this.gameObject);
                amiLive = false;
            }
        }

        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

    }

    public void Damage()
    {
        if (isthereaShield)
        {
            ShieldObject.gameObject.SetActive(false);
            isthereaShield = false;
            return;
        }
        Life = Life - 10;
    }

    private void Shoot()
    {
        if (Time.time > canFire)
        {
            if (!canTripleShot)
            {
                Instantiate(Laser, new Vector3(transform.position.x, transform.position.y + 0.88f, 0), Quaternion.identity);
                canFire = Time.time + fireRate;
            }
            else
            {
                GameObject triple = Instantiate(TripleShot, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.88f, 0), Quaternion.identity) as GameObject;
                Destroy(triple, 0.9f);
                canFire = Time.time + fireRate;
            }

        }
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * playerSpeed * verticalInput);

        //x
        if (this.gameObject.transform.position.x <= -9.0f)
            this.gameObject.transform.position = new Vector3(8.9f, 0, 0);
        else if (this.gameObject.transform.position.x >= 8.9f)
            this.gameObject.transform.position = new Vector3(-9.0f, 0, 0);

        //y
        if (this.gameObject.transform.position.y > 0)
        {
            transform.position = new Vector3(this.gameObject.transform.position.x, 0, 0);
        }
        else if (this.gameObject.transform.position.y <= -4.16f)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, -4.16f, 0); ;
        }
    }

    public void EnablePowerUp(string type)
    {
        switch (type)
        {
            case "TripleShot":
                canTripleShot = true;
                break;
            case "SpeedBoost":
                playerSpeed = playerSpeed + 3f;
                break;
            case "Shield":
                isthereaShield = true;
                ShieldObject.gameObject.SetActive(true);
                break;
        }
        StartCoroutine(TurnOffPowerUp(type));
    }

    public IEnumerator TurnOffPowerUp(string type)
    {
        yield return new WaitForSeconds(5.0f);
        switch (type)
        {
            case "TripleShot":
                canTripleShot = false;
                break;
            case "SpeedBoost":
                playerSpeed = playerSpeed - 3f;
                break;
            case "Shield":
                //
                break;
        }
    }
}
