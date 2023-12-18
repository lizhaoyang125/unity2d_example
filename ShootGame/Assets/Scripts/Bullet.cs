using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullect : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 10.0f;
    // 声明初始坐标变量
    private Vector3 initPosition;

    void Start()
    {
        initPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //子弹向上移动
        transform.Translate(Vector2.up * BulletSpeed * Time.deltaTime);
        //如果移动距离超过了1 则销毁子弹
        if (transform.position.y-initPosition.y>4f)
        {
            Destroy(gameObject);
        }
    }
}
