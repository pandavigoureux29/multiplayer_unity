using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TriggerDeathBullet : NetworkBehaviour {

	void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            var bullet = _coll.gameObject.GetComponent<Bullet>();
            bullet.Die();
        }
    }
        
}
