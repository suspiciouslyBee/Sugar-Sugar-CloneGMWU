using UnityEngine;

public class Particle : MonoBehaviour
{
    Rigidbody2D particlePhys;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particlePhys = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
  
        //this probably wont scale well
        particlePhys.gravityScale = SceneDescriptor.localInstance.localDefaultGravityScale;

        /*if(Mathf.Abs(particlePhys.linearVelocityY) 
            > SceneDescriptor.localInstance.localMaxParticleSpeed)
        {*/

        //}

        particlePhys.linearVelocityY = Mathf.Clamp(particlePhys.linearVelocityY,
            -SceneDescriptor.localInstance.localMaxParticleSpeed,
            SceneDescriptor.localInstance.localMaxParticleSpeed);
    }
}
