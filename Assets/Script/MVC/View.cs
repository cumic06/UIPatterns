using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVC
{
    public class View : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI maxStatText;
        public Button increaseHealthButton;

        private UnitData _unitData;

        private void Awake()
        {
            var unitData = Resources.Load("Data/UnitData 2");  //가져오기 편하게 로드
            _unitData = unitData as UnitData;

            _unitData.OnInitialize(this); //unitData는 ScriptableObject이기 때문에 따로 초기화가 불가능해서 함수로 초기화
        }

        public void ChangeStatText(UnitData unitData)
        {
            maxStatText.SetText(
                $"MaxHealth : {unitData.UnitMaxStat.Health}\n MaxAttackPower : {unitData.UnitMaxStat.AttackPower}\n MaxDefensePower : {unitData.UnitMaxStat.DefensePower}");
        }
    }
}