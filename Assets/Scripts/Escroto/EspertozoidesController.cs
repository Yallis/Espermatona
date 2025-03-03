using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspertozoidesController : MonoBehaviour{

    public GameObject espermatozoido;

    //List<GameObject> espermatozoidosList = new List<GameObject>(); 

    void Start(){
        for(int i=0; i<10; i++) {
            Vector2 spawnPosition = PolarToVector2((26*i-130), (float)Random.Range(15, 45)/10);
            GameObject newEspermatozoido = Instantiate(espermatozoido, spawnPosition, Quaternion.identity);
            newEspermatozoido.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            newEspermatozoido.transform.parent = gameObject.transform;
            //espermatozoidosList.Add(newEspermatozoido);
        }
    }


    void Update(){
        
    }

    Vector2 PolarToVector2(float degrees, float r) {
        float radians = degrees * Mathf.Deg2Rad;
        return new Vector2(r * Mathf.Sin(radians), r * Mathf.Cos(radians));
    }
}
