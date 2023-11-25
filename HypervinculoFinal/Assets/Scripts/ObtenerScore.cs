using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObtenerScore : MonoBehaviour
{
    private GameObject score1;
    // Start is called before the first frame update

    private void Start(){
        score1 = GameObject.FindGameObjectWithTag("score1");
        score1.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("score1");
    }

}