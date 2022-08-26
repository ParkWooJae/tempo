using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHurt : MonoBehaviour
{
    Rigidbody2D rigid;
    GameObject character;
    public Animator animator;
    bool NowHurt = false;
    bool NowDie = false;
    int Hp;
    bool LongAttack = false;
    public static float CountDie = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "InGame"){
            rigid = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            character = GameObject.Find("character");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "InGame"){
            OffDamaged();
            OrcDie();
        }
    }
    void Awake()
    {
        Hp = StateField.OrcHp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "scythe" || collision.gameObject.tag == "longRange"){
            if(collision.gameObject.tag == "longRange"){
                LongAttack = true;
            }
            else if(collision.gameObject.tag == "scythe"){
                LongAttack = false;
            }
            if(NowHurt == false){
                if(NowDie == false){
                    OnDamaged(collision.transform.position);
                }
            }
        }
    }

    void OnDamaged(Vector2 targetPos){
        // int dircX = transform.position.x - character.transform.position.x > 0 ? 1 : -1;
        // int dircY = transform.position.y - character.transform.position.y > 0 ? 1 : -1;

        if(!NowDie){
            float dircX = transform.position.x - character.transform.position.x ;
            float dircY = transform.position.y - character.transform.position.y ;

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

            rigid.AddForce(new Vector2(dircX,dircY)*7,ForceMode2D.Impulse);
            if(LongAttack){
                animator.SetTrigger("OrcLongHit");
            }
            else{
                animator.SetTrigger("OrcHurt");
            }
            NowHurt = true;
            Hp -= StateField.Power;
        }
    }

    void OffDamaged() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f){
            rigid.velocity = Vector3.zero;
            NowHurt = false;
        }if (animator.GetCurrentAnimatorStateInfo(0).IsName("OrcLongHurt")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f){
            rigid.velocity = Vector3.zero;
            NowHurt = false;
        }
    }

    void OrcDie(){
        if (Hp <= 0){
            NowDie = true;
            rigid.velocity = Vector3.zero;
            gameObject.layer = 12;
            animator.SetTrigger("OrcDie");
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("vanish")&&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f){
                CountDie --;
                Destroy(gameObject);
            }
            
        }
    }
}
