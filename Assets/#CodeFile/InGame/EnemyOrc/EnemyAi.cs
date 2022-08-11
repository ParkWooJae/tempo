using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;
    [Header("추격 속도")]
    [SerializeField] [Range(1f,4f)] float moveSpeed = 3f;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 9){
            FollowTarget();
            RunAnimation();
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

    // void IdleAnimation(){

    // }


}
