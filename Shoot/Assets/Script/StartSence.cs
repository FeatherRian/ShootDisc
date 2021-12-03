using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSence : MonoBehaviour
{
    public string menu;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMenu", 5f);//5s后进入菜单界面
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LoadMenu()
    {
        SceneManager.LoadScene(menu);//进入菜单界面
    }
}
