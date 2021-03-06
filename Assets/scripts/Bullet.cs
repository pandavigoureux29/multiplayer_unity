﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Bullet : NetworkBehaviour {

    public enum State { LAUNCHED, DEAD }
    [SyncVar]
    public State CurrentState;

	// Use this for initialization
	void Start () {
        CurrentState = State.DEAD;
        //Die();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Launch(Vector3 _position)
    {
        gameObject.SetActive(true);
        CurrentState = State.LAUNCHED;
        transform.position = _position;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,6) ;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        CurrentState = State.DEAD;
    }
}
