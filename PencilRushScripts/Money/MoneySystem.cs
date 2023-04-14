using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private LevelLoader _levelLoader;

    private void OnValidate()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnEnable()
    {
        _levelLoader.SceneNexted += OnMenuBacked;
    }

    private void OnDisable()
    {
        _levelLoader.SceneNexted -= OnMenuBacked;
    }

    public bool TryBuy(int price)
    {
        if ((SaveSystem.CurrentMoney - price) >= 0)
        {
            SaveSystem.CurrentMoney -= price;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanBuy(int price)
    {
        return (SaveSystem.CurrentMoney - price) >= 0;
    }

    private void OnMenuBacked()
    {
        SaveSystem.CurrentMoney += _levelSystem.RewardLevel;
        SaveSystem.AllMoney += _levelSystem.RewardLevel;
    }
}
