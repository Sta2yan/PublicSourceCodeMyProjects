using UnityEngine;

public class ShooterInteractivePicture : MonoBehaviour
{
    private const int Reward = 100;

    [SerializeField] private EndLevelPanel _panel;
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private InteractrivePictureSpawner _pictureSpawner;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private float _delayEnable;

    private bool _isActive;
    private PencilFollower _follower;
    private float _currentDelay;
    private Transform _pictureTransform;

    public bool IsActive => _isActive;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
        _pictureSpawner = FindObjectOfType<InteractrivePictureSpawner>();
    }

    private void OnEnable()
    {
        _levelSystem.Finished_Follower += OnEnded;
        _pictureSpawner.DrawEnded += OnDrawEnded;
        _pictureSpawner.Interactived += OnInteractive;
    }

    private void OnDisable()
    {
        _levelSystem.Finished_Follower -= OnEnded;
        _pictureSpawner.DrawEnded -= OnDrawEnded;
        _pictureSpawner.Interactived -= OnInteractive;
    }

    private void Update()
    {
        if (_panel.IsPressed && _isActive)
            _currentDelay += Time.deltaTime;

        if (_currentDelay > _delayBetweenShots)
            PictureInteractive();
    }

    public void EnableShootByDelay(float delay)
    {
        Invoke(nameof(EnableShoot), delay);
    }

    private void OnEnded(PencilFollower follower)
    {
        _follower = follower;
        Invoke(nameof(EnableShoot), _delayEnable);
    }

    private void PictureInteractive()
    {
        if (_levelSystem.IsFinished)
        {
            if (_isActive)
            {
                _currentDelay = 0;

                var listPencils = _follower.LineSystemPencilsCount.Pencils;
                int count = _follower.LineSystemPencilsCount.Pencils.Count - 1;

                if (count < 0)
                {
                    _isActive = false;
                    _levelSystem.InvokeWin();
                    return;
                }

                Vector3 size = _pictureTransform.gameObject.GetComponent<BoxCollider>().size;
                float x = UnityEngine.Random.Range(-(size.z / 2), size.z / 2);
                float y = UnityEngine.Random.Range(-(size.y / 2), size.y / 2);
                GameObject go = new GameObject();
                go.transform.position = new Vector3(_pictureTransform.position.x + x, _pictureTransform.position.y + y, _pictureTransform.transform.position.z);

                if (listPencils[count] != null)
                    if (listPencils[count].TryGetComponent(out PencilShooter shooter))
                        shooter.PrepareShoot(go.transform);
            }
        }
    }

    private void EnableShoot()
    {
        _pictureTransform = _pictureSpawner.PicturePosition;
        _isActive = true;
    }

    private void OnDrawEnded()
    {
        _isActive = false;
        _pictureTransform = null;
        _levelSystem.AddReward(Reward);
    }

    private void OnInteractive()
    {
        EnableShoot();
    }
}
