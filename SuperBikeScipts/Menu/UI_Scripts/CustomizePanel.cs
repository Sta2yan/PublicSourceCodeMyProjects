using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class CustomizePanel : MonoBehaviour
{
    [SerializeField] private Button _suit;
    [SerializeField] private Button _bike;
    [SerializeField] private Button _helmet;
    [SerializeField] private Button _boots;
    [SerializeField] private ButtonsCustomizeSelectorView _suitCustomize;
    [SerializeField] private ButtonsCustomizeSelectorView _bikeCustomize;
    [SerializeField] private ButtonsCustomizeSelectorView _helmetCustomize;
    [SerializeField] private ButtonsCustomizeSelectorView _bootsCustomize;
    [SerializeField] private List<ItemCostume> _suitItems;
    [SerializeField] private List<ItemCostume> _bikeItems;
    [SerializeField] private List<ItemCostume> _helmetItems;
    [SerializeField] private List<ItemCostume> _bootsItems;
    [SerializeField] private BuyButtonCustomize _buttonCustomize;
    [SerializeField] private CustomizatorSystem _customizatorSystem;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _money2;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;

        _buttonCustomize.Used += OnUsed;
        _buttonCustomize.Rewarded += OnRewarded;
        _buttonCustomize.Buy += OnBuy;
        _suit.onClick.AddListener(OnChangeButtonSuit);
        _bike.onClick.AddListener(OnChangeButtonBike);
        _helmet.onClick.AddListener(OnChangeButtonHelmet);
        _boots.onClick.AddListener(OnChangeButtonBoots);
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void OnDisable()
    {
        ResetCustomize();

        YandexGame.GetDataEvent -= GetLoad;

        _buttonCustomize.Used -= OnUsed;
        _buttonCustomize.Rewarded -= OnRewarded;
        _buttonCustomize.Buy -= OnBuy;

        _suit.onClick.RemoveListener(OnChangeButtonSuit);
        _bike.onClick.RemoveListener(OnChangeButtonBike);
        _helmet.onClick.RemoveListener(OnChangeButtonHelmet);
        _boots.onClick.RemoveListener(OnChangeButtonBoots);
    }

    public void View(ItemCostume obj)
    {
        for (int i = 0; i < _suitItems.Count; i++)
            if (_suitItems[i] == obj)
                _customizatorSystem.ChangeCostumeMaterial(i);

        for (int i = 0; i < _bikeItems.Count; i++)
            if (_bikeItems[i] == obj)
                _customizatorSystem.ChangeBikeMaterial(i);

        for (int i = 0; i < _helmetItems.Count; i++)
            if (_helmetItems[i] == obj)
                _customizatorSystem.ChangeHelmetMaterial(i);

        for (int i = 0; i < _bootsItems.Count; i++)
            if (_bootsItems[i] == obj)
                _customizatorSystem.ChangeBootMaterial(i);
    }

    private void OnUsed(ItemCostume obj)
    {
        UseItem(obj);

        _buttonCustomize.ResetView();
    }

    private void OnRewarded(ItemCostume obj)
    {
        if (obj.CurrentCountReward < obj.CountReward - 1)
        {
            YandexGame.RewVideoShow(0);
            obj.CurrentCountReward++;
        }
        else
        {
            YandexGame.RewVideoShow(0);
            UnlockItem(obj);
        }

        _buttonCustomize.ResetView();
    }

    private void OnBuy(ItemCostume obj)
    {
        if (obj.Cost <= YandexGame.savesData.Money)
        {
            YandexGame.savesData.Money -= obj.Cost;
            _money.text = "$" + YandexGame.savesData.Money.ToString();
            _money2.text = "$" + YandexGame.savesData.Money.ToString();
            UnlockItem(obj);
        }

        _buttonCustomize.ResetView();
    }

    private void UseItem(ItemCostume obj)
    {
        for (int i = 0; i < _suitItems.Count; i++)
        {
            if (_suitItems[i] == obj)
            {
                YandexGame.savesData.Costume = i;
                _customizatorSystem.ChangeCostumeMaterial(i);

                for (int j = 0; j < _suitItems.Count; j++)
                    _suitItems[j].IsUse = false;

                obj.IsUse = true;

                return;
            }
        }

        for (int i = 0; i < _bikeItems.Count; i++)
        {
            if (_bikeItems[i] == obj)
            {
                YandexGame.savesData.Bike = i;
                _customizatorSystem.ChangeBikeMaterial(i);

                for (int j = 0; j < _bikeItems.Count; j++)
                    _bikeItems[j].IsUse = false;

                _bikeItems[i].IsUse = true;

                return;
            }
        }

        for (int i = 0; i < _helmetItems.Count; i++)
        {
            if (_helmetItems[i] == obj)
            {
                YandexGame.savesData.Helmet = i;
                _customizatorSystem.ChangeHelmetMaterial(i);

                for (int j = 0; j < _helmetItems.Count; j++)
                    _helmetItems[j].IsUse = false;

                _helmetItems[i].IsUse = true;

                return;
            }
        }

        for (int i = 0; i < _bootsItems.Count; i++)
        {
            if (_bootsItems[i] == obj)
            {
                YandexGame.savesData.Boot = i;
                _customizatorSystem.ChangeBootMaterial(i);

                for (int j = 0; j < _bootsItems.Count; j++)
                    _bootsItems[j].IsUse = false;

                _bootsItems[i].IsUse = true;

                return;
            }
        }
    }

    private void UnlockItem(ItemCostume obj)
    {
        for (int i = 0; i < _suitItems.Count; i++)
            {
                if (_suitItems[i] == obj)
                {
                    _suitItems[i].IsUnlock = true;
                    YandexGame.savesData.IsUnlockCostumes[i] = true;
                    return;
                }
            }

        for (int i = 0; i < _bikeItems.Count; i++)
        {
            if (_bikeItems[i] == obj)
            {
                _bikeItems[i].IsUnlock = true;
                YandexGame.savesData.IsUnlockBikes[i] = true;
                return;
            }
        }

        for (int i = 0; i < _helmetItems.Count; i++)
        {
            if (_helmetItems[i] == obj)
            {
                _helmetItems[i].IsUnlock = true;
                YandexGame.savesData.IsUnlockHelmets[i] = true;
                return;
            }
        }

        for (int i = 0; i < _bootsItems.Count; i++)
        {
            if (_bootsItems[i] == obj)
            {
                _bootsItems[i].IsUnlock = true;
                YandexGame.savesData.IsUnlockBoots[i] = true;
                return;
            }
        }
    }

    private void OnChangeButtonSuit()
    {
        ResetCustomize();

        _suitCustomize.Press(_suitCustomize.Buttons[YandexGame.savesData.Costume]);
        _buttonCustomize.ResetView(_suitItems[YandexGame.savesData.Costume]);
    }

    private void OnChangeButtonBike()
    {
        ResetCustomize();

        _bikeCustomize.Press(_bikeCustomize.Buttons[YandexGame.savesData.Bike]);
        _buttonCustomize.ResetView(_bikeItems[YandexGame.savesData.Bike]);
    }

    private void OnChangeButtonHelmet()
    {
        ResetCustomize();

        _helmetCustomize.Press(_helmetCustomize.Buttons[YandexGame.savesData.Helmet]);
        _buttonCustomize.ResetView(_helmetItems[YandexGame.savesData.Helmet]);
    }

    private void OnChangeButtonBoots()
    {
        ResetCustomize();

        _bootsCustomize.Press(_bootsCustomize.Buttons[YandexGame.savesData.Boot]);
        _buttonCustomize.ResetView(_bootsItems[YandexGame.savesData.Boot]);
    }
    
    private void ResetCustomize()
    {
        _customizatorSystem.ChangeBikeMaterial(YandexGame.savesData.Bike);
        _customizatorSystem.ChangeBootMaterial(YandexGame.savesData.Boot);
        _customizatorSystem.ChangeCostumeMaterial(YandexGame.savesData.Costume);
        _customizatorSystem.ChangeHelmetMaterial(YandexGame.savesData.Helmet);
    }

    private void GetLoad()
    {
        for (int i = 0; i < _suitItems.Count; i++)
            _suitItems[i].IsUnlock = YandexGame.savesData.IsUnlockCostumes[i];

        for (int i = 0; i < _bikeItems.Count; i++)
            _bikeItems[i].IsUnlock = YandexGame.savesData.IsUnlockBikes[i];

        for (int i = 0; i < _helmetItems.Count; i++)
            _helmetItems[i].IsUnlock = YandexGame.savesData.IsUnlockHelmets[i];

        for (int i = 0; i < _bootsItems.Count; i++)
            _bootsItems[i].IsUnlock = YandexGame.savesData.IsUnlockBoots[i];

        _suitItems[YandexGame.savesData.Costume].IsUse = true;
        _bikeItems[YandexGame.savesData.Bike].IsUse = true;
        _helmetItems[YandexGame.savesData.Helmet].IsUse = true;
        _bootsItems[YandexGame.savesData.Boot].IsUse = true;
    }
}
