using UnityEngine;
using System.Collections.Generic;

public class PlanetManager : MonoBehaviour {

    #region Variables

    #region Instance

    private static PlanetManager _instance;

    public static PlanetManager instance { get { return _instance; } }

    #endregion

    #region Components

    public List<PlanetObject> planets;

    public GameObject [ ] planetPrefabs;
    public int planetSpawnRange = 10;

    #endregion

    public int desiredAmount = 10;

    #endregion

    #region Functions

    #region UnityFunctions

    void Awake( ) {
        if ( !_instance )
            _instance = this;

        else
            Destroy( gameObject );
    }

    // Use this for initialization
    void Start( ) {
        planets = new List<PlanetObject>();

        foreach ( GameObject planet in GameObject.FindGameObjectsWithTag( "Planet" ) )
            planets.Add( planet.GetComponent<PlanetObject>() );
    }

    void Update( ) {
        SpawnPlanets();
    }

    #endregion

    #region Public

    public PlanetObject ClosestPlanet( Vector3 objectPosition ) {
        float dist = float.MaxValue;
        PlanetObject closest = null;

        foreach ( PlanetObject planet in planets ) {
            float distTest = Vector3.Distance( planet.transform.position, objectPosition ) - Vector3.Magnitude( planet.transform.localScale ) * 0.5f;

            if ( distTest < dist ) {
                dist = distTest;
                closest = planet;
            }
        }

        return closest;
    }

    #endregion

    #region Management

    void InitializePlanetList( ) {
        if(planets == null) planets = new List<PlanetObject>();

        foreach ( GameObject planet in GameObject.FindGameObjectsWithTag( "Planet" ) ) {
            planets.Add( planet.GetComponent<PlanetObject>() );
        }
    }

    void AddToPlanetList( PlanetObject planet ) { planets.Add( planet ); }

    public void RemoveFromPlanetList( PlanetObject planet ) {
        planets.Remove( planet );
    }

    void SpawnPlanets( ) {
        if ( planets.Count < desiredAmount ) {
            GameObject obj = Instantiate( planetPrefabs [ Random.Range( 0, planetPrefabs.Length ) ] );
            obj.transform.position = new Vector3( Random.onUnitSphere.x * planetSpawnRange, Random.onUnitSphere.y * planetSpawnRange, 0 );

            AddToPlanetList( obj.GetComponent<PlanetObject>() );
            //Destroy( obj.gameObject );
        }
    }

    #endregion

    #endregion

}
