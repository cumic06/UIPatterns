using UnityEngine;

namespace MVC
{
    public class Controller : MonoBehaviour
    {
        private View _view;
        private UnitData _unitData; //Model

        private void Awake()
        {
            var unitData = Resources.Load("Data/UnitData 2"); //가져오기 편하게 로드
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