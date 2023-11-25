using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOver;
    private BarraVida barraVida;

    private void Start(){
        barraVida = GameObject.FindGameObjectWithTag("Player").GetComponent<BarraVida>();
        barraVida.MuerteJuagador += ActivarMenu;
    }

private void ActivarMenu(object sender, EventArgs e){
    gameOver.SetActive(true);

    
}
public void Reiniciar(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

public void MenuInicial(string nombre){
    SceneManager.LoadScene(nombre);
}

public void Salir(){
    UnityEditor.EditorApplication.isPlaying = false;
    Application.Quit();
}

}
