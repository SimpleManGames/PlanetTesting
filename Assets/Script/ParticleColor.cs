using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class ParticleColor : MonoBehaviour
{
    public Color particleColor;
    private Color lastColor;
    private Color regColor;
    private List<ParticleSystem> particleSys = new List<ParticleSystem>();

    void SetParticles()
    {
        if (particleSys.Count == 0)
            for (int i = 0; i < transform.childCount; i++)
            {
                ParticleSystem childParticle;
                if ((childParticle = transform.GetChild(i).GetComponent<ParticleSystem>()) != null)
                    particleSys.Add(childParticle);
            }
    }

    void Update()
    {
        SetParticles();
        if (particleColor != lastColor)
        {
            foreach (ParticleSystem p in particleSys)
                if (p.gameObject.tag == "Alpha") p.startColor = new Color(particleColor.r, particleColor.g, particleColor.b, 140.0f);
                else p.startColor = particleColor;

            lastColor = particleColor;
        }
    }
}