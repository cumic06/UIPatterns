using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public class View : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI maxStatText;
        [SerializeField] private TextMeshProUGUI currentStatText;
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
                var spawnUnit = Instantiate(_unitData.Prefab);
                var spawnedUnit = spawnUnit.GetComponent<Unit>();
                spawnedUnit.OnInitialize(_unitData);
            }
        }

        private void ChangeStatText(UnitData unitData)
        {
            maxStatText.SetText(
                $"MaxHealth : {unitData.UnitMaxStat.Health}\n MaxAttackPower : {unitData.UnitMaxStat.AttackPower}\n MaxDefensePower : {unitData.UnitMaxStat.DefensePower}");
            currentStatText.SetText(
                $"Health : {unitData.CurrentUnitStat.Health}\n AttackPower : {unitData.CurrentUnitStat.AttackPower}\n DefensePower : {unitData.CurrentUnitStat.DefensePower}");
        }
    }
}