using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlanetCollision : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    public GameObject pe;

    public GameObject brokenPlanet;

    public float minLaunch = 50, maxLaunch = 150;

    void Start()
    {
        // Set up the rigidbody ref
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check for other planet
        if (other.gameObject.tag == "Planet")
        {
            // Get the other planets rb
            Rigidbody2D otherRb = other.gameObject.GetComponent<Rigidbody2D>();
            // Get its mass for easy use
            float otherMass = otherRb.mass;
            // If this planet is the smaller one
            if (rb.mass <= otherMass)
            {
                // Do particles things
                //PlayParticles();
                // Break the planet apart
                BreakApart();
            }
        }
    }

    void BreakApart()
    {
        GameObject obj = (GameObject)Instantiate(brokenPlanet, transform.position, new Quaternion(0, 0, 0, 1));
        obj.transform.localScale = this.transform.localScale;
        List<Rigidbody2D> childrenRB = new List<Rigidbody2D>();
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            GameObject child = obj.transform.GetChild(i).gameObject;
            if (child.tag == "Fragment")
                childrenRB.Add(child.GetComponent<Rigidbody2D>());
        }

        foreach (Rigidbody2D rigid in childrenRB)
        {
            Vector2 force = (Random.insideUnitCircle * Random.Range(minLaunch, maxLaunch));
            rigid.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
        }

        PlanetManager.instance.RemoveFromPlanetList( this.gameObject.GetComponent<PlanetObject>() );
        Destroy(this.gameObject);
    }

    void PlayParticles()
    {
        // Set up the particle
        GameObject obj = (GameObject)Instantiate(pe);
        // Set the particle's position
        obj.transform.position = this.transform.position;
        // Play the particles
        obj.GetComponent<ParticleSystem>().Play();
        // Destroy the particles after its set duration
        Destroy(obj, obj.GetComponent<ParticleSystem>().duration);
    }
}
