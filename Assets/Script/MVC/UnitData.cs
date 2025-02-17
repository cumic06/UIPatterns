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

        private View _view;

        #endregion

        public void OnInitialize(View view)
        {
            _view = view;
            _view.ChangeStatText(this);
        }

        private void OnValidate()
        {
            if (_view != null)
            {
                _view.ChangeStatText(this);
            }
        }

        #region UnitMaxStat

        public void IncreaseUnitMaxStat(UnitStat unitStat)
        {
            unitMaxStat.Health += unitStat.Health;
            unitMaxStat.AttackPower += unitStat.AttackPower;
            unitMaxStat.DefensePower += unitStat.DefensePower;

            _view.ChangeStatText(this);
        }

        public void DecreaseUnitMaxStat(UnitStat unitStat)
        {
            unitMaxStat.Health -= unitStat.Health;
            unitMaxStat.AttackPower -= unitStat.AttackPower;
            unitMaxStat.DefensePower -= unitStat.DefensePower;

            _view.ChangeStatText(this);
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