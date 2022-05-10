using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject Target;
    public int move_method;
    public float speed;
    public Vector2 speed_vec;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove(){
        if(move_method == 0){
            speed_vec = Vector2.zero;

            if (Input.GetKey(KeyCode.W)){
                speed_vec.y += speed;
            }
            if (Input.GetKey(KeyCode.S)){
                speed_vec.y -= speed;
            }
            if (Input.GetKey(KeyCode.A)){
                speed_vec.x -= speed;
            }
            if (Input.GetKey(KeyCode.D)){
                speed_vec.x += speed;
            }

            transform.Translate(speed_vec);
        }
        else if (move_method == 1){
            speed_vec.x = Input.GetAxis("Horizontal") * speed;
            speed_vec.y = Input.GetAxis("Vertical") * speed;

            transform.Translate(speed_vec);
        }
        else if (move_method == 2){
            speed_vec = Vector2.zero;

            if (Input.GetKey(KeyCode.W)){
                speed_vec.y += speed;
            }
            if (Input.GetKey(KeyCode.S)){
                speed_vec.y -= speed;
            }
            if (Input.GetKey(KeyCode.A)){
                speed_vec.x -= speed;
                transform.localScale = new Vector3(0.5f,0.5f,1);
            }
            if (Input.GetKey(KeyCode.D)){
                speed_vec.x += speed;
                transform.localScale = new Vector3(-0.5f,0.5f,1);
            }

            //transform.Translate(speed_vec);
            GetComponent<Rigidbody2D>().velocity = speed_vec;
        }

 
    }
    
}
