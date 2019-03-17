using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    #region Fields

    //private LayerMask _mask;
    [SerializeField]
    private LayerMask _mask;

    #endregion

    #region Properties

    public bool IsGrounded { get; set; }

    #endregion

    #region Methods
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        SetGrounded(col);
        Debug.Log(col.gameObject.name);

        if (_mask == (_mask | (1 << col.gameObject.layer)))
        {
            IsGrounded = true;
        }
        //Debug.Log("trigger Enter: " + IsGrounded);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        SetGrounded(col);
        Debug.Log(col.gameObject.name);

        if (_mask == (_mask | (1 << col.gameObject.layer)))
        {
            IsGrounded = false;
        }

        //Debug.Log("trigger exit: " + IsGrounded);
    }

    private void SetGrounded(Collider2D col)
    {
        /*
         * (_mask == (_mask | (1 << col.gameObject.layer))) 
         *      geeft altijd true terug dus als je er een ! voor zet wordt dit altijd false
         *      de code controleert alleen of je layers overeenkomen
         */
        //IsGrounded = !(_mask == (_mask | (1 << col.gameObject.layer)));

        Debug.Log("setgrounded: " + !(_mask == (_mask | (1 << col.gameObject.layer))));
    }

    #endregion

}
