using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int hp;
    public int dañoArma1;
    public int dañoArma2;
    public int dañoPuño;
    public Animator anim;
    private Rigidbody rb;
    public int rutina;
    public float cornometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public bool atacando;

    public GameObject target;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        var currentScore = PlayerPrefs.GetString("score1");
        Debug.Log(currentScore);
        gameManager.UpdateScore(int.Parse(currentScore));
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 18)
        {
            ani.SetBool("run", false);
            cornometro+= 1 * Time.deltaTime;
            if (cornometro >= 4)
            {
            rutina = Random.Range(0,2);
            cornometro = 0;
            }

            switch(rutina)
            {
            case 0:
            ani.SetBool("walk", false);
            break;

            case 1:
            grado= Random.Range(0, 360);
            angulo= Quaternion.Euler(0, grado, 0);
            rutina++;
            break;

            case 2:
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            ani.SetBool("walk",true);
            break;
        }
    }
       else 
       {
           if (Vector3.Distance(transform.position, target.transform.position) > 5 )
           {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);

                ani.SetBool("attack", false);
           }
           else
           {
               ani.SetBool("walk", false);
               ani.SetBool("run", false);

               ani.SetBool("attack", true);
               atacando= true;
           }
        } 
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando= false;
    }
    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto")
        {
            if (anim != null)
            {
                anim.Play("DañoEnemigo");
            }

            hp -= dañoArma1;
            
        }   

        if (other.gameObject.tag == "armaImpacto1")
        {
            if (anim != null)
            {
                anim.Play("DañoEnemigo");
            }

            hp -= dañoArma2;
            
        }  

        if (other.gameObject.tag == "golpeImpacto")
        {
            if (anim != null)
            {
                anim.Play("DañoEnemigo");
            }

            hp -= dañoPuño;
            
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(100);
        }            
    }
}
