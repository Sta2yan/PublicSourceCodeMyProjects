using UnityEngine;

public class InteracrivePictureSound : MonoBehaviour
{
    [SerializeField] private InteractivePictureEnd _picture;
    [SerializeField] private AudioSource _audio;

    private void OnEnable()
    {
        _picture.DrawEnded += OnDrawEnded;
    }

    private void OnDisable()
    {
        _picture.DrawEnded -= OnDrawEnded;
    }

    private void OnDrawEnded()
    {
        _audio.Play();
    }
}
