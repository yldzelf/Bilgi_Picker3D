using UnityEngine.Events;
using Extensions;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<int> onSetNewLevelValue = delegate {  };
    }
}