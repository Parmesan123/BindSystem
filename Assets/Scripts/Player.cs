using InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector2 Position => transform.position;

    private void Update()
    {
        ReturnToMenu();
        Interact();
    }

    private void FixedUpdate()
    {
        HorizontalMove();
    }

    private void HorizontalMove()
    {
        Vector2 moveVector = new Vector2(BindProvider.GetInstance().GetBind(DirectionBindType.HorizontalMove).GetBindValue(), 0);

        if (moveVector.x != 0)
            transform.position = Position + moveVector * (_speed * Time.fixedDeltaTime);
    }

    private void Interact()
    {
        if(BindProvider.GetInstance().GetBind(KeyBindType.InteractBind).GetKeyDown())
            print("Interact was pressed");
        
        if(BindProvider.GetInstance().GetBind(KeyBindType.InteractBind).GetBindValue())
            print("Interact is pressed");
    }

    private void ReturnToMenu()
    {
        if (BindProvider.GetInstance().GetBind(KeyBindType.MenuBind).GetKeyDown())
            SceneManager.LoadScene("MainMenuScene");
    }
}
