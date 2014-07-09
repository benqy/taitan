using UnityEngine;
using System.Collections;

public class BadgerController : MonoBehaviour {
    public float moveSpeed = .1f;
    public float xDir = 0;
    public float yDir = 1;

    //寻路
    //private NavMeshAgent monster;
    //public GameObject target;

    void Start() {
        //target = GameObject.Find("End");
        //monster = GetComponent<NavMeshAgent>();
    }

    void Update() {
        //var p = transform.position;
        //Vector3 target = new Vector3(p.x, p.y - moveSpeed, p.z);
        //transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        rigidbody2D.velocity = new Vector2(0,-1);
        //monster.SetDestination(target.transform.position);     
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bullet") {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "End") {
            DestroyObject(GameObject.Find("bunny_1"));
        }
        else {
            Debug.Log(col.gameObject.tag);
            rigidbody2D.velocity = new Vector2(0, 1);
            //xDir = 1;
            //yDir = 0;
            //transform.Rotate(0, 0, -90f);
        }
    }
}
