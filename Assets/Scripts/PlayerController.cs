using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D m_RigidBody;

    public float maxSpeed = 5.0f;

	// Use this for initialization
	void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Valeur entre -1 et 1 selon intentsité de frappe sur l'axe horizontal
        float h = Input.GetAxis("Horizontal");
        //Fonction responsable du mouvement
        MovePlayer(h);
    }

    void MovePlayer( float h )
    {
        m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, m_RigidBody.velocity.y + maxSpeed /1.5f);
    }
}
