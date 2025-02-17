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
            var unitData = Resources.Load("Data/UnitData"); //가져오기 편하게 로드
            _unitData = unitData as UnitData;

            _viewModel = new ViewModel(_unitData); //viewModel 생성 및 Unitdata(Model) 할당

            increaseHealthButton.onClick.AddListener(_viewModel.IncreaseHealth); //버튼 눌렀을 때 액션 추가 (ViewModel 함수)

            _viewModel.Subscribe(ChangeStatText); //ViewModel에 함수 구독 (데이터 바인딩)
        }

        private void OnDisable()
        {
            _viewModel.UnSubscribe(ChangeStatText);
        }

        /// <summary>
        /// 현재 스탯도 변경되는지 확인하기 위해서 유닛 생성
        /// </summary>
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