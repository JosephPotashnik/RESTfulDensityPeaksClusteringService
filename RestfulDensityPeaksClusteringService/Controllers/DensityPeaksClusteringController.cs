using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DensityPeaksClustering;
using RestfulDensityPeaksClusteringService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestfulDensityPeaksClusteringService.Controllers
{
    [Produces("application/json")]
    [Route("api/Cluster")]
    public class DensityPeaksClusteringController : Controller
    {
        //Functions From Data (Distance is computed here).

        [HttpPost]
        [Route("MultiManifold/{k}/{M}/{tuningType}/{distanceType}")]
        public int[] MultiManifold([FromBody] DataMatrix<float> mat, int k = 0, int M = 0, ClusterCentersTuningType tuningType = ClusterCentersTuningType.FineTuning,
            DistanceFunctionType distanceType = DistanceFunctionType.EuclideanDistance)
        {
            return DensityPeaksClusteringAlgorithms.MultiManifold(mat.Matrix, k, M, tuningType, distanceType);
        }

        [HttpPost]
        [Route("KNN/{k}/{tuningType}/{distanceType}")]
        public int[] KNN([FromBody] DataMatrix<float> m, int k = 0, ClusterCentersTuningType tuningType = ClusterCentersTuningType.FineTuning,
            DistanceFunctionType distanceType = DistanceFunctionType.EuclideanDistance)
        {
            return DensityPeaksClusteringAlgorithms.KNN(m.Matrix, k, tuningType, distanceType);
        }
        /*

        [HttpPost]
        [Route("DPClustering/{cutoffDistance}/{distanceType}")]
        public int[] DPClustering([FromBody] DataMatrix<float> m, double cutoffDistance,
            DistanceFunctionType distanceType = DistanceFunctionType.EuclideanDistance)
        {
            return DensityPeaksClusteringAlgorithms.DPClustering(m.Matrix, cutoffDistance, distanceType);
        }


        //Functions From Distance Matrix:

        [HttpPost]
        [Route("DPClusteringFromDistanceMatrix/{cutoffDistance}")]
        public int[] DPClusteringFromDistanceMatrix([FromBody] DistanceMatrix dMatrix, double cutoffDistance)
        {
            return DensityPeaksClusteringAlgorithms.DPClusteringFromDistanceMatrix(dMatrix, cutoffDistance);

        }

        [HttpPost]
        [Route("DPClusteringWithKNNFromDistanceMatrix")]
        public int[] DPClusteringWithKNNFromDistanceMatrix([FromBody] DistanceMatrix dMatrix)
        {
            return DensityPeaksClusteringAlgorithms.DPClusteringWithKNNFromDistanceMatrix(dMatrix);
        }

        [HttpPost]
        [Route("DPClusteringWithMultiManifoldFromDistanceMatrix")]
        public int[] DPClusteringWithMultiManifoldFromDistanceMatrix([FromBody] DistanceMatrix dMatrix)
        {
            return DensityPeaksClusteringAlgorithms.DPClusteringWithMultiManifoldFromDistanceMatrix(dMatrix);
        }
        */
    } 
}