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

    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private HitEntity _hitEntity;

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

        try
        {
            _playerAttack = transform.parent.GetComponentInChildren<PlayerAttack>();
        }
        catch
        {
            Debug.Log("PlayerAttack Reference Missing on PlayerSoundManager ! Some Attack sounds won't play !");
        }
        try
        {
            _hitEntity = transform.parent.GetComponentInChildren<HitEntity>();
        }
        catch
        {
            Debug.Log("HitEntity Reference Missing on PlayerSoundManager ! Some Attack sounds won't play !");
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

        _playerAttack.OnAttack1 += PlaySwordSwingsSound;
        _hitEntity.OnHit += PlaySwordImpactSound;
    }
    private void OnDestroy()
    {
        _playerMovements.OnJump -= PlayStartJumpSound;
        _playerMovements.OnStopFall -= PlayStartJumpSound;

        _playerAttack.OnAttack1 -= PlaySwordSwingsSound;
        _hitEntity.OnHit -= PlaySwordImpactSound;
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

    #region Sword Sounds
    private void PlaySwordSwingsSound()
    {
        _audioSource.PlayOneShot(_playerSoundsData.PlayerSwordSwings[(int)Random.Range(0, _playerSoundsData.PlayerSwordSwings.Length - 1)]);
    }
    private void PlaySwordImpactSound()
    {
        _audioSource.PlayOneShot(_playerSoundsData.PlayerSwordImpact[(int)Random.Range(0, _playerSoundsData.PlayerSwordImpact.Length - 1)]);
    }
    #endregion
}
