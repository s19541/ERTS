using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsModel;
using System;

namespace ErtsApiFetcher.ApiDataProcessors {
    public abstract class ApiDataProcessor<TParameter> : IApiDataProcessor<TParameter> where TParameter : IApiDataProcessorParameter {
        protected readonly ErtsContext context;

        public ApiDataProcessor(ErtsContext context) {
            this.context = context;
        }

        protected virtual Action<TParameter, ApiDataProcessorExecutor> PostProcessAction { get; }

        public void Process(TParameter parameter) {
            ProcessInternal(parameter);
            context.SaveChanges();
        }

        protected abstract void ProcessInternal(TParameter parameter);
    }
}
