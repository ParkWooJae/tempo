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
    float NowHp;
    public bool NowPlayerDie = false;
    public GameObject PlayerDiePage;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        NowHp = StateField.Hp;
        PlayerHpBar();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetState();
        OffDamaged();
        PlayerHpBar();
        DestroyPlayer();
    }

    IEnumerator TeleportInvin(){
        gameObject.layer = 15;
        yield return new WaitForSeconds(0.8f);
        gameObject.layer = 6;
        NowHurt = false;
    }


    void GetState(){
        if(StateField.StateUpdate){
            NowHp = StateField.Hp;
            PlayerHpBar();
            StateField.StateUpdate = false;
        }
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
        if(StateField.OrcPower - StateField.Armer > 1){
            NowHp = NowHp - (StateField.OrcPower - StateField.Armer);
        }
        else{
            NowHp -= 1;
        }
        
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
            
            NowHurt = true;
            gameObject.layer = 12;  
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
            PlayerDiePage.SetActive(true);
            EnemyHurt.CountDie = 0;
            StateField.OrcHp = 5;
            StateField.OrcPower = 1;
            StateField.Hp = StateField.DefaultHp;
            StateField.Armer = StateField.DefaultArmer;
            StateField.Power = StateField.DefaultPower;
            StateField.StatePoint = 0;
            StateField.DefaultStatePoint = 0;
        }
    }

    void PlayerHpBar(){
        HpBar.fillAmount = NowHp / StateField.Hp;
    }

    void OffDamaged() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f){
            rigid.velocity = Vector3.zero;
            StartCoroutine(TeleportInvin());
            
        }
    }
}
