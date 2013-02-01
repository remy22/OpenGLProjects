using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStructure
{
    class StateSystem
    {
        Dictionary<string, IGameObject> _stateStore = new Dictionary<string, IGameObject>();
        IGameObject _currentState = null;

        public void Update(double elapsedTime)
        {
            if (_currentState == null)
            {
                return;
            }
            _currentState.Update(elapsedTime);
        }

        public void Render()
        {
            if (_currentState == null)
            {
                return;
            }
            _currentState.Render();
        }

        public void AddState(string stateId, IGameObject state)
        {
            if (!(Exists(stateId)))
                _stateStore.Add(stateId, state);
            else return;
        }

        public void ChangeState(string stateId)
        {
            if ((Exists(stateId)))
            _currentState = _stateStore[stateId];
            else return;
        }

        public bool Exists(string stateId)
        {
            if (_stateStore.ContainsKey(stateId))
                return true;
            else return false;
        }

        public Dictionary<string, IGameObject> getDictionary()
        {
            return _stateStore;
        }
        
    }
}
