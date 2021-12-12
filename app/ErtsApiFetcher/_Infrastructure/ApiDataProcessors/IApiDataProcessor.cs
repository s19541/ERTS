namespace ErtsApiFetcher._Infrastructure.ApiDataProcessors {
    public interface IApiDataProcessor<TParameter> where TParameter : IApiDataProcessorParameter {
        void Process(TParameter parameter);
    }
}
