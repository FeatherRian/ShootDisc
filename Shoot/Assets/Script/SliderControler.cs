using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{
    public static float mouse;
    public Slider mainslider;
    public Text slidertext;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()//显示滑动条组件的value值
    {
        mouse = mainslider.value;
        slidertext.text = "" + mainslider.value;

    }
}
