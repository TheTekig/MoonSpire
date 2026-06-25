using UnityEngine;

public class CuboColisao : MonoBehaviour
{
    [SerializeField] private AudioSource colisaoAudioSource;
    private void OnCollisionEnter(Collision collision)
    {
        colisaoAudioSource.PlayOneShot(colisaoAudioSource.clip);
    }
}
