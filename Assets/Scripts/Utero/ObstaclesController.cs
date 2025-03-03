using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour{

    public GameObject Obstacle1;
    public Transform playerTransform;
    public Transform ovuloTransform;

    private int[] yPos = new int[3] { 3, 0, -3 };
    private float lastXPosPlayer;
        
    void Start(){
        
    }

    void Update(){
        if (playerTransform.position.x > 5 && playerTransform.position.x - lastXPosPlayer > 5 && playerTransform.position.x < (ovuloTransform.position.x - 50)) {
            InstantiateObstacle(Random.Range(0,2));
            lastXPosPlayer = playerTransform.position.x;
        }
    }

    void InstantiateObstacle(int n) {

        for(int i=0; i<n; i++) {
            int yPosInd = Random.Range(0, yPos.Length);
            int xPos = (int)(playerTransform.position.x)/5;
            xPos = xPos * 5 + 15;

            GameObject newObstacle = Instantiate(Obstacle1, new Vector3( xPos , yPos[yPosInd], 0 ), Quaternion.identity );
            newObstacle.transform.parent = gameObject.transform;
        }
    }
}
