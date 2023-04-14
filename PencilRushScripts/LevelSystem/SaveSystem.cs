using System;
using UnityEngine;
using Agava.YandexGames;

public static class SaveSystem
{
    public const float DelayWin = 3f;
    private const string LeaderboardName = "Leaderboard";

    private const string CurrentLevelName = nameof(CurrentLevelName);
    private const string CountLevelName = nameof(CountLevelName);
    private const string CurrentMoneyName = nameof(CurrentMoneyName);
    private const string AllMoneyName = nameof(AllMoneyName);
    private const string CurrentUnlockInteractivePictureName = nameof(CurrentUnlockInteractivePictureName);
    private const string CurrentOpenedInteractivePictureName = nameof(CurrentOpenedInteractivePictureName);
    private const string CountUnlockInteractivePictureName = nameof(CountUnlockInteractivePictureName);
    private const string SaveIndexName = nameof(SaveIndexName);
    private const string GlobalMusicValueName = nameof(GlobalMusicValueName);

    public static event Action MoneyChanged;

    public static int CurrentLevel { get { return PlayerPrefs.GetInt(CurrentLevelName, 0); } set { PlayerPrefs.SetInt(CurrentLevelName, value); } }
    public static int CountLevel { get { return PlayerPrefs.GetInt(CountLevelName, 0); } set { PlayerPrefs.SetInt(CountLevelName, value); } }
    public static int CurrentMoney { get { return PlayerPrefs.GetInt(CurrentMoneyName, 0); } set { PlayerPrefs.SetInt(CurrentMoneyName, value); MoneyChanged?.Invoke(); } }
    public static int CurrentUnlockInteractivePicture { get { return PlayerPrefs.GetInt(CurrentUnlockInteractivePictureName, 0); } set { PlayerPrefs.SetInt(CurrentUnlockInteractivePictureName, value); } }
    public static int CurrentOpenedInteractivePicture { get { return PlayerPrefs.GetInt(CurrentOpenedInteractivePictureName, 0); } set { PlayerPrefs.SetInt(CurrentOpenedInteractivePictureName, value); } }
    public static int CountUnlockInteractivePicture { get { return PlayerPrefs.GetInt(CountUnlockInteractivePictureName, 0); } set { PlayerPrefs.SetInt(CountUnlockInteractivePictureName, value); } }
    public static string SaveIndex { get { return PlayerPrefs.GetString(SaveIndexName, "Menu"); } set { PlayerPrefs.SetString(SaveIndexName, value); } }
    public static float GlobalMusicValue { get { return PlayerPrefs.GetFloat(GlobalMusicValueName, 1); } set { PlayerPrefs.SetFloat(GlobalMusicValueName, value); } }
    public static int AllMoney { get { return PlayerPrefs.GetInt(AllMoneyName, 0); }
                                                 set { Leaderboard.GetPlayerEntry(LeaderboardName, (result) => Leaderboard.SetScore(LeaderboardName, value)); PlayerPrefs.SetInt(AllMoneyName, value); } }

    public static class Upgrader
    {
        private const string CountUpgradeLevelName = nameof(CountUpgradeLevelName);
        private const string CountUpgradeCostName = nameof(CountUpgradeCostName);
        private const string PowerUpgradeLevelName = nameof(PowerUpgradeLevelName);
        private const string PowerUpgradeCostName = nameof(PowerUpgradeCostName);
        private const string PaintUpgradeLevelName = nameof(PaintUpgradeLevelName);
        private const string PaintUpgradeCostName = nameof(PaintUpgradeCostName);

        public static int CountUpgradeLevel { get { return PlayerPrefs.GetInt(CountUpgradeLevelName, 1); } set { PlayerPrefs.SetInt(CountUpgradeLevelName, value); } }
        public static int CountUpgradeCost { get { return PlayerPrefs.GetInt(CountUpgradeCostName, 50); } set { PlayerPrefs.SetInt(CountUpgradeCostName, value); } }
        public static int PowerUpgradeLevel { get { return PlayerPrefs.GetInt(PowerUpgradeLevelName, 1); } set { PlayerPrefs.SetInt(PowerUpgradeLevelName, value); } }
        public static int PowerUpgradeCost { get { return PlayerPrefs.GetInt(PowerUpgradeCostName, 50); } set { PlayerPrefs.SetInt(PowerUpgradeCostName, value); } }
        public static int PaintUpgradeLevel { get { return PlayerPrefs.GetInt(PaintUpgradeLevelName, 1); } set { PlayerPrefs.SetInt(PaintUpgradeLevelName, value); } }
        public static int PaintUpgradeCost { get { return PlayerPrefs.GetInt(PaintUpgradeCostName, 50); } set { PlayerPrefs.SetInt(PaintUpgradeCostName, value); } }
    }

    public static class PencilUpgrades
    {
        private const string Blue = nameof(Blue);
        private const string Red = nameof(Red);
        private const string Green = nameof(Green);
        private const string Purple = nameof(Purple);
        private const string Yellow = nameof(Yellow);
        private const string Pink = nameof(Pink);
        private const string Orange = nameof(Orange);

        public static int BlueCollect { get { return PlayerPrefs.GetInt(Blue, 0); } set { PlayerPrefs.SetInt(Blue, value); } }
        public static int RedCollect { get { return PlayerPrefs.GetInt(Red, 0); } set { PlayerPrefs.SetInt(Red, value); } }
        public static int GreenCollect { get { return PlayerPrefs.GetInt(Green, 0); } set { PlayerPrefs.SetInt(Green, value); } }
        public static int PurpleCollect { get { return PlayerPrefs.GetInt(Purple, 0); } set { PlayerPrefs.SetInt(Purple, value); } }
        public static int YellowCollect { get { return PlayerPrefs.GetInt(Yellow, 0); } set { PlayerPrefs.SetInt(Yellow, value); } }
        public static int PinkCollect { get { return PlayerPrefs.GetInt(Pink, 0); } set { PlayerPrefs.SetInt(Pink, value); } }
        public static int OrangeCollect { get { return PlayerPrefs.GetInt(Orange, 0); } set { PlayerPrefs.SetInt(Orange, value); } }
    }
}
