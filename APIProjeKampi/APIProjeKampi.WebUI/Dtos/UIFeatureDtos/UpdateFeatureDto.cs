﻿namespace APIProjeKampi.WebUI.Dtos.UIFeatureDtos
{
    public class UpdateFeatureDto
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
    }
}
