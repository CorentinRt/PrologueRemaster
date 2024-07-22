using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSoundManager : MonoBehaviour
{
    #region Fields

    private AudioSource _audioSource;

    [SerializeField] private PlayerSoundsDataSO _playerSoundsData;

    [SerializeField] private PlayerMovements _playerMovements;

    #endregion

    private void Reset()
    {
        try
        {
            _playerMovements = transform.parent.GetComponentInChildren<PlayerMovements>();
        }
        catch
        {
            Debug.Log("PlayerMovements Reference Missing on PlayerSoundManager ! Movements sounds won't play !");
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _playerMovements.OnJump += PlayStartJumpSound;
        _playerMovements.OnStopFall += PlayStartJumpSound;
    }
    private void OnDestroy()
    {
        _playerMovements.OnJump -= PlayStartJumpSound;
        _playerMovements.OnStopFall -= PlayStartJumpSound;
    }

    #region Jump/Land Sounds
    private void PlayStartJumpSound()
    {
        _audioSource.PlayOneShot(_playerSoundsData.PlayerJumpStarts[(int)Random.Range(0, _playerSoundsData.PlayerJumpStarts.Length - 1)]);
    }
    private void PlayLandJumpSound()
    {
        _audioSource.PlayOneShot(_playerSoundsData.PlayerJumpLandings[(int)Random.Range(0, _playerSoundsData.PlayerJumpLandings.Length - 1)]);
    }
    #endregion
}
