using Cysharp.Threading.Tasks;

public class BootstrapRunner
{
    private readonly SceneHandler _sceneHandler;

    public BootstrapRunner(SceneHandler sceneHandler)
    {
        _sceneHandler = sceneHandler;
        StartAsync().Forget();
    }

    private async UniTaskVoid StartAsync()
    {
        await UniTask.DelayFrame(1);
        await _sceneHandler.LoadSceneAsync(1);
    }
}
