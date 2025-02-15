using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statText;
    [SerializeField] private Button increaseHealthButton;

    private UnitData _unitData;
    private ViewModel _viewModel;

    private void Awake()
    {
        var unitData = Resources.Load("Data/UnitData");
        _unitData = unitData as UnitData;

        _viewModel = new ViewModel(_unitData);

        increaseHealthButton.onClick.AddListener(_viewModel.IncreaseHealth);

        ChangeStatText(_unitData);

        _viewModel.Subscribe(ChangeStatText);
    }

    private void OnDisable()
    {
        _viewModel.UnSubscribe(ChangeStatText);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var unitObject = Resources.Load("Prefabs/TestUnit");
            var spawnUnit = unitObject as Unit;
            spawnUnit.OnInitialize(_unitData.UnitMaxStat);
        }
    }

    private void ChangeStatText(UnitData unitData)
    {
        statText.SetText(
            $"Health : {unitData.UnitMaxStat.Health}\n AttackPower : {unitData.UnitMaxStat.AttackPower}\n DefensePower : {unitData.UnitMaxStat.DefensePower}");
    }
}