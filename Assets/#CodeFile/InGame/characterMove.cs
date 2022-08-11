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
    public Vector3 CharacterPosition;
    Camera Camera;
    Rigidbody2D rid2D;
    static public bool attacking = false;
    static public bool sliding = false;
    static public bool teleportDelay = false;

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
        if(gameObject.layer != LayerMask.NameToLayer("invinci")){
            PlayerMove();
            PlayerAttack();
            PlayerTeleport();
        }
    }
    



    void RunAnimation(){
        animator.SetBool("idle",false);
        animator.SetBool("run",true);
    }
    void IdleAnimation(){
        animator.SetBool("run",false);
        animator.SetBool("idle",true);
    }
    IEnumerator TeleportDelay(){
        yield return new WaitForSeconds(5.0f);
        teleportDelay = false;
    }
    void PlayerTeleport(){
        if (!teleportDelay){
            if (attacking == false){
                if(Input.GetKeyDown(KeyCode.Space)){
                    animator.SetTrigger("teleport");
                    if(transform.position.x - 2 > -11.1){
                        if(animator.GetFloat("runX") == 1){
                            transform.position += new Vector3(-2,0,0);
                        }
                    }
                    else if (transform.position.x - 2 < -11.2){
                        if(animator.GetFloat("runX") == 1){
                            CharacterPosition = transform.position;
                            transform.position = new Vector3(-11.1f,CharacterPosition.y,CharacterPosition.z);
                        }
                    }
                    if(transform.position.x + 2 < 11.1 ){
                        if(animator.GetFloat("runX") == -1){
                            transform.position += new Vector3(2,0,0);
                        }
                    }
                    else if (transform.position.x + 2 > 11.1){
                        if(animator.GetFloat("runX") == -1){
                            CharacterPosition = transform.position;
                            transform.position = new Vector3(11.1f,CharacterPosition.y,CharacterPosition.z);
                        }
                    }
                    if(transform.position.y + 2 < 4.52){
                        if(animator.GetFloat("runY") == 1){
                            transform.position += new Vector3(0,2,0);
                        }
                    }
                    else if (transform.position.y + 2 > 4.52){
                        if(animator.GetFloat("runY") == 1){
                            CharacterPosition = transform.position;
                            transform.position = new Vector3(CharacterPosition.x, 4.52f ,CharacterPosition.z);
                        }
                    }
                    if(transform.position.y -2 > -6){
                        if(animator.GetFloat("runY") == -1){
                            transform.position += new Vector3(0,-2,0);
                        }
                    }
                    else if (transform.position.y -2 < -6){
                        if(animator.GetFloat("runY") == -1){
                            CharacterPosition = transform.position;
                            transform.position = new Vector3(CharacterPosition.x, -6f ,CharacterPosition.z);
                        }
                    }
                    teleportDelay = true;
                    StartCoroutine(TeleportDelay());
                }
            }

        }
        

        
    }

    void PlayerAttack(){
        if (Input.GetMouseButtonDown(0) &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
            animator.SetTrigger("attack");
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);
            
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
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.64f){
            attacking = false;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("teleport") ){
            attacking = false;
        }
        
    }

    void PlayerMove(){

            speed_vec = Vector2.zero;
            
            if (attacking == false){
                if (sliding == false){
                    if (Input.GetKey(KeyCode.W)){
                        speed_vec.y += speed;
                        animator.SetFloat("runX",0);
                        animator.SetFloat("runY",1);
                        RunAnimation();
                    }
                              
                    if (Input.GetKey(KeyCode.S)){
                        speed_vec.y -= speed;
                        animator.SetFloat("runX",0);
                        animator.SetFloat("runY",-1);
                        RunAnimation();
                    }
                               
                    if (Input.GetKey(KeyCode.A)){
                        speed_vec.x -= speed;
                        //rend.flipX = false;
                        transform.localScale = new Vector3(0.74f,0.75f,1);
                        animator.SetFloat("runY",0);
                        animator.SetFloat("runX",1);
                        RunAnimation();           
                    }
                                
                    if (Input.GetKey(KeyCode.D)){
                        speed_vec.x += speed;
                        //rend.flipX = true;
                        transform.localScale = new Vector3(-0.74f,0.75f,1);
                        animator.SetFloat("runY",0);
                        animator.SetFloat("runX",-1);
                        RunAnimation();              
                    }
                      
                } 
            }       
            if (Input.GetKeyUp(KeyCode.W)){
                animator.SetFloat("runX",0);
                IdleAnimation();
            } 
            if (Input.GetKeyUp(KeyCode.S)){
                animator.SetFloat("runX",0);
                IdleAnimation();
            } 
            if (Input.GetKeyUp(KeyCode.A)){
                IdleAnimation();
                animator.SetFloat("runY",0);
            }
            if (Input.GetKeyUp(KeyCode.D)){
                IdleAnimation();
                animator.SetFloat("runY",0);
            } 
            GetComponent<Rigidbody2D>().velocity = speed_vec;

            
        
        
 
    }

    
}
