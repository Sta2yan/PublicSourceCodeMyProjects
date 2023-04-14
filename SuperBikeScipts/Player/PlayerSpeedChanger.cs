using UnityEngine;

[RequireComponent(typeof(ArcadeBikeController))]
public class PlayerSpeedChanger : MonoBehaviour
{
    private const string Grass = nameof(Grass);
    private const float StepToResetTime = .17f;
    private const float TimeToChangeSpeed = 700f;

    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private TrailRenderer _trailRenderer; 
    [SerializeField] private ParticleSystem _particle2;
    [SerializeField] private TrailRenderer _trailRenderer2;

    private ArcadeBikeController _controller;
    private float _normalSpeed;
    private float _grassSpeed = 20f;
    private float _time = 0f;

    private void Awake()
    {
        _controller = GetComponent<ArcadeBikeController>();
        _normalSpeed = _controller.MaxSpeed;
    }

    private void OnEnable()
    {
        _controller.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable()
    {
        _controller.SpeedChanged -= OnSpeedChanged;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= StepToResetTime)
        {
            _controller.MaxSpeed = _normalSpeed;
            _trailRenderer.enabled = false;
            _trailRenderer2.enabled = false;
            _particle.Stop();
            _particle2.Stop();
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.tag == Grass)
            {
                _controller.MaxSpeed = Mathf.MoveTowards(_controller.MaxSpeed, _grassSpeed, Time.deltaTime * TimeToChangeSpeed);
                _time = 0f;
                _trailRenderer.enabled = true;
                _trailRenderer2.enabled = true;
                _particle.Play();
                _particle2.Play();
            }
        }
    }

    private void OnSpeedChanged(float obj)
    {
        _normalSpeed = obj;
    }
}
