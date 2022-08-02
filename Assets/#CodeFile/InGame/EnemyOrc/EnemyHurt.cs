using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject character;
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
        if(collision.gameObject.tag == "scythe" || collision.gameObject.tag == "longRange"){
            OnDamaged(collision.transform.position);
        }
    }

    void OnDamaged(Vector2 targetPos){
        int dircX = transform.position.x - character.transform.position.x > 0 ? 1 : -1;
        int dircY = transform.position.y - character.transform.position.y > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dircX,dircY)*7,ForceMode2D.Impulse);
    }
}
