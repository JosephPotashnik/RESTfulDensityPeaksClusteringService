using Newtonsoft.Json;

namespace RestfulDensityPeaksClusteringService.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DataMatrix<T>
    {
        public DataMatrix(int numberOfDimensions, int numberOfSamples)
        {
            Matrix = new T[numberOfSamples][];

            for (var i = 0; i < numberOfSamples; i++)
                Matrix[i] = new T[numberOfDimensions];
        }

        [JsonProperty] public T[][] Matrix { get; set; }

        public int NumberOfSamples => Matrix?.Length ?? 0;
        public int DimensionOfSamples => Matrix[0]?.Length ?? 0;

        public T this[int i, int j]
        {
            get => Matrix[i][j];
            set => Matrix[i][j] = value;
        }

        //single indexer = returns the i-th sample.
        public T[] this[int i]
        {
            get => Matrix[i];
            set => Matrix[i] = value;
        }
    }
}