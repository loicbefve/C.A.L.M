using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D m_RigidBody;
	private Animator m_Animator;

    public float maxSpeed = 5.0f;

	// Use this for initialization
	void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();
		m_Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Valeur entre -1 et 1 selon intentsité de frappe sur l'axe horizontal
        float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
        //Fonction responsable du mouvement
        MovePlayer(h, v);
    }

	void MovePlayer( float h, float v )
    {
		m_RigidBody.velocity = new Vector2(h*maxSpeed,v*maxSpeed);
    }
}
