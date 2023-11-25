using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//aaaa
using System;

using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public int vidaMax;
    //public float vidaActual;
    public Image barraVida;
    public float daño = 2.0f;
    public float Fdaño = 10.0f;

    //aaaa
    [SerializeField] private float vidaActual;
    public event EventHandler MuerteJuagador;



    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        if (vidaActual <= 0)
        {
            MuerteJuagador?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
        }
    }

    public void RevisarVida()
    {
        barraVida.fillAmount = vidaActual / vidaMax;
    }

        void OnTriggerEnter (Collider coll)
    {
        if(coll.CompareTag("arma"))
        {
            vidaActual -= daño;
        }

          if(coll.CompareTag("Farma"))
        {
            vidaActual -= Fdaño;
        }
    }


}
