using System;
using UnityEngine;

namespace MVVM
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/MVVM/UnitData")]
    public class UnitData : ScriptableObject
    {
        #region Fields

        [SerializeField] private GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField] private UnitStat unitMaxStat;
        public UnitStat UnitMaxStat => unitMaxStat;

        private UnitStat _currentUnitStat = new(0, 0, 0);
        public UnitStat CurrentUnitStat => _currentUnitStat;

        private Action<UnitData> _onChangedData; //데이터 변경시 실행 할 액션(Model에서만 변경된 경우 ex 적에게 공격 당함)

        #endregion

        private void OnValidate() //Inspector에서 변경 시에도 UI에 적용되게
        {
            _onChangedData?.Invoke(this);
        }

        public void OnInitialize()
        {
            _currentUnitStat =
                new UnitStat(unitMaxStat.Health, unitMaxStat.AttackPower, unitMaxStat.DefensePower); //현재 유닛 스탯 
            _onChangedData?.Invoke(this); //초기화 하자마자 데이터 바인딩
        }

        #region UnitMaxStat

        public void IncreaseUnitMaxStat(UnitStat unitStat)
        {
            unitMaxStat.Health += unitStat.Health;
            unitMaxStat.AttackPower += unitStat.AttackPower;
            unitMaxStat.DefensePower += unitStat.DefensePower;
            _onChangedData?.Invoke(this);
        }

        public void DecreaseUnitMaxStat(UnitStat unitStat)
        {
            unitMaxStat.Health -= unitStat.Health;
            unitMaxStat.AttackPower -= unitStat.AttackPower;
            unitMaxStat.DefensePower -= unitStat.DefensePower;
            _onChangedData?.Invoke(this);
        }

        #endregion

        /// <summary>
        /// 현재 스탯을 확인하는 부분은 MVVM에서만 사용했습니다.
        /// </summary>
        /// <param name="unitStat"></param>

        #region UnitStat

        public void IncreaseUnitStat(UnitStat unitStat)
        {
            _currentUnitStat.Health += unitStat.Health;
            _currentUnitStat.AttackPower += unitStat.AttackPower;
            _currentUnitStat.DefensePower += unitStat.DefensePower;
            _onChangedData?.Invoke(this);
        }

        public void DecreaseUnitStat(UnitStat unitStat)
        {
            _currentUnitStat.Health -= unitStat.Health;
            _currentUnitStat.AttackPower -= unitStat.AttackPower;
            _currentUnitStat.DefensePower -= unitStat.DefensePower;
            _onChangedData?.Invoke(this);
        }

        #endregion

        public void Subscribe(Action<UnitData> action) //액션 등록 (데이터 바인딩)
        {
            _onChangedData += action;
        }

        public void UnSubscribe(Action<UnitData> action) //액션 해제 (데이터 바인딩)
        {
            _onChangedData -= action;
        }
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