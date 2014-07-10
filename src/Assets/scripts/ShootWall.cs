using UnityEngine;
using System.Collections;

public class ShootWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            audio.Play();
            //Debug.Log(audio);
            // Destroy(gameObject);
        };
    }
}
