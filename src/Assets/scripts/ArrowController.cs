using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

    #region 可配置参数
    public int m_attack = 5;//攻击力
    #endregion

    private GameObject targetGameObject;
    private Vector3 moveDirection;
    

    //子弹移动速度
    private float moveSpeed = 0.1f;

    void Awake() {
        EventService.Instance.GetEvent<BulletShootEvent>().Subscribe(Attack);
    }

    // Use this for initialization
    void Start() {
        
    }

    void Attack<Object>(Object target) {
        Debug.Log(target);
        if (targetGameObject == null) {
            targetGameObject = target as GameObject;
        }
    }

    // Update is called once per frame
    void Update() {
        //子弹移动到屏幕外就销毁
        if (transform.position.x > 5 || transform.position.x < -5 || transform.position.y > 5 || transform.position.y < -5) {
            Destroy(gameObject);
        }

        //有目标则自动追踪目标,无目标则直线飞行
        if (targetGameObject != null) {
            var currentPosition = transform.position;
            moveDirection = targetGameObject.transform.position - currentPosition;
            moveDirection.z = 0;
            moveDirection.Normalize();
            transform.position = Vector3.Lerp(currentPosition, moveDirection + currentPosition, Time.deltaTime / moveSpeed);
            float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        }
        else {
            Debug.Log("no target");
           // var targetPosition = transform.position.normalized;
            //var speed = transform.position.normalized * moveSpeed;
            //rigidbody2D.velocity = new Vector2(speed.x, speed.y);
        }
    }



    void OnTriggerEnter2D(Collider2D col) {
        //if (col.tag == "Monster") {
        //    targetGameObject = null;
        //    var targetPosition = transform.position.normalized;
        //    var speed = transform.position.normalized * moveSpeed;
        //    rigidbody2D.velocity = new Vector2(speed.x, speed.y);
        //}
        if (col.tag == "Wall") {
            //audio.Play();
            //Debug.Log(audio);
            Destroy(gameObject);
        };
    }
}
