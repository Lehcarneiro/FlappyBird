using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}
    
    [FormerlySerializedAs("prefabs")]

    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 1;

    public float obstacleSpeed = 10;

    public float obstacleOffsetX = 0;

    public Vector2 obstacleOffsetY = new Vector2(0,0);

    [HideInInspector]
    public int score;

    private bool isGameOver = false;

 


    void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);

        }else{
            Instance = this;
        }
    }
    public bool IsGameActive(){
        return !isGameOver;
    }

    public bool IsGameOver(){
    return isGameOver;
    }

    public void EndGame(){
        // set flag
        isGameOver = true;

        //Print Message

        Debug.Log("Game Over... Your score was:" + score/3f );

        // reload scene 
        StartCoroutine(ReloadScene(2));

    }

    private IEnumerator ReloadScene(float delay){

        //wait
        yield return new WaitForSeconds(delay);
        // Reload scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene please");

    }


}