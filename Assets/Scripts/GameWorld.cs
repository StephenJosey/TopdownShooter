using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameWorld : MonoBehaviour {
    public static int WIDTH = 5;
    public static int HEIGHT = 5;
    static GameObject enemyPrefab;
    LinkedList<GameObject> enemies;
    bool loaded = false;

    // Use this for initialization
    void Start () {
        enemyPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Enemy.prefab", typeof(GameObject));
        LoadEnemies();
	}

    public void LoadEnemies()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<Enemy>().SetCoordinates(-2, 2);
        enemy.GetComponent<Enemy>().playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        //enemies.AddLast(enemy);
        enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<Enemy>().SetCoordinates(3, 3);
        enemy.GetComponent<Enemy>().playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        //enemies.AddLast(enemy);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
