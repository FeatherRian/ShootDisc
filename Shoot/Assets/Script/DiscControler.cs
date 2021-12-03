using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscControler : MonoBehaviour
{
    private float randomx, randomy;//x与y方向随机速度
    private int x, y;//固定的x与y方向
    private Transform m_transform;//盘子生成点
    public GameObject discpieces;//定义破碎的盘子物体
    public Transform disc_transform;//定义盘子的位置
    public Transform piecescollection;//定义盘子碎片的集合体
    // Start is called before the first frame update
    void Start()
    {
        piecescollection = GameObject.Find("PiecesCollection").gameObject.GetComponent<Transform>();//获取盘子碎片集合体
        m_transform = gameObject.GetComponent<Transform>();//获取盘子生成点
        //根据盘子位置确定发射方向
        if (m_transform.position.x <= 0)
        {
            x = 1;
        }
        else
        {
            x = -1;
        }
        if (m_transform.position.y <= 6)
        {
            y = 1;
        }
        else
        {
            y = -1;
        }
        //随机发射速度（发射角30到60度）
        randomx = Random.Range(0.5f, 1.0f);
        randomy = Random.Range(0.5f, 1.0f);
        //保证向下发射时角度不大于45度
        if (y == -1 && randomx < randomy)
        {
            randomx += randomy;
            randomy = randomx - randomy;
            randomx -= randomy;
        }
        GetComponent<Rigidbody>().AddForce(new Vector3(randomx * x, randomy * y, 0) * 200);//给予盘子一个速度
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)//碰撞判定
    {
        if (collision.transform.tag == "Bullet")//碰到子弹
        {

            Break();
            Destroy(this.gameObject);//自毁
            CreateDisc.disccount -= 1;//在场盘子数量减一
            ScoreControler.hitcount += 1;
        }
        if (collision.transform.tag == "Ground")//碰到地面
        {
            Destroy(this.gameObject);//自毁
            CreateDisc.disccount -= 1;//在场盘子数减一
        }
    }

    void Break()
    {
        GameObject piecesclone = GameObject.Instantiate(discpieces, transform.position, transform.rotation); //生成盘子碎片
        piecesclone.GetComponent<Transform>().SetParent(piecescollection);//归到父物体下
        GameObject.Destroy(piecesclone, 4.0f);//删除原来的盘子
    }

}
