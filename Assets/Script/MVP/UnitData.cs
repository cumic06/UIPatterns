using System;
using UnityEngine;

namespace MVP
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/MVP/UnitData")]
    public class UnitData : ScriptableObject
    {
        #region Fields

        [SerializeField] private GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField] private UnitStat unitMaxStat;
        public UnitStat UnitMaxStat => unitMaxStat;

        private Presenter _presenter;

        #endregion

        public void OnInitialize(Presenter presenter)
        {
            _presenter = presenter;
        }

        #region UnitMaxStat

        private void OnValidate()
        {
            if (_presenter != null)
            {
                _presenter.UpdateView();
            }
        }

        public void IncreaseUnitMaxStat(UnitStat unitStat)
        {
            unitMaxStat.Health += unitStat.Health;
            unitMaxStat.AttackPower += unitStat.AttackPower;
            unitMaxStat.DefensePower += unitStat.DefensePower;
        }

        public void DecreaseUnitMaxStat(UnitStat unitStat)
        {
            unitMaxStat.Health -= unitStat.Health;
            unitMaxStat.AttackPower -= unitStat.AttackPower;
            unitMaxStat.DefensePower -= unitStat.DefensePower;
        }

        #endregion
    }

    [Serializable]
    public class UnitStat
    {
        public int Health;
        public int AttackPower;
        public int DefensePower;

        public UnitStat(int health, int attackPower, int defensePower)
        {
            Health = health;
            AttackPower = attackPower;
            DefensePower = defensePower;
        }
    }
}