using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CoreWeapon : NetworkBehaviour {

    public GameObject projectile;

    public virtual void OnAttackPressed()
    {

    }

    public virtual void OnAttackUnpressed()
    {

    }

    public virtual void OnAttack()
    {

    }
}
