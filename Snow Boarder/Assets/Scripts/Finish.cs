using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] float finishDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    bool canSound = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && canSound)
        {
            finishEffect.Play();
            canSound = false;
            Invoke("ReloadScene", finishDelay);
            GetComponent<AudioSource>().Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
