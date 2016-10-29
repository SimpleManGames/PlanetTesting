using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalManager : MonoBehaviour
{
    private static PortalManager _instance;
    public static PortalManager instance { get { return _instance; } }

    private List<Portal> _portalList = new List<Portal>();
    public List<Portal> PortalList
    {
        get { return _portalList; }
        set { foreach (Portal p in value) _portalList.Add(p); }
    }

    public void AddPortal(Portal add) { _portalList.Add(add); }

    public Portal GetRandomPortal
    {
        get
        {
            return _portalList[Random.Range(0, _portalList.Count)];
        }
    }
    public int teleportDelay = 3;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else
            Destroy(gameObject);
        
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Portal"))
            _portalList.Add(obj.GetComponent<Portal>());
    }
}
