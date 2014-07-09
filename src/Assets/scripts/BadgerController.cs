using UnityEngine;
using System.Collections;

public class BadgerController : MonoBehaviour {
    public float moveSpeed = .1f;
    public float xDir = 0;
    public float yDir = 1;


    void Awake() {
    }

    void Update() {
        //var p = transform.position;
        //Vector3 target = new Vector3(p.x, p.y - moveSpeed, p.z);
        //transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        rigidbody2D.velocity = new Vector2(0,-1);
    }

    void FixedUpdate() {
        //if (-1 * rigidbody2D.velocity.y < maxSpeed)
        //    rigidbody2D.AddForce(Vector2.right * -1 * moveForce);
        //if (Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
        //    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,Mathf.Sign(rigidbody2D.velocity.y) * maxSpeed);


    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Bullet") {
            Destroy(gameObject);
        }
        else {
            rigidbody2D.velocity = new Vector2(0, 0);
            //xDir = 1;
            //yDir = 0;
            //transform.Rotate(0, 0, -90f);
        }
    }
}
