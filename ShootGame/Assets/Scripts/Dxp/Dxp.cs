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
            // ��0��8�������һ����
            interval = 0;
            int i = Random.Range(0, 9);

            // ��ȡholes�����еĵ�i��Ԫ�ص�������BossP�������伤��
            GameObject bossP = holes[i].transform.GetChild(0).gameObject;
            bossP.SetActive(true);

            // �ӳ�1�������������
            Invoke("HideBossP", 2f);
        } else
        {
            interval++;
        }
        // ���������¼�
        if (Input.GetMouseButtonDown(0))
        {
            HideBossP();
        }
    }
    // ����������ķ���
    void HideBossP()
    {
        // ����holes���飬������������BossP����
        foreach (GameObject hole in holes)
        {
            hole.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
