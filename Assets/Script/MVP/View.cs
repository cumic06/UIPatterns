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
            var unitData = Resources.Load("Data/UnitData 1");
            _unitData = unitData as UnitData;

            _presenter = new Presenter(_unitData, this);

            _unitData.OnInitialize(_presenter);

            increaseHealthButton.onClick.AddListener(_presenter.IncreaseUnitMaxStat);
        }

        public void ChangeStatText(UnitData unitData)
        {
            maxStatText.SetText(
                $"MaxHealth : {unitData.UnitMaxStat.Health}\n MaxAttackPower : {unitData.UnitMaxStat.AttackPower}\n MaxDefensePower : {unitData.UnitMaxStat.DefensePower}");
        }
    }
}