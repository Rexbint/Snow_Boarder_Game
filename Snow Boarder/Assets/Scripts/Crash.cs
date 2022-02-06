using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] float crashDelay = 0.5f;
    CircleCollider2D boarderHead;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool canSound = true;

    private void Start()
    {
        boarderHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && boarderHead.IsTouching(other.collider) && canSound)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            canSound = false;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
