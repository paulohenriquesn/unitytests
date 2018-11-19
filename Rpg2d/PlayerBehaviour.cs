using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


    Animator anim;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speedVelocity;

    bool amIRunning;

	
	void Start () {
        anim = this.gameObject.GetComponent<Animator>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

    }

	void Update () {
        Moviment();
	}

    void Moviment()
    {
        #region Animation
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Walking", true);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Walking", true);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Running", true);
            anim.SetBool("Walking", false);
            if (!amIRunning)
            {
                speedVelocity = speedVelocity + 2.0f;
                amIRunning = true;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            int randAttack = Random.Range(0, 4);
            Debug.Log(randAttack);
            switch (randAttack)
            {
                case 0:
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("AttackOne", true);
                    break;
                case 1:
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("AttackTwo", true);
                    break;
                case 2:
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("AttackThree", true);
                    break;
                case 3:
                    anim.SetBool("Walking", false);
                    anim.SetBool("Running", false);
                    anim.SetBool("AttackFor", true);
                    break;
            }
        }
        #region disableAnimation
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            anim.SetBool("Walking", false);
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            anim.SetBool("Walking", false);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Running", false);
            if (amIRunning)
            {
                speedVelocity = speedVelocity - 2.0f;
                amIRunning = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("Walking", false);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("Walking", false);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
            anim.SetBool("AttackOne", false);
            anim.SetBool("AttackTwo", false);
            anim.SetBool("AttackThree", false);
            anim.SetBool("AttackFor", false);
        }
        #endregion

        #endregion
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speedVelocity * Time.deltaTime);
    }
}
