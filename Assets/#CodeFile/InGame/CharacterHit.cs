using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHit : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    bool NowHurt = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OffDamaged();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy"){
            if(NowHurt == false){
                OnDamaged(collision.transform.position);
            }
            
        }
    }

    void OnDamaged(Vector2 targetPos){
        
        float dircX = transform.position.x - targetPos.x;
        float dircY = transform.position.y - targetPos.y;

         if (dircX > 1){
            dircX = 1;
        }
        if (dircX < -1){
            dircX = -1;
        }
        if (dircY > 1){
            dircY = 1;
        }
        if (dircY < -1){
            dircY = -1;
        }

        gameObject.layer = 12;  
        NowHurt = true;      
        animator.SetTrigger("Hit");
        rigid.AddForce(new Vector2(dircX,dircY)*7,ForceMode2D.Impulse);      
        
    }

    void OffDamaged() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f){
            rigid.velocity = Vector3.zero;
            NowHurt = false;
            gameObject.layer = 6;
        }
    }
}
