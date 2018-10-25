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
        [Route("DPClusteringWithMultiManifold/{distanceType}")]
        public int[] DPClusteringWithMultiManifold([FromBody] DataMatrix<float> m,
            DistanceFunctionType distanceType = DistanceFunctionType.EuclideanDistance)
        {
            return DensityPeaksClusteringAlgorithms.MultiManifold(m.Matrix, 0, 0, distanceType);
        }

        [HttpPost]
        [Route("DPClusteringWithKNN/{distanceType}")]
        public int[] DPClusteringWithKNN([FromBody] DataMatrix<float> m,
            DistanceFunctionType distanceType = DistanceFunctionType.EuclideanDistance)
        {
            return DensityPeaksClusteringAlgorithms.KNN(m.Matrix, distanceType);
        }


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
    } 
}