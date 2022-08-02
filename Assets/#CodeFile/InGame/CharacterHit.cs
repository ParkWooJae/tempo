using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHit : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy"){
            OnDamaged(collision.transform.position);
        }
    }

    void OnDamaged(Vector2 targetPos){
        
        int dircX = transform.position.x - targetPos.x > 0 ? 1 : -1;
        int dircY = transform.position.y - targetPos.y > 0 ? 1 : -1;
        gameObject.layer = 12;        
        rigid.AddForce(new Vector2(dircX,dircY)*7,ForceMode2D.Impulse);
       
        
    }
}
