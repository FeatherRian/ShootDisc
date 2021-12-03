using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 8000);//给予子弹一个向前的力
        GameObject.Destroy(gameObject, 10.0f);//如果未碰撞，10s后摧毁子弹
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);//碰撞摧毁子弹
    }


}
