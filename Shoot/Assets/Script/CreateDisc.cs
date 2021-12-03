using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateDisc : MonoBehaviour
{
    public int roundcount;//定义实际轮数
    public GameObject m_disc; //定义公共游戏对象m_disc
    private Transform m_transform; //定义变换类型对象m_transform
    private float m_time = 2; //定义浮点类型m_time，作用是2s后生成盘子
    private Transform m_collection; //定义变换类型对象m_collection，这是用于收集克隆盘子的父类，相当于一个文件夹
    private float randomX;//定义随机x坐标
    public static int disccount;//在场盘子计数
    public int discsum;//发射盘子总数
    public GameObject score;//为了获取ScoreControler脚本
    public bool roundbool, roundbool2, scorebool, gunbool;
    public GameObject round;
    public Text roundText;
    public GameObject head;
    // Use this for initialization
    void Start()
    {
        //初始赋值
        roundcount = 1;
        discsum = 0;
        roundbool = false;
        roundbool2 = true;
        scorebool = true;
        gunbool = true;
        m_transform = gameObject.GetComponent<Transform>(); //获取Transform组件
        m_collection = GameObject.Find("DiscCollection").gameObject.GetComponent<Transform>(); //获取名为DiscCollection的Transform组件
    }

    // Update is called once per frame
    void Update()
    {
        if (roundbool)//如果没达到上限
        {
            m_time -= Time.deltaTime;//计时
            if (m_time < 0 && disccount < 2)
            {
                Batchdisc(); //调用生成函数
                discsum += 1;//飞盘总数加一
                if (discsum == 5)//如果达到一轮上限5个
                {
                    discsum = 0;//清空总数
                    //通过bool值进行一次性的调用
                    roundbool2 = false;
                    roundbool = false;
                    scorebool = true;
                }
                m_time = 2; //计时用的时间重置为2
            }
        }
        else if (disccount == 0)//如果没有在场的盘子且达到了上限
        {
            if (roundbool2 == false)//轮数加一
            {
                roundcount += 1;
                roundbool2 = true;
            }
            if (roundcount != 1)
            {
                //第二轮开始显示前一次的分数和下一轮轮数
                Invoke("ShowScoreOn", 2f);
                Invoke("ShowScoreOff", 4f);
                Invoke("RoundOn", 4f);
                Invoke("RoundOff", 6f);
            }
            else
            {
                //第一轮只显示轮数
                RoundOn();
                Invoke("RoundOff", 2f);
            }
        }
    }

    private void Batchdisc()
    {
        if (Random.value <= 0.5f)//随机生成左边或者右边
        {
            randomX = -15.0f;
        }
        else
        {
            randomX = 15.0f;
        }
        disccount += 1;//在场盘子数加一
        Vector3 pos = new Vector3(randomX, Random.Range(2.0f, 10.0f), Random.Range(15.0f, 20.0f)); //随机一个位置
        GameObject clonedisc = GameObject.Instantiate(m_disc, pos, m_transform.rotation); //创建克隆并赋值
        clonedisc.GetComponent<Transform>().SetParent(m_collection); //把克隆体装入一个父类里
    }
    //显示分数
    void ShowScoreOn()
    {
        if (scorebool)
        {
            head.GetComponent<CameraController>().onUpdate = false;//设置不能移动镜头
            roundText.text = "Score:" + score.GetComponent<ScoreControler>().score;//设置文本为分数
            round.SetActive(true);//显示轮数与分数
            scorebool = false;//设置本函数只执行一次
            gunbool = false;//设置不能开枪
        }
    }
    //清空分数相关变量
    void ShowScoreOff()
    {
        ScoreControler.hitcount = 0;
        score.GetComponent<ScoreControler>().bulletcount = 0;
    }
    //显示轮数
    void RoundOn()
    {
        score.GetComponent<ScoreControler>().round = roundcount;//设置轮数
        head.GetComponent<CameraController>().onUpdate = false;//设置不能移动镜头
        roundText.text = "Round" + roundcount;//设置文本为轮数
        round.SetActive(true);//显示分数与轮数
        gunbool = false;//设置不能开枪
    }
    //隐藏轮数
    void RoundOff()
    {
        head.GetComponent<CameraController>().onUpdate = true;//设置能移动镜头
        roundbool = true;//设置进入下一轮的开关开启
        round.SetActive(false);//隐藏文本
        gunbool = true;//设置能开枪
    }
}
