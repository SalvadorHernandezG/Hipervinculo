using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObtenerNombre : MonoBehaviour
{
    private GameObject nombre1;
    // Start is called before the first frame update

    private void Start(){
        nombre1 = GameObject.FindGameObjectWithTag("nombre1");
        nombre1.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("nombre1");
    }
}
