using System;
using UnityEngine;

namespace MVC
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/MVC/UnitData")]
    public class UnitData : ScriptableObject
    {
        #region Fields

        [SerializeField] private UnitStat unitMaxStat;
        public UnitStat UnitMaxStat => unitMaxStat;

        private View _view;

        #endregion

        public void OnInitialize(View view)
        {
            _view = view;
            _view.ChangeStatText(this);//시작하자마자 스탯 표시
        }

        private void OnValidate()//Inspector에서 변경 시에도 UI에 적용되게
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