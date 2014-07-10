using UnityEngine;
using System.Collections;

public class bunnyController : MonoBehaviour {
    public float moveSpeed = 2;
    public float turnSpeed = 5;

    private Vector3 moveDirection;
    private Vector3 moveToward;
   



    private float bulletSpeed = 5;
    public GameObject[] ammo;   

    // Use this for initialization
    void Start() {
        // moveDirection = Vector3.down;
    }

    // Update is called once per frame
    void Update() {
        Vector3 currentPosition = transform.position;
        moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDirection = moveToward - currentPosition;
        moveDirection.z = 0;
        moveDirection.Normalize();

        //Vector3 target = moveDirection * moveSpeed + currentPosition;
        //transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);

        float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation =
            // Quaternion.Slerp(transform.rotation,
                             Quaternion.Euler(0, 0, targetAngle);
                          //   turnSpeed * Time.deltaTime);
    }


    void FixedUpdate() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            int ammoIndex = 0;
            GameObject bullet = (GameObject)Instantiate(ammo[ammoIndex], new Vector3(transform.position.x,transform.position.y,0), transform.rotation);
            var speed = moveDirection * bulletSpeed;
            bullet.rigidbody2D.velocity = new Vector2(speed.x, speed.y);
        }
    }
}
