using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float speed = 10.0f;

	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(this.gameObject, 0.9f);
	}
}
