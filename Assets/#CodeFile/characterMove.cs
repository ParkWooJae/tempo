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
    public Vector2 MousePosition;
    public Vector2 attack;
    Camera Camera;
    Rigidbody2D rid2D;
    static public bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //rend = GetComponent<SpriteRenderer>();
        rid2D = GetComponent<Rigidbody2D>();
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
        
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
        if (Input.GetMouseButtonDown(0) &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
            animator.SetTrigger("attack");
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);
            
            
            

            // if (transform.position.x > MousePosition.x){
            //     attack.x = -1;
            // }
            // else if (transform.position.x < MousePosition.x){
            //     attack.x = 1;
            // }
            // if (transform.position.y > MousePosition.y){
            //     attack.y = -1;
            // }
            // else if (transform.position.y < MousePosition.y){
            //     attack.y = 1;
            // }
            
            attack.x = (transform.position.x - MousePosition.x) * -1;
            attack.y = (transform.position.y - MousePosition.y) * -1;
            
            
            if ( Mathf.Abs(attack.x) > Mathf.Abs(attack.y)){
                animator.SetFloat("attackingX",attack.x);
                animator.SetFloat("attackingY",0);
                if (attack.x > 0){
                    transform.localScale = new Vector3(-0.74f,0.75f,1);
                }
                else if (attack.x < 0){
                    transform.localScale = new Vector3(0.74f,0.75f,1);
                }
               
            }
            else if(Mathf.Abs(attack.x) < Mathf.Abs(attack.y)){
                animator.SetFloat("attackingX",0);
                animator.SetFloat("attackingY",attack.y);
                
            }
            attacking = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f){
            attacking = false;
            IdleAnimation();
        }
    }

    void PlayerMove(){

            speed_vec = Vector2.zero;
            if (attacking == false){
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
            }         
            GetComponent<Rigidbody2D>().velocity = speed_vec;

            
        
        
 
    }
}
