using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    public string play, settings, menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPlay()
    {
        SceneManager.LoadScene(play);//切换到游戏场景
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(settings);//切换到设定场景
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(menu);//切换到菜单场景
    }

    public void ExitGame()
    {
        Application.Quit();//点击结束退出游戏
    }
}
