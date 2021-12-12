using Microsoft.Extensions.DependencyInjection;
using System;

namespace ErtsApiFetcher._Infrastructure.ApiDataProcessors {
    public class ApiDataProcessorExecutor {

        private readonly IServiceProvider serviceProvider;

        public ApiDataProcessorExecutor(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }

        public void Execute<TParameter>(TParameter parameter) where TParameter : IApiDataProcessorParameter {
            var processor = serviceProvider.GetService<IApiDataProcessor<TParameter>>();
            processor.Process(parameter);
        }
    }
}
