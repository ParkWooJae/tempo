using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterMove : MonoBehaviour
{
    
    public float speed;
    public Vector2 speed_vec; 
    public Animator animator;
    //public SpriteRenderer rend;
    
    Rigidbody2D rid2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //rend = GetComponent<SpriteRenderer>();
        rid2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerAttack();
    }

    void RunAnimation(){
        animator.SetBool("idle",false);
        animator.SetBool("run",true);
    }
    void IdleAnimation(){
        animator.SetBool("run",false);
        animator.SetBool("idle",true);
    }

    void PlayerAttack(){
        if (Input.GetMouseButtonDown(0)){
            animator.SetTrigger("attack");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
            animator.SetTrigger("attackend");
        }
    }

    void PlayerMove(){

            speed_vec = Vector2.zero;

            if (Input.GetKey(KeyCode.W)){
                speed_vec.y += speed;
                animator.SetFloat("runX",0);
                animator.SetFloat("runY",1);
                RunAnimation();
            }
            if (Input.GetKeyUp(KeyCode.W)){
                animator.SetFloat("runX",0);
                IdleAnimation();
            }           
            if (Input.GetKey(KeyCode.S)){
                speed_vec.y -= speed;
                animator.SetFloat("runX",0);
                animator.SetFloat("runY",-1);
                RunAnimation();
            }
            if (Input.GetKeyUp(KeyCode.S)){
                animator.SetFloat("runX",0);
                IdleAnimation();
            }            
            if (Input.GetKey(KeyCode.A)){
                speed_vec.x -= speed;
                //rend.flipX = false;
                transform.localScale = new Vector3(0.74f,0.75f,1);
                animator.SetFloat("runY",0);
                animator.SetFloat("runX",1);
                RunAnimation();           
            }
            if (Input.GetKeyUp(KeyCode.A)){
                IdleAnimation();
                animator.SetFloat("runY",0);
            }            
            if (Input.GetKey(KeyCode.D)){
                speed_vec.x += speed;
                //rend.flipX = true;
                transform.localScale = new Vector3(-0.74f,0.75f,1);
                animator.SetFloat("runY",0);
                animator.SetFloat("runX",-1);
                RunAnimation();              
            }
            if (Input.GetKeyUp(KeyCode.D)){
                IdleAnimation();
                animator.SetFloat("runY",0);
            }            
            GetComponent<Rigidbody2D>().velocity = speed_vec;

            
        
        
 
    }
}
