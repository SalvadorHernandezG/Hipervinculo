using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarArma : MonoBehaviour
{
    public BoxCollider[] armaBoxCol;
    public BoxCollider puñoBoxCol;


    public GameObject[] armas;
    // Start is called before the first frame update
    public Player player;

    void Start()
    {
        DesactivarColliderArmas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DesactivarArma();
        }
    }

    public void ActivarArma(int numero)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        armas[numero].SetActive(true);

        player.conArma = true;
    }

    public void DesactivarArma()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        } 

        player.conArma = false;     
    }

    public void ActivarColliderArmas()
    {
        for (int i = 0; i < armaBoxCol.Length; i++)
        {
            if (player.conArma)
            {
                if (armaBoxCol[i] != null)
                {
                    armaBoxCol[i].enabled = true;
                }
            }
            else
            {
                puñoBoxCol.enabled = true;
            }
        }

    }

    public void DesactivarColliderArmas()
    {
        for (int i = 0; i < armaBoxCol.Length;i++)
        {
            if (armaBoxCol[i] != null)
            {
                armaBoxCol[i].enabled = false;
            }
        }



        puñoBoxCol.enabled = false;
    }
}
