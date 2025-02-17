using UnityEngine;

namespace MVC
{
    public class Controller : MonoBehaviour
    {
        private View _view;
        private UnitData _unitData;

        private void Awake()
        {
            var unitData = Resources.Load("Data/UnitData 2");
            _unitData = unitData as UnitData;
            
            _view = GetComponent<View>();
            
            _view.increaseHealthButton.onClick.AddListener(OnClickHealthUp);
        }

        private void OnClickHealthUp()
        {
            _unitData.IncreaseUnitMaxStat(new UnitStat(100, 0, 0));
        }
    }
}