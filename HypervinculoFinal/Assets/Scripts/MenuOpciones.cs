using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioMixer audioMixer;
    public void PantallaCompleta(bool pantallaCompleta){
        Screen.fullScreen = pantallaCompleta;
    }

    public void CambiarVolumen(float volumen){
        audioMixer.SetFloat("Volumen", volumen);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
