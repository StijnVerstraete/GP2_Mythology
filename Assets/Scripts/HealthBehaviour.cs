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

    // Start is called before the first frame update
    void Start()
    {
        // Find player first, then try and do thing with it...
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        _liveIndex = _player.Health;
    }

    // Update is called once per frame
    void Update()
    {
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
            _player.transform.position = _respawnPoint.position;
            _player.Health = 3;

            foreach (Image item in _lives)
            {
                item.sprite = _fullHeart;
            }
        }
    }
}
