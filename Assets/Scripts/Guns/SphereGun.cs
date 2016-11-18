using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SphereGun : CoreWeapon
{
    
    public Transform exitZone;

    private float currentCooldownTimer;
    public float cooldown;

    void Update()
    {
        currentCooldownTimer += Time.deltaTime;
    }

    public override void OnAttackPressed()
    {
        base.OnAttackPressed();

        if (currentCooldownTimer <= cooldown)
        {
            currentCooldownTimer = 0;
            CmdShoot();
        }
    }

    [Command]
    void CmdShoot()
    {
        GameObject bullet = (GameObject)Instantiate(projectile, exitZone.position, transform.rotation);
        bullet.GetComponent<BulletMotor>().owner = transform;
        NetworkServer.Spawn(bullet);
    }
}
