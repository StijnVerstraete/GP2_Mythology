using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private Image[] _lives;
    [SerializeField]
    private Transform _respawnPoint;
    [SerializeField]
    private Sprite _fullHeart;
    [SerializeField]
    private Sprite _emptyHeart;

    private int _liveIndex;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Find player first, then try and do thing with it...
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        anim = _player.GetComponentInChildren<Animator>();

        _liveIndex = _player.Health;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsDeath", false);
        _liveIndex = _player.Health;

        switch (_liveIndex)
        {
            case 0:
                _lives[_liveIndex].sprite = _emptyHeart;
                break;
            case 1:
                _lives[_liveIndex].sprite = _emptyHeart;
                break;
            case 2:
                _lives[_liveIndex].sprite = _emptyHeart;
                break;
            default:
                
                break;
        }

        if (_liveIndex <= 0)
        {
            Camera.main.SendMessage("FadeOut");
            StartCoroutine(SetPlayerToStartPosition());
        }
    }

    private IEnumerator SetPlayerToStartPosition()
    {
        
        yield return new WaitForSeconds(1.5f);
        Camera.main.SendMessage("FadeIn");
        _player.transform.position = _respawnPoint.position;
        _player.Health = 3;

        _player.gameObject.SetActive(false);

        

        StartCoroutine(RisePlayerFromDeath());
    }

    private IEnumerator RisePlayerFromDeath(){

        yield return new WaitForSeconds(1.5f);
        
        foreach (Image item in _lives)
        {
            item.sprite = _fullHeart;
        }

        anim.SetBool("IsDeath", true);
        _player.gameObject.SetActive(true);
    }
}
