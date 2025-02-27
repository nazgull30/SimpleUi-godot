namespace SimpleUi.Src;

using Godot;
using TextAndQuest.Game.Ui;
using VContainer;
using VContainer.Unity;

public partial class SampleUiMonoInstaller : MonoInstaller
{
    [Export] private SimpleUiWindow _simpleUiWindow;

    public override void Install(IContainerBuilder builder)
    {
        builder.BindUiView<SimpleUiController, SimpleUiWindow>(_simpleUiWindow);

        builder.Register<GameMainScreenWindow>(Lifetime.Singleton);
    }
}
