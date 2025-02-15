using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/UnitData")]
public class UnitData : ScriptableObject
{
    #region Fields

    [SerializeField] private UnitStat unitMaxStat;
    private UnitStat _currentUnitStat;
    public UnitStat UnitMaxStat => unitMaxStat;

    private Action<UnitData> _onChangedData;

    #endregion

    private void OnValidate()
    {
        _onChangedData?.Invoke(this);
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

    #region UnitStat

    public void IncreaseUnitStat(UnitStat unitStat)
    {
        unitMaxStat.Health += unitStat.Health;
        unitMaxStat.AttackPower += unitStat.AttackPower;
        unitMaxStat.DefensePower += unitStat.DefensePower;
        _onChangedData?.Invoke(this);
    }

    public void DecreaseUnitStat(UnitStat unitStat)
    {
        unitMaxStat.Health -= unitStat.Health;
        unitMaxStat.AttackPower -= unitStat.AttackPower;
        unitMaxStat.DefensePower -= unitStat.DefensePower;
        _onChangedData?.Invoke(this);
    }

    #endregion

    public void Subscribe(Action<UnitData> action)
    {
        _onChangedData += action;
    }

    public void UnSubscribe(Action<UnitData> action)
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