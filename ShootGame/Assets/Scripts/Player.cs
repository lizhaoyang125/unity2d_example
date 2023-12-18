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
    public float Speed = 2.0f;
    public float BulletSpeed = 10.0f;
    public FirearmFxExample FirearmFx;
    public GameObject Map; // The object you want to instantiate
    public GameObject Bullet1;


    public float attackInterval = 1.0f; // 攻击间隔，单位为秒
    private float lastAttackTime = 0.0f; // 上次攻击的时间
    //public Assets.HeroEditor4D.Common.Scripts.CharacterScripts.Character front, back, left, right;
    //public AppearanceExample AppearanceExample;
    // Start is called before the first frame update
    float xMove, yMove;
    private Animator animator;
    private int fireIndex=0;
    void Start()
    {
        anim.SetState(CharacterState.Walk);
        animator = GetComponent<Animator>();
        for(int i = 0; i < 10; i++) { Instantiate(Map, new Vector3(0, 10*i+1, 0), Quaternion.identity); }
        
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
        if (xMove == 0 && yMove == 0)
        {
            anim.SetState(CharacterState.Idle);
            anim.SetState(CharacterState.Walk);
            gunmanCha.SetDirection(Vector2.up);
            //move player up
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
            print("move up");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetState(CharacterState.Walk);
            gunmanCha.SetDirection(Vector2.right);
            if (transform.position.x < 1.5f) { 
                transform.position = new Vector3(transform.position.x+1.5f, transform.position.y, transform.position.z);
            }
            print("move right");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetState(CharacterState.Walk);
            gunmanCha.SetDirection(Vector2.left);
            if (transform.position.x > -1.5f){ 
                transform.position = new Vector3(transform.position.x -1.5f, transform.position.y, transform.position.z);
            }
            print("move left");
        }


        if (Time.time - lastAttackTime > attackInterval)
        {
            Fire();
            lastAttackTime = Time.time;
        }
        //如果按下q键，换装备
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print(fireIndex);
            EquipFirearm(fireIndex);
            fireIndex++;
        }


    }
    void Fire() {
        animator.Play("Fire2H", 1);
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
        //例化子弹Bullet1
        GameObject bullet = Instantiate(Bullet1, transform.position+new Vector3(0.1f,1.5f,0), Quaternion.identity);
        Bullect bulletScript = bullet.GetComponent<Bullect>();
        bulletScript.BulletSpeed=BulletSpeed;
        //bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, BulletSpeed);
        Destroy(bullet, 1.0f);


    }
    public void EquipFirearm(int index)
    {
       // var randomIndex = Random.Range(0, gunmanCha.SpriteCollection.Firearm2H.Count);
        var randomItem = gunmanCha.SpriteCollection.Firearm2H[index];
        gunmanCha.Equip(randomItem, EquipmentPart.Firearm2H);
        //AppearanceExample.Refresh();
    }

    //碰撞器函数
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AUG")
        {
            Destroy(other.gameObject);
            //Destroy(gameObject);
            print("碰撞");
            EquipFirearm(3);
        }
        if (other.gameObject.tag == "AR-CL")
        {
            Destroy(other.gameObject);
            //Destroy(gameObject);
            print("碰撞");
            EquipFirearm(2);
            attackInterval = 0.2f;
        }
        if (other.gameObject.tag == "M134")
        {
            Destroy(other.gameObject);
            //Destroy(gameObject);
            print("碰撞");
            attackInterval = 0.1f;
            EquipFirearm(9);
        }
    }

}
