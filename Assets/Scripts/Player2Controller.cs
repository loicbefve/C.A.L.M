﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    private Rigidbody2D rigidBody;
	private Animator animator;

    public float maxSpeed = 5.0f;
    private bool facingRight = false;

	private GameObject target;

    // Use this for initialization
    void Start () {
		
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		target = GameObject.Find ("Player1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Valeur entre -1 et 1 selon intentsité de frappe sur l'axe horizontal
        float h = Input.GetAxis ("Horizontal_P2");
		float v = Input.GetAxis ("Vertical_P2");
        //Fonction responsable du mouvement

		MovePlayer (h, v);
		float distance = Vector3.Distance (target.transform.position, transform.position);
		float direction = Vector3.Dot ((target.transform.position - transform.position).normalized, new Vector3(h, v, 0).normalized);
		if (Input.GetAxis ("Fire1_P2") > 0) {
			Fire ();
			if (distance < 1.0f && Mathf.Abs (direction) > 0.9f) {
				Debug.Log ("Hit !");
			}
		}
    }

	private void MovePlayer( float h, float v)
    {
		rigidBody.velocity = new Vector2 (h * maxSpeed, v * maxSpeed);
		SetBool_H_V(h, v);
		//Si on veut utiliser un miroir avec les sprites il faut ces lignes de code
		if ((h > 0 && facingRight) || (h < 0 && !facingRight))
		{
			Flip();
		}
    }

	private void SetBool_V(float v)
    {
		if (v > 0) {
			animator.SetBool ("GoUp", true);
			animator.SetBool ("GoDown", false);
		} else if (v < 0) {
			animator.SetBool ("GoUp", false);
			animator.SetBool ("GoDown", true);
		} else {
			animator.SetBool ("GoUp", false);
			animator.SetBool ("GoDown", false);
		}
    }

	void SetBool_H_V(float h, float v)
    {
		if (h > 0) {
			animator.SetBool ("GoLeft", false);
			animator.SetBool ("GoRight", true);
			SetBool_V (v);
		} else if (h < 0) {
			animator.SetBool ("GoLeft", true);
			animator.SetBool ("GoRight", false);
			SetBool_V (v);
		} else {
			animator.SetBool ("GoLeft", false);
			animator.SetBool ("GoRight", false);
			SetBool_V (v);
		}
    }

	private void Flip()
    {
		facingRight = !facingRight;
		Vector3 s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
    }

	private void Fire(){
	}
}
