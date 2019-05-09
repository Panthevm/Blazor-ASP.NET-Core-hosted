using Dekanat.Shared;
using Microsoft.AspNetCore.Components;

namespace Dekanat.Client.Services {
    public abstract class ChildElement<TParent> : ComponentBase {
        TParent Parent { get; set; }

        

    }
  



}