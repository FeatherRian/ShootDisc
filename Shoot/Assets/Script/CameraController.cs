using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private float mouseX, mouseY;//检测鼠标移动
    public float mouseSensitivity;//鼠标灵敏度
    public float xRotation, yRotation;//计算鼠标位移总量
    public bool onUpdate;//控制鼠标是否被检测
    private void Start()
    {
        if (SliderControler.mouse != 0)
        {
            mouseSensitivity = SliderControler.mouse;//设置灵敏度随滑动条变化
        }
        else
        {
            mouseSensitivity = 300;//默认灵敏度
        }
        onUpdate = false;
        Invoke("UpdateOn", 0.5f);//0.5s后开始检测鼠标
    }
    private void Update()
    {
        if (onUpdate == true)
        {
            //检测鼠标移动
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            //计算鼠标总位移并且根据角度限定范围，上下50度，左右60度
            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -50f, 50f);
            xRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -60f, 60f);
            //改变摄像机旋转角度
            transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0);
        }
        else
        {   //固定摄像机到正前方
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            yRotation = 0;
            xRotation = 0;
        }
    }
    void UpdateOn()
    {
        onUpdate = true;//开始检测鼠标
    }
}
