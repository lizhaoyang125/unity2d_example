using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5f;
    Rigidbody2D rig;
    Animator anim;
    Vector2 lookDirection = new Vector2(0, -1);
    // Start is called before the first frame update
    void Awake()
    {
        rig =GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");
        Vector2 MoveVector2 = new Vector2(MoveX, MoveY);    
        //ransform.Translate(MoveVector* speed * Time.deltaTime);
        Vector2 pos = rig.position;
        pos += MoveVector2 * speed * Time.fixedDeltaTime;
        rig.MovePosition(pos);
        if (MoveVector2.x!=0 || MoveVector2.y != 0)
        {
            lookDirection = MoveVector2;
        }

        anim.SetFloat("LookX", lookDirection.x);
        anim.SetFloat("LookY", lookDirection.y);
        anim.SetFloat("Speed", MoveVector2.magnitude);//magnitude=向量的长度
    }
    void Update()
    {


    }
}
