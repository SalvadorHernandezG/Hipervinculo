using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using TMPro;


public class DBMongo : MonoBehaviour
{
    // Start is called before the first frame update

    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<PlayerC2> collection;
    void Start()
    {
        // Debug.Log("Init()");
        // client = new MongoClient("mongodb+srv://Test:1234@cluster0.tp1rtii.mongodb.net/?retryWrites=true&w=majority"); 

        // db = client.GetDatabase("Unity"); 
        // collection = db.GetCollection<PlayerC2>("player");

        // var cursor = collection.AsQueryable();
        // foreach(var p in cursor.ToEnumerable())
        // {
        //     Debug.Log(p.Name);
        // }
    }

}

public class PlayerC2
{
    public ObjectId _id { get; set; }
    public string Name { get; set; }
    public float score { get; set; }
}
