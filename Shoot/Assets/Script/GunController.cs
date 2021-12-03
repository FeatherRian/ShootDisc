using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform BulletPoint;//关联子弹发射点
    public GameObject BulletPre;//关联子弹预设体
    private float cd = 0.8f;//蓄力时间
    private float timer = 0;//计时器
    private AudioSource gunPlayer;//声音播放组件
    public AudioClip clip;//关联枪声音效
    public Transform m_collection;//定义子弹的克隆体父物体位置
    public GameObject score;//关联分数
    public GameObject disc;//关联生成盘子
    void Start()
    {
        gunPlayer = GetComponent<AudioSource>();//获取播放器组件
    }

    // Update is called once per frame
    void Update()
    {
        if (disc.GetComponent<CreateDisc>().gunbool == true)//判定是否可以使用枪
        {
            if (Input.GetMouseButton(0))//检测鼠标左键点击
            {
                timer += Time.deltaTime;//开始计算蓄力时间
            }
            else//松开左键
            {
                if (timer > cd)//如果蓄力达到标准
                {
                    score.GetComponent<ScoreControler>().bulletcount += 1;//子弹计数加1
                    GameObject clonebullet = GameObject.Instantiate(BulletPre, BulletPoint.position, BulletPoint.rotation);//创建子弹
                    clonebullet.GetComponent<Transform>().SetParent(m_collection);//将子弹的克隆归到一个父物体下
                    gunPlayer.PlayOneShot(clip);//播放枪声
                }
                timer = 0;//计时器归零
            }
            if (timer < cd)//判定是否蓄满力，然后给与一个镜头拉伸
            {
                Camera.main.fieldOfView = 60 - timer * 15;
            }
            else
            {
                Camera.main.fieldOfView = 60 - cd * 15;
            }
        }
        else//不能使用枪的情况
        {
            timer = 0;//清空计时器
            Camera.main.fieldOfView = 60;//回复视野
        }
    }
}
