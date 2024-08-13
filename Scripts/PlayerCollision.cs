using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioSource painSound; // Assign in Inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Hit Spike!");
            PlayPainSound();
        }
    }

    void PlayPainSound()
    {
        if (painSound != null)
        {
            Debug.Log("Playing Pain Sound");
            painSound.Play();
        }
    }
}


