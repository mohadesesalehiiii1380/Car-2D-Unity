using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    public Transform transform;
    public float speed = 1.5f;
    public float rotationSpeed = 5f;

    public Score_Manager score_Value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       Movment();
       Clamp();


    }

    void Movment() {
 if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(speed * Time.deltaTime ,0,0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,57), rotationSpeed * Time.deltaTime);
        }

         if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= new Vector3(speed * Time.deltaTime ,0,0);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,115), rotationSpeed * Time.deltaTime);
        }

        if (transform.rotation.z != 90) {
             transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,90), rotationSpeed * Time.deltaTime);
        }
    }

    void Clamp() {

        // if (transform.position.x < -1.92f) {
        //     transform.position = new Vector3(-1.92f,transform.position.y,transform.position.z);
        // }

        //    if (transform.position.x > 1.92f) {
        //     transform.position = new Vector3(1.92f,transform.position.y,transform.position.z);
        // }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x,-1.92f,1.92f);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Cars"){
               Time.timeScale = 0 ;
        }
        if (collision.gameObject.tag == "Coin"){
               score_Value.score += 10;
               Destroy(collision.gameObject);
        }
        
    }
}
