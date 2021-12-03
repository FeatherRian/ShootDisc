using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreControler : MonoBehaviour
{

    public Text ScoreControl;//关联分数文档
    public int score, round;
    public GameObject disc;//关联生成盘子
    public static int hitcount;//击中数
    public int bulletcount, discnum;//定义子弹数与已经销毁的盘子数
    // Start is called before the first frame update
    void Start()
    {
        round = 1;//初始化轮数
    }

    // Update is called once per frame
    void Update()
    {
        //计算已经销毁的盘子
        if (disc.GetComponent<CreateDisc>().discsum != 0)
        {
            discnum = disc.GetComponent<CreateDisc>().discsum - CreateDisc.disccount;
        }
        else
        {
            discnum = 5 - CreateDisc.disccount;
        }

        if (bulletcount != 0)//如果开过枪
        {
            if (bulletcount >= discnum)//如果开枪次数大于盘子销毁数，就按开枪数算
            {
                score = 100 * hitcount / bulletcount;
            }
            else//否则按盘子销毁数算
            {
                score = 100 * hitcount / discnum;
            }
        }
        else//没开枪0分
        {
            score = 0;
        }
        ScoreControl.text = round + ":" + score;//显示轮数与分数
    }
}
