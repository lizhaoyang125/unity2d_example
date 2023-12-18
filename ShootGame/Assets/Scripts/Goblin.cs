using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //��ײ����
    public TextMeshPro text; // ʹ��TextMeshPro����TextMesh
    public int hp = 100;
    public GameObject Goblin;
    private Animator animator;

    void Start()
    {
        //�����ı�
        text.text = hp.ToString();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�����ײ�����ǵ���
        print("��ײ����1");
        if (collision.tag == "Bullet")
        {
            animator.Play("Hit", 2);
            ///�����ӵ�
            Destroy(collision.gameObject);
            hp--;
            //�����ı�
            text.text = hp.ToString();
            if (hp == 0)
            {
                //destroy this object
                Destroy(gameObject);
            }
        }
    
    }
}
