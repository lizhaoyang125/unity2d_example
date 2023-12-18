using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //碰撞函数
    public TextMeshPro text; // 使用TextMeshPro代替TextMesh
    public int hp = 100;
    public GameObject Goblin;
    private Animator animator;

    void Start()
    {
        //更新文本
        text.text = hp.ToString();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果碰撞到的是敌人
        print("碰撞！！1");
        if (collision.tag == "Bullet")
        {
            animator.Play("Hit", 2);
            ///销毁子弹
            Destroy(collision.gameObject);
            hp--;
            //更新文本
            text.text = hp.ToString();
            if (hp == 0)
            {
                //destroy this object
                Destroy(gameObject);
            }
        }
    
    }
}
