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

        ChangeStatText();

        _unitData.Subscribe(ChangeStatText);
    }

    private void OnDisable()
    {
        _unitData.UnSubscribe(ChangeStatText);
    }

    private void ChangeStatText()
    {
        statText.SetText(
            $"Health : {_unitData.UnitStat.Health}\n AttackPower : {_unitData.UnitStat.AttackPower}\n DefensePower : {_unitData.UnitStat.DefensePower}");
    }
}