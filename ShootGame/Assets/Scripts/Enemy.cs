using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Goblin;
    public GameObject BossPeng;
    // public AnimationManager GoblinAnim;
    //定义object 数组
    public GameObject[] Goblins = new GameObject[100];
    public AnimationManager[] GoblinAnims = new AnimationManager[100];

    private void Start()
    {
        //GoblinAnim.SetState(CharacterState.Idle);
        //例化新的Goblin
        for (int i = 0; i < 100; i++) {
            Goblins[i] = Instantiate(Goblin, new Vector3((i%3-1)*1.5f, i*2, 0), Quaternion.identity);
            GoblinAnims[i]= Goblins[i].GetComponent<AnimationManager>();
            GoblinAnims[i].SetState(CharacterState.Walk);
            Goblins[i].GetComponent<NewBehaviourScript>().hp = i+1;

        }
       // GoblinAnim.SetState(CharacterState.Walk);
    }
    private void Update()
    {
    }
}
