using System.Collections.Generic;
using UnityEngine;

public class HumanChanger : MonoBehaviour, IHumanAnimationVisitor
{
    [SerializeField] private HumanState _human;
    [SerializeField] private List<HumanModel> _models;

    private HumanModel _humanModel;

    public void Change()
    {
        if (_humanModel != null)
            _humanModel.gameObject.SetActive(false);

        var disableModels = _models.FindAll(model => model.gameObject.activeSelf == false);
        _humanModel = disableModels[UnityEngine.Random.Range(0, disableModels.Count)].Init(transform);
        _humanModel.gameObject.SetActive(true);
    }

    public void ChangeAnim(IdleState state)
        => _humanModel.ChangeIdle();

    public void ChangeAnim(WalkState state)
        => _humanModel.ChangeWalk();
}
