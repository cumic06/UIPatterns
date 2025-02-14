using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/UnitData")]
public class UnitData : ScriptableObject
{
    [SerializeField] private UnitStat unitStat;
    public UnitStat UnitStat => unitStat;

    private Action _onChangedData;

    public void IncreaseUnitStat(UnitStat unitStat)
    {
        this.unitStat.Health += unitStat.Health;
        this.unitStat.AttackPower += unitStat.AttackPower;
        this.unitStat.DefensePower += unitStat.DefensePower;

        _onChangedData?.Invoke();
    }

    public void DecreaseUnitStat(UnitStat unitStat)
    {
        this.unitStat.Health -= unitStat.Health;
        this.unitStat.AttackPower -= unitStat.AttackPower;
        this.unitStat.DefensePower -= unitStat.DefensePower;
        
        _onChangedData?.Invoke();
    }

    public void Subscribe(Action action)
    {
        _onChangedData += action;
    }

    public void UnSubscribe(Action action)
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