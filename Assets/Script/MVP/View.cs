using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class View : MonoBehaviour
    {
        #region fields

        [SerializeField] private TextMeshProUGUI maxStatText;
        [SerializeField] private Button increaseHealthButton;

        private UnitData _unitData;
        private Presenter _presenter;

        #endregion

        private void Awake()
        {
            var unitData = Resources.Load("Data/UnitData 1");  //가져오기 편하게 로드
            _unitData = unitData as UnitData;

            _presenter = new Presenter(_unitData, this); //presenter 생성 및 데이터와 view 할당

            _unitData.OnInitialize(_presenter); //unitData는 ScriptableObject이기 때문에 따로 초기화가 불가능해서 함수로 초기화

            increaseHealthButton.onClick.AddListener(_presenter.IncreaseUnitMaxStat); //버튼 눌렀을 때 액션 추가 (Presenter 함수)
        }

        public void ChangeStatText(UnitData unitData)
        {
            maxStatText.SetText(
                $"MaxHealth : {unitData.UnitMaxStat.Health}\n MaxAttackPower : {unitData.UnitMaxStat.AttackPower}\n MaxDefensePower : {unitData.UnitMaxStat.DefensePower}");
        }
    }
}