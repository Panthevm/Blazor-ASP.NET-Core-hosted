using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Dekanat.Client {

    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
        }
        int test;
        public void Configure(IComponentsApplicationBuilder app) {
            app.AddComponent<App>("app");
        }
    }
}
