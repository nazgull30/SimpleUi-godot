namespace Example;

using Godot;
using SimpleUi;
using SimpleUi.Src;
using VContainer;
using VContainer.Godot;

//just an example. in Godot use MonoInstaller
[GlobalClass]
public partial class SampleUiPrefabInstaller : ScriptableObjectInstaller
{
    [Export] private PackedScene _canvas;
    [Export] private PackedScene _simpleUiWindow;

    [Inject] private IObjectResolver _objectResolver;

    public override void Install(IContainerBuilder builder)
    {
        var canvasView = _objectResolver.Instantiate<CanvasLayer>(_canvas);
        canvasView.Layer = 1;
        ((LifetimeScope)builder.ApplicationOrigin).AddChild(canvasView);

        builder.BindUiView<SimpleUiController, SimpleUiWindow>(_simpleUiWindow, canvasView);

        builder.BindWindowsController<WindowsController>(EWindowLayer.Local);
    }
}
