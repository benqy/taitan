using UnityEngine;
using System.Collections;

public class BadgerController : MonoBehaviour {
    public float moveSpeed = .1f;

    public GameObject[] points;

    private int currentIndex = 0;
    private GameObject currentPoint;
    private GameObject nextPoint;
    void Start() {
        for (var i = 0; i <= 11; i++) {
            points[i] = GameObject.Find("Point" + i);
        }
        //target = GameObject.Find("End");
        //monster = GetComponent<NavMeshAgent>();
        
    }

    void Update() {
        //var p = transform.position;
        //Vector3 target = new Vector3(p.x, p.y - moveSpeed, p.z);
        //transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        currentPoint = points[currentIndex];
        nextPoint = points[currentIndex + 1];
        var direction = nextPoint.transform.position - transform.position;
        direction.z = 0;
        direction.Normalize();
        Vector3 target = direction * moveSpeed + transform.position;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;

        //transform.rotation =Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), 5 * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        //transform.LookAt(new Vector3(0,0,nextPoint.transform.position.y));

        transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, 0, targetAngle),15* Time.deltaTime);
        
        //monster.SetDestination(target.transform.position);     
    }


    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.name);
        if (col.tag == "Bullet") {
            Destroy(gameObject);
        }
        else if (col.tag == "End") {
           // DestroyObject(GameObject.Find("bunny_1"));
            Destroy(gameObject);
        }
        else if(col.tag == "Point"){
            var colIndex = System.Convert.ToInt32(col.name.Replace("Point", ""));
            //
            //Debug.Log("col" + colIndex);
            //Debug.Log("curr" + currentIndex);
            if (colIndex != currentIndex) {
                currentIndex++;
                Debug.Log(currentIndex);
            }
        }
    }
}
