using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject Target;
    public float speed;
    public Vector2 speed_vec;
    public float Horizontal;
    public float Vertical;
    public Animator animator;
    public SpriteRenderer rend;
    Rigidbody2D rid2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        rid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove(){
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
       
            speed_vec = Vector2.zero;

            if (Input.GetKey(KeyCode.W)){
                speed_vec.y += speed;
                animator.SetBool("characterMoveUp",true);
            }
            if (Input.GetKeyUp(KeyCode.W)){
                animator.SetBool("characterMoveUp",false);
            }
            if (Input.GetKey(KeyCode.S)){
                speed_vec.y -= speed;
                animator.SetBool("characterMoveDawn",true);
            }
            if (Input.GetKeyUp(KeyCode.S)){
                animator.SetBool("characterMoveDawn",false);
            }
            if (Input.GetKey(KeyCode.A)){
                speed_vec.x -= speed;
                rend.flipX = false;
                animator.SetBool("characterMoveSide",true);
            }
            if (Input.GetKeyUp(KeyCode.A)){
                animator.SetBool("characterMoveSide",false);
            }
            if (Input.GetKey(KeyCode.D)){
                speed_vec.x += speed;
                rend.flipX = true;
                animator.SetBool("characterMoveSide",true);
            }
            if(Input.GetKeyUp(KeyCode.D)){
                animator.SetBool("characterMoveSide",false);
            }
            GetComponent<Rigidbody2D>().velocity = speed_vec;

            
        
        
 
    }
    
}
