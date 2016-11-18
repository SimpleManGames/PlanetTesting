using UnityEngine;
using System.Collections;


public class ItemPickupObject : CoreObject
{

    private float currentRespawnTime;
    public float respawnTime;
    
    public enum Accessory {
        Empty = 0,
        Armor = 1
    }
    [SerializeField]
    public Accessory accessory;


    public enum Weapon {
        Empty = 0,
        SphereGun = 1
    }
    [SerializeField]
    public Weapon weapon;


	// Use this for initialization
	protected override void Start () {
        base.Start();
        currentRespawnTime = respawnTime;
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        currentRespawnTime += Time.deltaTime;
	}

    protected override void OnPlayerCollision(PlayerController player)
    {
        base.OnPlayerCollision(player);
        if (currentRespawnTime >= respawnTime && player.motor is BipedMotor)
        {
            if ( accessory != Accessory.Empty && ((BipedStats)player.stats).accessory == null) {
                switch ( accessory ) {
                    case Accessory.Armor:
                            ( ( BipedStats )player.stats ).accessory = player.gameObject.AddComponent<ArmorAccessory>();
                        break;
                }
            }
            if ( weapon != Weapon.Empty && ( ( BipedStats )player.stats ).weapon == null ) {
                switch ( weapon ) {
                    case Weapon.SphereGun:
                        ( ( BipedStats )player.stats ).weapon = player.gameObject.AddComponent<SphereGun>();
                        break;
                }
            }

            respawnTime = 0;
        }
    }
}
