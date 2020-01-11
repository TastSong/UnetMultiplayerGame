using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayController : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer == false)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * h * 120 * Time.deltaTime);
        transform.Translate(Vector3.forward * v * 3 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    public override void OnStartLocalPlayer()
    {//本地角色生成时调用此方法
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    [Command]//此特性表示下面的方法只能在server运行，但是方法名前面要有Cmd
    void CmdFire()
    {//子弹的生成是server完成，然后同步到client
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
        Destroy(bullet, 2);

        NetworkServer.Spawn(bullet);
    }
}
