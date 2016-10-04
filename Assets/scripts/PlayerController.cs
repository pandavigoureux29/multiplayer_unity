using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    BulletSpawner m_bulletSpawner;

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        m_bulletSpawner = Component.FindObjectOfType<BulletSpawner>();
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    [Command]
    void CmdFire()
    {
        m_bulletSpawner.FireBullet(transform.position);
        //NetworkServer.Spawn(bullet);
    }
}
