using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesControler : MonoBehaviour
{
    public GameObject[] piece = new GameObject[6];
    private float randomx, randomy;
    private int i;
    private int x, y;
    // Start is called before the first frame update
    void Start()
    {
        for (i = 0; i < 6; i++)
        {
            //定义每块碎片飞出的方向
            if (i > 2)
            {
                x = -1;
            }
            else
            {
                x = 1;
            }
            if (2 <= i && i <= 4)
            {
                y = 1;
            }
            else
            {
                y = -1;
            }
            //随机生成水平与数直方向速度
            randomx = Random.Range(0f, 1.0f);
            randomy = Random.Range(0f, 1.0f);
            //给碎片一个力
            piece[i].GetComponent<Rigidbody>().AddForce(new Vector3(randomx * x, randomy * y, 0) * 30);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
