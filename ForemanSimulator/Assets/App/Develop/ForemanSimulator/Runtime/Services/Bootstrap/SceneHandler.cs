using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class SceneHandler
{
    public async UniTask LoadSceneAsync(int sceneIndex, LoadSceneMode mode = LoadSceneMode.Single, CancellationToken token = default)
    {
        var loading = SceneManager.LoadSceneAsync(sceneIndex, mode);
        loading.allowSceneActivation = false;

        while (!loading.isDone && loading.progress < 0.9f)
        {
            await UniTask.Yield(PlayerLoopTiming.Update, token);
        }

        loading.allowSceneActivation = true;
        await UniTask.Yield(PlayerLoopTiming.Update, token);
    }
}
