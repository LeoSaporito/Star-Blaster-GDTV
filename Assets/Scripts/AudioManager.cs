using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0, 1)] float damageVolume;
    public void PlayShootingSFX()
    {
        if (shootingClip != null)
        {
            PlayAudioClip(shootingClip, shootingVolume);
        }
    }
    public void PlayDamageClip()
    {
        if (damageClip != null)
        {
            PlayAudioClip(damageClip, damageVolume);
        }
    }

    void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
