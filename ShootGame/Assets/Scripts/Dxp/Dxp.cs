using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dxp : MonoBehaviour
{
    public GameObject[] holes = new GameObject[9];
    int interval = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (interval == 100)
        {
            // 从0到8随机生成一个数
            interval = 0;
            int i = Random.Range(0, 9);

            // 获取holes数组中的第i个元素的子物体BossP，并将其激活
            GameObject bossP = holes[i].transform.GetChild(0).gameObject;
            bossP.SetActive(true);

            // 延迟1秒后隐藏子物体
            Invoke("HideBossP", 2f);
        } else
        {
            interval++;
        }
        // 检测鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            HideBossP();
        }
    }
    // 隐藏子物体的方法
    void HideBossP()
    {
        // 遍历holes数组，将所有子物体BossP隐藏
        foreach (GameObject hole in holes)
        {
            hole.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
