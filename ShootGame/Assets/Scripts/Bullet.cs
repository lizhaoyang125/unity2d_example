using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullect : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 10.0f;
    // ������ʼ�������
    private Vector3 initPosition;

    void Start()
    {
        initPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�ӵ������ƶ�
        transform.Translate(Vector2.up * BulletSpeed * Time.deltaTime);
        //����ƶ����볬����1 �������ӵ�
        if (transform.position.y-initPosition.y>4f)
        {
            Destroy(gameObject);
        }
    }
}
