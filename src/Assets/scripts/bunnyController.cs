using UnityEngine;
using System.Collections;

public class bunnyController : MonoBehaviour {
    private float turnSpeed = 5;

    private Vector3 moveDirection;
    private Vector3 moveToward;


    public string m_name = "Bunny";//名字，以后看可以让玩家自己取名字的
    public int m_lv = 1;
    public int m_experience = 0;//经验
    public static int m_maxLife = 100;//生命
    public int m_currentLife = 100;//当前生命
    public int m_defense = 10;//防御力
    public static int m_attack = 5;//攻击力
    private float m_attack_speed = 1f;//攻击速度
    //public int m_rotateSpeed = 180;//旋转速度

    private GameObject target;


    private float bulletSpeed = 5;
    public GameObject[] ammo;

    // Use this for initialization
    void Start() {
        // moveDirection = Vector3.down;
        InvokeRepeating("Attack", 1, 1 / m_attack_speed);
    }

    // Update is called once per frame
    void Update() {
        Vector3 currentPosition = transform.position;
        //moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //当前已有目标则跳过
        if (target == null) {
            target = GameObject.FindWithTag("Monster");
        }
        if (target != null) {
            moveDirection = target.transform.position - currentPosition;
            moveDirection.z = 0;
            moveDirection.Normalize();

            //Vector3 target = moveDirection * moveSpeed + currentPosition;
            //transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);

            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation =Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, targetAngle),turnSpeed * Time.deltaTime);
        }
        //   turnSpeed * Time.deltaTime);
    }


    void Attack() {
        if (target != null) {
            int ammoIndex = 0;
            GameObject bullet = (GameObject)Instantiate(ammo[ammoIndex], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            EventService.Instance.GetEvent<BulletShootEvent>().Publish(target);

            //var speed = moveDirection * bulletSpeed;
            //bullet.rigidbody2D.velocity = new Vector2(speed.x, speed.y);
            //bullet.transform.LookAt(target.transform);
        }
    }
}
