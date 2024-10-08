using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Input {
    [CreateAssetMenu(menuName = "PlayerInputProcessor")]
    public class PlayerInputProcessor : ScriptableObject, PlayerInputActions.IPlayerActions {
        PlayerInputActions inputActions;

        public event Action<Vector2> OnMove;
        public event Action OnAttack;
        void Initialize() {
            inputActions = new();
            inputActions.Enable();
            inputActions.Player.SetCallbacks(this);
            inputActions.Player.Enable();
        }
        void OnEnable() {
            Initialize();
        }
        void OnDisable() {
           Disable();
        }
        void Disable() {
            inputActions.Player.Disable();
        }
        void PlayerInputActions.IPlayerActions.OnMove(InputAction.CallbackContext context) {
            OnMove?.Invoke(context.ReadValue<Vector2>());
        }
        void PlayerInputActions.IPlayerActions.OnAttack(InputAction.CallbackContext context) {
            if (context.phase != InputActionPhase.Started) return;
            OnAttack?.Invoke();
        }
        public void OnInteract(InputAction.CallbackContext context) {
            // noop
        }
    }
}
