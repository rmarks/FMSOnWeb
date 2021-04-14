using Microsoft.AspNetCore.Components;

namespace ComponentLibrary.Tabs
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}
