using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ParticleColor : MonoBehaviour {
    
    private Color lastColor;
    private List<ParticleSystem> particleSys = new List<ParticleSystem>();
    [SerializeField]
    [Tooltip("The color of the childrens particle effects.")]
    private Color _color;
    public Color Color {
        get { return _color; }
        set { this._color = value; }
    }

    void SetParticles( ) {
        if ( particleSys.Count == 0 )
            for ( int i = 0; i < transform.childCount; i++ ) {
                ParticleSystem childParticle;
                if ( ( childParticle = transform.GetChild( i ).GetComponent<ParticleSystem>() ) != null )
                    particleSys.Add( childParticle );
            }
    }

    void Update( ) {
        SetParticles();
        if ( Color != lastColor ) {
            foreach ( ParticleSystem p in particleSys )
                p.startColor = (p.gameObject.tag == "Alpha") ? p.startColor = new Color( Color.r, Color.g, Color.b, 140.0f ) : p.startColor = Color;

            lastColor = Color;
        }
    }
}