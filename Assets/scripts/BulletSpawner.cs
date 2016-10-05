using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class BulletSpawner : NetworkBehaviour {

    [SerializeField] List<Bullet> m_bullets;

    [SerializeField] GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FireBullet(Vector3 _position)
    {
        /*var bullet = GetBullet();
        if (bullet == null)
            return;
        bullet.Launch(_position);*/
        // create the bullet object locally
        var bullet = (GameObject)Instantiate(
             prefab,
             _position,
             Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,1) * 4;

        // spawn the bullet on the clients
        NetworkServer.Spawn(bullet);

        // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
        Destroy(bullet, 2.0f);
    }

    Bullet GetBullet()
    {
        foreach(var bullet in m_bullets)
        {
            if (bullet.CurrentState == Bullet.State.DEAD)
                return bullet;
        }
        return null;
    }
}
