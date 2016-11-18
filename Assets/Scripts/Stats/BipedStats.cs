using UnityEngine;
using System.Collections;

public class BipedStats : CoreStats
{

    #region Variables

    #region Modifiers

    public float jumpStrength;
    public float jumpLength;
    public float fastFallSpeed;

    public float acceleration;

    #endregion

    #region Components

    public CoreWeapon weapon;

    public CoreAccessory accessory;

    #endregion

    #region Properties

    public bool hasWeapon
    { get { return weapon != null || GetComponent<CoreWeapon>() != null; } }

    public bool hasAccessory
    { get { return accessory != null || GetComponent<CoreAccessory>() != null; } }

    #endregion

    #endregion

    #region Functions

    #region UnityFunctions

    // Use this for initialization
    protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}

    #endregion

    #endregion

}
