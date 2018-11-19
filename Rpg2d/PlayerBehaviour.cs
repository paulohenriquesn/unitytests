using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private float speedVelocity;

    Vector3 Moviment;

	void Start () {
       
    }
	
	void Update (){

        Moviment = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
        this.gameObject.transform.Translate((Moviment * speedVelocity * Time.deltaTime));

    }
}
