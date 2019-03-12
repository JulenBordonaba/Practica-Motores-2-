using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallGenerator : MonoBehaviour {

    public float timeBetweentBalls = 5f;
    public GameObject ball;
    public Transform spawn;

	// Use this for initialization
	void Start () {
        InvokeRepeating("GenerateBall", 0, timeBetweentBalls);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GenerateBall()
    {
        GameObject nuevo=Instantiate(ball, spawn.position, Quaternion.identity);
        nuevo.GetComponent<Pelota>().RandomDirection();
    }
}
