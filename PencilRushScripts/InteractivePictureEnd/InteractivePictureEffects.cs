using UnityEngine;

public class InteractivePictureEffects : MonoBehaviour
{
    [SerializeField] private InteractivePictureEnd _interactivePicture;
    [SerializeField] private ParticleSystem _drawEnd;
    [SerializeField] private ParticleSystem _hit;

    private void OnEnable()
    {
        _interactivePicture.DrawEnded += OnDrawEnded;
        _interactivePicture.Hitted += OnHitted;
    }

    private void OnDisable()
    {
        _interactivePicture.DrawEnded -= OnDrawEnded;
        _interactivePicture.Hitted -= OnHitted;
    }

    private void OnDrawEnded()
    {
        _drawEnd.Play();
    }

    private void OnHitted(Pencil pencil)
    {
        Instantiate(_hit, pencil.transform.position, Quaternion.identity);
    }
}
