using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody1;
	private Animator animator1;
	private Rigidbody2D rigidBody2;
	private Animator animator2;

	public GameObject player1;
	public GameObject player2;

    public float maxSpeed = 5.0f;
    private bool facingRight = false;
    private bool facingDown = true;

    // Use this for initialization
    void Start () {
		rigidBody1 = player1.GetComponents<Rigidbody2D> ()[0];
		rigidBody2 = player2.GetComponents<Rigidbody2D> ()[0];

		animator1 = player1.GetComponent<Animator> ();
		animator2 = player2.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Valeur entre -1 et 1 selon intentsité de frappe sur l'axe horizontal
        float h1 = Input.GetAxis ("Horizontal_P1");
		float v1 = Input.GetAxis ("Vertical_P1");
		float h2 = Input.GetAxis ("Horizontal_P2");
		float v2 = Input.GetAxis ("Vertical_P2");
        //Fonction responsable du mouvement

		MovePlayer (h1, v1, 1);
		MovePlayer (h2, v2, 2);
    }

	void MovePlayer( float h, float v, int player)
    {
		if (player == 1) {
			rigidBody1.velocity = new Vector2 (h * maxSpeed, v * maxSpeed);
			SetBool_H_V(h, v, 1);
		}
		else{
			rigidBody2.velocity = new Vector2 (h * maxSpeed, v * maxSpeed);
			SetBool_H_V(h, v, 2);
		}
        
    }

	void SetBool_V(float v, int player)
    {
		if (player == 1) {
			if (v > 0) {
				animator1.SetBool ("GoUp", true);
				animator1.SetBool ("GoDown", false);
			} else if (v < 0) {
				animator1.SetBool ("GoUp", false);
				animator1.SetBool ("GoDown", true);
			} else {
				animator1.SetBool ("GoUp", false);
				animator1.SetBool ("GoDown", false);
			}
		} else {
			if (v > 0) {
				animator2.SetBool ("GoUp", true);
				animator2.SetBool ("GoDown", false);
			} else if (v < 0) {
				animator2.SetBool ("GoUp", false);
				animator2.SetBool ("GoDown", true);
			} else {
				animator2.SetBool ("GoUp", false);
				animator2.SetBool ("GoDown", false);
			}
		}
    }

	void SetBool_H_V(float h, float v, int player)
    {
		if (player == 1) {
			if (h > 0) {
				animator1.SetBool ("GoLeft", false);
				animator1.SetBool ("GoRight", true);
				SetBool_V (v, 1);
			} else if (h < 0) {
				animator1.SetBool ("GoLeft", true);
				animator1.SetBool ("GoRight", false);
				SetBool_V (v, 1);
			} else {
				animator1.SetBool ("GoLeft", false);
				animator1.SetBool ("GoRight", false);
				SetBool_V (v, 1);
			}
		} else {
			if (h > 0) {
				animator2.SetBool ("GoLeft", false);
				animator2.SetBool ("GoRight", true);
				SetBool_V (v, 2);
			} else if (h < 0) {
				animator2.SetBool ("GoLeft", true);
				animator2.SetBool ("GoRight", false);
				SetBool_V (v, 2);
			} else {
				animator2.SetBool ("GoLeft", false);
				animator2.SetBool ("GoRight", false);
				SetBool_V (v, 2);
			}
		}
    }
}
