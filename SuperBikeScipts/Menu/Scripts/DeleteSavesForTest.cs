using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class DeleteSavesForTest : MonoBehaviour
{
    public void Delete()
    {
        YandexGame.ResetSaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddLevel()
    {
        YandexGame.savesData.LevelComplete++;
    }

    public void AddMoney()
    {
        YandexGame.savesData.Money += 9999;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
