using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorControler : MonoBehaviour
{
    public string menu;
    // Start is called before the first frame update
    void Start()
    {
        ToHideCursor();//隐藏鼠标
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//按下esc
        {
            ToShowCursor();//显示鼠标
            CreateDisc.disccount = 0;
            SceneManager.LoadScene(menu);//切换到菜单
        }
    }

    void ToHideCursor()//隐藏鼠标
    {
        Cursor.visible = false;
    }
    void ToShowCursor()//显示鼠标
    {
        Cursor.visible = true;
    }
}
