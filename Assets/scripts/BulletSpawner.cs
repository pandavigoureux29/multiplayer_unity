using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class BulletSpawner : NetworkBehaviour {

    [SerializeField] List<Bullet> m_bullets;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FireBullet(Vector3 _position)
    {
        if (!isServer)
            return;
        var bullet = GetBullet();
        if (bullet == null)
            return;
        bullet.Launch(_position);
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
