using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractrivePictureSpawner : MonoBehaviour
{
    private const string HasNotFullPictureName = nameof(HasNotFullPictureName);

    [SerializeField] private InteractivePictureList _interactivePictures;
    [SerializeField] private Transform _spawnPoint;

    private InteractivePictureEnd _currentInteractivePicture;
    
    public int NumberNotFullPicture { get { return PlayerPrefs.GetInt(HasNotFullPictureName, -1); } set { PlayerPrefs.SetInt(HasNotFullPictureName, value); } }
    public Transform PicturePosition => _currentInteractivePicture.transform;

    public event Action Spawned;
    public event Action DrawEnded;
    public event Action Interactived;

    private void Awake()
    {
        Spawn(GetPictureToSpawn());
    }

    private void Spawn(InteractivePictureEnd picture)
    {
        if (_currentInteractivePicture != null)
        {
            _currentInteractivePicture.Interactived -= OnIntercative;
            _currentInteractivePicture.DrawEnded -= OnDrawEnded;
        }

        _currentInteractivePicture = Instantiate(picture, _spawnPoint);
        _currentInteractivePicture.Interactived += OnIntercative;
        _currentInteractivePicture.DrawEnded += OnDrawEnded;
        Spawned?.Invoke();
    }

    private InteractivePictureEnd GetPictureToSpawn()
    {
        if (SaveSystem.CurrentUnlockInteractivePicture < _interactivePictures.Pictures.Count)
        {
            return _interactivePictures.Pictures[SaveSystem.CurrentUnlockInteractivePicture];
        }
        else
        {
            if (NumberNotFullPicture == -1)
                NumberNotFullPicture = UnityEngine.Random.Range(0, _interactivePictures.Pictures.Count);

            return _interactivePictures.Pictures[NumberNotFullPicture];
        }
    }

    private void OnDrawEnded()
    {
        if (SaveSystem.CurrentUnlockInteractivePicture < _interactivePictures.Pictures.Count)
            SaveSystem.CurrentUnlockInteractivePicture++;

        NumberNotFullPicture = -1;
        DrawEnded?.Invoke();
        Invoke(nameof(DelaySpawn), SaveSystem.DelayWin);
    }

    private void OnIntercative()
    {
        Interactived?.Invoke();
    }

    private void DelaySpawn()
    {
        Spawn(GetPictureToSpawn());
    }
}
