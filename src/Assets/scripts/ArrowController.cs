using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.position.x);
        if (transform.position.x > 50 || transform.position.x < -50 || transform.position.y > 50 || transform.position.y < -50)
        {
            Destroy(gameObject);
        }
	}

}
