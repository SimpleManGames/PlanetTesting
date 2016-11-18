using UnityEngine;
using System.Collections;

public class CoreStats : MonoBehaviour
{

    #region Variables

    #region Modifiers

    public float moveSpeed;

    #endregion

    #region Components

    protected CoreMotor motor;

    #endregion

    #region Properties

    protected bool hasMotor
    { get { return motor != null || GetComponent<CoreMotor>() != null; } }

    #endregion

    #endregion

    #region Functions

    #region UnityFunctions

    // Use this for initialization
    protected virtual void Start ()
    {
        if(hasMotor)
            motor = GetComponent<CoreMotor>();
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
	
	}

    #endregion

    #endregion

}
