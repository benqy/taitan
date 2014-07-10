using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 5 || transform.position.x < -5 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            //audio.Play();
            //Debug.Log(audio);
            Destroy(gameObject);
        };
    }
}
