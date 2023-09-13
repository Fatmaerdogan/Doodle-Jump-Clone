using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed = 10f;

	Rigidbody2D rb;
	BoxCollider2D boxCollider2D;
	float movement = 0f;

	bool Fly;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		boxCollider2D = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;
		if (transform.position.y < Camera.main.transform.position.y - 5)
		{
			GameManager.instance.GameEndActive();
			Destroy(gameObject, 1);
		}
	}

	void FixedUpdate()
	{

            Vector2 velocity = rb.velocity;
            velocity.x = movement;
            rb.velocity = velocity;

	}
	public void FlyJett()
	{

		boxCollider2D.enabled = false;
		transform.DOMove(transform.position +(Vector3.up * 50), 2.5f).OnComplete(() =>
		{
			Destroy(transform.GetChild(0).gameObject);
            boxCollider2D.enabled = true;
        });

    }
	
}
