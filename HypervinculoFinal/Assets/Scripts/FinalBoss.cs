using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
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
        gameManager.UpdateScore(int.Parse(currentScore));

    }


    public void Comportamiento_FEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 20)
        {            
            ani.SetBool("Fwalk", false);
            cornometro+= 1 * Time.deltaTime;
            if (cornometro >= 4)
            {
            rutina = Random.Range(0,2);
            cornometro = 0;
            }

            switch(rutina)
            {
            case 0:
            ani.SetBool("Fwalk", false);
            break;

            case 1:
            grado= Random.Range(0, 360);
            angulo= Quaternion.Euler(0, grado, 0);
            rutina++;
            break;

            case 2:
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            ani.SetBool("Fwalk",true);
            break;
        }
            
        } else  {
           if (Vector3.Distance(transform.position, target.transform.position) > 10 )
           {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("Fwalk", false);

               ani.SetBool("Fwalk", true);
               transform.Translate(Vector3.forward * 5 * Time.deltaTime);

                ani.SetBool("Fattack", false);
           }
           else
           {
               ani.SetBool("Fwalk", false);
              // ani.SetBool("run", false);

               ani.SetBool("Fattack", true);
               atacando= true;
           }
        } 
    }

        public void Final_Ani()
    {
        ani.SetBool("Fattack", false);
        atacando= false;
    }
    // Update is called once per frame
    void Update()
    {
        Comportamiento_FEnemigo();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto")
        {
            if (anim != null)

            hp -= dañoArma1;
            
        }   

        if (other.gameObject.tag == "armaImpacto1")
        {
            if (anim != null)

            hp -= dañoArma2;
            
        }  

        if (other.gameObject.tag == "golpeImpacto")
        {
            if (anim != null)


            hp -= dañoPuño;
            
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(500);
        }            
    }
}
