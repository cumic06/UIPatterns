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
            var unitData = Resources.Load("Data/UnitData 2");
            _unitData = unitData as UnitData;

            _unitData.OnInitialize(this);
        }

        public void ChangeStatText(UnitData unitData)
        {
            maxStatText.SetText(
                $"MaxHealth : {unitData.UnitMaxStat.Health}\n MaxAttackPower : {unitData.UnitMaxStat.AttackPower}\n MaxDefensePower : {unitData.UnitMaxStat.DefensePower}");
        }
    }
}