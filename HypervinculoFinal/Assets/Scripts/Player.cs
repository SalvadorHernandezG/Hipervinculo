using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private Animator anim;
    //public float x,y;
    float speed = 8f;
    float rotationSpeed = 50f;
    private Rigidbody rb;
    public bool avanzoSolo;
    public bool estoyAtacando;
    public float impulsoDeGolpe = 30f;
    // Update is called once per frame

    public bool conArma;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       anim = GetComponent<Animator>();
    }

    void OnTriggerEnter (Collider coll)
    {
        if(coll.CompareTag("arma"))
        {
            
        }
    }

    void Update()
    {
        //x = Input.GetAxis("Horizontal");
        //y = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && !estoyAtacando)
        {

            if (conArma)
            {
                anim.SetTrigger("Golpe2");
                estoyAtacando = true;
            }
            else 
            {
                anim.SetTrigger("Golpe");
                estoyAtacando = true;
            }
        }

        if (!estoyAtacando)
        {
                  Vector3 movementDirection = new Vector3(-horizontalInput, 0, -verticalInput);
      movementDirection.Normalize();

      transform.position = transform.position + movementDirection * (speed * Time.deltaTime);
      if (movementDirection != Vector3.zero)
          transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
        }

        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoDeGolpe;
        }
        

        //transform.Rotate(0,x*Time.deltaTime*rotationSpeed,0);
        //transform.Translate(0,0,y*Time.deltaTime * speed);





        anim.SetFloat("VelX",horizontalInput);
        anim.SetFloat("VelY",verticalInput);


    }

        public void DejoDeGolpear()
        {
            estoyAtacando=false;
        }

        public void ananzoSolo()
        {
            avanzoSolo=true;
        }

        public void DejoDeAvanzar()
        {
            avanzoSolo=false;
        }

}
