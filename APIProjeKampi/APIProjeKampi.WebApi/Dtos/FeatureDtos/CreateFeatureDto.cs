﻿namespace APIProjeKampi.WebApi.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }

    }
}
