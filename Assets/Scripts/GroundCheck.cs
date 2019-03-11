using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    #region Fields

    private LayerMask _mask;

    #endregion

    #region Properties

    public bool IsGrounded { get; set; }

    #endregion

    #region Methods

    private void OnTriggerEnter2D(Collider2D col)
    {
        SetGrounded(col);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        SetGrounded(col);
    }

    private void SetGrounded(Collider2D col)
    {
        IsGrounded = !(_mask == (_mask | (1 << col.gameObject.layer)));
    }

    #endregion

}
