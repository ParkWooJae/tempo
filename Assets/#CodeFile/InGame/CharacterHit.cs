using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHit : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    bool NowHurt = false;
    public Image HpBar;
    public float MaxHp;
    float NowHp;
    public bool NowPlayerDie = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        NowHp = MaxHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        OffDamaged();
        PlayerHpBar();
        DestroyPlayer();
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
        NowHp -= 5;
        if(NowHp <= 0){
            PlayerDie();
        }
        else{
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
                      
    }

    void PlayerDie(){
        gameObject.layer = 12;
        animator.SetTrigger("Die");
        NowPlayerDie = true;
        rigid.velocity = Vector3.zero;
    }
    void DestroyPlayer(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("vanish")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f){
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    void PlayerHpBar(){
        HpBar.fillAmount = NowHp / MaxHp;
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
