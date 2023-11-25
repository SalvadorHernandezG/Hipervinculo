using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

public class NamePlayer : MonoBehaviour
{
    public TMP_InputField inputField;

    public TextMeshProUGUI textoNombre;
    public Image luz;
    public GameObject botonAceptar;
    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<PlayerC> collection;

    private void Awake(){
        luz.color = Color.red;
    }

    private void Update(){
        if(textoNombre.text.Length < 4)
        {
            luz.color = Color.red;
            botonAceptar.SetActive(false);
        }

        if(textoNombre.text.Length >= 4)
        {
            luz.color = Color.green;
            botonAceptar.SetActive(true);
        }
    }

    public async void aceptar(){
        try
        {
            // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            var uri = "mongodb+srv://Test:1234@cluster0.tp1rtii.mongodb.net/?retryWrites=true&w=majority";

            client = new MongoClient(uri); 

            db = client.GetDatabase("Unity");
            collection = db.GetCollection<PlayerC>("player");

            bool existeUsuario = false;
            
            PlayerC current = new PlayerC();
            var cursor = collection.AsQueryable();
            foreach(var p in cursor.ToEnumerable())
            {
                if (p.Name == inputField.text)
                {
                    existeUsuario = true;
                    current = p;
                    break;
                }
            }

            if (!existeUsuario)
            { 
                List<PlayerC> players = new List<PlayerC>();
                PlayerC p = new PlayerC();
                p.Name = inputField.text;
                p.score = 0;
                players.Add(p);

                collection.InsertMany(players);

                PlayerPrefs.SetString("score1", "0");
                
                // gameManager.UpdateScore(0);
            }
            else
            {
                Debug.Log(current.score);
                PlayerPrefs.SetString("score1", current.score.ToString());
                // gameManager.UpdateScore(current.score);
                // gameManager.UpdateScore(200);
            }

            PlayerPrefs.SetString("nombre1", inputField.text);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
        }
        
    }
}

public class PlayerC
{
    public ObjectId _id { get; set; }
    public string Name { get; set; }
    public float score { get; set; }
}
