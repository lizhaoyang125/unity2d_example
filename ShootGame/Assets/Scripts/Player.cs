using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using Assets.HeroEditor4D.Common.Scripts.ExampleScripts;
using System.Linq;
using System;
using Assets.HeroEditor4D.Common.Scripts.EditorScripts;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Character4D gunmanCha;
    public AnimationManager anim;
    public float Speed = 5.0f;
    public FirearmFxExample FirearmFx;
    public GameObject Map; // The object you want to instantiate

    //public Assets.HeroEditor4D.Common.Scripts.CharacterScripts.Character front, back, left, right;
    //public AppearanceExample AppearanceExample;
    // Start is called before the first frame update
    float xMove, yMove;
    private Animator animator;

    void Start()
    {
        anim.SetState(CharacterState.Walk);
        animator = GetComponent<Animator>();
        Instantiate(Map, new Vector3(0, 10, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
        if (xMove == 0 && yMove == 0)
        {
            anim.SetState(CharacterState.Idle);
        }
        else if (xMove > 0)
        {
            anim.SetState(CharacterState.Walk);
            gunmanCha.SetDirection(Vector2.right);
            //move player right
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            print("move right");
        }
        else if (xMove < 0)
        {
            anim.SetState(CharacterState.Walk);
            gunmanCha.SetDirection(Vector2.left);
            //move player left
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            print("move left");
        }
        else
        if (yMove > 0)
        {
            anim.SetState(CharacterState.Walk);
            gunmanCha.SetDirection(Vector2.up);
            //move player up
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
            print("move up"); 
        }
        else if (yMove < 0)
        {
            anim.SetState(CharacterState.Walk);
            gunmanCha.SetDirection(Vector2.down);
            //move player down
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
            print("move down");
        }
        //如果点击鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            var options = new List<CaptureOption>();
            animator.Play("Fire2H",1);
            //anim.SetState(CharacterState.Idle); ;
            //if (gunmanCha.AnimationManager.IsAction) return;
            //gunmanCha.AnimationManager.Attack();
            switch (gunmanCha.WeaponType)
            {
                
                case WeaponType.Crossbow:
                    gunmanCha.AnimationManager.CrossbowShot();
                    break;
                case WeaponType.Firearm1H:
                case WeaponType.Firearm2H:
                    {
                        gunmanCha.AnimationManager.Fire();

                        if (gunmanCha.Parts[0].PrimaryWeapon != null)
                        {
                            var firearm = gunmanCha.SpriteCollection.Firearm1H.SingleOrDefault(i => i.Sprites.Contains(gunmanCha.Parts[0].PrimaryWeapon))
                                ?? gunmanCha.SpriteCollection.Firearm2H.SingleOrDefault(i => i.Sprites.Contains(gunmanCha.Parts[0].PrimaryWeapon));

                            if (firearm != null)
                            {
                                FirearmFx.CreateFireMuzzle(firearm.Name, firearm.Collection);
                            }
                        }

                        break;
                    }
                case WeaponType.Paired:
                    gunmanCha.AnimationManager.SecondaryShot();
                    break;
            }
        }   
        
    }


}
