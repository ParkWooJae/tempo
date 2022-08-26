using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;
    [Header("추격 속도")]
    [SerializeField] [Range(1f,4f)] float moveSpeed = 3f;
    public Animator animator;
    GameObject PlayerObject;
    CharacterHit Player;
    bool PlayerDie = false;
    Rigidbody2D rigid;

    

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "InGame"){
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            animator = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
            PlayerObject = GameObject.Find("character");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "InGame"){
            PlayerDieCheck();
            if(!Player.NowPlayerDie){
                if (gameObject.layer == 9){
                    if(!StateField.CheckEscapePage && !StateField.CheckStatePage){
                        if (PlayerObject.layer != 12 && PlayerObject.layer != 15){
                        FollowTarget();
                        RunAnimation();
                        }
                        else{
                            IdleAnimation();
                        }
                    }
                
                }
            }
        }
    }

    void FollowTarget(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void RunAnimation(){
        animator.SetBool("OrcRun",true);
        if (transform.position.x != target.position.x){
            if (transform.position.x > target.position.x){
                transform.localScale = new Vector3(1,1,1);
                animator.SetFloat("OrcRunX",1);
            }
            else {
                transform.localScale = new Vector3(-1,1,1);
                animator.SetFloat("OrcRunX",-1);
            }
        }
        else {
            animator.SetFloat("OrcRunX", 0);
        }
        if (transform.position.y != target.position.y){
            if (transform.position.y > target.position.y){
                animator.SetFloat("OrcRunY",1);
            }
            else {
                animator.SetFloat("OrcRunY",-1);
            }
        }
        else {
            animator.SetFloat("OrcRunY", 0);
        }
        
        

        
    }
    void PlayerDieCheck(){
        if (!PlayerDie){
            Player = GameObject.Find("character").GetComponent<CharacterHit>();
            if (Player.NowPlayerDie){
                gameObject.layer = 12;
                animator.SetBool("OrcJump",true);
                rigid.velocity = Vector3.zero;
                PlayerDie = true;
            }
        }
    }
    void IdleAnimation(){
        animator.SetBool("OrcRun",false);
    }


}
