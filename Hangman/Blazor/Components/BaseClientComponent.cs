using Blazor.Clients;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components
{
    public class BaseClientComponent : ComponentBase
    {
        [Inject]
        public JsInteropClient JsInterop { get; set; }

        [Inject]
        public SessionClass SessionClass { get; set; }

        [Inject]
        public IUriHelper UriHelper { get; set; }

        [Inject]
        public ApiClient ApiClient { get; set; }
    }
}
