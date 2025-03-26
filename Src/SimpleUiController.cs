namespace SimpleUi;

using SimpleUi.Abstracts;
using SimpleUi.Src;
using VContainer;

public partial class SimpleUiController : UiController<SimpleUiWindow>, IInitializable
{
    public void Initialize()
    {
        View.Label.Text = "Hello, Simple Ui";
    }
}
