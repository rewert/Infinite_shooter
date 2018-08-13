using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    GameObject explode;
    public int scoreValue;
    private GameController gameController;
	
	void Start(){
		explode = Resources.Load<GameObject>("Prefabs/explode") as GameObject;
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
	}

    void OnTriggerEnter(Collider other) 
    {
        if (this.tag == "Enemy" && other.tag == "Enemy" || other.tag == "Boundary"){
            return;
        }
        if (this.tag == "Enemy" && other.tag == "Player" || this.tag == "Player" && other.tag == "Enemy"){
            return;
        }
        gameController.AddScore (scoreValue);
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}