using UnityEngine;

public class DustParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            dustEffect.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            dustEffect.Stop();
    }
}
