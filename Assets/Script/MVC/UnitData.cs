using System;
using UnityEngine;

namespace MVC
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/MVC/UnitData")]
    public class UnitData : ScriptableObject
    {
        #region Fields

        [SerializeField] private GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField] private UnitStat unitMaxStat;
        public UnitStat UnitMaxStat => unitMaxStat;

        private UnitStat _currentUnitStat = new(0, 0, 0);
        public UnitStat CurrentUnitStat => _currentUnitStat;

        private View _view;

        #endregion

        public void OnInitialize(View view)
        {
            _view = view;
        }

        #region UnitMaxStat

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